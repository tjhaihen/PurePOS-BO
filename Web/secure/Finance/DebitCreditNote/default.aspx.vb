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


Namespace Raven.Web.Secure.Finance

    Public Class DebitCreditNote
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "610"

        'header
        Protected WithEvents RadDebitCreditNoteDate As RadDatePicker
        Protected WithEvents RadComboBoxReferenceNo As RadComboBox
        Protected WithEvents RadReferenceDate As RadDatePicker
        Protected WithEvents ddlDCNoteID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtVoucherNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxDebitCreditNoteNo As RadComboBox

        Protected WithEvents lblDebitCreditNoteNoCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblVoucherNoCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblReferenceNoCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblReferenceDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesNameCaption As System.Web.UI.WebControls.Label

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlProcessed As System.Web.UI.WebControls.Panel

        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox

        Protected WithEvents chkIsTax As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtTaxPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTax As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAmtDifferences As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image


        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents Panel As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxDebitCreditNoteNo.IsCallBack And _
                'Not RadComboBoxReferenceNo.IsCallBack And _
                'Not RadComboBoxEntitiesID.IsCallBack Then

                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreenHd()

            End If
        End Sub

        Private Sub RadComboBoxDebitCreditNoteNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDebitCreditNoteNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDebitCreditNote(e.Text)
        End Sub

        Private Sub RadComboBoxDebitCreditNoteNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDebitCreditNoteNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("DCNoteNo").ToString()
        End Sub

        Private Sub RadComboBoxDebitCreditNoteNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDebitCreditNoteNo.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave
                    _SaveHd()
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
            End Select
        End Sub

        Private Sub RadComboBoxReferenceNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxReferenceNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadReferenceNo(e.Text)
        End Sub

        Private Sub RadComboBoxReferenceNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxReferenceNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ReferenceNo").ToString()
        End Sub

        Private Sub RadComboBoxReferenceNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReferenceNo.SelectedIndexChanged
            Dim br As New BussinessRules.DebitCreditNote
            br.ReferenceNo = RadComboBoxReferenceNo.Text.Trim
            If br.SelectOneForReferenceNo.Rows.Count > 0 Then
                commonFunction.SelectListItem(ddlCurrency, br.Currency.Trim)
                txtAmount.Text = Format(br.Amount, commonFunction.FORMAT_CURRENCY)
            Else
                ddlCurrency.SelectedIndex = 0
                RadComboBoxReferenceNo.Text = String.Empty
                RadComboBoxReferenceNo.SelectedValue = String.Empty
                txtAmount.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            br.Dispose()
            br = Nothing

            GetReferenceInfo(ddlDCNoteID.SelectedValue.Trim)
            chkIsTax_CheckedChanged(Nothing, Nothing)
            txtTotal_TextChanged(Nothing, Nothing)
            InitialVariableTmp()
        End Sub

        Private Sub txtTotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
            txtAmtDifferences.Text = Format(CDbl(txtTotal.Text.Trim) - (CDbl(txtAmount.Text.Trim) + CDbl(txtTax.Text.Trim)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub ddlDCNoteID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDCNoteID.SelectedIndexChanged
            InitialVariableTmp()
            If ddlDCNoteID.SelectedValue.Trim = "01" Then
                '// Credit Note
                lblDebitCreditNoteNoCaption.Text = "Credit Note No."
                lblVoucherNoCaption.Text = "Voucher No."
                lblReferenceNoCaption.Text = "Purchase Return No."
                lblReferenceDateCaption.Text = "Purchase Return Date"
                lblEntitiesIDCaption.Text = "Supplier ID"
                lblEntitiesNameCaption.Text = "Supplier Name"
            Else
                '// Debit Note
                lblDebitCreditNoteNoCaption.Text = "Debit Note No."
                lblVoucherNoCaption.Text = "Invoice No."
                lblReferenceNoCaption.Text = "Sales Return No."
                lblReferenceDateCaption.Text = "Sales Return Date"
                lblEntitiesIDCaption.Text = "Customer ID"
                lblEntitiesNameCaption.Text = "Customer Name"
            End If
            PrepareScreenHd(True)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesID").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesID.SelectedIndexChanged
            commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName)
            RadComboBoxReferenceNo.Text = String.Empty
            InitialVariableTmp()
        End Sub

        Private Sub chkIsTax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsTax.CheckedChanged
            If chkIsTax.Checked Then
                txtTax.Text = Format((CDbl(txtTaxPct.Text.Trim) * CDbl(txtAmount.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtTax.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            txtTotal.Text = Format(CDbl(txtAmount.Text.Trim) + CDbl(txtTax.Text.Trim) + CDbl(txtAmtDifferences.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtTotal_TextChanged(Nothing, Nothing)
        End Sub

#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.DebitCreditNote
            With br
                .DCNoteNo = RadComboBoxDebitCreditNoteNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxDebitCreditNoteNo.Text = .DCNoteNo.Trim
                    End If
                    RadDebitCreditNoteDate.SelectedDate = .DCNoteDate

                    commonFunction.SelectListItem(ddlDCNoteID, .DCNoteID.Trim)

                    RadComboBoxReferenceNo.Text = .ReferenceNo.Trim
                    GetReferenceInfo(ddlDCNoteID.SelectedValue.Trim)

                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtAmount.Text = Format(.Amount, commonFunction.FORMAT_CURRENCY)

                    txtAmtDifferences.Text = Format(.AmtDifferences, commonFunction.FORMAT_CURRENCY)
                    chkIsTax.Checked = .IsTax
                    txtTaxPct.Text = .TaxPct

                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)

                    txtDescriptionHd.Text = .Description.Trim

                    If .IsProcess Then
                        commonFunction.ShowPanel(PnlProcessed, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False

                        'chkIsTax.Enabled = False
                    Else
                        commonFunction.ShowPanel(PnlProcessed, False)
                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True

                        'chkIsTax.Enabled = True
                    End If

                    ddlDCNoteID.Enabled = False

                    RadComboBoxEntitiesID.Enabled = False
                    RadComboBoxReferenceNo.Enabled = False

                    chkIsTax_CheckedChanged(Nothing, Nothing)
                    txtTotal_TextChanged(Nothing, Nothing)

                    txtVoucherNo.Text = .VoucherNo.Trim
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            InitialVariableTmp()
            commonFunction.Focus(Me, RadComboBoxDebitCreditNoteNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean

            If RadComboBoxEntitiesID.SelectedValue.Trim = "none" Then
                Select Case ddlDCNoteID.SelectedValue.Trim
                    Case "01"
                        '// CN
                        commonFunction.MsgBox(Me, "Supplier Name Cannot Empty.")
                    Case "02"
                        '// DN
                        commonFunction.MsgBox(Me, "Customer Name Cannot Empty.")
                End Select
                Return False
                Exit Function
            End If

            If RadComboBoxReferenceNo.Text.Trim = "" Then
                Select Case ddlDCNoteID.SelectedValue.Trim
                    Case "01"
                        '// CN
                        commonFunction.MsgBox(Me, "Purchase Return No. Cannot Empty.")
                    Case "02"
                        '// DN
                        commonFunction.MsgBox(Me, "Sales Return No. Cannot Empty.")
                End Select
                Return False
                Exit Function
            End If

            If RadDebitCreditNoteDate.SelectedDate.Value < RadReferenceDate.SelectedDate.Value Then
                Select Case ddlDCNoteID.SelectedValue.Trim
                    Case "01"
                        '// CN
                        commonFunction.MsgBox(Me, "Credit Note Date must be equal or greater than Purchase Return Date.")
                    Case "02"
                        '// DN
                        commonFunction.MsgBox(Me, "Debit Note Date must be equal or greater than Sales Return Date.")
                End Select
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.DebitCreditNote
            Dim fNew As Boolean = True

            With br
                .DCNoteNo = RadComboBoxDebitCreditNoteNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                    If .IsProcess Then
                        Select Case ddlDCNoteID.SelectedValue.Trim
                            Case "01"
                                '// CN
                                commonFunction.MsgBox(Me, "This Credit Note already processed.")
                            Case "02"
                                '// DN
                                commonFunction.MsgBox(Me, "This Debit Note already processed.")
                        End Select
                        GoTo ExitFunction
                    End If
                Else
                    Dim dcb As New BussinessRules.DebitCreditNote
                    dcb.ReferenceNo = RadComboBoxReferenceNo.Text.Trim
                    If dcb.SelectOneByReferenceNo.Rows.Count > 0 Then
                        Select Case ddlDCNoteID.SelectedValue.Trim
                            Case "01"
                                '// CN
                                commonFunction.MsgBox(Me, "The Purchase Return No. already exists.")
                            Case "02"
                                '// DN
                                commonFunction.MsgBox(Me, "The Sales Return No. already exists.")
                        End Select
                        PrepareScreenHd()
                        dcb.Dispose()
                        dcb = Nothing
                        Return False
                        Exit Function
                    End If
                    dcb.Dispose()
                    dcb = Nothing

                    RadComboBoxDebitCreditNoteNo.Text = BussinessRules.ID.GenerateIDNumber("DebitCreditNote", "DCNoteNo", GetPrefixIDNumber(ddlDCNoteID.SelectedValue.Trim), " WHERE LEFT(DCNoteNo, @PrefixLength) = @prefix ")
                End If

                '// set the value
                .DCNoteID = ddlDCNoteID.SelectedValue.Trim
                .DCNoteNo = RadComboBoxDebitCreditNoteNo.Text.Trim
                .DCNoteDate = RadDebitCreditNoteDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .ReferenceNo = RadComboBoxReferenceNo.Text.Trim
                .Amount = CDec(txtAmount.Text.Trim)
                .AmtDifferences = CDec(txtAmtDifferences.Text.Trim)
                .IsTax = chkIsTax.Checked
                .TaxPct = txtTaxPct.Text.Trim
                .Description = txtDescriptionHd.Text.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsProcess = False

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

ExitFunction:
            br.Dispose()
            br = Nothing

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _DeleteHd()
            If Len(RadComboBoxDebitCreditNoteNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DebitCreditNote
            With br
                .DCNoteNo = RadComboBoxDebitCreditNoteNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .IsProcess Then
                        commonFunction.MsgBox(Me, "Debit / credit note no is processed.")
                        _OpenHd(RavenRecStatus.CurrentRecord)
                    Else
                        .UserDelete = MyBase.LoggedOnUserID.Trim
                        If .Delete() = True Then
                            PrepareScreenHd()
                        End If
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxDebitCreditNoteNo.ClientID)
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

        Private Sub PrepareScreenHd(Optional ByVal IsDDLCNDNTypeChange As Boolean = False)
            DCNoteIDTmp = String.Empty
            EntitiesSeqNoTmp = String.Empty

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True

            txtVoucherNo.Text = String.Empty
            RadComboBoxEntitiesID.Enabled = True
            RadComboBoxReferenceNo.Enabled = True

            If IsDDLCNDNTypeChange = False Then
                commonFunction.LoadDDLCommonSetting("DCNoteID", ddlDCNoteID, False)

                '// Credit Note as Default
                lblDebitCreditNoteNoCaption.Text = "Credit Note No."
                lblVoucherNoCaption.Text = "Voucher No."
                lblReferenceNoCaption.Text = "Purchase Return No."
                lblReferenceDateCaption.Text = "Purchase Return Date"
                lblEntitiesIDCaption.Text = "Supplier ID"
                lblEntitiesNameCaption.Text = "Supplier Name"
            End If

            DCNoteIDTmp = ddlDCNoteID.SelectedValue.Trim
            ddlDCNoteID.Enabled = True

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(Panel, True)

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            txtAmount.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtTotal.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtAmtDifferences.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            commonFunction.GetTaxPct(txtTaxPct)
            chkIsTax.Checked = False
            txtTax.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            'chkIsTax.Enabled = True

            RadComboBoxDebitCreditNoteNo.Text = String.Empty
            RadComboBoxDebitCreditNoteNo.SelectedValue = String.Empty

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            RadComboBoxReferenceNo.Text = String.Empty

            RadDebitCreditNoteDate.SelectedDate = Date.Now
            RadReferenceDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            commonFunction.ShowPanel(PnlProcessed, False)
        End Sub

        Private Sub LoadDebitCreditNote(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.DCNoteID = DCNoteIDTmp.Trim
            dt = br.SelectAllForDCNoteNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDebitCreditNoteNo.DataSource = dt.DefaultView
            RadComboBoxDebitCreditNoteNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadReferenceNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.EntitiesSeqNo = EntitiesSeqNoTmp.Trim

            If DCNoteIDTmp.Trim = "02" Then
                dt = br.SelectAllForReferenceNoDN(Filter.Trim, commonFunction.MaxRecord)
            ElseIf DCNoteIDTmp.Trim = "01" Then
                dt = br.SelectAllForReferenceNoCN(Filter.Trim, commonFunction.MaxRecord)
            End If

            RadComboBoxReferenceNo.DataSource = dt.DefaultView
            RadComboBoxReferenceNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            If DCNoteIDTmp.Trim = "02" Then
                dt = br.SelectAllForEntitiesSeqNoDN(Filter.Trim, commonFunction.MaxRecord)
            ElseIf DCNoteIDTmp.Trim = "01" Then
                dt = br.SelectAllForEntitiesSeqNoCN(Filter.Trim, commonFunction.MaxRecord)
            End If

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Function GetPrefixIDNumber(ByVal DCNoteID As String) As String
            Select Case DCNoteID
                Case "01"
                    Return "CN"
                Case "02"
                    Return "DN"
            End Select
        End Function

        Private Sub GetReferenceInfo(ByVal DCNoteID As String)
            If Len(RadComboBoxReferenceNo.Text.Trim) = 0 Then Exit Sub
            Dim err As Integer = 0

            Select Case DCNoteID
                Case "01"
                    '// CN
                    Dim br As New BussinessRules.PurchaseReturnHd
                    With br
                        .PReturnNO = RadComboBoxReferenceNo.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            RadReferenceDate.SelectedDate = .PReturnDate
                        Else
                            RadReferenceDate.SelectedDate = Date.Now
                            err += 1
                        End If
                    End With

                    br.Dispose()
                    br = Nothing

                    If err > 0 Then
                        commonFunction.MsgBox(Me, "Purchase Return not found.")
                        Exit Sub
                    End If
                Case "02"
                    '// DN
                    Dim br As New BussinessRules.SalesReturnHd
                    With br
                        .SReturnNo = RadComboBoxReferenceNo.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            RadReferenceDate.SelectedDate = .SReturnDate
                        Else
                            RadReferenceDate.SelectedDate = Date.Now
                            err += 1
                        End If
                    End With

                    br.Dispose()
                    br = Nothing

                    If err > 0 Then
                        commonFunction.MsgBox(Me, "Sales Return not found.")
                        Exit Sub
                    End If
            End Select
        End Sub

        Private Sub InitialVariableTmp()
            DCNoteIDTmp = ddlDCNoteID.SelectedValue.Trim
            EntitiesSeqNoTmp = RadComboBoxEntitiesID.SelectedValue.Trim
        End Sub
#End Region


    End Class
End Namespace