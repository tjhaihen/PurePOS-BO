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

    Public Class ProductionFormula
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "220"

        'header

        
        Protected WithEvents txtItemNameHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFormulaName As System.Web.UI.WebControls.TextBox


        Protected WithEvents RadComboBoxProductionFormulaID As RadComboBox
        Protected WithEvents RadComboBoxItemSeqNoHd As RadComboBox


        Protected WithEvents Toolbar As CSSToolbar


        'detail

        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox

        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton

        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblDescriptionHdCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridProductionFormula As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxProductionFormulaID.IsCallBack And _
                'Not RadComboBoxItemSeqNoHd.IsCallBack And _
                'Not RadComboBoxItemSeqNo.IsCallBack Then

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

        Private Sub RadComboBoxProductionFormulaID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxProductionFormulaID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadProductionFormula(e.Text)
        End Sub

        Private Sub RadComboBoxProductionFormulaID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxProductionFormulaID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("FormulaID").ToString()
        End Sub

        Private Sub RadComboBoxProductionFormulaID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxProductionFormulaID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub RadComboBoxItemSeqNoHd_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNoHd.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItemHd(e.Text)
        End Sub

        Private Sub RadComboBoxItemSeqNoHd_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNoHd.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNoHd_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNoHd.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNoHd, txtItemNameHd)

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
            '           commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedItem.Value.Trim))
            commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave
                    _SaveHd()
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
            End Select
        End Sub

        Private Sub lbtnNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewDetail.Click
            PrepareScreendt()
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _Savedt()
        End Sub
        Private Sub ddlItemUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemUnitID.SelectedIndexChanged
            Dim ift As New BussinessRules.ItemFactorTemplate
            'ift.ItemSeqNo = RadComboBoxItemSeqNo.SelectedItem.Value.Trim
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

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridProductionFormula_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridProductionFormula.ItemCommand
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
        Private Sub RadGridProductionFormula_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridProductionFormula.ItemCreated
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

            Dim br As New BussinessRules.ProductionFormulahd
            With br
                .FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxProductionFormulaID.Text = .FormulaID.Trim
                    End If
                    txtFormulaName.Text = .FormulaName.Trim
                    'RadComboBoxItemSeqNoHd.SelectedItem.Value = .ItemSeqNo.Trim
                    RadComboBoxItemSeqNoHd.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNoHd, txtItemNameHd, True)

                    txtDescriptionHd.Text = .Description.Trim

                    UpdateViewGridProductionFormula()


                    RadComboBoxItemSeqNoHd.Enabled = False

                    Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                    Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True

                    'RadToolbar.Items(2).Enabled = True ' save
                    'RadToolbar.Items(4).Enabled = True ' Delete

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

            commonFunction.Focus(Me, RadComboBoxItemSeqNoHd.ClientID)
        End Sub

        Private Sub _Opendt()

            Dim br As New BussinessRules.ProductionFormulaDt
            With br
                .ID = txtID.Text.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridProductionFormula()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    'RadComboBoxItemSeqNo.SelectedItem.Value = .ItemSeqNo.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName, True)

                    RadComboBoxItemSeqNo_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlItemUnitID, .ItemUnitID)
                    txtItemFactor.Text = Format(.ItemFactor, commonFunction.FORMAT_CURRENCY)
                Else
                    PrepareScreendt()
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxItemSeqNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            ' If Len(RadComboBoxItemSeqNoHd.SelectedItem.Value.Trim) = 0 Then
            If Len(RadComboBoxItemSeqNoHd.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Name Header Cannot Empty.")
                Return False
                Exit Function
            End If

            If txtFormulaName.Text.Trim = "" Then
                commonFunction.MsgBox(Me, "Formula Name Cannot Empty.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.ProductionFormulahd
            Dim fNew As Boolean = True

            With br
                .FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxProductionFormulaID.Text = BussinessRules.ID.GenerateIDNumber("ProductionFormulahd", "FormulaID", "PF")
                End If

                '// set the value
                .FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                .FormulaName = txtFormulaName.Text.Trim
                '.ItemSeqNo = RadComboBoxItemSeqNoHd.SelectedItem.Value.Trim
                .ItemSeqNo = RadComboBoxItemSeqNoHd.SelectedValue.Trim
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

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _Savedt()
            'If RadComboBoxItemSeqNo.SelectedItem.Value.Trim = RadComboBoxItemSeqNoHd.SelectedItem.Value.Trim Then
            If RadComboBoxItemSeqNo.SelectedValue.Trim = RadComboBoxItemSeqNoHd.SelectedValue.Trim Then
                commonFunction.MsgBox(Me, "Item name must difference with item name header.")
                Exit Sub
            End If

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

            'If Len(RadComboBoxItemSeqNo.SelectedItem.Value.Trim) = 0 Then
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

            If RadComboBoxProductionFormulaID.Text.Trim.Length = 0 Then If Not _SaveHd() Then Exit Sub

            Dim br As New BussinessRules.ProductionFormulaDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("ProductionFormuladt", "ID")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                '.ItemSeqNo = RadComboBoxItemSeqNo.SelectedItem.Value.Trim
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnitID.SelectedValue.Trim
                .ItemFactor = CDec(txtItemFactor.Text.Trim)
                .Qty = CDec(txtQty.Text.Trim)

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
            UpdateViewGridProductionFormula()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxProductionFormulaID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ProductionFormulahd

            With br
                .FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.ProductionFormulaDt
                    brdt.FormulaID = RadComboBoxProductionFormulaID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByFormulaID()
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

            commonFunction.Focus(Me, RadComboBoxProductionFormulaID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ProductionFormulaDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridProductionFormula()
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
            End With
        End Sub

        Private Sub PrepareScreenHd()
            'RadToolbar.Items(2).Enabled = False ' save
            'RadToolbar.Items(4).Enabled = False ' Delete
            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False

            RadComboBoxProductionFormulaID.Text = String.Empty
            'RadComboBoxProductionFormulaID.SelectedItem.Value = String.Empty
            RadComboBoxProductionFormulaID.SelectedValue = String.Empty

            txtDescriptionHd.Text = String.Empty
            RadComboBoxItemSeqNoHd.Enabled = True
            RadComboBoxItemSeqNoHd.Text = String.Empty
            'RadComboBoxItemSeqNoHd.SelectedItem.Value = String.Empty
            RadComboBoxItemSeqNoHd.SelectedValue = String.Empty
            txtItemNameHd.Text = String.Empty

            txtFormulaName.Text = String.Empty

            PrepareScreendt()

            UpdateViewGridProductionFormula()
        End Sub

        Private Sub PrepareScreendt()
            txtID.Text = String.Empty
            RadComboBoxItemSeqNo.Text = String.Empty
            'RadComboBoxItemSeqNo.SelectedItem.Value = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
            txtItemName.Text = String.Empty
            ddlItemUnitID.Items.Clear()
            txtItemFactor.Text = "1"
            txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub LoadProductionFormula(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ProductionFormulahd

            dt = br.SelectAllForFormulaID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxProductionFormulaID.DataSource = dt.DefaultView
            RadComboBoxProductionFormulaID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadItemHd(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            'dt = br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)
            dt = br.SelectAllForItemSeqNoFormula(Filter.Trim, commonFunction.MaxRecord)


            RadComboBoxItemSeqNoHd.DataSource = dt
            RadComboBoxItemSeqNoHd.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadItem(ByVal Filter As String)

            Dim br As New BussinessRules.Item

            Dim dt As New DataView(br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord))

            RadComboBoxItemSeqNo.DataSource = dt
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub


        Private Sub UpdateViewGridProductionFormula()
            Dim dt As DataTable
            Dim br As New BussinessRules.ProductionFormulaDt

            br.FormulaID = RadComboBoxProductionFormulaID.Text.Trim
            dt = br.SelectForViewGrid

            RadGridProductionFormula.DataSource = dt.DefaultView
            RadGridProductionFormula.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub


#End Region

    End Class
End Namespace