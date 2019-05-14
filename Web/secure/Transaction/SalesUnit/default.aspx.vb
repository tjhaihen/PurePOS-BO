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

    Public Class SalesUnit
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "520"

        'header
        Protected WithEvents RadSTxnDate As RadDatePicker

        Protected WithEvents ddlStxnTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlBranchID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMemberNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliveryFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxDONO As RadComboBox
        Protected WithEvents RadComboBoxSalesUnitID As RadComboBox
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
        Protected WithEvents txtDescriptiondt As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton

        Protected WithEvents chkIsBonus As System.Web.UI.WebControls.CheckBox

        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesUnitID As System.Web.UI.WebControls.Label

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
        Protected WithEvents RadGridSalesUnit As DataGrid
        Protected WithEvents RadGridDeliveryOrder As DataGrid

        'link
        Protected WithEvents lbtnSaveGetItemDO As System.Web.UI.WebControls.LinkButton

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelDetail As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridDO As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxSalesUnitID.IsCallBack And Not RadComboBoxEntitiesID.IsCallBack And Not RadComboBoxDONO.IsCallBack Then
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

        Private Sub RadComboBoxDONO_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDONO.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDONO(e.Text)
        End Sub

        Private Sub RadComboBoxDONO_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDONO.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("DONO").ToString()
        End Sub

        Private Sub RadComboBoxDONO_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDONO.SelectedIndexChanged
            Dim ob As New BussinessRules.DeliveryOrderHd
            ob.DONo = RadComboBoxDONO.Text.Trim
            If ob.SelectOne.Rows.Count > 0 Then
                commonFunction.SelectListItem(ddlBranchID, ob.BranchID.Trim)
                RadComboBoxEntitiesID.SelectedValue = ob.EntitiesSeqNo.Trim
                commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                commonFunction.SelectListItem(ddlWhID, ob.WhID.Trim)
                commonFunction.SelectListItem(ddlUnitID, ob.UnitID.Trim)
                commonFunction.SelectListItem(ddlCurrency, ob.Currency.Trim)
                txtCurrencyRate.Text = Format(ob.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                txtDeliveryFee.Text = Format(ob.DeliveryFee, commonFunction.FORMAT_CURRENCY)
                UpdateViewGridDeliveryOrder()

                RadComboBoxDONO.Enabled = False
                ddlBranchID.Enabled = False
                RadComboBoxEntitiesID.Enabled = False
                ddlWhID.Enabled = False
                ddlUnitID.Enabled = False
                'ddlCurrency.Enabled = False
                txtCurrencyRate.ReadOnly = True
            Else
                PrepareScreenHd()
            End If
            ob.Dispose()
            ob = Nothing

            CalculationGrid()
        End Sub

        Private Sub RadComboBoxSalesUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSalesUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSalesUnit(e.Text)
        End Sub

        Private Sub RadComboBoxSalesUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSalesUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("STxnNo").ToString()
        End Sub

        Private Sub RadComboBoxSalesUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSalesUnitID.SelectedIndexChanged
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
            _SelectInfoByEntitiesSeqNo(RadComboBoxEntitiesID.SelectedValue.Trim)
            UpdateViewGridDeliveryOrder()
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
            commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNoForDOandSU(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing
            LoadPrice()
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
                    If RadComboBoxSalesUnitID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 5201
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxSalesUnitID.Text.Trim)
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
            _Savedt()
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
            'UpdateViewGridDeliveryOrder()
        End Sub

        'Private Sub ddlUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnitID.SelectedIndexChanged
        '    UpdateViewGridDeliveryOrder()
        'End Sub

        'Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        '    UpdateViewGridDeliveryOrder()
        'End Sub

        Private Sub ddlStxnTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStxnTypeID.SelectedIndexChanged
            LoadPrice()
        End Sub

        Private Sub ddlItemUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemUnitID.SelectedIndexChanged
            Dim ift As New BussinessRules.ItemFactorTemplate
            ift.ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
            ift.ItemUnitID = ddlItemUnitID.SelectedValue.Trim
            If ift.SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                txtItemFactor.Text = Format(ift.ItemFactor, commonFunction.FORMAT_CURRENCY)
            Else
                txtItemFactor.Text = ""
            End If
            ift.Dispose()
            ift = Nothing
            LoadPrice()
        End Sub

        Private Sub chkIsBonus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsBonus.CheckedChanged
            If chkIsBonus.Checked Then
                txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDbl(txtPPNpct.Text.Trim) * (CDbl(txtTotal.Text.Trim) - CDbl(txtDiscFinalAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalPct.TextChanged
            If Not IsNumeric(txtDiscFinalPct.Text) Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) must be numeric")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalPct.Text.Trim) < 0 OrElse CDec(txtDiscFinalPct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) Must Be 0% - 100%.")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtDiscFinalPct.Text = Format(CDbl(txtDiscFinalPct.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format((CDbl(txtDiscFinalPct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalAmt.TextChanged
            If Not IsNumeric(txtDiscFinalAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount Final Must Be Numeric.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount Final Must Be equal Or Greater than 0.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtDiscFinalAmt.Text = Format(CDbl(txtDiscFinalAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub txtPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrice.TextChanged
            If IsNumeric(txtPrice.Text.Trim) Then
                txtPrice.Text = Format((CDec(txtPrice.Text.Trim)), commonFunction.FORMAT_CURRENCY)
            Else
                txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If

            txtDisc1Pct_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtDisc1Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Pct.TextChanged
            If IsNumeric(txtDisc1Pct.Text.Trim) Then
                txtDisc1Amt.Text = Format((CDbl(txtDisc1Pct.Text.Trim) * CDbl(txtPrice.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc1Amt.Text.Trim) > CDbl(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc1Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Amt.TextChanged
            If IsNumeric(txtDisc1Amt.Text.Trim) Then
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(CDbl(txtDisc1Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc1Amt.Text.Trim) > CDbl(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Pct.TextChanged
            If IsNumeric(txtDisc2Pct.Text.Trim) Then
                txtDisc2Amt.Text = Format((CDbl(txtDisc2Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Amt.TextChanged
            If IsNumeric(txtDisc2Amt.Text.Trim) Then
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(CDbl(txtDisc2Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Pct.TextChanged
            If IsNumeric(txtDisc3Pct.Text.Trim) Then
                txtDisc3Amt.Text = Format((CDbl(txtDisc3Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Amt.TextChanged
            If IsNumeric(txtDisc3Amt.Text.Trim) Then
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(CDbl(txtDisc3Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub lbtnSaveGetItemDO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveGetItemDO.Click
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridDeliveryOrder.Items
                Dim _chkOrder As CheckBox = CType(gitm.FindControl("_chkOrder"), CheckBox)
                Dim _lblID As Label = CType(gitm.FindControl("_lblID"), Label)
                Dim _lblDONO As Label = CType(gitm.FindControl("_lblDONO"), Label)
                Dim _lblItemSeqNo As Label = CType(gitm.FindControl("_lblItemSeqNo"), Label)
                Dim _lblItemName As Label = CType(gitm.FindControl("_lblItemName"), Label)
                Dim _lblQtyRemaining As Label = CType(gitm.FindControl("_lblQtyRemaining"), Label)
                Dim _txtQtySale As TextBox = CType(gitm.FindControl("_txtQtySale"), TextBox)
                Dim _lblItemUnitID As Label = CType(gitm.FindControl("_lblItemUnitID"), Label)
                Dim _TxtPrice As TextBox = CType(gitm.FindControl("_TxtPrice"), TextBox)
                Dim _TxtItemFactor As TextBox = CType(gitm.FindControl("_TxtItemFactor"), TextBox)
                Dim _lblDueDate As Label = CType(gitm.FindControl("_lblDueDate"), Label)
                Dim _chkIsBonus As CheckBox = CType(gitm.FindControl("_chkIsBonus"), CheckBox)
                Dim _lblDisc1Pct As Label = CType(gitm.FindControl("_lblDisc1Pct"), Label)
                Dim _lblDisc1Amt As Label = CType(gitm.FindControl("_lblDisc1Amt"), Label)
                Dim _lblDisc2Pct As Label = CType(gitm.FindControl("_lblDisc2Pct"), Label)
                Dim _lblDisc2Amt As Label = CType(gitm.FindControl("_lblDisc2Amt"), Label)
                Dim _lblDisc3Pct As Label = CType(gitm.FindControl("_lblDisc3Pct"), Label)
                Dim _lblDisc3Amt As Label = CType(gitm.FindControl("_lblDisc3Amt"), Label)

                If _chkOrder.Checked = True Then
                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("IDDO") = Trim(_lblID.Text)
                    row("ItemSeqNo") = CType(Trim(_lblItemSeqNo.Text.Trim), String)
                    row("ItemUnitID") = CType(Trim(_lblItemUnitID.Text.Trim), String)

                    If Not IsNumeric(_TxtItemFactor.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Item Factor must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDbl(_TxtItemFactor.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                        GoTo ExitSub
                    End If
                    row("ItemFactor") = CDec(Left(Replace(_TxtItemFactor.Text.Trim, ",", ""), 16).Trim)

                    If Not IsNumeric(_txtQtySale.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Qty Sale must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDbl(_txtQtySale.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Qty Sale must be greater than 0.")
                        GoTo ExitSub
                    End If

                    Dim podt As New BussinessRules.DeliveryOrderDt
                    Dim dt As New DataTable
                    podt.ID = _lblID.Text.Trim
                    dt = podt.ValidateSaveGetItemDO(RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim)
                    If (CDbl(_txtQtySale.Text.Trim) * CDbl(_TxtItemFactor.Text.Trim)) > ((CDbl(dt.Rows(0)("Qty")) * CDbl(dt.Rows(0)("ItemFactor"))) - CDbl(dt.Rows(0)("QtySale")) - CDbl(dt.Rows(0)("QtySU"))) Then
                        commonFunction.MsgBox(Me, "[" + _lblDONO.Text.Trim + "] " + _lblItemName.Text.Trim + " Qty Sale (" + Format((CDbl(_txtQtySale.Text.Trim) * CDbl(_TxtItemFactor.Text.Trim)), commonFunction.FORMAT_CURRENCY) + ") must be equal or Less than qty remaining (" + Format(((CDbl(dt.Rows(0)("Qty")) * CDbl(dt.Rows(0)("ItemFactor"))) - CDbl(dt.Rows(0)("QtySale")) - CDbl(dt.Rows(0)("QtySU"))), commonFunction.FORMAT_CURRENCY) + ").")
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
                    row("QtySale") = CDec(Left(Replace(_txtQtySale.Text.Trim, ",", ""), 16).Trim)

                    If Not IsNumeric(_TxtPrice.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Price must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDbl(_TxtPrice.Text.Trim) < 0 Then
                        commonFunction.MsgBox(Me, "Price must be equal or greater than 0.")
                        GoTo ExitSub
                    End If
                    row("Price") = CDec(Left(Replace(_TxtPrice.Text.Trim, ",", ""), 16).Trim)
                    row("Disc1Pct") = CDec(Left(Replace(_lblDisc1Pct.Text.Trim, ",", ""), 16).Trim)
                    row("Disc1Amt") = CDec(Left(Replace(_lblDisc1Amt.Text.Trim, ",", ""), 16).Trim)
                    row("Disc2Pct") = CDec(Left(Replace(_lblDisc2Pct.Text.Trim, ",", ""), 16).Trim)
                    row("Disc2Amt") = CDec(Left(Replace(_lblDisc2Amt.Text.Trim, ",", ""), 16).Trim)
                    row("Disc3Pct") = CDec(Left(Replace(_lblDisc3Pct.Text.Trim, ",", ""), 16).Trim)
                    row("Disc3Amt") = CDec(Left(Replace(_lblDisc3Amt.Text.Trim, ",", ""), 16).Trim)
                    row("DONO") = CType(Trim(_lblDONO.Text.Trim), String)
                    row("IsBonus") = CType(_chkIsBonus.Checked, Boolean)
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                commonFunction.MsgBox(Me, "You to choose at least one record to be save")
                Exit Sub
            End If

            '// save header first
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGrid, True)

            If Not _SaveHd() Then
                Exit Sub
            End If

            '// save the data
            Dim pudt As New BussinessRules.SalesUnitDt
            pudt.STxnNo = RadComboBoxSalesUnitID.Text.Trim
            pudt.UserInsert = MyBase.LoggedOnUserID.Trim
            pudt.InsertItemSu(tblTmp)
            pudt.Dispose()
            pudt = Nothing

            UpdateViewGridDeliveryOrder()
            UpdateViewGridSalesUnit()
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("IDDO", System.Type.GetType("System.String"))
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("QtySale", System.Type.GetType("System.Double"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Double"))
                .Columns.Add("Price", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Amt", System.Type.GetType("System.Double"))
                .Columns.Add("DONO", System.Type.GetType("System.String"))
                .Columns.Add("IsBonus", System.Type.GetType("System.Boolean"))
            End With
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            LoadPrice()
        End Sub

        Private Sub txtCurrencyRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCurrencyRate.TextChanged
            LoadPrice()
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
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridSalesUnit_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridSalesUnit.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _OpenDt(txtID.Text.Trim)
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Deletedt(txtID.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridSalesUnit_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridSalesUnit.ItemCreated
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

            Dim br As New BussinessRules.SalesUnitHd
            With br
                .STxnNo = RadComboBoxSalesUnitID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Sales order ID is deleted.")
                        PrepareScreenHd()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxSalesUnitID.Text = .STxnNo.Trim
                    End If
                    RadComboBoxDONO.Text = .DONo.Trim
                    RadSTxnDate.SelectedDate = .STxnDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    _SelectInfoByEntitiesSeqNo(RadComboBoxEntitiesID.SelectedValue.Trim)
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)
                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)
                    txtDescriptionHd.Text = .Description.Trim
                    txtDiscFinalPct.Text = Format(.DiscFinalPct, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format(.DiscFinalAmt, commonFunction.FORMAT_CURRENCY)
                    txtDeliveryFee.Text = Format(.DeliveryFee, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridDeliveryOrder()
                    UpdateViewGridSalesUnit()

                    If .IsApproval Then
                        RadComboBoxEntitiesID.Enabled = False
                        chkIsPPN.Enabled = False
                        txtDiscFinalPct.ReadOnly = True
                        txtDiscFinalAmt.ReadOnly = True
                        txtCurrencyRate.ReadOnly = True
                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        lbtnSaveGetItemDO.Enabled = False

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False

                        RadComboBoxItemSeqNo.Enabled = False

                        'ddlCurrency.Enabled = False
                        RadGridSalesUnit.Columns(0).Visible = False
                        RadGridSalesUnit.Columns(1).Visible = False

                    Else
                        RadComboBoxEntitiesID.Enabled = True
                        chkIsPPN.Enabled = True
                        txtDiscFinalPct.ReadOnly = False
                        txtDiscFinalAmt.ReadOnly = False
                        txtCurrencyRate.ReadOnly = False
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        lbtnSaveGetItemDO.Enabled = True

                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True

                        RadComboBoxItemSeqNo.Enabled = True

                        'ddlCurrency.Enabled = True
                        RadGridSalesUnit.Columns(0).Visible = True
                        RadGridSalesUnit.Columns(1).Visible = True
                    End If

                    'If RadComboBoxDONO.Text.Trim <> "" Then
                    RadComboBoxDONO.Enabled = False
                    ddlBranchID.Enabled = False
                    RadComboBoxEntitiesID.Enabled = False
                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                    'ddlCurrency.Enabled = False
                    txtCurrencyRate.ReadOnly = True
                    'End If
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxEntitiesID.ClientID)
        End Sub

        Private Sub _OpenDt(ByVal ID As String)

            Dim br As New BussinessRules.SalesUnitDt
            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridDeliveryOrder()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName, True)
                    chkIsBonus.Checked = .IsBonus
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
                commonFunction.MsgBox(Me, "Customer Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If IsNumeric(txtDeliveryFee.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Delivery Fee must be numeric.")
                Return False
                Exit Function
            End If

            If CDbl(txtDeliveryFee.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Delivery Fee must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If IsNumeric(txtCurrencyRate.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Currency Rate must be numeric.")
                Return False
                Exit Function
            End If

            If CDbl(txtCurrencyRate.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Currency Rate must be greater than 0.")
                Return False
                Exit Function
            End If

            If RadSTxnDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Sales Transaction Date must be equal or less than today.")
                Return False
                Exit Function
            End If

            If Len(RadComboBoxDONO.Text.Trim) > 0 Then
                Dim DODate As Date
                Dim oDO As New BussinessRules.DeliveryOrderHd
                With oDO
                    .DONo = RadComboBoxDONO.Text.Trim
                    If .SelectOne.Rows.Count > 0 Then
                        DODate = .DODate
                        If RadSTxnDate.SelectedDate.Value < DODate Then
                            commonFunction.MsgBox(Me, "Sales Transaction Date must be equal or greater than Delivery Order Date.")
                            oDO.Dispose()
                            oDO = Nothing
                            Return False
                            Exit Function
                        End If
                    Else
                        commonFunction.MsgBox(Me, "DO No. not found.")
                        oDO.Dispose()
                        oDO = Nothing
                        Return False
                        Exit Function
                    End If
                End With
                oDO.Dispose()
                oDO = Nothing
            End If

            Dim br As New BussinessRules.SalesUnitHd
            Dim fNew As Boolean = True

            With br
                .STxnNo = RadComboBoxSalesUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxSalesUnitID.Text = BussinessRules.ID.GenerateIDNumber("SalesUnithd", "STxnNo", "OS", " WHERE LEFT(STxnNo, @PrefixLength) = @prefix ")
                End If

                '// set the value
                .DONo = RadComboBoxDONO.Text.Trim
                .STxnNo = RadComboBoxSalesUnitID.Text.Trim
                .StxnTypeID = ddlStxnTypeID.SelectedValue.Trim
                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .STxnDate = RadSTxnDate.SelectedDate.Value
                .BranchID = ddlBranchID.SelectedValue.Trim
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(Left(Replace(txtPPNpct.Text.Trim, ",", ""), 16).Trim)
                .DiscFinalPct = CDec(Left(Replace(txtDiscFinalPct.Text.Trim, ",", ""), 16).Trim)
                .DiscFinalAmt = CDec(Left(Replace(txtDiscFinalAmt.Text.Trim, ",", ""), 16).Trim)
                .DeliveryFee = CDec(Left(Replace(txtDeliveryFee.Text.Trim, ",", ""), 16).Trim)
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

        Private Sub _Savedt()

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

            If CDbl(txtItemFactor.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                Exit Sub
            End If

            If Not _SaveHd() Then
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesUnitDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("SalesUnitdt", "ID", "OS", " WHERE LEFT(ID, @PrefixLength) = @prefix ")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .STxnNo = RadComboBoxSalesUnitID.Text.Trim
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
                .IsBonus = chkIsBonus.Checked
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
            UpdateViewGridSalesUnit()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxSalesUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesUnitHd
            With br
                .STxnNo = RadComboBoxSalesUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.SalesUnitDt
                    brdt.STxnNo = RadComboBoxSalesUnitID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllBySTxnNo()
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

            commonFunction.Focus(Me, RadComboBoxSalesUnitID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesUnitDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridDeliveryOrder()
                UpdateViewGridSalesUnit()
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

#Region " Main Function (Custom) "
        Private Sub _SelectInfoByEntitiesSeqNo(ByVal EntitiesSeqNo As String)
            If Len(EntitiesSeqNo.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.Entities

            With br
                .EntitiesSeqNo = EntitiesSeqNo.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtMemberNo.Text = .MemberNo.Trim
                Else
                    txtMemberNo.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub
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
            th.TxnNo = RadComboBoxSalesUnitID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(BussinessRules.TxnType.SalesCashier)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            SourceWhIDTmp = String.Empty
            SourceUnitIDTmp = String.Empty

            RadComboBoxItemSeqNo.Enabled = True

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True

            RadComboBoxDONO.Enabled = True
            ddlBranchID.Enabled = True
            RadComboBoxEntitiesID.Enabled = True
            ddlWhID.Enabled = True
            ddlUnitID.Enabled = True

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            commonFunction.LoadDDLCommonSetting("STxnTypeID", ddlStxnTypeID, False)

            '// Grocer as default Type in Back Office
            commonFunction.SelectListItem(ddlStxnTypeID, "02")

            Dim bc As New BussinessRules.Branch
            Dim dt As New DataTable
            dt = bc.SelectAll
            dt.Select("IsActive=1")
            commonFunction.LoadDDL(ddlBranchID, "BranchName", "BranchID", dt, False)
            dt.Dispose()
            dt = Nothing
            bc.Dispose()
            bc = Nothing

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            RadComboBoxEntitiesID.Enabled = True
            ddlWhID.Enabled = True
            ddlUnitID.Enabled = True

            txtCurrencyRate.ReadOnly = False
            commonFunction.SelectListItem(ddlCurrency, commonFunction.GetCurrencyPos.Trim)
            ddlCurrency.Enabled = False
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            txtDeliveryFee.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)

            commonFunction.ShowPanel(PanelDetail, True)
            'commonFunction.ShowPanel(PanelGridDO, False)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            lbtnSaveGetItemDO.Enabled = True

            RadComboBoxSalesUnitID.Text = String.Empty
            RadComboBoxSalesUnitID.SelectedValue = String.Empty

            RadComboBoxDONO.Text = String.Empty
            RadComboBoxDONO.SelectedValue = String.Empty

            RadSTxnDate.SelectedDate = Date.Now
            txtMemberNo.Text = String.Empty
            txtDescriptionHd.Text = String.Empty

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0

            txtDescriptionHd.Text = String.Empty
            commonFunction.ShowPanel(PnlApproved, False)

            RadComboBoxEntitiesID.Enabled = True
            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            commonFunction.GetTaxPct(txtPPNpct)

            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)
            PrepareScreendt()

            UpdateViewGridDeliveryOrder()
            UpdateViewGridSalesUnit()
            CalculationGrid()

            InitialVariableTmp()
        End Sub

        Private Sub PrepareScreendt()
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
            txtDescriptiondt.Text = String.Empty
            chkIsBonus.Checked = False
        End Sub

        Private Sub LoadDONO(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderHd

            dt = br.SelectAllForDONoSaleUnit(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDONO.DataSource = dt.DefaultView
            RadComboBoxDONO.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadSalesUnit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesUnitHd

            dt = br.SelectAllForSTxnNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSalesUnitID.DataSource = dt.DefaultView
            RadComboBoxSalesUnitID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            '// '04' = Customer/Member as EntitiesType
            dt = br.SelectAllForEntitiesSeqNoByEntitiesType("04", Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemBalance

            br.WhID = SourceWhIDTmp.Trim
            br.UnitID = SourceUnitIDTmp.Trim

            dt = br.SelectAllByWhIDUnitIDForItemSeqNoDOAndSU(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxItemSeqNo.DataSource = dt
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) + CDbl(txtDeliveryFee.Text) - CDbl(txtDiscFinalAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridSalesUnit()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesUnitDt
            br.STxnNo = RadComboBoxSalesUnitID.Text.Trim
            dt = br.SelectForViewGrid
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt")))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                If CDbl(txtDiscFinalPct.Text.Trim) > 0 Then
                    txtDiscFinalPct_TextChanged(Nothing, Nothing)
                Else
                    txtDiscFinalAmt_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtDiscFinalPct.ReadOnly = False
                txtDiscFinalAmt.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.ReadOnly = True
                txtDiscFinalAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridSalesUnit.DataSource = dt.DefaultView
            RadGridSalesUnit.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridDeliveryOrder()
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderDt

            br.DONO = RadComboBoxDONO.Text.Trim
            dt = br.SelectForViewGridDOForSU(RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim)

            RadGridDeliveryOrder.DataSource = dt.DefaultView
            RadGridDeliveryOrder.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadPrice()
            Dim strTypeGetPrice As String = String.Empty
            If ddlStxnTypeID.SelectedValue = "01" Then
                '// retail
                strTypeGetPrice = "FO"
            Else
                strTypeGetPrice = "BO"
            End If

            If ddlItemUnitID.SelectedValue.Trim <> Nothing And ddlItemUnitID.SelectedValue.Trim <> "none" _
                And Len(ddlItemUnitID.SelectedValue.Trim) > 0 Then
                Dim oPrice As BussinessRules.Price
                oPrice = BussinessRules.Functions.GetPriceItemDOorSales(strTypeGetPrice.Trim, CDec(txtCurrencyRate.Text.Trim), RadComboBoxItemSeqNo.SelectedValue.Trim, ddlItemUnitID.SelectedValue.Trim, CDec(txtItemFactor.Text.Trim), txtMemberNo.Text.Trim, RadComboBoxSalesUnitID.Text.Trim, CDec(txtQty.Text.Trim))
                txtPrice.Text = Format(oPrice.price, commonFunction.FORMAT_CURRENCY)
                txtDisc1Pct.Text = Format(oPrice.discount1pct, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(oPrice.discount1amt, commonFunction.FORMAT_CURRENCY)
                txtDisc2Pct.Text = Format(oPrice.discount2pct, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(oPrice.discount2amt, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(oPrice.discount3pct, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(oPrice.discount3amt, commonFunction.FORMAT_CURRENCY)
            Else
                txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub InitialVariableTmp()
            SourceWhIDTmp = ddlWhID.SelectedValue.Trim
            SourceUnitIDTmp = ddlUnitID.SelectedValue.Trim
        End Sub
#End Region

    End Class
End Namespace