Option Strict Off
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

'Imports System.Web.Mail

Imports Raven
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.SystemFramework


Namespace Raven.Web.Secure.Purchasing

    Public Class PurchaseOrder
        Inherits PageBase        

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "330"

        'header
        Protected WithEvents RadPOrdDate As RadDatePicker
        Protected WithEvents RadPOrdExpiredDate As RadDatePicker
        Protected WithEvents RadPOrdDeliveryDate As RadDatePicker

        Protected WithEvents ddlPOrdTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlPaymentTypeID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlCurrency As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTermOfPayment As System.Web.UI.WebControls.DropDownList
        Protected WithEvents ddlTermOfAgreement As System.Web.UI.WebControls.DropDownList

        Protected WithEvents txtEntitiesName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPICName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCurrencyRate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptionHd As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDeliverTo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPNpct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPPN As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalPct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDiscFinalAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDPAmt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtTotal As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtGrandTotal As System.Web.UI.WebControls.TextBox

        Protected WithEvents RadComboBoxPurchaseOrderID As RadComboBox
        Protected WithEvents RadComboBoxEntitiesID As RadComboBox

        Protected WithEvents chkIsPPN As System.Web.UI.WebControls.CheckBox

        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents PnlApproved As System.Web.UI.WebControls.Panel

        'detail

        Protected WithEvents txtItemSeqNo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemName As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtItemFactor As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtQty As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtPrice As System.Web.UI.WebControls.TextBox

        Protected WithEvents txtDisc1Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc1Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc2Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc2Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc3Pct As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDisc3Amt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtDescriptiondt As System.Web.UI.WebControls.TextBox

        Protected WithEvents lbtnNewDetail As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lbtnSaveDetail As System.Web.UI.WebControls.LinkButton

        Protected WithEvents chkIsBonus As System.Web.UI.WebControls.CheckBox

        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox
        Protected WithEvents ddlItemUnitID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents RadAjaxManager1 As RadAjaxManager
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image

        Protected WithEvents lblRecordHeaderEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPurchaseOrderID As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdExpiredDateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPOrdTypeIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblEntitiesID As System.Web.UI.WebControls.Label
        Protected WithEvents lblWhIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPaymentTypeIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCurrencyCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCurrencyRateCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblTermOfPaymentCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptionHdCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordDetailEntryCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemSeqNo As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemUnitIDCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemFactorCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblQtyCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPriceCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc1PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc2PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc3PctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDescriptiondtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc1AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc2AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDisc3AmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblRecordListCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblPPNCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiscFinalPctCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDiscFinalAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblDPAmtCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblGrandTotalCaption As System.Web.UI.WebControls.Label
        Protected WithEvents sharedCalendar As RadCalendar
        Protected WithEvents sharedCalendarPlaceHolder As System.Web.UI.WebControls.PlaceHolder

        '// grid
        Protected WithEvents RadGridPurchaseOrder As DataGrid

        '// Record Properties
        Protected WithEvents lblUserInsert As System.Web.UI.WebControls.Label
        Protected WithEvents lblInsertDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUserUpdate As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateDate As System.Web.UI.WebControls.Label

        Private StrPONo As String
#End Region

#Region " Control Events "

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And _
                'Not RadComboBoxPurchaseOrderID.IsCallBack And _
                'Not RadComboBoxEntitiesID.IsCallBack And _
                'Not RadComboBoxItemSeqNo.IsCallBack Then

                If Not MyBase.AllowRead(Me.ModuleId) Then
                    Throw New Exception(commonFunction.MSG_ACCESS_DENIED)
                End If

                Toolbar.UserGroupID = MyBase.LoggedOnUserGroupID
                Toolbar.MenuID = ModuleId.Trim
                Toolbar.setAuthorizationToolbar()
                setToolbarVisibledButton()

                PrepareScreenHd()

                If ReadQueryString() = True Then
                    RadComboBoxPurchaseOrderID.Text = StrPONo.Trim
                    _OpenHd(RavenRecStatus.CurrentRecord)
                End If

                'PlainTextAuthentication("pop.mail.yahoo.co.id", "sugi_kuo@yahoo.com", "password", "sugi_kuo@yahoo.com", "sugi_kuo@yahoo.com", "tes aj", "hore berhasil")

            End If
        End Sub

        'Private Sub PlainTextAuthentication(ByVal oServer As String, _
        '                    ByVal oUser As String, _
        '                    ByVal oPassword As String, _
        '                    ByVal oSendTo As String, _
        '                    ByVal oFrom As String, _
        '                    ByVal oSubject As String, _
        '                    ByVal oBody As String)
        '    'Declare and build the standard MailMessage 
        '    '(See previous example for detail)
        '    Dim oMessage As New MailMessage
        '    oMessage.From = oFrom
        '    oMessage.To = oSendTo
        '    oMessage.Subject = oSubject
        '    oMessage.BodyFormat = MailFormat.Text
        '    oMessage.Body = oBody

        '    'Storing keys to a varible to provide readable code
        '    Dim oAuthenticationKey As String = "http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"
        '    Dim oSendUsernameKey As String = "http://schemas.microsoft.com/cdo/configuration/sendusername"
        '    Dim oSendPasswordKey As String = "http://schemas.microsoft.com/cdo/configuration/sendpassword"

        '    'Add field information for the authentication, username, and password
        '    oMessage.Fields.Add(oAuthenticationKey, "1")    'Enables basic authentication
        '    oMessage.Fields.Add(oSendUsernameKey, oUser)    'Sends the username with the msg
        '    oMessage.Fields.Add(oSendPasswordKey, oPassword) 'Sends the password with the msg

        '    'Set the mail server
        '    SmtpMail.SmtpServer = oServer

        '    'Send the message
        '    SmtpMail.Send(oMessage)
        'End Sub

        Private Sub RadComboBoxPurchaseOrderID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxPurchaseOrderID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadPurchaseOrder(e.Text)
        End Sub

        Private Sub RadComboBoxPurchaseOrderID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxPurchaseOrderID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("POrdNO").ToString()
        End Sub

        Private Sub RadComboBoxPurchaseOrderID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPurchaseOrderID.SelectedIndexChanged
            _OpenHd(RavenRecStatus.CurrentRecord)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxEntitiesID.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadEntities(e.Text)
        End Sub

        Private Sub RadComboBoxEntitiesID_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxEntitiesID.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("EntitiesID").ToString()
        End Sub

        Private Sub RadComboBoxEntitiesID_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEntitiesID.SelectedIndexChanged
            commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName)
            If Len(txtEntitiesName.Text.Trim) > 0 Then
                txtPICName.Text = GetEntitiesPICName(RadComboBoxEntitiesID.SelectedValue.Trim).Trim
            Else
                txtPICName.Text = String.Empty
            End If
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            LoadItem(e.Text)
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemID").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNo.SelectedIndexChanged
            commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName)
            txtItemSeqNo.Text = RadComboBoxItemSeqNo.SelectedValue.Trim
            Dim itemunit As New BussinessRules.ItemUnit
            commonFunction.LoadDDL(ddlItemUnitID, "ItemUnitName", "ItemUnitID", itemunit.SelectAllByItemSeqNo(RadComboBoxItemSeqNo.SelectedValue.Trim))
            itemunit.Dispose()
            itemunit = Nothing
        End Sub

        Private Sub Toolbar_OnClick(ByVal sender As System.Object, ByVal e As CSSToolbarItem) Handles Toolbar.CSSToolbarItemClick
            Select Case e
                Case CSSToolbarItem.tidNew
                    PrepareScreenHd()
                Case CSSToolbarItem.tidSave, CSSToolbarItem.tidVoid
                    _SaveHd()
                Case CSSToolbarItem.tidDelete
                    _DeleteHd()
                Case CSSToolbarItem.tidApprove
                    _SaveHd(True)
                Case CSSToolbarItem.tidPrevious
                    _OpenHd(RavenRecStatus.PreviousRecord)
                Case CSSToolbarItem.tidNext
                    _OpenHd(RavenRecStatus.NextRecord)
                Case CSSToolbarItem.tidPrint
                    If RadComboBoxPurchaseOrderID.Text.Trim <> "" Then
                        Dim oprintform As New BussinessRules.PrintForm
                        With oprintform
                            .PrintFormID = 3301
                            .MenuID = CInt(ModuleId.Trim)
                            .AddParametersPrintForm(RadComboBoxPurchaseOrderID.Text.Trim)
                            .AddParametersPrintForm(MyBase.LoggedOnUserID.Trim)
                            Response.Write(.UrlPrintForm(Context.Request.Url.Host))
                        End With
                        oprintform.Dispose()
                        oprintform = Nothing
                    Else
                        commonFunction.MsgBox(Me, "Nothing to preview.")
                    End If
            End Select
        End Sub

        Private Sub lbtnNewDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnNewDetail.Click
            PrepareScreendt()
        End Sub

        Private Sub lbtnSaveDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnSaveDetail.Click
            _SaveDt()
        End Sub

        Private Sub ddlItemUnitID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemUnitID.SelectedIndexChanged
            Dim ift As New BussinessRules.ItemFactorTemplate
            ift.ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
            ift.ItemUnitID = ddlItemUnitID.SelectedValue
            If ift.SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                txtItemFactor.Text = Format(ift.ItemFactor, commonFunction.FORMAT_CURRENCY)
            Else
                txtItemFactor.Text = ""
            End If
            ift.Dispose()
            ift = Nothing
            loadprice()
        End Sub

        Private Sub chkIsBonus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsBonus.CheckedChanged
            If chkIsBonus.Checked Then
                txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If

            txtPrice.Enabled = Not chkIsBonus.Checked
            txtDisc1Pct.Enabled = Not chkIsBonus.Checked
            txtDisc1Amt.Enabled = Not chkIsBonus.Checked
            txtDisc2Pct.Enabled = Not chkIsBonus.Checked
            txtDisc2Amt.Enabled = Not chkIsBonus.Checked
            txtDisc3Pct.Enabled = Not chkIsBonus.Checked
            txtDisc3Amt.Enabled = Not chkIsBonus.Checked
        End Sub

        Private Sub chkIsPPN_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsPPN.CheckedChanged
            If chkIsPPN.Checked Then
                txtPPN.Text = Format((CDbl(txtPPNpct.Text.Trim) * (CDbl(txtTotal.Text.Trim) - CDbl(txtDiscFinalAmt.Text)) / 100), commonFunction.FORMAT_CURRENCY)
            Else
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
            '            txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalPct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalPct.TextChanged
            If Not IsNumeric(txtDiscFinalPct.Text) Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) must be numeric")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalPct.Text.Trim) < 0 OrElse CDec(txtDiscFinalPct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount Final ( % ) Must Be 0% - 100%.")
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            txtDiscFinalPct.Text = Format(CDbl(txtDiscFinalPct.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format((CDbl(txtDiscFinalPct.Text.Trim) * CDbl(txtTotal.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            'txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtDiscFinalAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscFinalAmt.TextChanged
            If Not IsNumeric(txtDiscFinalAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount Final Must Be Numeric.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDiscFinalAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount Final Must Be equal Or Greater than 0.")
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtDiscFinalAmt.Text = Format(CDbl(txtDiscFinalAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsPPN_CheckedChanged(Nothing, Nothing)
            'txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtDPAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDPAmt.TextChanged
            If Not IsNumeric(txtDPAmt.Text.Trim) Then
                commonFunction.MsgBox(Me, "DP Amount Must Be Numeric.")
                txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDPAmt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "DP Amount Must Be equal Or Greater than 0.")
                txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            txtDPAmt.Text = Format(CDbl(txtDPAmt.Text.Trim), commonFunction.FORMAT_CURRENCY)
            CalculationGrid()
        End Sub

        Private Sub txtPrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrice.TextChanged
            If IsNumeric(txtPrice.Text.Trim) Then
                txtPrice.Text = Format(CDec(txtPrice.Text.Trim), commonFunction.FORMAT_CURRENCY)
            Else
                txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If

            txtDisc1Pct_TextChanged(Nothing, Nothing)
        End Sub

        Private Sub txtDisc1Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Pct.TextChanged
            If IsNumeric(txtDisc1Pct.Text.Trim) Then
                txtDisc1Amt.Text = Format((CDbl(txtDisc1Pct.Text.Trim) * CDbl(txtPrice.Text.Trim) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc1Amt.Text.Trim) > CDbl(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc1Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc1Amt.TextChanged
            If IsNumeric(txtDisc1Amt.Text.Trim) Then
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(CDbl(txtDisc1Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc1Amt.Text.Trim) > CDbl(txtPrice.Text.Trim) Then
                    txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            Else
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Pct.TextChanged
            If IsNumeric(txtDisc2Pct.Text.Trim) Then
                txtDisc2Amt.Text = Format((CDbl(txtDisc2Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc2Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc2Amt.TextChanged
            If IsNumeric(txtDisc2Amt.Text.Trim) Then
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(CDbl(txtDisc2Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc2Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim)) Then
                    txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            Else
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Pct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Pct.TextChanged
            If IsNumeric(txtDisc3Pct.Text.Trim) Then
                txtDisc3Amt.Text = Format((CDbl(txtDisc3Pct.Text.Trim) * (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) / 100), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub txtDisc3Amt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDisc3Amt.TextChanged
            If IsNumeric(txtDisc3Amt.Text.Trim) Then
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(CDbl(txtDisc3Amt.Text), commonFunction.FORMAT_CURRENCY)
                If CDbl(txtDisc3Amt.Text.Trim) > (CDbl(txtPrice.Text.Trim) - CDbl(txtDisc1Amt.Text.Trim) - CDbl(txtDisc2Amt.Text.Trim)) Then
                    txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                End If
            Else
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            End If
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            If ddlCurrency.SelectedValue.Trim = commonFunction.GetCurrencyPos.Trim Then
                txtCurrencyRate.ReadOnly = True
                txtCurrencyRate.Text = Format(1, commonFunction.FORMAT_CURRENCY)
            Else
                txtCurrencyRate.ReadOnly = False
            End If
            loadprice()
        End Sub
#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridPurchaseOrder_ItemCommand(ByVal source As Object, ByVal e As DataGridCommandEventArgs) Handles RadGridPurchaseOrder.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _OpenDt()
                Case "Delete"
                    Dim _lblID As Label = CType(e.Item.FindControl("_lblID"), Label)
                    txtID.Text = _lblID.Text.Trim
                    _DeleteDt(txtID.Text.Trim)
            End Select
        End Sub
        Private Sub RadGridPurchaseOrder_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles RadGridPurchaseOrder.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    ' // Dialog save or not when the imagebutton clicked by user ..
                    Dim _lbtnDelete As LinkButton = CType(e.Item.FindControl("_lbtnDelete"), LinkButton)

                    If Not _lbtnDelete Is Nothing Then
                        _lbtnDelete.Attributes.Add("OnClick", "javascript:return dlgDeleteRecordInGrid();")
                    End If
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _OpenHd(ByVal recStatus As BussinessRules.RavenRecStatus)

            Dim br As New BussinessRules.PurchaseOrderHd
            With br
                .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If .IsDeleted Then
                        'commonFunction.MsgBox(Me, "Purchase order ID is deleted.")
                        PrepareScreenHd()

                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If

                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxPurchaseOrderID.Text = .POrdNO.Trim
                    End If
                    RadPOrdDate.SelectedDate = .POrdDate
                    RadPOrdExpiredDate.SelectedDate = .POrdExpiredDate
                    RadPOrdDeliveryDate.SelectedDate = .DeliveryDate
                    commonFunction.SelectListItem(ddlPOrdTypeID, .POrdTypeID.Trim)
                    RadComboBoxEntitiesID.SelectedValue = .EntitiesSeqNo.Trim
                    commonFunction.LoadIDName("EntitiesWithTextBox", RadComboBoxEntitiesID, txtEntitiesName, True)
                    txtPICName.Text = .PICName.Trim
                    commonFunction.SelectListItem(ddlPaymentTypeID, .PaymentTypeID.Trim)
                    commonFunction.SelectListItem(ddlCurrency, .Currency.Trim)
                    txtCurrencyRate.Text = Format(.CurrencyRate, commonFunction.FORMAT_CURRENCY)
                    commonFunction.SelectListItem(ddlTermOfPayment, .TermOfPayment.Trim)
                    commonFunction.SelectListItem(ddlTermOfAgreement, .TermOfAgreement.Trim)
                    chkIsPPN.Checked = .IsPPN
                    txtPPNpct.Text = Format(IIf(.PPNPct = 0, CDec(txtPPNpct.Text), .PPNPct), commonFunction.FORMAT_CURRENCY)
                    txtDescriptionHd.Text = .Description.Trim
                    txtDeliverTo.Text = .DeliverTo.Trim
                    txtDiscFinalPct.Text = Format(.DiscFinalPct, commonFunction.FORMAT_CURRENCY)
                    txtDiscFinalAmt.Text = Format(.DiscFinalAmt, commonFunction.FORMAT_CURRENCY)
                    txtDPAmt.Text = Format(.DPAmt, commonFunction.FORMAT_CURRENCY)
                    UpdateViewGridPurchaseOrder()

                    If .IsApproval Then
                        RadComboBoxEntitiesID.Enabled = False
                        chkIsPPN.Enabled = False
                        txtDiscFinalPct.ReadOnly = True
                        txtDiscFinalAmt.ReadOnly = True
                        txtCurrencyRate.ReadOnly = True
                        txtDPAmt.ReadOnly = True
                        commonFunction.ShowPanel(PnlApproved, True)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = True

                        lbtnNewDetail.Enabled = False
                        lbtnSaveDetail.Enabled = False
                        ddlCurrency.Enabled = False
                        RadGridPurchaseOrder.Columns(0).Visible = False
                        RadGridPurchaseOrder.Columns(1).Visible = False
                    Else
                        RadComboBoxEntitiesID.Enabled = True
                        chkIsPPN.Enabled = True
                        txtDiscFinalPct.ReadOnly = False
                        txtDiscFinalAmt.ReadOnly = False
                        txtDPAmt.ReadOnly = False
                        txtCurrencyRate.ReadOnly = False
                        commonFunction.ShowPanel(PnlApproved, False)

                        Toolbar.EnableButton(CSSToolbarItem.tidSave) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidDelete) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidApprove) = True
                        Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False
                        

                        lbtnNewDetail.Enabled = True
                        lbtnSaveDetail.Enabled = True

                        ddlCurrency.Enabled = True
                        RadGridPurchaseOrder.Columns(0).Visible = True
                        RadGridPurchaseOrder.Columns(1).Visible = True
                    End If
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If

                    PrepareScreenHd()
                End If
            End With
GoNext:
            br.Dispose()
            br = Nothing

            GetRecordProperties()
            commonFunction.Focus(Me, RadComboBoxEntitiesID.ClientID)
        End Sub

        Private Sub _OpenDt()

            Dim br As New BussinessRules.PurchaseOrderDt
            With br
                .ID = txtID.Text.Trim
                If .SelectOne().Rows.Count > 0 Then
                    If .IsDeleted Then
                        commonFunction.MsgBox(Me, "Item is deleted by " + .UserDelete + ".")
                        UpdateViewGridPurchaseOrder()
                        br.Dispose()
                        br = Nothing
                        Exit Sub
                    End If
                    txtID.Text = .ID.Trim
                    RadComboBoxItemSeqNo.SelectedValue = .ItemSeqNo.Trim
                    commonFunction.LoadIDName("ItemWithTextBox", RadComboBoxItemSeqNo, txtItemName, True)
                    txtItemSeqNo.Text = RadComboBoxItemSeqNo.SelectedValue.Trim
                    chkIsBonus.Checked = .IsBonus
                    RadComboBoxItemSeqNo_SelectedIndexChanged(Nothing, Nothing)
                    commonFunction.SelectListItem(ddlItemUnitID, .ItemUnitID)
                    txtItemFactor.Text = Format(.ItemFactor, commonFunction.FORMAT_CURRENCY)
                    txtQty.Text = Format(.Qty, commonFunction.FORMAT_CURRENCY)
                    txtPrice.Text = Format(.Price, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Pct.Text = Format(.Disc1Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc1Amt.Text = Format(.Disc1Amt, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Pct.Text = Format(.Disc2Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc2Amt.Text = Format(.Disc2Amt, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Pct.Text = Format(.Disc3Pct, commonFunction.FORMAT_CURRENCY)
                    txtDisc3Amt.Text = Format(.Disc3Amt, commonFunction.FORMAT_CURRENCY)
                    txtDescriptiondt.Text = .Description.Trim
                Else
                    PrepareScreendt()
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxItemSeqNo.ClientID)
        End Sub

        Private Function _SaveHd(Optional ByVal FApproval As Boolean = False) As Boolean
            If Not FApproval Then
                Dim brdt As New BussinessRules.PurchaseUnitDt
                With brdt
                    .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                    If .SelectAllByPONo.Rows.Count > 0 Then
                        commonFunction.MsgBox(Me, "This item already received.")
                        brdt.Dispose()
                        brdt = Nothing
                        Return False
                        Exit Function
                    End If
                End With
                brdt.Dispose()
                brdt = Nothing

                Dim podt As New BussinessRules.PurchaseOrderDt
                With podt
                    .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                    Dim dv As New DataView(.SelectAllByPOrdNO)
                    dv.RowFilter = "IsRelease = 1"
                    If dv.Count > 0 Then
                        commonFunction.MsgBox(Me, "This item already released.")
                        dv.Dispose()
                        dv = Nothing
                        podt.Dispose()
                        podt = Nothing
                        Return False
                        Exit Function
                    End If
                    dv.Dispose()
                    dv = Nothing
                End With
                podt.Dispose()
                podt = Nothing
            End If

            If Len(RadComboBoxEntitiesID.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Supplier Name Cannot Empty.")
                Return False
                Exit Function
            End If

            If ddlPaymentTypeID.SelectedValue.Trim = "none" Then
                commonFunction.MsgBox(Me, "Payment Type Cannot Empty.")
                Return False
                Exit Function
            End If

            If CDbl(txtGrandTotal.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Grand Total must be equal or greater than 0.")
                Return False
                Exit Function
            End If

            If RadPOrdExpiredDate.SelectedDate.Value < RadPOrdDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "PO Due Date must be equal or greater than PO Date.")
                Return False
                Exit Function
            End If

            If RadPOrdDeliveryDate.SelectedDate.Value < RadPOrdDate.SelectedDate.Value Then
                commonFunction.MsgBox(Me, "Delivery Date must be equal or greater than PO Date.")
                Return False
                Exit Function
            End If

            If RadPOrdDate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "PO Date must be equal or greater than today.")
                Return False
                Exit Function
            End If

            If RadPOrdExpiredDate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "PO Due Date must be equal or greater than today.")
                Return False
                Exit Function
            End If

            If RadPOrdDeliveryDate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "Delivery Date must be equal or greater than today.")
                Return False
                Exit Function
            End If

            If IsNumeric(txtCurrencyRate.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Currency Rate must be numeric.")
                Return False
                Exit Function
            End If

            If CDec(txtCurrencyRate.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Currency Rate must be greater than 0.")
                Return False
                Exit Function
            End If

            Dim br As New BussinessRules.PurchaseOrderHd
            Dim fNew As Boolean = True

            With br
                .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    RadComboBoxPurchaseOrderID.Text = BussinessRules.ID.GenerateIDNumber("purchaseorderhd", "POrdNO", "PO")
                End If

                '// set the value
                .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                .POrdDate = RadPOrdDate.SelectedDate.Value
                .POrdExpiredDate = RadPOrdExpiredDate.SelectedDate.Value
                .DeliveryDate = RadPOrdDeliveryDate.SelectedDate.Value
                .POrdTypeID = ddlPOrdTypeID.SelectedValue
                .EntitiesSeqNo = RadComboBoxEntitiesID.SelectedValue.Trim
                .PICName = txtPICName.Text.Trim
                .PaymentTypeID = ddlPaymentTypeID.SelectedValue.Trim
                .Currency = ddlCurrency.SelectedValue.Trim
                .CurrencyRate = CDec(txtCurrencyRate.Text.Trim)
                .TermOfPayment = ddlTermOfPayment.SelectedValue.Trim
                .TermOfAgreement = ddlTermOfAgreement.SelectedValue.Trim
                .IsPPN = chkIsPPN.Checked
                .PPNPct = CDec(txtPPNpct.Text)
                .DiscFinalPct = CDec(txtDiscFinalPct.Text.Trim)
                .DiscFinalAmt = CDec(txtDiscFinalAmt.Text.Trim)
                .DPAmt = CDec(txtDPAmt.Text.Trim)
                .Description = txtDescriptionHd.Text.Trim
                .DeliverTo = txtDeliverTo.Text.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .IsApproval = FApproval

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

            br.Dispose()
            br = Nothing

            _OpenHd(RavenRecStatus.CurrentRecord)
            Return True
        End Function

        Private Sub _SaveDt()

            If Not IsNumeric(txtQty.Text.Trim) Then
                commonFunction.MsgBox(Me, "Qty must be numeric.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtQty.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Qty must be greater than 0.")
                txtQty.Text = Format(1, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc1Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 1 ( % ) must be numeric")
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc1Pct.Text.Trim) < 0 OrElse CDec(txtDisc1Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 1 ( % ) must be 0% - 100%.")
                txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc1Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 1 must be numeric.")
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc1Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 1 must be equal or greater than 0.")
                txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc2Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 2 ( % ) must be numeric")
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc2Pct.Text.Trim) < 0 OrElse CDec(txtDisc2Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 2 ( % ) must be 0% - 100%.")
                txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc2Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 2 must be numeric.")
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc2Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 2 must be equal or greater than 0.")
                txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc3Pct.Text) Then
                commonFunction.MsgBox(Me, "Discount 3 ( % ) must be numeric")
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc3Pct.Text.Trim) < 0 OrElse CDec(txtDisc3Pct.Text.Trim) > 100 Then
                commonFunction.MsgBox(Me, "Discount 3 ( % ) must be 0% - 100%.")
                txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Not IsNumeric(txtDisc3Amt.Text.Trim) Then
                commonFunction.MsgBox(Me, "Discount 3 must be numeric.")
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If
            If CDec(txtDisc3Amt.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Discount 3 must be equal or greater than 0.")
                txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                Exit Sub
            End If

            If Len(RadComboBoxItemSeqNo.SelectedValue.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Name Cannot Empty.")
                Exit Sub
            End If

            If ddlItemUnitID.SelectedValue = "none" Then
                commonFunction.MsgBox(Me, "Item Unit Cannot Empty.")
                Exit Sub
            End If

            If Not IsNumeric(txtItemFactor.Text.Trim) Then
                commonFunction.MsgBox(Me, "Item Factor must be numeric.")
                Exit Sub
            End If

            If CDbl(txtItemFactor.Text.Trim) <= 0 Then
                commonFunction.MsgBox(Me, "Item Factor must be greater than 0.")
                Exit Sub
            End If

            If RadComboBoxPurchaseOrderID.Text.Trim.Length = 0 Then If Not _SaveHd() Then Exit Sub

            Dim br As New BussinessRules.PurchaseOrderDt
            Dim fNew As Boolean = True

            With br
                .ID = txtID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    txtID.Text = BussinessRules.ID.GenerateIDNumber("purchaseorderdt", "ID")
                End If

                '// set the value
                .ID = txtID.Text.Trim
                .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                .PReqNO = ""
                .ItemSeqNo = RadComboBoxItemSeqNo.SelectedValue.Trim
                .ItemUnitID = ddlItemUnitID.SelectedValue.Trim
                .ItemFactor = CDec(Left(Replace(txtItemFactor.Text.Trim, ",", ""), 15).Trim)
                .Qty = CDec(Left(Replace(txtQty.Text.Trim, ",", ""), 15).Trim)
                .Price = CDec(Left(Replace(txtPrice.Text.Trim, ",", ""), 16).Trim)
                .Disc1Pct = CDec(Left(Replace(txtDisc1Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc1Amt = CDec(Left(Replace(txtDisc1Amt.Text.Trim, ",", ""), 16).Trim)
                .Disc2Pct = CDec(Left(Replace(txtDisc2Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc2Amt = CDec(Left(Replace(txtDisc2Amt.Text.Trim, ",", ""), 16).Trim)
                .Disc3Pct = CDec(Left(Replace(txtDisc3Pct.Text.Trim, ",", ""), 16).Trim)
                .Disc3Amt = CDec(Left(Replace(txtDisc3Amt.Text.Trim, ",", ""), 16).Trim)
                .IsBonus = chkIsBonus.Checked
                .Description = txtDescriptiondt.Text.Trim
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With

            br.Dispose()
            br = Nothing

            PrepareScreendt()
            UpdateViewGridPurchaseOrder()
        End Sub

        Private Sub _DeleteHd()
            If Len(RadComboBoxPurchaseOrderID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseOrderHd

            With br
                .POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then

                    Dim brdt As New BussinessRules.PurchaseOrderDt
                    brdt.POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
                    brdt.UserDelete = MyBase.LoggedOnUserID.Trim
                    brdt.DeleteAllByPOrdNO()
                    brdt.Dispose()
                    brdt = Nothing

                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    If .Delete() = True Then
                        PrepareScreenHd()
                    End If
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
            End With

            br.Dispose()
            br = Nothing

            commonFunction.Focus(Me, RadComboBoxPurchaseOrderID.ClientID)
        End Sub

        Private Sub _DeleteDt(ByVal ID As String)
            If Len(ID.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.PurchaseOrderDt

            With br
                .ID = ID.Trim
                If .SelectOne().Rows.Count > 0 Then
                    .UserDelete = MyBase.LoggedOnUserID.Trim
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "Record not found.")
                End If
                UpdateViewGridPurchaseOrder()
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

#Region " Main Function (Custom) "

#End Region

#Region " Additional Function: Private Function "

        Private Function ReadQueryString() As Boolean
            StrPONo = Request.QueryString("PONo")
            Return Len(Trim(StrPONo)) > 0
        End Function

        Private Sub setToolbarVisibledButton()
            With Toolbar
                '.VisibleButton(CSSToolbarItem.tidApprove) = False
                '.VisibleButton(CSSToolbarItem.tidVoid) = False
                '.VisibleButton(CSSToolbarItem.tidPrint) = False
            End With
        End Sub

        Private Function GetEntitiesPICName(ByVal EntitiesSeqNo As String) As String
            Dim strPICName As String = String.Empty
            Dim br As New BussinessRules.EntitiesContact

            With br
                .EntitiesSeqNo = EntitiesSeqNo.Trim
                If .SelectOneByEntitiesSeqNo.Rows.Count > 0 Then
                    strPICName = .FullName.Trim
                Else
                    strPICName = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing

            Return strPICName.Trim
        End Function

        Private Sub PrepareScreenHd()
            commonFunction.LoadDDLCommonSetting("POrdType", ddlPOrdTypeID)
            commonFunction.LoadDDLCommonSetting("POPaymentType", ddlPaymentTypeID)
            commonFunction.LoadDDLCommonSetting("Currency", ddlCurrency, False)
            commonFunction.LoadDDLCommonSetting("TermOfPayment", ddlTermOfPayment)
            commonFunction.LoadDDLCommonSetting("TermOfAgreement", ddlTermOfAgreement)

            Toolbar.EnableButton(CSSToolbarItem.tidSave) = False
            Toolbar.EnableButton(CSSToolbarItem.tidDelete) = False
            Toolbar.EnableButton(CSSToolbarItem.tidApprove) = False
            Toolbar.EnableButton(CSSToolbarItem.tidVoid) = False            

            lbtnNewDetail.Enabled = True
            lbtnSaveDetail.Enabled = True

            RadComboBoxPurchaseOrderID.Text = String.Empty
            RadComboBoxPurchaseOrderID.SelectedValue = String.Empty

            RadPOrdDate.SelectedDate = Date.Now
            RadPOrdExpiredDate.SelectedDate = Date.Now
            RadPOrdDeliveryDate.SelectedDate = Date.Now
            txtDescriptionHd.Text = String.Empty
            txtDeliverTo.Text = String.Empty
            ddlPOrdTypeID.SelectedIndex = 0
            ddlPaymentTypeID.SelectedIndex = 0

            ddlCurrency.SelectedIndex = 0
            ddlCurrency.Enabled = True
            txtCurrencyRate.Text = "1.00"
            txtCurrencyRate.ReadOnly = False

            ddlTermOfPayment.SelectedIndex = 0
            ddlTermOfAgreement.SelectedIndex = 0
            txtDescriptionHd.Text = String.Empty
            commonFunction.ShowPanel(PnlApproved, False)

            RadComboBoxEntitiesID.Enabled = True
            RadComboBoxEntitiesID.Text = String.Empty
            RadComboBoxEntitiesID.SelectedValue = String.Empty
            txtEntitiesName.Text = String.Empty
            txtPICName.Text = String.Empty

            commonFunction.GetTaxPct(txtPPNpct)

            txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)

            ddlCurrency_SelectedIndexChanged(Nothing, Nothing)
            PrepareScreendt()

            UpdateViewGridPurchaseOrder()
            CalculationGrid()
            GetRecordProperties()
        End Sub

        Private Sub PrepareScreendt()
            txtID.Text = String.Empty
            RadComboBoxItemSeqNo.Text = String.Empty
            RadComboBoxItemSeqNo.SelectedValue = String.Empty
            txtItemSeqNo.Text = String.Empty
            txtItemName.Text = String.Empty
            ddlItemUnitID.Items.Clear()
            txtItemFactor.Text = "1"
            txtQty.Text = "1.00"
            txtPrice.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc1Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc2Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Pct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            txtDisc3Amt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
            chkIsBonus.Checked = False
            txtDescriptiondt.Text = String.Empty
        End Sub

        Private Sub LoadPurchaseOrder(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderHd

            dt = br.SelectAllForPOrdNO(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxPurchaseOrderID.DataSource = dt.DefaultView
            RadComboBoxPurchaseOrderID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadEntities(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Entities

            '// '01' = Supplier/Distributor as EntitiesType
            dt = br.SelectAllForEntitiesSeqNoByEntitiesType("01", Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxEntitiesID.DataSource = dt.DefaultView
            RadComboBoxEntitiesID.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectAllForItemSeqNo(Filter.Trim, commonFunction.MaxRecord)

            RadComboBoxItemSeqNo.DataSource = dt
            RadComboBoxItemSeqNo.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub CalculationGrid()
            txtGrandTotal.Text = Format((CDbl(txtTotal.Text) + CDbl(txtPPN.Text) - CDbl(txtDiscFinalAmt.Text) - CDbl(txtDPAmt.Text)), commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub UpdateViewGridPurchaseOrder()
            Dim subtotal As Double = 0
            Dim grandtotal As Double = 0
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseOrderDt
            br.POrdNO = RadComboBoxPurchaseOrderID.Text.Trim
            dt = br.SelectForViewGrid
            dt.Columns.Add("subtotal", GetType(System.Double))

            Dim dtRows As DataRow() = dt.Select()
            If dtRows.Length > 0 Then

                Dim i As Integer = 1
                Do While i <= dtRows.Length
                    dtRows(i - 1)("subtotal") = (CDbl(dtRows(i - 1)("qty")) * (CDbl(dtRows(i - 1)("Price")) - CDbl(dtRows(i - 1)("Disc1Amt")) - CDbl(dtRows(i - 1)("Disc2Amt")) - CDbl(dtRows(i - 1)("Disc3Amt"))))
                    subtotal = subtotal + CDbl(dtRows(i - 1)("subtotal"))
                    i += 1
                Loop
            Else

            End If
            txtTotal.Text = Format(subtotal, commonFunction.FORMAT_CURRENCY)

            If subtotal > 0 Then
                chkIsPPN.Enabled = True
                If txtDiscFinalPct.Text.Trim = "0" Then
                    txtDiscFinalAmt_TextChanged(Nothing, Nothing)
                Else
                    txtDiscFinalPct_TextChanged(Nothing, Nothing)
                End If
                chkIsPPN_CheckedChanged(Nothing, Nothing)
                txtDiscFinalPct.ReadOnly = False
                txtDiscFinalAmt.ReadOnly = False
                txtDPAmt.ReadOnly = False
            Else
                chkIsPPN.Enabled = False
                chkIsPPN.Checked = False
                txtDiscFinalPct.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtPPN.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDPAmt.Text = Format(0, commonFunction.FORMAT_CURRENCY)
                txtDiscFinalPct.ReadOnly = True
                txtDiscFinalAmt.ReadOnly = True
                txtDPAmt.ReadOnly = True
            End If

            CalculationGrid()

            RadGridPurchaseOrder.DataSource = dt.DefaultView
            RadGridPurchaseOrder.DataBind()

            dt.Dispose()
            dt = Nothing

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub loadprice()
            Dim oPrice As BussinessRules.Price
            oPrice = BussinessRules.Functions.GetPriceItemPO(ddlCurrency.SelectedValue.Trim, RadComboBoxItemSeqNo.SelectedValue.Trim, ddlItemUnitID.SelectedValue.Trim)
            txtPrice.Text = Format(oPrice.price, commonFunction.FORMAT_CURRENCY)
            txtDisc1Pct.Text = Format(oPrice.discount1pct, commonFunction.FORMAT_CURRENCY)
            txtDisc1Amt.Text = Format(oPrice.discount1amt, commonFunction.FORMAT_CURRENCY)
            txtDisc2Pct.Text = Format(oPrice.discount2pct, commonFunction.FORMAT_CURRENCY)
            txtDisc2Amt.Text = Format(oPrice.discount2amt, commonFunction.FORMAT_CURRENCY)
            txtDisc3Pct.Text = Format(oPrice.discount3pct, commonFunction.FORMAT_CURRENCY)
            txtDisc3Amt.Text = Format(oPrice.discount3amt, commonFunction.FORMAT_CURRENCY)
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("POrdNo", RadComboBoxPurchaseOrderID.Text.Trim, "PurchaseOrderHD").Rows.Count > 0 Then
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

    End Class
End Namespace