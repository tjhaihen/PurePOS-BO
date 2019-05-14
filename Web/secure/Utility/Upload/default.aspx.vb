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
Imports System.IO

Imports Microsoft.VisualBasic

Imports Telerik.Web.UI

Imports Raven
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.SystemFramework

Namespace Raven.Web.Secure.Utility

    Public Class Upload
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "253"
        Protected WithEvents lbtnUploadScale As System.Web.UI.WebControls.LinkButton
        Protected WithEvents RadGridULScale As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                PrepareScreen(False)

                DataBind()
            End If
        End Sub

        Private Sub lbtnUploadScale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnUploadScale.Click
            _UploadItemPriceToScale()
            UpdateViewGridULScale()
        End Sub

#End Region

#Region " DataGrid Command Center "
        
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            
        End Sub

        Private Function _UploadItemPriceToScale() As Boolean
            Dim b As Boolean = False
            Dim TotalRecord As Decimal = 0D
            Dim cm As New BussinessRules.CommonSetting
            Dim br As New BussinessRules.UploadDownload
            Dim dt As New DataTable             

            Try
                dt = br.UploadItemPriceToScale()
                TotalRecord = dt.Rows.Count

                _SaveUploadScale(TotalRecord, "Upload Succeed", "Success")

                Dim exeScaleFileDir As String
                cm.GroupID = "FileDir"
                cm.DetailID = "EXEScale"
                If cm.SelecOneByGroupIDByDetailID.Rows.Count > 0 Then
                    exeScaleFileDir = cm.DetailDesc.Trim
                Else
                    exeScaleFileDir = String.Empty
                End If

                System.Diagnostics.Process.Start(exeScaleFileDir)                

                b = True
            Catch ex As Exception
                _SaveUploadScale(TotalRecord, ex.ToString.Trim, "Failed")
                b = False
            End Try

            br.Dispose()
            br = Nothing

            cm.Dispose()
            cm = Nothing

            Return b
        End Function

        Private Sub _SaveUploadScale(ByVal TotalRecord As Decimal, ByVal Description As String, ByVal UpdateStatus As String)
            Dim br As New BussinessRules.UploadDownload

            With br
                .ID = BussinessRules.ID.GenerateIDNumber("UploadDownload", "ID")

                '// set the value
                .Type = "UL"
                .TotalRecord = TotalRecord
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .UpdateStatus = UpdateStatus.Trim
                .Description = "Scale; " + Description.Trim

                If .Insert() Then
                    UpdateViewGridULScale()
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()

        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub PrepareScreen(ByVal fnew As Boolean)
            UpdateViewGridULScale()
        End Sub

        Private Sub UpdateViewGridULScale()
            Dim dt As DataTable
            Dim br As New BussinessRules.UploadDownload

            br.Type = "UL"            
            dt = br.SelectByTypePrefixDescription("Scale")

            RadGridULScale.DataSource = dt.DefaultView
            RadGridULScale.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace