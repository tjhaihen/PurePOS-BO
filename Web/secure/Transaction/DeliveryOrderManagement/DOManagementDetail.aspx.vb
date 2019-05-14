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

    Public Class DOManagementDetail
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "511"
        Protected WithEvents lblDONO As System.Web.UI.WebControls.Label
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadGridDeliveryOrderManagementDetail As DataGrid

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
            lblDONO.Text = Common.ProcessNull.GetString((Request.QueryString("DONo")).Trim)
            Return (Len(lblDONO.Text.Trim) > 0)
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
            End With
        End Sub

        Private Sub PrepareScreen()
            UpdateViewGridDODt()
        End Sub

        Private Sub UpdateViewGridDODt()
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryOrderDt

            br.DONO = lblDONO.Text.Trim
            dt = br.SelectForViewGridDOManagementDetail
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then
                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))                    
                    i += 1
                Loop
            Else

            End If

            RadGridDeliveryOrderManagementDetail.DataSource = dt.DefaultView
            RadGridDeliveryOrderManagementDetail.DataBind()

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