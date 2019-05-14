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


Namespace Raven.Web.Secure.Finance.AccountPayable

    Public Class APInvoice
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "625"

        'header
        Protected WithEvents RadVoucherDate As RadDatePicker
        Protected WithEvents RadDueDate As RadDatePicker

        Protected WithEvents RadTaxDate As RadDatePicker
        Protected WithEvents txtTaxInvoiceNo As System.Web.UI.WebControls.TextBox

        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxVoucherNo As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        Protected WithEvents txtInvoiceNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliveryFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtStampDutyFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankAdmFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCNAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDPAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtRoundingAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image


        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridPurchaseUnit As DataGrid
        Protected WithEvents RadGridCreditNote As DataGrid
        Protected WithEvents RadGridDPAmount As DataGrid
        Protected WithEvents RadGridGetPU As DataGrid
        Protected WithEvents RadGridGetCN As DataGrid
        Protected WithEvents RadGridGetDP As DataGrid

        'link
        Protected WithEvents lbtnCancelGet As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveGet As System.Web.UI.WebControls.LinkButton

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridGet As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridGetPU As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridGetCN As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridGetDP As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Me.IsPostBack Then 'And _
                'Not RadComboBoxVoucherNo.IsCallBack And _
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

        Private Sub RadComboBoxVoucherNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxVoucherNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadVoucherNo(e.Text)
        End Sub

        Private Sub RadComboBoxVoucherNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxVoucherNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("VoucherNo").ToString()
        End Sub

        Private Sub RadComboBoxVoucherNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxVoucherNo.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave, CSSToolbarItem.tidVoid
                    _SaveHd()
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrint
                    If RadComboBoxVoucherNo.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 6251
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxVoucherNo.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If

                Case CSSToolbarItem.tidOther1 ' get item pu
                    If Len(RadComboBoxEntitiesID.Text.Trim) = 0 Then
                        commonFunction.MsgBox(Me, "Entities ID Cannot Empty.")
                        Exit Sub
                    End If
                    If ddlCurrency.SelectedValue.Trim = "None" Then
                        commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                        Exit Sub
                    End If

                    If txtInvoiceNo.Text.Trim = "" Then
                        commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                        Exit Sub
                    End If

                    UpdateViewGridGetPU()

                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelGrid, False)
                    commonFunction.ShowPanel(PanelGridGet, True)
                    commonFunction.ShowPanel(PanelGridGetPU, True)
                    commonFunction.ShowPanel(PanelGridGetCN, False)
                    commonFunction.ShowPanel(PanelGridGetDP, False)
                Case CSSToolbarItem.tidOther2 ' get item cn
                    If Len(RadComboBoxEntitiesID.Text.Trim) = 0 Then
                        commonFunction.MsgBox(Me, "Entities ID Cannot Empty.")
                        Exit Sub
                    End If
                    If ddlCurrency.SelectedValue.Trim = "None" Then
                        commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                        Exit Sub
                    End If
                    If txtInvoiceNo.Text.Trim = "" Then
                        commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                        Exit Sub
                    End If
                    UpdateViewGridGetCN()
                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelGrid, False)
                    commonFunction.ShowPanel(PanelGridGet, True)
                    commonFunction.ShowPanel(PanelGridGetPU, False)
                    commonFunction.ShowPanel(PanelGridGetCN, True)
                    commonFunction.ShowPanel(PanelGridGetDP, False)
                Case CSSToolbarItem.tidOther3 ' "GetItemDP"
                    If Len(RadComboBoxEntitiesID.Text.Trim) = 0 Then
                        commonFunction.MsgBox(Me, "Entities ID Cannot Empty.")
                        Exit Sub
                    End If
                    If ddlCurrency.SelectedValue.Trim = "None" Then
                        commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                        Exit Sub
                    End If
                    If txtInvoiceNo.Text.Trim = "" Then
                        commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                        Exit Sub
                    End If
                    UpdateViewGridGetDPAmount()
                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelGrid, False)
                    commonFunction.ShowPanel(PanelGridGet, True)
                    commonFunction.ShowPanel(PanelGridGetPU, False)
                    commonFunction.ShowPanel(PanelGridGetCN, False)
                    commonFunction.ShowPanel(PanelGridGetDP, True)


            End Select
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
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                'txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                'txtCurrencyRate.ReadOnly = False
            End If
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDbl(txtPPNpct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            CalculationGrid()
        End Sub

        Private Sub txtDeliveryFee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeliveryFee.TextChanged
            If Not IsNumeric(txtDeliveryFee.Text.Trim) Then
                commonFunction.MsgBox(Me, "Delivery Fee Must Be Numeric.")
                txtDeliveryFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDeliveryFee.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Delivery Fee Must Be equal Or Greater than 0.")
                txtDeliveryFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtDeliveryFee.Text = Format(CDbl(txtDeliveryFee.Text.Trim), commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtStampDutyFee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStampDutyFee.TextChanged
            If Not IsNumeric(txtStampDutyFee.Text.Trim) Then
                commonFunction.MsgBox(Me, "Stamp Duty Fee Must Be Numeric.")
                txtStampDutyFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtStampDutyFee.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Stamp Duty Fee Must Be equal Or Greater than 0.")
                txtStampDutyFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtStampDutyFee.Text = Format(CDbl(txtStampDutyFee.Text.Trim), commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtBankAdmFee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankAdmFee.TextChanged
            If Not IsNumeric(txtBankAdmFee.Text.Trim) Then
                commonFunction.MsgBox(Me, "Bank Adm Fee Must Be Numeric.")
                txtBankAdmFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtBankAdmFee.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Bank Adm Fee Must Be equal Or Greater than 0.")
                txtBankAdmFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtBankAdmFee.Text = Format(CDbl(txtBankAdmFee.Text.Trim), commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtRoundingAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoundingAmt.TextChanged
            If Not IsNumeric(txtRoundingAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Rounding must be numeric.")
                txtRoundingAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtRoundingAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Rounding must be equal or greater than 0.")
                txtRoundingAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtRoundingAmt.Text = Format(CDbl(txtRoundingAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub lbtnCancelGetItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCancelGet.Click
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridGet, False)
            commonFunction.ShowPanel(PanelGridGetPU, False)
            commonFunction.ShowPanel(PanelGridGetCN, False)
            commonFunction.ShowPanel(PanelGridGetDP, False)
        End Sub

        Private Sub lbtnSaveGetItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveGet.Click
            If PanelGridGetPU.Visible Then
                Dim rowCount As Integer = 0
                Dim tblTmp As DataTable
                createTmpTable(tblTmp)

                'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
                Dim gitm As DataGridItem
                For Each gitm In RadGridGetPU.Items
                    Dim _chkIE As CheckBox = CType(gitm.FindControl("_chkIE"), CheckBox)
                    Dim _lblPUnitNO As Label = CType(gitm.FindControl("_lblPUnitNO"), Label)


                    If _chkIE.Checked = True Then
                        Dim puhd As New BussinessRules.PurchaseUnitHd
                        puhd.PUnitNO = Trim(_lblPUnitNO.Text)
                        If puhd.SelectOne.Rows.Count > 0 Then
                            If puhd.VoucherNo.Trim <> "" Then
                                commonFunction.MsgBox(Me, _lblPUnitNO.Text.Trim + " is already used with voucher no. (" + puhd.VoucherNo.Trim + ").")
                                puhd.Dispose()
                                puhd = Nothing
                                Exit Sub
                            End If
                        Else
                            commonFunction.MsgBox(Me, "Record is not found.")
                            puhd.Dispose()
                            puhd = Nothing
                            Exit Sub
                        End If
                        puhd.Dispose()
                        puhd = Nothing

                        rowCount += 1

                        Dim row As DataRow = tblTmp.NewRow
                        row("NomorID") = Trim(_lblPUnitNO.Text)
                        tblTmp.Rows.Add(row)
                    End If
                Next

                If rowCount = 0 Then
                    commonFunction.MsgBox(Me, "You to choose at least one record to be save")
                    Exit Sub
                End If

                ' // save header first

                If Not _SaveHd() Then
                    Exit Sub
                End If

                ' // save the data
                Dim pudt As New BussinessRules.PurchaseUnitHd

                pudt.VoucherNo = RadComboBoxVoucherNo.Text.Trim
                pudt.UpdateVoucherNo(tblTmp)
                pudt.Dispose()
                pudt = Nothing

                tblTmp.Dispose()
                tblTmp = Nothing
            ElseIf PanelGridGetCN.Visible Then
                Dim rowCount As Integer = 0
                Dim tblTmp As DataTable
                createTmpTable(tblTmp)

                'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
                Dim gitm As DataGridItem
                For Each gitm In RadGridGetCN.Items
                    Dim _chkCN As CheckBox = CType(gitm.FindControl("_chkCN"), CheckBox)
                    Dim _lblCNoteNo As Label = CType(gitm.FindControl("_lblCNoteNo"), Label)

                    If _chkCN.Checked = True Then
                        Dim dcnt As New BussinessRules.DebitCreditNote
                        dcnt.DCNoteNo = Trim(_lblCNoteNo.Text)
                        If dcnt.SelectOne.Rows.Count > 0 Then
                            If dcnt.VoucherNo.Trim <> "" Then
                                commonFunction.MsgBox(Me, _lblCNoteNo.Text.Trim + " is already processed with voucher no. (" + dcnt.VoucherNo.Trim + ").")
                                dcnt.Dispose()
                                dcnt = Nothing
                                Exit Sub
                            End If
                        Else
                            commonFunction.MsgBox(Me, "Record is not found.")
                            dcnt.Dispose()
                            dcnt = Nothing
                            Exit Sub
                        End If
                        dcnt.Dispose()
                        dcnt = Nothing

                        rowCount += 1
                        Dim row As DataRow = tblTmp.NewRow
                        row("NomorID") = Trim(_lblCNoteNo.Text)
                        tblTmp.Rows.Add(row)
                    End If
                Next

                If rowCount = 0 Then
                    commonFunction.MsgBox(Me, "You to choose at least one record to be save")
                    Exit Sub
                End If

                ' // save header first

                If Not _SaveHd() Then
                    Exit Sub
                End If


                ' // save the data
                Dim dcn As New BussinessRules.DebitCreditNote

                dcn.VoucherNo = RadComboBoxVoucherNo.Text.Trim
                dcn.UserUpdate = MyBase.LoggedOnUserID.Trim
                dcn.UpdateVoucherNo(tblTmp)
                dcn.Dispose()
                dcn = Nothing

                tblTmp.Dispose()
                tblTmp = Nothing
            ElseIf PanelGridGetDP.Visible Then
                Dim rowCount As Integer = 0
                Dim tblTmp As DataTable
                createTmpTable(tblTmp)

                'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
                Dim gitm As DataGridItem
                For Each gitm In RadGridGetDP.Items
                    Dim _chkDP As CheckBox = CType(gitm.FindControl("_chkDP"), CheckBox)
                    Dim _lblPOrdNO As Label = CType(gitm.FindControl("_lblPOrdNO"), Label)

                    If _chkDP.Checked = True Then
                        Dim pohd As New BussinessRules.PurchaseOrderHd
                        pohd.POrdNO = Trim(_lblPOrdNO.Text)
                        If pohd.SelectOne.Rows.Count > 0 Then
                            If pohd.VoucherNo.Trim <> "" Then
                                commonFunction.MsgBox(Me, _lblPOrdNO.Text.Trim + " is already used with voucher no. (" + pohd.VoucherNo.Trim + ").")
                                pohd.Dispose()
                                pohd = Nothing
                                Exit Sub
                            End If
                        Else
                            commonFunction.MsgBox(Me, "Record is not found.")
                            pohd.Dispose()
                            pohd = Nothing
                            Exit Sub
                        End If
                        pohd.Dispose()
                        pohd = Nothing

                        rowCount += 1
                        Dim row As DataRow = tblTmp.NewRow
                        row("NomorID") = Trim(_lblPOrdNO.Text)
                        tblTmp.Rows.Add(row)
                    End If
                Next

                If rowCount = 0 Then
                    commonFunction.MsgBox(Me, "You to choose at least one record to be save")
                    Exit Sub
                End If

                ' // save header first

                If Not _SaveHd() Then
                    Exit Sub
                End If


                ' // save the data
                Dim dcn As New BussinessRules.PurchaseOrderHd

                dcn.VoucherNo = RadComboBoxVoucherNo.Text.Trim
                dcn.UserUpdate = MyBase.LoggedOnUserID.Trim
                dcn.UpdateVoucherNo(tblTmp)
                dcn.Dispose()
                dcn = Nothing

                tblTmp.Dispose()
                tblTmp = Nothing
            End If

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridGet, False)
            commonFunction.ShowPanel(PanelGridGetPU, False)
            commonFunction.ShowPanel(PanelGridGetCN, False)
            commonFunction.ShowPanel(PanelGridGetDP, False)

            UpdateViewGridPU()
            UpdateViewGridCreditNote()
            UpdateViewGridDPAmount()
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("NomorID", System.Type.GetType("System.String"))
            End With
        End Sub
#End Region

#Region " DataGrid Command Center "

        Private Sub RadGridPurchaseUnit_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridPurchaseUnit.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub

        Private Sub RadGridCreditNote_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridCreditNote.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDeleteCN As LinkButton = CType(e.Item.FindControl("_lbtnDeleteCN"), LinkButton)

                    If Not _lbtnDeleteCN Is Nothing Then
                        _lbtnDeleteCN.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub

        Private Sub RadGridDPAmount_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridDPAmount.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDeleteDP As LinkButton = CType(e.Item.FindControl("_lbtnDeleteDP"), LinkButton)

                    If Not _lbtnDeleteDP Is Nothing Then
                        _lbtnDeleteDP.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub

        Private Sub RadGridPurchaseUnit_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPurchaseUnit.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblPUnitNO As Label = CType(e.Item.FindControl("_lblPUnitNO"), Label)
                    _DeletedtPU(_lblPUnitNO.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridCreditNote_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridCreditNote.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblCNoteNo As Label = CType(e.Item.FindControl("_lblCNoteNo"), Label)
                    _DeletedtCN(_lblCNoteNo.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridDPAmount_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridDPAmount.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblPOrdNO As Label = CType(e.Item.FindControl("_lblPOrdNO"), Label)
                    _DeletedtDP(_lblPOrdNO.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.APInvoice
            With br
                .VoucherNo = RadComboBoxVoucherNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                        PrepareScreenHd()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxVoucherNo.Text = .VoucherNo.Trim
                    End If
                    RadVoucherDate.SelectedDate = .VoucherDate
                    RadTaxDate.SelectedDate = .TaxDate
                    RadDueDate.SelectedDate = .DueDate
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(.PPNPct, commonFunction.FORMAT_CURRENCY)

                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)

                    txtDescriptionHd.Text = .Description.Trim
                    txtInvoiceNo.Text = .InvoiceNo.Trim
                    txtTaxInvoiceNo.Text = .TaxInvoiceNo.Trim
                    UpdateViewGridPU()
                    UpdateViewGridCreditNote()
                    UpdateViewGridDPAmount()

                    txtDeliveryFee.Text = Format(.DeliveryFee, commonFunction.FORMAT_CURRENCY)
                    txtStampDutyFee.Text = Format(.StampDutyFee, commonFunction.FORMAT_CURRENCY)
                    txtBankAdmFee.Text = Format(.BankAdmFee, commonFunction.FORMAT_CURRENCY)
                    txtRoundingAmt.Text = Format(.RoundingAmt, commonFunction.FORMAT_CURRENCY)
                    CalculationGrid()

                    If .IsApproval Then

                        commonFunction.ShowPanel(PnlApproved, True)
                        chkIsPPN.Enabled = False

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidOther2) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidOther3) = False

                        RadGridPurchaseUnit.Columns(0).Visible = False
                        RadGridCreditNote.Columns(0).Visible = False
                        RadGridDPAmount.Columns(0).Visible = False
                        txtDeliveryFee.ReadOnly = True
                        txtStampDutyFee.ReadOnly = True
                        txtBankAdmFee.ReadOnly = True
                        txtRoundingAmt.ReadOnly = True
                    Else
                        commonFunction.ShowPanel(PnlApproved, False)
                        chkIsPPN.Enabled = True

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidOther2) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidOther3) = True

                        RadGridPurchaseUnit.Columns(0).Visible = True
                        RadGridCreditNote.Columns(0).Visible = True
                        RadGridDPAmount.Columns(0).Visible = True
                        txtDeliveryFee.ReadOnly = False
                        txtStampDutyFee.ReadOnly = False
                        txtBankAdmFee.ReadOnly = False
                        txtRoundingAmt.ReadOnly = False
                    End If

                    RadComboBoxEntitiesID.Enabled = False
                    ddlCurrency.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxVoucherNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand total must be equal or greater than 0.")
                Exit Function
            End If

            If ddlCurrency.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                Exit Function
            End If

            If IsNumeric(txtCurrencyRate.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Currency Rate must be numeric.")
                Return False
                Exit Function
            End If

            If CDec(txtCurrencyRate.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Currency Rate must be greater than 0.")
                Return False
                Exit Function
            End If

            If RadComboBoxEntitiesID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Supplier Name Cannot Empty.")
                Exit Function
            End If

            If txtInvoiceNo.Text.Trim = "" Then
                commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadVoucherDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Voucher Date must be equal or less than today.")
                Return False
                Exit Function
            End If

            If RadDueDate.SelectedDate.Value < RadVoucherDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Due Date must be equal or greater than Voucher Date.")
                Return False
                Exit Function
            End If

            Dim pubr As New BussinessRules.PurchaseUnitHd
            pubr.VoucherNo = RadComboBoxVoucherNo.Text.Trim
            Dim dv As New DataView(pubr.SelectForViewGridPUAPInvoice)
            If dv.Count > 0 Then
                dv.Sort = "PUnitDate Desc"
                If RadVoucherDate.SelectedDate.Value < CDate(dv.Item(0)("PUnitDate")) Then
                    commonFunction.MsgBox(Me, "Date must be equal or greater than PU date (" + Format(CDate(dv.Item(0)("PUnitDate")), commonFunction.FORMAT_DATE) + ").")
                    dv.Dispose()
                    dv = Nothing
                    pubr.Dispose()

                    pubr = Nothing
                    Exit Function
                End If
                dv.Sort = "CurrencyRate Desc"
                dv.RowFilter = "CurrencyRate <> " + CStr(CDbl(dv.Item(0)("CurrencyRate")))
                If dv.Count > 0 Then
                    commonFunction.MsgBox(Me, "Added purchase unit must be at the same currency rate.")
                    dv.Dispose()
                    dv = Nothing
                    pubr.Dispose()
                    pubr = Nothing
                    Exit Function
                End If
            End If
            dv.Dispose()
            dv = Nothing
            pubr.Dispose()
            pubr = Nothing

            If RadVoucherDate.SelectedDate.Value > RadDueDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Date must be equal or less than due date.")
                Exit Function
            End If

            If RadVoucherDate.SelectedDate.Value > RadTaxDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Date must be equal or less than tax date.")
                Exit Function
            End If

            Dim br As New BussinessRules.APInvoice
            Dim fNew As Boolean = True

            With br
                .VoucherNo = RadComboBoxVoucherNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .IsVerified Then
                        commonFunction.MsgBox(Me, "Voucher No. " + RadComboBoxVoucherNo.Text.Trim + " Is Verified.")
                        GoTo ExitSub
                    End If
                    fNew = False
                Else
                    RadComboBoxVoucherNo.Text = BussinessRules.ID.GenerateIDNumber("APInvoice", "VoucherNo", "IE")
                End If

                '// set the value
                .VoucherNo = RadComboBoxVoucherNo.Text.Trim
                .VoucherDate = RadVoucherDate.SelectedDate.Value
                .TaxDate = RadTaxDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .DueDate = RadDueDate.SelectedDate.Value
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(txtPPNpct.Text.Trim)
                .InvoiceNo = txtInvoiceNo.Text.Trim
                .TaxInvoiceNo = txtTaxInvoiceNo.Text.Trim
                .Description = txtDescriptionHd.Text.Trim
                .BankAdmFee = CDec(txtBankAdmFee.Text.Trim)
                .DeliveryFee = CDec(txtDeliveryFee.Text.Trim)
                .StampDutyFee = CDec(txtStampDutyFee.Text.Trim)
                .CNAmount = CDec(txtCNAmount.Text.Trim)
                .DPAmt = CDec(txtDPAmt.Text.Trim)
                .RoundingAmt = CDec(txtRoundingAmt.Text.Trim)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsApproval = FApproval

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
ExitSub:
            br.Dispose()
            br = Nothing

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _DeleteHd()
            If Len(RadComboBoxVoucherNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.APInvoice
            With br
                .VoucherNo = RadComboBoxVoucherNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .DeleteAllByVoucherNo() = True Then
                        PrepareScreenHd()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxVoucherNo.ClientID)
        End Sub

        Private Sub _DeletedtPU(ByVal PUnitNO As String)
            If Len(PUnitNO.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseUnitHd
            With br
                .PUnitNO = PUnitNO.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .VoucherNo.Trim = "" Then
                        commonFunction.MsgBox(Me, "Record not found.")
                    Else
                        .VoucherNo = ""
                        .DeleteVouvherNo()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridPU()
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _DeletedtCN(ByVal DCNoteNo As String)
            If Len(DCNoteNo.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DebitCreditNote
            With br
                .DCNoteNo = DCNoteNo.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .VoucherNo.Trim = "" Then
                        commonFunction.MsgBox(Me, "Record not found.")
                    Else
                        .VoucherNo = ""
                        .IsProcess = False
                        .DeleteVoucherNo()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridCreditNote()
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _DeletedtDP(ByVal POrdNO As String)
            If Len(POrdNO.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseOrderHd
            With br
                .POrdNO = POrdNO.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .VoucherNo.Trim = "" Then
                        commonFunction.MsgBox(Me, "Record not found.")
                    Else
                        .VoucherNo = ""
                        .DeleteVoucherNo()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridDPAmount()
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
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidOther1) = True
                .lbtnOther1_Text = "Get Item PU"
                .VisibleButton(CSSToolbarItem.tidOther2) = True
                .lbtnOther2_Text = "Get Item CN"
                .VisibleButton(CSSToolbarItem.tidOther3) = True
                .lbtnOther3_Text = "Get Item DP"
            End With
        End Sub


        Private Sub PrepareScreenHd()
            CurrencyTmp = String.Empty
            EntitiesSeqNoTmp = String.Empty

            RadComboBoxEntitiesID.Enabled = True
            ddlCurrency.Enabled = True

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridGet, False)
            commonFunction.ShowPanel(PanelGridGetPU, False)
            commonFunction.ShowPanel(PanelGridGetCN, False)
            commonFunction.ShowPanel(PanelGridGetDP, False)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
            Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True
            Toolbar.EnableButton(CSSToolbarItem.tidOther2) = True
            Toolbar.EnableButton(CSSToolbarItem.tidOther3) = True

            chkIsPPN.Enabled = True
            RadGridPurchaseUnit.Columns(0).Visible = True
            RadGridCreditNote.Columns(0).Visible = True
            RadGridDPAmount.Columns(0).Visible = True
            txtDeliveryFee.ReadOnly = False
            txtStampDutyFee.ReadOnly = False
            txtBankAdmFee.ReadOnly = False
            txtRoundingAmt.ReadOnly = False

            RadComboBoxVoucherNo.Text = String.Empty
            RadComboBoxVoucherNo.SelectedValue = String.Empty

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            RadVoucherDate.SelectedDate = Date.Now
            RadTaxDate.SelectedDate = Date.Now
            RadDueDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty
            txtInvoiceNo.Text = String.Empty
            txtTaxInvoiceNo.Text = String.Empty

            ddlCurrency.SelectedIndex = 0

            commonFunction.ShowPanel(PnlApproved, False)

            commonFunction.GetTaxPct(txtPPNpct)

            txtDeliveryFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtStampDutyFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtBankAdmFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDeliveryFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtRoundingAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            UpdateViewGridPU()
            UpdateViewGridCreditNote()
            UpdateViewGridDPAmount()

            CalculationGrid()
        End Sub

        Private Sub LoadVoucherNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.APInvoice

            dt = br.SelectAllForVoucherNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxVoucherNo.DataSource = dt.DefaultView
            RadComboBoxVoucherNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitHd

            dt = br.SelectAllForEntitiesSeqNoAPInvoice(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPU()
            Dim subtotal As Double = 0
            Dim CurrencyRate As Double = 1
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitHd
            br.VoucherNo = RadComboBoxVoucherNo.Text.Trim
            dt = br.SelectForViewGridPUAPInvoice()

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("TotalDetail")) - CDbl(dtRows(i - 1)("DiscFinalAmt"))) + CDbl(dtRows(i - 1)("PPNAmount"))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    If CDbl(dtRows(i - 1)("CurrencyRate")) > CurrencyRate Then
                        CurrencyRate = CDbl(dtRows(i - 1)("CurrencyRate"))
                    End If
                    i += 1
                Loop
            Else
                'RadToolbar.Items(16).Enabled = False 'GetItemCN
                'RadToolbar.Items(18).Enabled = False 'GetItemDp
            End If

            txtCurrencyRate.Text = Format(CurrencyRate, commonFunction.FORMAT_CURRENCY)
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtDeliveryFee.ReadOnly = False
                txtStampDutyFee.ReadOnly = False
                txtBankAdmFee.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDeliveryFee.ReadOnly = True
                txtStampDutyFee.ReadOnly = True
                txtBankAdmFee.ReadOnly = True
            End If

            CalculationGrid()

            RadGridPurchaseUnit.DataSource = dt.DefaultView
            RadGridPurchaseUnit.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) + CDbl(txtDeliveryFee.Text) + CDbl(txtStampDutyFee.Text) + CDbl(txtBankAdmFee.Text) - CDbl(txtCNAmount.Text) - CDbl(txtDPAmt.Text) + CDbl(txtRoundingAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridCreditNote()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.VoucherNo = RadComboBoxVoucherNo.Text.Trim
            dt = br.SelectAllForViewGridCNDN()

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDbl(dtRows(i - 1)("Amount")) + CDbl(dtRows(i - 1)("TaxAmount")) + CDbl(dtRows(i - 1)("AmtDifferences"))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            End If

            txtCNAmount.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            CalculationGrid()

            RadGridCreditNote.DataSource = dt.DefaultView
            RadGridCreditNote.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridDPAmount()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderHd

            br.VoucherNo = RadComboBoxVoucherNo.Text.Trim
            dt = br.SelectAllForViewGridDPAmount()

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    subtotal = subtotal + CDbl(dtRows(i - 1)("DPAmt"))
                    i += 1
                Loop
            End If

            txtDPAmt.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            CalculationGrid()

            RadGridDPAmount.DataSource = dt.DefaultView
            RadGridDPAmount.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridGetPU()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitHd
            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim
            dt = br.SelectForViewGridGetPUAPInvoice()

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("TotalDetail")) - CDbl(dtRows(i - 1)("DiscFinalAmt"))) + CDbl(dtRows(i - 1)("PPNAmount"))
                    i += 1
                Loop


            Else

            End If
            RadGridGetPU.DataSource = dt.DefaultView
            RadGridGetPU.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridGetCN()
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            dt = br.SelectAllForViewGridGetCNAPInvoice(ddlCurrency.SelectedValue.Trim)

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDbl(dtRows(i - 1)("Amount")) + CDbl(dtRows(i - 1)("TaxAmount")) + CDbl(dtRows(i - 1)("AmtDifferences"))
                    i += 1
                Loop
            End If

            RadGridGetCN.DataSource = dt.DefaultView
            RadGridGetCN.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridGetDPAmount()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderHd

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim
            dt = br.SelectAllForViewGridGetDPAmount()

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    subtotal = subtotal + CDbl(dtRows(i - 1)("DPAmt"))
                    i += 1
                Loop
            End If

            RadGridGetDP.DataSource = dt.DefaultView
            RadGridGetDP.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub
#End Region

    End Class
End Namespace