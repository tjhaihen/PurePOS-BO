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

    Public Class PurchaseRequestManagement
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "320"

        '// PR Header Filter 
        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList

        '// PO Header
        Protected WithEvents RadPOrdDate As RadDatePicker
        Protected WithEvents RadPOrdExpiredDate As RadDatePicker
        Protected WithEvents RadPOrdDeliveryDate As RadDatePicker

        Protected WithEvents ddlPOrdTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPaymentTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTermOfPayment As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTermOfAgreement As System.Web.UI.WebControls.DropDownList

        Protected WithEvents RadComboBoxEntityID As RadComboBox
        Protected WithEvents txtEntityName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPICName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliverTo As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbtnPOrdNo As System.Web.UI.WebControls.LinkButton
        Protected WithEvents PnlPONo As System.Web.UI.WebControls.Panel

        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadGridPurchaseRequestManagement As System.Web.UI.WebControls.DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxEntityID.IsCallBack Then
                Dim fQueryStringExist As Boolean
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

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
            End Select
        End Sub

        Private Sub RadComboBoxEntityID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntityID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntityID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntityID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesID").ToString()
        End Sub

        Private Sub RadComboBoxEntityID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntityID.SelectedIndexChanged
            LoadIDName(RadComboBoxEntityID)
            If Len(txtEntityName.Text.Trim) > 0 Then
                txtPICName.Text = GetEntitiesPICName(RadComboBoxEntityID.SelectedValue.Trim).Trim
            Else
                txtPICName.Text = String.Empty
            End If
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            LoadDDL(False, True)

            UpdateViewGridPurchaseRequestManagement()
        End Sub

        Private Sub ddlUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnitID.SelectedIndexChanged
            UpdateViewGridPurchaseRequestManagement()
        End Sub

        Private Sub lbtnPOrdNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnPOrdNo.Click
            If lbtnPOrdNo.Text.Trim <> "" Then
                Response.Redirect(MyBase.UrlBase + "/secure/Purchasing/PurchaseOrder/default.aspx?PONo=" + lbtnPOrdNo.Text.Trim)
            End If
        End Sub

#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "

        Private Sub _Save()
            Dim totalRowSelected As Integer = 0
            Dim tblTmpDropped As DataTable = createDroppedTmpTable()
            Dim tblTmpProcess As DataTable = createProcessTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPurchaseRequestManagement.Items
                Dim _lblID As Label = CType(_item.FindControl("_lblID"), Label)

                Dim _DDLStatusID As DropDownList = CType(_item.FindControl("_DDLStatusID"), DropDownList)
                Dim _lblPReqNo As Label = CType(_item.FindControl("_lblPReqNo"), Label)
                Dim _lblItemSeqNo As Label = CType(_item.FindControl("_lblItemSeqNo"), Label)
                Dim _lblItemID As Label = CType(_item.FindControl("_lblItemID"), Label)
                Dim _lblItemName As Label = CType(_item.FindControl("_lblItemName"), Label)

                Dim _txtQty As TextBox = CType(_item.FindControl("_txtQty"), TextBox)
                Dim _lblItemUnitID As Label = CType(_item.FindControl("_lblItemUnitID"), Label)
                Dim _lblItemFactor As Label = CType(_item.FindControl("_lblItemFactor"), Label)

                Dim _txtPrice As TextBox = CType(_item.FindControl("_txtPrice"), TextBox)
                Dim _txtDiscount1pct As TextBox = CType(_item.FindControl("_txtDiscount1pct"), TextBox)
                Dim _txtDiscount2pct As TextBox = CType(_item.FindControl("_txtDiscount2pct"), TextBox)
                Dim _txtDiscount3pct As TextBox = CType(_item.FindControl("_txtDiscount3pct"), TextBox)


                If _DDLStatusID.SelectedValue.Trim = "2" Then
                    Dim row As DataRow = tblTmpDropped.NewRow
                    row("IsDropped") = True
                    row("ID") = _lblID.Text.Trim
                    tblTmpDropped.Rows.Add(row)
                    totalRowSelected += 1
                Else
                    If _DDLStatusID.SelectedValue.Trim = "1" Then

                        If Len(RadComboBoxEntityID.SelectedValue.Trim) = 0 Then
                            commonFunction.MsgBox(Me, "Supplier Name Cannot Empty.")
                            Exit Sub
                        End If

                        If ddlPaymentTypeID.SelectedValue.Trim = "none" Then
                            commonFunction.MsgBox(Me, "Payment Type Cannot Empty.")
                            Exit Sub
                        End If

                        If RadPOrdExpiredDate.SelectedDate.Value < RadPOrdDate.SelectedDate.Value Then
                            commonFunction.MsgBox(Me, "PO Due Date must be equal or greater than PO Date.")
                            Exit Sub
                        End If

                        If RadPOrdDeliveryDate.SelectedDate.Value < RadPOrdDate.SelectedDate.Value Then
                            commonFunction.MsgBox(Me, "Delivery Date must be equal or greater than PO Date.")
                            Exit Sub
                        End If

                        If RadPOrdDate.SelectedDate.Value < Date.Today Then
                            commonFunction.MsgBox(Me, "PO Date must be equal or greater than today.")
                            Exit Sub
                        End If

                        If RadPOrdExpiredDate.SelectedDate.Value < Date.Today Then
                            commonFunction.MsgBox(Me, "PO Due Date must be equal or greater than today.")
                            Exit Sub
                        End If

                        If RadPOrdDeliveryDate.SelectedDate.Value < Date.Today Then
                            commonFunction.MsgBox(Me, "Delivery Date must be equal or greater than today.")
                            Exit Sub
                        End If

                        If IsNumeric(txtCurrencyRate.Text.Trim) = False Then
                            commonFunction.MsgBox(Me, "Currency Rate must be numeric.")
                            Exit Sub
                        End If

                        If CDec(txtCurrencyRate.Text.Trim) <= 0 Then
                            commonFunction.MsgBox(Me, "Currency Rate must be greater than 0.")
                            Exit Sub
                        End If

                        Dim br As New BussinessRules.PurchaseRequestDt
                        With br
                            .ID = _lblID.Text.Trim
                            If .SelectOne.Rows.Count > 0 Then
                                If .IsProcess = True Then
                                    commonFunction.MsgBox(Me, .PReqNO.Trim + " [" + _lblItemID.Text.Trim + "] " + _lblItemName.Text.Trim + " is already process ")
                                    br.Dispose()
                                    br = Nothing
                                    Exit Sub
                                End If
                            End If
                        End With
                        br.Dispose()
                        br = Nothing

                        Dim row As DataRow = tblTmpProcess.NewRow
                        row("IsProcess") = True
                        row("ID") = _lblID.Text.Trim
                        row("PReqNo") = _lblPReqNo.Text.Trim
                        row("EntitiesSeqNo") = RadComboBoxEntityID.SelectedValue.Trim
                        row("ItemSeqNo") = _lblItemSeqNo.Text.Trim

                        If Not IsNumeric(_txtQty.Text.Trim) Then
                            commonFunction.MsgBox(Me, "Qty must be numeric.")
                            Exit Sub
                        End If

                        If CDec(_txtQty.Text.Trim) <= 0 Then
                            commonFunction.MsgBox(Me, "Qty must be greater than 0.")
                            Exit Sub
                        End If
                        row("Qty") = CDec(_txtQty.Text.Trim)
                        row("ItemUnitID") = _lblItemUnitID.Text.Trim
                        row("ItemFactor") = CDec(_lblItemFactor.Text.Trim)

                        If Not IsNumeric(_txtPrice.Text.Trim) Then
                            commonFunction.MsgBox(Me, "Price must be numeric.")
                            Exit Sub
                        End If

                        If CDec(_txtPrice.Text.Trim) < 0 Then
                            commonFunction.MsgBox(Me, "Price must be equal or greater than 0.")
                            Exit Sub
                        End If
                        row("Price") = _txtPrice.Text.Trim

                        If Not IsNumeric(_txtDiscount1pct.Text) Then
                            commonFunction.MsgBox(Me, "Discount 1 ( % ) must be numeric")
                            Exit Sub
                        End If
                        If CDec(_txtDiscount1pct.Text.Trim) < 0 OrElse CDec(_txtDiscount1pct.Text.Trim) > 100 Then
                            commonFunction.MsgBox(Me, "Discount 1 ( % ) must be 0% - 100%.")
                            Exit Sub
                        End If
                        row("Discount1Pct") = _txtDiscount1pct.Text.Trim
                        row("Discount1Amt") = CDec(row("Price")) * CDec(_txtDiscount1pct.Text.Trim) / 100

                        If Not IsNumeric(_txtDiscount2pct.Text) Then
                            commonFunction.MsgBox(Me, "Discount 2 ( % ) must be numeric")
                            Exit Sub
                        End If
                        If CDec(_txtDiscount2pct.Text.Trim) < 0 OrElse CDec(_txtDiscount2pct.Text.Trim) > 100 Then
                            commonFunction.MsgBox(Me, "Discount 2 ( % ) must be 0% - 100%.")
                            Exit Sub
                        End If
                        row("Discount2Pct") = _txtDiscount2pct.Text.Trim
                        row("Discount2Amt") = (CDec(row("Price")) - CDec(row("Discount1Amt"))) * CDec(_txtDiscount2pct.Text.Trim) / 100

                        If Not IsNumeric(_txtDiscount3pct.Text) Then
                            commonFunction.MsgBox(Me, "Discount 3 ( % ) must be numeric")
                            Exit Sub
                        End If
                        If CDec(_txtDiscount3pct.Text.Trim) < 0 OrElse CDec(_txtDiscount3pct.Text.Trim) > 100 Then
                            commonFunction.MsgBox(Me, "Discount 3 ( % ) must be 0% - 100%.")
                            Exit Sub
                        End If
                        row("Discount3Pct") = _txtDiscount3pct.Text.Trim
                        row("Discount3Amt") = (CDec(row("Price")) - CDec(row("Discount1Amt")) - CDec(row("Discount2Amt"))) * CDec(_txtDiscount3pct.Text.Trim) / 100
                        tblTmpProcess.Rows.Add(row)
                        totalRowSelected += 1
                    End If
                End If
            Next

            If totalRowSelected > 0 Then
                '// Drop Purchase Request(s)
                If tblTmpDropped.Rows.Count > 0 Then
                    Dim br As New BussinessRules.PurchaseRequestDt
                    With br
                        If br.UpdateStatusDropped(tblTmpDropped, MyBase.LoggedOnUserID.Trim) Then UpdateViewGridPurchaseRequestManagement()
                    End With
                    br.Dispose()
                    br = Nothing
                End If

                '// Process Purchase Request(s) to Purchase Order
                If tblTmpProcess.Rows.Count > 0 Then
                    Dim br As New BussinessRules.PurchaseOrderDt
                    With br
                        lbtnPOrdNo.Text = .ProcessPRtoPO(tblTmpProcess, ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim, txtPICName.Text.Trim, _
                                           ddlPOrdTypeID.SelectedValue.Trim, ddlPaymentTypeID.SelectedValue.Trim, ddlTermOfPayment.SelectedValue.Trim, _
                                           RadPOrdDate.SelectedDate.Value, RadPOrdExpiredDate.SelectedDate.Value, RadPOrdDeliveryDate.SelectedDate.Value, _
                                           ddlTermOfAgreement.SelectedValue.Trim, txtDeliverTo.Text.Trim, ddlCurrency.SelectedValue.Trim, txtCurrencyRate.Text.Trim, MyBase.LoggedOnUserID.Trim)
                    End With
                    br.Dispose()
                    br = Nothing
                    commonFunction.ShowPanel(PnlPONo, True)
                End If
                UpdateViewGridPurchaseRequestManagement()
            Else
                commonFunction.MsgBox(Me, "You must choose at least one record to be Processed or Dropped.")
                Exit Sub
            End If
        End Sub

        Private Function createDroppedTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("IsDropped", System.Type.GetType("System.Boolean"))
                .Columns.Add("ID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Function createProcessTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("IsProcess", System.Type.GetType("System.Boolean"))
                .Columns.Add("ID", System.Type.GetType("System.String"))
                .Columns.Add("PReqNo", System.Type.GetType("System.String"))
                .Columns.Add("EntitiesSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("Qty", System.Type.GetType("System.Decimal"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Decimal"))
                .Columns.Add("Price", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount1Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount1Amt", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount2Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount2Amt", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount3Pct", System.Type.GetType("System.Decimal"))
                .Columns.Add("Discount3Amt", System.Type.GetType("System.Decimal"))
            End With

            Return tbl
        End Function

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
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            ddlWhID.Items.Clear()
            ddlUnitID.Items.Clear()

            '// PO Header
            commonFunction.LoadDDLCommonSetting("POrdType", ddlPOrdTypeID)
            commonFunction.LoadDDLCommonSetting("POPaymentType", ddlPaymentTypeID)
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            commonFunction.LoadDDLCommonSetting("TermOfPayment", ddlTermOfPayment)
            commonFunction.LoadDDLCommonSetting("TermOfAgreement", ddlTermOfAgreement)

            RadComboBoxEntityID.Text = String.Empty
            RadComboBoxEntityID.SelectedValue = String.Empty
            txtEntityName.Text = String.Empty
            txtPICName.Text = String.Empty
            RadPOrdDate.SelectedDate = Date.Now
            RadPOrdExpiredDate.SelectedDate = Date.Now
            RadPOrdDeliveryDate.SelectedDate = Date.Now
            ddlPOrdTypeID.SelectedIndex = 0
            ddlPaymentTypeID.SelectedIndex = 0
            ddlTermOfPayment.SelectedIndex = 0
            ddlTermOfAgreement.SelectedIndex = 0
            ddlCurrency.SelectedIndex = 0
            txtCurrencyRate.Text = "1.00"
            txtDescriptionHd.Text = String.Empty
            txtDeliverTo.Text = String.Empty

            lbtnPOrdNo.Text = ""

            commonFunction.ShowPanel(PnlPONo, False)

            LoadDDL(True, True)

            UpdateViewGridPurchaseRequestManagement()
        End Sub

        Private Sub LoadDDL(ByVal IsLoadWh As Boolean, ByVal IsLoadUnit As Boolean)
            If IsLoadWh = True Then
                Dim wh As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, False)
                wh.Dispose()
                wh = Nothing
            End If

            If ddlWhID.SelectedValue <> Nothing And IsLoadUnit = True Then
                Dim whunit As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
                whunit.Dispose()
                whunit = Nothing
            End If
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            dt = br.SelectAllForEntitiesSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntityID.DataSource = dt.DefaultView
            RadComboBoxEntityID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadIDName(ByVal sender As Object)
            Select Case CType(sender, RadComboBox).ID
                Case RadComboBoxEntityID.ID
                    If RadComboBoxEntityID.SelectedValue.Trim.Length <> 0 Then
                        Dim En As New BussinessRules.Entities
                        With En
                            .EntitiesSeqNo = RadComboBoxEntityID.SelectedValue.Trim
                            If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                                RadComboBoxEntityID.Text = .EntitiesID.Trim
                                txtEntityName.Text = .EntitiesName
                            Else
                                RadComboBoxEntityID.SelectedValue = String.Empty
                                RadComboBoxEntityID.Text = String.Empty
                                txtEntityName.Text = String.Empty
                            End If
                        End With
                        En.Dispose()
                        En = Nothing
                    Else
                        RadComboBoxEntityID.SelectedValue = String.Empty
                        RadComboBoxEntityID.Text = String.Empty
                        txtEntityName.Text = String.Empty
                    End If
            End Select
        End Sub

        Private Function GetEntitiesPICName(ByVal EntitiesSeqNo As String) As String
            Dim strPICName As String = String.Empty
            Dim br As New BussinessRules.EntitiesContact

            With br
                .EntitiesSeqNo = EntitiesSeqNo.Trim
                If .SelectOneByEntitiesSeqNo.Rows.Count > 0 Then
                    strPICName = .FullName.Trim
                Else
                    strPICName = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing

            Return strPICName.Trim
        End Function

        Private Sub UpdateViewGridPurchaseRequestManagement()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseRequestDt

            dt = br.SelectForViewGridPRManagement(ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim)
            dt.Columns.Add("Price", GetType(System.Double))
            dt.Columns.Add("Discount1pct", GetType(System.Double))
            '         dt.Columns.Add("Discount1amt", GetType(System.Double))
            dt.Columns.Add("Discount2pct", GetType(System.Double))
            '        dt.Columns.Add("Discount2amt", GetType(System.Double))
            dt.Columns.Add("Discount3pct", GetType(System.Double))
            '       dt.Columns.Add("Discount3amt", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    Dim oprice As BussinessRules.Price
                    oprice = BussinessRules.Functions.GetPriceItemPO(ddlCurrency.SelectedValue.Trim, CStr(dtRows(i - 1)("ItemSeqNo")).Trim, CStr(dtRows(i - 1)("ItemUnitID")).Trim)
                    dtRows(i - 1)("Price") = oprice.price
                    dtRows(i - 1)("discount1pct") = oprice.discount1pct
                    '                    dtRows(i - 1)("discount1amt") = oprice.discount1amt
                    dtRows(i - 1)("discount2pct") = oprice.discount2pct
                    '                   dtRows(i - 1)("discount2amt") = oprice.discount2amt
                    dtRows(i - 1)("discount3pct") = oprice.discount3pct
                    '                  dtRows(i - 1)("discount3amt") = oprice.discount3amt
                    oprice = Nothing
                    i += 1
                Loop
            Else
            End If

            RadGridPurchaseRequestManagement.DataSource = dt.DefaultView
            RadGridPurchaseRequestManagement.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace