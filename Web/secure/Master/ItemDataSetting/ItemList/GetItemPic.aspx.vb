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
Imports System.IO
Imports System.Data.SqlTypes

Imports Microsoft.VisualBasic

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Web.Secure.Master.ItemDataSetting
    Public Class GetItemPic
        Inherits PageBase

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
            Dim strItemSeqNo As String
            If (Len(Request.QueryString("no").Trim) > 0) Then
                Dim br As New BussinessRules.ItemPhoto
                br.ItemSeqNo = Request.QueryString("no").Trim
                If br.SelectByItemSeqNo.Rows.Count > 0 Then
                    Response.BinaryWrite(br.ItemPhoto.Value)
                Else

                End If
                br.Dispose()
                br = Nothing
            End If
        End Sub

    End Class
End Namespace

