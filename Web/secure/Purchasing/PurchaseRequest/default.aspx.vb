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

    Public Class PurchaseRequest
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "310"

        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'header
        Protected WithEvents RadComboBoxPurchaseRequestNo As RadComboBox
        Protected WithEvents RadPReqDate As RadDatePicker
        Protected WithEvents ddlWH As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnit As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsApproval As System.Web.UI.WebControls.CheckBox

        'detail
        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton

        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents ddlItemUnit As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblItemSUnitName As System.Web.UI.WebControls.Label
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents txtEntityName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionDt As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadGridPurchaseRequest As DataGrid
        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxPurchaseRequestNo.IsCallBack And _
                'Not RadComboBoxItemSeqNo.IsCallBack And _
                'Not RadComboBoxEntitiesID.IsCallBack Then

                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                PrepareScreenHd()

            End If
        End Sub

        Private Sub RadComboBoxPurchaseRequestNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxPurchaseRequestNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadPurchaseRequest(e.Text)
        End Sub

        Private Sub RadComboBoxPurchaseRequestNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxPurchaseRequestNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("PReqNO").ToString()
        End Sub

        Private Sub RadComboBoxPurchaseRequestNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPurchaseRequestNo.SelectedIndexChanged
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
            LoadIDName(RadComboBoxEntitiesID)
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
            commonFunction.LoadDDL(ddlItemUnit, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave, CSSToolbarItem.tidVoid
                    _SaveHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrint
                    If RadComboBoxPurchaseRequestNo.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 3101
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxPurchaseRequestNo.Text.Trim)
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
            PrepareScreenDt()
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _SaveDt()
        End Sub

        Private Sub ddlWH_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWH.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnit, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWH.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
        End Sub

        Private Sub ddlItemUnit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemUnit.SelectedIndexChanged
            Dim ift As New BussinessRules.ItemFactorTemplate
            ift.ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
            ift.ItemUnitID = ddlItemUnit.SelectedValue
            If ift.SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                txtItemFactor.Text = Format(ift.ItemFactor, commonFunction.FORMAT_CURRENCY)
            Else
                txtItemFactor.Text = ""
            End If
            ift.Dispose()
            ift = Nothing
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridPurchaseRequest_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPurchaseRequest.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _OpenDt()

                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _DeleteDt(txtID.Text.Trim)
            End Select
        End Sub

        Private Sub RadGridPurchaseRequest_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridPurchaseRequest.ItemCreated
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

            Dim br As New BussinessRules.PurchaseRequestHd
            With br
                .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        PrepareScreenHd()

                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxPurchaseRequestNo.Text = .PReqNO.Trim
                    End If
                    RadPReqDate.SelectedDate = .PReqDate
                    LoadIDName(RadComboBoxEntitiesID)
                    commonFunction.SelectListItem(ddlWH, .WhID.Trim)
                    ddlWH_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnit, .UnitID.Trim)
                    txtDescription.Text = .Description.Trim

                    UpdateViewGridPurchaseRequest()

                    If .IsApproval Then
                        RadComboBoxItemSeqNo.Enabled = False
                        RadComboBoxEntitiesID.Enabled = False
                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False
                        RadGridPurchaseRequest.Columns(0).Visible = False
                        RadGridPurchaseRequest.Columns(1).Visible = False
                    Else
                        RadComboBoxItemSeqNo.Enabled = True
                        RadComboBoxEntitiesID.Enabled = True
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
                        
                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True

                        RadGridPurchaseRequest.Columns(0).Visible = True
                        RadGridPurchaseRequest.Columns(1).Visible = True
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

            GetRecordProperties()
            'commonFunction.Focus(Me, RadPReqDate.ClientID)
        End Sub

        Private Sub _OpenDt()
            Dim br As New BussinessRules.PurchaseRequestDt
            With br
                .ID = txtID.Text.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridPurchaseRequest()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    LoadIDName(RadComboBoxItemSeqNo)
                    RadComboBoxItemSeqNo_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlItemUnit, .ItemUnitID)
                    txtItemFactor.Text = Format(.ItemFactor, commonFunction.FORMAT_CURRENCY)
                    txtQty.Text = Format(.Qty, commonFunction.FORMAT_CURRENCY)
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    LoadIDName(RadComboBoxEntitiesID)
                    RadComboBoxEntitiesID_SelectedIndexChanged(Nothing, Nothing)
                    txtDescriptionDt.Text = .Description.Trim
                Else
                    PrepareScreenDt()
                End If
            End With

            br.Dispose()
            br = Nothing

            'commonFunction.Focus(Me, RadComboBoxItemSeqNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If Not FApproval Then
                Dim brdt As New BussinessRules.PurchaseOrderDt
                With brdt
                    .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                    If .SelectAllByPReqNO.Rows.Count > 0 Then
                        commonFunction.MsgBox(Me, "This item already ordered.")
                        brdt.Dispose()
                        brdt = Nothing
                        Return False
                        Exit Function
                    End If
                End With
                brdt.Dispose()
                brdt = Nothing
            End If

            Dim br As New BussinessRules.PurchaseRequestHd
            Dim fNew As Boolean = True

            With br
                .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxPurchaseRequestNo.Text = BussinessRules.ID.GenerateIDNumber("PurchaseRequestHd", "PReqNO", "PR")
                End If

                '// set the value
                .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                .PReqDate = RadPReqDate.SelectedDate.Value
                .WhID = ddlWH.SelectedValue.Trim
                .UnitID = ddlUnit.SelectedValue.Trim
                .Description = txtDescription.Text.Trim
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

        Private Sub _SaveDt()
            If Not IsNumeric(txtQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Qty must be numeric.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtQty.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Qty must be greater than 0.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Len(RadComboBoxItemSeqNo.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Name Cannot Empty.")
                Exit Sub
            End If

            If ddlItemUnit.SelectedValue = "none" Then
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

            If RadComboBoxPurchaseRequestNo.Text.Trim.Length = 0 Then If Not _SaveHd() Then Exit Sub

            Dim br As New BussinessRules.PurchaseRequestDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("PurchaseRequestDt", "ID")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnit.SelectedValue.Trim
                .ItemFactor = CDec(txtItemFactor.Text.Trim)
                .Qty = CDec(Left(Replace(txtQty.Text.Trim, ",", ""), 15).Trim)
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .Description = txtDescriptionDt.Text.Trim
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

            PrepareScreenDt()
            UpdateViewGridPurchaseRequest()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxPurchaseRequestNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseRequestHd

            With br
                .PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.PurchaseRequestDt
                    brdt.PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByPReqNO()
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

            'commonFunction.Focus(Me, RadComboBoxPurchaseRequestNo.ClientID)
        End Sub

        Private Sub _DeleteDt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseRequestDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() Then
                        PrepareScreenDt()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If

                UpdateViewGridPurchaseRequest()
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

        Private Sub PrepareScreenHd()
            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWH, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnit, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWH.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True

            RadComboBoxPurchaseRequestNo.Text = String.Empty
            'RadComboBoxPurchaseRequestNo.SelectedItem.Value = String.Empty
            RadComboBoxPurchaseRequestNo.SelectedValue = String.Empty

            RadPReqDate.SelectedDate = Date.Now
            txtDescription.Text = String.Empty

            ddlWH.SelectedIndex = 0
            ddlUnit.SelectedIndex = 0

            commonFunction.ShowPanel(PnlApproved, False)

            PrepareScreenDt()

            UpdateViewGridPurchaseRequest()
            GetRecordProperties()
        End Sub

        Private Sub PrepareScreenDt()
            txtID.Text = String.Empty

            RadComboBoxItemSeqNo.Text = String.Empty
            'RadComboBoxItemSeqNo.SelectedItem.Value = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
            RadComboBoxItemSeqNo.Enabled = True
            txtItemName.Text = String.Empty
            ddlItemUnit.Items.Clear()

            txtItemFactor.Text = "1"
            lblItemSUnitName.Text = String.Empty
            txtQty.Text = "1.00"

            RadComboBoxEntitiesID.Text = String.Empty
            'RadComboBoxEntitiesID.SelectedItem.Value = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            RadComboBoxEntitiesID.Enabled = True
            txtEntityName.Text = String.Empty

            txtDescriptionDt.Text = String.Empty
        End Sub

        Private Sub LoadPurchaseRequest(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseRequestHd

            dt = br.SelectAllForPReqNO(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxPurchaseRequestNo.DataSource = dt.DefaultView
            RadComboBoxPurchaseRequestNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

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

            dt = br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxItemSeqNo.DataSource = dt
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadIDName(ByVal sender As Object)
            Select Case CType(sender, RadComboBox).ID
                Case RadComboBoxEntitiesID.ID
                    If RadComboBoxEntitiesID.SelectedValue.Trim.Length <> 0 Then
                        Dim En As New BussinessRules.Entities
                        With En
                            .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                            If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                                RadComboBoxEntitiesID.Text = .EntitiesID.Trim
                                txtEntityName.Text = .EntitiesName
                            Else
                                RadComboBoxEntitiesID.Text = String.Empty
                                txtEntityName.Text = String.Empty
                            End If
                        End With
                        En.Dispose()
                        En = Nothing
                    Else
                        RadComboBoxEntitiesID.Text = String.Empty
                        txtEntityName.Text = String.Empty
                    End If

                Case RadComboBoxItemSeqNo.ID
                    If RadComboBoxItemSeqNo.SelectedValue.Trim.Length <> 0 Then
                        Dim it As New BussinessRules.Item
                        With it
                            .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                            If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                                RadComboBoxItemSeqNo.Text = .ItemID.Trim
                                txtItemName.Text = .ItemName
                                Dim iu As New BussinessRules.ItemUnit
                                iu.ItemUnitID = .ItemSUnitID.Trim
                                If iu.SelectOne.Rows.Count > 0 Then
                                    lblItemSUnitName.Text = iu.ItemUnitName.Trim
                                Else
                                    lblItemSUnitName.Text = String.Empty
                                End If
                            Else
                                RadComboBoxItemSeqNo.Text = String.Empty
                                txtItemName.Text = String.Empty
                                lblItemSUnitName.Text = String.Empty
                            End If
                        End With
                        it.Dispose()
                        it = Nothing
                    Else
                        RadComboBoxItemSeqNo.Text = String.Empty
                        txtItemName.Text = String.Empty
                        lblItemSUnitName.Text = String.Empty
                    End If
            End Select
        End Sub

        Private Sub UpdateViewGridPurchaseRequest()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseRequestDt
            br.PReqNO = RadComboBoxPurchaseRequestNo.Text.Trim
            dt = br.SelectForViewGrid

            RadGridPurchaseRequest.DataSource = dt.DefaultView
            RadGridPurchaseRequest.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("PReqNo", RadComboBoxPurchaseRequestNo.Text.Trim, "PurchaseRequestHD").Rows.Count > 0 Then
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