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

Namespace Raven.Web.Secure.Master.ItemDataSetting

    Public Class ItemUnit
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "212"
        Protected WithEvents lblRecordListCaption As Label
        Protected WithEvents lblItemUnitIDCaption As Label
        Protected WithEvents lblItemUnitNameCaption As Label
        Protected WithEvents lblDescriptionCaption As Label
        Protected WithEvents txtItemUnitName As TextBox
        Protected WithEvents txtDescription As TextBox
        Protected WithEvents chkIsAllowDecimal As CheckBox
        Protected WithEvents chkIsActive As CheckBox
        Protected WithEvents RadComboBoxItemUnitID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridItemUnit As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxItemUnitID.IsCallBack Then
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

        Private Sub RadComboBoxItemUnitID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemUnitID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItemUnit(e.Text)
        End Sub

        Private Sub RadComboBoxItemUnitID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemUnitID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemUnitID").ToString()
        End Sub

        Private Sub RadComboBoxItemUnitID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemUnitID.SelectedIndexChanged
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
        Private Sub RadGridItemUnit_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridItemUnit.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblItemUnitID As Label = CType(e.Item.FindControl("_lblItemUnitID"), Label)

                    RadComboBoxItemUnitID.Text = _lblItemUnitID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxItemUnitID.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemUnit

            With br
                .ItemUnitID = RadComboBoxItemUnitID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxItemUnitID.Text = .ItemUnitID.Trim
                    End If
                    txtItemUnitName.Text = .ItemUnitName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsAllowDecimal.Checked = .IsAllowDecimal
                    chkIsActive.Checked = .IsActive
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtItemUnitName.Text = String.Empty
                    txtDescription.Text = String.Empty
                    chkIsAllowDecimal.Checked = True
                    chkIsActive.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtItemUnitName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxItemUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Category ID cannot empty.")
                Exit Sub
            End If

            If Len(txtItemUnitName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Category Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemUnit
            Dim fNew As Boolean = True

            With br
                .ItemUnitID = RadComboBoxItemUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .ItemUnitID = RadComboBoxItemUnitID.Text.Trim
                .ItemUnitName = txtItemUnitName.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500)
                .IsAllowDecimal = chkIsAllowDecimal.Checked
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridItemUnit()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxItemUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.ItemUnit

            With br
                .ItemUnitID = RadComboBoxItemUnitID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    If .Delete() = True Then
                        PrepareScreen()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxItemUnitID.ClientID)
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
            RadComboBoxItemUnitID.Text = String.Empty
            txtItemUnitName.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsAllowDecimal.Checked = True
            chkIsActive.Checked = True
            UpdateViewGridItemUnit()
        End Sub

        Private Sub LoadItemUnit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemUnit

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ItemUnitID LIKE '" + Filter.Trim + "%' OR ItemUnitName LIKE '" + Filter.Trim + "%'"

            RadComboBoxItemUnitID.DataSource = dv
            RadComboBoxItemUnitID.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItemUnit()
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemUnit

            dt = br.SelectAll

            RadGridItemUnit.DataSource = dt.DefaultView
            RadGridItemUnit.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace