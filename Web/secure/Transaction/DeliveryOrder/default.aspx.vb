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

    Public Class DeliveryOrder
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "510"

        'header
        Protected WithEvents RadDODate As RadDatePicker

        Protected WithEvents RadDueDate As RadDatePicker

        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlBranchID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMemberNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxDeliveryOrderID As RadComboBox
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox

        Protected WithEvents txtPrimaryPhoneNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliveryAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlDeliveryZone As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDeliveryFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMinPurchaseAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMinPurchaseQty As System.Web.UI.WebControls.TextBox

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        'detail

        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
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
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeliveryOrderID As System.Web.UI.WebControls.Label
        Protected WithEvents lblDODateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDueDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesID As System.Web.UI.WebControls.Label
        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCurrencyCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCurrencyRateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionHdCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemSeqNo As System.Web.UI.WebControls.Label
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
        Protected WithEvents lblGrandTotalCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridDeliveryOrder As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxDeliveryOrderID.IsCallBack And _
                'Not RadComboBoxEntitiesID.IsCallBack And _
                'Not RadComboBoxItemSeqNo.IsCallBack Then

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

        Private Sub RadComboBoxDeliveryOrderID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDeliveryOrderID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDeliveryOrder(e.Text)
        End Sub

        Private Sub RadComboBoxDeliveryOrderID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDeliveryOrderID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("DONO").ToString()
        End Sub

        Private Sub RadComboBoxDeliveryOrderID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDeliveryOrderID.SelectedIndexChanged
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
                    If RadComboBoxDeliveryOrderID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 5111
                            .MenuID = 511
                            .AddParametersPrintForm(RadComboBoxDeliveryOrderID.Text.Trim)
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
            InitialVariableTmp()
        End Sub

        Private Sub ddlUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnitID.SelectedIndexChanged
            InitialVariableTmp()
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
            '            txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
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
            txtDiscFinalPct.Text = Format((CDbl(txtDiscFinalAmt.Text.Trim) / CDbl(txtTotal.Text.Trim)) * 100, commonFunction.FORMAT_CURRENCY)
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

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            LoadPrice()
        End Sub

        Private Sub ddlDeliveryZone_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeliveryZone.SelectedIndexChanged
            _OpenDeliveryZone()
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
        Private Sub RadGridDeliveryOrder_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridDeliveryOrder.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Opendt()
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Deletedt(txtID.Text.Trim)
            End Select
        End Sub

        Private Sub RadGridDeliveryOrder_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridDeliveryOrder.ItemCreated
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
            Dim br As New BussinessRules.DeliveryOrderHd
            With br
                .DONo = RadComboBoxDeliveryOrderID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                        PrepareScreenHd()

                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxDeliveryOrderID.Text = .DONo.Trim
                    End If
                    RadDODate.SelectedDate = .DODate
                    RadDueDate.SelectedDate = .DueDate
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

                    commonFunction.SelectListItem(ddlDeliveryZone, .DeliveryZoneID.Trim)
                    _OpenDeliveryZone()
                    txtDeliveryAddress.Text = .DeliveryAddress.Trim
                    txtPrimaryPhoneNo.Text = .PrimaryPhoneNo.Trim
                    txtDeliveryFee.Text = Format(.DeliveryFee, commonFunction.FORMAT_CURRENCY).Trim
                    UpdateViewGridDeliveryOrder()

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
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False
                        'ddlCurrency.Enabled = False
                        RadGridDeliveryOrder.Columns(0).Visible = False
                        RadGridDeliveryOrder.Columns(1).Visible = False
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

                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True

                        ' ddlCurrency.Enabled = True
                        RadGridDeliveryOrder.Columns(0).Visible = True
                        RadGridDeliveryOrder.Columns(1).Visible = True
                    End If

                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If

                    PrepareScreenHd()
                End If
            End With
GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxEntitiesID.ClientID)
        End Sub

        Private Sub _Opendt()

            Dim br As New BussinessRules.DeliveryOrderDt
            With br
                .ID = txtID.Text.Trim
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
            If Not FApproval Then
                'Dim brdt As New BussinessRules.PurchaseUnitDt
                'With brdt
                '    .POrdNO = RadComboBoxDeliveryOrderID.Text.Trim
                '    If .SelectAllByPONo.Rows.Count > 0 Then
                '        commonFunction.MsgBox(Me, "This item already accepted.")
                '        brdt.Dispose()
                '        brdt = Nothing
                '        Return False
                '        Exit Function
                '    End If
                'End With
                'brdt.Dispose()
                'brdt = Nothing

                Dim podt As New BussinessRules.DeliveryOrderDt
                With podt
                    .DONO = RadComboBoxDeliveryOrderID.Text.Trim
                    Dim dv As New DataView(.SelectAllByDONO)
                    dv.RowFilter = "IsRelease = 1"
                    If dv.Count > 0 Then
                        commonFunction.MsgBox(Me, "This item already released.")
                        dv.Dispose()
                        dv = Nothing
                        podt.Dispose()
                        podt = Nothing
                        Return False
                        Exit Function
                    End If
                    dv.Dispose()
                    dv = Nothing
                End With
                podt.Dispose()
                podt = Nothing
            End If

            If Len(RadComboBoxEntitiesID.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Customer Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If Len(txtDeliveryAddress.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Delivery Address Cannot Empty.")
                Return False
                Exit Function
            End If

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If RadDueDate.SelectedDate.Value < RadDODate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Due Date must be equal or greater than DO Date.")
                Return False
                Exit Function
            End If

            If RadDODate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "DO Date must be equal or greater than today.")
                Return False
                Exit Function
            End If

            If RadDueDate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "Due Date must be equal or greater than today.")
                Return False
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

            If ddlDeliveryZone.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Delivery Zone cannot empty.")
                commonFunction.Focus(Me, ddlDeliveryZone.ClientID)
                Return False
                Exit Function
            End If

            If IsNumeric(txtDeliveryFee.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Delivery Fee must be numeric.")
                commonFunction.Focus(Me, txtDeliveryFee.ClientID)
                Return False
                Exit Function
            End If

            If CDec(txtDeliveryFee.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Delivery Fee must be equal or greater than 0.")
                commonFunction.Focus(Me, txtDeliveryFee.ClientID)
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.DeliveryOrderHd
            Dim fNew As Boolean = True

            With br
                .DONo = RadComboBoxDeliveryOrderID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxDeliveryOrderID.Text = BussinessRules.ID.GenerateIDNumber("DeliveryOrderhd", "DONO", "DO")
                End If

                '// set the value
                .DONo = RadComboBoxDeliveryOrderID.Text.Trim
                .DODate = RadDODate.SelectedDate.Value
                .DueDate = RadDueDate.SelectedDate.Value
                .BranchID = ddlBranchID.SelectedValue.Trim
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(txtPPNpct.Text)
                .DiscFinalPct = CDec(Left(Replace(txtDiscFinalPct.Text.Trim, ",", ""), 16).Trim)
                .DiscFinalAmt = CDec(Left(Replace(txtDiscFinalAmt.Text.Trim, ",", ""), 16).Trim)
                .Description = Left(txtDescriptionHd.Text.Trim, 500)
                .DeliveryZoneID = ddlDeliveryZone.SelectedValue.Trim
                .DeliveryAddress = Left(txtDeliveryAddress.Text.Trim, 500)
                .PrimaryPhoneNo = txtPrimaryPhoneNo.Text.Trim
                .DeliveryFee = CDec(Left(Replace(txtDeliveryFee.Text.Trim, ",", ""), 16).Trim)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsApproval = FApproval

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

            br.Dispose()
            br = Nothing

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
                commonFunction.MsgBox(Me, "Item Name Cannot Empty.")
                Exit Sub
            End If

            If ddlItemUnitID.SelectedValue = "none" Then
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

            Dim br As New BussinessRules.DeliveryOrderDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("DeliveryOrderdt", "ID")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .DONO = RadComboBoxDeliveryOrderID.Text.Trim
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
            UpdateViewGridDeliveryOrder()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxDeliveryOrderID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DeliveryOrderHd

            With br
                .DONo = RadComboBoxDeliveryOrderID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.DeliveryOrderDt
                    brdt.DONO = RadComboBoxDeliveryOrderID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByDONO()
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

            commonFunction.Focus(Me, RadComboBoxDeliveryOrderID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DeliveryOrderDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridDeliveryOrder()
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

#Region " Main Function (Custom) "
        Private Sub _OpenDeliveryZone()
            Dim br As New BussinessRules.DeliveryZoneHd

            With br
                .DeliveryZoneID = ddlDeliveryZone.SelectedValue.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtMinPurchaseAmount.Text = Format(.MinPurchaseAmount, commonFunction.FORMAT_CURRENCY).Trim
                    txtMinPurchaseQty.Text = Format(.MinPurchaseQty, commonFunction.FORMAT_QTY).Trim
                    txtDeliveryFee.Text = Format(.DeliveryFee, commonFunction.FORMAT_CURRENCY).Trim
                Else
                    txtMinPurchaseAmount.Text = "0.00"
                    txtMinPurchaseQty.Text = "0.000"
                    txtDeliveryFee.Text = "0.00"
                End If
            End With

            br.Dispose()
            br = Nothing

            CalculationGrid()
        End Sub

        Private Sub _SelectInfoByEntitiesSeqNo(ByVal EntitiesSeqNo As String)
            If Len(EntitiesSeqNo.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.Entities

            With br
                .EntitiesSeqNo = EntitiesSeqNo.Trim
                If .SelectOne.Rows.Count > 0 Then
                    commonFunction.SelectListItem(ddlDeliveryZone, .DeliveryZoneID.Trim)
                    _OpenDeliveryZone()
                    txtPrimaryPhoneNo.Text = .PrimaryPhoneNo.Trim
                    txtDeliveryAddress.Text = .PrimaryAddress.Trim
                    txtMemberNo.Text = .MemberNo.Trim
                Else
                    ddlDeliveryZone.SelectedIndex = 0
                    txtDeliveryFee.Text = "0.00"
                    txtMinPurchaseAmount.Text = "0.00"
                    txtMinPurchaseQty.Text = "0.000"
                    txtPrimaryPhoneNo.Text = String.Empty
                    txtDeliveryAddress.Text = String.Empty
                    txtMemberNo.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing

            CalculationGrid()
        End Sub
#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub PrepareScreenHd()
            SourceWhIDTmp = String.Empty
            SourceUnitIDTmp = String.Empty

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            '//Delivery Zone
            Dim oDZ As New BussinessRules.DeliveryZoneHd
            Dim dtDZ As New DataTable
            With oDZ
                dtDZ = .SelectAllActive
                commonFunction.LoadDDL(ddlDeliveryZone, "DeliveryZoneName", "DeliveryZoneID", dtDZ, True)
            End With
            oDZ.Dispose()
            oDZ = Nothing

            '//Branch
            Dim bc As New BussinessRules.Branch
            Dim dt As New DataTable
            dt = bc.SelectAll
            dt.Select("IsActive=1")
            commonFunction.LoadDDL(ddlBranchID, "BranchName", "BranchID", dt, False)
            dt.Dispose()
            dt = Nothing
            bc.Dispose()
            bc = Nothing

            '//Warehouse
            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            '//Unit
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True

            RadComboBoxDeliveryOrderID.Text = String.Empty
            RadComboBoxDeliveryOrderID.SelectedValue = String.Empty

            RadDODate.SelectedDate = Date.Now
            RadDueDate.SelectedDate = Date.Now
            txtMemberNo.Text = String.Empty
            txtDescriptionHd.Text = String.Empty
            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0

            commonFunction.SelectListItem(ddlCurrency, commonFunction.GetCurrencyPos.Trim)
            ddlCurrency.Enabled = False
            txtCurrencyRate.Text = "1.00"
            txtCurrencyRate.ReadOnly = True

            txtDescriptionHd.Text = String.Empty
            txtPrimaryPhoneNo.Text = String.Empty
            txtDeliveryAddress.Text = String.Empty
            ddlDeliveryZone.SelectedIndex = 0
            txtDeliveryFee.Text = "0.00"
            txtMinPurchaseAmount.Text = "0.00"
            txtMinPurchaseQty.Text = "0.000"
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
            txtQty.Text = "1.000"
            txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsBonus.Checked = False
            txtDescriptiondt.Text = String.Empty
        End Sub

        Private Sub LoadDeliveryOrder(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderHd

            dt = br.SelectAllForDONo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDeliveryOrderID.DataSource = dt.DefaultView
            RadComboBoxDeliveryOrderID.DataBind()

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
            txtGrandTotal.Text = Format((CDec(txtTotal.Text.Trim) + CDec(txtPPN.Text.Trim) + CDec(txtDeliveryFee.Text.Trim) - CDec(txtDiscFinalAmt.Text.Trim)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridDeliveryOrder()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderDt
            br.DONO = RadComboBoxDeliveryOrderID.Text.Trim
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
                If txtDiscFinalPct.Text.Trim = "0" Then
                    txtDiscFinalAmt_TextChanged(Nothing, Nothing)
                Else
                    txtDiscFinalPct_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtDiscFinalPct.ReadOnly = False
                txtDiscFinalAmt.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.ReadOnly = True
                txtDiscFinalAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridDeliveryOrder.DataSource = dt.DefaultView
            RadGridDeliveryOrder.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadPrice()
            If Len(txtItemFactor.Text.Trim) = 0 Then txtItemFactor.Text = "1"
            If IsNumeric(txtItemFactor.Text.Trim) = False Or CDec(txtItemFactor.Text.Trim) < 1 Then
                txtItemFactor.Text = "1"
            End If
            If Len(txtCurrencyRate.Text.Trim) = 0 Then txtCurrencyRate.Text = "1"
            If IsNumeric(txtCurrencyRate.Text.Trim) = False Or CDec(txtCurrencyRate.Text.Trim) < 1 Then
                txtCurrencyRate.Text = "1"
            End If

            If ddlItemUnitID.SelectedValue.Trim <> Nothing And ddlItemUnitID.SelectedValue.Trim <> "none" _
                And Len(ddlItemUnitID.SelectedValue.Trim) > 0 Then
                Dim oPrice As BussinessRules.Price
                oPrice = BussinessRules.Functions.GetPriceItemDOorSales("BO", CDec(txtCurrencyRate.Text.Trim), RadComboBoxItemSeqNo.SelectedValue.Trim, ddlItemUnitID.SelectedValue.Trim, CDec(txtItemFactor.Text.Trim), txtMemberNo.Text.Trim, RadComboBoxDeliveryOrderID.Text.Trim, CDec(txtQty.Text.Trim))
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