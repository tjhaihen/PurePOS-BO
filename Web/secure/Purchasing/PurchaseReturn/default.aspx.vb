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

    Public Class PurchaseReturn
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "360"

        'header
        Protected WithEvents RadPurchaseReturnDate As RadDatePicker

        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxPurchaseReturnID As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        Protected WithEvents ddlReason As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeePct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeeAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

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
        Protected WithEvents txtReturnFeePctdt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtReturnFeeAmtdt As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtDescriptiondt As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton


        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPurchaseReturnID As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemID As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemFactorCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridPurchaseReturn As DataGrid
        'Protected WithEvents RadGridPurchaseUnit As RadGrid

        'link
        Protected WithEvents lbtnCancelGetItemPU As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveGetItemPU As System.Web.UI.WebControls.LinkButton

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelDetail As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel

        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxPurchaseReturnID.IsCallBack And _
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

        Private Sub RadComboBoxPurchaseReturnID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxPurchaseReturnID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadPurchaseReturn(e.Text)
        End Sub

        Private Sub RadComboBoxPurchaseReturnID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxPurchaseReturnID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("PReturnNO").ToString()
        End Sub

        Private Sub RadComboBoxPurchaseReturnID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPurchaseReturnID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
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
                    If RadComboBoxPurchaseReturnID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 3601
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxPurchaseReturnID.Text.Trim)
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
            loadprice()
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
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            loadprice()
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDbl(txtPPNpct.Text.Trim) * (CDbl(txtTotal.Text.Trim) - CDbl(txtReturnFeeAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            CalculationGrid()
        End Sub

        Private Sub txtReturnFeePct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReturnFeePct.TextChanged
            If Not IsNumeric(txtReturnFeePct.Text) Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) must be numeric")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtReturnFeePct.Text.Trim) < 0 OrElse CDec(txtReturnFeePct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) Must Be 0% - 100%.")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtReturnFeePct.Text = Format(CDbl(txtReturnFeePct.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtReturnFeeAmt.Text = Format((CDbl(txtReturnFeePct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
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
            txtReturnFeeAmt.Text = Format(CDbl(txtReturnFeeAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
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
                txtDisc1Amt.Text = Format(CDbl(txtDisc1Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc1Amt.Text.Trim) > CDbl(txtPrice.Text.Trim) Then
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
                txtDisc2Amt.Text = Format((CDbl(txtDisc2Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
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
                txtDisc2Amt.Text = Format(CDbl(txtDisc2Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
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
                txtDisc3Amt.Text = Format((CDbl(txtDisc3Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
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
                txtDisc3Amt.Text = Format(CDbl(txtDisc3Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
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
                txtReturnFeeAmtdt.Text = Format((CDbl(txtReturnFeePctdt.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim) - CDbl(txtDisc3Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtReturnFeeAmtdt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim) - CDbl(txtDisc3Amt.Text.Trim)) Then
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
                txtReturnFeeAmtdt.Text = Format(CDbl(txtReturnFeeAmtdt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtReturnFeeAmtdt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
                    txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub lbtnCancelGetItemPU_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCancelGetItemPU.Click
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PanelGrid, True)

        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridPurchaseReturn_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPurchaseReturn.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Opendt(txtID.Text.Trim)
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _Deletedt(txtID.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridPurchaseReturn_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridPurchaseReturn.ItemCreated
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

            Dim br As New BussinessRules.PurchaseReturnHd
            With br
                .PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    'If .IsDeleted Then
                    '    'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                    '    PrepareScreenHd()
                    '    br.Dispose()
                    '    br = Nothing
                    '    Exit Sub
                    'End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxPurchaseReturnID.Text = .PReturnNO.Trim
                    End If
                    RadPurchaseReturnDate.SelectedDate = .PReturnDate
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)

                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)

                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)

                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)

                    commonFunction.SelectListItem(ddlReason, .PReturnReasonID.Trim)
                    txtDescriptionHd.Text = .Description.Trim
                    txtReturnFeePct.Text = Format(.ReturnFeePct, commonFunction.FORMAT_CURRENCY)
                    txtReturnFeeAmt.Text = Format(.ReturnFeeAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridPurchaseReturn()
                    If .IsApproval Then
                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False

                        RadGridPurchaseReturn.Columns(0).Visible = False
                        RadGridPurchaseReturn.Columns(1).Visible = False

                        RadComboBoxEntitiesID.Enabled = False
                        ddlCurrency.Enabled = False

                        chkIsPPN.Enabled = False
                        txtReturnFeePct.ReadOnly = True
                        txtReturnFeeAmt.ReadOnly = True
                    Else
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        RadGridPurchaseReturn.Columns(0).Visible = True
                        RadGridPurchaseReturn.Columns(1).Visible = True

                        RadComboBoxEntitiesID.Enabled = True
                        ddlCurrency.Enabled = True

                        chkIsPPN.Enabled = True
                        txtReturnFeePct.ReadOnly = False
                        txtReturnFeeAmt.ReadOnly = False

                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True
                    End If

                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            InitialVariableTmp()
            GetRecordProperties()
            commonFunction.Focus(Me, RadComboBoxPurchaseReturnID.ClientID)
        End Sub

        Private Sub _Opendt(ByVal ID As String)

            Dim br As New BussinessRules.PurchaseReturnDt
            With br
                .ID = ID
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
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

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If ddlWhID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Warehouse Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlUnitID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Unit Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlCurrency.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlReason.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Reason Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadComboBoxEntitiesID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Entities Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadPurchaseReturnDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Purchase Return Date must be equal or less than today.")
                Return False
                Exit Function
            End If

            If Not IsNumeric(txtReturnFeePct.Text) Then
                commonFunction.MsgBox(Me, "Return Fee ( % ) must be numeric")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Function
            End If
            If CDec(txtReturnFeePct.Text.Trim) < 0 OrElse CDec(txtReturnFeePct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Return Fee ( % ) must be between 0% - 100%.")
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Function
            End If

            If Not IsNumeric(txtReturnFeeAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Return Fee must be numeric.")
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Function
            End If
            If CDec(txtReturnFeeAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Return Fee must be equal or greater than 0.")
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Function
            End If

            Dim br As New BussinessRules.PurchaseReturnHd
            Dim fNew As Boolean = True

            With br
                .PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxPurchaseReturnID.Text = BussinessRules.ID.GenerateIDNumber("PurchaseReturnhd", "PReturnNO", "PR")
                End If

                '// set the value
                .PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
                .PReturnDate = RadPurchaseReturnDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(txtPPNpct.Text.Trim)
                .ReturnFeePct = CDec(Left(Replace(txtReturnFeePct.Text.Trim, ",", ""), 16).Trim)
                .ReturnFeeAmt = CDec(Left(Replace(txtReturnFeeAmt.Text.Trim, ",", ""), 16).Trim)
                .PReturnReasonID = ddlReason.SelectedValue.Trim
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
                commonFunction.MsgBox(Me, "Discount 1 ( % ) must be beetwen 0% - 100%.")
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
                commonFunction.MsgBox(Me, "Discount 2 ( % ) must be beetwen 0% - 100%.")
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
                commonFunction.MsgBox(Me, "Discount 3 ( % ) must be beetwen 0% - 100%.")
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

            If Not IsNumeric(txtReturnFeePctdt.Text) Then
                commonFunction.MsgBox(Me, "Return Fee ( % ) must be numeric")
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtReturnFeePctdt.Text.Trim) < 0 OrElse CDec(txtReturnFeePctdt.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Return Fee ( % ) must be between 0% - 100%.")
                txtReturnFeePctdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtReturnFeeAmtdt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Return Fee must be numeric.")
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtReturnFeeAmtdt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Return Fee must be equal or greater than 0.")
                txtReturnFeeAmtdt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Len(RadComboBoxItemSeqNo.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Name Cannot Empty.")
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


            Dim br As New BussinessRules.PurchaseReturnDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("PurchaseReturndt", "ID", "PR")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
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
            UpdateViewGridPurchaseReturn()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxPurchaseReturnID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseReturnHd
            With br
                .PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.PurchaseReturnDt
                    brdt.PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByTxnNo()
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

            commonFunction.Focus(Me, RadComboBoxPurchaseReturnID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseReturnDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridPurchaseReturn()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
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
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxPurchaseReturnID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(TxnType.PurchaseReturn)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            SourceWhIDTmp = String.Empty
            SourceUnitIDTmp = String.Empty

            RadComboBoxEntitiesID.Enabled = True
            ddlWhID.Enabled = True
            ddlUnitID.Enabled = True
            ddlCurrency.Enabled = True
            ddlReason.Enabled = True

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            commonFunction.LoadDDLCommonSetting("PReturnReason", ddlReason, False)

            Dim Swh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", Swh.SelectAllWarehouse, False)
            Swh.Dispose()
            Swh = Nothing

            Dim Swhunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", Swhunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            Swhunit.Dispose()
            Swhunit = Nothing

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelDetail, True)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
            
            RadComboBoxPurchaseReturnID.Text = String.Empty
            RadComboBoxPurchaseReturnID.SelectedValue = String.Empty

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            RadPurchaseReturnDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            chkIsPPN.Enabled = False
            chkIsPPN.Checked = False
            commonFunction.GetTaxPct(txtPPNpct)

            txtReturnFeePct.ReadOnly = False
            txtReturnFeeAmt.ReadOnly = False

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0
            ddlCurrency.SelectedIndex = 0
            ddlReason.SelectedIndex = 0

            commonFunction.ShowPanel(PnlApproved, False)

            txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)
            PrepareScreendt()

            UpdateViewGridPurchaseReturn()
            CalculationGrid()
            GetRecordProperties()
        End Sub

        Private Sub PrepareScreendt()
            InitialVariableTmp()
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

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True
        End Sub

        Private Sub LoadPurchaseReturn(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseReturnHd

            dt = br.SelectAllForPReturnNO(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxPurchaseReturnID.DataSource = dt.DefaultView
            RadComboBoxPurchaseReturnID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseReturnHd

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
            Dim br As New BussinessRules.ItemBalance

            br.WhID = SourceWhIDTmp
            br.UnitID = SourceUnitIDTmp
            dt = br.SelectAllByWhIDUnitIDForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxItemSeqNo.DataSource = dt.DefaultView
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPurchaseReturn()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseReturnDt
            br.PReturnNO = RadComboBoxPurchaseReturnID.Text.Trim
            dt = br.SelectForViewGrid()

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt")) - CDbl(dtRows(i - 1)("ReturnFeeAmt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If

            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                If CDbl(txtReturnFeePct.Text.Trim) = 0 Then
                    txtReturnFeeAmt_TextChanged(Nothing, Nothing)
                Else
                    txtReturnFeePct_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtReturnFeePct.ReadOnly = False
                txtReturnFeeAmt.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtReturnFeePct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeeAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtReturnFeePct.ReadOnly = True
                txtReturnFeeAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridPurchaseReturn.DataSource = dt.DefaultView
            RadGridPurchaseReturn.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) - CDbl(txtReturnFeeAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub loadprice()
            Dim oPrice As BussinessRules.Price
            oPrice = BussinessRules.Functions.GetPriceItemPO(ddlCurrency.SelectedValue.Trim, RadComboBoxItemSeqNo.SelectedValue.Trim, ddlItemUnitID.SelectedValue.Trim)
            txtPrice.Text = Format(oPrice.price, commonFunction.FORMAT_CURRENCY)
            txtDisc1Pct.Text = Format(oPrice.discount1pct, commonFunction.FORMAT_CURRENCY)
            txtDisc1Amt.Text = Format(oPrice.discount1amt, commonFunction.FORMAT_CURRENCY)
            txtDisc2Pct.Text = Format(oPrice.discount2pct, commonFunction.FORMAT_CURRENCY)
            txtDisc2Amt.Text = Format(oPrice.discount2amt, commonFunction.FORMAT_CURRENCY)
            txtDisc3Pct.Text = Format(oPrice.discount3pct, commonFunction.FORMAT_CURRENCY)
            txtDisc3Amt.Text = Format(oPrice.discount3amt, commonFunction.FORMAT_CURRENCY)
            oPrice = Nothing
        End Sub

        Private Sub InitialVariableTmp()
            SourceWhIDTmp = ddlWhID.SelectedValue.Trim
            SourceUnitIDTmp = ddlUnitID.SelectedValue.Trim
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("PReturnNo", RadComboBoxPurchaseReturnID.Text.Trim, "PurchaseReturnHD").Rows.Count > 0 Then
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