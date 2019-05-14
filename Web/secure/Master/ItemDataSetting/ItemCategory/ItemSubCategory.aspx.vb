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

    Public Class ItemSubCategory
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "211"
        Protected WithEvents lblItemCategoryID As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemCategoryName As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemSubCategoryIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemSubCategoryNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesDiscountPctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSalesDiscountAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtItemSubCategoryName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSalesDiscountPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSalesDiscountAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxItemSubCategoryID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridItemSubCategory As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxItemSubCategoryID.IsCallBack Then
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

        Private Sub RadComboBoxItemSubCategoryID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSubCategoryID.ItemsRequested
            If Len(ItemCategoryIDTmp.Trim) > 0 Then
                Dim combo As RadComboBox = CType(o, RadComboBox)
                combo.Items.Clear()

                LoadItemSubCategory(e.Text, ItemCategoryIDTmp.Trim)
            End If
        End Sub

        Private Sub RadComboBoxItemSubCategoryID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSubCategoryID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemSubCategoryID").ToString()
        End Sub

        Private Sub RadComboBoxItemSubCategoryID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSubCategoryID.SelectedIndexChanged
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
        Private Sub RadGridItemSubCategory_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridItemSubCategory.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblItemSubCategoryID As Label = CType(e.Item.FindControl("_lblItemSubCategoryID"), Label)

                    RadComboBoxItemSubCategoryID.Text = _lblItemSubCategoryID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxItemSubCategoryID.Text.Trim) = 0 Or Len(lblItemCategoryID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemSubCategory

            With br
                .ItemSubCategoryID = RadComboBoxItemSubCategoryID.Text.Trim
                .ItemCategoryID = lblItemCategoryID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxItemSubCategoryID.Text = .ItemSubCategoryID.Trim
                    End If
                    txtItemSubCategoryName.Text = .ItemSubCategoryName.Trim
                    txtDescription.Text = .Description.Trim
                    txtSalesDiscountPct.Text = Format(.SalesDiscountPct, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesDiscountAmt.Text = Format(.SalesDiscountAmt, commonFunction.FORMAT_CURRENCY).Trim
                    chkIsActive.Checked = .IsActive
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtItemSubCategoryName.Text = String.Empty
                    txtDescription.Text = String.Empty
                    txtSalesDiscountPct.Text = "0.00"
                    txtSalesDiscountAmt.Text = "0.00"
                    chkIsActive.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtItemSubCategoryName.ClientID)
        End Sub

        Private Sub _OpenItemCategory(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(lblItemCategoryID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemCategory

            With br
                .ItemCategoryID = lblItemCategoryID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    lblItemCategoryName.Text = .ItemCategoryName.Trim
                Else
                    lblItemCategoryID.Text = String.Empty
                    lblItemCategoryName.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxItemSubCategoryID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Sub Category ID cannot empty.")
                Exit Sub
            End If

            If Len(txtItemSubCategoryName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Sub Category Name cannot empty.")
                commonFunction.Focus(Me, txtItemSubCategoryName.ClientID)
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

            Dim br As New BussinessRules.ItemSubCategory
            Dim fNew As Boolean = True

            With br
                .ItemSubCategoryID = RadComboBoxItemSubCategoryID.Text.Trim
                .ItemCategoryID = lblItemCategoryID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .ItemCategoryID = lblItemCategoryID.Text.Trim
                .ItemSubCategoryID = RadComboBoxItemSubCategoryID.Text.Trim
                .ItemSubCategoryName = txtItemSubCategoryName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500)
                .SalesDiscountPct = CDec(Left(Replace(txtSalesDiscountPct.Text.Trim, ",", ""), 16))
                .SalesDiscountAmt = CDec(Left(Replace(txtSalesDiscountAmt.Text.Trim, ",", ""), 16))
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
                        UpdateViewGridItemSubCategory()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxItemSubCategoryID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemSubCategory

            With br
                .ItemSubCategoryID = RadComboBoxItemSubCategoryID.Text.Trim
                .ItemCategoryID = lblItemCategoryID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxItemSubCategoryID.ClientID)
        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean
            lblItemCategoryID.Text = (Request.QueryString("cid")).Trim
            Return (Len(lblItemCategoryID.Text.Trim) > 0)
        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            If ReadQueryString() = True Then
                _OpenItemCategory(RavenRecStatus.CurrentRecord)
                ItemCategoryIDTmp = lblItemCategoryID.Text.Trim
            Else
                lblItemCategoryID.Text = String.Empty
                lblItemCategoryName.Text = String.Empty
            End If

            RadComboBoxItemSubCategoryID.Text = String.Empty
            txtItemSubCategoryName.Text = String.Empty
            txtDescription.Text = String.Empty
            txtSalesDiscountPct.Text = "0.00"
            txtSalesDiscountAmt.Text = "0.00"
            chkIsActive.Checked = True
            UpdateViewGridItemSubCategory()
        End Sub

        Private Sub LoadItemSubCategory(ByVal Filter As String, ByVal ItemCategoryID As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemSubCategory

            br.ItemCategoryID = ItemCategoryID.Trim
            dt = br.SelectByItemCategoryID

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ItemSubCategoryID LIKE '" + Filter.Trim + "%' OR ItemSubCategoryName LIKE '" + Filter.Trim + "%'"

            RadComboBoxItemSubCategoryID.DataSource = dv
            RadComboBoxItemSubCategoryID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItemSubCategory()
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemSubCategory

            br.ItemCategoryID = lblItemCategoryID.Text.Trim
            dt = br.SelectByItemCategoryID

            RadGridItemSubCategory.DataSource = dt.DefaultView
            RadGridItemSubCategory.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace