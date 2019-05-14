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

    Public Class ItemCategory
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "211"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemCategoryIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemCategoryNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesDiscountPctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesDiscountAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtItemCategoryName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSalesDiscountPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSalesDiscountAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSalesMarginPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkIsFormula As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkIsInventory As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxItemCategoryID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        
        Protected WithEvents RadGridItemCategory As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxItemCategoryID.IsCallBack Then
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

        Private Sub RadComboBoxItemCategoryID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemCategoryID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItemCategory(e.Text)
        End Sub

        Private Sub RadComboBoxItemCategoryID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemCategoryID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemCategoryID").ToString()
        End Sub

        Private Sub RadComboBoxItemCategoryID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemCategoryID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
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
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridItemCategory_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridItemCategory.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblItemCategoryID As Label = CType(e.Item.FindControl("_lblItemCategoryID"), Label)

                    RadComboBoxItemCategoryID.Text = _lblItemCategoryID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxItemCategoryID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemCategory

            With br
                .ItemCategoryID = RadComboBoxItemCategoryID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxItemCategoryID.Text = .ItemCategoryID.Trim
                    End If
                    txtItemCategoryName.Text = .ItemCategoryName.Trim
                    txtDescription.Text = .Description.Trim
                    txtSalesDiscountPct.Text = Format(.SalesDiscountPct, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesDiscountAmt.Text = Format(.SalesDiscountAmt, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesMarginPct.Text = Format(.MarginPct, commonFunction.FORMAT_CURRENCY).Trim
                    chkIsActive.Checked = .IsActive
                    chkIsFormula.Checked = .IsFormula
                    chkIsInventory.Checked = .IsInventory
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtItemCategoryName.Text = String.Empty
                    txtDescription.Text = String.Empty
                    txtSalesDiscountPct.Text = "0.00"
                    txtSalesDiscountAmt.Text = "0.00"
                    txtSalesMarginPct.Text = "0.00"
                    chkIsActive.Checked = True
                    chkIsFormula.Checked = False
                    chkIsInventory.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtItemCategoryName.ClientID)
        End Sub

        Private Sub _Save()
            '// Here goes the validations...
            If Len(RadComboBoxItemCategoryID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Category ID cannot empty.")
                Exit Sub
            End If

            If Len(txtItemCategoryName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Category Name cannot empty.")
                commonFunction.Focus(Me, txtItemCategoryName.ClientID)
                Exit Sub
            End If

            If IsNumeric(txtSalesDiscountPct.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Sales Discount ( % ) must be numeric.")
                commonFunction.Focus(Me, txtSalesDiscountPct.ClientID)
                Exit Sub
            End If

            If IsNumeric(txtSalesDiscountAmt.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Sales Discount Amount must be numeric.")
                commonFunction.Focus(Me, txtSalesDiscountAmt.ClientID)
                Exit Sub
            End If

            If CDec(txtSalesDiscountPct.Text.Trim) < 0 Or CDec(txtSalesDiscountPct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Sales Discount ( % ) must be between 0 - 100.")
                commonFunction.Focus(Me, txtSalesDiscountPct.ClientID)
                Exit Sub
            End If

            If CDec(txtSalesDiscountAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Sales Discount Amount must be equal or greater than 0.")
                commonFunction.Focus(Me, txtSalesDiscountAmt.ClientID)
                Exit Sub
            End If

            If CDec(txtSalesDiscountPct.Text.Trim) > 0 And CDec(txtSalesDiscountAmt.Text.Trim) > 0 Then
                commonFunction.MsgBox(Me, "Sales Discount Pct or Sales Discount Amount must be completed one.")
                commonFunction.Focus(Me, txtSalesDiscountPct.ClientID)
                Exit Sub
            End If

            If IsNumeric(txtSalesMarginPct.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Sales Margin ( % ) must be numeric.")
                commonFunction.Focus(Me, txtSalesMarginPct.ClientID)
                Exit Sub
            End If

            If CDec(txtSalesMarginPct.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Sales Margin ( % ) must be greater than 0.")
                commonFunction.Focus(Me, txtSalesMarginPct.ClientID)
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemCategory
            Dim fNew As Boolean = True

            With br
                .ItemCategoryID = RadComboBoxItemCategoryID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .ItemCategoryID = RadComboBoxItemCategoryID.Text.Trim
                .ItemCategoryName = txtItemCategoryName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500)
                .SalesDiscountPct = CDec(Left(Replace(txtSalesDiscountPct.Text.Trim, ",", ""), 16))
                .SalesDiscountAmt = CDec(Left(Replace(txtSalesDiscountAmt.Text.Trim, ",", ""), 16))
                .MarginPct = CDec(Left(Replace(txtSalesMarginPct.Text.Trim, ",", ""), 16))
                .IsFormula = chkIsFormula.Checked
                .IsInventory = chkIsInventory.Checked
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        _Open(RavenRecStatus.CurrentRecord)
                        UpdateViewGridItemCategory()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxItemCategoryID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemCategory

            With br
                .ItemCategoryID = RadComboBoxItemCategoryID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxItemCategoryID.ClientID)
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

        Private Sub PrepareScreen()
            RadComboBoxItemCategoryID.Text = String.Empty
            txtItemCategoryName.Text = String.Empty
            txtDescription.Text = String.Empty
            txtSalesDiscountPct.Text = "0.00"
            txtSalesDiscountAmt.Text = "0.00"
            txtSalesMarginPct.Text = "0.00"
            chkIsActive.Checked = True
            chkIsFormula.Checked = False
            chkIsInventory.Checked = True
            UpdateViewGridItemCategory()
        End Sub

        Private Sub LoadItemCategory(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemCategory

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ItemCategoryID LIKE '" + Filter.Trim + "%' OR ItemCategoryName LIKE '" + Filter.Trim + "%'"

            RadComboBoxItemCategoryID.DataSource = dv
            RadComboBoxItemCategoryID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItemCategory()
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemCategory

            dt = br.SelectAll

            RadGridItemCategory.DataSource = dt.DefaultView
            RadGridItemCategory.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace