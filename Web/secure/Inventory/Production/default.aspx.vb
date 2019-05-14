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

    Public Class Production
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "415"

        'header


        Protected WithEvents RadProductionDate As RadDatePicker
        Protected WithEvents txtFormulaName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        Protected WithEvents RadComboBoxProductionNo As RadComboBox
        Protected WithEvents RadComboBoxFormulaID As RadComboBox

        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents Toolbar As CSSToolbar


        'detail

        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image



        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridProduction As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxProductionNo.IsCallBack And _
                'Not RadComboBoxFormulaID.IsCallBack Then

                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreenHd()

                If ReadQueryString() = True Then
                End If

            End If
        End Sub

        Private Sub RadComboBoxProductionNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxProductionNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadProduction(e.Text)
        End Sub

        Private Sub RadComboBoxProductionNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxProductionNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ProductionNo").ToString()
        End Sub

        Private Sub RadComboBoxProductionNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxProductionNo.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub RadComboBoxFormulaID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxFormulaID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadFormulaID(e.Text)
        End Sub

        Private Sub RadComboBoxFormulaID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxFormulaID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("FormulaID").ToString()
        End Sub

        Private Sub RadComboBoxFormulaID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxFormulaID.SelectedIndexChanged
            Dim oformula As New BussinessRules.ProductionFormulahd
            With oformula
                .FormulaID = RadComboBoxFormulaID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtFormulaName.Text = .FormulaName.Trim
                    Dim oitem As New BussinessRules.Item
                    oitem.ItemSeqNo = .ItemSeqNo.Trim
                    If oitem.SelectOne.Rows.Count > 0 Then
                        txtItemName.Text = oitem.ItemName.Trim
                    Else
                        txtItemName.Text = String.Empty
                    End If
                    oitem.Dispose()
                    oitem = Nothing
                Else
                    RadComboBoxFormulaID.Text = String.Empty
                    txtFormulaName.Text = String.Empty
                    txtItemName.Text = String.Empty
                End If
            End With
            oformula.Dispose()
            oformula = Nothing
            UpdateViewGridProduction()
        End Sub


        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave
                    _Savedt()
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
            End Select
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), True)
            whunit.Dispose()
            whunit = Nothing
        End Sub

        Private Sub ddlUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnitID.SelectedIndexChanged
        End Sub
#End Region

