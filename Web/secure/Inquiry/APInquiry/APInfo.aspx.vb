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

    Public Class APInfo
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "
        'header
        'detail
        Protected WithEvents lblAPInfoType As Label
        Protected WithEvents lblNo As Label
        Protected WithEvents txtNo As TextBox
        Protected WithEvents lblDateCaption As Label
        Protected WithEvents txtDate As TextBox
        Protected WithEvents lblEntitiesID As Label
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox
        Protected WithEvents lblEntitiesNameCaption As Label
        Protected WithEvents txtEntitiesName As TextBox
        Protected WithEvents lblWhIDCaption As Label
        Protected WithEvents ddlWhID As DropDownList
        Protected WithEvents lblUnitIDCaption As Label
        Protected WithEvents ddlUnitID As DropDownList
        Protected WithEvents lblCurrencyCaption As Label
        Protected WithEvents ddlCurrency As DropDownList
        Protected WithEvents lblCurrencyRateCaption As Label
        Protected WithEvents txtCurrencyRate As TextBox
        Protected WithEvents lblInvoiceNoCaption As Label
        Protected WithEvents txtInvoiceNo As TextBox
        Protected WithEvents lblDescriptionHdCaption As Label
        Protected WithEvents txtDescriptionHd As TextBox
        Protected WithEvents RadGridInfo As DataGrid
        Protected WithEvents lblTotalCaption As Label
        Protected WithEvents txtTotal As TextBox
        Protected WithEvents lblDiscFinalPctCaption As Label
        Protected WithEvents txtDiscFinalPct As TextBox
        Protected WithEvents lblDiscFinalAmtCaption As Label
        Protected WithEvents txtDiscFinalAmt As TextBox
        Protected WithEvents chkIsPPN As CheckBox
        Protected WithEvents txtPPNpct As TextBox
        Protected WithEvents lblPPNCaption As Label
        Protected WithEvents txtPPN As TextBox
        Protected WithEvents lblGrandTotalCaption As Label
        Protected WithEvents txtGrandTotal As TextBox


        Private _TxnNo As String = String.Empty
        Private _Type As String = String.Empty
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxPurchaseUnitID.IsCallBack And Not RadComboBoxEntitiesID.IsCallBack Then
                Dim fQueryStringExist As Boolean = ReadQueryString()
                PrepareScreenHd()

                If fQueryStringExist Then
                    txtNo.Text = _TxnNo.Trim
                    If _Type = "punit" Then
                        lblAPInfoType.Text = "Purchase Unit"
                        _OpenPUnitHd(RavenRecStatus.CurrentRecord)
                        UpdateViewGridInfoPUnit()
                    Else
                        lblAPInfoType.Text = "Purchase Return"
                        _OpenPReturnHd(RavenRecStatus.CurrentRecord)
                        UpdateViewGridInfoPReturn()
                    End If
                End If
            End If
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDbl(txtPPNpct.Text.Trim) * (CDbl(txtTotal.Text.Trim) - CDbl(txtDiscFinalAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalPct.TextChanged
            If Not IsNumeric(txtDiscFinalPct.Text) Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) must be numeric")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalPct.Text.Trim) < 0 OrElse CDec(txtDiscFinalPct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) Must Be 0% - 100%.")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtDiscFinalPct.Text = Format(CDbl(txtDiscFinalPct.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format((CDbl(txtDiscFinalPct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalAmt.TextChanged
            If Not IsNumeric(txtDiscFinalAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount Final Must Be Numeric.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount Final Must Be equal Or Greater than 0.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtDiscFinalAmt.Text = Format(CDbl(txtDiscFinalAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            CalculationGrid()
        End Sub

        Private Sub ddlWhID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWhID.SelectedIndexChanged
            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub createTmpTable(ByRef tbl As DataTable)
            tbl = New DataTable
            With tbl
                .Columns.Add("IDPO", System.Type.GetType("System.String"))
                .Columns.Add("ItemSeqNo", System.Type.GetType("System.String"))
                .Columns.Add("ItemUnitID", System.Type.GetType("System.String"))
                .Columns.Add("QtyReceived", System.Type.GetType("System.Double"))
                .Columns.Add("ItemFactor", System.Type.GetType("System.Double"))
                .Columns.Add("Price", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc1Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc2Amt", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Pct", System.Type.GetType("System.Double"))
                .Columns.Add("Disc3Amt", System.Type.GetType("System.Double"))
                .Columns.Add("POrdNO", System.Type.GetType("System.String"))
                .Columns.Add("IsBonus", System.Type.GetType("System.Boolean"))
            End With
        End Sub

#End Region

#Region " DataGrid Command Center "
        
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenPUnitHd(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim br As New BussinessRules.PurchaseUnitHd
            With br
                .PUnitNO = txtNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                        PrepareScreenHd()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        _TxnNo = .PUnitNO.Trim
                    End If
                    txtDate.Text = Format(.PUnitDate, commonFunction.FORMAT_DATE)
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)
                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)
                    txtInvoiceNo.Text = .InvoiceNo.Trim
                    txtDescriptionHd.Text = .Description.Trim
                    txtDiscFinalPct.Text = Format(.DiscFinalPct, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format(.DiscFinalAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridInfoPUnit()

                    RadComboBoxEntitiesID.Enabled = False
                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                    ddlCurrency.Enabled = False
                Else
                    PrepareScreenHd()
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _OpenPReturnHd(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim br As New BussinessRules.PurchaseReturnHd
            With br
                .PReturnNO = txtNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        txtNo.Text = .PReturnNO.Trim
                    End If
                    txtDate.Text = Format(.PReturnDate, commonFunction.FORMAT_DATE)
                    commonFunction.SelectListItem(ddlWhID, .WhID.Trim)

                    ddlWhID_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlUnitID, .UnitID.Trim)

                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)

                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)

                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)

                    'commonFunction.SelectListItem(ddlReason, .PReturnReasonID.Trim)
                    txtDescriptionHd.Text = .Description.Trim
                    txtDiscFinalPct.Text = Format(.ReturnFeePct, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format(.ReturnFeeAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridInfoPReturn()

                    ddlWhID.Enabled = False
                    ddlUnitID.Enabled = False
                Else
                    PrepareScreenHd()
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
            _Type = Request.QueryString("type")
            _TxnNo = Request.QueryString("no")

            Return _Type.Length > 0 And _TxnNo.Length > 0
        End Function

        Private Sub PrepareScreenHd()
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)

            Dim wh As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlWhID, "WHName", "WHID", wh.SelectAllWarehouse, False)
            wh.Dispose()
            wh = Nothing

            Dim whunit As New BussinessRules.Warehouse
            commonFunction.LoadDDL(ddlUnitID, "UnitName", "UnitID", whunit.SelectAllUnitByWarehouse(ddlWhID.SelectedValue.Trim), False)
            whunit.Dispose()
            whunit = Nothing

            txtNo.Text = String.Empty
            
            txtDate.Text = Format(Date.Now, commonFunction.FORMAT_DATE)
            txtDescriptionHd.Text = String.Empty
            txtInvoiceNo.Text = String.Empty

            ddlWhID.SelectedIndex = 0
            ddlUnitID.SelectedIndex = 0
            ddlCurrency.SelectedIndex = 0
            txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            txtDescriptionHd.Text = String.Empty
            
            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty

            commonFunction.GetTaxPct(txtPPNpct)

            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)

            UpdateViewGridInfoPUnit()
            UpdateViewGridInfoPReturn()
            CalculationGrid()            
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) - CDbl(txtDiscFinalAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridInfoPUnit()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim MaxCurrencyRate As Double = 1
            Dim dt As DataTable

            Dim br As New BussinessRules.PurchaseUnitDt
            br.PUnitNO = txtNo.Text.Trim
            dt = br.SelectForViewGrid
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                MaxCurrencyRate = CDbl(dtRows(i - 1)("CurrencyRate"))
                Do While i <= dtRows.Length
                    If CDbl(dtRows(i - 1)("CurrencyRate")) > MaxCurrencyRate Then
                        MaxCurrencyRate = CDbl(dtRows(i - 1)("CurrencyRate"))
                    End If
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtCurrencyRate.Text = Format(MaxCurrencyRate, commonFunction.FORMAT_CURRENCY)
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                If CDbl(txtDiscFinalPct.Text.Trim) = 0 Then
                    txtDiscFinalAmt_TextChanged(Nothing, Nothing)
                Else
                    txtDiscFinalPct_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)                
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.ReadOnly = True
                txtDiscFinalAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridInfo.DataSource = dt.DefaultView
            RadGridInfo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridInfoPReturn()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseReturnDt
            br.PReturnNO = txtNo.Text.Trim
            dt = br.SelectForViewGrid()

            dt.Columns.Add("subtotal", GetType(System.Double))
            dt.Columns.Add("IsBonus", GetType(System.Boolean))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("IsBonus") = False
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt")) - CDbl(dtRows(i - 1)("ReturnFeeAmt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If

            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                If CDbl(txtDiscFinalPct.Text.Trim) = 0 Then
                    txtDiscFinalAmt_TextChanged(Nothing, Nothing)
                Else
                    txtDiscFinalPct_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)                
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.ReadOnly = True
                txtDiscFinalAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridInfo.DataSource = dt.DefaultView
            RadGridInfo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub
#End Region

    End Class
End Namespace