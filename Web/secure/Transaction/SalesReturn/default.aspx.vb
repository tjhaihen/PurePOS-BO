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


Namespace Raven.Web.Secure.Transaction

    Public Class SalesReturn
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "521"

        'header
        Protected WithEvents RadSReturnDate As RadDatePicker
        Protected WithEvents RadSUnitDate As RadDatePicker

        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlSReturnReason As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeePct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeeAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxSTxnNo As RadComboBox
        Protected WithEvents RadComboBoxSalesReturnID As RadComboBox
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        'detail

        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPrice As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtDisc1Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc1Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc2Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc2Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc3Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc3Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeePctdt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeeAmtdt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptiondt As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton


        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesReturnNoCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblEntitiesID As System.Web.UI.WebControls.Label
        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblCurrencyCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCurrencyRateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblTermOfPaymentCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionHdCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemID As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemFactorCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblQtyCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPriceCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc1PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc2PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc3PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptiondtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc1AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc2AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc3AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPPNCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiscFinalPctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiscFinalAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDPAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblGrandTotalCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridSalesReturn As DataGrid
        Protected WithEvents RadGridSalesUnit As DataGrid

        'link
        Protected WithEvents lbtnSaveGetItemSU As System.Web.UI.WebControls.LinkButton

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelDetail As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridDO As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxSalesReturnID.IsCallBack And Not RadComboBoxEntitiesID.IsCallBack And Not RadComboBoxSTxnNo.IsCallBack Then
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

        Private Sub RadComboBoxSTxnNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSTxnNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSTxnNo(e.Text)
        End Sub

        Private Sub RadComboBoxSTxnNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSTxnNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("STxnNo").ToString()
        End Sub

        Private Sub RadComboBoxSTxnNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSTxnNo.SelectedIndexChanged
            Dim ob As New BussinessRules.SalesUnitHd
            ob.STxnNo = RadComboBoxSTxnNo.Text.Trim
            If ob.SelectOne.Rows.Count > 0 Then
                RadComboBoxEntitiesID.SelectedValue = ob.EntitiesSeqNo.Trim
                commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                commonFunction.SelectListItem(ddlWhID, ob.WhID.Trim)
                commonFunction.SelectListItem(ddlUnitID, ob.UnitID.Trim)
                commonFunction.SelectListItem(ddlCurrency, ob.Currency.Trim)
                txtCurrencyRate.Text = Format(ob.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                RadSUnitDate.SelectedDate = ob.STxnDate
                UpdateViewGridSalesUnit()

                RadComboBoxSTxnNo.Enabled = False

                RadComboBoxEntitiesID.Enabled = False
                'ddlWhID.Enabled = False
                'ddlUnitID.Enabled = False
                ddlCurrency.Enabled = False
                txtCurrencyRate.ReadOnly = True
            Else
                PrepareScreenHd()
            End If
            ob.Dispose()
            ob = Nothing
        End Sub

        Private Sub RadComboBoxSalesReturnID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSalesReturnID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSalesReturn(e.Text)
        End Sub

        Private Sub RadComboBoxSalesReturnID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSalesReturnID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("SReturnNo").ToString()
        End Sub

        Private Sub RadComboBoxSalesReturnID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSalesReturnID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
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
            UpdateViewGridSalesUnit()
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItem(e.Text)
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNo.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName)
            Dim itemunit As New BussinessRules.ItemUnit
            commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing
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
                    If RadComboBoxSalesReturnID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 5211
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxSalesReturnID.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
            End Select
        End Sub

        Private Sub lbtnNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewDetail.Click
            PrepareScreendt()
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _SaveDt()
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
            'UpdateViewGridSalesUnit()
        End Sub

        Private Sub ddlItemUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemUnitID.SelectedIndexChanged
            Dim ift As New BussinessRules.ItemFactorTemplate
            ift.ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
            ift.ItemUnitID = ddlItemUnitID.SelectedValue
            If ift.SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                txtItemFactor.Text = Format(ift.ItemFactor, commonFunction.FORMAT_CURRENCY)
            Else
                txtItemFactor.Text = ""
            End If
            ift.Dispose()
            ift = Nothing
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDec(txtPPNpct.Text.Trim) * (CDec(txtTotal.Text.Trim) - CDec(txtReturnFeeAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            CalculationGrid()
        End Sub

        Private Sub txtReturnFeePct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnFeePct.TextChanged
            If Not IsNumeric(txtReturnFeePct.Text) Then
                commonFunction.MsgBox(Me, "Return Fee Final ( % ) must be numeric")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtReturnFeePct.Text.Trim) < 0 OrElse CDec(txtReturnFeePct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Return Fee Final ( % ) Must Be 0% - 100%.")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtReturnFeePct.Text = Format(CDec(txtReturnFeePct.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtReturnFeeAmt.Text = Format((CDec(txtReturnFeePct.Text.Trim) * CDec(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub txtReturnFeeAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnFeeAmt.TextChanged
            If Not IsNumeric(txtReturnFeeAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount Final Must Be Numeric.")
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtReturnFeeAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount Final Must Be equal Or Greater than 0.")
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtReturnFeeAmt.Text = Format(CDec(txtReturnFeeAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub txtDisc1Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Pct.TextChanged
            If IsNumeric(txtDisc1Pct.Text.Trim) Then
                txtDisc1Amt.Text = Format((CDec(txtDisc1Pct.Text.Trim) * CDec(txtPrice.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc1Amt.Text.Trim) > CDec(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc1Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Amt.TextChanged
            If IsNumeric(txtDisc1Amt.Text.Trim) Then
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(CDec(txtDisc1Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc1Amt.Text.Trim) > CDec(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Pct.TextChanged
            If IsNumeric(txtDisc2Pct.Text.Trim) Then
                txtDisc2Amt.Text = Format((CDec(txtDisc2Pct.Text.Trim) * (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc2Amt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Amt.TextChanged
            If IsNumeric(txtDisc2Amt.Text.Trim) Then
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(CDec(txtDisc2Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc2Amt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Pct.TextChanged
            If IsNumeric(txtDisc3Pct.Text.Trim) Then
                txtDisc3Amt.Text = Format((CDec(txtDisc3Pct.Text.Trim) * (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc3Amt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Amt.TextChanged
            If IsNumeric(txtDisc3Amt.Text.Trim) Then
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(CDec(txtDisc3Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDec(txtDisc3Amt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtReturnFeePctdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnFeePctdt.TextChanged
            If IsNumeric(txtReturnFeePctdt.Text.Trim) Then
                txtReturnFeeAmtdt.Text = Format((CDec(txtReturnFeePctdt.Text.Trim) * (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim) - CDec(txtDisc3Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDec(txtReturnFeeAmtdt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim) - CDec(txtDisc3Amt.Text.Trim)) Then
                    txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtReturnFeeAmtdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnFeeAmtdt.TextChanged
            If IsNumeric(txtReturnFeeAmtdt.Text.Trim) Then
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(CDec(txtReturnFeeAmtdt.Text), commonFunction.FORMAT_CURRENCY)
                If CDec(txtReturnFeeAmtdt.Text.Trim) > (CDec(txtPrice.Text.Trim) - CDec(txtDisc1Amt.Text.Trim) - CDec(txtDisc2Amt.Text.Trim)) Then
                    txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub lbtnSaveGetItemSU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveGetItemSU.Click
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridSalesUnit.Items
                Dim _chkOrder As CheckBox = CType(gitm.FindControl("_chkOrder"), CheckBox)
                Dim _lblID As Label = CType(gitm.FindControl("_lblID"), Label)
                Dim _lblItemSeqNo As Label = CType(gitm.FindControl("_lblItemSeqNo"), Label)
                Dim _lblItemName As Label = CType(gitm.FindControl("_lblItemName"), Label)
                Dim _lblQtyRemaining As Label = CType(gitm.FindControl("_lblQtyRemaining"), Label)
                Dim _txtQtyReturn As TextBox = CType(gitm.FindControl("_txtQtyReturn"), TextBox)
                Dim _lblItemUnitID As Label = CType(gitm.FindControl("_lblItemUnitID"), Label)
                Dim _TxtPrice As TextBox = CType(gitm.FindControl("_TxtPrice"), TextBox)
                Dim _lblItemFactor As Label = CType(gitm.FindControl("_lblItemFactor"), Label)
                Dim _lblDisc1Pct As Label = CType(gitm.FindControl("_lblDisc1Pct"), Label)
                Dim _lblDisc1Amt As Label = CType(gitm.FindControl("_lblDisc1Amt"), Label)
                Dim _lblDisc2Pct As Label = CType(gitm.FindControl("_lblDisc2Pct"), Label)
                Dim _lblDisc2Amt As Label = CType(gitm.FindControl("_lblDisc2Amt"), Label)
                Dim _lblDisc3Pct As Label = CType(gitm.FindControl("_lblDisc3Pct"), Label)
                Dim _lblDisc3Amt As Label = CType(gitm.FindControl("_lblDisc3Amt"), Label)
                Dim _TxtReturnFeePct As TextBox = CType(gitm.FindControl("_TxtReturnFeePct"), TextBox)

                If _chkOrder.Checked = True Then
                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("IDSU") = Trim(_lblID.Text)
                    row("ItemSeqNo") = CType(Trim(_lblItemSeqNo.Text.Trim), String)
                    row("ItemUnitID") = CType(Trim(_lblItemUnitID.Text.Trim), String)

                    If Not IsNumeric(_lblItemFactor.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Item Factor must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDec(_lblItemFactor.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                        GoTo ExitSub
                    End If
                    row("ItemFactor") = CType(Trim(_lblItemFactor.Text.Trim), Decimal)

                    If Not IsNumeric(_txtQtyReturn.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Qty Return must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDec(_txtQtyReturn.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Qty Return must be greater than 0.")
                        GoTo ExitSub
                    End If

                    Dim podt As New BussinessRules.SalesUnitDt
                    Dim dt As New DataTable
                    podt.ID = _lblID.Text.Trim
                    podt.STxnNo = RadComboBoxSTxnNo.Text.Trim
                    dt = podt.ValidateGetItemSU()
                    If (CDec(_txtQtyReturn.Text.Trim)) > (CDec(dt.Rows(0)("Qty")) - CDec(dt.Rows(0)("QtyReturn")) - CDec(dt.Rows(0)("QtySURT"))) Then
                        commonFunction.MsgBox(Me, _lblItemName.Text.Trim + " Qty Return (" + Format((CDec(_txtQtyReturn.Text.Trim)), commonFunction.FORMAT_CURRENCY) + ") must be equal or less than Qty Remaining (" + Format((CDec(dt.Rows(0)("Qty")) - CDec(dt.Rows(0)("QtyReturn")) - CDec(dt.Rows(0)("QtySURT"))), commonFunction.FORMAT_CURRENCY) + ").")
                        dt.Dispose()
                        dt = Nothing
                        podt.Dispose()
                        podt = Nothing
                        GoTo ExitSub
                    End If
                    dt.Dispose()
                    dt = Nothing
                    podt.Dispose()
                    podt = Nothing
                    row("QtyReturn") = CType(_txtQtyReturn.Text.Trim, Decimal)

                    If Not IsNumeric(_TxtPrice.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Price must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDec(_TxtPrice.Text.Trim) < 0 Then
                        commonFunction.MsgBox(Me, "Price must be equal or greater than 0.")
                        GoTo ExitSub
                    End If
                    row("Price") = CType(_TxtPrice.Text.Trim, Decimal)
                    row("Disc1Pct") = CType(_lblDisc1Pct.Text.Trim, Decimal)
                    row("Disc1Amt") = CType(_lblDisc1Amt.Text.Trim, Decimal)
                    row("Disc2Pct") = CType(_lblDisc2Pct.Text.Trim, Decimal)
                    row("Disc2Amt") = CType(_lblDisc2Amt.Text.Trim, Decimal)
                    row("Disc3Pct") = CType(_lblDisc3Pct.Text.Trim, Decimal)
                    row("Disc3Amt") = CType(_lblDisc3Amt.Text.Trim, Decimal)

                    If Not IsNumeric(_TxtReturnFeePct.Text) Then
                        commonFunction.MsgBox(Me, "Return Fee ( % ) must be numeric")
                        GoTo ExitSub
                    End If
                    If CDec(_TxtReturnFeePct.Text.Trim) < 0 OrElse CDec(_TxtReturnFeePct.Text.Trim) > 100 Then
                        commonFunction.MsgBox(Me, "Return Fee ( % ) must be 0% - 100%.")
                        GoTo ExitSub
                    End If
                    row("ReturnFeePct") = CType(_TxtReturnFeePct.Text.Trim, Decimal)
                    row("ReturnFeeAmt") = ((CType(_TxtPrice.Text.Trim, Decimal) - CType(_lblDisc1Amt.Text.Trim, Decimal) - CType(_lblDisc2Amt.Text.Trim, Decimal) - CType(_lblDisc3Amt.Text.Trim, Decimal)) * CType(_TxtReturnFeePct.Text.Trim, Decimal)) / 100
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                commonFunction.MsgBox(Me, "You have to choose at least one record to be saved.")
                Exit Sub
            End If

            ' // save header first
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGrid, True)
            'commonFunction.ShowPanel(PanelGridDO, False)


            If Not _SaveHd() Then
                Exit Sub
            End If

            ' // save the data
            Dim pudt As New BussinessRules.SalesReturndt
            pudt.SReturnNo = RadComboBoxSalesReturnID.Text.Trim
            pudt.InsertItemSR(tblTmp, MyBase.LoggedOnUserID)
            pudt.Dispose()
            pudt = Nothing

            UpdateViewGridSalesUnit()
            UpdateViewGridSalesReturn()
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("IDSU", System.Type.GetType("System.String"))
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("QtyReturn", System.Type.GetType("System.Decimal"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Decimal"))
                .Columns.Add("Price", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc1Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc1Amt", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc2Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc2Amt", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc3Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Disc3Amt", System.Type.GetType("System.Decimal"))
                .Columns.Add("ReturnFeePct", System.Type.GetType("System.Decimal"))
                .Columns.Add("ReturnFeeAmt", System.Type.GetType("System.Decimal"))
            End With
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridSalesReturn_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridSalesReturn.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Opendt(txtID.Text.Trim)
                    lbtnNewDetail.Enabled = True
                    lbtnSaveDetail.Enabled = True
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Deletedt(txtID.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridSalesReturn_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridSalesReturn.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.SalesReturnHd
            With br
                .SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Sales order ID is deleted.")
                        PrepareScreenHd()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxSalesReturnID.Text = .SReturnNo.Trim
                    End If
                    RadComboBoxSTxnNo.Text = .STxnNo.Trim
                    RadSReturnDate.SelectedDate = .SReturnDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)
                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)
                    commonFunction.SelectListItem(ddlSReturnReason, .SReturnReasonID.Trim)
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)
                    txtDescriptionHd.Text = .Description.Trim
                    txtReturnFeePct.Text = Format(.ReturnFeePct, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmt.Text = Format(.ReturnFeeAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridSalesUnit()
                    UpdateViewGridSalesReturn()

                    If .IsApproval Then
                        RadComboBoxEntitiesID.Enabled = False
                        chkIsPPN.Enabled = False
                        txtReturnFeePct.ReadOnly = True
                        txtReturnFeeAmt.ReadOnly = True
                        txtCurrencyRate.ReadOnly = True
                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False


                        ddlSReturnReason.Enabled = False
                        ddlCurrency.Enabled = False
                        RadGridSalesReturn.Columns(0).Visible = False
                        RadGridSalesReturn.Columns(1).Visible = False

                        lbtnSaveGetItemSU.Enabled = False
                    Else
                        RadComboBoxEntitiesID.Enabled = True
                        chkIsPPN.Enabled = True
                        txtReturnFeePct.ReadOnly = False
                        txtReturnFeeAmt.ReadOnly = False
                        txtCurrencyRate.ReadOnly = False
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False


                        ddlSReturnReason.Enabled = True
                        ddlCurrency.Enabled = True
                        RadGridSalesReturn.Columns(0).Visible = True
                        RadGridSalesReturn.Columns(1).Visible = True

                        lbtnSaveGetItemSU.Enabled = True
                    End If


                    lbtnNewDetail.Enabled = False
                    lbtnSaveDetail.Enabled = False

                    RadComboBoxEntitiesID.Enabled = False
                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                    ddlSReturnReason.Enabled = False
                    ddlCurrency.Enabled = False

                    If RadComboBoxSTxnNo.Text.Trim <> "" Then
                        RadComboBoxSTxnNo.Enabled = False

                        RadComboBoxEntitiesID.Enabled = False
                        txtCurrencyRate.ReadOnly = True
                    End If

                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxEntitiesID.ClientID)
        End Sub

        Private Sub _Opendt(ByVal ID As String)

            Dim br As New BussinessRules.SalesReturndt
            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridSalesUnit()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName, True)
                    RadComboBoxItemSeqNo_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlItemUnitID, .ItemUnitID)
                    txtItemFactor.Text = Format(.ItemFactor, commonFunction.FORMAT_CURRENCY)
                    txtQty.Text = Format(.Qty, commonFunction.FORMAT_CURRENCY)
                    txtPrice.Text = Format(.Price, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Pct.Text = Format(.Disc1Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(.Disc1Amt, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Pct.Text = Format(.Disc2Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(.Disc2Amt, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Pct.Text = Format(.Disc3Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(.Disc3Amt, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeePctdt.Text = Format(.ReturnFeePct, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmtdt.Text = Format(.ReturnFeeAmt, commonFunction.FORMAT_CURRENCY)
                    txtDescriptiondt.Text = .Description.Trim

                Else
                    PrepareScreendt()
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxItemSeqNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If Len(RadComboBoxEntitiesID.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Entities Name cannot empty.")
                Return False
                Exit Function
            End If

            If CDec(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If RadSReturnDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Sales Return Date must be equal or less than today.")
                Return False
                Exit Function
            End If

            If RadSReturnDate.SelectedDate.Value < RadSUnitDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Sales Return Date must be equal or greater than Sales Unit Date.")
                Return False
                Exit Function
            End If

            If ddlSReturnReason.SelectedValue = "none" Then
                commonFunction.MsgBox(Me, "Sales Return Reason cannot empty.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.SalesReturnHd
            Dim fNew As Boolean = True

            With br
                .SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxSalesReturnID.Text = BussinessRules.ID.GenerateIDNumber("SalesReturnhd", "SReturnNo", "SR")
                End If

                '// set the value

                .SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                .STxnNo = RadComboBoxSTxnNo.Text.Trim

                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .SReturnDate = RadSReturnDate.SelectedDate.Value

                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(Left(Replace(txtPPNpct.Text.Trim, ",", ""), 16).Trim)
                .ReturnFeePct = CDec(Left(Replace(txtReturnFeePct.Text.Trim, ",", ""), 16).Trim)
                .ReturnFeeAmt = CDec(Left(Replace(txtReturnFeeAmt.Text.Trim, ",", ""), 16).Trim)
                .SReturnReasonID = ddlSReturnReason.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(Left(Replace(txtCurrencyRate.Text.Trim, ",", ""), 16).Trim)
                .Description = txtDescriptionHd.Text.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsApproval = False

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

            br.Dispose()
            br = Nothing

            If FApproval Then
                _Approval()
            End If

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _SaveDt()
            If Not IsNumeric(txtQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Qty must be numeric.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtQty.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Qty must be greater than 0.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc1Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 1 ( % ) must be numeric")
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtDisc1Pct.Text.Trim) < 0 OrElse CDec(txtDisc1Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 1 ( % ) must be 0% - 100%.")
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc1Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 1 must be numeric.")
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc1Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 1 must be equal or greater than 0.")
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc2Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 2 ( % ) must be numeric")
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc2Pct.Text.Trim) < 0 OrElse CDec(txtDisc2Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 2 ( % ) must be 0% - 100%.")
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc2Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 2 must be numeric.")
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc2Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 2 must be equal or greater than 0.")
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc3Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 3 ( % ) must be numeric")
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtDisc3Pct.Text.Trim) < 0 OrElse CDec(txtDisc3Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 3 ( % ) must be 0% - 100%.")
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc3Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 3 must be numeric.")
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtDisc3Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 3 must be equal or greater than 0.")
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Len(RadComboBoxItemSeqNo.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item ID Cannot Empty.")
                Exit Sub
            End If

            If ddlItemUnitID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Item Unit Cannot Empty.")
                Exit Sub
            End If

            If Not IsNumeric(txtItemFactor.Text.Trim) Then
                commonFunction.MsgBox(Me, "Item Factor must be numeric.")
                Exit Sub
            End If

            If CDec(txtItemFactor.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                Exit Sub
            End If


            If Not _SaveHd() Then
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesReturndt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("SalesReturndt", "ID", "SU")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnitID.SelectedValue.Trim
                .ItemFactor = CDec(Left(Replace(txtItemFactor.Text.Trim, ",", ""), 15).Trim)
                .Qty = CDec(Left(Replace(txtQty.Text.Trim, ",", ""), 15).Trim)
                .Price = CDec(Left(Replace(txtPrice.Text.Trim, ",", ""), 16).Trim)
                .Disc1Pct = CDec(Left(Replace(txtDisc1Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc1Amt = CDec(Left(Replace(txtDisc1Amt.Text.Trim, ",", ""), 16).Trim)
                .Disc2Pct = CDec(Left(Replace(txtDisc2Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc2Amt = CDec(Left(Replace(txtDisc2Amt.Text.Trim, ",", ""), 16).Trim)
                .Disc3Pct = CDec(Left(Replace(txtDisc3Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc3Amt = CDec(Left(Replace(txtDisc3Amt.Text.Trim, ",", ""), 16).Trim)
                .ReturnFeePct = CDec(Left(Replace(txtReturnFeePctdt.Text.Trim, ",", ""), 16).Trim)
                .ReturnFeeAmt = CDec(Left(Replace(txtReturnFeeAmtdt.Text.Trim, ",", ""), 16).Trim)
                .Description = Left(txtDescriptiondt.Text.Trim, 500)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

            br.Dispose()
            br = Nothing

            PrepareScreendt()
            UpdateViewGridSalesReturn()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxSalesReturnID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesReturnHd
            With br
                .SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.SalesReturndt
                    brdt.SReturnNo = RadComboBoxSalesReturnID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllBySReturnNo()
                    brdt.Dispose()
                    brdt = Nothing

                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        PrepareScreenHd()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxSalesReturnID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesReturndt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridSalesUnit()
                UpdateViewGridSalesReturn()
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
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub


        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxSalesReturnID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(BussinessRules.TxnType.SalesCashierReturn)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            RadComboBoxSTxnNo.Enabled = True
            RadComboBoxEntitiesID.Enabled = True
            ddlWhID.Enabled = True
            ddlUnitID.Enabled = True
            ddlSReturnReason.Enabled = True
            ddlCurrency.Enabled = True
            txtCurrencyRate.ReadOnly = False

            commonFunction.LoadDDLCommonSetting("SReturnReason", ddlSReturnReason, True)
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)

            commonFunction.ShowPanel(PanelDetail, True)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            lbtnSaveGetItemSU.Enabled = True

            RadComboBoxSalesReturnID.Text = String.Empty
            RadComboBoxSalesReturnID.SelectedValue = String.Empty

            RadComboBoxSTxnNo.Text = String.Empty
            RadComboBoxSTxnNo.SelectedValue = String.Empty

            RadSReturnDate.SelectedDate = Date.Now
            RadSUnitDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0
            ddlSReturnReason.SelectedIndex = 0
            ddlCurrency.SelectedIndex = 0
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            txtDescriptionHd.Text = String.Empty
            commonFunction.ShowPanel(PnlApproved, False)

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            commonFunction.GetTaxPct(txtPPNpct)

            txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            PrepareScreendt()

            UpdateViewGridSalesUnit()
            UpdateViewGridSalesReturn()
            CalculationGrid()
        End Sub

        Private Sub PrepareScreendt()
            lbtnNewDetail.Enabled = False
            lbtnSaveDetail.Enabled = False
            txtID.Text = String.Empty
            RadComboBoxItemSeqNo.Text = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
            txtItemName.Text = String.Empty
            ddlItemUnitID.Items.Clear()
            txtItemFactor.Text = "1"
            txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDescriptiondt.Text = String.Empty
        End Sub

        Private Sub LoadSTxnNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesUnitHd

            dt = br.SelectAllForSTxnNoSReturn(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSTxnNo.DataSource = dt.DefaultView
            RadComboBoxSTxnNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadSalesReturn(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesReturnHd

            dt = br.SelectAllForSReturnNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSalesReturnID.DataSource = dt.DefaultView
            RadComboBoxSalesReturnID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesUnitHd

            dt = br.SelectAllForEntitiesSeqNoSalesReturn(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ItemId LIKE '" + Filter.Trim + "%' OR ItemName LIKE '" + Filter.Trim + "%'"

            RadComboBoxItemSeqNo.DataSource = dv
            RadComboBoxItemSeqNo.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDec(txtTotal.Text) + CDec(txtPPN.Text) - CDec(txtReturnFeeAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridSalesReturn()
            Dim subtotal As Decimal = 0
            Dim grandtotal As Decimal = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesReturndt
            br.SReturnNo = RadComboBoxSalesReturnID.Text.Trim
            dt = br.SelectForViewGrid
            dt.Columns.Add("subtotal", GetType(System.Decimal))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDec(dtRows(i - 1)("qty")) * (CDec(dtRows(i - 1)("Price")) - CDec(dtRows(i - 1)("Disc1Amt")) - CDec(dtRows(i - 1)("Disc2Amt")) - CDec(dtRows(i - 1)("Disc3Amt")) - CDec(dtRows(i - 1)("ReturnFeeAmt")))
                    subtotal = subtotal + CDec(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                If CDec(txtReturnFeePct.Text.Trim) > 0 Then
                    txtReturnFeePct_TextChanged(Nothing, Nothing)
                Else
                    txtReturnFeeAmt_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtReturnFeePct.ReadOnly = False
                txtReturnFeeAmt.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePct.ReadOnly = True
                txtReturnFeeAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridSalesReturn.DataSource = dt.DefaultView
            RadGridSalesReturn.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridSalesUnit()
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesUnitDt

            br.STxnNo = RadComboBoxSTxnNo.Text.Trim
            dt = br.SelectForViewGridSU(RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim)

            RadGridSalesUnit.DataSource = dt.DefaultView
            RadGridSalesUnit.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub
#End Region

    End Class
End Namespace