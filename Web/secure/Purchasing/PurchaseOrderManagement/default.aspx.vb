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

    Public Class PurchaseOrderManagement
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "340"

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList

        Protected WithEvents RadPOrdExpiredDate As RadDatePicker
        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnRefresh As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnApproval As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnClose As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnRelease As System.Web.UI.WebControls.LinkButton

        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridUnapprovedPurchaseOrderManagement As DataGrid
        Protected WithEvents RadGridPurchaseOrderManagement As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxEntitiesID.IsCallBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub LinkButton_OnClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtnRefresh.Click, lbtnApproval.Click, lbtnClose.Click, lbtnRelease.Click
            Select Case CType(sender, LinkButton).ID
                Case lbtnRefresh.ID
                    PrepareScreen()
                Case lbtnRelease.ID
                    _Release()
                Case lbtnApproval.ID
                    _Approval()
                Case _lbtnClose.ID
                    _Close()
            End Select
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesName").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesID.SelectedIndexChanged
            commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName)
            UpdateViewGridUnapprovedPurchaseOrderManagement()
            UpdateViewGridPurchaseOrderManagement()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            UpdateViewGridUnapprovedPurchaseOrderManagement()
            UpdateViewGridPurchaseOrderManagement()
        End Sub

        Private Sub RadPOrdExpiredDate_SelectedDateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadPOrdExpiredDate.SelectedDateChanged
            UpdateViewGridUnapprovedPurchaseOrderManagement()
            UpdateViewGridPurchaseOrderManagement()
        End Sub
#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "
        Private Sub _Approval()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridUnapprovedPurchaseOrderManagement.Items
                Dim _chkIsSelected As CheckBox = CType(_item.FindControl("_chkIsSelected"), CheckBox)
                Dim _lblPOrdNO As Label = CType(_item.FindControl("_lblPOrdNO"), Label)

                If _chkIsSelected.Checked Then
                    Dim brhd As New BussinessRules.PurchaseOrderHd
                    With brhd
                        .POrdNO = _lblPOrdNO.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            If Not .IsApproval Then
                                Dim row As DataRow = tblTmp.NewRow
                                row("chkIsSelected") = _chkIsSelected.Checked
                                row("POrdNO") = _lblPOrdNO.Text.Trim
                                tblTmp.Rows.Add(row)
                                totalRowSelected += 1
                            End If
                        End If
                    End With
                    brhd.Dispose()
                    brhd = Nothing
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PurchaseOrderHd
                With br
                    For Each _row As DataRow In tblTmp.Rows
                        .POrdNO = CType(_row("POrdNo"), String).Trim
                        If .SelectOne.Rows.Count > 0 Then
                            .IsApproval = CType(_row("chkIsSelected"), Boolean)
                            .UserApproval = MyBase.LoggedOnUserID.Trim
                            .Update()
                        End If
                    Next
                End With
                br.Dispose()
                br = Nothing

                UpdateViewGridUnapprovedPurchaseOrderManagement()
            Else
                commonFunction.MsgBox(Me, "You have to choose at least one record to be Approved.")
                Exit Sub
            End If
        End Sub

        Private Sub _Close()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridUnapprovedPurchaseOrderManagement.Items
                Dim _chkIsSelected As CheckBox = CType(_item.FindControl("_chkIsSelected"), CheckBox)
                Dim _lblPOrdNO As Label = CType(_item.FindControl("_lblPOrdNO"), Label)

                If _chkIsSelected.Checked Then
                    Dim brhd As New BussinessRules.PurchaseOrderHd
                    With brhd
                        .POrdNO = _lblPOrdNO.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            If Not .IsApproval Then
                                Dim row As DataRow = tblTmp.NewRow
                                row("chkIsSelected") = _chkIsSelected.Checked
                                row("POrdNO") = _lblPOrdNO.Text.Trim
                                tblTmp.Rows.Add(row)
                                totalRowSelected += 1
                            End If
                        End If
                    End With
                    brhd.Dispose()
                    brhd = Nothing
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PurchaseOrderHd
                With br
                    For Each _row As DataRow In tblTmp.Rows
                        .POrdNO = CType(_row("POrdNo"), String).Trim
                        If .SelectOne.Rows.Count > 0 Then
                            Dim brdt As New BussinessRules.PurchaseOrderDt
                            brdt.POrdNO = CType(_row("POrdNo"), String).Trim
                            brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                            brdt.DeleteAllByPOrdNO()
                            brdt.Dispose()
                            brdt = Nothing

                            .UserDelete = MyBase.LoggedOnUserID.Trim
                            .Delete()
                        End If
                    Next
                End With
                br.Dispose()
                br = Nothing

                UpdateViewGridUnapprovedPurchaseOrderManagement()
            Else
                commonFunction.MsgBox(Me, "You have to choose at least one record to be Closed.")
                Exit Sub
            End If
        End Sub

        Private Sub _Release()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridPurchaseOrderManagement.Items
                Dim _chkIsSelected As CheckBox = CType(_item.FindControl("_chkIsSelected"), CheckBox)
                Dim _lblPOrdNO As Label = CType(_item.FindControl("_lblPOrdNO"), Label)

                If _chkIsSelected.Checked Then
                    Dim brhd As New BussinessRules.PurchaseOrderHd
                    With brhd
                        .POrdNO = _lblPOrdNO.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            If Not .IsApproval Then
                                commonFunction.MsgBox(Me, "PO No. " + .POrdNO.Trim + " is not approved.")
                                brhd.Dispose()
                                brhd = Nothing
                                Exit Sub
                            End If
                        End If
                    End With
                    brhd.Dispose()
                    brhd = Nothing

                    Dim row As DataRow = tblTmp.NewRow
                    row("chkIsSelected") = _chkIsSelected.Checked
                    row("POrdNO") = _lblPOrdNO.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.PurchaseOrderDt
                With br
                    If br.UpdateStatusRelease(tblTmp, MyBase.LoggedOnUserID.Trim) Then UpdateViewGridPurchaseOrderManagement()
                End With
                br.Dispose()
                br = Nothing
            Else
                commonFunction.MsgBox(Me, "You have to choose at least one record to be Released.")
                Exit Sub
            End If
        End Sub

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("chkIsSelected", System.Type.GetType("System.Boolean"))
                .Columns.Add("POrdNO", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

#End Region

#Region " Main Function (Custom) "


#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareScreen()
            'Dim cr As New BussinessRules.PurchaseOrderHd
            'cr.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedItem.Value.Trim
            'commonFunction.LoadDDL(ddlCurrency, "CurrencyName", "Currency", cr.SelectAllForCurrency, False)
            'cr.Dispose()
            'cr = Nothing

            txtEntitiesName.Text = String.Empty

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            RadPOrdExpiredDate.SelectedDate = Date.Now

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            UpdateViewGridUnapprovedPurchaseOrderManagement()
            UpdateViewGridPurchaseOrderManagement()
        End Sub

        Private Sub UpdateViewGridUnapprovedPurchaseOrderManagement()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderDt

            dt = br.SelectForViewGridPOManagement(RadPOrdExpiredDate.SelectedDate.Value, RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, False)

            RadGridUnapprovedPurchaseOrderManagement.DataSource = dt.DefaultView
            RadGridUnapprovedPurchaseOrderManagement.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPurchaseOrderManagement()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderDt

            dt = br.SelectForViewGridPOManagement(RadPOrdExpiredDate.SelectedDate.Value, RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, True)

            RadGridPurchaseOrderManagement.DataSource = dt.DefaultView
            RadGridPurchaseOrderManagement.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderHd

            dt = br.SelectAllForEntitiesSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace