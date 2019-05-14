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

    Public Class BalanceInformation
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "420"

        Protected WithEvents RadComboBoxSourceWhID As RadComboBox
        Protected WithEvents RadComboBoxDestinationWhID As RadComboBox
        Protected WithEvents RadComboBoxSourceUnitID As RadComboBox
        Protected WithEvents RadComboBoxDestinationUnitID As RadComboBox
        Protected WithEvents RadComboBoxSourceItemSeqNo As RadComboBox
        Protected WithEvents RadComboBoxDestinationItemSeqNo As RadComboBox

        Protected WithEvents txtSourceWhName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDestinationWhName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSourceUnitName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDestinationUnitName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSourceItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDestinationItemName As System.Web.UI.WebControls.TextBox

        Protected WithEvents Toolbar As CSSToolbar


        'grid
        Protected WithEvents RadGridQuery As DataGrid

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel

        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel



#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxSourceWhID.IsCallBack And _
                'Not RadComboBoxDestinationWhID.IsCallBack And Not RadComboBoxSourceUnitID.IsCallBack And _
                'Not RadComboBoxDestinationUnitID.IsCallBack And Not RadComboBoxSourceItemSeqNo.IsCallBack And _
                'Not RadComboBoxDestinationItemSeqNo.IsCallBack _            
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

        Private Sub RadComboBoxSourceUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSourceUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSourceUnit(e.Text)
        End Sub

        Private Sub RadComboBoxSourceUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSourceUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UnitID").ToString().Trim
        End Sub

        Private Sub RadComboBoxSourceUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSourceUnitID.SelectedIndexChanged
            Dim un As New BussinessRules.Warehouse
            un.UnitID = RadComboBoxSourceUnitID.Text.Trim
            un.IsActive = True
            If un.SelectOneUnitWithOptionalActive.Rows.Count > 0 Then
                txtSourceUnitName.Text = un.UnitName.Trim
            Else
                RadComboBoxSourceUnitID.Text = String.Empty
                txtSourceUnitName.Text = String.Empty
            End If
            un.Dispose()
            un = Nothing
        End Sub

        Private Sub RadComboBoxDestinationUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDestinationUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDestinationUnit(e.Text)
        End Sub

        Private Sub RadComboBoxDestinationUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDestinationUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("UnitID").ToString().Trim
        End Sub

        Private Sub RadComboBoxDestinationUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDestinationUnitID.SelectedIndexChanged
            Dim un As New BussinessRules.Warehouse
            un.UnitID = RadComboBoxDestinationUnitID.Text.Trim
            un.IsActive = True
            If un.SelectOneUnitWithOptionalActive.Rows.Count > 0 Then
                txtDestinationUnitName.Text = un.UnitName.Trim
            Else
                RadComboBoxDestinationUnitID.Text = String.Empty
                txtDestinationUnitName.Text = String.Empty
            End If
            un.Dispose()
            un = Nothing
        End Sub

        Private Sub RadComboBoxSourceWhID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSourceWhID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSourceWarehouse(e.Text)
        End Sub

        Private Sub RadComboBoxSourceWhID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSourceWhID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("WHID").ToString().Trim
        End Sub

        Private Sub RadComboBoxSourceWhID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSourceWhID.SelectedIndexChanged
            Dim wh As New BussinessRules.Warehouse
            wh.WhID = RadComboBoxSourceWhID.Text.Trim
            wh.IsActive = True
            If wh.SelectOneWarehouseWithOptionalActive.Rows.Count > 0 Then
                txtSourceWhName.Text = wh.WhName.Trim
            Else
                RadComboBoxSourceWhID.Text = String.Empty
                txtSourceWhName.Text = String.Empty
            End If
            wh.Dispose()
            wh = Nothing
        End Sub

        Private Sub RadComboBoxDestinationWhID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDestinationWhID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDestinationWarehouse(e.Text)
        End Sub

        Private Sub RadComboBoxDestinationWhID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDestinationWhID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("WHID").ToString().Trim
        End Sub

        Private Sub RadComboBoxDestinationWhID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDestinationWhID.SelectedIndexChanged
            Dim wh As New BussinessRules.Warehouse
            wh.WhID = RadComboBoxDestinationWhID.Text.Trim
            wh.IsActive = True
            If wh.SelectOneWarehouseWithOptionalActive.Rows.Count > 0 Then
                txtDestinationWhName.Text = wh.WhName.Trim
            Else
                RadComboBoxDestinationWhID.Text = String.Empty
                txtDestinationWhName.Text = String.Empty
            End If
            wh.Dispose()
            wh = Nothing
        End Sub


        Private Sub RadComboBoxSourceItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxSourceItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadSourceItem(e.Text)
        End Sub

        Private Sub RadComboBoxSourceItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxSourceItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString().Trim
        End Sub

        Private Sub RadComboBoxSourceItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSourceItemSeqNo.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxSourceItemSeqNo, txtSourceItemName)
        End Sub

        Private Sub RadComboBoxDestinationItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDestinationItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDestinationItem(e.Text)
        End Sub

        Private Sub RadComboBoxDestinationItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDestinationItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString().Trim
        End Sub

        Private Sub RadComboBoxDestinationItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDestinationItemSeqNo.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxDestinationItemSeqNo, txtDestinationItemName)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidOther1
                    UpdateViewGridQuery()
                Case CSSToolbarItem.tidOther2
                    UpdateViewGridQueryCalculateROP()
            End Select
        End Sub
#End Region

#Region " DataGrid Command Center "
        
#End Region

#Region " Main Function (CRUD) "

        
#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidOther1) = True
                .lbtnOther1_Text = "Show"
                .VisibleButton(CSSToolbarItem.tidOther2) = True
                .lbtnOther2_Text = "Calculate ROP"
            End With
        End Sub

        Private Sub PrepareScreenHd()
            RadComboBoxSourceWhID.Text = ""
            RadComboBoxDestinationWhID.Text = ""
            txtSourceWhName.Text = String.Empty
            txtDestinationWhName.Text = String.Empty

            RadComboBoxSourceUnitID.Text = ""
            RadComboBoxDestinationUnitID.Text = ""
            txtSourceUnitName.Text = String.Empty
            txtDestinationUnitName.Text = String.Empty

            RadComboBoxSourceItemSeqNo.Text = ""
            RadComboBoxSourceItemSeqNo.SelectedValue = ""
            RadComboBoxDestinationItemSeqNo.Text = ""
            RadComboBoxDestinationItemSeqNo.SelectedValue = ""
            txtSourceItemName.Text = String.Empty
            txtDestinationItemName.Text = String.Empty

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGrid, True)

            UpdateViewGridQuery(True)
        End Sub

        Private Sub LoadSourceItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSourceItemSeqNo.DataSource = dt.DefaultView
            RadComboBoxSourceItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub
        Private Sub LoadDestinationItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDestinationItemSeqNo.DataSource = dt.DefaultView
            RadComboBoxDestinationItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadSourceWarehouse(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllWarehouseForWHID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSourceWhID.DataSource = dt.DefaultView
            RadComboBoxSourceWhID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadDestinationWarehouse(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllWarehouseForWHID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDestinationWhID.DataSource = dt.DefaultView
            RadComboBoxDestinationWhID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadSourceUnit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllWarehouseForUnitID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxSourceUnitID.DataSource = dt.DefaultView
            RadComboBoxSourceUnitID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadDestinationUnit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectAllWarehouseForUnitID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDestinationUnitID.DataSource = dt.DefaultView
            RadComboBoxDestinationUnitID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridQuery(Optional ByVal IsNew As Boolean = False)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemBalance

            If IsNew Then
                dt = br.SelectAllForBalanceInformation("none", "none", "none", "none", "none", "none")
            Else
                dt = br.SelectAllForBalanceInformation(RadComboBoxSourceWhID.Text.Trim, RadComboBoxDestinationWhID.Text.Trim, _
                                                   RadComboBoxSourceUnitID.Text.Trim, RadComboBoxDestinationUnitID.Text.Trim, _
                                                   RadComboBoxSourceItemSeqNo.SelectedValue.Trim, RadComboBoxDestinationItemSeqNo.SelectedValue.Trim)
            End If

            RadGridQuery.DataSource = dt.DefaultView
            RadGridQuery.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridQueryCalculateROP(Optional ByVal IsNew As Boolean = False)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemBalance

            If IsNew Then
                dt = br.SelectAllForBalanceInformationCalculateROP("none", "none", "none", "none", "none", "none")
            Else
                dt = br.SelectAllForBalanceInformationCalculateROP(RadComboBoxSourceWhID.Text.Trim, RadComboBoxDestinationWhID.Text.Trim, _
                                                   RadComboBoxSourceUnitID.Text.Trim, RadComboBoxDestinationUnitID.Text.Trim, _
                                                   RadComboBoxSourceItemSeqNo.SelectedValue.Trim, RadComboBoxDestinationItemSeqNo.SelectedValue.Trim)
            End If

            RadGridQuery.DataSource = dt.DefaultView
            RadGridQuery.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub
#End Region
    End Class
End Namespace