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

    Public Class MarginRangeSetting
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "254"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMarginRangeIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMarginRangeNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtMarginRangeName As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxMarginRangeID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents RadGridMarginRange As DataGrid
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxMarginRangeID.IsCallBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If
                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub RadComboBoxMarginRangeID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxMarginRangeID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadMarginRange(e.Text)
        End Sub

        Private Sub RadComboBoxMarginRangeID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxMarginRangeID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("MarginRangeID").ToString()
        End Sub

        Private Sub RadComboBoxMarginRangeID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMarginRangeID.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
        End Sub

        
        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreen()
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
        Private Sub RadGridMarginRange_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridMarginRange.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblMarginRangeID As Label = CType(e.Item.FindControl("_lblMarginRangeID"), Label)

                    RadComboBoxMarginRangeID.Text = _lblMarginRangeID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxMarginRangeID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.MarginRangeHd

            With br
                .MarginRangeID = RadComboBoxMarginRangeID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxMarginRangeID.Text = .MarginRangeID.Trim
                    End If
                    txtMarginRangeName.Text = .MarginRangeName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtMarginRangeName.Text = String.Empty
                    txtDescription.Text = String.Empty
                    chkIsActive.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtMarginRangeName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxMarginRangeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Margin Range ID Cannot Empty.")
                Exit Sub
            End If

            If Len(txtMarginRangeName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Margin Range Name Cannot Empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MarginRangeHd
            Dim fNew As Boolean = True

            With br
                .MarginRangeID = RadComboBoxMarginRangeID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .MarginRangeID = RadComboBoxMarginRangeID.Text.Trim
                .MarginRangeName = txtMarginRangeName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridMarginRange()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxMarginRangeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MarginRangeHd
            Dim brdt As New BussinessRules.MarginRangedt

            With br
                .MarginRangeID = RadComboBoxMarginRangeID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    brdt.MarginRangeID = RadComboBoxMarginRangeID.Text.Trim
                    If brdt.SelectAllByMarginRangeID.Rows.Count > 0 Then
                        commonFunction.MsgBox(Me, "Record Cannot Be Delete Due To Inconsistency")
                        Exit Sub
                    Else
                        If .Delete() = True Then
                            PrepareScreen()
                        End If
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            brdt.Dispose()
            brdt = Nothing

            commonFunction.Focus(Me, RadComboBoxMarginRangeID.ClientID)
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

        Private Sub PrepareScreen()
            RadComboBoxMarginRangeID.Text = String.Empty
            txtMarginRangeName.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            UpdateViewGridMarginRange()
        End Sub

        Private Sub LoadMarginRange(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.MarginRangeHd

            dt = br.SelectAllForMarginRangeID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxMarginRangeID.DataSource = dt.DefaultView
            RadComboBoxMarginRangeID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridMarginRange()
            Dim dt As DataTable
            Dim br As New BussinessRules.MarginRangeHd

            dt = br.SelectAll

            RadGridMarginRange.DataSource = dt.DefaultView
            RadGridMarginRange.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace