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

Namespace Raven.Web.Secure.Transaction

    Public Class DeliveryOrderManagement
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "511"

        Protected WithEvents ddlWhID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDeliveryZone As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents RadDueDate As RadDatePicker
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridDeliveryOrderManagement As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxEntitiesID.IsCallBack Then
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

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
                Case CSSToolbarItem.tidSave
                    _Save()
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
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub ddlUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnitID.SelectedIndexChanged
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub ddlDeliveryZone_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDeliveryZone.SelectedIndexChanged
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub RadDueDate_SelectedDateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadDueDate.SelectedDateChanged
            UpdateViewGridDeliveryOrderManagement()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridDeliveryOrderManagement_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridDeliveryOrderManagement.ItemCommand
            Select Case e.CommandName
                Case "Print"
                    Dim _lblDONo As Label = CType(e.Item.FindControl("_lblDONO"), Label)
                    _Print(_lblDONo.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Save()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridDeliveryOrderManagement.Items
                Dim _chkIsRelease As CheckBox = CType(_item.FindControl("_chkIsRelease"), CheckBox)
                Dim _lblDONO As Label = CType(_item.FindControl("_lblDONO"), Label)

                If _chkIsRelease.Checked Then

                    Dim brhd As New BussinessRules.DeliveryOrderHd
                    With brhd
                        .DONo = _lblDONO.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            If Not .IsApproval Then
                                commonFunction.MsgBox(Me, "PO No. " + .DONo.Trim + " is not approved.")
                                brhd.Dispose()
                                brhd = Nothing
                                Exit Sub
                            End If
                        End If
                    End With
                    brhd.Dispose()
                    brhd = Nothing

                    Dim row As DataRow = tblTmp.NewRow
                    row("chkIsRelease") = _chkIsRelease.Checked
                    row("DONO") = _lblDONO.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.DeliveryOrderDt
                With br
                    br.UserUpdate = MyBase.LoggedOnUserID.Trim
                    If br.UpdateStatusRelease(tblTmp) Then UpdateViewGridDeliveryOrderManagement()
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
                .Columns.Add("chkIsRelease", System.Type.GetType("System.Boolean"))
                .Columns.Add("DONO", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

#End Region

#Region " Main Function (Custom) "

        Private Sub _Print(ByVal DONo As String)
            If Len(DONo.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.DeliveryOrderHd

            With br
                .DONo = DONo.Trim
                .UserPrinted = MyBase.LoggedOnUserID.Trim
                If .UpdatePrint() Then
                    Dim oprintform As New BussinessRules.PrintForm
                    With oprintform
                        .PrintFormID = 5111
                        .MenuID = CInt(ModuleId.Trim)
                        .AddParametersPrintForm(DONo.Trim)
                        .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                        Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                    End With
                    oprintform.Dispose()
                    oprintform = Nothing
                    UpdateViewGridDeliveryOrderManagement()
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

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
                .VisibleButton(CSSToolbarItem.tidDelete) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            txtEntitiesName.Text = String.Empty

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, True)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), True)
            whunit.Dispose()
            whunit = Nothing

            Dim oDeliveryZone As New BussinessRules.DeliveryZoneHd
            commonFunction.LoadDDL(ddlDeliveryZone, "DeliveryZoneName", "DeliveryZoneID", oDeliveryZone.SelectAllActive, True)
            oDeliveryZone.Dispose()
            oDeliveryZone = Nothing

            RadDueDate.SelectedDate = Date.Now

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            UpdateViewGridDeliveryOrderManagement()
        End Sub

        Private Sub UpdateViewGridDeliveryOrderManagement()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderDt

            dt = br.SelectForViewGridDOManagement(RadDueDate.SelectedDate.Value, RadComboBoxEntitiesID.SelectedValue.Trim, ddlCurrency.SelectedValue.Trim, ddlWhID.SelectedValue.Trim, ddlUnitID.SelectedValue.Trim, ddlDeliveryZone.SelectedValue.Trim)

            RadGridDeliveryOrderManagement.DataSource = dt.DefaultView
            RadGridDeliveryOrderManagement.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderHd

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