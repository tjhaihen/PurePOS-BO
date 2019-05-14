Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Namespace Raven.Web

    Public Class _Default
        Inherits PageBase
        Protected WithEvents cLogo As System.Web.UI.WebControls.ImageButton

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Response.Redirect("secure/main.aspx")
            Dim txtScript As New System.Text.StringBuilder()


            txtScript.Append("<script language=JavaScript> function openMainWindow(){")
            txtScript.Append("var hwnd = window.open('" + PageBase.UrlBase + "/secure/main.aspx" + "', '_blank', 'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes');}<")
            txtScript.Append("/")
            txtScript.Append("script>")

            'Page.RegisterStartupScript("openMainPage", txtScript.ToString)
            If Not Page.IsClientScriptBlockRegistered("openMainPage") Then
                Page.RegisterClientScriptBlock("openMainPage", txtScript.ToString)
            End If
        End Sub

    End Class

End Namespace