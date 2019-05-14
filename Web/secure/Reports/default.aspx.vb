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

Namespace Raven.Web.Secure

    Public Class Reports
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "800"
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As Image

        Protected WithEvents lblReportExplorerCaption As Label
        Protected WithEvents lblParameterEntryCaption As Label
        Protected WithEvents lblReportID As Label
        Protected WithEvents lblReportCaption As Label
        Protected WithEvents lblReportAsp As Label
        Protected WithEvents lblReportName As Label
        Protected WithEvents lblReportSP As Label
        Protected WithEvents RadTreeViewReportExplorer As RadTreeView
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As PlaceHolder

        '// Parameter Panels
        Protected WithEvents pnlPeriod As Panel
        Protected WithEvents RadDateFrom As RadDatePicker
        Protected WithEvents RadDateTo As RadDatePicker

        Protected WithEvents pnlAnalysisDate As Panel
        Protected WithEvents RadAnalysisDate As RadDatePicker

        Protected WithEvents pnlWarehouse As Panel
        Protected WithEvents ddlWarehouse As DropDownList
        Protected WithEvents ddlUnit As DropDownList

        Protected WithEvents pnlItem As Panel
        Protected WithEvents txtItemIDFrom As TextBox
        Protected WithEvents txtItemIDTo As TextBox

        Protected WithEvents pnlSingleItem As Panel
        Protected WithEvents txtItemID As TextBox

        Protected WithEvents pnlSupplier As Panel
        Protected WithEvents txtSupplierID As TextBox

        Protected WithEvents pnlAllCashier As Panel
        Protected WithEvents chkAllCashier As CheckBox

        Protected WithEvents pnlByCashier As Panel
        Protected WithEvents txtCashierID As TextBox

        Protected WithEvents pnlSortBy As Panel
        Protected WithEvents ddlSortBy As DropDownList

        Protected WithEvents pnlSortDir As Panel
        Protected WithEvents ddlSortDirection As DropDownList

        '// Report Viewing Panels
        Protected WithEvents pnlRptView As Panel
        Protected WithEvents ddlRptView As DropDownList

        Protected WithEvents p1 As Panel
        Protected WithEvents p2 As Panel
        Protected WithEvents txtp1 As TextBox
        Protected WithEvents txtp2 As TextBox
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadTreeViewReportExplorer.IsCallBack Then
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreen()
            End If
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidPrint ' "preview"
                    If lblReportAsp.Text.Trim <> "" And lblReportName.Text.Trim <> "" And lblReportSP.Text.Trim <> "" Then
                        Dim oReport As New BussinessRules.Report
                        With oReport
                            .ReportID = CInt(Replace(Replace(lblReportID.Text.Trim, "[", ""), "]", ""))
                            .ReportAsp = lblReportAsp.Text.Trim
                            .ReportFileName = lblReportName.Text.Trim
                            .ReportSPName = lblReportSP.Text.Trim
                            .ReportCaption = lblReportCaption.Text.Trim
                            .AddParametersPrintReport(Replace(Replace(lblReportID.Text.Trim, "[", ""), "]", ""))
                            .AddParametersPrintReport(MyBase.LoggedOnUserID.Trim)

                            If pnlRptView.Visible Then
                                .AddParametersPrintReport(ddlRptView.SelectedValue.Trim)
                            End If

                            If pnlPeriod.Visible Then
                                .AddParametersPrintReport(Format(RadDateFrom.SelectedDate.Value, "yyyyMMdd"))
                                .AddParametersPrintReport(Format(RadDateTo.SelectedDate.Value, "yyyyMMdd"))
                            End If

                            If pnlAnalysisDate.Visible Then
                                .AddParametersPrintReport(Format(RadAnalysisDate.SelectedDate.Value, "yyyyMMdd"))                                
                            End If

                            If pnlSupplier.Visible Then
                                .AddParametersPrintReport(txtSupplierID.Text.Trim)
                            End If

                            If pnlWarehouse.Visible Then
                                .AddParametersPrintReport(ddlWarehouse.SelectedValue.Trim)
                                .AddParametersPrintReport(ddlUnit.SelectedValue.Trim)
                            End If

                            If pnlItem.Visible Then
                                .AddParametersPrintReport(txtItemIDFrom.Text.Trim)
                                .AddParametersPrintReport(txtItemIDTo.Text.Trim)
                            End If

                            If pnlSingleItem.Visible Then
                                .AddParametersPrintReport(txtItemID.Text.Trim)                                
                            End If

                            If pnlAllCashier.Visible Then
                                .AddParametersPrintReport("")
                            End If

                            If pnlByCashier.Visible Then
                                .AddParametersPrintReport(txtCashierID.Text.Trim)
                            End If

                            If pnlSortBy.Visible Then
                                .AddParametersPrintReport(ddlSortBy.SelectedItem.Value.Trim)
                            End If

                            If pnlSortDir.Visible Then
                                .AddParametersPrintReport(ddlSortDirection.SelectedItem.Value.Trim)
                            End If

                            Response.Write(.UrlPrintReport(Context.Request.Url.Host))
                        End With
                        oReport.Dispose()
                        oReport = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to Preview.")
                        Exit Sub
                    End If

                Case CSSToolbarItem.tidOther2  '"clear"
                    PrepareParameterFields()
            End Select
        End Sub

        Private Sub RadTreeViewReportExplorer_NodeClick(ByVal o As Object, ByVal e As RadTreeNodeEventArgs) Handles RadTreeViewReportExplorer.NodeClick
            PrepareParameterPanels()
            PrepareParameterFields()

            Dim orpt As New BussinessRules.Report
            orpt.ReportID = CInt(CType(o, RadTreeView).SelectedNode.Value.Trim)
            With orpt
                If .SelectOne.Rows.Count > 0 Then
                    If Len(.ReportAsp.Trim) > 0 And Len(.ReportSPName.Trim) > 0 And Len(.ReportFileName.Trim) > 0 Then
                        lblReportID.Text = "[" + .ReportID.ToString.Trim + "]"
                        lblReportCaption.Text = .ReportCaption.Trim
                        lblReportAsp.Text = .ReportAsp.Trim
                        lblReportName.Text = .ReportFileName.Trim
                        lblReportSP.Text = .ReportSPName.Trim

                        '// Get parameter for the report
                        Dim dtParm As New DataTable
                        dtParm = .SelectReportParameterByReportID()
                        If dtParm.Rows.Count > 0 Then
                            Dim iRecCount As Integer = 0
                            While dtParm.Rows.Count > iRecCount
                                Dim _AspxPanelID As String = CType(dtParm.Rows(iRecCount)("AspxPanelID"), String)
                                Dim _IsVisible As Boolean = CType(dtParm.Rows(iRecCount)("IsVisible"), Boolean)

                                Select Case _AspxPanelID.Trim
                                    Case pnlPeriod.ClientID '"pnlPeriod"
                                        pnlPeriod.Visible = _IsVisible
                                        If pnlPeriod.Visible Then
                                            sharedCalendar.Visible = True
                                        End If
                                        RadDateFrom.SelectedDate = Date.Today
                                        RadDateTo.SelectedDate = Date.Today

                                    Case pnlAnalysisDate.ClientID '"pnlAnalysisDate"
                                        pnlAnalysisDate.Visible = _IsVisible
                                        If pnlAnalysisDate.Visible Then
                                            sharedCalendar.Visible = True
                                        End If
                                        RadAnalysisDate.SelectedDate = Date.Today                                        

                                    Case pnlSupplier.ClientID '"pnlSupplier"
                                        pnlSupplier.Visible = _IsVisible
                                        txtSupplierID.Text = String.Empty                                        

                                    Case pnlWarehouse.ClientID '"pnlWarehouse"
                                        pnlWarehouse.Visible = _IsVisible
                                        ddlWarehouse.SelectedIndex = 0
                                        ddlUnit.SelectedIndex = 0

                                    Case pnlItem.ClientID '"pnlItem"
                                        pnlItem.Visible = _IsVisible
                                        txtItemIDFrom.Text = "000"
                                        txtItemIDTo.Text = "ZZZ"

                                    Case pnlSingleItem.ClientID '"pnlSingleItem"
                                        pnlSingleItem.Visible = _IsVisible
                                        txtItemID.Text = String.Empty

                                    Case pnlAllCashier.ClientID '"pnlAllCashier"
                                        pnlAllCashier.Visible = _IsVisible
                                        chkAllCashier.Checked = True

                                    Case pnlByCashier.ClientID '"pnlByCashier"
                                        pnlByCashier.Visible = _IsVisible
                                        txtCashierID.Text = MyBase.LoggedOnUserID.Trim

                                    Case pnlSortBy.ClientID '"pnlSortBy"
                                        pnlSortBy.Visible = _IsVisible
                                        ddlSortBy.SelectedIndex = 0

                                    Case pnlSortDir.ClientID '"pnlSortDir"
                                        pnlSortDir.Visible = _IsVisible
                                        ddlSortDirection.SelectedIndex = 0
                                End Select

                                iRecCount += 1
                            End While
                        Else
                            PrepareParameterPanels()
                        End If
                    Else
                        PrepareSelectedReport()
                        PrepareParameterPanels()
                        PrepareParameterFields()
                    End If

                    commonFunction.ShowPanel(pnlRptView, .IsAllowViewingType)
                Else
                    commonFunction.MsgBox(Me, "Report does not exists.")
                    PrepareScreen()
                    orpt.Dispose()
                    orpt = Nothing
                    Exit Sub
                End If
            End With
            orpt.Dispose()
            orpt = Nothing
        End Sub

        Private Sub ddlWarehouse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWarehouse.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnit, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWarehouse.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
        End Sub
