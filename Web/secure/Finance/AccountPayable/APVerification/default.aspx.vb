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

    Public Class APVerification
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "626"

        
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadDueDate As RadDatePicker
        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox

        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager        
        Protected WithEvents RadGridAPVerification As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'And Not RadComboBoxEntitiesID.IsCallBack Then
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
            UpdateViewGridAPVerification()
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            UpdateViewGridAPVerification()
        End Sub

        'Private Sub RadDueDate_SelectedDateChanged(ByVal sender As Object, ByVal e As SelectedDateChangedEventArgs) Handles RadDueDate.SelectedDate.ValueChanged
        '    UpdateViewGridAPVerification()
        'End Sub
#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Main Function (CRUD) "

        Private Sub _Save()
            Dim totalRowSelected As Integer = 0
            Dim tblTmp As DataTable = createTmpTable()

            Dim _item As DataGridItem

            For Each _item In RadGridAPVerification.Items
                Dim _chkIsVerification As CheckBox = CType(_item.FindControl("_chkIsVerification"), CheckBox)
                Dim _lblVoucherNo As Label = CType(_item.FindControl("_lblVoucherNo"), Label)

                If _chkIsVerification.Checked Then
                    Dim brIE As New BussinessRules.APInvoice
                    With brIE
                        .VoucherNo = _lblVoucherNo.Text.Trim
                        If .SelectOne.Rows.Count > 0 Then
                            If Not .IsApproval Then
                                commonFunction.MsgBox(Me, "Voucher No. " + _lblVoucherNo.Text.Trim + " is not approved.")
                                Exit Sub
                            End If
                        Else
                            commonFunction.MsgBox(Me, "Voucher No. " + _lblVoucherNo.Text.Trim + " is not found.")
                            Exit Sub
                        End If
                    End With
                    brIE.Dispose()
                    brIE = Nothing

                    Dim row As DataRow = tblTmp.NewRow
                    row("chkIsVerification") = _chkIsVerification.Checked
                    row("VoucherNo") = _lblVoucherNo.Text.Trim
                    tblTmp.Rows.Add(row)
                    totalRowSelected += 1
                End If
            Next

            If totalRowSelected > 0 Then
                Dim br As New BussinessRules.APInvoice
                With br
                    br.UserVerified = MyBase.LoggedOnUserID.Trim
                    If br.UpdateStatusVerification(tblTmp) Then
                        UpdateViewGridAPVerification()
                        PrepareScreen()
                    End If
                End With
                br.Dispose()
                br = Nothing
            Else
                commonFunction.MsgBox(Me, "You to choose at least one record to be Release")
                Exit Sub
            End If
        End Sub

        Private Function createTmpTable() As DataTable
            Dim tbl As DataTable = New DataTable

            With tbl
                .Columns.Add("chkIsVerification", System.Type.GetType("System.Boolean"))
                .Columns.Add("VoucherNo", System.Type.GetType("System.String"))
            End With

            Return tbl
        End Function

#End Region

#Region " Main Function (Custom) "


#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
            End With
        End Sub

        Private Sub PrepareScreen()

            'Dim cr As New BussinessRules.APInvoice
            'cr.EntitiesSeqNo = RadComboBoxEntitiesID.selectedvalue.Trim
            'commonFunction.LoadDDL(ddlCurrency, "CurrencyName", "Currency", cr.SelectAllForCurrencyAPVerification, False)
            'cr.Dispose()
            'cr = Nothing
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            txtEntitiesName.Text = String.Empty
            RadDueDate.SelectedDate = Date.Now
            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedIndex = 0
            UpdateViewGridAPVerification()
        End Sub

        Private Sub UpdateViewGridAPVerification()
            Dim subtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.APInvoice

            br.EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
            br.Currency = ddlCurrency.SelectedValue.Trim
            br.DueDate = RadDueDate.SelectedDate.Value
            dt = br.SelectForViewGridAPVerification()

            dt.Columns.Add("subtotal", GetType(System.Double))
            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = CDbl(dtRows(i - 1)("TotalPU")) + CDbl(dtRows(i - 1)("TaxAmount")) + CDbl(dtRows(i - 1)("BankAdmFee")) + _
                                                CDbl(dtRows(i - 1)("DeliveryFee")) + CDbl(dtRows(i - 1)("StampDutyFee")) - _
                                                CDbl(dtRows(i - 1)("CNAmount")) - CDbl(dtRows(i - 1)("DPAmt")) + CDbl(dtRows(i - 1)("RoundingAmt"))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else
            End If

            RadGridAPVerification.DataSource = dt.DefaultView
            RadGridAPVerification.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.APInvoice

            dt = br.SelectAllForEntitiesSeqNoAPVerification(Filter.Trim, commonFunction.MaxRecord)

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