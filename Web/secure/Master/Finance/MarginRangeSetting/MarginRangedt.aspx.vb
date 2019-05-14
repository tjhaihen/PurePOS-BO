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

Namespace Raven.Web.Secure.Master.Finance

    Public Class MarginRangedt
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "254"
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblMarginRangeID As System.Web.UI.WebControls.Label
        Protected WithEvents lblMarginRangeName As System.Web.UI.WebControls.Label
        Protected WithEvents txtMaxAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMarginPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadGridMarginRangedt As DataGrid

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
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
            End Select
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridMarginRangedt_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridMarginRangedt.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)

                    txtID.Text = _lblID.Text.Trim
                    _OpenMarginRange(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenMarginRange(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(txtMarginRangeID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.MarginRangedt

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    lblMarginRangeID.Text = .MarginRangeID.Trim
                    txtMaxAmount.Text = CStr(.MaxAmount)
                    txtMarginPct.Text = CStr(.MarginPct)
                    chkIsActive.Checked = .IsActive
                Else
                    lblMarginRangeID.Text = String.Empty
                    txtMaxAmount.Text = "0.00"
                    txtMarginPct.Text = "0"
                    chkIsActive.Checked = True
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            If Len(lblMarginRangeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Margin Range ID cannot empty.")
                Exit Sub
            End If

            If Not IsNumeric(txtMaxAmount.Text.Trim) Then
                commonFunction.MsgBox(Me, "Max Amount must be numeric.")
                txtMaxAmount.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtMaxAmount.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Max Amount must be equal or greater than 0.")
                txtMaxAmount.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtMarginPct.Text.Trim) Then
                commonFunction.MsgBox(Me, "Margin Percent must be numeric.")
                txtMarginPct.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtMarginPct.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Margin Percent must be equal or greater than 0.")
                txtMarginPct.Text = "0.00"
                Exit Sub
            End If

            Dim brhd As New BussinessRules.MarginRangeHd
            With brhd
                .MarginRangeID = lblMarginRangeID.Text.Trim
                If Not .SelectOne.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "Record Cannot Be Delete Due To Inconsistency.")
                    lblMarginRangeID.Text = String.Empty
                    PrepareScreen()
                    Exit Sub
                End If
            End With
            brhd.Dispose()
            brhd = Nothing

            Dim fNotNew As Boolean
            Dim br As New BussinessRules.MarginRangedt
            With br
                '// validate if MaxAmount already exist by MarginRangeID
                .MarginRangeID = lblMarginRangeID.Text.Trim
                .MaxAmount = CDec(Left(Replace(txtMaxAmount.Text.Trim, ",", ""), 16))
                If .SelectByMarginRangeIDAndMaxAmount.Rows.Count > 0 Then
                    commonFunction.MsgBox(Me, "Record failed to save. Max Amount already exists.")
                    commonFunction.Focus(Me, txtMaxAmount.ClientID)
                    Exit Sub
                End If

                .ID = txtID.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    fNotNew = True
                Else
                    .ID = BussinessRules.ID.GenerateIDNumber("MarginRangeDt", "ID", "")
                    fNotNew = False
                End If
                .MarginRangeID = lblMarginRangeID.Text.Trim
                .MaxAmount = CDec(Left(Replace(txtMaxAmount.Text.Trim, ",", ""), 16))
                .MarginPct = CDec(Left(Replace(txtMarginPct.Text.Trim, ",", ""), 16))
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsActive = chkIsActive.Checked

                If fNotNew Then
                    .Update()
                Else
                    .Insert()
                End If

            End With

            br.Dispose()
            br = Nothing

            PrepareScreen()
        End Sub

        Private Sub _Delete()
            'Page.Validate()
            'If Not Page.IsValid Then Exit Sub
            If Len(txtID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim brdt As New BussinessRules.MarginRangedt
            With brdt
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    If .Delete() = True Then
                        PrepareScreen()
                    End If

                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            brdt.Dispose()
            brdt = Nothing

            commonFunction.Focus(Me, txtMaxAmount.ClientID)
        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean
            lblMarginRangeID.Text = Common.ProcessNull.GetString((Request.QueryString("mrid")).Trim)
            lblMarginRangeName.Text = Common.ProcessNull.GetString((Request.QueryString("mrnm")).Trim)
            Return (Len(lblMarginRangeID.Text.Trim) > 0)
        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            txtID.Text = String.Empty
            txtMaxAmount.Text = "0.00"
            txtMarginPct.Text = "0.00"
            chkIsActive.Checked = True
            UpdateViewMarginRangedt()

            commonFunction.Focus(Me, txtMaxAmount.ClientID)
        End Sub


        Private Sub UpdateViewMarginRangedt()
            Dim dt As DataTable
            Dim br As New BussinessRules.MarginRangedt

            br.MarginRangeID = lblMarginRangeID.Text.Trim
            dt = br.SelectAllByMarginRangeID

            RadGridMarginRangedt.DataSource = dt.DefaultView
            RadGridMarginRangedt.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace