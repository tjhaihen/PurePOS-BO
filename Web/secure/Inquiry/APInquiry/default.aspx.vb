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

Namespace Raven.Web.Secure.Inquiry

    Public Class APInquiry
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "703"

        Protected WithEvents lbtnNew As LinkButton
        Protected WithEvents lbtnRefresh As LinkButton
        Protected WithEvents lbtnSave As LinkButton
        Protected WithEvents lbtnPrint As LinkButton

        Protected WithEvents RadComboBoxAPAnalysisNo As RadComboBox
        Protected WithEvents RadSDate As RadDatePicker
        Protected WithEvents RadEDate As RadDatePicker
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox

        Protected WithEvents grdPUnit As DataGrid
        Protected WithEvents grdPReturn As DataGrid

        Protected WithEvents txtEntitiesName As TextBox
        Protected WithEvents txtPurchaseUnitTotal As TextBox
        Protected WithEvents txtPurchaseReturnTotal As TextBox
        Protected WithEvents txtAPDueTotal As TextBox

        Protected WithEvents lblTotalPUnit As Label
        Protected WithEvents lblTotalPReturn As Label

        Protected WithEvents chkShowOutstandingOnly As CheckBox
        Protected WithEvents lbtnSelectAllPUnit As LinkButton
        Protected WithEvents lbtnDeselectAllPUnit As LinkButton
        Protected WithEvents lbtnSelectAllPReturn As LinkButton
        Protected WithEvents lbtnDeselectAllPReturn As LinkButton

        Protected WithEvents RadAjaxManager1 As RadAjaxManager

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub lbtnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNew.Click
            PrepareScreen()
        End Sub

        Private Sub lbtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRefresh.Click
            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGrid(_isAPAnalysisNoExists)
        End Sub

        Private Sub lbtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSave.Click
            _SavePUnitandPReturn()
        End Sub

        Private Sub lbtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnPrint.Click
            Dim oprintform As New BussinessRules.PrintForm
            With oprintform
                .PrintFormID = 6261
                .MenuID = CInt(ModuleId.Trim)
                .AddParametersPrintForm(RadComboBoxAPAnalysisNo.Text.Trim)
                .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                Response.Write(.UrlPrintForm(Context.Request.Url.Host))
            End With
            oprintform.Dispose()
            oprintform = Nothing

            'Response.Write("<script language=javascript>window.open('http://" + Context.Request.Url.Host + Common.HisConfiguration.ReportsFolder + "APPaymentOrder.asp?apano=" + RadComboBoxAPAnalysisNo.Text.Trim + "&uid=" + MyBase.LoggedOnUserID.Trim + "', '','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
        End Sub

        Private Sub lbtnSelectAllPUnit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSelectAllPUnit.Click
            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGridPUnitOnly(_isAPAnalysisNoExists)

            Dim _item As DataGridItem
            Dim _PUnitTotal As Decimal = 0D

            For Each _item In grdPUnit.Items
                Dim _chkPUnit As CheckBox = CType(_item.FindControl("_chkPUnit"), CheckBox)
                Dim _lblPurchaseTotal As Label = CType(_item.FindControl("_lblPurchaseTotal"), Label)                

                _chkPUnit.Checked = _chkPUnit.Enabled
                If _chkPUnit.Checked Then
                    _PUnitTotal += CType(_lblPurchaseTotal.Text.Trim, Decimal)
                End If
            Next

            txtPurchaseUnitTotal.Text = Format(_PUnitTotal, commonFunction.FORMAT_CURRENCY)
            txtAPDueTotal.Text = Format(_PUnitTotal - CDec(txtPurchaseReturnTotal.Text.Trim), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub lbtnSelectAllPReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSelectAllPReturn.Click
            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGridPReturnOnly(_isAPAnalysisNoExists)

            Dim _item As DataGridItem
            Dim _PReturnTotal As Decimal = 0D

            For Each _item In grdPReturn.Items
                Dim _chkPReturn As CheckBox = CType(_item.FindControl("_chkPReturn"), CheckBox)
                Dim _lblPurchaseTotal As Label = CType(_item.FindControl("_lblPurchaseTotal"), Label)

                _chkPReturn.Checked = _chkPReturn.Enabled
                If _chkPReturn.Checked Then
                    _PReturnTotal += CType(_lblPurchaseTotal.Text.Trim, Decimal)
                End If
            Next

            txtPurchaseReturnTotal.Text = Format(_PReturnTotal, commonFunction.FORMAT_CURRENCY)
            txtAPDueTotal.Text = Format(CDec(txtPurchaseUnitTotal.Text.Trim) - _PReturnTotal, commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub lbtnDeselectAllPUnit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDeselectAllPUnit.Click
            Dim _item As DataGridItem
            Dim _PUnitTotalToDeduct As Decimal = 0D

            For Each _item In grdPUnit.Items
                Dim _chkPUnit As CheckBox = CType(_item.FindControl("_chkPUnit"), CheckBox)
                Dim _lblPurchaseTotal As Label = CType(_item.FindControl("_lblPurchaseTotal"), Label)

                If _chkPUnit.Enabled And _chkPUnit.Checked Then
                    _PUnitTotalToDeduct += CDec(_lblPurchaseTotal.Text.Trim)
                    _chkPUnit.Checked = False
                End If
            Next

            txtPurchaseUnitTotal.Text = Format(CDec(txtPurchaseUnitTotal.Text.Trim) - _PUnitTotalToDeduct, commonFunction.FORMAT_CURRENCY)
            txtAPDueTotal.Text = Format(CDec(txtPurchaseUnitTotal.Text.Trim) - CDec(txtPurchaseReturnTotal.Text.Trim), commonFunction.FORMAT_CURRENCY)

            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGridPUnitOnly(_isAPAnalysisNoExists)
        End Sub

        Private Sub lbtnDeselectAllPReturn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDeselectAllPReturn.Click
            Dim _item As DataGridItem
            Dim _PReturnTotalToDeduct As Decimal = 0D

            For Each _item In grdPReturn.Items
                Dim _chkPReturn As CheckBox = CType(_item.FindControl("_chkPReturn"), CheckBox)
                Dim _lblPurchaseTotal As Label = CType(_item.FindControl("_lblPurchaseTotal"), Label)

                If _chkPReturn.Enabled And _chkPReturn.Checked Then
                    _PReturnTotalToDeduct += CDec(_lblPurchaseTotal.Text.Trim)
                    _chkPReturn.Checked = False
                End If
            Next

            txtPurchaseReturnTotal.Text = Format(CDec(txtPurchaseReturnTotal.Text.Trim) - _PReturnTotalToDeduct, commonFunction.FORMAT_CURRENCY)
            txtAPDueTotal.Text = Format(CDec(txtPurchaseUnitTotal.Text.Trim) - CDec(txtPurchaseReturnTotal.Text.Trim), commonFunction.FORMAT_CURRENCY)

            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGridPReturnOnly(_isAPAnalysisNoExists)
        End Sub

        Private Sub chkShowOutstandingOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowOutstandingOnly.CheckedChanged
            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGrid(_isAPAnalysisNoExists)
        End Sub

        Private Sub RadComboBoxAPAnalysisNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxAPAnalysisNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadAPAnalysisNo(e.Text)
        End Sub

        Private Sub RadComboBoxAPAnalysisNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxAPAnalysisNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("APAnalysisNo").ToString()
        End Sub

        Private Sub RadComboBoxAPAnalysisNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAPAnalysisNo.SelectedIndexChanged
            _Open()
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesID").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesID.SelectedIndexChanged
            commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName)
            UpdateViewGrid(False)
        End Sub
#End Region

#Region " DataGrid Command Center "

        Private Sub grdPUnit_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPUnit.ItemCommand
            Select Case e.CommandName
                Case "_PUnit"
                    Dim PUnitNo As String = CType(e.Item.FindControl("_lbtnPUnitNo"), LinkButton).Text.Trim

                    If Len(PUnitNo.Trim) > 0 Then
                        Response.Write("<script language=javascript>window.open('" + MyBase.UrlBase + "/secure/Inquiry/APInquiry/APInfo.aspx?type=punit&no=" + PUnitNo.Trim + "',null,'status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
                    End If
            End Select
        End Sub

        Private Sub grdPReturn_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grdPReturn.ItemCommand
            Select Case e.CommandName
                Case "_PReturn"
                    Dim PReturnNo As String = CType(e.Item.FindControl("_lbtnPReturnNo"), LinkButton).Text.Trim

                    If Len(PReturnNo.Trim) > 0 Then
                        Response.Write("<script language=javascript>window.open('" + MyBase.UrlBase + "/secure/Inquiry/APInquiry/APInfo.aspx?type=preturn&no=" + PReturnNo.Trim + "',null,'status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
                    End If
            End Select
        End Sub

        Private Sub grdPUnit_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdPUnit.ItemCreated
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim X As DataRowView = CType(e.Item.DataItem, DataRowView)
                If Not X Is Nothing Then
                    Dim s1 As String = CType(X.Row.Item("total"), String).Trim
                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    Dim _chkPUnit As CheckBox = CType(e.Item.FindControl("_chkPUnit"), CheckBox)
                    _chkPUnit.Attributes.Add("OnClick", "javascript:colorRowv2(this,'chkSelectAllPUnit');javascript:count('" + s1 + "',this);")

                    'If CType(X.Row.Item("IsAnalyzed"), Boolean) = True Then
                    '    txtPurchaseUnitTotal.Text = Format(CDec(txtPurchaseUnitTotal.Text.Trim) + CDec(s1), commonFunction.FORMAT_CURRENCY)
                    'End If

                    If CType(X.Row.Item("IsAnalyzed"), Boolean) = True Then
                        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC525")
                    End If

                    If CType(X.Row.Item("IsPaid"), Boolean) = True Then
                        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4921B")
                    End If
                End If

            ElseIf e.Item.ItemType = ListItemType.Footer Then
                Dim dt As DataTable
                Dim oTotalPUnit As New BussinessRules.PurchaseUnitHd
                Dim row As DataRow
                Dim dTotal As Decimal

                With oTotalPUnit
                    dt = .SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim)
                End With

                For Each row In dt.Rows
                    dTotal += CDec(ProcessNull.GetDecimal(row("total")))
                Next

                lblTotalPUnit.Text = Format(dTotal, "#,##0.00")

                oTotalPUnit.Dispose()
                oTotalPUnit = Nothing
            End If
        End Sub

        Private Sub grdPReturn_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles grdPReturn.ItemCreated
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim X As DataRowView = CType(e.Item.DataItem, DataRowView)
                If Not X Is Nothing Then
                    Dim s1 As String = CType(X.Row.Item("total"), String).Trim
                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    Dim _chkPReturn As CheckBox = CType(e.Item.FindControl("_chkPReturn"), CheckBox)
                    _chkPReturn.Attributes.Add("OnClick", "javascript:colorRowv2(this,'chkSelectAllPReturn');javascript:countPReturn('" + s1 + "',this);")

                    'If CType(X.Row.Item("IsAnalyzed"), Boolean) = True Then
                    '    txtPurchaseReturnTotal.Text = Format(CDec(txtPurchaseReturnTotal.Text.Trim) + CDec(s1), commonFunction.FORMAT_CURRENCY)
                    'End If
                    If CType(X.Row.Item("IsAnalyzed"), Boolean) = True Then
                        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#9CC525")
                    End If

                    If CType(X.Row.Item("IsPaid"), Boolean) = True Then
                        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4921B")
                    End If
                End If

            ElseIf e.Item.ItemType = ListItemType.Footer Then
                Dim dt As DataTable
                Dim oTotalPReturn As New BussinessRules.PurchaseReturnHd
                Dim row As DataRow
                Dim dTotal As Decimal

                With oTotalPReturn
                    dt = .SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim)
                End With

                For Each row In dt.Rows
                    dTotal += CDec(ProcessNull.GetDecimal(row("total")))
                Next

                lblTotalPReturn.Text = Format(dTotal, "#,##0.00")

                oTotalPReturn.Dispose()
                oTotalPReturn = Nothing
            End If
        End Sub
#End Region

#Region " Main Function (CRUD) "
        Private Function _SaveAPAnalysis() As Boolean
            If Len(RadComboBoxEntitiesID.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Entities Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadSDate.SelectedDate.Value > RadEDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Start Date must be less than End Date.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.APAnalysis
            Dim fNew As Boolean = True

            With br
                .APAnalysisNo = RadComboBoxAPAnalysisNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxAPAnalysisNo.Text = BussinessRules.ID.GenerateIDNumber("APAnalysis", "APAnalysisNo", "AP")
                End If

                '// set the value
                .APAnalysisNo = RadComboBoxAPAnalysisNo.Text.Trim
                .StartDate = RadSDate.SelectedDate.Value
                .EndDate = RadEDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
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

            Return True
        End Function

        Private Sub _SavePUnitandPReturn()
            ' // save header first
            If Not _SaveAPAnalysis() Then
                Exit Sub
            End If

            Dim rowCount As Integer = 0            
            Dim oPU As New BussinessRules.PurchaseUnitHd
            Dim oPR As New BussinessRules.PurchaseReturnHd

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitmPUnit As DataGridItem
            For Each gitmPUnit In grdPUnit.Items
                Dim _chkPUnit As CheckBox = CType(gitmPUnit.FindControl("_chkPUnit"), CheckBox)
                Dim _lblPurchaseUnitNo As Label = CType(gitmPUnit.FindControl("_lblPurchaseUnitNo"), Label)

                If _chkPUnit.Checked = True And _chkPUnit.Enabled = True Then
                    rowCount += 1

                    '// Purchase Unit
                    oPU.PUnitNO = Trim(_lblPurchaseUnitNo.Text)
                    oPU.APAnalysisNo = RadComboBoxAPAnalysisNo.Text.Trim
                    oPU.IsAnalyzed = True
                    oPU.UserUpdate = MyBase.LoggedOnUserID.Trim
                    oPU.UpdateAPAnalysisNo()
                End If
            Next

            Dim gitmPReturn As DataGridItem
            For Each gitmPReturn In grdPReturn.Items
                Dim _chkPReturn As CheckBox = CType(gitmPReturn.FindControl("_chkPReturn"), CheckBox)
                Dim _lblPurchaseReturnNo As Label = CType(gitmPReturn.FindControl("_lblPurchaseReturnNo"), Label)

                If _chkPReturn.Checked = True And _chkPReturn.Enabled = True Then
                    rowCount += 1

                    '// Purchase Return
                    oPR.PReturnNO = Trim(_lblPurchaseReturnNo.Text)
                    oPR.APAnalysisNo = RadComboBoxAPAnalysisNo.Text.Trim
                    oPR.IsAnalyzed = True
                    oPR.UserUpdate = MyBase.LoggedOnUserID.Trim
                    oPR.UpdateAPAnalysisNo()
                End If
            Next

            oPU.Dispose()
            oPU = Nothing

            oPR.Dispose()
            oPR = Nothing

            If rowCount = 0 Then
                commonFunction.MsgBox(Me, "You have to choose at least one record to be saved.")
                Exit Sub
            End If

            Dim _isAPAnalysisNoExists As Boolean = (Len(RadComboBoxAPAnalysisNo.Text.Trim) > 0)
            UpdateViewGrid(_isAPAnalysisNoExists)
        End Sub
#End Region

#Region " Main Function (Custom) "
        Private Sub _Open()            
            Dim br As New BussinessRules.APAnalysis
            With br
                .APAnalysisNo = RadComboBoxAPAnalysisNo.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    RadSDate.SelectedDate = .StartDate
                    RadEDate.SelectedDate = .EndDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                Else
                    RadSDate.SelectedDate = Date.Now
                    RadEDate.SelectedDate = Date.Now
                    RadComboBoxEntitiesID.SelectedValue = String.Empty
                    RadComboBoxEntitiesID.Text = String.Empty
                    txtEntitiesName.Text = String.Empty
                End If
            End With
            br.Dispose()
            br = Nothing

            UpdateViewGrid(True)
        End Sub
#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("PUnitNo", System.Type.GetType("System.String"))
                .Columns.Add("APAnalysisNo", System.Type.GetType("System.String"))
                .Columns.Add("IsAnalyzed", System.Type.GetType("System.String"))
            End With
        End Sub

        Private Sub PrepareScreen()
            RadComboBoxAPAnalysisNo.Text = String.Empty
            RadComboBoxAPAnalysisNo.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty
            RadSDate.SelectedDate = Date.Now
            RadEDate.SelectedDate = Date.Now
            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtPurchaseUnitTotal.Text = "0.00"
            txtPurchaseReturnTotal.Text = "0.00"
            txtAPDueTotal.Text = "0.00"
            UpdateViewGrid(False)
        End Sub

        Private Sub UpdateViewGrid(ByVal IsAPAnalysisNoExists As Boolean)
            Dim oPU As New BussinessRules.PurchaseUnitHd
            Dim oPR As New BussinessRules.PurchaseReturnHd

            Dim dsPU As DataView
            Dim dsPR As DataView

            If IsAPAnalysisNoExists Then
                dsPU = New DataView(oPU.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim))
                dsPR = New DataView(oPR.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim))
                
                RefreshTotal()
            Else
                dsPU = New DataView(oPU.SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim))
                dsPR = New DataView(oPR.SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim))
            End If

            If chkShowOutstandingOnly.Checked Then
                dsPU.RowFilter = "isPaid = 0"
                grdPUnit.DataSource = dsPU
                grdPUnit.DataBind()

                dsPR.RowFilter = "isPaid = 0"
                grdPReturn.DataSource = dsPR
                grdPReturn.DataBind()
            Else
                grdPUnit.DataSource = dsPU
                grdPUnit.DataBind()

                grdPReturn.DataSource = dsPR
                grdPReturn.DataBind()
            End If

            oPU.Dispose()
            oPU = Nothing
            oPR.Dispose()
            oPR = Nothing
        End Sub

        Private Sub UpdateViewGridPUnitOnly(ByVal IsAPAnalysisNoExists As Boolean)
            Dim oPU As New BussinessRules.PurchaseUnitHd
            
            If IsAPAnalysisNoExists Then
                grdPUnit.DataSource = oPU.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim)
                grdPUnit.DataBind()

                RefreshTotal()
            Else
                grdPUnit.DataSource = oPU.SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim)
                grdPUnit.DataBind()
            End If

            oPU.Dispose()
            oPU = Nothing
        End Sub

        Private Sub UpdateViewGridPReturnOnly(ByVal IsAPAnalysisNoExists As Boolean)
            Dim oPR As New BussinessRules.PurchaseReturnHd

            If IsAPAnalysisNoExists Then
                grdPReturn.DataSource = oPR.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim)
                grdPReturn.DataBind()

                RefreshTotal()
            Else
                grdPReturn.DataSource = oPR.SelectForAPInquiry(RadSDate.SelectedDate.Value, RadEDate.SelectedDate.Value, RadComboBoxEntitiesID.Text.Trim)
                grdPReturn.DataBind()
            End If

            oPR.Dispose()
            oPR = Nothing
        End Sub

        Private Sub RefreshTotal()
            Dim oPU As New BussinessRules.PurchaseUnitHd
            Dim oPR As New BussinessRules.PurchaseReturnHd

            Dim dtPUnit As New DataTable
            Dim dtPReturn As New DataTable

            dtPUnit = oPU.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim)            
            dtPReturn = oPR.SelectForAPInquiryByAPAnalysisNo(RadComboBoxAPAnalysisNo.Text.Trim)

            oPU.Dispose()
            oPU = Nothing
            oPR.Dispose()
            oPR = Nothing


            Dim PUnitTotal As Decimal = 0D
            Dim PReturnTotal As Decimal = 0D
            For Each rPUnit As DataRow In dtPUnit.Rows
                PUnitTotal += ProcessNull.GetDecimal(rPUnit("Total"))
            Next
            For Each rPReturn As DataRow In dtPReturn.Rows
                PReturnTotal += ProcessNull.GetDecimal(rPReturn("Total"))
            Next

            txtPurchaseUnitTotal.Text = Format(PUnitTotal, commonFunction.FORMAT_CURRENCY)
            txtPurchaseReturnTotal.Text = Format(PReturnTotal, commonFunction.FORMAT_CURRENCY)
            txtAPDueTotal.Text = Format(PUnitTotal - PReturnTotal, commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub LoadAPAnalysisNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.APAnalysis

            '// '01' = Supplier/Distributor as EntitiesType
            dt = br.SelectAll

            RadComboBoxAPAnalysisNo.DataSource = dt.DefaultView
            RadComboBoxAPAnalysisNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            '// '01' = Supplier/Distributor as EntitiesType
            dt = br.SelectAllForEntitiesSeqNoByEntitiesType("01", Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace