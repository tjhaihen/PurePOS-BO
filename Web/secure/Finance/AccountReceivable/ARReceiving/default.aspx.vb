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

    Public Class ARReceiving
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "632"

        'header
        Protected WithEvents RadARReceivingDate As RadDatePicker
        Protected WithEvents RadDocumentDate As RadDatePicker


        Protected WithEvents ddlBankID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlARReceivingTypeID As System.Web.UI.WebControls.DropDownList
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
        Protected WithEvents RadComboBoxARReceivingID As RadComboBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel
        Protected WithEvents PnlVoid As System.Web.UI.WebControls.Panel


        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblARReceivingID As System.Web.UI.WebControls.Label

        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        'grid
        Protected WithEvents RadGridARReceiving As DataGrid
        Protected WithEvents RadGridARInvoicing As DataGrid

        'panel
        Protected WithEvents PanelToolbar As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelHeader As System.Web.UI.WebControls.Panel
        Protected WithEvents PanelGrid As System.Web.UI.WebControls.Panel


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxARReceivingID.IsCallBack And _
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

        Private Sub RadComboBoxARReceivingID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxARReceivingID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadARReceiving(e.Text)
        End Sub

        Private Sub RadComboBoxARReceivingID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxARReceivingID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ARReceivingNo").ToString()
        End Sub

        Private Sub RadComboBoxARReceivingID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxARReceivingID.SelectedIndexChanged
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
                    If RadComboBoxARReceivingID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 6321
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxARReceivingID.Text.Trim)
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

            UpdateViewGridRadGridARInvoicing()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            UpdateViewGridRadGridARInvoicing()
        End Sub

        Private Sub ddlARReceivingTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlARReceivingTypeID.SelectedIndexChanged
            ValidatePaymentTypeID(ddlARReceivingTypeID.SelectedValue.Trim)
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridARReceiving_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridARReceiving.ItemCommand
            Select Case e.CommandName
                Case "Delete"
                    Dim _lblIDP As Label = CType(e.Item.FindControl("_lblIDP"), Label)
                    _Deletedt(_lblIDP.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridARReceiving_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridARReceiving.ItemCreated
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

            Dim br As New BussinessRules.ARReceivingHd
            With br
                .ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    'If .IsDeleted Then
                    '    'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                    '    PrepareScreenHd()
                    '    br.Dispose()
                    '    br = Nothing
                    '    Exit Sub
                    'End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxARReceivingID.Text = .ARReceivingNo.Trim
                    End If
                    RadARReceivingDate.SelectedDate = .ARReceivingDate
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    txtDocumentNo.Text = .DocumentNo.Trim
                    RadDocumentDate.SelectedDate = .DocumentDate

                    commonFunction.SelectListItem(ddlARReceivingTypeID, .ARReceivingTypeID.Trim)
                    commonFunction.SelectListItem(ddlBankID, .BankID.Trim)
                    txtBankAccountNo.Text = .BankAccountNo.Trim
                    txtBankGiroNo.Text = .BankGiroNo.Trim
                    txtBankGiroSerialNo.Text = .BankGiroSerialNo.Trim
                    txtBankGiroGroupNo.Text = .BankGiroGroupNo.Trim

                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    txtAmount.Text = Format(.Amount, commonFunction.FORMAT_CURRENCY)

                    If .IsApproval Or .IsVoid Then
                        UpdateViewGridARReceiving()

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
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False

                        commonFunction.ShowPanel(PanelGrid, False)

                        RadGridARReceiving.Columns(0).Visible = False
                    Else
                        UpdateViewGridRadGridARInvoicing()
                        UpdateViewGridARReceiving()

                        commonFunction.ShowPanel(PnlApproved, False)
                        commonFunction.ShowPanel(PnlVoid, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

                        commonFunction.ShowPanel(PanelGrid, True)
                        RadGridARReceiving.Columns(0).Visible = True


                    End If

                    txtCurrencyRate.ReadOnly = True
                    RadComboBoxEntitiesID.Enabled = False
                    ddlARReceivingTypeID.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxARReceivingID.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If ddlARReceivingTypeID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "AR Receiving Type Cannot Empty.")
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

            If FApproval = True Then
                Dim errCount As Integer = 0
                Dim oARInvDt As New BussinessRules.ARReceivingDt
                With oARInvDt
                    .ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                    If .SelectForRadGridARReceiving.Rows.Count = 0 Then
                        errCount += 1
                    End If
                End With
                oARInvDt.Dispose()
                oARInvDt = Nothing

                If errCount > 1 Then
                    commonFunction.MsgBox(Me, "This A/R Receiving No. does not have A/R Invoice items. Approval failed.")
                    Return False
                    Exit Function
                End If
            End If

            Dim br As New BussinessRules.ARReceivingHd
            Dim fNew As Boolean = True

            With br
                .ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxARReceivingID.Text = BussinessRules.ID.GenerateIDNumber("ARReceivinghd", "ARReceivingNo", "AR")
                End If

                '// set the value
                .ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                .ARReceivingDate = RadARReceivingDate.SelectedDate.Value
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .ARReceivingTypeID = ddlARReceivingTypeID.SelectedValue.Trim
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

        Private Sub _SaveDt()
            Dim rowCount As Integer = 0
            Dim tblTmp As DataTable
            createTmpTable(tblTmp)

            'Loop through each DataGridItem, and determine which CheckBox controls have been selected.
            Dim gitm As DataGridItem
            For Each gitm In RadGridARInvoicing.Items
                Dim _chkpayment As CheckBox = CType(gitm.FindControl("_chkpayment"), CheckBox)
                Dim _txtpayment As TextBox = CType(gitm.FindControl("_txtpayment"), TextBox)
                Dim _lblSalesInvoiceNo As Label = CType(gitm.FindControl("_lblSalesInvoiceNo"), Label)
                Dim _lblCurrencyRate As Label = CType(gitm.FindControl("_lblCurrencyRate"), Label)
                Dim _lblSalesInvoiceDate As Label = CType(gitm.FindControl("_lblSalesInvoiceDate"), Label)

                If _chkpayment.Checked = True Then

                    Dim ie As New BussinessRules.SalesInvoiceHd
                    ie.SalesInvoiceNo = _lblSalesInvoiceNo.Text.Trim
                    If ie.SelectOne.Rows.Count > 0 Then
                        If ie.IsVoid Then
                            commonFunction.MsgBox(Me, "Invoice No. " + _lblSalesInvoiceNo.Text.Trim + " is already Void")
                            GoTo ExitSub
                        End If
                    Else
                        commonFunction.MsgBox(Me, "Record with Invoice No. " + _lblSalesInvoiceNo.Text.Trim + " not found.")
                        GoTo ExitSub
                    End If
                    ie.Dispose()
                    ie = Nothing

                    Dim apdt As New BussinessRules.SalesInvoicedt
                    Dim dt As New DataTable
                    apdt.SalesInvoiceNo = _lblSalesInvoiceNo.Text.Trim
                    dt = apdt.ValidateForSaveARReceivingDt()
                    If dt.Rows.Count > 0 Then
                        If CDbl(dt.Rows(0)("PaidAmount")) + CDbl(_txtpayment.Text.Trim) > CDbl(dt.Rows(0)("Total")) Then
                            commonFunction.MsgBox(Me, "(Invoice No. " + _lblSalesInvoiceNo.Text.Trim + ") Payment must be equal or less than Balance Due " + Format((CDbl(dt.Rows(0)("Total")) - CDbl(dt.Rows(0)("PaidAmount"))), commonFunction.FORMAT_CURRENCY))
                            GoTo ExitSub
                        End If
                    End If
                    dt.Dispose()
                    dt = Nothing
                    apdt.Dispose()
                    apdt = Nothing

                    If RadARReceivingDate.SelectedDate.Value < CType(_lblSalesInvoiceDate.Text.Trim, Date) Then
                        commonFunction.MsgBox(Me, "A/R Receiving Date must be equal or greater than A/R Invoice Date (" + _lblSalesInvoiceNo.Text.Trim + ").")
                        Exit Sub
                    End If

                    rowCount += 1

                    Dim row As DataRow = tblTmp.NewRow
                    row("InvoiceNo") = Trim(_lblSalesInvoiceNo.Text)

                    If Not IsNumeric(_txtpayment.Text.Trim) Then
                        commonFunction.MsgBox(Me, "Payment must be numeric.")
                        GoTo ExitSub
                    End If
                    'If CDbl(_txtpayment.Text.Trim) <= 0 Then
                    '    commonFunction.MsgBox(Me, "Payment must be greater than 0.")
                    '    GoTo ExitSub
                    'End If CDec(Left(Replace(txtSalesMarginPct.Text.Trim, ",", ""), 16))
                    row("payment") = CDec(Left(Replace(_txtpayment.Text.Trim, ",", ""), 16))
                    row("CurrencyRateAP") = CType(txtCurrencyRate.Text.Trim, Double)
                    row("CurrencyRateIE") = CType(_lblCurrencyRate.Text.Trim, Double)
                    row("chkpayment") = _chkpayment.Checked
                    tblTmp.Rows.Add(row)
                End If
            Next

            If rowCount = 0 Then
                ' // save header first
                If RadComboBoxARReceivingID.Text.Trim = "" Then
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
                Dim pudt As New BussinessRules.ARReceivingDt
                pudt.ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                pudt.UserInsert = MyBase.LoggedOnUserID
                pudt.UserUpdate = MyBase.LoggedOnUserID
                pudt.InsertToGridARReceiving(tblTmp)
                pudt.Dispose()
                pudt = Nothing

                UpdateViewGridRadGridARInvoicing()
                UpdateViewGridARReceiving()
            End If
ExitSub:
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("InvoiceNo", System.Type.GetType("System.String"))
                .Columns.Add("payment", System.Type.GetType("System.Double"))
                .Columns.Add("CurrencyRateAP", System.Type.GetType("System.Double"))
                .Columns.Add("CurrencyRateIE", System.Type.GetType("System.Double"))
                .Columns.Add("chkpayment", System.Type.GetType("System.Boolean"))
            End With
        End Sub

        Private Sub _VoidHd()
            If Len(RadComboBoxARReceivingID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to void.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ARReceivingHd
            With br
                .ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    .UserVoid = MyBase.LoggedOnUserID.Trim
                    If .Void() = True Then
                        _OpenHd(RavenRecStatus.CurrentRecord)
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxARReceivingID.ClientID)
        End Sub

        Private Sub _Deletedt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ARReceivingDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        UpdateViewGridRadGridARInvoicing()
                        UpdateViewGridARReceiving()
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
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
            End With
        End Sub

        Private Sub PrepareScreenHd()

            RadComboBoxEntitiesID.Enabled = True

            ddlARReceivingTypeID.Enabled = True

            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            ddlCurrency.Enabled = False
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)

            RadDocumentDate.SelectedDate = Date.Now

            Dim bid As New BussinessRules.Bank
            commonFunction.LoadDDL(ddlBankID, "BankName", "BankID", bid.SelectAll, False)
            bid.Dispose()
            bid = Nothing

            commonFunction.LoadDDLCommonSetting("ARReceivingType", ddlARReceivingTypeID, False)
            ddlARReceivingTypeID.SelectedIndex = 0
            ValidatePaymentTypeID(ddlARReceivingTypeID.SelectedValue.Trim)

            txtDocumentNo.Text = String.Empty
            txtBankAccountNo.Text = String.Empty
            txtBankGiroNo.Text = String.Empty
            txtBankGiroSerialNo.Text = String.Empty
            txtBankGiroGroupNo.Text = String.Empty
            txtEntitiesName.Text = String.Empty

            txtAmount.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            commonFunction.ShowPanel(PanelGrid, True)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False

            RadComboBoxARReceivingID.Text = String.Empty
            RadComboBoxARReceivingID.SelectedValue = String.Empty

            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty

            RadARReceivingDate.SelectedDate = Date.Now

            commonFunction.SelectListItem(ddlCurrency, commonFunction.GetCurrencyPos)
            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)

            commonFunction.ShowPanel(PnlVoid, False)
            commonFunction.ShowPanel(PnlApproved, False)

            UpdateViewGridRadGridARInvoicing()
            UpdateViewGridARReceiving()
        End Sub

        Private Sub LoadARReceiving(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ARReceivingHd

            dt = br.SelectAllForARReceivingNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxARReceivingID.DataSource = dt.DefaultView
            RadComboBoxARReceivingID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.SalesInvoiceHd

            dt = br.SelectAllForEntitiesSeqNoARReceiving(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridARReceiving()
            Dim total As Double = 0
            Dim br As New BussinessRules.ARReceivingDt
            Dim dt As New DataTable

            br.ARReceivingNo = RadComboBoxARReceivingID.Text.Trim
            dt = br.SelectForRadGridARReceiving()


            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    total = total + CDbl(row("Amount"))
                Next
            Else

            End If
            txtAmount.Text = Format(total, commonFunction.FORMAT_CURRENCY)

            RadGridARReceiving.DataSource = dt.DefaultView
            RadGridARReceiving.DataBind()

            dt.Dispose()
            dt = Nothing
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridRadGridARInvoicing()
            Dim br As New BussinessRules.SalesInvoiceHd

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim

            RadGridARInvoicing.DataSource = br.SelectForViewGridARInvoicing()
            RadGridARInvoicing.DataBind()

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