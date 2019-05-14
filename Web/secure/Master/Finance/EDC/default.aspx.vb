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

    Public Class EDC
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "253"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEDCIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEDCNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtEDCName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxEDCID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridEDC As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxEDCID.IsCallBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()
                PrepareScreen(False)

                DataBind()
            End If
        End Sub

        Private Sub RadComboBoxEDCID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEDCID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEDC(e.Text)
        End Sub

        Private Sub RadComboBoxEDCID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEDCID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EDCID").ToString()
        End Sub

        Private Sub RadComboBoxEDCID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEDCID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen(False)
                Case CSSToolbarItem.tidSave
                    _Save()
                Case CSSToolbarItem.tidDelete
                    _Delete()
                Case CSSToolbarItem.tidPrevious
                    _Open(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _Open(RavenRecStatus.NextRecord)
            End Select
        End Sub

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridEDC_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridEDC.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblEDCID As Label = CType(e.Item.FindControl("_lblEDCID"), Label)

                    RadComboBoxEDCID.Text = _lblEDCID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxEDCID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.EDC

            With br
                .EDCID = RadComboBoxEDCID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxEDCID.Text = .EDCID.Trim
                    End If
                    txtEDCName.Text = .EDCName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive

                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    PrepareScreen(True)
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtEDCName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxEDCID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "EDC ID cannot empty.")
                Exit Sub
            End If

            If Len(txtEDCName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "EDC Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.EDC
            Dim fNew As Boolean = True

            With br
                .EDCID = RadComboBoxEDCID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .EDCID = RadComboBoxEDCID.Text.Trim
                .EDCName = txtEDCName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen(False)
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridEDC()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxEDCID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.EDC

            With br
                .EDCID = RadComboBoxEDCID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen(False)
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxEDCID.ClientID)
        End Sub

#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean

        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                .VisibleButton(CSSToolbarItem.tidApprove) = False
                .VisibleButton(CSSToolbarItem.tidVoid) = False
                .VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Sub PrepareScreen(ByVal fnew As Boolean)
            If fnew = False Then
                RadComboBoxEDCID.Text = String.Empty
            End If
            txtEDCName.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            UpdateViewGridEDC()
        End Sub

        Private Sub LoadEDC(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.EDC

            dt = br.SelectAllForEDCID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEDCID.DataSource = dt.DefaultView
            RadComboBoxEDCID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridEDC()
            Dim dt As DataTable
            Dim br As New BussinessRules.EDC

            dt = br.SelectAll

            RadGridEDC.DataSource = dt.DefaultView
            RadGridEDC.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace