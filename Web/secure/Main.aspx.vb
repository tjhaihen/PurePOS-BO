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

Imports Raven.Common

Namespace Raven.Web

    Public Class Main
        Inherits PageBase

        'Protected WithEvents panelListInformasiPasien As System.Web.UI.WebControls.Panel
        'Protected WithEvents lblTotalRegistrasiPasien As System.Web.UI.WebControls.Label
        'Protected WithEvents lblTahun As System.Web.UI.WebControls.Label


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
            'lblTahun.Text = "©" + Date.Now.Year.ToString
            '_buildListInformasiPasien()
        End Sub

        'Private Sub _buildListInformasiPasien()
        '    Dim NewSetVar As New Common.SetVar
        '    Dim brRuang As New BussinessRules.Poliklinik
        '    Dim tblRuang As DataTable
        '    Dim intTotalPasienDirawat As Integer

        '    tblRuang = brRuang.SelectAll_Aktif

        '    panelListInformasiPasien.Controls.Clear()

        '    If tblRuang.Rows.Count > 0 Then
        '        Dim i As Integer = 0

        '        While (i < tblRuang.Rows.Count)
        '            Dim tblReg As DataTable
        '            Dim brReg As New BussinessRules.Registrasi

        '            Dim brShift As New BussinessRules.stdfield
        '            Dim tblShift As DataTable
        '            brShift.Kdfield = New SqlString("SHIFT")
        '            tblShift = brShift.SelectByKdField

        '            If tblShift.Rows.Count > 0 Then
        '                Dim j As Integer = 0

        '                While j < tblShift.Rows.Count
        '                    brReg.kdpoli = New SqlString(ProcessNull.GetString(tblRuang.Rows(i)("kdpoli")).Trim)
        '                    brReg.tglregistrasi = New SqlDateTime(Date.Now)
        '                    brReg.shift = New SqlString(ProcessNull.GetString(tblShift.Rows(j)("kduser")).Trim)

        '                    tblReg = brReg.Select_By_TglPoliShift

        '                    If tblReg.Rows.Count > 0 Then
        '                        Dim _list As Raven.Web.informasiRegistrasiPasien = CType(LoadControl("informasiRegistrasiPasien.ascx"), informasiRegistrasiPasien)

        '                        panelListInformasiPasien.Controls.Add(_list)

        '                        Dim list As DataList = CType(_list.FindControl("dlInformasiRegistrasiPasien"), DataList)
        '                        Dim headerCaption As Label = CType(_list.FindControl("lblPoli"), Label)
        '                        Dim shiftCaption As Label = CType(_list.FindControl("lblShift"), Label)
        '                        Dim totalShift As Label = CType(_list.FindControl("lblTotalShift"), Label)

        '                        list.DataSource = tblReg
        '                        list.DataBind()

        '                        headerCaption.Text = CType(tblRuang.Rows(i)("nmpoli"), String)
        '                        shiftCaption.Text = "SHIFT " + CType(tblShift.Rows(j)("nmkduser"), String)

        '                        totalShift.Text = "Total Pasien SHIFT " + CType(tblShift.Rows(j)("nmkduser"), String).Trim + " : " + tblReg.Rows.Count.ToString

        '                        intTotalPasienDirawat += tblReg.Rows.Count
        '                    End If
        '                    j += 1
        '                End While
        '            End If
        '            i += 1
        '        End While
        '    End If

        '    lblTotalRegistrasiPasien.Text = CStr(intTotalPasienDirawat)
        'End Sub
    End Class

End Namespace