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


Namespace Raven.Web.Secure.Inventory

    Public Class Mutation
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "410"

        'header
        Protected WithEvents RadMutationDate As RadDatePicker

        Protected WithEvents lblSourceWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSourceUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents ddlSourceWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlSourceUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlDestinationWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDestinationUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents ddlInventoryTxnID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents RadComboBoxMutationID As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        Protected WithEvents PanelADJUST As System.Web.UI.WebControls.Panel
        Protected WithEvents ddlReason As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox

        'detail

        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtOperandType As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton


        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMutationID As System.Web.UI.WebControls.Label

        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemID As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemFactorCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridMutation As DataGrid

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelDetail As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelWHIDST As System.Web.UI.WebControls.Panel

        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'And Not RadComboBoxMutationID.IsCallBack And Not RadComboBoxItemSeqNo.IsCallBack Then
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

        Private Sub RadComboBoxMutationID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxMutationID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadMutation(e.Text)
        End Sub

        Private Sub RadComboBoxMutationID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxMutationID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("TxnNo").ToString()
        End Sub

        Private Sub RadComboBoxMutationID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMutationID.SelectedIndexChanged
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
                    PrepareScreenHd(True)
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
                    If RadComboBoxMutationID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 4101
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxMutationID.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
                Case CSSToolbarItem.tidOther1
                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelDetail, False)
                    commonFunction.ShowPanel(PanelGrid, False)
            End Select
        End Sub

        Private Sub lbtnNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewDetail.Click
            PrepareScreendt()
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _Savedt()
        End Sub

        Private Sub ddlSourceWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSourceWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlSourceUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlSourceWhID.SelectedValue.Trim), True)
            whunit.Dispose()
            whunit = Nothing
            SourceWhIDTmp = ddlSourceWhID.SelectedValue.Trim
            SourceUnitIDTmp = ddlSourceUnitID.SelectedValue.Trim
        End Sub

        Private Sub ddlSourceUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSourceUnitID.SelectedIndexChanged
            SourceWhIDTmp = ddlSourceWhID.SelectedValue.Trim
            SourceUnitIDTmp = ddlSourceUnitID.SelectedValue.Trim
        End Sub

        Private Sub ddlDestinationWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDestinationWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlDestinationUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlDestinationWhID.SelectedValue.Trim), True)
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

        Private Sub ddlInventoryTxnID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInventoryTxnID.SelectedIndexChanged
            Select Case ddlInventoryTxnID.SelectedValue.Trim
                Case CStr(BussinessRules.TxnType.Distribution)
                    commonFunction.ShowPanel(PanelADJUST, False)
                    commonFunction.ShowPanel(PanelWHIDST, True)
                    lblSourceWhIDCaption.Text = "Source Warehouse Name"
                    lblSourceUnitIDCaption.Text = "Source Unit Name"
                    ddlReason.SelectedIndex = 0

                Case CStr(BussinessRules.TxnType.AdjustmentPlus), CStr(BussinessRules.TxnType.AdjustmentMinus)
                    commonFunction.ShowPanel(PanelADJUST, True)
                    commonFunction.ShowPanel(PanelWHIDST, False)
                    lblSourceWhIDCaption.Text = "Warehouse Name"
                    lblSourceUnitIDCaption.Text = "Unit Name"

                Case Else
                    commonFunction.ShowPanel(PanelWHIDST, False)
                    lblSourceWhIDCaption.Text = "Warehouse Name"
                    lblSourceUnitIDCaption.Text = "Unit Name"
                    ddlReason.SelectedIndex = 0
            End Select

            GetOperandType()

            InitialVariableTmp()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridMutation_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridMutation.ItemCommand
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

        Private Sub RadGridMutation_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridMutation.ItemCreated
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

            Dim br As New BussinessRules.MutationHd
            With br
                .TxnNo = RadComboBoxMutationID.Text.Trim
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    'If .IsDeleted Then
                    '    'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                    '    PrepareScreenHd()
                    '    br.Dispose()
                    '    br = Nothing
                    '    Exit Sub
                    'End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxMutationID.Text = .TxnNo.Trim
                    End If
                    commonFunction.SelectListItem(ddlInventoryTxnID, .InventoryTxnID.Trim)
                    ddlInventoryTxnID_SelectedIndexChanged(Nothing, Nothing)
                    RadMutationDate.SelectedDate = .TxnDate
                    commonFunction.SelectListItem(ddlSourceWhID, .SourceWHID.Trim)

                    ddlSourceWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlSourceUnitID, .SourceUnitID.Trim)

                    commonFunction.SelectListItem(ddlDestinationWhID, .DestinationWHID.Trim)
                    ddlDestinationWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlDestinationUnitID, .DestinationUnitID.Trim)
                    commonFunction.SelectListItem(ddlReason, .AdjustmentReasonID.Trim)
                    txtDescriptionHd.Text = .Description.Trim
                    UpdateViewGridMutation()

                    If .IsApproval Then

                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False

                        RadGridMutation.Columns(0).Visible = False
                        RadGridMutation.Columns(1).Visible = False
                    Else
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True

                        RadGridMutation.Columns(0).Visible = True
                        RadGridMutation.Columns(1).Visible = True
                    End If

                    ddlInventoryTxnID.Enabled = False
                    ddlSourceWhID.Enabled = False
                    ddlSourceUnitID.Enabled = False
                    ddlDestinationWhID.Enabled = False
                    ddlDestinationUnitID.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            GetRecordProperties()
            InitialVariableTmp()
            commonFunction.Focus(Me, ddlInventoryTxnID.ClientID)
        End Sub

        Private Sub _Opendt(ByVal ID As String)

            Dim br As New BussinessRules.MutationDt
            With br
                .ID = ID
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
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
                    txtQty.Text = Format(.Qty, commonFunction.FORMAT_QTY)
                    txtOperandType.Text = .PlusOrMinus.Trim
                Else
                    PrepareScreendt()
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxItemSeqNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If ddlSourceWhID.SelectedValue.Trim = "none" Then
                If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.Distribution) Then
                    commonFunction.MsgBox(Me, "Source Warehouse Name Cannot Empty.")
                Else
                    commonFunction.MsgBox(Me, "Warehouse Name Cannot Empty.")
                End If
                Return False
                Exit Function
            End If

            If ddlSourceUnitID.SelectedValue.Trim = "none" Then
                If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.Distribution) Then
                    commonFunction.MsgBox(Me, "Source Unit Name Cannot Empty.")
                Else
                    commonFunction.MsgBox(Me, "Unit Name Cannot Empty.")
                End If
                Return False
                Exit Function
            End If

            If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.Distribution) Then
                If ddlDestinationWhID.SelectedValue.Trim = "none" Then
                    commonFunction.MsgBox(Me, "Destination Warehouse Name Cannot Empty.")
                    Return False
                    Exit Function
                End If

                If ddlDestinationUnitID.SelectedValue.Trim = "none" Then
                    commonFunction.MsgBox(Me, "Destination Unit Name Cannot Empty.")
                    Return False
                    Exit Function
                End If
            End If

            If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentPlus) Or ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentMinus) Then
                If ddlReason.SelectedValue.Trim = "none" Then
                    commonFunction.MsgBox(Me, "Reason Cannot Empty.")
                    Return False
                    Exit Function
                End If
            End If

            Dim br As New BussinessRules.MutationHd
            Dim fNew As Boolean = True

            With br
                .TxnNo = RadComboBoxMutationID.Text.Trim
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxMutationID.Text = BussinessRules.ID.GenerateIDNumber("Mutationhd", "TxnNo", _
                    GetPrefixIDNumber(ddlInventoryTxnID.SelectedValue.Trim, True), _
                    "Where InventoryTxnID = '" + ddlInventoryTxnID.SelectedValue.Trim + "'")
                End If

                '// set the value
                .TxnNo = RadComboBoxMutationID.Text.Trim
                .TxnDate = RadMutationDate.SelectedDate.Value
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                .SourceWHID = ddlSourceWhID.SelectedValue.Trim
                .SourceUnitID = ddlSourceUnitID.SelectedValue.Trim
                .DestinationWHID = ddlDestinationWhID.SelectedValue.Trim
                .DestinationUnitID = ddlDestinationUnitID.SelectedValue.Trim
                .AdjustmentReasonID = ddlReason.SelectedValue.Trim
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
                txtQty.Text = Format(1, commonFunction.FORMAT_QTY)
                Exit Sub
            End If

            If ddlInventoryTxnID.SelectedValue.Trim <> CStr(BussinessRules.TxnType.BeginningBalance) Then
                If CDbl(txtQty.Text.Trim) <= 0 Then
                    commonFunction.MsgBox(Me, "Qty must be greater than 0.")
                    txtQty.Text = Format(1, commonFunction.FORMAT_QTY)
                    Exit Sub
                End If
            Else
                If CDbl(txtQty.Text.Trim) < 0 Then
                    commonFunction.MsgBox(Me, "Qty must be equal or greater than 0.")
                    Exit Sub
                End If
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

            If Len(txtOperandType.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Operand Type not set, this Transaction Type is not ready for use.")
                Exit Sub
            End If

            If Not _SaveHd() Then
                Exit Sub
            End If

            Dim br As New BussinessRules.MutationDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentPlus) Or ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentMinus) Or ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.BeginningBalance) Then
                        Dim mtdt As New BussinessRules.MutationDt
                        mtdt.TxnNo = RadComboBoxMutationID.Text.Trim
                        Dim dv As New DataView(mtdt.SelectAllByTxnNo)
                        dv.RowFilter = "ItemSeqNo = '" + RadComboBoxItemSeqNo.SelectedValue.Trim + "'"
                        If dv.Count > 0 Then
                            commonFunction.MsgBox(Me, "Item is already exsist.")
                            dv.Dispose()
                            dv = Nothing
                            mtdt.Dispose()
                            mtdt = Nothing
                            Exit Sub
                        End If
                        dv.Dispose()
                        dv = Nothing
                        mtdt.Dispose()
                        mtdt = Nothing
                    End If

                    txtID.Text = BussinessRules.ID.GenerateIDNumber("Mutationdt", "ID", GetPrefixIDNumber(ddlInventoryTxnID.SelectedValue.Trim), _
                    "Where TxnNo in (SELECT TxnNo FROM Mutationhd WHERE InventoryTxnID = '" + ddlInventoryTxnID.SelectedValue.Trim + "')")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .TxnNo = RadComboBoxMutationID.Text.Trim
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnitID.SelectedValue.Trim
                .ItemFactor = CDec(txtItemFactor.Text.Trim)
                .Qty = CDec(txtOperandType.Text.Trim + txtQty.Text.Trim)
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
            UpdateViewGridMutation()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxMutationID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MutationHd
            With br
                .TxnNo = RadComboBoxMutationID.Text.Trim
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.MutationDt
                    brdt.TxnNo = RadComboBoxMutationID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxMutationID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MutationDt

            With br
                .ID = ID.Trim
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridMutation()
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
                '.VisibleButton(CSSToolbarItem.tidOther1) = True
                '.lbtnOther1_Text = "Get Item PO"
            End With
        End Sub


        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxMutationID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)

            Select Case ddlInventoryTxnID.SelectedValue.Trim
                Case CStr(BussinessRules.TxnType.Distribution)
                    th.DoApproval(TxnType.Distribution)
                Case CStr(BussinessRules.TxnType.Consumption)
                    th.DoApproval(TxnType.Consumption)
                Case CStr(BussinessRules.TxnType.Production)
                    th.DoApproval(TxnType.Production)
                Case CStr(BussinessRules.TxnType.AdjustmentPlus)
                    th.DoApproval(TxnType.AdjustmentPlus)
                Case CStr(BussinessRules.TxnType.AdjustmentMinus)
                    th.DoApproval(TxnType.AdjustmentMinus)
                Case CStr(BussinessRules.TxnType.BeginningBalance)
                    th.DoApproval(TxnType.BeginningBalance)
                Case Else
            End Select

            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd(Optional ByVal IsNew As Boolean = False)
            InventoryIDTmp = String.Empty
            SourceWhIDTmp = String.Empty
            SourceUnitIDTmp = String.Empty

            If IsNew = False Then
                Dim iv As New BussinessRules.InventoryTxn
                iv.IsMutation = True
                commonFunction.LoadDDL(ddlInventoryTxnID, "InventoryTxnName", "InventoryTxnID", iv.SelectAllForInventoryTxnID, False)
                iv.Dispose()
                iv = Nothing

                Dim Swh As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlSourceWhID, "WHName", "WHID", Swh.SelectAllWarehouse, True)
                Swh.Dispose()
                Swh = Nothing
                SourceWhIDTmp = ddlSourceWhID.SelectedValue.Trim

                Dim Swhunit As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlSourceUnitID, "UnitName", "UnitID", Swhunit.SelectAllUnitByWarehouse(ddlSourceWhID.SelectedValue.Trim), True)
                Swhunit.Dispose()
                Swhunit = Nothing
                SourceUnitIDTmp = ddlSourceUnitID.SelectedValue.Trim

                Dim Twh As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlDestinationWhID, "WHName", "WHID", Twh.SelectAllWarehouse, True)
                Twh.Dispose()
                Twh = Nothing

                Dim Twhunit As New BussinessRules.Warehouse
                commonFunction.LoadDDL(ddlDestinationUnitID, "UnitName", "UnitID", Twhunit.SelectAllUnitByWarehouse(ddlDestinationWhID.SelectedValue.Trim), True)
                Twhunit.Dispose()
                Twhunit = Nothing

                commonFunction.LoadDDLCommonSetting("AdjustReason", ddlReason, True)

                ddlSourceWhID.SelectedIndex = 0
                ddlSourceUnitID.SelectedIndex = 0
                ddlDestinationWhID.SelectedIndex = 0
                ddlDestinationUnitID.SelectedIndex = 0
                ddlReason.SelectedIndex = 0

                ddlInventoryTxnID_SelectedIndexChanged(Nothing, Nothing)

                '// Distribution
                If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.Distribution) Then
                    commonFunction.ShowPanel(PanelWHIDST, True)
                Else
                    commonFunction.ShowPanel(PanelWHIDST, False)
                End If

                '// Adjustment
                If ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentPlus) Or ddlInventoryTxnID.SelectedValue.Trim = CStr(BussinessRules.TxnType.AdjustmentMinus) Then
                    commonFunction.ShowPanel(PanelADJUST, True)
                Else
                    commonFunction.ShowPanel(PanelADJUST, False)
                End If
            End If

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelDetail, True)
            commonFunction.ShowPanel(PnlApproved, False)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            RadComboBoxMutationID.Text = String.Empty
            RadComboBoxMutationID.SelectedValue = String.Empty

            RadMutationDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True

            ddlInventoryTxnID.Enabled = True
            ddlSourceWhID.Enabled = True
            ddlSourceUnitID.Enabled = True
            ddlDestinationWhID.Enabled = True
            ddlDestinationUnitID.Enabled = True
            ddlReason.Enabled = True

            PrepareScreendt()
            UpdateViewGridMutation()
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
            txtQty.Text = Format(1, commonFunction.FORMAT_QTY)
            GetOperandType()
        End Sub

        Private Sub GetOperandType()
            '// Get Operand Type for Selected Mutation Type
            Dim br As New BussinessRules.InventoryTxn
            With br
                .InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtOperandType.Text = .OperandTypeSourceWarehouse.Trim
                Else
                    txtOperandType.Text = String.Empty
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadMutation(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.MutationHd

            'br.InventoryTxnID = ddlInventoryTxnID.SelectedValue.Trim
            br.InventoryTxnID = InventoryIDTmp.Trim
            dt = br.SelectAllForTxnNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxMutationID.DataSource = dt.DefaultView
            RadComboBoxMutationID.DataBind()

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

            If InventoryIDTmp.Trim = CStr(BussinessRules.TxnType.BeginningBalance) And SourceWhIDTmp.Trim <> "none" And SourceUnitIDTmp.Trim <> "none" Then
                dt = br.SelectAllByWhIDUnitIDForItemSeqNoBeginBalance(Filter.Trim, commonFunction.MaxRecord)
            Else
                dt = br.SelectAllByWhIDUnitIDForItemSeqNoMutation(MutationIDTmp.Trim, Filter.Trim, commonFunction.MaxRecord)
            End If

            RadComboBoxItemSeqNo.DataSource = dt.DefaultView
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridMutation()
            Dim dt As DataTable
            Dim br As New BussinessRules.MutationDt
            br.TxnNo = RadComboBoxMutationID.Text.Trim
            dt = br.SelectForViewGrid()

            RadGridMutation.DataSource = dt.DefaultView
            RadGridMutation.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Function GetPrefixIDNumber(ByVal InventoryTxnID As String, Optional ByVal IsHeader As Boolean = False) As String
            Select Case InventoryTxnID
                Case CStr(BussinessRules.TxnType.Distribution)
                    If IsHeader Then
                        Return "DS"
                    Else
                        Return "DT"
                    End If
                Case CStr(BussinessRules.TxnType.Consumption)
                    If IsHeader Then
                        Return "CS"
                    Else
                        Return "CM"
                    End If
                Case CStr(BussinessRules.TxnType.Production)
                    If IsHeader Then
                        Return "PD"
                    Else
                        Return "PT"
                    End If
                Case CStr(BussinessRules.TxnType.AdjustmentPlus)
                    If IsHeader Then
                        Return "AP"
                    Else
                        Return "AJ"
                    End If
                Case CStr(BussinessRules.TxnType.AdjustmentMinus)
                    If IsHeader Then
                        Return "AM"
                    Else
                        Return "AD"
                    End If
                Case CStr(BussinessRules.TxnType.BeginningBalance)
                    If IsHeader Then
                        Return "BB"
                    Else
                        Return "BL"
                    End If
                Case Else
                    Return ("")
            End Select
        End Function

        Private Sub InitialVariableTmp()
            MutationIDTmp = RadComboBoxMutationID.Text.Trim
            InventoryIDTmp = ddlInventoryTxnID.SelectedValue.Trim
            SourceWhIDTmp = ddlSourceWhID.SelectedValue.Trim
            SourceUnitIDTmp = ddlSourceUnitID.SelectedValue.Trim
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("TxnNo", RadComboBoxMutationID.Text.Trim, "MutationHd").Rows.Count > 0 Then
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