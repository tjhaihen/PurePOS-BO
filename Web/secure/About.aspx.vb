Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.Data.SqlTypes
Imports Telerik.Web.UI

Imports Raven.Common

Namespace Raven.Web

    Public Class About
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

#End Region

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

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else

            End If
        End Sub
#End Region

#Region " DataGrid Command Center "

#End Region

#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean

        End Function
#End Region

#Region " Main Function Open, Save, Delete "

#End Region

    End Class

End Namespace