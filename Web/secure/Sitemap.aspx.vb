Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlTypes
Imports Telerik.Web.UI

Imports Raven.Common

Namespace Raven.Web

    Public Class Sitemap
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        Protected WithEvents RadTreeViewSitemap As RadTreeView
#End Region

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then 'And Not RadTreeViewSitemap.IsCallBack Then
            Else
                GenerateSitemap()
            End If
        End Sub
#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean

        End Function

        Private Function CreateTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("MenuID", System.Type.GetType("System.Int32"))
                .Columns.Add("ParentMenuID", System.Type.GetType("System.Int32"))
                .Columns.Add("Caption", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Sub GenerateSitemap()
            '// Get UserGroupID from User
            Dim strUserGroupID As String = String.Empty
            Dim oUser As New BussinessRules.User

            oUser.UserID = MyBase.LoggedOnUserID.Trim
            If oUser.SelectOne.Rows.Count > 0 Then
                strUserGroupID = oUser.UserGroupID.Trim
            Else
                strUserGroupID = String.Empty
            End If
            oUser.Dispose()
            oUser = Nothing

            '// Get Report By UserGroupID from Menu
            Dim dt As DataTable
            Dim br As New BussinessRules.Menu
            br.UserGroupID = strUserGroupID.Trim
            dt = br.SelectByUserGroupID
            br.Dispose()
            br = Nothing

            Dim tmpTbl As DataTable = CreateTmpTable()
            Dim iRecCount As Integer = 0
            While dt.Rows.Count > iRecCount
                Dim _MenuID As Integer = CType(ProcessNull.GetInt32(dt.Rows(iRecCount)("MenuID")), Integer)
                Dim _ParentMenuID As Integer = CType(ProcessNull.GetInt32(dt.Rows(iRecCount)("ParentMenuID")), Integer)
                Dim _Caption As String = CType(dt.Rows(iRecCount)("Caption"), String)

                Dim row As DataRow = tmpTbl.NewRow

                row("MenuID") = _MenuID
                If _ParentMenuID = 0 Then
                    row("ParentMenuID") = DBNull.Value
                Else
                    row("ParentMenuID") = _ParentMenuID
                End If
                row("Caption") = _Caption.Trim

                tmpTbl.Rows.Add(row)

                iRecCount += 1
            End While

            '// set report data into RadTreeView
            RadTreeViewSitemap.DataTextField = "Caption"
            RadTreeViewSitemap.DataFieldID = "MenuID"
            RadTreeViewSitemap.DataFieldParentID = "ParentMenuID"

            RadTreeViewSitemap.DataValueField = "MenuID"

            RadTreeViewSitemap.DataSource = tmpTbl
            RadTreeViewSitemap.DataBind()
            RadTreeViewSitemap.ExpandAllNodes()
        End Sub
#End Region

#Region " Main Function Open, Save, Delete "

#End Region

    End Class

End Namespace