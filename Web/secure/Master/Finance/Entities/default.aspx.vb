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

    Public Class Entities
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "251"
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPrimaryAddressCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSecondaryAddress1Caption As System.Web.UI.WebControls.Label
        Protected WithEvents lblSecondaryAddress2Caption As System.Web.UI.WebControls.Label
        Protected WithEvents lblBankCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblMemberTypeCaption As System.Web.UI.WebControls.Label

        Protected WithEvents txtEntitiesID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtParentEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTIN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPrimaryAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSecondaryAddress1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSecondaryAddress2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtZipCode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPrimaryPhoneNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSecondaryPhoneNo1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSecondaryPhoneNo2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFaxNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtWebsite As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBank As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankAccountNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankBranch As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBankAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMaxPOrdAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMemberNo As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadMemberSinceDate As RadDatePicker

        Protected WithEvents ddlEntitiesTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlRelationshipID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlMemberTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCityID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCountryID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlDeliveryZoneID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox

        Protected WithEvents RadComboBoxEntitiesSeqNo As RadComboBox
        Protected WithEvents RadComboBoxParentEntitiesSeqNo As RadComboBox

        Protected WithEvents RadGridEntities As DataGrid

        '// Start Contact Person
        Protected WithEvents RadComboBoxCPContactSeqNo As RadComboBox

        Protected WithEvents txtCPFullName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCPAddress As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCPPrimaryPhoneNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCPSecondaryPhoneNo1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCPSecondaryPhoneNo2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCPEmail As System.Web.UI.WebControls.TextBox

        Protected WithEvents ddlCPJobTitleID As System.Web.UI.WebControls.DropDownList

        Protected WithEvents chkCPIsActive As System.Web.UI.WebControls.CheckBox

        Protected WithEvents RadGridEntitiesContact As DataGrid

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton
        '// End Contact Person

        Protected WithEvents txtSearchEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbtnApplyFilter As System.Web.UI.WebControls.LinkButton

        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents RadAjaxManager1 As RadAjaxManager


        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                ' And Not RadComboBoxEntitiesSeqNo.IsCallBack _
                'And Not RadComboBoxParentEntitiesSeqNo.IsCallBack _
                'And Not RadComboBoxCPContactSeqNo.IsCallBack Then

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

        Private Sub RadComboBoxEntitiesSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntitiesSeqNo(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesSeqNo.SelectedIndexChanged
            _Open(RavenRecStatus.CurrentRecord)
            EntitiesSeqNoTmp = RadComboBoxEntitiesSeqNo.Text.Trim
        End Sub

        Private Sub RadComboBoxParentEntitiesSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxParentEntitiesSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadParentEntitiesSeqNo(e.Text)
        End Sub

        Private Sub RadComboBoxParentEntitiesSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxParentEntitiesSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxParentEntitiesSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxParentEntitiesSeqNo.SelectedIndexChanged
            _OpenParentEntitesName(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub RadComboBoxCPContactSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxCPContactSeqNo.ItemsRequested
            If Len(EntitiesSeqNoTmp.Trim) > 0 Then
                Dim combo As RadComboBox = CType(o, RadComboBox)
                combo.Items.Clear()

                LoadContactSeqNo(e.Text, EntitiesSeqNoTmp.Trim)
            End If
        End Sub

        Private Sub RadComboBoxCPContactSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxCPContactSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ContactSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxCPContactSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCPContactSeqNo.SelectedIndexChanged
            _OpenContact(RavenRecStatus.CurrentRecord)
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

        Private Sub ddlEntitiesTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEntitiesTypeID.SelectedIndexChanged
            If ddlEntitiesTypeID.SelectedItem.Value = "04" Then
                '// Member
                ddlMemberTypeID.Enabled = True
                txtMemberNo.Enabled = True
                RadMemberSinceDate.Enabled = True
            Else
                ddlMemberTypeID.SelectedIndex = 0
                ddlMemberTypeID.Enabled = False
                txtMemberNo.Text = String.Empty
                txtMemberNo.Enabled = False
                RadMemberSinceDate.SelectedDate = Date.Now
                RadMemberSinceDate.Enabled = False
            End If
        End Sub

        Private Sub lbtnNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewDetail.Click
            PrepareScreenContact()
            commonFunction.Focus(Me, txtCPFullName.ClientID)
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _SaveContact()
        End Sub

        Private Sub lbtnApplyFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnApplyFilter.Click
            UpdateViewGridEntities(txtSearchEntitiesName.Text.Trim.Replace("*", "%"))
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridEntities_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridEntities.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblEntitiesSeqNo As Label = CType(e.Item.FindControl("_lblEntitiesSeqNo"), Label)

                    RadComboBoxEntitiesSeqNo.Text = _lblEntitiesSeqNo.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub

        Private Sub RadGridEntitiesContact_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridEntitiesContact.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblContactSeqNo As Label = CType(e.Item.FindControl("_lblContactSeqNo"), Label)

                    RadComboBoxCPContactSeqNo.Text = _lblContactSeqNo.Text.Trim
                    _OpenContact(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxEntitiesSeqNo.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.Entities

            With br
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxEntitiesSeqNo.Text = .EntitiesSeqNo.Trim
                    End If
                    txtEntitiesID.Text = .EntitiesID.Trim
                    txtEntitiesName.Text = .EntitiesName.Trim
                    commonFunction.SelectListItem(ddlEntitiesTypeID, .EntitiesTypeID.Trim)
                    RadComboBoxParentEntitiesSeqNo.Text = .ParentEntitiesSeqNo.Trim
                    _OpenParentEntitesName(RavenRecStatus.CurrentRecord)
                    commonFunction.SelectListItem(ddlRelationshipID, .RelationshipID.Trim)
                    txtTIN.Text = .TIN.Trim
                    txtPrimaryAddress.Text = .PrimaryAddress.Trim
                    txtSecondaryAddress1.Text = .SecondaryAddress1.Trim
                    txtSecondaryAddress2.Text = .SecondaryAddress2.Trim
                    commonFunction.SelectListItem(ddlCountryID, .CountryID.Trim)
                    commonFunction.SelectListItem(ddlDeliveryZoneID, .DeliveryZoneID.Trim)
                    commonFunction.SelectListItem(ddlCityID, .CityID.Trim)
                    txtZipCode.Text = .ZipCode.Trim
                    txtPrimaryPhoneNo.Text = .PrimaryPhoneNo.Trim
                    txtSecondaryPhoneNo1.Text = .SecondaryPhoneNo1.Trim
                    txtSecondaryPhoneNo2.Text = .SecondaryPhoneNo2.Trim
                    txtFaxNo.Text = .FaxNo.Trim
                    txtEmail.Text = .Email.Trim
                    txtWebsite.Text = .Website.Trim
                    txtBank.Text = .Bank.Trim
                    txtBankAccountNo.Text = .BankAccountNo.Trim
                    txtBankBranch.Text = .BankBranch.Trim
                    txtBankAddress.Text = .BankAddress.Trim
                    txtMaxPOrdAmount.Text = Format(.MaxPOrdAmount, commonFunction.FORMAT_CURRENCY).Trim
                    txtDescription.Text = .Description.Trim
                    commonFunction.SelectListItem(ddlMemberTypeID, .MemberTypeID.Trim)
                    txtMemberNo.Text = .MemberNo.Trim
                    RadMemberSinceDate.SelectedDate = .MemberSinceDate
                    chkIsActive.Checked = .IsActive
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    RadComboBoxEntitiesSeqNo.Text = String.Empty
                    txtEntitiesID.Text = String.Empty
                    txtEntitiesName.Text = String.Empty
                    ddlEntitiesTypeID.SelectedIndex = 0
                    RadComboBoxParentEntitiesSeqNo.Text = String.Empty
                    txtParentEntitiesName.Text = String.Empty
                    ddlRelationshipID.SelectedIndex = 0
                    txtTIN.Text = String.Empty
                    txtPrimaryAddress.Text = String.Empty
                    txtSecondaryAddress1.Text = String.Empty
                    txtSecondaryAddress2.Text = String.Empty
                    ddlCityID.SelectedIndex = 0
                    ddlCountryID.SelectedIndex = 0
                    ddlDeliveryZoneID.SelectedIndex = 0
                    txtZipCode.Text = String.Empty
                    txtPrimaryPhoneNo.Text = String.Empty
                    txtSecondaryPhoneNo1.Text = String.Empty
                    txtSecondaryPhoneNo2.Text = String.Empty
                    txtFaxNo.Text = String.Empty
                    txtEmail.Text = String.Empty
                    txtWebsite.Text = String.Empty
                    txtBank.Text = String.Empty
                    txtBankAccountNo.Text = String.Empty
                    txtBankBranch.Text = String.Empty
                    txtBankAddress.Text = String.Empty
                    txtMaxPOrdAmount.Text = "0.00"
                    txtDescription.Text = String.Empty
                    ddlMemberTypeID.SelectedIndex = 0
                    txtMemberNo.Text = String.Empty
                    RadMemberSinceDate.SelectedDate = Date.Now
                    chkIsActive.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            ddlEntitiesTypeID_SelectedIndexChanged(Nothing, Nothing)
            GetRecordProperties()
            commonFunction.Focus(Me, txtEntitiesID.ClientID)
            PrepareScreenContact()
        End Sub

        Private Sub _Save()
            If Len(txtEntitiesID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Entities ID cannot empty.")
                commonFunction.Focus(Me, txtEntitiesID.ClientID)
                Exit Sub
            End If

            If Len(txtEntitiesName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Entities Name cannot empty.")
                commonFunction.Focus(Me, txtEntitiesName.ClientID)
                Exit Sub
            End If

            If ddlEntitiesTypeID.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Entities Type cannot empty.")
                commonFunction.Focus(Me, ddlEntitiesTypeID.ClientID)
                Exit Sub
            End If

            If Len(RadComboBoxEntitiesSeqNo.Text.Trim) > 0 And Len(RadComboBoxParentEntitiesSeqNo.Text.Trim) > 0 Then
                If RadComboBoxEntitiesSeqNo.Text = RadComboBoxParentEntitiesSeqNo.Text Then
                    commonFunction.MsgBox(Me, "Parent Entities Seq. No. must be different with Entities Seq. No.")
                    Exit Sub
                End If
            End If

            If IsNumeric(txtMaxPOrdAmount.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Max. P.O. Amount must be numeric.")
                commonFunction.Focus(Me, txtMaxPOrdAmount.ClientID)
                Exit Sub
            End If

            If CDec(txtMaxPOrdAmount.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Max. P.O. Amount must be greater than 0.")
                commonFunction.Focus(Me, txtMaxPOrdAmount.ClientID)
                Exit Sub
            End If

            If ddlMemberTypeID.SelectedIndex > 0 Then
                If Len(txtMemberNo.Text.Trim) = 0 Then
                    commonFunction.MsgBox(Me, "Member No. cannot empty.")
                    commonFunction.Focus(Me, txtMemberNo.ClientID)
                    Exit Sub
                End If
            End If

            Dim br As New BussinessRules.Entities
            Dim fNew As Boolean = True
            With br

                '// validate ParentEntitiesSeqNo
                If Len(RadComboBoxParentEntitiesSeqNo.Text.Trim) > 0 Then
                    .EntitiesSeqNo = RadComboBoxParentEntitiesSeqNo.Text.Trim
                    If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count = 0 Then
                        commonFunction.MsgBox(Me, "Parent Entities Seq. No. does not exists.")
                        GoTo GoNext
                    End If
                End If

                br.EntitiesID = txtEntitiesID.Text.Trim
                Dim dv As New DataView(br.SelectOneByEntitiesID)
                dv.RowFilter = "EntitiesSeqNo <> '" + RadComboBoxEntitiesSeqNo.Text.Trim + "'"
                If dv.Count > 0 Then
                    commonFunction.MsgBox(Me, "Entities ID already exist.")
                    _Open(RavenRecStatus.CurrentRecord)
                    commonFunction.Focus(Me, txtEntitiesID.ClientID)
                    Exit Sub
                End If
                dv.Dispose()
                dv = Nothing

                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    .EntitiesSeqNo = BussinessRules.ID.GenerateIDNumber("Entities", "EntitiesSeqNo")
                End If

                '// set the value
                .EntitiesID = txtEntitiesID.Text.Trim
                .EntitiesName = txtEntitiesName.Text.Trim
                .EntitiesTypeID = ddlEntitiesTypeID.SelectedItem.Value.Trim
                .ParentEntitiesSeqNo = RadComboBoxParentEntitiesSeqNo.Text.Trim
                .RelationshipID = ddlRelationshipID.SelectedItem.Value.Trim
                .TIN = txtTIN.Text.Trim
                .PrimaryAddress = txtPrimaryAddress.Text.Trim
                .SecondaryAddress1 = txtSecondaryAddress1.Text.Trim
                .SecondaryAddress2 = txtSecondaryAddress2.Text.Trim
                .CityID = ddlCityID.SelectedItem.Value.Trim
                .CountryID = ddlCountryID.SelectedItem.Value.Trim
                .DeliveryZoneID = ddlDeliveryZoneID.SelectedItem.Value.Trim
                .ZipCode = txtZipCode.Text.Trim
                .PrimaryPhoneNo = txtPrimaryPhoneNo.Text.Trim
                .SecondaryPhoneNo1 = txtSecondaryPhoneNo1.Text.Trim
                .SecondaryPhoneNo2 = txtSecondaryPhoneNo2.Text.Trim
                .FaxNo = txtFaxNo.Text.Trim
                .Email = txtEmail.Text.Trim
                .Website = txtWebsite.Text.Trim
                .Bank = txtBank.Text.Trim
                .BankAccountNo = txtBankAccountNo.Text.Trim
                .BankBranch = txtBankBranch.Text.Trim
                .BankAddress = txtBankAddress.Text.Trim
                .MaxPOrdAmount = CDec(txtMaxPOrdAmount.Text.Trim)
                .MemberTypeID = ddlMemberTypeID.SelectedItem.Value.Trim
                .MemberNo = txtMemberNo.Text.Trim
                .MemberSinceDate = RadMemberSinceDate.SelectedDate.Value
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        RadComboBoxEntitiesSeqNo.Text = .EntitiesSeqNo.Trim
                        _Open(RavenRecStatus.CurrentRecord)
                    End If
                Else
                    If .Update() Then
                        _Open(RavenRecStatus.CurrentRecord)
                        'UpdateViewGridEntities()
                    End If
                End If
            End With

GoNext:

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxEntitiesSeqNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Entities

            With br
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        PrepareScreen()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtEntitiesID.ClientID)
        End Sub

#Region " Contact Person "
        Private Sub _OpenContact(ByVal recstatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxEntitiesSeqNo.Text.Trim) = 0 Or Len(RadComboBoxCPContactSeqNo.Text.Trim) = 0 Then
                PrepareScreenContact()
                Exit Sub
            End If

            Dim br As New BussinessRules.EntitiesContact

            With br
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                .ContactSeqNo = RadComboBoxCPContactSeqNo.Text.Trim
                If .SelectOne(recstatus).Rows.Count > 0 Then
                    If Not recstatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxEntitiesSeqNo.Text = .EntitiesSeqNo.Trim
                        RadComboBoxCPContactSeqNo.Text = .ContactSeqNo.Trim
                    End If
                    txtCPFullName.Text = .FullName.Trim
                    commonFunction.SelectListItem(ddlCPJobTitleID, .JobTitleID.Trim)
                    txtCPAddress.Text = .Address.Trim
                    txtCPPrimaryPhoneNo.Text = .PrimaryPhoneNo.Trim
                    txtCPSecondaryPhoneNo1.Text = .SecondaryPhoneNo1.Trim
                    txtCPSecondaryPhoneNo2.Text = .SecondaryPhoneNo2.Trim
                    txtCPEmail.Text = .Email.Trim
                    chkCPIsActive.Checked = .IsActive
                Else
                    If Not recstatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    RadComboBoxCPContactSeqNo.Text = String.Empty
                    txtCPFullName.Text = String.Empty
                    ddlCPJobTitleID.SelectedIndex = 0
                    txtCPAddress.Text = String.Empty
                    txtCPPrimaryPhoneNo.Text = String.Empty
                    txtCPSecondaryPhoneNo1.Text = String.Empty
                    txtCPSecondaryPhoneNo2.Text = String.Empty
                    txtCPEmail.Text = String.Empty
                    chkCPIsActive.Checked = True
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtCPFullName.ClientID)
        End Sub

        Private Sub _SaveContact()
            If Len(txtCPFullName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Contact's Full Name cannot empty.")
                Exit Sub
            End If

            If Len(txtCPPrimaryPhoneNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Contact's Primary Phone No. cannot empty.")
                Exit Sub
            End If

            If ddlCPJobTitleID.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Contact's Job Title cannot empty.")
                Exit Sub
            End If

            Dim br As New BussinessRules.EntitiesContact
            Dim fNew As Boolean = True
            With br
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                .ContactSeqNo = RadComboBoxCPContactSeqNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    .ContactSeqNo = BussinessRules.ID.GenerateIDNumber("EntitiesContact", "ContactSeqNo")
                End If

                '// set the value
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                .FullName = txtCPFullName.Text.Trim
                .JobTitleID = ddlCPJobTitleID.SelectedItem.Value.Trim
                .Address = txtCPAddress.Text.Trim
                .PrimaryPhoneNo = txtCPPrimaryPhoneNo.Text.Trim
                .SecondaryPhoneNo1 = txtCPSecondaryPhoneNo1.Text.Trim
                .SecondaryPhoneNo2 = txtCPSecondaryPhoneNo2.Text.Trim
                .Email = txtCPEmail.Text.Trim
                .IsActive = chkCPIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    If .Insert() Then
                        PrepareScreenContact()
                    End If
                Else
                    If .Update() Then
                        _OpenContact(RavenRecStatus.CurrentRecord)
                        UpdateViewGridEntitiesContact()
                    End If
                End If
            End With

GoNext:

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _DeleteContact()
            If Len(RadComboBoxEntitiesSeqNo.Text.Trim) = 0 Or Len(RadComboBoxCPContactSeqNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.EntitiesContact

            With br
                .EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
                .ContactSeqNo = RadComboBoxCPContactSeqNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        PrepareScreenContact()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtCPFullName.ClientID)
        End Sub
#End Region

#End Region

#Region " Main Function (Custom) "
        Private Sub _OpenParentEntitesName(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxParentEntitiesSeqNo.Text.Trim) = 0 Then
                txtParentEntitiesName.Text = String.Empty
                ddlRelationshipID.SelectedIndex = 0
                ddlRelationshipID.Enabled = False
                Exit Sub
            End If

            Dim br As New BussinessRules.Entities

            With br
                .EntitiesSeqNo = RadComboBoxParentEntitiesSeqNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxParentEntitiesSeqNo.Text = .EntitiesSeqNo.Trim
                    End If
                    txtParentEntitiesName.Text = .EntitiesName.Trim
                    ddlRelationshipID.Enabled = True
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    RadComboBoxParentEntitiesSeqNo.Text = String.Empty
                    txtParentEntitiesName.Text = String.Empty
                    ddlRelationshipID.SelectedIndex = 0
                    ddlRelationshipID.Enabled = False
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing
        End Sub
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
            commonFunction.LoadDDLCommonSetting("EntitiesType", ddlEntitiesTypeID)

            '//Member Type
            Dim oMemberType As New BussinessRules.MemberBenefit
            Dim dtMemberType As New DataTable

            With oMemberType
                dtMemberType = .SelectAllActive
                commonFunction.LoadDDL(ddlMemberTypeID, "MBTypeName", "MBTypeID", dtMemberType, True)
            End With

            oMemberType.Dispose()
            oMemberType = Nothing

            commonFunction.LoadDDLCommonSetting("City", ddlCityID)
            commonFunction.LoadDDLCommonSetting("Country", ddlCountryID)

            '//Delivery Zone
            Dim oDZ As New BussinessRules.DeliveryZoneHd
            Dim dtDZ As New DataTable

            With oDZ
                dtDZ = .SelectAllActive
                commonFunction.LoadDDL(ddlDeliveryZoneID, "DeliveryZoneName", "DeliveryZoneID", dtDZ, True)
            End With

            oDZ.Dispose()
            oDZ = Nothing

            commonFunction.LoadDDLCommonSetting("Relationship", ddlRelationshipID)

            RadComboBoxEntitiesSeqNo.Text = String.Empty
            RadComboBoxParentEntitiesSeqNo.Text = String.Empty
            ddlRelationshipID.SelectedIndex = 0
            ddlRelationshipID.Enabled = False
            txtEntitiesID.Text = String.Empty
            txtEntitiesName.Text = String.Empty
            txtTIN.Text = String.Empty
            txtParentEntitiesName.Text = String.Empty
            ddlEntitiesTypeID.SelectedIndex = 0
            chkIsActive.Checked = True
            txtPrimaryAddress.Text = String.Empty
            txtSecondaryAddress1.Text = String.Empty
            txtSecondaryAddress2.Text = String.Empty
            txtZipCode.Text = String.Empty
            ddlCityID.SelectedIndex = 0
            ddlCountryID.SelectedIndex = 0
            ddlDeliveryZoneID.SelectedIndex = 0
            txtPrimaryPhoneNo.Text = String.Empty
            txtSecondaryPhoneNo1.Text = String.Empty
            txtSecondaryPhoneNo2.Text = String.Empty
            txtFaxNo.Text = String.Empty
            txtEmail.Text = String.Empty
            txtWebsite.Text = String.Empty
            txtBank.Text = String.Empty
            txtBankAccountNo.Text = String.Empty
            txtBankBranch.Text = String.Empty
            txtBankAddress.Text = String.Empty
            ddlMemberTypeID.SelectedIndex = 0
            txtMaxPOrdAmount.Text = "0.00"
            txtDescription.Text = String.Empty

            '// Membership Information
            txtMemberNo.Text = String.Empty
            RadMemberSinceDate.SelectedDate = Date.Now

            EntitiesSeqNoTmp = String.Empty

            txtSearchEntitiesName.Text = "*"
            UpdateViewGridEntities(String.Empty)

            '//Contact Person
            PrepareScreenContact()

            ddlEntitiesTypeID_SelectedIndexChanged(Nothing, Nothing)
            GetRecordProperties()
            commonFunction.Focus(Me, txtEntitiesID.ClientID)
        End Sub

        Private Sub PrepareScreenContact()
            '//Contact Person
            commonFunction.LoadDDLCommonSetting("JobTitle", ddlCPJobTitleID)

            If RadComboBoxEntitiesSeqNo.Text.Trim = String.Empty Then
                lbtnNewDetail.Enabled = False
                lbtnSaveDetail.Enabled = False
            Else
                lbtnNewDetail.Enabled = True
                lbtnSaveDetail.Enabled = True
            End If

            RadComboBoxCPContactSeqNo.Text = String.Empty
            ddlCPJobTitleID.SelectedIndex = 0
            txtCPFullName.Text = String.Empty
            txtCPAddress.Text = String.Empty
            txtCPPrimaryPhoneNo.Text = String.Empty
            txtCPSecondaryPhoneNo1.Text = String.Empty
            txtCPSecondaryPhoneNo2.Text = String.Empty
            txtCPEmail.Text = String.Empty
            chkCPIsActive.Checked = True

            UpdateViewGridEntitiesContact()
        End Sub

        Private Sub LoadEntitiesSeqNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "EntitiesSeqNo LIKE '%" + Filter.Trim + "%' OR " + _
                            "EntitiesID LIKE '%" + Filter.Trim + "%' OR " + _
                            "EntitiesName LIKE '%" + Filter.Trim + "%'"

            RadComboBoxEntitiesSeqNo.DataSource = dv
            RadComboBoxEntitiesSeqNo.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadParentEntitiesSeqNo(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "EntitiesSeqNo LIKE '%" + Filter.Trim + "%' OR " + _
                            "EntitiesID LIKE '%" + Filter.Trim + "%' OR " + _
                            "EntitiesName LIKE '%" + Filter.Trim + "%'"

            RadComboBoxParentEntitiesSeqNo.DataSource = dv
            RadComboBoxParentEntitiesSeqNo.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadContactSeqNo(ByVal Filter As String, ByVal EntitiesSeqNo As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.EntitiesContact

            br.EntitiesSeqNo = EntitiesSeqNo.Trim
            dt = br.SelectAllByEntitiesSeqNo

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ContactSeqNo LIKE '%" + Filter.Trim + "%' OR " + _
                            "FullName LIKE '%" + Filter.Trim + "%'"

            RadComboBoxCPContactSeqNo.DataSource = dv
            RadComboBoxCPContactSeqNo.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridEntities(ByVal strEntitiesName As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            dt = br.SelectByFilterEntitiesName(strEntitiesName.Trim)

            RadGridEntities.DataSource = dt.DefaultView
            RadGridEntities.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridEntitiesContact()
            Dim dt As DataTable
            Dim br As New BussinessRules.EntitiesContact

            br.EntitiesSeqNo = RadComboBoxEntitiesSeqNo.Text.Trim
            dt = br.SelectAllByEntitiesSeqNo

            RadGridEntitiesContact.DataSource = dt.DefaultView
            RadGridEntitiesContact.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("EntitiesSeqNo", RadComboBoxEntitiesSeqNo.Text.Trim, "Entities").Rows.Count > 0 Then
                    lblUserInsert.Text = .UserInsert.Trim
                    lblInsertDate.Text = .InsertDate.ToString.Trim
                    lblUserUpdate.Text = .UserUpdate.Trim
                    lblUpdateDate.Text = .UpdateDate.ToString.Trim
                Else
                    lblUserInsert.Text = "-"
                    lblInsertDate.Text = "-"
                    lblUserUpdate.Text = "-"
                    lblUpdateDate.Text = "-"
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace