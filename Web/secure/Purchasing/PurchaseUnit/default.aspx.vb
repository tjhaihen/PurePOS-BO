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


Namespace Raven.Web.Secure.Purchasing

    Public Class PurchaseUnit
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "350"

        'header
        Protected WithEvents RadPUnitDate As RadDatePicker

        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtInvoiceNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxPurchaseUnitID As RadComboBox
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
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPurchaseUnitID As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdExpiredDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdTypeIDCaption As System.Web.UI.WebControls.Label
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
        Protected WithEvents RadGridPurchaseUnit As DataGrid
        Protected WithEvents RadGridPurchaseOrder As DataGrid

        'link
        Protected WithEvents lbtnCancelGetItemPO As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveGetItemPO As System.Web.UI.WebControls.LinkButton

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelDetail As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridPO As System.Web.UI.WebControls.Panel

        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxPurchaseUnitID.IsCallBack And Not RadComboBoxEntitiesID.IsCallBack Then
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

        Private Sub RadComboBoxPurchaseUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxPurchaseUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadPurchaseUnit(e.Text)
        End Sub

        Private Sub RadComboBoxPurchaseUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxPurchaseUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("PUnitNO").ToString()
        End Sub

        Private Sub RadComboBoxPurchaseUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPurchaseUnitID.SelectedIndexChanged
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
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItem(e.Text)
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemName").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNo.SelectedIndexChanged
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
                    If RadComboBoxPurchaseUnitID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 3501
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxPurchaseUnitID.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
                Case CSSToolbarItem.tidOther1
                    If Len(RadComboBoxEntitiesID.SelectedValue.Trim) = 0 Then
                        commonFunction.MsgBox(Me, "Entities Name Cannot Empty.")
                        Exit Sub
                    End If

                    If txtInvoiceNo.Text.Trim = "" Then
                        commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                        Exit Sub
                    End If

                    UpdateViewGridPurchaseOrder()
                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelDetail, False)
                    commonFunction.ShowPanel(PanelGrid, False)
                    commonFunction.ShowPanel(PanelGridPO, True)
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
                txtPrice.Text = Format(CDec(txtPrice.Text.Trim), commonFunction.FORMAT_CURRENCY)
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

        Private Sub lbtnCancelGetItemPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCancelGetItemPO.Click
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridPO, False)
        End Sub

        Private Sub lbtnSaveGetItemPO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveGetItemPO.Click
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridPurchaseOrder.Items
                Dim _chkOrder As CheckBox = CType(gitm.FindControl("_chkOrder"), CheckBox)
                Dim _lblID As Label = CType(gitm.FindControl("_lblID"), Label)
                Dim _lblPOrdNO As Label = CType(gitm.FindControl("_lblPOrdNO"), Label)
                Dim _lblItemSeqNo As Label = CType(gitm.FindControl("_lblItemSeqNo"), Label)
                Dim _lblItemName As Label = CType(gitm.FindControl("_lblItemName"), Label)
                Dim _lblQtyRemaining As Label = CType(gitm.FindControl("_lblQtyRemaining"), Label)
                Dim _txtQtyReceived As TextBox = CType(gitm.FindControl("_txtQtyReceived"), TextBox)
                Dim _lblItemUnitID As Label = CType(gitm.FindControl("_lblItemUnitID"), Label)
                Dim _TxtPrice As TextBox = CType(gitm.FindControl("_TxtPrice"), TextBox)
                Dim _TxtItemFactor As TextBox = CType(gitm.FindControl("_TxtItemFactor"), TextBox)
                Dim _lblPOrdExpiredDate As Label = CType(gitm.FindControl("_lblPOrdExpiredDate"), Label)
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
                    row("IDPO") = Trim(_lblID.Text)
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
                    row("ItemFactor") = CDec(Left(Replace(_TxtItemFactor.Text.Trim, ",", ""), 15).Trim)

                    If Not IsNumeric(_txtQtyReceived.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Qty received must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDbl(_txtQtyReceived.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Qty received must be greater than 0.")
                        GoTo ExitSub
                    End If

                    Dim podt As New BussinessRules.PurchaseOrderDt
                    Dim dt As New DataTable
                    podt.ID = _lblID.Text.Trim
                    dt = podt.ValidateSaveGetItemPO(RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim)
                    If (CDbl(_txtQtyReceived.Text.Trim) * CDbl(_TxtItemFactor.Text.Trim)) > ((CDbl(dt.Rows(0)("Qty")) * CDbl(dt.Rows(0)("ItemFactor"))) - CDbl(dt.Rows(0)("QtyReceived")) - CDbl(dt.Rows(0)("QtyPU"))) Then
                        commonFunction.MsgBox(Me, "[" + _lblPOrdNO.Text.Trim + "] " + _lblItemName.Text.Trim + " Qty received (" + Format((CDbl(_txtQtyReceived.Text.Trim) * CDbl(_TxtItemFactor.Text.Trim)), commonFunction.FORMAT_CURRENCY) + ") must be equal or Less than qty remaining (" + Format(((CDbl(dt.Rows(0)("Qty")) * CDbl(dt.Rows(0)("ItemFactor"))) - CDbl(dt.Rows(0)("QtyReceived")) - CDbl(dt.Rows(0)("QtyPU"))), commonFunction.FORMAT_CURRENCY) + ").")
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
                    row("QtyReceived") = CDec(Left(Replace(_txtQtyReceived.Text.Trim, ",", ""), 15).Trim)

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
                    row("POrdNO") = CType(Trim(_lblPOrdNO.Text.Trim), String)
                    row("IsBonus") = CType(_chkIsBonus.Checked, Boolean)
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                commonFunction.MsgBox(Me, "You have to choose at least one record to be save")
                Exit Sub
            End If

            ' // save header first
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridPO, False)


            If Not _SaveHd() Then
                Exit Sub
            End If

            ' // save the data
            Dim pudt As New BussinessRules.PurchaseUnitDt
            pudt.PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
            pudt.InsertItemPO(tblTmp, MyBase.LoggedOnUserID)
            pudt.Dispose()
            pudt = Nothing

            UpdateViewGridPurchaseUnit()
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("IDPO", System.Type.GetType("System.String"))
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("QtyReceived", System.Type.GetType("System.Double"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Double"))
                .Columns.Add("Price", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Amt", System.Type.GetType("System.Double"))
                .Columns.Add("POrdNO", System.Type.GetType("System.String"))
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
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridPurchaseUnit_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPurchaseUnit.ItemCommand
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
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.PurchaseUnitHd
            With br
                .PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                        PrepareScreenHd()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxPurchaseUnitID.Text = .PUnitNO.Trim
                    End If
                    RadPUnitDate.SelectedDate = .PUnitDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)
                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)
                    txtInvoiceNo.Text = .InvoiceNo.Trim
                    txtDescriptionHd.Text = .Description.Trim
                    txtDiscFinalPct.Text = Format(.DiscFinalPct, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format(.DiscFinalAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridPurchaseUnit()

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
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = False

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False
                        ddlCurrency.Enabled = False
                        RadGridPurchaseUnit.Columns(0).Visible = False
                        RadGridPurchaseUnit.Columns(1).Visible = False

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
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True

                        ddlCurrency.Enabled = True
                        RadGridPurchaseUnit.Columns(0).Visible = True
                        RadGridPurchaseUnit.Columns(1).Visible = True
                    End If

                    RadComboBoxEntitiesID.Enabled = False
                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                    ddlCurrency.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            GetRecordProperties()
            commonFunction.Focus(Me, RadComboBoxEntitiesID.ClientID)
        End Sub

        Private Sub _Opendt(ByVal ID As String)

            Dim br As New BussinessRules.PurchaseUnitDt
            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridPurchaseOrder()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("Item", RadComboBoxItemSeqNo)
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
                commonFunction.MsgBox(Me, "Entities Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlCurrency.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                Exit Function
            End If

            If txtInvoiceNo.Text.Trim = "" Then
                commonFunction.MsgBox(Me, "Invoice No. Cannot Empty.")
                Return False
                Exit Function
            End If

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If RadPUnitDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Purchase Unit Date must be equal or less than today.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.PurchaseUnitHd
            Dim fNew As Boolean = True

            With br
                .PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxPurchaseUnitID.Text = BussinessRules.ID.GenerateIDNumber("purchaseUnithd", "PUnitNO", "PU")
                End If

                '// set the value
                .PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                .PUnitDate = RadPUnitDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(txtPPNpct.Text)
                .DiscFinalPct = CDec(txtDiscFinalPct.Text.Trim)
                .DiscFinalAmt = CDec(txtDiscFinalAmt.Text.Trim)
                .InvoiceNo = txtInvoiceNo.Text.Trim
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


            Dim br As New BussinessRules.PurchaseUnitDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("purchaseUnitdt", "ID")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                .POrdNO = ""
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
                .Description = txtDescriptiondt.Text.Trim
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
            UpdateViewGridPurchaseUnit()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxPurchaseUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseUnitHd
            With br
                .PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.PurchaseUnitDt
                    brdt.PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByPUnitNO()
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

            commonFunction.Focus(Me, RadComboBoxPurchaseUnitID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseUnitDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridPurchaseUnit()
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
                .VisibleButton(CSSToolbarItem.tidOther1) = True
                .lbtnOther1_Text = "Get Item PO"
            End With
        End Sub

        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxPurchaseUnitID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(BussinessRules.TxnType.Receiving)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

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
            ddlCurrency.Enabled = True

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)

            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGridPO, False)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
            Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True


            RadComboBoxPurchaseUnitID.Text = String.Empty
            RadComboBoxPurchaseUnitID.SelectedValue = String.Empty

            RadPUnitDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty
            txtInvoiceNo.Text = String.Empty

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0
            ddlCurrency.SelectedIndex = 0
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
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

            UpdateViewGridPurchaseUnit()
            CalculationGrid()
            GetRecordProperties()
        End Sub

        Private Sub PrepareScreendt()
            txtID.Text = String.Empty
            RadComboBoxItemSeqNo.Text = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
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
            lbtnNewDetail.Enabled = False
            lbtnSaveDetail.Enabled = False
            chkIsBonus.Checked = False
        End Sub

        Private Sub LoadPurchaseUnit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitHd

            dt = br.SelectAllForPUnitNO(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxPurchaseUnitID.DataSource = dt.DefaultView
            RadComboBoxPurchaseUnitID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderHd

            dt = br.SelectAllForEntitiesSeqNo(Filter.Trim, commonFunction.MaxRecord)

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
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) - CDbl(txtDiscFinalAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridPurchaseUnit()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim MaxCurrencyRate As Double = 1
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitDt
            br.PUnitNO = RadComboBoxPurchaseUnitID.Text.Trim
            dt = br.SelectForViewGrid
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                MaxCurrencyRate = CDbl(dtRows(i - 1)("CurrencyRate"))
                Do While i <= dtRows.Length
                    If CDbl(dtRows(i - 1)("CurrencyRate")) > MaxCurrencyRate Then
                        MaxCurrencyRate = CDbl(dtRows(i - 1)("CurrencyRate"))
                    End If
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtCurrencyRate.Text = Format(MaxCurrencyRate, commonFunction.FORMAT_CURRENCY)
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                If CDbl(txtDiscFinalPct.Text.Trim) = 0 Then
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

            RadGridPurchaseUnit.DataSource = dt.DefaultView
            RadGridPurchaseUnit.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPurchaseOrder()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderDt

            dt = br.SelectForViewGridPOForPU(RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim)

            RadGridPurchaseOrder.DataSource = dt.DefaultView
            RadGridPurchaseOrder.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("PUnitNo", RadComboBoxPurchaseUnitID.Text.Trim, "PurchaseUnitHD").Rows.Count > 0 Then
                    lblUserInsert.Text = .UserInsert.Trim
                    lblInsertDate.Text = .InsertDate.ToString.Trim
                    lblUserUpdate.Text = .UserUpdate.Trim
                    lblUpdateDate.Text = .UpdateDate.ToString.Trim
                Else
                    lblUserInsert.Text = "-"
                    lblInsertDate.Text = "-"
                    lblUserUpdate.Text = "-"
                    lblUpdateDate.Text = "-"
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

    End Class
End Namespace