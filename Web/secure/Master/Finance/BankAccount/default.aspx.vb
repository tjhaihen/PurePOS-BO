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

Namespace Raven.Web.Secure.Master.Finance

    Public Class BankAccount
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "252"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblBankIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblBankNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtBankName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBranch As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAccountNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAccountTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxBankID As RadComboBox
        Protected WithEvents ddlBankTxnTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrencyID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridBank As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxBankID.IsCallBack Then
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

        Private Sub RadComboBoxBankID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxBankID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadBank(e.Text)
        End Sub

        Private Sub RadComboBoxBankID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxBankID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("BankID").ToString()
        End Sub

        Private Sub RadComboBoxBankID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxBankID.SelectedIndexChanged
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
        Private Sub RadGridBank_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridBank.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblBankID As Label = CType(e.Item.FindControl("_lblBankID"), Label)

                    RadComboBoxBankID.Text = _lblBankID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxBankID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.Bank

            With br
                .BankID = RadComboBoxBankID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxBankID.Text = .BankID.Trim
                    End If
                    txtBankName.Text = .BankName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    commonFunction.SelectListItem(ddlBankTxnTypeID, .BankTxnType.Trim)
                    commonFunction.SelectListItem(ddlCurrencyID, .Currency.Trim)
                    txtBranch.Text = .Branch.Trim
                    txtAccountNo.Text = .AccountNo.Trim
                    txtAccountTitle.Text = .AccountTitle.Trim
                    txtAddress.Text = .Address.Trim

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

            commonFunction.Focus(Me, txtBankName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxBankID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Bank ID cannot empty.")
                Exit Sub
            End If

            If Len(txtBankName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Bank Name cannot empty.")
                Exit Sub
            End If

            If ddlBankTxnTypeID.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Transaction Type cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Bank
            Dim fNew As Boolean = True

            With br
                .BankID = RadComboBoxBankID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .BankID = RadComboBoxBankID.Text.Trim
                .BankName = txtBankName.Text.Trim
                .BankTxnType = ddlBankTxnTypeID.SelectedItem.Value.Trim
                .Branch = txtBranch.Text.Trim
                .AccountNo = txtAccountNo.Text.Trim
                .AccountTitle = txtAccountTitle.Text.Trim
                .Address = txtAddress.Text.Trim
                .Currency = ddlCurrencyID.SelectedItem.Value.Trim
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
                        _Open(RavenRecStatus.CurrentRecord)
                        UpdateViewGridBank()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxBankID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Bank

            With br
                .BankID = RadComboBoxBankID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxBankID.ClientID)
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
                RadComboBoxBankID.Text = String.Empty
            End If
            txtBankName.Text = String.Empty
            txtBranch.Text = String.Empty
            txtAccountNo.Text = String.Empty
            txtAccountTitle.Text = String.Empty
            txtAddress.Text = String.Empty
            ddlCurrencyID.SelectedIndex = 0
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            commonFunction.LoadDDLCommonSetting("BankTxnType", ddlBankTxnTypeID)
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrencyID)
            UpdateViewGridBank()
        End Sub

        Private Sub LoadBank(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Bank

            dt = br.SelectAllForBankID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxBankID.DataSource = dt.DefaultView
            RadComboBoxBankID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridBank()
            Dim dt As DataTable
            Dim br As New BussinessRules.Bank

            dt = br.SelectAll

            RadGridBank.DataSource = dt.DefaultView
            RadGridBank.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace