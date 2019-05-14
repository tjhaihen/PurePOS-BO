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

Namespace Raven.Web.Secure.Master.ItemDataSetting

    Public Class ItemCatalogue
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "215"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemFactorCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemSeqNo As System.Web.UI.WebControls.Label
        Protected WithEvents lblStartingDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitPriceCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label

        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtUnitPrice As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox

        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents chkIsAllowDecimal As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox

        Protected WithEvents RadStartingDate As RadDatePicker

        Protected WithEvents RadGridItemCatalogue As DataGrid

        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxEntitiesID.IsCallBack And Not RadComboBoxItemSeqNo.IsCallBack Then
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

        Private Sub RadComboBoxEntitiesID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesID").ToString()
            e.Item.Value = CType(e.Item.DataItem, DataRowView)("EntitiesSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesID.SelectedIndexChanged
            commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName)
            UpdateViewGridItemCatalogue()
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItem(e.Text)
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString()
            e.Item.Value = CType(e.Item.DataItem, DataRowView)("ItemSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNo.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName)
            Dim itemunit As New BussinessRules.ItemUnit
            commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing

            UpdateViewGridItemCatalogue()
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

            UpdateViewGridItemCatalogue()
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
            End Select
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridItemCatalogue_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridItemCatalogue.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblIDDt As Label = CType(e.Item.FindControl("_lblIDDt"), Label)
                    txtID.Text = _lblIDDt.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(txtID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.EntitiesItem

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        txtID.Text = .ID.Trim
                    End If
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName, True)
                    txtDescription.Text = .Description.Trim
                    RadComboBoxItemSeqNo_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlItemUnitID, .ItemUnitID)
                    txtItemFactor.Text = Format(.ItemFactor, commonFunction.FORMAT_CURRENCY)
                    RadStartingDate.SelectedDate = .StartingDate
                    txtUnitPrice.Text = Format(.Price, commonFunction.FORMAT_CURRENCY)
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    PrepareScreen()
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            If ddlItemUnitID.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Item Unit cannot empty.")
                Exit Sub
            End If

            If IsNumeric(txtItemFactor.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Item Factor must be numeric.")
                Exit Sub
            End If

            If CDec(txtItemFactor.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                Exit Sub
            End If

            Dim br As New BussinessRules.EntitiesItem
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("EntitiesItem", "ID", "")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnitID.Text.Trim
                .ItemFactor = CDec(txtItemFactor.Text.Trim)
                .StartingDate = RadStartingDate.SelectedDate.Value
                .Price = CDec(txtUnitPrice.Text.Trim)
                .Description = Left(txtDescription.Text.Trim, 500)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen(True)
                    End If
                Else
                    If .Update() Then
                        PrepareScreen(True)
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            Dim br As New BussinessRules.EntitiesItem

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen(True)
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
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub PrepareScreen(Optional ByVal IsFromCUD As Boolean = False)
            txtID.Text = String.Empty
            If IsFromCUD = False Then
                RadComboBoxEntitiesID.Text = String.Empty
                RadComboBoxEntitiesID.SelectedValue = String.Empty
                RadComboBoxEntitiesID.SelectedIndex = 0
                txtEntitiesName.Text = String.Empty
            End If
            RadComboBoxItemSeqNo.Text = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
            RadComboBoxItemSeqNo.SelectedIndex = 0
            txtItemName.Text = String.Empty
            ddlItemUnitID.Items.Clear()
            txtItemFactor.Text = "1"
            RadStartingDate.SelectedDate = Date.Now
            txtUnitPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDescription.Text = String.Empty

            UpdateViewGridItemCatalogue()
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            '// '01' = Supplier/Distributor as EntitiesType
            dt = br.SelectAllForEntitiesSeqNoByEntitiesType("01", Filter.Trim, commonFunction.MaxRecord)

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

        Private Sub UpdateViewGridItemCatalogue()
            Dim strEntitiesSeqNo As String
            If Len(txtEntitiesName.Text.Trim) = 0 Then
                strEntitiesSeqNo = String.Empty
            Else
                strEntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            End If

            Dim strItemSeqNo As String
            If Len(txtItemName.Text.Trim) = 0 Then
                strItemSeqNo = String.Empty
            Else
                strItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
            End If

            Dim strItemUnitID As String
            If ddlItemUnitID.Items.Count = 0 Then
                strItemUnitID = String.Empty
            Else
                If Len(ddlItemUnitID.Text.Trim) = 0 Or ddlItemUnitID.Text.Trim = "none" Then
                    strItemUnitID = String.Empty
                Else
                    strItemUnitID = ddlItemUnitID.Text.Trim
                End If
            End If

            Dim dt As DataTable
            Dim br As New BussinessRules.EntitiesItem

            br.EntitiesSeqNo = strEntitiesSeqNo.Trim
            dt = br.SelectAllByEntitiesSeqNo(strItemSeqNo.Trim, strItemUnitID.Trim)

            RadGridItemCatalogue.DataSource = dt.DefaultView
            RadGridItemCatalogue.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace