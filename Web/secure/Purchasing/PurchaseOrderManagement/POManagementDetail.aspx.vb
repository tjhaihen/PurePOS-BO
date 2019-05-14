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

Namespace Raven.Web.Secure.Purchasing

    Public Class POManagementDetail
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "340"
        Protected WithEvents lblPONO As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadGridPurchaseOrderManagementDetail As DataGrid

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDPAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If
                setToolbarVisibledButton()
                If ReadQueryString() = True Then

                    PrepareScreen()
                    DataBind()
                End If
            End If
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
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
            lblPONO.Text = Common.ProcessNull.GetString((Request.QueryString("PONo")).Trim)
            Return (Len(lblPONO.Text.Trim) > 0)
        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidDelete) = False
                .VisibleButton(CSSToolbarItem.tidSave) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub


        Private Sub PrepareScreen()
            UpdateViewGridPODt()
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) - CDbl(txtDiscFinalAmt.Text) - CDbl(txtDPAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridPODt()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim brHd As New BussinessRules.PurchaseOrderHd
            Dim br As New BussinessRules.PurchaseOrderDt
            brHd.POrdNO = lblPONO.Text.Trim
            br.POrdNO = lblPONO.Text.Trim
            dt = br.SelectForViewGridPOManagementDetail
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                If brHd.SelectOne.Rows.Count > 0 Then
                    txtDiscFinalPct.Text = Format(brHd.DiscFinalAmt, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format((CDbl(txtDiscFinalPct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
                    chkIsPPN.Checked = brHd.IsPPN
                    txtPPNpct.Text = Format(IIf(brHd.PPNPct = 0, CDec(txtPPNpct.Text), brHd.PPNPct), commonFunction.FORMAT_CURRENCY)
                    If chkIsPPN.Checked Then
                        txtPPN.Text = Format((brHd.PPNPct * (CDbl(txtTotal.Text.Trim) - CDbl(txtDiscFinalAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
                    Else
                        txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    End If
                End If
            Else
                chkIsPPN.Checked = False
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If

            CalculationGrid()

            RadGridPurchaseOrderManagementDetail.DataSource = dt.DefaultView
            RadGridPurchaseOrderManagementDetail.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPurchaseOrder()
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderDt

            br.POrdNO = lblPONO.Text.Trim
            dt = br.SelectForViewGridPOManagementDetail
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))
                    '    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If

            RadGridPurchaseOrderManagementDetail.DataSource = dt.DefaultView
            RadGridPurchaseOrderManagementDetail.DataBind()

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