Namespace Raven.Web

    Partial Public Class CRReportViewer
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim shcr As New ShowCR

                Dim menuID As String = Request.QueryString("mnu")
                Dim rptCode As String = Request.QueryString("rpt")
                Dim parVal As String = Request.QueryString("par")
                Dim opener As String = Request.QueryString("opn")

                If opener = "Report" Then
                    shcr.CreateReport(opener, rptCode, rptViewer, parVal)
                Else
                    shcr.CreatePrintForm(opener, rptCode, menuID, rptViewer, parVal)
                End If                
            End If
        End Sub

    End Class

End Namespace