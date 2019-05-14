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

Namespace Raven.Web.Secure.Master

    Public Class Warehouse
        Inherits PageBase

#Region " Private Variables (web form designer generated code and Unit code) "

        Private ModuleId As String = "230"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblWarehouseIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtUnitName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblWarehouseNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtWarehouseID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWarehouseName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblSearchItemName As Label
        Protected WithEvents txtSearchItemName As TextBox
        Protected WithEvents lbtnApplyFilter As LinkButton
        Protected WithEvents RadGridROP As DataGrid
        Protected WithEvents lbtnSaveROP As LinkButton
        Protected WithEvents lbtnShowROP As LinkButton
        Protected WithEvents RadComboBoxUnitID As RadComboBox
        Protected WithEvents RadComboBoxWarehouseID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridWarehouse As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxWarehouseID.IsCallBack And Not RadComboBoxUnitID.IsCallBack Then
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

        Private Sub RadComboBoxWarehouseID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxWarehouseID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadWarehouse(e.Text)
        End Sub

        Private Sub RadComboBoxUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadUnit(e.Text, RadComboBoxWarehouseID.SelectedValue.Trim)
        End Sub

        Private Sub RadComboBoxWarehouseID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxWarehouseID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("WhID").ToString()
            e.Item.Value = CType(e.Item.DataItem, DataRowView)("WhID").ToString()
        End Sub

        Private Sub RadComboBoxUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UnitID").ToString()
            e.Item.Value = CType(e.Item.DataItem, DataRowView)("UnitID").ToString()
        End Sub

        Private Sub RadComboBoxWarehouseID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxWarehouseID.SelectedIndexChanged
            _OpenWarehouse()            
        End Sub

        Private Sub RadComboBoxUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxUnitID.SelectedIndexChanged
            _OpenUnit(RadComboBoxWarehouseID.Text.Trim)
        End Sub

        Private Sub lbtnApplyFilter_Click(sender As Object, e As System.EventArgs) Handles lbtnApplyFilter.Click
            UpdateViewGridItem(txtSearchItemName.Text.Trim.Replace("*", "%"))
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
                Case CSSToolbarItem.tidPrevious
                    _Open(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _Open(RavenRecStatus.NextRecord)
            End Select
        End Sub

        Private Sub lbtnSaveROP_Click(sender As Object, e As System.EventArgs) Handles lbtnSaveROP.Click
            Dim oBR As New BussinessRules.ItemROP
            Dim isNew As Boolean = True
            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridROP.Items
                Dim _lblItemSeqNo As Label = CType(gitm.FindControl("_lblItemSeqNo"), Label)
                Dim _txtROPMin As TextBox = CType(gitm.FindControl("_txtROPMin"), TextBox)
                Dim _txtROPMax As TextBox = CType(gitm.FindControl("_txtROPMax"), TextBox)

                oBR.ItemSeqNo = _lblItemSeqNo.Text.Trim
                oBR.WhID = RadComboBoxWarehouseID.Text.Trim
                oBR.UnitID = RadComboBoxUnitID.Text.Trim
                oBR.UserUpdate = MyBase.LoggedOnUserID.Trim

                If IsNumeric(_txtROPMin.Text) And IsNumeric(_txtROPMax.Text) Then
                    If (CType(_txtROPMin.Text.Trim, Decimal) >= 0 And CType(_txtROPMax.Text.Trim, Decimal) > 0) _
                        And (CType(_txtROPMax.Text.Trim, Decimal) >= CType(_txtROPMin.Text.Trim, Decimal)) Then
                        If oBR.SelectOne.Rows.Count > 0 Then
                            isNew = False
                        Else
                            isNew = True
                        End If
                        oBR.ROPMinSUnit = CType(_txtROPMin.Text.Trim, Decimal)
                        oBR.ROPMaxSUnit = CType(_txtROPMax.Text.Trim, Decimal)
                        If isNew Then
                            oBR.Insert()
                        Else
                            oBR.Update()
                        End If                        
                    Else
                        oBR.Delete()
                    End If
                Else
                    oBR.Delete()
                End If
            Next

            UpdateViewGridItem(txtSearchItemName.Text.Trim.Replace("*", "%"))
        End Sub

        Private Sub lbtnShowROP_Click(sender As Object, e As System.EventArgs) Handles lbtnShowROP.Click
            UpdateViewGridItemActiveROP()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridWarehouse_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridWarehouse.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblWarehouseID As Label = CType(e.Item.FindControl("_lblWarehouseID"), Label)
                    Dim _lblUnitID As Label = CType(e.Item.FindControl("_lblUnitID"), Label)

                    RadComboBoxWarehouseID.Text = _lblWarehouseID.Text.Trim
                    RadComboBoxUnitID.Text = _lblUnitID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxWarehouseID.Text.Trim) = 0 And Len(RadComboBoxUnitID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.Warehouse

            With br
                .WhID = RadComboBoxWarehouseID.Text.Trim
                .UnitID = RadComboBoxUnitID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxWarehouseID.Text = .WhID.Trim
                        RadComboBoxUnitID.Text = .UnitID.Trim
                    End If
                    txtWarehouseName.Text = .WhName.Trim
                    txtUnitName.Text = .UnitName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive

                    lbtnSaveROP.Enabled = True
                    lbtnShowROP.Enabled = True
                Else
                    lbtnSaveROP.Enabled = False
                    lbtnShowROP.Enabled = False
                End If
            End With

GoNext:

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtDescription.ClientID)
        End Sub

        Private Sub _OpenWarehouse()
            If Len(RadComboBoxWarehouseID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.Warehouse

            With br
                .WhID = RadComboBoxWarehouseID.Text.Trim
                If .SelectOneWarehouse().Rows.Count > 0 Then
                    txtWarehouseID.Text = .WhID.Trim
                    txtWarehouseName.Text = .WhName.Trim
                    RadComboBoxUnitID.Text = String.Empty
                    txtUnitName.Text = String.Empty
                    txtDescription.Text = String.Empty
                    chkIsActive.Checked = True
                Else
                    PrepareScreen(True)
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtWarehouseName.ClientID)
        End Sub

        Private Sub _OpenUnit(ByVal WhID As String)
            If Len(RadComboBoxUnitID.Text.Trim) = 0 Then
                Exit Sub
            End If

            Dim br As New BussinessRules.Warehouse

            With br
                .UnitID = RadComboBoxUnitID.Text.Trim
                If .SelectOneUnitByWarehouse(WhID.Trim).Rows.Count > 0 Then
                    txtUnitName.Text = .UnitName.Trim
                    _Open(RavenRecStatus.CurrentRecord)
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtUnitName.ClientID)
        End Sub

        Private Sub _Save()
            Page.Validate()
            If Page.IsValid = False Then
                Exit Sub
            End If

            If RadComboBoxWarehouseID.Text = String.Empty Then
                commonFunction.MsgBox(Me, "Warehouse ID cannot empty.")
                Exit Sub
            End If

            If txtWarehouseName.Text = String.Empty Then
                commonFunction.MsgBox(Me, "Warehouse Name cannot empty.")
                Exit Sub
            End If

            If RadComboBoxUnitID.Text = String.Empty Then
                commonFunction.MsgBox(Me, "Unit ID cannot empty.")
                Exit Sub
            End If

            If txtUnitName.Text = String.Empty Then
                commonFunction.MsgBox(Me, "Unit Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Warehouse
            Dim fNew As Boolean = True

            With br
                .WhID = RadComboBoxWarehouseID.Text.Trim
                .UnitID = RadComboBoxUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .WhID = RadComboBoxWarehouseID.Text.Trim
                .UnitID = RadComboBoxUnitID.Text.Trim
                .WhName = txtWarehouseName.Text.Trim
                .UnitName = txtUnitName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridWarehouse()
                        lbtnSaveROP.Enabled = True
                        lbtnShowROP.Enabled = True
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxWarehouseID.Text.Trim) = 0 And Len(RadComboBoxUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Warehouse

            With br
                .WhID = RadComboBoxWarehouseID.Text.Trim
                .UnitID = RadComboBoxUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtWarehouseName.ClientID)
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
            End With
        End Sub

        Private Sub PrepareScreen(Optional ByVal IsOpen As Boolean = False)
            If IsOpen = False Then
                RadComboBoxWarehouseID.Text = String.Empty
            End If
            RadComboBoxUnitID.Text = String.Empty
            RadComboBoxUnitID.Items.Clear()
            txtWarehouseName.Text = String.Empty
            txtUnitName.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True

            lbtnSaveROP.Enabled = False
            lbtnShowROP.Enabled = False

            txtSearchItemName.Text = "*"
            UpdateViewGridItem(String.Empty)

            UpdateViewGridWarehouse()
        End Sub

        Private Sub LoadWarehouse(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllWarehouse

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "WhID LIKE '%" + Filter.Trim + "%' OR WhName LIKE '%" + Filter.Trim + "%'"

            RadComboBoxWarehouseID.DataSource = dv
            RadComboBoxWarehouseID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadUnit(ByVal Filter As String, ByVal WhID As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllUnitByWarehouse(WhID.Trim)

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "UnitID LIKE '" + Filter.Trim + "%' OR UnitName LIKE '" + Filter.Trim + "%'"

            RadComboBoxUnitID.DataSource = dv
            RadComboBoxUnitID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridWarehouse()
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAll

            RadGridWarehouse.DataSource = dt.DefaultView
            RadGridWarehouse.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItem(ByVal strItemName As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectByFilterItemNameWithROP(RadComboBoxWarehouseID.Text.Trim, RadComboBoxUnitID.Text.Trim, strItemName.Trim, True)

            RadGridROP.DataSource = dt.DefaultView
            RadGridROP.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItemActiveROP()
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemROP

            br.WhID = RadComboBoxWarehouseID.Text.Trim
            br.UnitID = RadComboBoxUnitID.Text.Trim
            dt = br.SelectByWHIDUnitID()

            RadGridROP.DataSource = dt.DefaultView
            RadGridROP.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace