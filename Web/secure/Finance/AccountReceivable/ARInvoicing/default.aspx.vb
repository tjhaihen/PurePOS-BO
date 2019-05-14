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


Namespace Raven.Web.Secure.Finance.AccountReceivable

    Public Class ARInvoicing
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "631"

        'header
        Protected WithEvents RadARInvoicingDate As RadDatePicker
        Protected WithEvents RadDueDate As RadDatePicker

        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox

        Protected WithEvents ddlBankID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTermID As System.Web.UI.WebControls.DropDownList
        'txtTermID

        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox



        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDNAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox


        Protected WithEvents lbtnCancelGet As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveGet As System.Web.UI.WebControls.LinkButton

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxARInvoicingNo As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel
        Protected WithEvents PnlVoid As System.Web.UI.WebControls.Panel

        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridARInvoicing As DataGrid
        Protected WithEvents RadGridOutstandingAR As DataGrid
        Protected WithEvents RadGridGetDN As DataGrid
        Protected WithEvents RadGridDebitNote As DataGrid



        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridOAR As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridGetDN As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGridDebitNote As System.Web.UI.WebControls.Panel

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxARInvoicingNo.IsCallBack And _
                'Not RadComboBoxEntitiesID.IsCallBack Then

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

        Private Sub RadComboBoxARInvoicingNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxARInvoicingNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadARInvoicing(e.Text)
        End Sub

        Private Sub RadComboBoxARInvoicingNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxARInvoicingNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("SalesInvoiceNo").ToString()
        End Sub

        Private Sub RadComboBoxARInvoicingNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxARInvoicingNo.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave
                    _SaveDt()
                Case CSSToolbarItem.tidVoid
                    _VoidHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrint
                    If RadComboBoxARInvoicingNo.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 6311
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxARInvoicingNo.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
                Case CSSToolbarItem.tidOther1 ' "GetItemDN"
                    UpdateViewGridGetDN()
                    commonFunction.ShowPanel(PanelToolbar, False)
                    commonFunction.ShowPanel(PanelHeader, False)
                    commonFunction.ShowPanel(PanelGridOAR, False)
                    commonFunction.ShowPanel(PanelGrid, False)
                    commonFunction.ShowPanel(PanelGridDebitNote, False)
                    commonFunction.ShowPanel(PanelGridGetDN, True)
            End Select
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
            If Len(txtEntitiesName.Text.Trim) > 0 Then
                Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True
            Else
                Toolbar.EnableButton(CSSToolbarItem.tidOther1) = False
            End If
            UpdateViewGridRadGridOutstandingAR()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
        End Sub

        Private Sub lbtnCancelGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnCancelGet.Click
            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGridOAR, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridDebitNote, True)
            commonFunction.ShowPanel(PanelGridGetDN, False)
        End Sub

        Private Sub lbtnSaveGet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveGet.Click
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTableDN(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridGetDN.Items
                Dim _chkDN As CheckBox = CType(gitm.FindControl("_chkDN"), CheckBox)
                Dim _lblDNoteNo As Label = CType(gitm.FindControl("_lblDNoteNo"), Label)

                If _chkDN.Checked = True Then
                    Dim dcnt As New BussinessRules.DebitCreditNote
                    dcnt.DCNoteNo = Trim(_lblDNoteNo.Text)
                    If dcnt.SelectOne.Rows.Count > 0 Then
                        If dcnt.VoucherNo.Trim <> "" Then
                            commonFunction.MsgBox(Me, _lblDNoteNo.Text.Trim + " is already processed with invoice no. (" + dcnt.VoucherNo.Trim + ").")
                            dcnt.Dispose()
                            dcnt = Nothing
                            Exit Sub
                        End If
                    Else
                        commonFunction.MsgBox(Me, "Record is not found.")
                        dcnt.Dispose()
                        dcnt = Nothing
                        Exit Sub
                    End If
                    dcnt.Dispose()
                    dcnt = Nothing

                    rowCount += 1
                    Dim row As DataRow = tblTmp.NewRow
                    row("NomorID") = Trim(_lblDNoteNo.Text)
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                commonFunction.MsgBox(Me, "You to choose at least one record to be save")
                Exit Sub
            End If

            ' // save header first

            If Not _SaveHd() Then
                Exit Sub
            End If


            ' // save the data
            Dim dcn As New BussinessRules.DebitCreditNote
            dcn.VoucherNo = RadComboBoxARInvoicingNo.Text.Trim
            dcn.UserUpdate = MyBase.LoggedOnUserID.Trim
            dcn.UpdateVoucherNo(tblTmp)
            dcn.Dispose()
            dcn = Nothing

            tblTmp.Dispose()
            tblTmp = Nothing

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGridOAR, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridDebitNote, True)
            commonFunction.ShowPanel(PanelGridGetDN, False)

            UpdateViewGridDebitNote()
        End Sub

        Private Sub createTmpTableDN(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("NomorID", System.Type.GetType("System.String"))
            End With
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridARInvoicing_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridARInvoicing.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    _Deletedt(_lblID.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridARInvoicing_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridARInvoicing.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub


        Private Sub RadGridDebitNote_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridDebitNote.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDeleteDN As LinkButton = CType(e.Item.FindControl("_lbtnDeleteDN"), LinkButton)

                    If Not _lbtnDeleteDN Is Nothing Then
                        _lbtnDeleteDN.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub


        Private Sub RadGridDebitNote_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridDebitNote.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblDNoteNo As Label = CType(e.Item.FindControl("_lblDNoteNo"), Label)
                    _DeletedtDN(_lblDNoteNo.Text.Trim)
            End Select
        End Sub

#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.SalesInvoiceHd
            With br
                .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    'If .IsDeleted Then
                    '    'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                    '    PrepareScreenHd()
                    '    br.Dispose()
                    '    br = Nothing
                    '    Exit Sub
                    'End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxARInvoicingNo.Text = .SalesInvoiceNo.Trim
                    End If
                    RadARInvoicingDate.SelectedDate = .SalesInvoiceDate
                    RadDueDate.SelectedDate = .DueDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    commonFunction.SelectListItem(ddlTermID, .TermID.Trim)
                    commonFunction.SelectListItem(ddlBankID, .BankID.Trim)
                    txtDescriptionHd.Text = .Description.Trim
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                    commonFunction.SelectListItem(ddlBankID, .BankID.Trim)

                    If .IsApproval Or .IsVoid Then
                        UpdateViewGridARInvoicing()

                        If .IsVoid Then
                            commonFunction.ShowPanel(PnlVoid, True)
                            commonFunction.ShowPanel(PnlApproved, False)
                            txtDNAmount.Text = Format(.DNAmount, commonFunction.FORMAT_CURRENCY)
                            commonFunction.ShowPanel(PanelGridDebitNote, False)
                            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
                        ElseIf .IsApproval Then
                            commonFunction.ShowPanel(PnlApproved, True)
                            commonFunction.ShowPanel(PnlVoid, False)
                            UpdateViewGridDebitNote()
                            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True
                        End If

                        ddlBankID.Enabled = False
                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = False

                        commonFunction.ShowPanel(PanelGridOAR, False)

                        RadGridARInvoicing.Columns(0).Visible = False
                        RadGridDebitNote.Columns(0).Visible = False

                    Else
                        UpdateViewGridRadGridOutstandingAR()
                        UpdateViewGridARInvoicing()
                        UpdateViewGridDebitNote()

                        ddlBankID.Enabled = True
                        commonFunction.ShowPanel(PnlApproved, False)
                        commonFunction.ShowPanel(PnlVoid, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidOther1) = True

                        commonFunction.ShowPanel(PanelGridOAR, True)
                        commonFunction.ShowPanel(PanelGridDebitNote, True)
                        RadGridARInvoicing.Columns(0).Visible = True
                        RadGridDebitNote.Columns(0).Visible = True

                    End If

                    RadComboBoxEntitiesID.Enabled = False

                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxARInvoicingNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            'If CDec(txtGrandTotal.Text.Trim) < 0 Then
            '    commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
            '    Return False
            '    Exit Function
            'End If

            If RadComboBoxEntitiesID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Customer ID cannot empty.")
                Return False
                Exit Function
            End If

            If RadDueDate.SelectedDate.Value < RadARInvoicingDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Due Date must be equal or greater than A/R Invoice Date.")
                Return False
                Exit Function
            End If

            If ddlTermID.SelectedValue = "none" Then
                commonFunction.MsgBox(Me, "Term cannot empty.")
                Return False
                Exit Function
            End If

            If FApproval = True Then
                Dim errCount As Integer = 0
                Dim oSInvDt As New BussinessRules.SalesInvoicedt
                With oSInvDt
                    .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                    If .SelectAllBySalesInvoiceNo.Rows.Count = 0 Then
                        errCount += 1
                    End If
                End With
                oSInvDt.Dispose()
                oSInvDt = Nothing

                Dim oDN As New BussinessRules.DebitCreditNote
                With oDN
                    .VoucherNo = RadComboBoxARInvoicingNo.Text.Trim
                    If .SelectAllForViewGridCNDN.Rows.Count = 0 Then
                        errCount += 1
                    End If
                End With
                oDN.Dispose()
                oDN = Nothing

                If errCount > 1 Then
                    commonFunction.MsgBox(Me, "This A/R Invoice No. does not have Sales Unit or Debit Note items. Approval failed.")
                    Return False
                    Exit Function
                End If
            End If

            Dim br As New BussinessRules.SalesInvoiceHd
            Dim fNew As Boolean = True

            With br
                .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxARInvoicingNo.Text = BussinessRules.ID.GenerateIDNumber("SalesInvoiceHd", "SalesInvoiceNo", "SI")
                End If

                '// set the value
                .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                .SalesInvoiceDate = RadARInvoicingDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .TermID = ddlTermID.SelectedValue.Trim
                .BankID = ddlBankID.SelectedValue.Trim
                .DueDate = RadDueDate.SelectedDate.Value
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .DNAmount = CDec(txtDNAmount.Text.Trim)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .Description = txtDescriptionHd.Text.Trim
                .IsApproval = FApproval

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

        Private Sub _SaveDt()
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridOutstandingAR.Items
                Dim _chkinvoice As CheckBox = CType(gitm.FindControl("_chkinvoice"), CheckBox)
                Dim _lblSTxnNo As Label = CType(gitm.FindControl("_lblSTxnNo"), Label)
                Dim _lblSTxnDate As Label = CType(gitm.FindControl("_lblSTxnDate"), Label)

                If _chkinvoice.Checked = True Then
                    Dim apdt As New BussinessRules.SalesInvoicedt
                    apdt.STxnNo = _lblSTxnNo.Text.Trim
                    If apdt.SelectOneSalesInvoicedtBySTxnNo.Rows.Count > 0 Then
                        commonFunction.MsgBox(Me, _lblSTxnNo.Text.Trim + " is already used in Invoice No. " + apdt.SalesInvoiceNo.Trim)
                        apdt.Dispose()
                        apdt = Nothing
                        Exit Sub
                    End If
                    apdt.Dispose()
                    apdt = Nothing

                    If RadARInvoicingDate.SelectedDate.Value < CType(_lblSTxnDate.Text.Trim, Date) Then
                        commonFunction.MsgBox(Me, "A/R Invoice Date must be equal or greater than Sales Unit Date (" + _lblSTxnNo.Text.Trim + ").")
                        Exit Sub
                    End If

                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("STxnNo") = Trim(_lblSTxnNo.Text)
                    row("chkinvoice") = _chkinvoice.Checked
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                ' // save header first
                If RadComboBoxARInvoicingNo.Text.Trim = "" Then
                    commonFunction.MsgBox(Me, "You have to choose at least one record to be saved.")
                    Exit Sub
                Else
                    If Not _SaveHd() Then
                        Exit Sub
                    End If
                End If
            Else
                ' // save header first
                If Not _SaveHd() Then
                    Exit Sub
                End If

                ' // save the data
                Dim pudt As New BussinessRules.SalesInvoicedt
                pudt.SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                pudt.UserInsert = MyBase.LoggedOnUserID
                pudt.InsertToGridSalesInvoiceNo(tblTmp)
                pudt.Dispose()
                pudt = Nothing

                UpdateViewGridRadGridOutstandingAR()
                UpdateViewGridARInvoicing()
            End If
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("STxnNo", System.Type.GetType("System.String"))
                .Columns.Add("chkinvoice", System.Type.GetType("System.Boolean"))
            End With
        End Sub

        Private Sub _VoidHd()
            If Len(RadComboBoxARInvoicingNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to void.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesInvoiceHd
            With br
                .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .IsApproval = False Then
                        _SaveHd()
                    Else
                        Dim oARR As New BussinessRules.ARReceivingDt
                        With oARR
                            .SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
                            If .SelectSalesInvoiceNoInValidARReceiving.Rows.Count > 0 Then
                                commonFunction.MsgBox(Me, "This A/R Invoice already has A/R Receiving. Void failed.")

                                oARR.Dispose()
                                oARR = Nothing

                                GoTo GoNext
                            End If
                        End With
                        oARR.Dispose()
                        oARR = Nothing
                    End If

                    .UserVoid = MyBase.LoggedOnUserID.Trim
                    If .Void() = True Then
                        _OpenHd(RavenRecStatus.CurrentRecord)
                    End If

                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

GoNext:

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.SalesInvoicedt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridRadGridOutstandingAR()
                        UpdateViewGridARInvoicing()
                        '_SaveHd()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If

            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _DeletedtDN(ByVal DCNoteNo As String)
            If Len(DCNoteNo.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DebitCreditNote
            With br
                .DCNoteNo = DCNoteNo.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .VoucherNo.Trim = "" Then
                        commonFunction.MsgBox(Me, "Record not found.")
                    Else
                        .VoucherNo = ""
                        .IsProcess = False
                        .DeleteVoucherNo()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridDebitNote()
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
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidOther1) = True
                .lbtnOther1_Text = "Get Item DN"
            End With
        End Sub

        Private Sub PrepareScreenHd()

            RadComboBoxEntitiesID.Enabled = True

            ddlBankID.Enabled = True
            Dim bid As New BussinessRules.Bank
            commonFunction.LoadDDL(ddlBankID, "BankName", "BankID", bid.SelectAll, False)
            bid.Dispose()
            bid = Nothing

            commonFunction.LoadDDLCommonSetting("ARInvoiceTerm", ddlTermID, True)

            txtEntitiesName.Text = String.Empty


            commonFunction.ShowPanel(PanelGridOAR, True)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
            Toolbar.EnableButton(CSSToolbarItem.tidOther1) = False

            RadComboBoxARInvoicingNo.Text = String.Empty
            RadComboBoxARInvoicingNo.SelectedValue = String.Empty

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            txtCurrencyRate.ReadOnly = False
            commonFunction.SelectListItem(ddlCurrency, commonFunction.GetCurrencyPos.Trim)
            ddlCurrency.Enabled = False
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty

            RadARInvoicingDate.SelectedDate = Date.Now
            RadDueDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty

            commonFunction.ShowPanel(PnlApproved, False)
            commonFunction.ShowPanel(PnlVoid, False)

            commonFunction.ShowPanel(PanelToolbar, True)
            commonFunction.ShowPanel(PanelHeader, True)
            commonFunction.ShowPanel(PanelGridOAR, True)
            commonFunction.ShowPanel(PanelGrid, True)
            commonFunction.ShowPanel(PanelGridDebitNote, True)
            commonFunction.ShowPanel(PanelGridGetDN, False)

            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)

            UpdateViewGridRadGridOutstandingAR()
            UpdateViewGridDebitNote()
            UpdateViewGridARInvoicing()

            RadGridARInvoicing.Columns(0).Visible = True
            RadGridDebitNote.Columns(0).Visible = True
        End Sub

        Private Sub LoadARInvoicing(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesInvoiceHd

            dt = br.SelectAllForSalesInvoiceNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxARInvoicingNo.DataSource = dt.DefaultView
            RadComboBoxARInvoicingNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesInvoiceHd

            dt = br.SelectAllForEntitiesSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridARInvoicing()
            Dim total As Double = 0
            Dim br As New BussinessRules.SalesInvoicedt
            Dim dt As New DataTable

            br.SalesInvoiceNo = RadComboBoxARInvoicingNo.Text.Trim
            dt = br.SelectAllBySalesInvoiceNo()


            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    total = total + CDec(row("total"))
                Next
            Else
            End If
            txtTotal.Text = Format(total, commonFunction.FORMAT_CURRENCY)

            CalculationGrid()

            RadGridARInvoicing.DataSource = dt.DefaultView
            RadGridARInvoicing.DataBind()

            dt.Dispose()
            dt = Nothing
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridRadGridOutstandingAR()
            Dim br As New BussinessRules.SalesInvoiceHd

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim

            RadGridOutstandingAR.DataSource = br.SelectForViewGridOutstandingAR()
            RadGridOutstandingAR.DataBind()

            br.Dispose()
            br = Nothing

        End Sub

        Private Sub UpdateViewGridGetDN()
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            dt = br.SelectAllForViewGridGetARInvoicing(ddlCurrency.SelectedValue.Trim)

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDec(dtRows(i - 1)("Amount")) + CDec(dtRows(i - 1)("TaxAmount")) + CDec(dtRows(i - 1)("AmtDifferences"))
                    i += 1
                Loop
            End If

            RadGridGetDN.DataSource = dt.DefaultView
            RadGridGetDN.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridDebitNote()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.DebitCreditNote

            br.VoucherNo = RadComboBoxARInvoicingNo.Text.Trim
            dt = br.SelectAllForViewGridCNDN()

            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDec(dtRows(i - 1)("Amount")) + CDec(dtRows(i - 1)("TaxAmount")) + CDec(dtRows(i - 1)("AmtDifferences"))
                    subtotal = subtotal + CDec(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            End If

            txtDNAmount.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            CalculationGrid()

            RadGridDebitNote.DataSource = dt.DefaultView
            RadGridDebitNote.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDec(txtTotal.Text) - CDec(txtDNAmount.Text)), commonFunction.FORMAT_CURRENCY)

            'If CDec(txtGrandTotal.Text.Trim) > 0 Then
            '    RadToolbar.Items(12).Enabled = True 'Get Item DN
            'Else
            '    RadToolbar.Items(12).Enabled = False 'Get Item DN
            'End If
        End Sub
#End Region

    End Class
End Namespace