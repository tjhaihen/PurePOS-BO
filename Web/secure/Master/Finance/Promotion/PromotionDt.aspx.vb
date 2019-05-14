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

Namespace Raven.Web.Secure.Master.Finance

    Public Class Promotiondt
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "255"
        Protected WithEvents lblPromotionDetailCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblID As System.Web.UI.WebControls.Label
        Protected WithEvents lblPromotionName As System.Web.UI.WebControls.Label
        Protected WithEvents lbtnAddBrandName As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnRemoveBrandName As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnAddItemCategory As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnRemoveItemCategory As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnAddItemSubCategory As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnRemoveItemSubCategory As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnAdd As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnRemove As System.Web.UI.WebControls.LinkButton
        'Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadGridBrandName As DataGrid
        Protected WithEvents RadGridPromotionBrandName As DataGrid
        Protected WithEvents RadGridItemCategory As DataGrid
        Protected WithEvents RadGridPromotionItemCategory As DataGrid
        Protected WithEvents RadGridItemSubCategory As DataGrid
        Protected WithEvents RadGridPromotionItemSubCategory As DataGrid
        Protected WithEvents RadGridItems As DataGrid
        Protected WithEvents RadGridPromotiondt As DataGrid

        Protected WithEvents txtSearchItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbtnApplyFilter As System.Web.UI.WebControls.LinkButton

        Protected WithEvents pnlPromotionBrandName As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlPromotionItemCategory As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlPromotionItemSubCategory As System.Web.UI.WebControls.Panel
        Protected WithEvents pnlPromotionItem As System.Web.UI.WebControls.Panel
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                If ReadQueryString() = True Then
                    PrepareScreen()
                    DataBind()
                End If
                ' setToolbarVisibledButton()
            End If
        End Sub

        Private Sub lbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnApplyFilter.Click, lbtnAdd.Click, lbtnRemove.Click, lbtnAddBrandName.Click, lbtnRemoveBrandName.Click, lbtnAddItemCategory.Click, lbtnRemoveItemCategory.Click, lbtnAddItemSubCategory.Click, lbtnRemoveItemSubCategory.Click
            Select Case CType(sender, LinkButton).ID
                Case lbtnApplyFilter.ID
                    UpdateViewMaster("PromotionItem", txtSearchItemName.Text.Trim.Replace("*", "%"))

                Case lbtnAdd.ID
                    _add()

                Case lbtnRemove.ID
                    _Remove()

                Case lbtnAddBrandName.ID
                    _AddPromotionBrandName()

                Case lbtnRemoveBrandName.ID
                    _RemoveBrandName()

                Case lbtnAddItemCategory.ID
                    _AddPromotionItemCategory()

                Case lbtnRemoveItemCategory.ID
                    _RemoveItemCategory()

                Case lbtnAddItemSubCategory.ID
                    _AddPromotionItemSubCategory()

                Case lbtnRemoveItemSubCategory.ID
                    _RemoveItemSubCategory()
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Add()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridItems.Items
                Dim _chkAdd As CheckBox = CType(_item.FindControl("_chkAdd"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemSeqNo"), Label)

                If _chkAdd.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkAdd.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim brhd As New BussinessRules.PromotionHd
                With brhd
                    brhd.ID = lblID.Text.Trim
                    If brhd.SelectOne.Rows.Count = 0 Then
                        commonFunction.MsgBox(Me, "Record cannot be deleted due to inconsistency.")
                        Exit Sub
                    End If
                End With
                brhd.Dispose()
                brhd = Nothing

                Dim br As New BussinessRules.Promotiondt
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemSeqNo = ProcessNull.GetString(row("ID"))
                        .Insert()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(txtSearchItemName.Text.Trim.Replace("*", "%"))
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be added.")
                Exit Sub
            End If
        End Sub

        Private Sub _AddPromotionBrandName()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridBrandName.Items
                Dim _chkAdd As CheckBox = CType(_item.FindControl("_chkAddBrandName"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblBrandID"), Label)

                If _chkAdd.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkAdd.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim brhd As New BussinessRules.PromotionHd
                With brhd
                    brhd.ID = lblID.Text.Trim
                    If brhd.SelectOne.Rows.Count = 0 Then
                        commonFunction.MsgBox(Me, "Record cannot be deleted due to inconsistency.")
                        Exit Sub
                    End If
                End With
                brhd.Dispose()
                brhd = Nothing

                Dim br As New BussinessRules.PromotionBrandNameID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .BrandNameID = ProcessNull.GetString(row("ID"))
                        .Insert()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be added.")
                Exit Sub
            End If
        End Sub

        Private Sub _AddPromotionItemCategory()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridItemCategory.Items
                Dim _chkAdd As CheckBox = CType(_item.FindControl("_chkAddItemCategory"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemCategoryID"), Label)

                If _chkAdd.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkAdd.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim brhd As New BussinessRules.PromotionHd
                With brhd
                    brhd.ID = lblID.Text.Trim
                    If brhd.SelectOne.Rows.Count = 0 Then
                        commonFunction.MsgBox(Me, "Record cannot be deleted due to inconsistency.")
                        Exit Sub
                    End If
                End With
                brhd.Dispose()
                brhd = Nothing

                Dim br As New BussinessRules.PromotionItemCategoryID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemCategoryID = ProcessNull.GetString(row("ID"))
                        .Insert()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be added.")
                Exit Sub
            End If
        End Sub

        Private Sub _AddPromotionItemSubCategory()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridItemSubCategory.Items
                Dim _chkAdd As CheckBox = CType(_item.FindControl("_chkAddItemSubCategory"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemSubCategoryID"), Label)

                If _chkAdd.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkAdd.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim brhd As New BussinessRules.PromotionHd
                With brhd
                    brhd.ID = lblID.Text.Trim
                    If brhd.SelectOne.Rows.Count = 0 Then
                        commonFunction.MsgBox(Me, "Record cannot be deleted due to inconsistency.")
                        Exit Sub
                    End If
                End With
                brhd.Dispose()
                brhd = Nothing

                Dim br As New BussinessRules.PromotionItemSubCategoryID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemSubCategoryID = ProcessNull.GetString(row("ID"))
                        .Insert()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be added.")
                Exit Sub
            End If
        End Sub

        Private Sub _Remove()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPromotiondt.Items
                Dim _chkRemove As CheckBox = CType(_item.FindControl("_chkRemove"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemSeqNoPdt"), Label)

                If _chkRemove.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkRemove.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.Promotiondt
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemSeqNo = ProcessNull.GetString(row("ID"))
                        .Delete()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(txtSearchItemName.Text.Trim.Replace("*", "%"))
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be removed.")
                Exit Sub
            End If
        End Sub

        Private Sub _RemoveBrandName()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPromotionBrandName.Items
                Dim _chkRemove As CheckBox = CType(_item.FindControl("_chkRemovePromotionBrandName"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblBrandNameIDPdt"), Label)

                If _chkRemove.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkRemove.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PromotionBrandNameID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .BrandNameID = ProcessNull.GetString(row("ID"))
                        .Delete()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be removed.")
                Exit Sub
            End If
        End Sub

        Private Sub _RemoveItemCategory()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPromotionItemCategory.Items
                Dim _chkRemove As CheckBox = CType(_item.FindControl("_chkRemovePromotionItemCategory"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemCategoryIDPdt"), Label)

                If _chkRemove.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkRemove.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PromotionItemCategoryID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemCategoryID = ProcessNull.GetString(row("ID"))
                        .Delete()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be removed.")
                Exit Sub
            End If
        End Sub

        Private Sub _RemoveItemSubCategory()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPromotionItemSubCategory.Items
                Dim _chkRemove As CheckBox = CType(_item.FindControl("_chkRemovePromotionItemSubCategory"), CheckBox)
                Dim _lblID As Label = CType(_item.FindControl("_lblItemSubCategoryIDPdt"), Label)

                If _chkRemove.Checked Then
                    Dim row As DataRow = tblTmp.NewRow
                    row("isChk") = _chkRemove.Checked
                    row("ID") = _lblID.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PromotionItemSubCategoryID
                With br
                    For Each row As DataRow In tblTmp.Rows
                        .ID = lblID.Text.Trim
                        .ItemSubCategoryID = ProcessNull.GetString(row("ID"))
                        .Delete()
                    Next
                End With

                br.Dispose()
                br = Nothing

                ShowHidePanelAndLoadDataGrid(String.Empty)
            Else
                commonFunction.MsgBox(Me, "You have to choose at least 1 (one) record to be removed.")
                Exit Sub
            End If
        End Sub

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("isChk", System.Type.GetType("System.Boolean"))
                .Columns.Add("ID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean
            Dim strPromotionDetailCaption As String = String.Empty
            strPromotionDetailCaption = Common.ProcessNull.GetString((Request.QueryString("pdc")).Trim)

            Select Case strPromotionDetailCaption.Trim
                Case "PromotionBrandName"
                    lblPromotionDetailCaption.Text = "Promotion Brand Name"

                Case "PromotionItemCategory"
                    lblPromotionDetailCaption.Text = "Promotion Item Category"

                Case "PromotionItemSubCategory"
                    lblPromotionDetailCaption.Text = "Promotion Item Sub Category"

                Case "PromotionItem"
                    lblPromotionDetailCaption.Text = "Promotion Item"
            End Select

            lblID.Text = Common.ProcessNull.GetString((Request.QueryString("pid")).Trim)
            lblPromotionName.Text = Common.ProcessNull.GetString((Request.QueryString("pnid")).Trim)
            Return (Len(lblID.Text.Trim) > 0)
        End Function

        Private Sub PrepareScreen()
            ShowHidePanelAndLoadDataGrid(String.Empty)
        End Sub

        Private Sub ShowHidePanelAndLoadDataGrid(ByVal strItemName As String)
            If lblPromotionDetailCaption.Text.Trim.Length > 0 Then
                Select Case lblPromotionDetailCaption.Text.Trim
                    Case "Promotion Brand Name"
                        commonFunction.ShowPanel(pnlPromotionBrandName, True)
                        commonFunction.ShowPanel(pnlPromotionItemCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItemSubCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItem, False)
                        UpdateViewMaster("PromotionBrandName", String.Empty)
                        UpdateViewPromotionDt("PromotionBrandName")

                    Case "Promotion Item Category"
                        commonFunction.ShowPanel(pnlPromotionBrandName, False)
                        commonFunction.ShowPanel(pnlPromotionItemCategory, True)
                        commonFunction.ShowPanel(pnlPromotionItemSubCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItem, False)
                        UpdateViewMaster("PromotionItemCategory", String.Empty)
                        UpdateViewPromotionDt("PromotionItemCategory")

                    Case "Promotion Item Sub Category"
                        commonFunction.ShowPanel(pnlPromotionBrandName, False)
                        commonFunction.ShowPanel(pnlPromotionItemCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItemSubCategory, True)
                        commonFunction.ShowPanel(pnlPromotionItem, False)
                        UpdateViewMaster("PromotionItemSubCategory", String.Empty)
                        UpdateViewPromotionDt("PromotionItemSubCategory")

                    Case "Promotion Item"
                        commonFunction.ShowPanel(pnlPromotionBrandName, False)
                        commonFunction.ShowPanel(pnlPromotionItemCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItemSubCategory, False)
                        commonFunction.ShowPanel(pnlPromotionItem, True)
                        UpdateViewMaster("PromotionItem", strItemName.Trim)
                        UpdateViewPromotionDt("PromotionItem")
                        commonFunction.Focus(Me, txtSearchItemName.ClientID)
                End Select
            Else
                commonFunction.ShowPanel(pnlPromotionBrandName, False)
                commonFunction.ShowPanel(pnlPromotionItemCategory, False)
                commonFunction.ShowPanel(pnlPromotionItemSubCategory, False)
                commonFunction.ShowPanel(pnlPromotionItem, False)
            End If
        End Sub

        Private Sub UpdateViewPromotionDt(ByVal strPromotionGroup As String)
            Dim dt As DataTable

            Select Case strPromotionGroup.Trim
                Case "PromotionBrandName"
                    Dim br As New BussinessRules.PromotionBrandNameID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllByID

                    RadGridPromotionBrandName.DataSource = dt.DefaultView
                    RadGridPromotionBrandName.DataBind()

                    br.Dispose()
                    br = Nothing

                Case "PromotionItemCategory"
                    Dim br As New BussinessRules.PromotionItemCategoryID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllByID

                    RadGridPromotionItemCategory.DataSource = dt.DefaultView
                    RadGridPromotionItemCategory.DataBind()

                    br.Dispose()
                    br = Nothing

                Case "PromotionItemSubCategory"
                    Dim br As New BussinessRules.PromotionItemSubCategoryID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllByID

                    RadGridPromotionItemSubCategory.DataSource = dt.DefaultView
                    RadGridPromotionItemSubCategory.DataBind()

                    br.Dispose()
                    br = Nothing

                Case "PromotionItem"
                    Dim br As New BussinessRules.Promotiondt
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllByID

                    RadGridPromotiondt.DataSource = dt.DefaultView
                    RadGridPromotiondt.DataBind()

                    br.Dispose()
                    br = Nothing
            End Select

            dt.Dispose()
            dt = Nothing
        End Sub

        Private Sub UpdateViewMaster(ByVal strPromotionGroup As String, ByVal strItemName As String)
            Dim dt As DataTable

            Select Case strPromotionGroup.Trim
                Case "PromotionBrandName"
                    Dim br As New BussinessRules.PromotionBrandNameID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllForGridItem()
                    br.Dispose()
                    br = Nothing

                    RadGridBrandName.DataSource = dt.DefaultView
                    RadGridBrandName.DataBind()

                Case "PromotionItemCategory"
                    Dim br As New BussinessRules.PromotionItemCategoryID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllForGridItem()
                    br.Dispose()
                    br = Nothing

                    RadGridItemCategory.DataSource = dt.DefaultView
                    RadGridItemCategory.DataBind()

                Case "PromotionItemSubCategory"
                    Dim br As New BussinessRules.PromotionItemSubCategoryID
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllForGridItem()
                    br.Dispose()
                    br = Nothing

                    RadGridItemSubCategory.DataSource = dt.DefaultView
                    RadGridItemSubCategory.DataBind()

                Case "PromotionItem"
                    Dim br As New BussinessRules.Promotiondt
                    br.ID = lblID.Text.Trim
                    dt = br.SelectAllForGridItem(strItemName.Trim)
                    br.Dispose()
                    br = Nothing

                    RadGridItems.DataSource = dt.DefaultView
                    RadGridItems.DataBind()
            End Select

            dt.Dispose()
            dt = Nothing
        End Sub


#End Region

        Private Sub InitializeComponent()

        End Sub
    End Class
End Namespace