#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "

#End Region

#Region " Main Function (Custom) "
        
#End Region

#Region " Additional Function: Private Function "

        Private Sub PrepareScreen()
            GenerateReportExplorer()
            PrepareSelectedReport()
            PrepareParameterPanels()
            PrepareParameterFields()
            pnlRptView.Visible = False
            ddlRptView.SelectedIndex = 0
        End Sub

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidNew) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidOther1) = False
                .VisibleButton(CSSToolbarItem.tidOther2) = True
                .lbtnOther2_Text = "Clear"
            End With
        End Sub

        Private Sub PrepareSelectedReport()
            lblReportID.Text = String.Empty
            lblReportCaption.Text = "Please select a report from the Report Explorer."
            lblReportAsp.Text = String.Empty
            lblReportName.Text = String.Empty
            lblReportSP.Text = String.Empty
        End Sub

        Private Sub PrepareParameterPanels()
            sharedCalendar.Visible = False
            pnlPeriod.Visible = False
            pnlAnalysisDate.Visible = False
            pnlSupplier.Visible = False
            pnlWarehouse.Visible = False
            pnlItem.Visible = False
            pnlSingleItem.Visible = False
            pnlAllCashier.Visible = False
            pnlByCashier.Visible = False
            pnlSortBy.Visible = False
            pnlSortDir.Visible = False
        End Sub

        Private Sub PrepareParameterFields()
            RadDateFrom.SelectedDate = Date.Today
            RadDateTo.SelectedDate = Date.Today

            RadAnalysisDate.SelectedDate = Date.Today

            txtSupplierID.Text = String.Empty

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWarehouse, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnit, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWarehouse.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            ddlWarehouse.SelectedIndex = 0
            ddlUnit.SelectedIndex = 0

            txtItemIDFrom.Text = "000"
            txtItemIDTo.Text = "ZZZ"

            txtItemID.Text = String.Empty

            chkAllCashier.Checked = True

            txtCashierID.Text = MyBase.LoggedOnUserID.Trim

            txtp1.Text = "000"
            txtp2.Text = "ZZZ"

            ddlSortBy.SelectedIndex = 0
            ddlSortDirection.SelectedIndex = 0
        End Sub

        Private Function CreateTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("ReportID", System.Type.GetType("System.Int32"))
                .Columns.Add("ParentReportID", System.Type.GetType("System.Int32"))
                .Columns.Add("ReportCaption", System.Type.GetType("System.String"))
                .Columns.Add("Url", System.Type.GetType("System.String"))
                .Columns.Add("IsHeader", System.Type.GetType("System.Boolean"))
            End With

            Return tbl
        End Function

        Private Sub GenerateReportExplorer()
            '// Get UserGroupID from User
            Dim strUserGroupID As String = String.Empty
            Dim oUser As New BussinessRules.User

            oUser.UserID = MyBase.LoggedOnUserID.Trim
            If oUser.SelectOne.Rows.Count > 0 Then
                strUserGroupID = oUser.UserGroupID.Trim
            Else
                strUserGroupID = String.Empty
            End If
            oUser.Dispose()
            oUser = Nothing

            '// Get Report By UserGroupID from UserGroupReport
            Dim dt As DataTable
            Dim br As New BussinessRules.Report
            br.UserGroupID = strUserGroupID.Trim
            dt = br.SelectByUserGroupID
            br.Dispose()
            br = Nothing

            Dim tmpTbl As DataTable = CreateTmpTable()
            Dim iRecCount As Integer = 0
            While dt.Rows.Count > iRecCount
                Dim _ReportID As Integer = CType(ProcessNull.GetInt32(dt.Rows(iRecCount)("ReportID")), Integer)
                Dim _ParentReportID As Integer = CType(ProcessNull.GetInt32(dt.Rows(iRecCount)("ParentReportID")), Integer)
                Dim _ReportCaption As String = CType(dt.Rows(iRecCount)("ReportCaption"), String)
                Dim _Url As String = CType(dt.Rows(iRecCount)("Url"), String)
                Dim _IsHeader As Boolean = CType(dt.Rows(iRecCount)("IsHeader"), Boolean)

                Dim row As DataRow = tmpTbl.NewRow

                row("ReportID") = _ReportID
                If _ParentReportID = 0 Then
                    row("ParentReportID") = DBNull.Value
                Else
                    row("ParentReportID") = _ParentReportID
                End If
                row("ReportCaption") = _ReportCaption.Trim

                If _Url = "#" Then
                    row("Url") = ""
                Else
                    row("Url") = ""
                    'row("Url") = PageBase.UrlBase + "/secure/" + _Url.Trim
                End If

                If _IsHeader Then
                    row("IsHeader") = _IsHeader
                End If

                tmpTbl.Rows.Add(row)

                iRecCount += 1
            End While

            '// set report data into RadTreeView
            RadTreeViewReportExplorer.DataTextField = "ReportCaption"
            RadTreeViewReportExplorer.DataFieldID = "ReportID"
            RadTreeViewReportExplorer.DataFieldParentID = "ParentReportID"

            RadTreeViewReportExplorer.DataValueField = "ReportID"

            'RadTreeViewReportExplorer.DataNavigateUrlField = "Url"

            RadTreeViewReportExplorer.DataSource = tmpTbl
            RadTreeViewReportExplorer.DataBind()
            RadTreeViewReportExplorer.ExpandAllNodes()

            ''// Disabled if IsHeader = True
            'iRecCount = 0
            'While dt.Rows.Count > iRecCount
            '    Dim _ReportID As Integer = CType(ProcessNull.GetInt32(dt.Rows(iRecCount)("ReportID")), Integer)
            '    Dim _IsHeader As Boolean = CType(dt.Rows(iRecCount)("IsHeader"), Boolean)
            '    If _isheader = True Then
            '        'RadTreeViewReportExplorer.Nodes.FindNodeByValue(_ReportID.ToString.Trim).Enabled = False
            '        RadTreeViewReportExplorer.
            '    End If
            '    iRecCount += 1
            'End While
        End Sub

#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace