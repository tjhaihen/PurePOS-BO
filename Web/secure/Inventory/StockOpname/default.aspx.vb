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

    Public Class StockOpname
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "420"

        'header
        Protected WithEvents RadStockOpnameDate As RadDatePicker
        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents RadComboBoxStockOpnameID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        'detail
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label

        'grid
        Protected WithEvents RadGridStockOpname As RadGrid
        Protected WithEvents lblPageGrid As System.Web.UI.WebControls.Label


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxStockOpnameID.IsCallBack Then
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

        Private Sub RadComboBoxStockOpnameID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxStockOpnameID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadStockOpname(e.Text)
        End Sub

        Private Sub RadComboBoxStockOpnameID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxStockOpnameID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("TxnNo").ToString()
        End Sub

        Private Sub RadComboBoxStockOpnameID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxStockOpnameID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
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
                    If RadComboBoxStockOpnameID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 4201
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxStockOpnameID.Text.Trim)
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

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), True, "Unit Name")
            whunit.Dispose()
            whunit = Nothing
        End Sub


#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridStockOpname_ItemCreated(ByVal sender As Object, ByVal e As GridItemEventArgs) Handles RadGridStockOpname.ItemCreated
            Select Case e.Item.ItemType
                Case GridItemType.AlternatingItem, GridItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub

        Private Sub RadGridStockOpname_NeedDataSource(ByVal source As Object, ByVal e As GridNeedDataSourceEventArgs) Handles RadGridStockOpname.NeedDataSource
            'If Not RadComboBoxStockOpnameID.IsCallBack Then
            Dim startRowIndex As String = CStr((RadGridStockOpname.CurrentPageIndex * RadGridStockOpname.PageSize) + 1)
            Dim maximumRows As String = CStr(RadGridStockOpname.PageSize + (RadGridStockOpname.CurrentPageIndex * RadGridStockOpname.PageSize))

            UpdateQtyGrid()

            Dim br As New BussinessRules.MutationDt
            br.TxnNo = RadComboBoxStockOpnameID.Text.Trim

            RadGridStockOpname.DataSource = br.SelectForViewGrid(startRowIndex, maximumRows).DefaultView
            br.Dispose()
            br = Nothing

            lblPageGrid.Text = (RadGridStockOpname.CurrentPageIndex + 1).ToString.Trim
            'End If
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.MutationHd
            With br
                .TxnNo = RadComboBoxStockOpnameID.Text.Trim
                .InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxStockOpnameID.Text = .TxnNo.Trim
                    End If
                    RadStockOpnameDate.SelectedDate = .TxnDate

                    commonFunction.SelectListItem(ddlWhID, .SourceWHID.Trim)

                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .SourceUnitID.Trim)

                    txtDescriptionHd.Text = .Description.Trim

                    UpdateViewGridStockOpname()

                    If .IsApproval Then

                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False

                    Else

                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        
                    End If
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxStockOpnameID.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean

            If ddlWhID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Warehouse Name Cannot Empty.")
                Exit Function
            End If

            If ddlUnitID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Unit Name Cannot Empty.")
                Exit Function
            End If

            If RadStockOpnameDate.SelectedDate.Value > Date.Today Then
                commonFunction.MsgBox(Me, "Stock Opname Date must be equal or less than today.")
                Exit Function
            End If

            UpdateQtyGrid()

            Dim br As New BussinessRules.MutationHd
            Dim fNew As Boolean = True

            With br
                .TxnNo = RadComboBoxStockOpnameID.Text.Trim
                .InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False

                    If .IsApproval = True And FApproval = True Then
                        commonFunction.MsgBox(Me, RadComboBoxStockOpnameID.Text.Trim + "is already approved")
                        br.Dispose()
                        br = Nothing
                        Exit Function
                    End If
                Else
                    RadComboBoxStockOpnameID.Text = BussinessRules.ID.GenerateIDNumber("MutationHD", "TxnNo", "SO", _
                    "Where InventoryTxnID = '" + CStr(BussinessRules.TxnType.StockOpname) + "'")
                End If

                '// set the value
                .TxnNo = RadComboBoxStockOpnameID.Text.Trim
                .TxnDate = RadStockOpnameDate.SelectedDate.Value
                .InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
                .SourceWHID = ddlWhID.SelectedValue.Trim
                .SourceUnitID = ddlUnitID.SelectedValue.Trim
                .DestinationWHID = "None"
                .DestinationUnitID = "None"
                .AdjustmentReasonID = String.Empty
                .Description = txtDescriptionHd.Text.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        Dim brdt As New BussinessRules.MutationDt
                        brdt.InsertMutationDtFromItemBalance(RadComboBoxStockOpnameID.Text.Trim, _
                        ddlWhID.SelectedValue.Trim, _
                        ddlUnitID.SelectedValue.Trim, _
                        MyBase.LoggedOnUserID.Trim)
                        brdt.Dispose()
                        brdt = Nothing
                    End If
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

        Private Sub _DeleteHd()
            If Len(RadComboBoxStockOpnameID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MutationHd
            With br
                .TxnNo = RadComboBoxStockOpnameID.Text.Trim
                .InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.MutationDt
                    brdt.TxnNo = RadComboBoxStockOpnameID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxStockOpnameID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MutationDt

            With br
                .ID = ID.Trim
                .InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridStockOpname()
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

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("Qty", System.Type.GetType("System.Double"))
                .Columns.Add("ID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Function UpdateQtyGrid() As Boolean
            Dim mhd As New BussinessRules.MutationHd
            mhd.TxnNo = RadComboBoxStockOpnameID.Text.Trim
            mhd.InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
            mhd.SelectOne(RavenRecStatus.CurrentRecord)
            If Not mhd.IsApproval Then
                Dim tblTmp As DataTable = createTmpTable()
                Dim _item As GridDataItem
                For Each _item In RadGridStockOpname.Items
                    Dim txtDifferencesQty As TextBox = CType(_item.FindControl("txtDifferencesQty"), TextBox)
                    Dim _lblID As Label = CType(_item.FindControl("_lblID"), Label)
                    Dim _lblQtyReal As Label = CType(_item.FindControl("_lblQtyReal"), Label)

                    Dim row As DataRow = tblTmp.NewRow

                    If Not IsNumeric(txtDifferencesQty.Text.Trim) Then
                        txtDifferencesQty.Text = _lblQtyReal.Text.Trim
                    End If

                    row("Qty") = CDec(Left(Replace(txtDifferencesQty.Text.Trim, ",", ""), 16).Trim)
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                Next
                If tblTmp.Rows.Count > 0 Then
                    Dim br As New BussinessRules.MutationDt
                    br.UpdateQtySP(tblTmp, MyBase.LoggedOnUserID.Trim)
                    br.Dispose()
                    br = Nothing
                End If
            End If
            mhd.Dispose()
            mhd = Nothing
        End Function

        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxStockOpnameID.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(BussinessRules.TxnType.StockOpname)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            ddlWhID.Enabled = True
            ddlUnitID.Enabled = True

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, True, "Warehouse Name")
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), True, "Unit Name")
            whunit.Dispose()
            whunit = Nothing

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False


            RadComboBoxStockOpnameID.Text = String.Empty
            RadComboBoxStockOpnameID.SelectedValue = String.Empty

            RadStockOpnameDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0

            commonFunction.ShowPanel(PnlApproved, False)

            UpdateViewGridStockOpname()
        End Sub

        Private Sub LoadStockOpname(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.MutationHd

            br.InventoryTxnID = CStr(BussinessRules.TxnType.StockOpname)
            dt = br.SelectAllForTxnNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxStockOpnameID.DataSource = dt.DefaultView
            RadComboBoxStockOpnameID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridStockOpname()
            RadGridStockOpname.CurrentPageIndex = 0
            Dim startRowIndex As String = CStr((RadGridStockOpname.CurrentPageIndex * RadGridStockOpname.PageSize) + 1)
            Dim maximumRows As String = CStr(RadGridStockOpname.PageSize + (RadGridStockOpname.CurrentPageIndex * RadGridStockOpname.PageSize))

            Dim br As New BussinessRules.MutationDt
            br.TxnNo = RadComboBoxStockOpnameID.Text.Trim
            Dim dv As New DataView(br.SelectForViewGrid())
            RadGridStockOpname.VirtualItemCount = dv.Count

            If dv.Count > 0 Then
                ddlWhID.Enabled = False
                ddlUnitID.Enabled = False
                lblPageGrid.Text = (RadGridStockOpname.CurrentPageIndex + 1).ToString.Trim
            Else
                ddlWhID.Enabled = True
                ddlUnitID.Enabled = True
                lblPageGrid.Text = "0"
            End If

            dv.RowFilter = "Number >= '" + startRowIndex + "' and Number <= '" + maximumRows + "'"

            RadGridStockOpname.DataSource = dv
            RadGridStockOpname.DataBind()

            dv.Dispose()
            dv = Nothing

            br.Dispose()
            br = Nothing
        End Sub

#End Region

    End Class
End Namespace