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

Imports Telerik.Web.UI

Imports Raven
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.SystemFramework

Namespace Raven.Web.Secure.Administrator

    Public Class User
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "112"
        Protected WithEvents lblRecordListCaption As Label
        Protected WithEvents lblUserGroupIDCaption As Label
        Protected WithEvents lblUserNameCaption As Label
        Protected WithEvents txtUserName As TextBox
        Protected WithEvents lblUserGroupNameCaption As Label
        Protected WithEvents txtUserGroupName As TextBox
        Protected WithEvents txtPassword As TextBox
        Protected WithEvents txtConfirmPassword As TextBox
        Protected WithEvents chkIsActive As CheckBox
        Protected WithEvents chkIsResetPassword As CheckBox
        Protected WithEvents ddlJobTitle As DropDownList
        Protected WithEvents chkIsResetAuthorizePassword As CheckBox
        Protected WithEvents txtAuthorizePassword As TextBox
        Protected WithEvents txtPrimaryPhoneNo As TextBox
        Protected WithEvents txtSecondaryPhoneNo1 As TextBox
        Protected WithEvents txtSecondaryPhoneNo2 As TextBox
        Protected WithEvents txtEmail As TextBox
        Protected WithEvents txtAddress As TextBox
        Protected WithEvents RadComboBoxUserID As RadComboBox
        Protected WithEvents RadComboBoxUserGroupID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As Label        
        Protected WithEvents RadGridUser As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
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

        Private Sub RadComboBoxUserGroupID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxUserGroupID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadUserGroup(e.Text)
        End Sub

        Private Sub RadComboBoxUserID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxUserID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadUser(e.Text)
        End Sub

        Private Sub RadComboBoxUserGroupID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxUserGroupID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UserGroupID").ToString()
        End Sub

        Private Sub RadComboBoxUserID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxUserID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UserID").ToString()
        End Sub

        Private Sub RadComboBoxUserGroupID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxUserGroupID.SelectedIndexChanged
            _OpenUserGroup()
        End Sub

        Private Sub RadComboBoxUserID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxUserID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidPrevious
                    _Open(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _Open(RavenRecStatus.NextRecord)
            End Select
        End Sub

        Private Sub chkIsResetPassword_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsResetPassword.CheckedChanged
            txtPassword.Text = String.Empty
            txtConfirmPassword.Text = String.Empty
            txtPassword.Enabled = chkIsResetPassword.Checked
            txtConfirmPassword.Enabled = chkIsResetPassword.Checked
            commonFunction.Focus(Me, txtPassword.ClientID)
        End Sub

        Private Sub chkIsResetAuthorizePassword_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsResetAuthorizePassword.CheckedChanged
            txtAuthorizePassword.Text = String.Empty
            txtAuthorizePassword.Enabled = chkIsResetAuthorizePassword.Checked
            commonFunction.Focus(Me, txtAuthorizePassword.ClientID)
        End Sub

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridUser_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridUser.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblUserID As Label = CType(e.Item.FindControl("_lblUserID"), Label)

                    RadComboBoxUserID.Text = _lblUserID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxUserID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.User

            With br
                .UserID = RadComboBoxUserID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxUserID.Text = .UserID.Trim
                    End If
                    txtUserName.Text = .UserName.Trim
                    RadComboBoxUserGroupID.Text = .UserGroupID.Trim
                    _OpenUserGroup()
                    chkIsActive.Checked = .isActive
                    '// validate IsActive CheckBox, so user cannot active/incavtive him/her-self
                    If RadComboBoxUserID.Text.Trim = MyBase.LoggedOnUserID.Trim Then
                        chkIsActive.Enabled = False
                    Else
                        chkIsActive.Enabled = True
                    End If
                    chkIsResetPassword.Checked = False
                    chkIsResetPassword.Enabled = True
                    txtPassword.Text = String.Empty
                    txtPassword.Enabled = False
                    txtConfirmPassword.Text = String.Empty
                    txtConfirmPassword.Enabled = False
                    chkIsResetAuthorizePassword.Checked = False
                    txtAuthorizePassword.Text = String.Empty
                    txtAuthorizePassword.Enabled = False
                    commonFunction.SelectListItem(ddlJobTitle, .JobTitleID.Trim)
                    txtPrimaryPhoneNo.Text = .PrimaryPhoneNo.Trim
                    txtSecondaryPhoneNo1.Text = .SecondaryPhoneNo1.Trim
                    txtSecondaryPhoneNo2.Text = .SecondaryPhoneNo2.Trim
                    txtEmail.Text = .Email.Trim
                    txtAddress.Text = .Address.Trim

                    '// if System Administrator make all disabled
                    If RadComboBoxUserID.Text = "sa" Then
                        txtUserName.Enabled = False
                        RadComboBoxUserGroupID.Enabled = False
                        ddlJobTitle.Enabled = False
                        chkIsActive.Enabled = False
                        txtPrimaryPhoneNo.Enabled = False
                        txtSecondaryPhoneNo1.Enabled = False
                        txtSecondaryPhoneNo2.Enabled = False
                        txtEmail.Enabled = False
                        txtAddress.Enabled = False

                        chkIsResetPassword.Enabled = False
                        chkIsResetAuthorizePassword.Enabled = False
                    Else
                        txtUserName.Enabled = True
                        RadComboBoxUserGroupID.Enabled = True
                        ddlJobTitle.Enabled = True
                        chkIsActive.Enabled = True
                        txtPrimaryPhoneNo.Enabled = True
                        txtSecondaryPhoneNo1.Enabled = True
                        txtSecondaryPhoneNo2.Enabled = True
                        txtEmail.Enabled = True
                        txtAddress.Enabled = True

                        chkIsResetPassword.Enabled = True
                        chkIsResetAuthorizePassword.Enabled = True

                        commonFunction.Focus(Me, txtUserName.ClientID)
                    End If
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtUserName.Text = String.Empty
                    RadComboBoxUserGroupID.Text = String.Empty
                    txtUserGroupName.Text = String.Empty
                    chkIsActive.Checked = True
                    chkIsActive.Enabled = True
                    chkIsResetPassword.Checked = True
                    chkIsResetPassword.Enabled = False
                    txtPassword.Enabled = True
                    txtConfirmPassword.Enabled = True
                    chkIsResetAuthorizePassword.Checked = False
                    txtAuthorizePassword.Enabled = False
                    ddlJobTitle.SelectedIndex = 0
                    txtPrimaryPhoneNo.Text = String.Empty
                    txtSecondaryPhoneNo1.Text = String.Empty
                    txtSecondaryPhoneNo2.Text = String.Empty
                    txtEmail.Text = String.Empty
                    txtAddress.Text = String.Empty

                    txtUserName.Enabled = True
                    RadComboBoxUserGroupID.Enabled = True
                    ddlJobTitle.Enabled = True
                    chkIsActive.Enabled = True
                    txtPrimaryPhoneNo.Enabled = True
                    txtSecondaryPhoneNo1.Enabled = True
                    txtSecondaryPhoneNo2.Enabled = True
                    txtEmail.Enabled = True
                    txtAddress.Enabled = True

                    chkIsResetPassword.Enabled = True
                    chkIsResetAuthorizePassword.Enabled = True

                    commonFunction.Focus(Me, txtUserName.ClientID)
                End If
            End With

GoNext:

            br.Dispose()
            br = Nothing            
        End Sub

        Private Sub _OpenUserGroup()
            If Len(RadComboBoxUserGroupID.Text.Trim) = 0 Then
                Exit Sub
            End If

            Dim br As New BussinessRules.UserGroup

            With br
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectOne().Rows.Count > 0 Then
                    RadComboBoxUserGroupID.Text = .UserGroupID.Trim
                    txtUserGroupName.Text = .UserGroupName.Trim
                Else
                    RadComboBoxUserGroupID.Text = String.Empty
                    txtUserGroupName.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            '// validate form
            If Len(RadComboBoxUserID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "User ID cannot empty.")
                Exit Sub
            End If

            '// Special for 'System Administrator'
            If RadComboBoxUserID.Text.Trim = "sa" Then
                commonFunction.MsgBox(Me, "'System Administrator' is a built-in User and cannot be updated.")
                Exit Sub
            End If

            If Len(txtUserName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "User Name cannot empty.")
                commonFunction.Focus(Me, txtUserName.ClientID)
                Exit Sub
            End If

            If chkIsResetPassword.Checked = True And Len(txtPassword.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Password cannot empty.")
                commonFunction.Focus(Me, txtPassword.ClientID)
                Exit Sub
            End If

            If chkIsResetAuthorizePassword.Checked = True And Len(txtAuthorizePassword.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Authorize Password cannot empty.")
                commonFunction.Focus(Me, txtAuthorizePassword.ClientID)
                Exit Sub
            End If

            If Len(RadComboBoxUserGroupID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "User Group ID cannot empty.")
                Exit Sub
            End If

            '// validate the password
            If txtPassword.Text.Trim <> txtConfirmPassword.Text.Trim Then
                commonFunction.MsgBox(Me, "Your Password do not match. Please try again.")
                txtPassword.Text = String.Empty
                txtConfirmPassword.Text = String.Empty
                commonFunction.Focus(Me, txtPassword.ClientID)
                Exit Sub
            End If

            Dim br As New BussinessRules.User
            Dim um As New Security.UserManagement
            Dim fNew As Boolean = True

            With br
                .UserID = RadComboBoxUserID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .UserID = RadComboBoxUserID.Text.Trim
                .UserName = txtUserName.Text.Trim
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                '.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim, "sha1")
                .Password = commonFunction.GetHashString(txtPassword.Text.Trim)
                If chkIsResetAuthorizePassword.Checked = True Then
                    .AuthorizePassword = commonFunction.GetHashString(txtAuthorizePassword.Text.Trim)
                Else
                    .AuthorizePassword = String.Empty
                End If
                .JobTitleID = ddlJobTitle.SelectedItem.Value.Trim
                .PrimaryPhoneNo = txtPrimaryPhoneNo.Text.Trim
                .SecondaryPhoneNo1 = txtSecondaryPhoneNo1.Text.Trim
                .SecondaryPhoneNo2 = txtSecondaryPhoneNo2.Text.Trim
                .Email = txtEmail.Text.Trim
                .Address = Left(txtAddress.Text.Trim, 500).Trim
                .isActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    '// to make sure the password will not be leave blank
                    If Len(txtPassword.Text.Trim) = 0 Then
                        commonFunction.MsgBox(Me, "Password cannot empty.")
                        commonFunction.Focus(Me, txtPassword.ClientID)
                        Exit Sub
                    End If

                    '// validate the password
                    If txtPassword.Text.Trim <> txtConfirmPassword.Text.Trim Then
                        commonFunction.MsgBox(Me, "Your Password do not match. Please try again.")
                        txtPassword.Text = String.Empty
                        txtConfirmPassword.Text = String.Empty
                        commonFunction.Focus(Me, txtPassword.ClientID)
                        Exit Sub
                    End If

                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .UpdateAll(chkIsResetPassword.Checked, chkIsResetAuthorizePassword.Checked) Then
                        UpdateViewGridUser()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing            
        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            commonFunction.LoadDDLCommonSetting("JobTitle", ddlJobTitle)

            RadComboBoxUserID.Text = String.Empty
            txtUserName.Text = String.Empty
            RadComboBoxUserGroupID.Text = String.Empty
            txtUserGroupName.Text = String.Empty
            txtPassword.Text = String.Empty
            txtPassword.Enabled = True
            txtConfirmPassword.Text = String.Empty
            txtConfirmPassword.Enabled = True
            chkIsActive.Checked = True
            chkIsActive.Enabled = True
            ddlJobTitle.SelectedIndex = 0
            chkIsResetPassword.Checked = True
            chkIsResetPassword.Enabled = False
            txtAuthorizePassword.Text = String.Empty
            txtPrimaryPhoneNo.Text = String.Empty
            txtSecondaryPhoneNo1.Text = String.Empty
            txtSecondaryPhoneNo2.Text = String.Empty
            txtEmail.Text = String.Empty
            txtAddress.Text = String.Empty

            txtUserName.Enabled = True
            RadComboBoxUserGroupID.Enabled = True
            ddlJobTitle.Enabled = True
            chkIsActive.Enabled = True
            txtPrimaryPhoneNo.Enabled = True
            txtSecondaryPhoneNo1.Enabled = True
            txtSecondaryPhoneNo2.Enabled = True
            txtEmail.Enabled = True
            txtAddress.Enabled = True

            chkIsResetPassword.Enabled = True
            chkIsResetAuthorizePassword.Enabled = True

            UpdateViewGridUser()
        End Sub

        Private Sub LoadUser(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.User

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "UserID LIKE '" + Filter.Trim + "%' OR UserName LIKE '" + Filter.Trim + "%'"

            RadComboBoxUserID.DataSource = dv
            RadComboBoxUserID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadUserGroup(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.UserGroup

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "UserGroupID LIKE '" + Filter.Trim + "%' OR UserGroupName LIKE '" + Filter.Trim + "%'"

            RadComboBoxUserGroupID.DataSource = dv
            RadComboBoxUserGroupID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridUser()
            Dim dt As DataTable
            Dim br As New BussinessRules.User

            dt = br.SelectAll

            RadGridUser.DataSource = dt.DefaultView
            RadGridUser.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace