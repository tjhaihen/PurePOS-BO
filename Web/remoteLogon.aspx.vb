Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Common

Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class remoteLogin
        Inherits PageBase

        Private logonUserData As DataSet
        Private isRemoteLogin As Boolean
        Private sUserID, sPwd, sForm As String

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'isRemoteLogin = False

            'logonUserData = CType(PB_CacheLoggedOnUser, DataSet)

            'If Not logonUserData Is Nothing Then
            '    DoRemoteLogin()
            'End If

            If ReadQueryString() Then
                DoRemoteLogin()
            Else
                Response.Redirect("Logon.aspx")
                'Dim br As New BussinessRules.RavenUser
                'With br
                '    .UserID = sUserID.Trim
                '    If .SelectOneByUserID.Rows.Count > 0 Then
                '        If .Password = sPwd Then
                '            DoRemoteLogin(.UserGroupID.Trim)
                '        Else
                '            'Response.Redirect("Logon.aspx")
                '            commonFunction.MsgBox(Me, "1")
                '        End If
                '    Else
                '        'Response.Redirect("Logon.aspx")
                '        commonFunction.MsgBox(Me, "2")
                '    End If
                'End With
                'br.Dispose()
                'br = Nothing
            End If
        End Sub

        Private Sub DoRemoteLogin()
            If Not PB_CacheLoggedOnUser Is Nothing Then
                Response.Redirect("Secure/Main.aspx")
            Else
                Dim dtUser As New DataTable
                dtUser = commonFunction.TableUserLogin(sUserID.Trim)
                With dtUser
                    If .Rows.Count = 1 Then
                        If CType(.Rows(0)("Password"), String).Trim = sPwd.Trim Then
                            Dim ds As New DataSet
                            Dim dtUserGroupMenu As New DataTable
                            dtUserGroupMenu = commonFunction.TableMenuAuthorization(CType(.Rows(0)("UserGroupID"), String).Trim)
                            dtUser.TableName = "User"
                            dtUserGroupMenu.TableName = "UserGroupMenu"
                            ds.Tables.Add(dtUser)
                            ds.Tables.Add(dtUserGroupMenu)
                            MyBase.PB_CacheLoggedOnUser = ds
                            dtUserGroupMenu = Nothing
                            ds = Nothing
                            FormsAuthentication.SetAuthCookie(sUserID, False)
                            Response.Redirect("Secure/Main.aspx")
                        Else
                            Response.Redirect("Logon.aspx")
                        End If
                    Else
                        Response.Redirect("Logon.aspx")
                    End If
                End With
                dtUser = Nothing
            End If
            

            'Dim userData As DataSet

            'With New Security.UserManagement
            '    userData = .GetUserDataSetByUserGroup(strUserGroupID, sUserID, sPwd)
            'End With

            'If Not userData Is Nothing Then
            '    MyBase.PB_CacheLoggedOnUser = userData
            '    FormsAuthentication.SetAuthCookie(sUserID, False)
            '    Response.Redirect("Secure/Main.aspx")
            'Else
            '    'Response.Redirect("Logon.aspx")
            '    commonFunction.MsgBox(Me, "3")
            'End If
        End Sub

        Private Function ReadQueryString() As Boolean
            Dim bRetVal As Boolean = False

            sUserID = Request.QueryString("a")
            sPwd = Request.QueryString("b")

            If (Len(Trim(sUserID)) > 0) Then
                bRetVal = True
            End If

            Return bRetVal
        End Function

    End Class

End Namespace