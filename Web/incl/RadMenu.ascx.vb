Option Strict On
Option Explicit On

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Telerik.Web.UI

Imports Raven.Web
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven
    Public MustInherit Class RadMenu
        Inherits ModuleBase

#Region "  Private Variables  "
        Private _MenuID As String
        
        Protected Function FullPathToTop(ByVal item As RadMenuItem) As ArrayList
            Dim pathList As New ArrayList

            pathList.Add(item)

            If TypeOf item.Owner Is RadMenu Then
                Return pathList
            Else
                Dim currentParent As IRadMenuItemContainer = item.Owner

                While Not TypeOf currentParent Is RadMenu
                    pathList.Add(currentParent)
                    currentParent = currentParent.Owner
                End While
            End If

            Return pathList
        End Function 'FullPathToTop
#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "  Control Events  "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not Page.IsPostBack Then
                initCompanyInfo()
                initUserInfo()
                CreateMenu()
            End If
        End Sub

        Private Sub RadMenu1_ItemClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs) Handles RadMenu1.ItemClick
            'lblMenuInfo.Text = e.Item.Value.Trim             
        End Sub

        Protected Sub RadMenu1_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
            Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
            If TypeOf row("Value") Is System.DBNull Or row("Value") Is String.Empty Then
                e.Item.PostBack = False
            End If
        End Sub

        Private Sub btnLogout_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnLogout.Click
            Response.Redirect(PageBase.UrlBase + "/Logout.aspx")
        End Sub
#End Region

#Region "  Private Functions  "
        Private Sub CreateMenu()
            Dim br As New BussinessRules.Menu

            '// Get Menu by UserGroupID
            Dim links As DataTable = New DataTable
            br.UserGroupID = MyBase.MB_UserGroupID
            links = commonFunction.TableMenuAuthorization(MyBase.MB_UserGroupID.Trim)

            '// Create Tmp Table for Menu
            '// This is for URL
            Dim tmpTbl As DataTable = CreateTmpTable()
            Dim iRecCount As Integer = 0
            While links.Rows.Count > iRecCount
                Dim _MenuID As Integer = CType(ProcessNull.GetInt32(links.Rows(iRecCount)("MenuID")), Integer)
                Dim _ParentMenuID As Integer = CType(ProcessNull.GetInt32(links.Rows(iRecCount)("ParentMenuID")), Integer)
                Dim _Caption As String = CType(links.Rows(iRecCount)("Caption"), String)
                Dim _Url As String = CType(links.Rows(iRecCount)("Url"), String)
                Dim _ImageUrl As String = CType(links.Rows(iRecCount)("ImageUrl"), String)

                Dim row As DataRow = tmpTbl.NewRow

                row("MenuID") = _MenuID
                If _ParentMenuID = 0 Then
                    row("ParentMenuID") = DBNull.Value
                Else
                    row("ParentMenuID") = _ParentMenuID
                End If
                row("Caption") = _Caption.Trim

                If _Url = "#" Then
                    row("Url") = ""
                Else
                    row("Url") = PageBase.UrlBase + "/Secure/" + _Url.Trim
                End If

                If _ImageUrl = "#" Then
                    row("ImageUrl") = ""
                Else
                    row("ImageUrl") = _ImageUrl.Trim
                End If

                tmpTbl.Rows.Add(row)

                iRecCount += 1
            End While

            '// set menu data into RadMenu
            RadMenu1.DataTextField = "Caption"
            RadMenu1.DataFieldID = "MenuID"
            RadMenu1.DataFieldParentID = "ParentMenuID"
            RadMenu1.DataNavigateUrlField = "Url"

            RadMenu1.DataSource = tmpTbl
            RadMenu1.DataBind()
        End Sub

        Private Function CreateTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("MenuID", System.Type.GetType("System.Int32"))
                .Columns.Add("ParentMenuID", System.Type.GetType("System.Int32"))
                .Columns.Add("Caption", System.Type.GetType("System.String"))
                .Columns.Add("Url", System.Type.GetType("System.String"))
                .Columns.Add("ImageUrl", System.Type.GetType("System.String"))
                '.Columns.Add("AccessKey", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Sub initCompanyInfo()
            If commonFunction.ValidateSerialNo() = False Then
                doLogout()
                Throw New Exception("This copy of program is NOT VALID. Please contact us to get your License Key.")
            End If

            Dim br As New BussinessRules.Company
            With br
                If .SelectOne.Rows.Count > 0 Then
                    lblCompanyName.Text = .CompanyName.Trim
                Else
                    lblCompanyName.Text = "[Company Name]"
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub initUserInfo()
            If MyBase.MB_CacheLoggedOnUser Is Nothing Then
                System.Web.Security.FormsAuthentication.SignOut()
                lblMessage.Text = "You are Logged Out. Please Log In again to continue using the system."
            Else
                lblMessage.Text = MyBase.MB_UserName.Trim + " [" + MyBase.MB_UserGroupID + "]"
            End If
        End Sub

        Private Sub doLogout()
            System.Web.Security.FormsAuthentication.SignOut()
            MB_CacheLoggedOnUser = Nothing
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()
            HttpRuntime.Close()
            For Each de As DictionaryEntry In HttpContext.Current.Cache
                HttpContext.Current.Cache.Remove(DirectCast(de.Key, String))
            Next

            Dim myCookie As HttpCookie
            myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
            myCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(myCookie)
        End Sub
#End Region

#Region " Public Property "
        'Public ReadOnly Property Menu_UserID() As String
        '    Get
        '        Return lblUserID.Text.Trim
        '    End Get
        'End Property

        'Public ReadOnly Property Menu_UserName() As String
        '    Get
        '        Return lblUserName.Text.Trim
        '    End Get
        'End Property

        'Public Property Menu_CompanyID() As String
        '    Get
        '        Return lblCompanyID.Text.Trim
        '    End Get
        '    Set(ByVal Value As String)
        '        lblCompanyID.Text = Value
        '    End Set
        'End Property

        Public Property Menu_CompanyName() As String
            Get
                Return lblCompanyName.Text.Trim
            End Get
            Set(ByVal Value As String)
                lblCompanyName.Text = Value
            End Set
        End Property

        'Public Property Menu_LocationID() As String
        '    Get
        '        Return lblLocationID.Text.Trim
        '    End Get
        '    Set(ByVal Value As String)
        '        lblLocationID.Text = Value
        '    End Set
        'End Property

        'Public Property Menu_LocationName() As String
        '    Get
        '        Return lblLocationName.Text.Trim
        '    End Get
        '    Set(ByVal Value As String)
        '        lblLocationName.Text = Value
        '    End Set
        'End Property

        'Public Property Menu_MenuID() As String
        '    Get
        '        Return _MenuID
        '    End Get
        '    Set(ByVal value As String)
        '        _MenuID = value
        '    End Set
        'End Property
#End Region
    End Class
End Namespace


