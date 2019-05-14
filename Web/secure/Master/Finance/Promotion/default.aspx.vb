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

    Public Class Promotion
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "255"

        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPromotionNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtPromotionName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBuyQty As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtGetQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtSpecialPrice As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc1Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc2Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtBuyAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGetVoucherAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtnPurchase As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsMultipleApplied As System.Web.UI.WebControls.CheckBox
        Protected WithEvents chkIsNoEndDate As System.Web.UI.WebControls.CheckBox
        Protected WithEvents ddlMemberType As System.Web.UI.WebControls.DropDownList

        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents RadGridPromotion As DataGrid
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPromotionTypeIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents ddlPromotionTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadDatePickerStart As RadDatePicker
        Protected WithEvents RadDatePickerEnd As RadDatePicker

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxID.IsCallBack Then

                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                commonFunction.LoadDDLCommonSetting("PromotionType", ddlPromotionTypeID)
                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()
                PrepareScreen()

                DataBind()
            End If
        End Sub

        Private Sub RadComboBoxPromotionID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadPromotion(e.Text)
        End Sub

        Private Sub RadComboBoxPromotionID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ID").ToString()
        End Sub

        Private Sub RadComboBoxPromotionID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxID.SelectedIndexChanged
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

        Private Sub ddlPromotionTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPromotionTypeID.SelectedIndexChanged
            Select Case ddlPromotionTypeID.SelectedItem.Value.Trim
                Case "01" '// Buy n Get n
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = True
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = True

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = False

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = False
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = False

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = False

                    commonFunction.Focus(Me, txtBuyQty.ClientID)

                Case "02" '// Special Price
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = False
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = False

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = True

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = False
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = False

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = False

                    commonFunction.Focus(Me, txtSpecialPrice.ClientID)

                Case "03" '// Discount n1%
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = False
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = False

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = False

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = True
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = False

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = False

                    commonFunction.Focus(Me, txtDisc1Pct.ClientID)

                Case "04" '// Discount n1+n2%
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = False
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = False

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = False

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = True
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = True

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = False

                    commonFunction.Focus(Me, txtDisc1Pct.ClientID)

                Case "05" '// Get Voucher Amount
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = False
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = False

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = False

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = False
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = False

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = True

                    commonFunction.Focus(Me, txtGetVoucherAmt.ClientID)

                Case Else
                    txtBuyQty.Text = "0"
                    txtBuyQty.Enabled = False
                    txtGetQty.Text = "0"
                    txtGetQty.Enabled = False

                    txtSpecialPrice.Text = "0.00"
                    txtSpecialPrice.Enabled = False

                    txtDisc1Pct.Text = "0.00"
                    txtDisc1Pct.Enabled = False
                    txtDisc2Pct.Text = "0.00"
                    txtDisc2Pct.Enabled = False

                    txtGetVoucherAmt.Text = "0.00"
                    txtGetVoucherAmt.Enabled = False

                    commonFunction.Focus(Me, RadComboBoxID.ClientID)
            End Select
        End Sub

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridPromotion_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPromotion.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)

                    RadComboBoxID.Text = _lblID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim br As New BussinessRules.PromotionHd

            With br
                .ID = RadComboBoxID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxID.Text = .ID.Trim
                    End If
                    txtPromotionName.Text = .PromotionName.Trim
                    commonFunction.SelectListItem(ddlPromotionTypeID, .PromotionTypeID.Trim)
                    ddlPromotionTypeID_SelectedIndexChanged(Nothing, Nothing)
                    RadDatePickerStart.SelectedDate = .StartDate
                    RadDatePickerEnd.SelectedDate = .EndDate
                    txtBuyQty.Text = Format(.BuyQty, commonFunction.FORMAT_QTY).Trim
                    txtGetQty.Text = Format(.GetQty, commonFunction.FORMAT_QTY).Trim
                    txtSpecialPrice.Text = Format(.SpecialPrice, commonFunction.FORMAT_CURRENCY).Trim
                    txtDisc1Pct.Text = Format(.Disc1Pct, commonFunction.FORMAT_CURRENCY).Trim
                    txtDisc2Pct.Text = Format(.Disc2Pct, commonFunction.FORMAT_CURRENCY).Trim
                    txtBuyAmt.Text = Format(.BuyAmt, commonFunction.FORMAT_CURRENCY)
                    chkIsMultipleApplied.Checked = .IsMultipleApplied
                    txtGetVoucherAmt.Text = Format(.GetVoucherAmt, commonFunction.FORMAT_CURRENCY).Trim
                    txtnPurchase.Text = CType(.nPurchase, String)
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    chkIsNoEndDate.Checked = .IsNoEndDate
                    commonFunction.SelectListItem(ddlMemberType, .MemberTypeID.Trim)
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtPromotionName.Text = String.Empty
                    ddlPromotionTypeID.SelectedIndex = 0
                    ddlPromotionTypeID_SelectedIndexChanged(Nothing, Nothing)
                    RadDatePickerStart.SelectedDate = Date.Now
                    RadDatePickerEnd.SelectedDate = Date.Now
                    txtBuyQty.Text = "0"
                    txtGetQty.Text = "0"
                    txtSpecialPrice.Text = "0.00"
                    txtDisc1Pct.Text = "0.00"
                    txtDisc2Pct.Text = "0.00"
                    txtBuyAmt.Text = "0.00"
                    chkIsMultipleApplied.Checked = True
                    txtGetVoucherAmt.Text = "0.00"
                    txtnPurchase.Text = "0"
                    txtDescription.Text = String.Empty
                    chkIsActive.Checked = True
                    chkIsNoEndDate.Checked = False
                    ddlMemberType.SelectedIndex = 0
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, txtPromotionName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(txtPromotionName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Promotion name cannot empty.")
                Exit Sub
            End If

            If ddlPromotionTypeID.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Promotion type cannot empty.")
                Exit Sub
            End If

            If RadDatePickerStart.SelectedDate = Nothing Then
                commonFunction.MsgBox(Me, "Start date cannot empty.")
                Exit Sub
            End If

            If RadDatePickerEnd.SelectedDate = Nothing Then
                commonFunction.MsgBox(Me, "End date cannot empty.")
                Exit Sub
            End If

            If RadDatePickerStart.SelectedDate.Value > RadDatePickerEnd.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "The Start date must be after the end date.")
                Exit Sub
            End If

            If Not IsNumeric(txtBuyQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Buy qty must be numeric.")
                txtBuyQty.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtBuyQty.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Buy qty must be equal or greater than 0.")
                txtBuyQty.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtGetQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Get qty must be numeric.")
                txtGetQty.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtGetQty.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Get qty must be equal or greater than 0.")
                txtGetQty.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtSpecialPrice.Text.Trim) Then
                commonFunction.MsgBox(Me, "Special price must be numeric.")
                txtSpecialPrice.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtSpecialPrice.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Special price must be equal or greater than 0.")
                txtSpecialPrice.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtDisc1Pct.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount ( % ) 1 must be numeric.")
                txtDisc1Pct.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtDisc1Pct.Text.Trim) < 0 OrElse CDec(txtDisc1Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount ( % ) 1 must be 0% - 100%.")
                txtDisc1Pct.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtDisc2Pct.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount ( % ) 2 must be numeric.")
                txtDisc2Pct.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtDisc2Pct.Text.Trim) < 0 OrElse CDec(txtDisc2Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount ( % ) 2 must be 0% - 100%.")
                txtDisc2Pct.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtBuyAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Buy amount must be numeric.")
                txtBuyAmt.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtBuyAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Buy amount must be equal or greater than 0.")
                txtBuyAmt.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtGetVoucherAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Get voucher amount must be numeric.")
                txtGetVoucherAmt.Text = "0.00"
                Exit Sub
            End If

            If CDec(txtGetVoucherAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Get voucher amount must be equal or greater than 0.")
                txtGetVoucherAmt.Text = "0.00"
                Exit Sub
            End If

            If Not IsNumeric(txtnPurchase.Text.Trim) Then
                commonFunction.MsgBox(Me, "n purchase amount must be numeric.")
                txtnPurchase.Text = "0"
                Exit Sub
            End If

            If CDec(txtnPurchase.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "n purchase must be equal or greater than 0.")
                txtnPurchase.Text = "0"
                Exit Sub
            End If


            Dim br As New BussinessRules.PromotionHd
            Dim fnotNew As Boolean = False

            With br
                .ID = RadComboBoxID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fnotNew = True
                Else
                    .ID = BussinessRules.ID.GenerateIDNumber("PromotionHd", "ID")
                    fnotNew = False
                End If

                '// set the value
                .PromotionName = txtPromotionName.Text.Trim
                .PromotionTypeID = ddlPromotionTypeID.SelectedItem.Value.Trim
                .StartDate = RadDatePickerStart.SelectedDate.Value.Date
                .EndDate = RadDatePickerEnd.SelectedDate.Value.Date
                .BuyQty = CDec(Left(Replace(txtBuyQty.Text.Trim, ",", ""), 16).Trim)
                .GetQty = CDec(Left(Replace(txtGetQty.Text.Trim, ",", ""), 16).Trim)
                .SpecialPrice = CDec(Left(Replace(txtSpecialPrice.Text.Trim, ",", ""), 16).Trim)
                .Disc1Pct = CDec(Left(Replace(txtDisc1Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc2Pct = CDec(Left(Replace(txtDisc2Pct.Text.Trim, ",", ""), 16).Trim)
                .BuyAmt = CDec(Left(Replace(txtBuyAmt.Text.Trim, ",", ""), 16).Trim)
                .IsMultipleApplied = chkIsMultipleApplied.Checked
                .GetVoucherAmt = CDec(Left(Replace(txtGetVoucherAmt.Text.Trim, ",", ""), 16).Trim)
                .nPurchase = CDec(Left(Replace(txtnPurchase.Text.Trim, ",", ""), 16).Trim)
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsActive = chkIsActive.Checked
                .IsNoEndDate = chkIsNoEndDate.Checked
                .MemberTypeID = ddlMemberType.SelectedItem.Value.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fnotNew Then
                    If .Update() Then
                        _Open(RavenRecStatus.CurrentRecord)
                        UpdateViewGridPromotion()
                    End If
                Else
                    If .Insert() Then
                        PrepareScreen()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PromotionHd
            Dim brdt As New BussinessRules.Promotiondt

            With br
                .ID = RadComboBoxID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    brdt.ID = RadComboBoxID.Text.Trim
                    If brdt.SelectAllByID.Rows.Count > 0 Then
                        commonFunction.MsgBox(Me, "Record cannot be delete due to inconsistency")
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

            commonFunction.Focus(Me, RadComboBoxID.ClientID)
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
            '//Member Type
            Dim oMemberType As New BussinessRules.MemberBenefit
            Dim dtMemberType As New DataTable
            With oMemberType
                dtMemberType = .SelectAllActive
                commonFunction.LoadDDL(ddlMemberType, "MBTypeName", "MBTypeID", dtMemberType, True)
            End With
            oMemberType.Dispose()
            oMemberType = Nothing

            RadDatePickerStart.SelectedDate = Date.Now
            RadDatePickerEnd.SelectedDate = Date.Now
            RadComboBoxID.Text = String.Empty
            ddlPromotionTypeID.SelectedIndex = 0
            ddlPromotionTypeID_SelectedIndexChanged(Nothing, Nothing)
            txtPromotionName.Text = String.Empty
            txtBuyQty.Text = "0"
            txtGetQty.Text = "0"
            txtSpecialPrice.Text = "0.00"
            txtDisc1Pct.Text = "0.00"
            txtDisc2Pct.Text = "0.00"
            txtBuyAmt.Text = "0.00"
            chkIsMultipleApplied.Checked = True
            txtDescription.Text = String.Empty
            txtGetVoucherAmt.Text = "0.00"
            txtnPurchase.Text = "0"
            chkIsActive.Checked = True
            chkIsNoEndDate.Checked = False
            ddlMemberType.SelectedIndex = 0
            UpdateViewGridPromotion()

            commonFunction.Focus(Me, RadComboBoxID.ClientID)
        End Sub

        Private Sub LoadPromotion(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PromotionHd

            dt = br.SelectAllForID(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxID.DataSource = dt.DefaultView
            RadComboBoxID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridPromotion()
            Dim dt As DataTable
            Dim br As New BussinessRules.PromotionHd

            dt = br.SelectAll

            RadGridPromotion.DataSource = dt.DefaultView
            RadGridPromotion.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace