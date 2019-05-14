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

    Public Class SalesUnitInquiryandReprint
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "701"

        Protected WithEvents lbtnRefresh As System.Web.UI.WebControls.LinkButton
        Protected WithEvents ddlFilter As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlFilterThen1 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlFilterThen2 As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFilter As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFilterThen1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFilterThen2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents RadGridSalesUnit As DataGrid

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

        Private Sub lbtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRefresh.Click
            UpdateViewGrid()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridSalesUnit_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridSalesUnit.ItemCommand
            If e.CommandName.Trim = "__PrintReceipt" Then
                Dim _STxnNo As String = CType(e.Item.FindControl("_lblSalesUnitNo"), Label).Text.Trim
                Dim _ReceiptNo As String = CType(e.Item.FindControl("_lblReceiptNo"), Label).Text.Trim
                If _ReceiptNo.Trim.Length > 0 Then
                    Dim br As New BussinessRules.PaymentHd
                    With br
                        .ReceiptNo = _ReceiptNo.Trim
                        .UserUpdate = MyBase.LoggedOnUserID.Trim
                        If .UpdatePrintCounts() Then
                            Dim oprintform As New BussinessRules.PrintForm
                            With oprintform
                                .PrintFormID = 5201
                                .MenuID = 520
                                .AddParametersPrintForm(_STxnNo.Trim)
                                .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                                Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                            End With
                            oprintform.Dispose()
                            oprintform = Nothing
                            'Response.Write("<script language=javascript>window.open('http://" + Context.Request.Url.Host + Common.HisConfiguration.ReportsFolder + "PrintForm.asp?RptName=InvoicePosFo&SP=sprpt_Invoice&parm=" + _STxnNo.Trim + "','__CetakKwBO','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>")
                        End If
                    End With
                    br.Dispose()
                    br = Nothing

                    UpdateViewGrid()
                End If
            End If
        End Sub
#End Region

#Region " Main Function (CRUD) "

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareScreen()
            SetDefaultDropDownList()
            txtFilter.Text = "*"
            txtFilterThen1.Text = "*"
            txtFilterThen2.Text = "*"
        End Sub

        Private Sub UpdateViewGrid()
            Dim br As New BussinessRules.SalesUnitHd

            RadGridSalesUnit.DataSource = br.SelectForSalesUnitInquiry(ddlFilter.SelectedValue.Trim, Replace(txtFilter.Text.Trim, "*", "%"), _
                                            ddlFilterThen1.SelectedValue.Trim, Replace(txtFilterThen1.Text.Trim, "*", "%"), _
                                            ddlFilterThen2.SelectedValue.Trim, Replace(txtFilterThen2.Text.Trim, "*", "%"))
            RadGridSalesUnit.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Function SetDefaultDropDownList() As Boolean
            '// Default Filter By
            commonFunction.SelectListItem(ddlFilter, "ReceiptDate")
            commonFunction.SelectListItem(ddlFilterThen1, "ReceiptNo")
            commonFunction.SelectListItem(ddlFilterThen2, "EntitiesName")
        End Function

        Private Function GetParamList(ByVal spName As String) As DataTable
            Dim cn As New SqlClient.SqlConnection(Raven.Common.HisConfiguration.ConnectionString)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
            Dim tbl As DataTable = New DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim strSQL As String

            strSQL = "select name, type, length from syscolumns where id = object_id('" + spName + "') and type  = '39'"

            Try
                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = strSQL
                cmd.CommandType = CommandType.Text

                da = New SqlClient.SqlDataAdapter(cmd)
                da.Fill(tbl)

                Return tbl
            Catch ex As Exception
                Raven.Common.ExceptionManager.Publish(ex)
            Finally
                If Not cn Is Nothing Then
                    cn.Dispose()
                    cn = Nothing
                End If
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not da Is Nothing Then
                    da.Dispose()
                    da = Nothing
                End If
            End Try
        End Function

#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace