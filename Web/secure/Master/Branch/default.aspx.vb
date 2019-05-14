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

Namespace Raven.Web.Secure.Master

    Public Class Branch
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "298"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblBranchIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblBranchNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddressCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblZipCodeCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPhoneCodeAreaCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPhoneNoCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtBranchName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtZipCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhoneCodeArea As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPhoneNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxBranchID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridBranch As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxBranchID.IsCallBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()
                PrepareScreen(False)

                DataBind()
            End If
        End Sub

        Private Sub RadComboBoxBranchID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxBranchID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadBranch(e.Text)
        End Sub

        Private Sub RadComboBoxBranchID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxBranchID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("BranchID").ToString()
        End Sub

        Private Sub RadComboBoxBranchID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxBranchID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen(False)
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
        Private Sub RadGridBranch_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridBranch.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblBranchID As Label = CType(e.Item.FindControl("_lblBranchID"), Label)

                    RadComboBoxBranchID.Text = _lblBranchID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxBranchID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.Branch

            With br
                .BranchID = RadComboBoxBranchID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxBranchID.Text = .BranchID.Trim
                    End If
                    txtBranchName.Text = .BranchName.Trim
                    txtAddress.Text = .Address.Trim
                    txtZipCode.Text = .ZipCode.Trim
                    txtPhoneCodeArea.Text = .PhoneCodeArea.Trim
                    txtPhoneNo.Text = .PhoneNo.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    PrepareScreen(True)
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtBranchName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxBranchID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Branch ID cannot empty.")
                Exit Sub
            End If

            If Len(txtBranchName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Branch Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Branch
            Dim fNew As Boolean = True

            With br
                .BranchID = RadComboBoxBranchID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .BranchID = RadComboBoxBranchID.Text.Trim
                .BranchName = txtBranchName.Text.Trim
                .Address = txtAddress.Text.Trim
                .ZipCode = txtZipCode.Text.Trim
                .PhoneCodeArea = txtPhoneCodeArea.Text.Trim
                .PhoneNo = txtPhoneNo.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen(False)
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridBranch()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxBranchID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Branch

            With br
                .BranchID = RadComboBoxBranchID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen(False)
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxBranchID.ClientID)
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

        Private Sub PrepareScreen(ByVal fnew As Boolean)
            If fnew = False Then
                RadComboBoxBranchID.Text = String.Empty
            End If
            txtBranchName.Text = String.Empty
            txtAddress.Text = String.Empty
            txtZipCode.Text = String.Empty
            txtPhoneCodeArea.Text = String.Empty
            txtPhoneNo.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            UpdateViewGridBranch()
        End Sub

        Private Sub LoadBranch(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Branch

            dt = br.SelectAllForBranchId(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxBranchID.DataSource = dt.DefaultView
            RadComboBoxBranchID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridBranch()
            Dim dt As DataTable
            Dim br As New BussinessRules.Branch

            dt = br.SelectAll

            RadGridBranch.DataSource = dt.DefaultView
            RadGridBranch.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace