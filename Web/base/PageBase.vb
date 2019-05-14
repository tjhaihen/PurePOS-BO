
Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.ComponentModel
Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic

Imports Raven.Common

Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class PageBase
        Inherits System.Web.UI.Page

        Private Const UNHANDLED_EXCEPTION As String = "Unhandled Exception:"

        Private Shared pageSecureUrlBase As String
        Private Shared pageUrlBase As String
        Private Shared pageUrlDokuwiki As String
        Private Shared urlSuffix As String

        'for RadCombo ItemRequest By Another Code
        'begin
        Protected Shared ItemCategoryIDTmp As String
        Protected Shared InventoryIDTmp As String
        Protected Shared SourceWhIDTmp As String
        Protected Shared SourceUnitIDTmp As String
        Protected Shared EntitiesSeqNoTmp As String
        Protected Shared PurchaseUnitIDTmp As String
        Protected Shared MutationIDTmp As String
        Protected Shared CurrencyTmp As String
        Protected Shared DCNoteIDTmp As String
        'end 


        Public Sub New()
            MyBase.New()
            Try
                urlSuffix = Context.Request.Url.Host
                pageUrlDokuwiki = "http://" & urlSuffix

                urlSuffix = Context.Request.Url.Host & Context.Request.ApplicationPath
                pageUrlBase = "http://" & urlSuffix
            Catch
            End Try
        End Sub

        Public Shared ReadOnly Property SecureUrlBase() As String
            Get
                If SecureUrlBase Is Nothing Then
                    If HisConfiguration.EnableSsl Then
                        pageSecureUrlBase = "https://"
                    Else
                        pageSecureUrlBase = "http://"
                    End If
                    pageSecureUrlBase = pageSecureUrlBase & urlSuffix
                End If
                SecureUrlBase = pageSecureUrlBase
            End Get
        End Property

        Public Shared ReadOnly Property UrlBase() As String
            Get
                UrlBase = pageUrlBase
            End Get
        End Property

        Public Shared ReadOnly Property UrlDokuwiki() As String
            Get
                UrlDokuwiki = pageUrlDokuwiki
            End Get
        End Property


        Public Shared ReadOnly Property UrlBaseforLB() As String
            Get
                Dim cn As New SqlClient.SqlConnection(HisConfiguration.ConfigurationConnectionString)
                Dim CmdToExecute As New SqlClient.SqlCommand
                Dim a As String

                CmdToExecute.CommandType = CommandType.Text
                CmdToExecute.Connection = cn
                CmdToExecute.CommandText = "Select url from app where appId='LB_'"

                Dim da As New SqlClient.SqlDataAdapter(CmdToExecute)
                Dim retval As New DataTable("APP")
                Try
                    cn.Open()
                    da.Fill(retval)
                    If retval.Rows.Count() > 0 Then
                        a = CType(retval.Rows(0)("url"), String)
                    End If

                    cn.Close()

                Catch ex As Exception

                Finally
                    CmdToExecute.Dispose()
                    retval.Dispose()
                    da.Dispose()
                End Try
                UrlBaseforLB = a
            End Get
        End Property
        Public Shared ReadOnly Property UrlBaseforRJ() As String
            Get
                Dim cn As New SqlClient.SqlConnection(HisConfiguration.ConfigurationConnectionString)
                Dim CmdToExecute As New SqlClient.SqlCommand
                Dim a As String

                CmdToExecute.CommandType = CommandType.Text
                CmdToExecute.Connection = cn
                CmdToExecute.CommandText = "Select url from app where appId='RJ_'"

                Dim da As New SqlClient.SqlDataAdapter(CmdToExecute)
                Dim retval As New DataTable("APP")
                Try
                    cn.Open()
                    da.Fill(retval)
                    If retval.Rows.Count() > 0 Then
                        a = CType(retval.Rows(0)("url"), String)
                    End If

                    cn.Close()

                Catch ex As Exception

                Finally
                    CmdToExecute.Dispose()
                    retval.Dispose()
                    da.Dispose()
                End Try
                UrlBaseforRJ = a
            End Get
        End Property

        Public Shared ReadOnly Property UrlBaseforMCU() As String
            Get
                Dim cn As New SqlClient.SqlConnection(HisConfiguration.ConfigurationConnectionString)
                Dim CmdToExecute As New SqlClient.SqlCommand
                Dim a As String

                CmdToExecute.CommandType = CommandType.Text
                CmdToExecute.Connection = cn
                CmdToExecute.CommandText = "Select url from app where appId='MCU_'"

                Dim da As New SqlClient.SqlDataAdapter(CmdToExecute)
                Dim retval As New DataTable("APP")
                Try
                    cn.Open()
                    da.Fill(retval)
                    If retval.Rows.Count() > 0 Then
                        a = CType(retval.Rows(0)("url"), String)
                    End If

                    cn.Close()

                Catch ex As Exception

                Finally
                    CmdToExecute.Dispose()
                    retval.Dispose()
                    da.Dispose()
                End Try
                UrlBaseforMCU = a
            End Get
        End Property

        Public Property Search_KeyField() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_KEYFIELD), String)
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_KEYFIELD)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_KEYFIELD) = Value
                End If
            End Set
        End Property

        Public Property Search_DescField() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_DESCFIELD), String)
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_DESCFIELD)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_DESCFIELD) = Value
                End If
            End Set
        End Property

        Public Property Search_IsOk() As Boolean
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_ISOK), Boolean)
                Catch
                    Return False
                End Try
            End Get
            Set(ByVal Value As Boolean)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_ISOK)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_ISOK) = Value
                End If
            End Set
        End Property

        Public Property Search_UserType() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_USERTYPE), String)
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_USERTYPE)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_USERTYPE) = Value
                End If
            End Set
        End Property

        Public Property Search_CtrlID() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_CTRLID), String)
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_CTRLID)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_CTRLID) = Value
                End If
            End Set
        End Property

        Public Property Search_Result() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT), String).Trim
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT) = Value
                End If
            End Set
        End Property

        Public Property Search_Result2() As String
            Get
                Try
                    Return CType(Session.Item(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT2), String).Trim
                Catch
                    Return ""
                End Try
            End Get
            Set(ByVal Value As String)
                If Value = Nothing Then
                    Session.Remove(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT2)
                Else
                    Session.Item(Web.commonFunction.KEY_CACHEBROWSE_SEARCHRESULT2) = Value
                End If
            End Set
        End Property

        'Public Property LoggedOnUser() As DataSet
        '    Get
        '        Try
        '            Return CType(Session.Item(Web.commonFunction.KEY_CACHEUSER), DataSet)
        '        Catch
        '            Return Nothing
        '        End Try
        '    End Get
        '    Set(ByVal Value As DataSet)
        '        If Value Is Nothing Then
        '            Session.Remove(Web.commonFunction.KEY_CACHEUSER)
        '        Else
        '            Session.Item(Web.commonFunction.KEY_CACHEUSER) = Value
        '        End If
        '    End Set
        'End Property

        'Public ReadOnly Property AllowRead(ByVal ModuleID As String) As Boolean
        '    Get
        '        Dim moduleSet As DataSet
        '        Dim moduleView As DataView
        '        Dim moduleRow As DataRowView

        '        If LoggedOnUser Is Nothing Then
        '            Return False
        '        Else
        '            moduleSet = LoggedOnUser
        '            moduleView = moduleSet.Tables("UserModules").DefaultView
        '            moduleView.RowFilter = "moduleid='" & ModuleID.ToString.Trim & "'"
        '            If moduleView.Count > 0 Then
        '                If CType(moduleView(0)("r_read"), Boolean) = True Then
        '                    Return True
        '                End If
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public ReadOnly Property AllowEdit(ByVal ModuleID As String) As Boolean
        '    Get
        '        Dim moduleSet As DataSet
        '        Dim moduleView As DataView
        '        Dim moduleRow As DataRowView

        '        If LoggedOnUser Is Nothing Then
        '            Return False
        '        Else
        '            moduleSet = LoggedOnUser
        '            moduleView = moduleSet.Tables("UserModules").DefaultView
        '            moduleView.RowFilter = "moduleid= '" & ModuleID.ToString.Trim & "'"

        '            If moduleView.Count > 0 Then
        '                If CType(moduleView(0)("r_edit"), Boolean) = True Then
        '                    Return True
        '                End If
        '            End If
        '        End If
        '    End Get
        'End Property
        'Public ReadOnly Property AllowDelete(ByVal ModuleID As String) As Boolean
        '    Get
        '        Dim moduleSet As DataSet
        '        Dim moduleView As DataView
        '        Dim moduleRow As DataRowView

        '        If LoggedOnUser Is Nothing Then
        '            Return False
        '        Else
        '            moduleSet = LoggedOnUser
        '            moduleView = moduleSet.Tables("UserModules").DefaultView
        '            moduleView.RowFilter = "moduleid= '" & ModuleID.ToString.Trim & "'"

        '            If moduleView.Count > 0 Then
        '                If CType(moduleView(0)("r_delete"), Boolean) = True Then
        '                    Return True
        '                End If
        '            End If
        '        End If
        '    End Get
        'End Property
        
        'Public ReadOnly Property LoggedOnUserPwd() As String
        '    Get
        '        Dim moduleSet As DataSet
        '        Dim moduleTable As DataTable
        '        Dim PWD As String

        '        moduleSet = LoggedOnUser
        '        If moduleSet Is Nothing Then
        '            PWD = String.Empty
        '        Else
        '            moduleTable = moduleSet.Tables("Users")
        '            If (moduleTable.Rows.Count = 1) Then
        '                PWD = CType(moduleTable.Rows(0)("Password"), String)
        '            End If
        '        End If

        '        Return PWD
        '    End Get
        'End Property
        'Public ReadOnly Property ModulePolicy(ByVal ModuleID As String) As String
        '    Get
        '        Try
        '            Dim moduleSet As DataSet
        '            Dim moduleView As DataView
        '            Dim moduleRow As DataRowView
        '            Dim sPolicy As New StringBuilder

        '            moduleSet = LoggedOnUser
        '            moduleView = moduleSet.Tables("UserModules").DefaultView
        '            moduleView.RowFilter = "moduleid = '" & ModuleID.ToString.Trim & "'"

        '            sPolicy.Append("[")
        '            If CType(moduleView(0)("r_read"), Boolean) = True Then
        '                sPolicy.Append("R")
        '            End If
        '            If CType(moduleView(0)("r_edit"), Boolean) = True Then
        '                sPolicy.Append("E")
        '            End If
        '            If CType(moduleView(0)("r_delete"), Boolean) = True Then
        '                sPolicy.Append("D")
        '            End If
        '            sPolicy.Append("]")

        '            Return sPolicy.ToString
        '        Catch
        '            Return ""
        '        End Try

        '    End Get
        'End Property

        Public ReadOnly Property LoggedOnUserGroupID() As String
            Get
                Dim moduleSet As DataSet
                Dim moduleTable As DataTable
                Dim UGID As String = String.Empty

                moduleSet = PB_CacheLoggedOnUser
                If moduleSet Is Nothing Then
                    UGID = String.Empty
                Else
                    moduleTable = moduleSet.Tables("User")
                    If (moduleTable.Rows.Count = 1) Then
                        UGID = CType(moduleTable.Rows(0)("UserGroupID"), String)
                    End If
                End If

                Return UGID.Trim
            End Get
        End Property

        Public ReadOnly Property LoggedOnUserID() As String
            Get
                Dim moduleSet As DataSet
                Dim moduleTable As DataTable
                Dim UID As String = String.Empty

                moduleSet = PB_CacheLoggedOnUser
                If moduleSet Is Nothing Then
                    UID = String.Empty
                Else
                    moduleTable = moduleSet.Tables("User")
                    If (moduleTable.Rows.Count = 1) Then
                        UID = CType(moduleTable.Rows(0)("UserID"), String)
                    End If
                End If

                Return UID.Trim
            End Get
        End Property

        Public Sub Logout()
            System.Web.Security.FormsAuthentication.SignOut()
            Session.Abandon()
            Session.Clear()
            Session.RemoveAll()
            Cache.Remove(commonFunction.Key_CacheLoggedOnUser)
            Cache.Remove(commonFunction.Key_CacheErrorMessage)
            HttpRuntime.Close()
        End Sub

        Public Property PB_CacheLoggedOnUser() As DataSet
            Get
                'Return CType(Session(commonFunction.Key_CacheLoggedOnUser), DataSet)
                Try
                    Dim str As String = Request.Cookies(commonFunction.Key_CacheLoggedOnUser).Value
                    Dim arrstr() As String = str.Split(CChar("|"))
                    Dim dt As New DataSet
                    Dim dttable As New DataTable
                    dttable.TableName = "User"
                    dttable.Columns.Add("UserID")
                    dttable.Columns.Add("Password")
                    dttable.Columns.Add("UserName")
                    dttable.Columns.Add("UserGroupID")
                    dttable.Columns.Add("CompanyID")
                    dttable.Columns.Add("CompanyName")
                    dttable.Columns.Add("LocationID")
                    dttable.Columns.Add("LocationName")
                    dttable.Columns.Add("UserGroupMenuResult")

                    Dim dtrow As DataRow = dttable.NewRow()
                    For i As Integer = 0 To arrstr.Length - 1
                        dtrow.Item(i) = arrstr(i)
                    Next
                    dttable.Rows.Add(dtrow)
                    dt.Tables.Add(dttable)

                    Dim dtUserGroupMenu As New DataTable
                    dtUserGroupMenu = commonFunction.TableMenuAuthorization(CType(dttable.Rows(0)("UserGroupID"), String).Trim)
                    dtUserGroupMenu.TableName = "UserGroupMenu"

                    dt.Tables.Add(dtUserGroupMenu)

                    Return dt
                Catch
                    Return Nothing
                End Try
            End Get
            Set(ByVal Value As DataSet)
                If Value Is Nothing Then
                    ' Logout()
                    Dim myCookie As HttpCookie
                    myCookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    myCookie.Expires = DateTime.Now.AddDays(-1D)
                    Response.Cookies.Add(myCookie)
                Else
                    'Session(commonFunction.Key_CacheLoggedOnUser) = Value
                    Dim str As String = ""
                    str += CType(Value.Tables("User").Rows(0)("UserID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("Password"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserGroupID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("CompanyID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("CompanyName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("LocationID"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("LocationName"), String) + "|"
                    str += CType(Value.Tables("User").Rows(0)("UserGroupMenuResult"), String)

                    Dim cookie As HttpCookie
                    cookie = New HttpCookie(commonFunction.Key_CacheLoggedOnUser)
                    cookie.Value = str
                    Response.SetCookie(cookie)
                End If
            End Set
        End Property

        Public ReadOnly Property PB_UserID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("UserID"), String)
            End Get
        End Property

        Public ReadOnly Property PB_pwd() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("Password"), String)
            End Get
        End Property

        Public ReadOnly Property PB_UserName() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("UserName"), String)
            End Get
        End Property

        Public ReadOnly Property PB_UserGroupID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupID"), String)
            End Get
        End Property

        Public Property PB_CompanyID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyID"), String)
            End Get
            Set(ByVal Value As String)
                PB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyID") = Value
            End Set
        End Property

        Public Property PB_CompanyName() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyName"), String)
            End Get
            Set(ByVal Value As String)
                PB_CacheLoggedOnUser.Tables("User").Rows(0)("CompanyName") = Value
            End Set
        End Property

        Public Property PB_LocationID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationID"), String)
            End Get
            Set(ByVal Value As String)
                PB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationID") = Value
            End Set
        End Property

        Public Property PB_LocationName() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationName"), String)
            End Get
            Set(ByVal Value As String)
                PB_CacheLoggedOnUser.Tables("User").Rows(0)("LocationName") = Value
            End Set
        End Property

        Public ReadOnly Property PB_UserGroupMenuResult() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("UserGroupMenuResult"), String)
            End Get
        End Property

        Public Property PB_MenuID() As String
            Get
                Return CType(PB_CacheLoggedOnUser.Tables("User").Rows(0)("MenuID"), String)
            End Get
            Set(ByVal Value As String)
                PB_CacheLoggedOnUser.Tables("User").Rows(0)("MenuID") = Value
            End Set
        End Property

        Public ReadOnly Property PB_UserGroupMenu() As DataTable
            Get
                Return PB_CacheLoggedOnUser.Tables("UserGroupMenu")
            End Get
        End Property

        Public Property PB_ErrorMessage() As String
            Get
                Return CType(Session(commonFunction.Key_CacheErrorMessage), String)
            End Get
            Set(ByVal Value As String)
                If Value Is Nothing Then
                    Session.Remove(commonFunction.Key_CacheErrorMessage)
                Else
                    Session(commonFunction.Key_CacheErrorMessage) = Value
                End If
            End Set
        End Property

        Public ReadOnly Property AllowRead(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                moduleView = moduleSet.Tables("UserGroupMenu").DefaultView
                moduleView.RowFilter = "MenuID = '" & MenuID.Trim & "'"

                If CType(moduleView(0)("IsAllowRead"), Boolean) = True Then
                    Return True
                End If
            End Get
        End Property
        Public ReadOnly Property AllowEdit(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                moduleView = moduleSet.Tables("UserGroupMenu").DefaultView
                moduleView.RowFilter = "MenuID = '" & MenuID.Trim & "'"

                If CType(moduleView(0)("IsAllowEdit"), Boolean) = True Then
                    Return True
                End If
            End Get
        End Property
        Public ReadOnly Property AllowDelete(ByVal MenuID As String) As Boolean
            Get
                Dim moduleSet As DataSet
                Dim moduleView As DataView

                moduleSet = PB_CacheLoggedOnUser
                moduleView = moduleSet.Tables("UserGroupMenu").DefaultView
                moduleView.RowFilter = "MenuID  = '" & MenuID.Trim & "'"

                If CType(moduleView(0)("IsAllowDelete"), Boolean) = True Then
                    Return True
                End If
            End Get
        End Property

        Protected Overrides Sub OnError(ByVal e As EventArgs)
            ApplicationLog.WriteError(ApplicationLog.FormatException(Server.GetLastError(), UNHANDLED_EXCEPTION))
            Session("Cached:Error:") = Server.GetLastError
            Server.Transfer(Context.Request.ApplicationPath + "/errMsg.aspx")
            MyBase.OnError(e)
        End Sub

    End Class

End Namespace