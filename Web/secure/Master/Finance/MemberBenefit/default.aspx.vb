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

    Public Class MemberBenefit
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "253"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMBTypeIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMBTypeNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtMBTypeName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxMBTypeID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridMBType As DataGrid
        Protected WithEvents RadGridFormula As DataGrid
        Protected WithEvents txtMaxValue As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPoint As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbtnNewFormula As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveFormula As System.Web.UI.WebControls.LinkButton
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox


#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxMBTypeID.IsCallBack Then
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

        Private Sub RadComboBoxMBTypeID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxMBTypeID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadMemberBenefit(e.Text)
        End Sub

        Private Sub RadComboBoxMBTypeID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxMBTypeID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("MBTypeID").ToString()
        End Sub

        Private Sub RadComboBoxMBTypeID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMBTypeID.SelectedIndexChanged
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

        Private Sub lbtnNewFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewFormula.Click
            PrepareScreenFormula()
        End Sub

        Private Sub lbtnSaveFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveFormula.Click
            _SaveFormula()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridMBType_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridMBType.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblMBTypeID As Label = CType(e.Item.FindControl("_lblMBTypeID"), Label)

                    RadComboBoxMBTypeID.Text = _lblMBTypeID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub RadGridFormula_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridFormula.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    _OpenFormula(_lblID.Text.Trim)
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    _DeleteFormula(_lblID.Text.Trim)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            'If Len(RadComboBoxMBTypeID.Text.Trim) = 0 Then
            '    PrepareScreen()
            '    Exit Sub
            'End If

            Dim br As New BussinessRules.MemberBenefit

            With br
                .MBTypeID = RadComboBoxMBTypeID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxMBTypeID.Text = .MBTypeID.Trim
                    End If
                    txtMBTypeName.Text = .MBTypeName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    UpdateViewGridFormula()
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

            commonFunction.Focus(Me, txtMBTypeName.ClientID)
        End Sub

        Private Sub _OpenFormula(ByVal ID As String)
            Dim br As New BussinessRules.MemberBenefitFormula

            With br
                .ID = ID.Trim
                If .SelectOne.Rows.Count > 0 Then
                    txtID.Text = .ID.Trim
                    txtMaxValue.Text = Format(.MaxValue, commonFunction.FORMAT_CURRENCY)
                    txtPoint.Text = Format(.Point, commonFunction.FORMAT_CURRENCY)
                Else
                    PrepareScreenFormula()
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtID.ClientID)
        End Sub

        Private Sub _SaveFormula()
            If Len(RadComboBoxMBTypeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Member ID cannot empty.")
                Exit Sub
            End If

            If Len(txtMBTypeName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Member Name cannot empty.")
                Exit Sub
            End If

            If Not IsNumeric(txtMaxValue.Text.Trim) Then
                commonFunction.MsgBox(Me, "Max Value must be numeric.")
                txtMaxValue.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtMaxValue.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Max Value must be greater than 0.")
                txtMaxValue.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtPoint.Text.Trim) Then
                commonFunction.MsgBox(Me, "Point must be numeric.")
                txtPoint.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If CDec(txtPoint.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Point must be greater than 0.")
                txtPoint.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            Dim ocheck As New BussinessRules.MemberBenefit
            ocheck.MBTypeID = RadComboBoxMBTypeID.Text.Trim
            If Not ocheck.SelectOne.Rows.Count > 0 Then
                commonFunction.MsgBox(Me, "Member ID cannot found.")
                ocheck.Dispose()
                ocheck = Nothing
                Exit Sub
            End If
            ocheck.Dispose()
            ocheck = Nothing

            Dim ocheckf As New BussinessRules.MemberBenefitFormula
            ocheckf.MBTypeID = RadComboBoxMBTypeID.Text.Trim
            Dim dv As New DataView(ocheckf.SelectAllByMBTypeID)
            dv.RowFilter = " MaxValue = '" + txtMaxValue.Text.Trim + "' and Point = '" + txtPoint.Text.Trim + "'"
            If dv.Count > 0 Then
                commonFunction.MsgBox(Me, "MaxValue and Point is already exists.")
                dv.Dispose()
                dv = Nothing
                ocheckf.Dispose()
                ocheckf = Nothing
                Exit Sub
            End If
            dv.Dispose()
            dv = Nothing
            ocheckf.Dispose()
            ocheckf = Nothing

            Dim br As New BussinessRules.MemberBenefitFormula
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    .ID = BussinessRules.ID.GenerateIDNumber("MemberBenefitFormula", "ID")
                End If

                '// set the value
                .MBTypeID = RadComboBoxMBTypeID.Text.Trim
                .MaxValue = CDec(txtMaxValue.Text.Trim)
                .Point = CDec(txtPoint.Text.Trim)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreenFormula()
                    End If
                Else
                    If .Update() Then
                        UpdateViewGridFormula()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxMBTypeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Member ID cannot empty.")
                Exit Sub
            End If

            If Len(txtMBTypeName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Member Name cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MemberBenefit
            Dim fNew As Boolean = True

            With br
                .MBTypeID = RadComboBoxMBTypeID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .MBTypeID = RadComboBoxMBTypeID.Text.Trim
                .MBTypeName = txtMBTypeName.Text.Trim
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
                        UpdateViewGridMBType()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _DeleteFormula(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MemberBenefitFormula

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridFormula()
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxMBTypeID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.MemberBenefit

            With br
                .MBTypeID = RadComboBoxMBTypeID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    Dim brdt As New BussinessRules.MemberBenefitFormula
                    brdt.MBTypeID = RadComboBoxMBTypeID.Text.Trim
                    brdt.DeleteAllByMBTypeID()
                    brdt.Dispose()
                    brdt = Nothing

                    If .Delete() = True Then
                        PrepareScreen(False)
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxMBTypeID.ClientID)

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
                RadComboBoxMBTypeID.Text = String.Empty
            End If

            txtMBTypeName.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True

            UpdateViewGridMBType()
            PrepareScreenFormula()
        End Sub

        Private Sub PrepareScreenFormula()
            txtID.Text = String.Empty
            txtPoint.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtMaxValue.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            UpdateViewGridFormula()
        End Sub


        Private Sub LoadMemberBenefit(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.MemberBenefit

            dt = br.SelectAllForMBtypeID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxMBTypeID.DataSource = dt.DefaultView
            RadComboBoxMBTypeID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridMBType()
            Dim dt As DataTable
            Dim br As New BussinessRules.MemberBenefit

            dt = br.SelectAll

            RadGridMBType.DataSource = dt.DefaultView
            RadGridMBType.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridFormula()
            Dim dt As DataTable
            Dim br As New BussinessRules.MemberBenefitFormula

            br.MBTypeID = RadComboBoxMBTypeID.Text.Trim
            dt = br.SelectAllByMBTypeID

            RadGridFormula.DataSource = dt.DefaultView
            RadGridFormula.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

        
    End Class
End Namespace