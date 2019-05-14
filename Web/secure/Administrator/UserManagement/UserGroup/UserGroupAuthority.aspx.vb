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

Namespace Raven.Web.Secure.Administrator

    Public Class UserGroupAuthority
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "111"
        Protected WithEvents lblUserGroupID As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserGroupName As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        'Protected WithEvents RadTreeViewMenu As Telerik.Web.UIRadTreeView
        Protected WithEvents RadGridMenu As DataGrid
        Protected WithEvents RadGridReport As DataGrid
        Protected WithEvents RadGridWarehouseUnit As DataGrid
        Protected WithEvents RadGridInventoryTxn As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If
                setToolbarVisibledButton()
                PrepareScreen()

                DataBind()
            End If
        End Sub
        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
            End Select
        End Sub

#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenUserGroup(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(lblUserGroupID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.UserGroup

            With br
                .UserGroupID = lblUserGroupID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    lblUserGroupName.Text = .UserGroupName.Trim
                Else
                    lblUserGroupID.Text = String.Empty
                    lblUserGroupName.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            Dim totalRowSelected As Integer
            Dim fNotNew As Boolean

            '// ---------------------------------
            '// Begin Menu Authority
            '// ---------------------------------
            Dim tblTmp As DataTable = createTmpTable()
            Dim _item As DataGridItem

            For Each _item In RadGridMenu.Items
                Dim _chkIsAuthorized As CheckBox = CType(_item.FindControl("_chkIsAuthorized"), CheckBox)
                Dim _lblMenuID As Label = CType(_item.FindControl("_lblMenuID"), Label)
                Dim _chkIsAllowRead As CheckBox = CType(_item.FindControl("_chkIsAllowRead"), CheckBox)
                Dim _chkIsAllowEdit As CheckBox = CType(_item.FindControl("_chkIsAllowEdit"), CheckBox)
                Dim _chkIsAllowDelete As CheckBox = CType(_item.FindControl("_chkIsAllowDelete"), CheckBox)

                totalRowSelected += 1

                Dim row As DataRow = tblTmp.NewRow

                row("IsAuthorized") = _chkIsAuthorized.Checked
                row("UserGroupID") = lblUserGroupID.Text.Trim
                row("MenuID") = _lblMenuID.Text.Trim
                row("isAllowRead") = _chkIsAllowRead.Checked
                row("isAllowEdit") = _chkIsAllowEdit.Checked
                row("isAllowDelete") = _chkIsAllowDelete.Checked

                tblTmp.Rows.Add(row)
            Next

            Dim br As New BussinessRules.UserGroupMenu
            With br
                For Each row As DataRow In tblTmp.Rows
                    .UserGroupID = ProcessNull.GetString(row("UserGroupID"))
                    .MenuID = ProcessNull.GetString(row("MenuID"))
                    If .SelectOne.Rows.Count > 0 Then
                        fNotNew = True
                    Else
                        fNotNew = False
                    End If
                    .isAllowRead = ProcessNull.GetBoolean(row("isAllowRead"))
                    .isAllowEdit = ProcessNull.GetBoolean(row("isAllowEdit"))
                    .isAllowDelete = ProcessNull.GetBoolean(row("isAllowDelete"))

                    If ProcessNull.GetBoolean(row("isAuthorized")) = True Then
                        If fNotNew Then
                            .Update()
                        Else
                            .Insert()
                        End If
                    Else
                        .Delete()
                    End If
                Next
            End With

            br.Dispose()
            br = Nothing

            UpdateViewGridMenu()

            '// Reset variable value
            totalRowSelected = 0
            fNotNew = False
            '// ---------------------------------
            '// End Menu Authority
            '// ---------------------------------

            '// ---------------------------------
            '// Begin Report Authority
            '// ---------------------------------            
            Dim tblReportTmp As DataTable = createReportTmpTable()
            Dim _itemReport As DataGridItem

            For Each _itemReport In RadGridReport.Items
                Dim _chkIsReportAuthorized As CheckBox = CType(_itemReport.FindControl("_chkIsReportAuthorized"), CheckBox)
                Dim _lblReportID As Label = CType(_itemReport.FindControl("_lblReportID"), Label)

                totalRowSelected += 1

                Dim row As DataRow = tblReportTmp.NewRow

                row("IsAuthorized") = _chkIsReportAuthorized.Checked
                row("UserGroupID") = lblUserGroupID.Text.Trim
                row("ReportID") = _lblReportID.Text.Trim

                tblReportTmp.Rows.Add(row)
            Next

            Dim brReport As New BussinessRules.UserGroupReport
            With brReport
                For Each row As DataRow In tblReportTmp.Rows
                    .UserGroupID = ProcessNull.GetString(row("UserGroupID"))
                    .ReportID = ProcessNull.GetString(row("ReportID"))
                    If .SelectOne.Rows.Count > 0 Then
                        fNotNew = True
                    Else
                        fNotNew = False
                    End If

                    If ProcessNull.GetBoolean(row("isAuthorized")) = True Then
                        If fNotNew = False Then
                            .Insert()
                        End If
                    Else
                        .Delete()
                    End If
                Next
            End With

            brReport.Dispose()
            brReport = Nothing

            UpdateViewGridReport()

            '// Reset variable value
            totalRowSelected = 0
            fNotNew = False
            '// ---------------------------------
            '// End Report Authority
            '// ---------------------------------  

            '// ---------------------------------
            '// Begin Warehouse Unit Authority
            '// ---------------------------------            
            Dim tblWarehouseUnitTmp As DataTable = createWarehouseUnitTmpTable()
            Dim _itemWarehouseUnit As DataGridItem

            For Each _itemWarehouseUnit In RadGridWarehouseUnit.Items
                Dim _chkIsWarehouseUnitAuthorized As CheckBox = CType(_itemWarehouseUnit.FindControl("_chkIsWarehouseUnitAuthorized"), CheckBox)
                Dim _lblWhID As Label = CType(_itemWarehouseUnit.FindControl("_lblWhID"), Label)
                Dim _lblUnitID As Label = CType(_itemWarehouseUnit.FindControl("_lblUnitID"), Label)

                totalRowSelected += 1

                Dim row As DataRow = tblWarehouseUnitTmp.NewRow

                row("IsAuthorized") = _chkIsWarehouseUnitAuthorized.Checked
                row("UserGroupID") = lblUserGroupID.Text.Trim
                row("WhID") = _lblWhID.Text.Trim
                row("UnitID") = _lblUnitID.Text.Trim

                tblWarehouseUnitTmp.Rows.Add(row)
            Next

            Dim brWarehouseUnit As New BussinessRules.UserGroupWarehouse
            With brWarehouseUnit
                For Each row As DataRow In tblWarehouseUnitTmp.Rows
                    .UserGroupID = ProcessNull.GetString(row("UserGroupID"))
                    .WhID = ProcessNull.GetString(row("WhID"))
                    .UnitID = ProcessNull.GetString(row("UnitID"))
                    If .SelectOne.Rows.Count > 0 Then
                        fNotNew = True
                    Else
                        fNotNew = False
                    End If

                    If ProcessNull.GetBoolean(row("isAuthorized")) = True Then
                        If fNotNew = False Then
                            .Insert()
                        End If
                    Else
                        .Delete()
                    End If
                Next
            End With

            brWarehouseUnit.Dispose()
            brWarehouseUnit = Nothing

            UpdateViewGridWarehouseUnit()

            '// Reset variable value
            totalRowSelected = 0
            fNotNew = False
            '// ---------------------------------
            '// End Warehouse Unit Authority
            '// ---------------------------------  

            '// ---------------------------------
            '// Begin InventoryTxn Authority
            '// ---------------------------------            
            Dim tblInventoryTxnTmp As DataTable = createInventoryTxnTmpTable()
            Dim _itemInventoryTxn As DataGridItem

            For Each _itemInventoryTxn In RadGridInventoryTxn.Items
                Dim _chkIsInventoryTransactionAuthorized As CheckBox = CType(_itemInventoryTxn.FindControl("_chkIsInventoryTransactionAuthorized"), CheckBox)
                Dim _lblInventoryTxnID As Label = CType(_itemInventoryTxn.FindControl("_lblInventoryTxnID"), Label)

                totalRowSelected += 1

                Dim row As DataRow = tblInventoryTxnTmp.NewRow

                row("IsAuthorized") = _chkIsInventoryTransactionAuthorized.Checked
                row("UserGroupID") = lblUserGroupID.Text.Trim
                row("InventoryTxnID") = _lblInventoryTxnID.Text.Trim

                tblInventoryTxnTmp.Rows.Add(row)
            Next

            Dim brInventoryTxn As New BussinessRules.UserGroupInventoryTxn
            With brInventoryTxn
                For Each row As DataRow In tblInventoryTxnTmp.Rows
                    .UserGroupID = ProcessNull.GetString(row("UserGroupID"))
                    .InventoryTxnID = ProcessNull.GetString(row("InventoryTxnID"))
                    If .SelectOne.Rows.Count > 0 Then
                        fNotNew = True
                    Else
                        fNotNew = False
                    End If

                    If ProcessNull.GetBoolean(row("isAuthorized")) = True Then
                        If fNotNew = False Then
                            .Insert()
                        End If
                    Else
                        .Delete()
                    End If
                Next
            End With

            brInventoryTxn.Dispose()
            brInventoryTxn = Nothing

            UpdateViewGridInventoryTxn()

            '// Reset variable value
            totalRowSelected = 0
            fNotNew = False
            '// ---------------------------------
            '// End InventoryTxn Authority
            '// --------------------------------- 
        End Sub

        Private Sub _Delete()
            Page.Validate()
            If Not Page.IsValid Then Exit Sub

            '// ---------------------------------
            '// Begin Menu Authority
            '// --------------------------------- 
            Dim br As New BussinessRules.UserGroupMenu

            With br
                .UserGroupID = lblUserGroupID.Text.Trim
                If .DeleteByUserGroupID() = True Then
                    PrepareScreen()
                End If
            End With

            br.Dispose()
            br = Nothing
            '// ---------------------------------
            '// End Menu Authority
            '// --------------------------------- 

            '// ---------------------------------
            '// Begin Report Authority
            '// --------------------------------- 
            Dim brReport As New BussinessRules.UserGroupReport

            With brReport
                .UserGroupID = lblUserGroupID.Text.Trim
                If .DeleteByUserGroupID() = True Then
                    PrepareScreen()
                End If
            End With

            brReport.Dispose()
            brReport = Nothing
            '// ---------------------------------
            '// End Report Authority
            '// --------------------------------- 

            '// ---------------------------------
            '// Begin Warehouse Unit Authority
            '// --------------------------------- 
            Dim brWarehouseUnit As New BussinessRules.UserGroupWarehouse

            With brWarehouseUnit
                .UserGroupID = lblUserGroupID.Text.Trim
                If .DeleteByUserGroupID() = True Then
                    PrepareScreen()
                End If
            End With

            brWarehouseUnit.Dispose()
            brWarehouseUnit = Nothing
            '// ---------------------------------
            '// End Warehouse Unit Authority
            '// --------------------------------- 

            '// ---------------------------------
            '// Begin InventoryTxn Authority
            '// --------------------------------- 
            Dim brInventoryTxn As New BussinessRules.UserGroupInventoryTxn

            With brInventoryTxn
                .UserGroupID = lblUserGroupID.Text.Trim
                If .DeleteByUserGroupID() = True Then
                    PrepareScreen()
                End If
            End With

            brInventoryTxn.Dispose()
            brInventoryTxn = Nothing
            '// ---------------------------------
            '// End InventoryTxn Authority
            '// ---------------------------------
        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean
            lblUserGroupID.Text = (Request.QueryString("ugid")).Trim
            Return (Len(lblUserGroupID.Text.Trim) > 0)
        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            If ReadQueryString() = True Then
                _OpenUserGroup(RavenRecStatus.CurrentRecord)
            Else
                lblUserGroupID.Text = String.Empty
                lblUserGroupName.Text = String.Empty
            End If

            UpdateViewGridMenu()
            UpdateViewGridReport()
            UpdateViewGridWarehouseUnit()
            UpdateViewGridInventoryTxn()

            '// if Administrator make all disabled
            If lblUserGroupID.Text = "Administrator" Then
                Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Else
                Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
            End If
        End Sub

        'Private Sub GenerateMenuTree()
        '    Dim dt As DataTable
        '    Dim br As New BussinessRules.Menu

        '    br.UserGroupID = lblUserGroupID.Text.Trim
        '    dt = br.SelectByUserGroupID

        '    RadTreeViewMenu.DataFieldID = "MenuID"
        '    RadTreeViewMenu.DataFieldParentID = "ParentMenuID"
        '    RadTreeViewMenu.DataTextField = "Caption"

        '    RadTreeViewMenu.DataSource = dt
        '    RadTreeViewMenu.DataBind()

        '    RadTreeViewMenu.ExpandAllNodes()

        '    br.Dispose()
        '    br = Nothing
        'End Sub

        Private Sub UpdateViewGridMenu()
            Dim dt As DataTable
            Dim br As New BussinessRules.Menu

            dt = br.SelectMenuAuthorizationByUserGroupID(lblUserGroupID.Text.Trim)

            RadGridMenu.DataSource = dt.DefaultView
            RadGridMenu.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridReport()
            Dim dt As DataTable
            Dim br As New BussinessRules.Report

            dt = br.SelectReportAuthorizationByUserGroupID(lblUserGroupID.Text.Trim)

            RadGridReport.DataSource = dt.DefaultView
            RadGridReport.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridWarehouseUnit()
            Dim dt As DataTable
            Dim br As New BussinessRules.Warehouse

            dt = br.SelectWarehouseUnitAuthorizationByUserGroupID(lblUserGroupID.Text.Trim)

            RadGridWarehouseUnit.DataSource = dt.DefaultView
            RadGridWarehouseUnit.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridInventoryTxn()
            Dim dt As DataTable
            Dim br As New BussinessRules.InventoryTxn

            dt = br.SelectInventoryTxnAuthorizationByUserGroupID(lblUserGroupID.Text.Trim)

            RadGridInventoryTxn.DataSource = dt.DefaultView
            RadGridInventoryTxn.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("isAuthorized", System.Type.GetType("System.Boolean"))
                .Columns.Add("UserGroupID", System.Type.GetType("System.String"))
                .Columns.Add("MenuID", System.Type.GetType("System.String"))
                .Columns.Add("isAllowRead", System.Type.GetType("System.Boolean"))
                .Columns.Add("isAllowEdit", System.Type.GetType("System.Boolean"))
                .Columns.Add("isAllowDelete", System.Type.GetType("System.Boolean"))
            End With

            Return tbl
        End Function

        Private Function createReportTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("isAuthorized", System.Type.GetType("System.Boolean"))
                .Columns.Add("UserGroupID", System.Type.GetType("System.String"))
                .Columns.Add("ReportID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Function createWarehouseUnitTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("isAuthorized", System.Type.GetType("System.Boolean"))
                .Columns.Add("UserGroupID", System.Type.GetType("System.String"))
                .Columns.Add("WhID", System.Type.GetType("System.String"))
                .Columns.Add("UnitID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

        Private Function createInventoryTxnTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("isAuthorized", System.Type.GetType("System.Boolean"))
                .Columns.Add("UserGroupID", System.Type.GetType("System.String"))
                .Columns.Add("InventoryTxnID", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace