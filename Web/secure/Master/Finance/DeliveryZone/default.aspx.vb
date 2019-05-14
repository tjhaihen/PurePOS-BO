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

    Public Class DeliveryZone
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "258"
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeliveryZoneIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeliveryZoneNameCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtDeliveryZoneName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliveryFee As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMinPurchaseAmount As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtMinPurchaseQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliveryInterval As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescription As System.Web.UI.WebControls.TextBox
        Protected WithEvents chkIsActive As System.Web.UI.WebControls.CheckBox
        Protected WithEvents RadComboBoxDeliveryZoneID As RadComboBox
        Protected WithEvents Toolbar As CSSToolbar
        Protected WithEvents lblRecordEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents RadAjaxManager1 As RadAjaxManager

        Protected WithEvents RadGridDeliveryZone As DataGrid

#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxDeliveryZoneID.IsCallBack Then
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

        Private Sub RadComboBoxDeliveryZoneID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxDeliveryZoneID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadDeliveryZone(e.Text)
        End Sub

        Private Sub RadComboBoxDeliveryZoneID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxDeliveryZoneID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("DeliveryZoneID").ToString()
        End Sub

        Private Sub RadComboBoxDeliveryZoneID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDeliveryZoneID.SelectedIndexChanged
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
        Private Sub RadGridDeliveryZone_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridDeliveryZone.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblDeliveryZoneID As Label = CType(e.Item.FindControl("_lblDeliveryZoneID"), Label)

                    RadComboBoxDeliveryZoneID.Text = _lblDeliveryZoneID.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            Dim br As New BussinessRules.DeliveryZoneHd

            With br
                .DeliveryZoneID = RadComboBoxDeliveryZoneID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxDeliveryZoneID.Text = .DeliveryZoneID.Trim
                    End If
                    txtDeliveryZoneName.Text = .DeliveryZoneName.Trim
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    txtDeliveryFee.Text = Format(.DeliveryFee, commonFunction.FORMAT_CURRENCY).Trim
                    txtMinPurchaseAmount.Text = Format(.MinPurchaseAmount, commonFunction.FORMAT_CURRENCY).Trim
                    txtMinPurchaseQty.Text = Format(.MinPurchaseQty, commonFunction.FORMAT_QTY)
                    txtDeliveryInterval.Text = .DeliveryInterval.Trim

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

            commonFunction.Focus(Me, txtDeliveryZoneName.ClientID)
        End Sub

        Private Sub _Save()
            If Len(RadComboBoxDeliveryZoneID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Delivery Zone ID cannot empty.")
                Exit Sub
            End If

            If Len(txtDeliveryZoneName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Delivery Zone Name cannot empty.")
                Exit Sub
            End If

            If IsNumeric(txtDeliveryFee.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Delivery Fee must be numeric.")
                Exit Sub
            End If

            If IsNumeric(txtMinPurchaseAmount.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Min. Purchase Amount must be numeric.")
                Exit Sub
            End If

            If CDec(txtMinPurchaseAmount.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Min. Purchase Amount must be equal or greater than 0.")
                Exit Sub
            End If

            If IsNumeric(txtMinPurchaseQty.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Min. Purchase Qty must be numeric.")
                Exit Sub
            End If

            If CDec(txtMinPurchaseQty.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Min. Purchase Qty must be equal or greater than 0.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DeliveryZoneHd
            Dim fNew As Boolean = True

            With br
                .DeliveryZoneID = RadComboBoxDeliveryZoneID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                End If

                '// set the value
                .DeliveryZoneID = RadComboBoxDeliveryZoneID.Text.Trim
                .DeliveryZoneName = txtDeliveryZoneName.Text.Trim
                .DeliveryFee = CDec(txtDeliveryFee.Text.Trim)
                .MinPurchaseAmount = CDec(txtMinPurchaseAmount.Text.Trim)
                .MinPurchaseQty = CDec(txtMinPurchaseQty.Text.Trim)
                .DeliveryInterval = txtDeliveryInterval.Text.Trim
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
                        _Open(RavenRecStatus.CurrentRecord)
                        UpdateViewGridDeliveryZone()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxDeliveryZoneID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.DeliveryZoneHd

            With br
                .DeliveryZoneID = RadComboBoxDeliveryZoneID.Text.Trim
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

            commonFunction.Focus(Me, RadComboBoxDeliveryZoneID.ClientID)
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
                RadComboBoxDeliveryZoneID.Text = String.Empty
            End If
            txtDeliveryZoneName.Text = String.Empty
            txtDeliveryFee.Text = "0.00"
            txtMinPurchaseAmount.Text = "0.00"
            txtMinPurchaseQty.Text = "0.000"
            txtDeliveryInterval.Text = String.Empty
            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            UpdateViewGridDeliveryZone()
        End Sub

        Private Sub LoadDeliveryZone(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryZoneHd

            dt = br.SelectAllForDeliveryZoneId(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxDeliveryZoneID.DataSource = dt.DefaultView
            RadComboBoxDeliveryZoneID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridDeliveryZone()
            Dim dt As DataTable
            Dim br As New BussinessRules.DeliveryZoneHd

            dt = br.SelectAll

            RadGridDeliveryZone.DataSource = dt.DefaultView
            RadGridDeliveryZone.DataBind()

            br.Dispose()
            br = Nothing
        End Sub
#End Region

        Private Sub InitializeComponent()

        End Sub

    End Class
End Namespace