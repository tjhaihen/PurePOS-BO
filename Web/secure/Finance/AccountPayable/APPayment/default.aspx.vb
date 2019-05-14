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


Namespace Raven.Web.Secure.Finance.AccountPayable

    Public Class APPayment
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "627"

        'header
        Protected WithEvents RadAPPaymentDate As RadDatePicker
        Protected WithEvents RadDocumentDate As RadDatePicker


        Protected WithEvents ddlBankID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlAPPaymentTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtDocumentNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankAccountNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankGiroNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankGiroSerialNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankGiroGroupNo As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtAmount As System.Web.UI.WebControls.TextBox



        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents RadComboBoxAPPaymentID As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel
        Protected WithEvents PnlVoid As System.Web.UI.WebControls.Panel


        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image        
        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblAPPaymentID As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridAPPayment As DataGrid
        Protected WithEvents RadGridAPVerified As DataGrid

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'Not RadComboBoxAPPaymentID. And _
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

        Private Sub RadComboBoxAPPaymentID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxAPPaymentID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadAPPayment(e.Text)
        End Sub

        Private Sub RadComboBoxAPPaymentID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxAPPaymentID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("APPaymentNo").ToString()
        End Sub

        Private Sub RadComboBoxAPPaymentID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAPPaymentID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave
                    _Savedt()
                Case CSSToolbarItem.tidVoid
                    _VoidHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrint
                    If RadComboBoxAPPaymentID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 6271
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxAPPaymentID.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
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

            UpdateViewGridRadGridAPVerified()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            UpdateViewGridRadGridAPVerified()
        End Sub

        Private Sub ddlAPPaymentTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAPPaymentTypeID.SelectedIndexChanged
            ValidatePaymentTypeID(ddlAPPaymentTypeID.SelectedValue.Trim)
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridAPPayment_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridAPPayment.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblIDP As Label = CType(e.Item.FindControl("_lblIDP"), Label)
                    _Deletedt(_lblIDP.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridAPPayment_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridAPPayment.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim br As New BussinessRules.APPaymentHd
            With br
                .APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    'If .IsDeleted Then
                    '    'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                    '    PrepareScreenHd()
                    '    br.Dispose()
                    '    br = Nothing
                    '    Exit Sub
                    'End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxAPPaymentID.Text = .APPaymentNo.Trim
                    End If
                    RadAPPaymentDate.SelectedDate = .APPaymentDate
                    RadComboBoxEntitiesID.Text = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    txtDocumentNo.Text = .DocumentNo.Trim
                    RadDocumentDate.SelectedDate = .DocumentDate

                    commonFunction.SelectListItem(ddlAPPaymentTypeID, .APPaymentTypeID.Trim)
                    commonFunction.SelectListItem(ddlBankID, .BankID.Trim)
                    txtBankAccountNo.Text = .BankAccountNo.Trim
                    txtBankGiroNo.Text = .BankGiroNo.Trim
                    txtBankGiroSerialNo.Text = .BankGiroSerialNo.Trim
                    txtBankGiroGroupNo.Text = .BankGiroGroupNo.Trim

                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    txtAmount.Text = Format(.Amount, commonFunction.FORMAT_CURRENCY)

                    If .IsApproval Or .IsVoid Then
                        UpdateViewGridAPPayment()

                        If .IsVoid Then
                            commonFunction.ShowPanel(PnlVoid, True)
                            commonFunction.ShowPanel(PnlApproved, False)
                            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
                        ElseIf .IsApproval Then
                            commonFunction.ShowPanel(PnlVoid, False)
                            commonFunction.ShowPanel(PnlApproved, True)
                            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True
                        End If

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        
                        commonFunction.ShowPanel(PanelGrid, False)

                        RadGridAPPayment.Columns(0).Visible = False
                    Else
                        UpdateViewGridRadGridAPVerified()
                        UpdateViewGridAPPayment()

                        commonFunction.ShowPanel(PnlApproved, False)
                        commonFunction.ShowPanel(PnlVoid, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True

                        commonFunction.ShowPanel(PanelGrid, True)
                        RadGridAPPayment.Columns(0).Visible = True
                    End If

                    txtCurrencyRate.ReadOnly = True
                    RadComboBoxEntitiesID.Enabled = False
                    ddlCurrency.Enabled = False
                    ddlAPPaymentTypeID.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxAPPaymentID.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If ddlAPPaymentTypeID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "AP Payment Type Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlCurrency.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Currency Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadComboBoxEntitiesID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Entities Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If RadGridAPPayment.Items.Count > 0 Then
                Dim errNum As Integer = 0
                Dim oAPPayment As New BussinessRules.APPaymentDt
                Dim dt As New DataTable

                oAPPayment.APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                dt = oAPPayment.SelectForRadGridAPPayment()

                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        If RadAPPaymentDate.SelectedDate.Value < CDate(row("VoucherDate")) Then
                            errNum += 1
                        End If
                    Next
                End If

                oAPPayment.Dispose()
                oAPPayment = Nothing

                If errNum > 0 Then
                    commonFunction.MsgBox(Me, "A/P Payment Date must be equal or greater than Voucher Date.")
                    Return False
                    Exit Function
                End If
            End If

            Dim br As New BussinessRules.APPaymentHd
            Dim fNew As Boolean = True

            With br
                .APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxAPPaymentID.Text = BussinessRules.ID.GenerateIDNumber("APPaymenthd", "APPaymentNo", "AP")
                End If

                '// set the value
                .APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                .APPaymentDate = RadAPPaymentDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .APPaymentTypeID = ddlAPPaymentTypeID.SelectedValue.Trim
                .DocumentNo = txtDocumentNo.Text.Trim
                .DocumentDate = RadDocumentDate.SelectedDate.Value
                .BankID = ddlBankID.SelectedValue.Trim
                .BankAccountNo = txtBankAccountNo.Text.Trim
                .BankGiroNo = txtBankGiroNo.Text.Trim
                .BankGiroSerialNo = txtBankGiroSerialNo.Text.Trim
                .BankGiroGroupNo = txtBankGiroGroupNo.Text.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .Amount = CDec(txtAmount.Text.Trim)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
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

        Private Sub _Savedt()
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridAPVerified.Items
                Dim _chkpayment As CheckBox = CType(gitm.FindControl("_chkpayment"), CheckBox)
                Dim _txtpayment As TextBox = CType(gitm.FindControl("_txtpayment"), TextBox)
                Dim _lblVoucherNo As Label = CType(gitm.FindControl("_lblVoucherNo"), Label)
                Dim _lblCurrencyRate As Label = CType(gitm.FindControl("_lblCurrencyRate"), Label)
                Dim _lblVoucherDate As Label = CType(gitm.FindControl("_lblVoucherDate"), Label)

                If _chkpayment.Checked = True Then
                    'Dim ie As New BussinessRules.APInvoice
                    'ie.VoucherNo = _lblVoucherNo.Text.Trim
                    'If ie.SelectOne.Rows.Count > 0 Then
                    '    If Not ie.IsVerified Then
                    '        commonFunction.MsgBox(Me, "Voucher no. " + _lblVoucherNo.Text.Trim + " is not verified")
                    '        GoTo ExitSub
                    '    End If
                    'Else
                    '    commonFunction.MsgBox(Me, "Voucher no. " + _lblVoucherNo.Text.Trim + " Record not found.")
                    '    GoTo ExitSub
                    'End If
                    'ie.Dispose()
                    'ie = Nothing

                    If RadAPPaymentDate.SelectedDate.Value < CType(_lblVoucherDate.Text, Date) Then
                        commonFunction.MsgBox(Me, "A/P Payment Date must be equal or greater than Voucher Date.")
                        GoTo ExitSub
                    End If

                    Dim apdt As New BussinessRules.APPaymentDt
                    Dim dt As New DataTable
                    apdt.VoucherNo = _lblVoucherNo.Text.Trim
                    dt = apdt.ValidateForSaveAPPaymentDt()
                    If dt.Rows.Count > 0 Then
                        If CDbl(dt.Rows(0)("PaidAmount")) + CDbl(_txtpayment.Text.Trim) > CDbl(dt.Rows(0)("TotalAmtVoucher")) Then
                            commonFunction.MsgBox(Me, "(Voucher No. " + _lblVoucherNo.Text.Trim + ") Payment must be equal or less than balance due " + Format((CDbl(dt.Rows(0)("TotalAmtVoucher")) - CDbl(dt.Rows(0)("PaidAmount"))), commonFunction.FORMAT_CURRENCY))
                            GoTo ExitSub
                        End If
                    End If
                    dt.Dispose()
                    dt = Nothing
                    apdt.Dispose()
                    apdt = Nothing

                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("VoucherNo") = Trim(_lblVoucherNo.Text)

                    If Not IsNumeric(_txtpayment.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Payment must be numeric.")
                        GoTo ExitSub
                    End If
                    If CDbl(_txtpayment.Text.Trim) <= 0 Then
                        commonFunction.MsgBox(Me, "Payment must be greater than 0.")
                        GoTo ExitSub
                    End If
                    row("payment") = CDec(Left(Replace(_txtpayment.Text.Trim, ",", ""), 16).Trim)
                    row("CurrencyRateAP") = CDec(Left(Replace(txtCurrencyRate.Text.Trim, ",", ""), 16).Trim)
                    row("CurrencyRateIE") = CType(_lblCurrencyRate.Text.Trim, Decimal)
                    row("chkpayment") = _chkpayment.Checked
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                ' // save header first
                If RadComboBoxAPPaymentID.Text.Trim = "" Then
                    commonFunction.MsgBox(Me, "You have to choose at least one record to be saved.")
                    Exit Sub
                Else
                    If Not _SaveHd() Then
                        Exit Sub
                    End If
                End If
            Else
                ' // save header first
                If RadComboBoxAPPaymentID.Text.Trim.Length = 0 Then
                    If Not _SaveHd() Then
                        Exit Sub
                    End If
                End If

                ' // save the data
                Dim pudt As New BussinessRules.APPaymentDt
                pudt.APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                pudt.UserInsert = MyBase.LoggedOnUserID
                pudt.UserUpdate = MyBase.LoggedOnUserID
                pudt.InsertToGridAPPayment(tblTmp)
                pudt.Dispose()
                pudt = Nothing

                UpdateViewGridRadGridAPVerified()
                UpdateViewGridAPPayment()
            End If
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("VoucherNo", System.Type.GetType("System.String"))
                .Columns.Add("payment", System.Type.GetType("System.Double"))
                .Columns.Add("CurrencyRateAP", System.Type.GetType("System.Double"))
                .Columns.Add("CurrencyRateIE", System.Type.GetType("System.Double"))
                .Columns.Add("chkpayment", System.Type.GetType("System.Boolean"))
            End With
        End Sub

        Private Sub _VoidHd()
            If Len(RadComboBoxAPPaymentID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to void.")
                Exit Sub
            End If

            Dim br As New BussinessRules.APPaymentHd
            With br
                .APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    'Dim brdt As New BussinessRules.APPaymentdt
                    'brdt.APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
                    'brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    'If brdt.DeleteAllByAPPaymentNo() Then
                    .UserVoid = MyBase.LoggedOnUserID.Trim
                    If .Void() = True Then
                        _OpenHd(RavenRecStatus.CurrentRecord)
                    End If
                    'End If
                    'brdt.Dispose()
                    'brdt = Nothing
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxAPPaymentID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.APPaymentDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridRadGridAPVerified()
                        UpdateViewGridAPPayment()
                        '_SaveHd()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If

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
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub


        Private Sub PrepareScreenHd()

            RadComboBoxEntitiesID.Enabled = True
            ddlCurrency.Enabled = True
            ddlAPPaymentTypeID.Enabled = True

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)

            RadDocumentDate.SelectedDate = Date.Now

            Dim bid As New BussinessRules.Bank
            commonFunction.LoadDDL(ddlBankID, "BankName", "BankID", bid.SelectAll, False)
            bid.Dispose()
            bid = Nothing

            commonFunction.LoadDDLCommonSetting("APPaymentType", ddlAPPaymentTypeID, False)
            ddlAPPaymentTypeID.SelectedIndex = 0
            ValidatePaymentTypeID(ddlAPPaymentTypeID.SelectedValue.Trim)

            txtDocumentNo.Text = String.Empty
            txtBankAccountNo.Text = String.Empty
            txtBankGiroNo.Text = String.Empty
            txtBankGiroSerialNo.Text = String.Empty
            txtBankGiroGroupNo.Text = String.Empty
            txtEntitiesName.Text = String.Empty

            txtAmount.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            commonFunction.ShowPanel(PanelGrid, True)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            RadComboBoxAPPaymentID.Text = String.Empty
            RadComboBoxAPPaymentID.SelectedIndex = 0

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            RadComboBoxEntitiesID.SelectedIndex = 0

            RadAPPaymentDate.SelectedDate = Date.Now

            commonFunction.SelectListItem(ddlCurrency, commonFunction.GetCurrencyPos)
            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)

            commonFunction.ShowPanel(PnlVoid, False)
            commonFunction.ShowPanel(PnlApproved, False)

            UpdateViewGridRadGridAPVerified()
            UpdateViewGridAPPayment()
        End Sub

        Private Sub LoadAPPayment(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.APPaymentHd

            dt = br.SelectAllForAPPaymentNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxAPPaymentID.DataSource = dt.DefaultView
            RadComboBoxAPPaymentID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.APInvoice

            dt = br.SelectAllForEntitiesSeqNoAPPayment(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridAPPayment()
            Dim total As Double = 0
            Dim br As New BussinessRules.APPaymentDt
            Dim dt As New DataTable

            br.APPaymentNo = RadComboBoxAPPaymentID.Text.Trim
            dt = br.SelectForRadGridAPPayment()


            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    total = total + CDbl(row("Amount"))
                Next
            Else

            End If
            txtAmount.Text = Format(total, commonFunction.FORMAT_CURRENCY)

            RadGridAPPayment.DataSource = dt.DefaultView
            RadGridAPPayment.DataBind()

            dt.Dispose()
            dt = Nothing
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridRadGridAPVerified()
            Dim br As New BussinessRules.APInvoice

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim

            RadGridAPVerified.DataSource = br.SelectForViewGridAPVerified()
            RadGridAPVerified.DataBind()

            br.Dispose()
            br = Nothing

        End Sub

        Private Sub ValidatePaymentTypeID(ByVal PaymentTypeID As String)
            Select Case PaymentTypeID
                Case "02", "03", "04"
                    ddlBankID.Enabled = True
                    txtBankAccountNo.Enabled = True
                    txtBankGiroNo.Enabled = True
                    txtBankGiroSerialNo.Enabled = True
                    txtBankGiroGroupNo.Enabled = True
                Case Else
                    ddlBankID.Enabled = False
                    txtBankAccountNo.Enabled = False
                    txtBankGiroNo.Enabled = False
                    txtBankGiroSerialNo.Enabled = False
                    txtBankGiroGroupNo.Enabled = False
            End Select
        End Sub
#End Region

    End Class
End Namespace