Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Text
Imports System.Collections
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports Microsoft.VisualBasic

Imports Raven
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.SystemFramework

Imports Telerik.Web.UI

Namespace Raven.Web.Secure.Administrator

    Public Class ChangePassword
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Protected WithEvents txtUserID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUserGroupID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPasswordOld As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPasswordNew As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPasswordConfirm As System.Web.UI.WebControls.TextBox
        Protected WithEvents Toolbar As CSSToolbar

        Private ModuleId As String = "910"
#End Region

#Region " Control Events... "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew  '"clear"
                    PrepareScreen()
                Case CSSToolbarItem.tidSave  '"save"
                    _UpdatePassword()
            End Select
        End Sub
#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            txtUserID.Text = MyBase.LoggedOnUserID.Trim
            _OpenUser(RavenRecStatus.CurrentRecord)

            txtUserID.Enabled = False
            txtPasswordOld.Text = String.Empty
            txtPasswordNew.Text = String.Empty
            txtPasswordConfirm.Text = String.Empty

            commonFunction.Focus(Me, txtPasswordOld.ClientID)
        End Sub
#End Region

#Region " Main Function: CRUD "

        Private Sub _OpenUser(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(txtUserID.Text.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.User

            With br
                .UserID = txtUserID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtUserName.Text = .UserName.Trim
                    txtUserGroupID.Text = .UserGroupID.Trim
                Else
                    txtUserID.Text = String.Empty
                    txtUserName.Text = String.Empty
                    txtUserGroupID.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _UpdatePassword()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim br As New BussinessRules.User
            Dim um As New Security.UserManagement

            With br
                .UserID = txtUserID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    If um.GetHashString(txtPasswordOld.Text.Trim) = .Password.Trim Then
                        '// Password Old sudah benar
                        If txtPasswordNew.Text.Trim = txtPasswordConfirm.Text.Trim Then
                            '// Password New dan Password Confirm sudah sama
                            .NewPassword = um.GetHashString(txtPasswordNew.Text.Trim)
                            .UpdatePassword()
                            commonFunction.MsgBox(Me, "Your Password has been successfully changed.")
                            PrepareScreen()
                        Else
                            '// Password New dan Password Confirm tidak sama
                            commonFunction.MsgBox(Me, "Invalid Password. Confirm Password does not match to New Password.")
                            GoTo GoNext
                        End If
                    Else
                        '// Password Old salah
                        commonFunction.MsgBox(Me, "Invalid Password. Please check your Current Password.")
                        GoTo GoNext
                    End If
                Else
                    commonFunction.MsgBox(Me, "Invalid User ID.")
                    GoTo GoNext
                End If
            End With
GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtPasswordOld.ClientID)
        End Sub

#End Region

    End Class
End Namespace