#Region " DataGrid Command Center "
       
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.ProductionHd
            With br
                .ProductionNo = RadComboBoxProductionNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxProductionNo.Text = .ProductionNo.Trim
                    End If

                    RadProductionDate.SelectedDate = .ProductionDate

                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)
                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)
                    RadComboBoxFormulaID.Text = .FormulaID.Trim
                    RadComboBoxFormulaID_SelectedIndexChanged(Nothing, Nothing)
                    txtQty.Text = Format(.QtySUnit, commonFunction.FORMAT_CURRENCY)

                    txtDescriptionHd.Text = .Description.Trim

                    UpdateViewGridProduction()


                    RadComboBoxFormulaID.Enabled = False

                    If .IsApproval = True Then

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        commonFunction.ShowPanel(PnlApproved, True)
                    Else
                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        commonFunction.ShowPanel(PnlApproved, False)
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

            commonFunction.Focus(Me, RadComboBoxProductionNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean

            If RadComboBoxFormulaID.Text.Trim = "" Then
                commonFunction.MsgBox(Me, "Formula ID Cannot Empty.")
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

            If Not IsNumeric(txtQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Qty small unit must be numeric.")
                Exit Function
            End If

            If CDbl(txtQty.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Qty small unit must be greater than 0.")
                Exit Function
            End If

            If txtItemName.Text.Trim = "" Then
                commonFunction.MsgBox(Me, "Item name Cannot Empty.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.ProductionHd
            Dim fNew As Boolean = True

            With br
                .ProductionNo = RadComboBoxProductionNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxProductionNo.Text = BussinessRules.ID.GenerateIDNumber("Productionhd", "ProductionNo", "PH")
                End If

                '// set the value
                .ProductionNo = RadComboBoxProductionNo.Text.Trim
                .ProductionDate = RadProductionDate.SelectedDate.Value
                .WhID = ddlWhID.SelectedValue.Trim
                .UnitID = ddlUnitID.SelectedValue.Trim
                .FormulaID = RadComboBoxFormulaID.Text.Trim
                .QtySUnit = CDec(txtQty.Text.Trim)
                .Description = txtDescriptionHd.Text.Trim
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

            If FApproval Then
                _Approval()
            End If

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _Savedt()
            If RadComboBoxProductionNo.Text.Trim.Length = 0 Then
                Dim rowCount As Integer = 0
                Dim tblTmp As DataTable
                createTmpTable(tblTmp)

                Dim gitm As DataGridItem
                For Each gitm In RadGridProduction.Items
                    Dim _lblItemSeqNo As Label = CType(gitm.FindControl("_lblItemSeqNo"), Label)
                    Dim _lblQty As Label = CType(gitm.FindControl("_lblQty"), Label)
                    Dim _txtQty As TextBox = CType(gitm.FindControl("_txtQty"), TextBox)
                    Dim _lblItemUnit As Label = CType(gitm.FindControl("_lblItemUnit"), Label)
                    Dim _lblItemFactor As Label = CType(gitm.FindControl("_lblItemFactor"), Label)
                    Dim _chkIsAllowEditQty As CheckBox = CType(gitm.FindControl("_chkIsAllowEditQty"), CheckBox)

                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("ItemSeqNo") = CType(Trim(_lblItemSeqNo.Text.Trim), String)
                    row("ItemUnitID") = CType(Trim(_lblItemUnit.Text.Trim), String)
                    If _chkIsAllowEditQty.Checked Then
                        row("Qty") = CType(_txtQty.Text.Trim, Double)
                    Else
                        row("Qty") = CType(_lblQty.Text.Trim, Double)
                    End If
                    row("ItemFactor") = CType(Trim(_lblItemFactor.Text.Trim), Double)

                    tblTmp.Rows.Add(row)
                Next

                If rowCount = 0 Then
                    commonFunction.MsgBox(Me, "Nothing to save")
                    Exit Sub
                End If

                If RadComboBoxProductionNo.Text.Trim.Length = 0 Then If Not _SaveHd() Then Exit Sub


                ' // save the data
                Dim pdt As New BussinessRules.ProductionDt

                pdt.ProductionNo = RadComboBoxProductionNo.Text.Trim
                pdt.InsertItemProduction(tblTmp, MyBase.LoggedOnUserID)
                pdt.Dispose()
                pdt = Nothing

            Else
                _SaveHd()
            End If
            UpdateViewGridProduction()
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("Qty", System.Type.GetType("System.Double"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Double"))
            End With
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxProductionNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ProductionHd

            With br
                .ProductionNo = RadComboBoxProductionNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.ProductionDt
                    brdt.ProductionNo = RadComboBoxProductionNo.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByProductionNo()
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

            commonFunction.Focus(Me, RadComboBoxProductionNo.ClientID)
        End Sub
#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub _Approval()
            Dim th As New BussinessRules.ItemHistory
            th.TxnNo = RadComboBoxProductionNo.Text.Trim
            th.UserInsert = Trim(MyBase.LoggedOnUserID)
            th.DoApproval(TxnType.Production)
            th.Dispose()
            th = Nothing
        End Sub

        Private Sub PrepareScreenHd()
            Dim Swh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", Swh.SelectAllWarehouse, True)
            Swh.Dispose()
            Swh = Nothing


            Dim Swhunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", Swhunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), True)
            Swhunit.Dispose()
            Swhunit = Nothing

            RadProductionDate.SelectedDate = Date.Now

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False

            RadComboBoxProductionNo.Text = String.Empty
            RadComboBoxProductionNo.SelectedValue = String.Empty

            txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)

            txtDescriptionHd.Text = String.Empty
            RadComboBoxFormulaID.Enabled = True
            RadComboBoxFormulaID.Text = String.Empty
            RadComboBoxFormulaID.SelectedValue = String.Empty
            txtFormulaName.Text = String.Empty
            txtItemName.Text = String.Empty

            commonFunction.ShowPanel(PnlApproved, False)

            UpdateViewGridProduction()
        End Sub

        Private Sub LoadProduction(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ProductionHd

            dt = br.SelectAllForProductionNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxProductionNo.DataSource = dt.DefaultView
            RadComboBoxProductionNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadFormulaID(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ProductionFormulahd

            dt = br.SelectAllForFormulaID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxFormulaID.DataSource = dt
            RadComboBoxFormulaID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridProduction()
            Dim dt As DataTable
            Dim br As New BussinessRules.ProductionDt

            br.ProductionNo = RadComboBoxProductionNo.Text.Trim
            dt = br.SelectForViewGrid(RadComboBoxFormulaID.Text.Trim)

            RadGridProduction.DataSource = dt.DefaultView
            RadGridProduction.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub


#End Region

    End Class
End Namespace