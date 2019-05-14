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

    Public Class UserManagement
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "111"
        Protected WithEvents lblRecordListCaption As Label
        Protected WithEvents lblUserGroupIDCaption As Label
        Protected WithEvents lblUserGroupNameCaption As Label
        Protected WithEvents txtUserGroupName As TextBox
        Protected WithEvents chkIsActive As CheckBox
        Protected WithEvents RadComboBoxUserGroupID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As Label        
        Protected WithEvents RadGridUserGroup As DataGrid

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

        Private Sub RadComboBoxUserGroupID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxUserGroupID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UserGroupID").ToString()
        End Sub

        Private Sub RadComboBoxUserGroupID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxUserGroupID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
                Case CSSToolbarItem.tidPrevious
                    _Open(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _Open(RavenRecStatus.NextRecord)
            End Select
        End Sub

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridUserGroup_ItemCommand1(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridUserGroup.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblUserGroupID As Label = CType(e.Item.FindControl("_lblUserGroupID"), Label)

                    RadComboBoxUserGroupID.Text = _lblUserGroupID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxUserGroupID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.UserGroup

            With br
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxUserGroupID.Text = .UserGroupID.Trim
                    End If
                    txtUserGroupName.Text = .UserGroupName.Trim
                    chkIsActive.Checked = .IsActive

                    '// if Admin make all disabled
                    If RadComboBoxUserGroupID.Text = "Administrator" Then
                        txtUserGroupName.Enabled = False
                        chkIsActive.Enabled = False                        
                    Else
                        txtUserGroupName.Enabled = True
                        chkIsActive.Enabled = True
                        commonFunction.Focus(Me, txtUserGroupName.ClientID)
                    End If
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtUserGroupName.Text = String.Empty
                    chkIsActive.Checked = True
                    txtUserGroupName.Enabled = True
                    chkIsActive.Enabled = True
                    commonFunction.Focus(Me, txtUserGroupName.ClientID)
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing            
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxUserGroupID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "User Group ID cannot empty.")
                Exit Sub
            End If

            '// Special for 'Admin'
            If RadComboBoxUserGroupID.Text.Trim = "Administrator" Then
                commonFunction.MsgBox(Me, "'Admin' is a built-in User Group and cannot be updated.")
                Exit Sub
            End If

            If Len(txtUserGroupName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "User Group Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.UserGroup
            Dim fNew As Boolean = True

            With br
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                .UserGroupName = txtUserGroupName.Text.Trim
                .IsActive = chkIsActive.Checked

                If fNew Then
                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridUserGroup()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxUserGroupID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            '// Special for 'Admin'
            If RadComboBoxUserGroupID.Text.Trim = "Administrator" Then
                commonFunction.MsgBox(Me, "'Admin' is a built-in User Group and cannot be deleted.")
                Exit Sub
            End If

            '// Validasi apabila sudah diisi User Group Authorization
            Dim brUserGroupMenu As New BussinessRules.UserGroupMenu
            With brUserGroupMenu
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectByUserGroupID.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "This User Group already has Authorization. Record cannot be deleted.")
                    brUserGroupMenu.Dispose()
                    brUserGroupMenu = Nothing
                    Exit Sub
                End If
            End With
            brUserGroupMenu.Dispose()
            brUserGroupMenu = Nothing

            Dim brUserGroupReport As New BussinessRules.UserGroupReport
            With brUserGroupReport
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectByUserGroupID.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "This User Group already has Authorization. Record cannot be deleted.")
                    brUserGroupReport.Dispose()
                    brUserGroupReport = Nothing
                    Exit Sub
                End If
            End With
            brUserGroupReport.Dispose()
            brUserGroupReport = Nothing

            Dim brUserGroupWarehouse As New BussinessRules.UserGroupWarehouse
            With brUserGroupWarehouse
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectByUserGroupID.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "This User Group already has Authorization. Record cannot be deleted.")
                    brUserGroupWarehouse.Dispose()
                    brUserGroupWarehouse = Nothing
                    Exit Sub
                End If
            End With
            brUserGroupWarehouse.Dispose()
            brUserGroupWarehouse = Nothing

            Dim brUserGroupInventoryTxn As New BussinessRules.UserGroupInventoryTxn
            With brUserGroupInventoryTxn
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectByUserGroupID.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "This User Group already has Authorization. Record cannot be deleted.")
                    brUserGroupInventoryTxn.Dispose()
                    brUserGroupInventoryTxn = Nothing
                    Exit Sub
                End If
            End With
            brUserGroupInventoryTxn.Dispose()
            brUserGroupInventoryTxn = Nothing

            Dim br As New BussinessRules.UserGroup

            With br
                .UserGroupID = RadComboBoxUserGroupID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxUserGroupID.ClientID)
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
            RadComboBoxUserGroupID.Text = String.Empty
            txtUserGroupName.Text = String.Empty
            chkIsActive.Checked = True
            txtUserGroupName.Enabled = True
            chkIsActive.Enabled = True
            UpdateViewGridUserGroup()
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

        Private Sub UpdateViewGridUserGroup()
            Dim dt As DataTable
            Dim br As New BussinessRules.UserGroup

            dt = br.SelectAll

            RadGridUserGroup.DataSource = dt.DefaultView
            RadGridUserGroup.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub
    End Class
End Namespace