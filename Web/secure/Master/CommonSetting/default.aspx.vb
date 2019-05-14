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

Namespace Raven.Web.Secure.Master

    Public Class CommonSetting
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "299"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCommonSettingIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblGroupIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDetailIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDetailDescCaption As System.Web.UI.WebControls.Label


        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents ddlGroupID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtGroupID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDetailID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDetailDesc As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxCommonSettingID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridCommonSetting As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxCommonSettingID.IsCallBack Then
                Dim fQueryStringExist As Boolean
                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                'PrepareScreen(False)
                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()
                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub RadComboBoxCommonSettingID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxCommonSettingID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadCommonSetting(e.Text)
        End Sub

        Private Sub RadComboBoxCommonSettingID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxCommonSettingID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ID").ToString()
        End Sub

        Private Sub RadComboBoxCommonSettingID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCommonSettingID.SelectedIndexChanged
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
            End Select
        End Sub

        Private Sub ddlGroupID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroupID.SelectedIndexChanged
            UpdateViewGridCommonSetting()
        End Sub

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridCommonSetting_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridCommonSetting.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblCommonSettingID As Label = CType(e.Item.FindControl("_lblCommonSettingID"), Label)

                    RadComboBoxCommonSettingID.Text = _lblCommonSettingID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxCommonSettingID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.CommonSetting

            With br
                .ID = RadComboBoxCommonSettingID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxCommonSettingID.Text = .ID.Trim
                    End If
                    txtGroupID.Text = .GroupID.Trim
                    txtDetailID.Text = .DetailID.Trim
                    txtDetailDesc.Text = .DetailDesc.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    'ddlGroupID.Items.FindByValue(.GroupID.Trim).Selected = True
                    'UpdateViewGridCommonSetting()
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    'PrepareScreen(True)
                    PrepareScreen()
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtGroupID.ClientID)
        End Sub

        Private Sub _Save()
            If Len(txtGroupID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Group ID cannot empty.")
                Exit Sub
            End If

            If Len(txtDetailID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Detail ID Name cannot empty.")
                Exit Sub
            End If

            If Len(txtDetailDesc.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Detail Description Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.CommonSetting
            Dim fNew As Boolean = True

            With br
                .ID = RadComboBoxCommonSettingID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    If .IsSystem Then
                        commonFunction.MsgBox(Me, "Record is system cannot save")
                        Exit Sub
                    End If

                    fNew = False
                Else
                    .GroupID = txtGroupID.Text.Trim
                    Dim dv As New DataView(br.SelectAllByGroupID)
                    dv.RowFilter = "DetailID = '" + txtDetailID.Text.Trim + "'"
                    If dv.Count > 0 Then
                        commonFunction.MsgBox(Me, "Detail ID already exist.")
                        commonFunction.Focus(Me, txtDetailID.ClientID)
                        Exit Sub
                    End If
                    dv.Dispose()
                    dv = Nothing

                    .ID = BussinessRules.ID.GenerateIDNumber("CommonSetting", "ID")
                End If

                '// set the value
                .GroupID = txtGroupID.Text.Trim
                .DetailID = txtDetailID.Text.Trim
                .DetailDesc = txtDetailDesc.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        'PrepareScreen(False)
                        PrepareScreen()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridCommonSetting()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxCommonSettingID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.CommonSetting
            With br
                .ID = RadComboBoxCommonSettingID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    If .IsSystem Then
                        commonFunction.MsgBox(Me, "Record is system cannot Delete")
                        Exit Sub
                    End If

                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        'PrepareScreen(False)
                        PrepareScreen()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxCommonSettingID.ClientID)
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
                .VisibleButton(CSSToolbarItem.tidNext) = False
                .VisibleButton(CSSToolbarItem.tidPrevious) = False
            End With
        End Sub

        Private Sub PrepareScreen()
            'Private Sub PrepareScreen(ByVal fnew As Boolean)
            'If fnew = False Then
            '    RadComboBoxCommonSettingID.Text = String.Empty
            'End If
            RadComboBoxCommonSettingID.Text = String.Empty
            LoadGroupIDList()
            txtGroupID.Text = String.Empty
            txtDetailID.Text = String.Empty
            txtDetailDesc.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            UpdateViewGridCommonSetting()
        End Sub

        Private Sub LoadCommonSetting(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.CommonSetting

            dt = br.SelectAllForIDGroupID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxCommonSettingID.DataSource = dt.DefaultView
            RadComboBoxCommonSettingID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadGroupIDList()
            Dim dt As DataTable
            Dim cs As New BussinessRules.CommonSetting

            dt = cs.SelectAllGroupID
            ddlGroupID.Items.Clear()
            'ddlGroupID.Items.Add(New ListItem("All", ""))

            For Each row As DataRow In dt.Rows
                ddlGroupID.Items.Add(New ListItem(CType(row("GroupID"), String), CType(row("GroupID"), String)))
            Next

            cs.Dispose()
            cs = Nothing
        End Sub

        Private Sub UpdateViewGridCommonSetting()
            Dim dt As DataTable
            Dim br As New BussinessRules.CommonSetting

            If Len(ddlGroupID.SelectedValue.Trim) = 0 Then
                dt = br.SelectAll
            Else
                br.GroupID = ddlGroupID.SelectedValue.Trim
                dt = br.SelectAllByGroupID
            End If

            RadGridCommonSetting.DataSource = dt.DefaultView
            RadGridCommonSetting.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub


    End Class
End Namespace