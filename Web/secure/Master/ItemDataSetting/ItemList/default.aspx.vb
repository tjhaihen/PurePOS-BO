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
Imports System.IO
Imports Microsoft.VisualBasic

Imports Telerik.Web.UI

Imports Raven
Imports Raven.Common
Imports Raven.BussinessRules
Imports Raven.SystemFramework

Namespace Raven.Web.Secure.Master.ItemDataSetting

    Public Class ItemList
        Inherits PageBase

#Region " Private Variables (web form designer generated code and user code) "

        Private ModuleId As String = "213"
        Protected WithEvents lblRecordEntryCaption As Label
        Protected WithEvents lblRecordListCaption As Label
        Protected WithEvents lblItemSeqNoCaption As Label
        Protected WithEvents lblItemIDCaption As Label
        Protected WithEvents lblItemNameCaption As Label
        Protected WithEvents lblItemStatusCaption As Label
        Protected WithEvents lblPrintNameCaption As Label
        Protected WithEvents lblBrandNameCaption As Label
        Protected WithEvents lblItemSizeCaption As Label
        Protected WithEvents lblItemCategoryCaption As Label
        Protected WithEvents lblItemSubCategoryCaption As Label
        Protected WithEvents lblItemLUnitCaption As Label
        Protected WithEvents lblItemSUnitCaption As Label
        Protected WithEvents lblItemFactorCaption As Label
        Protected WithEvents lblSalesPriceLUnitCaption As Label
        Protected WithEvents lblSalesPriceSUnitCaption As Label
        Protected WithEvents lblOfficeSalesPriceLUnitCaption As Label
        Protected WithEvents lblOfficeSalesPriceSUnitCaption As Label
        Protected WithEvents lblMarginPctCaption As Label
        Protected WithEvents lblMarginRangeCaption As Label
        Protected WithEvents lblManufacturerCaption As Label
        Protected WithEvents lblDistributorCaption As Label
        Protected WithEvents lblProducerCaption As Label
        Protected WithEvents lblCountryCaption As Label
        Protected WithEvents lblDescriptionCaption As Label
        Protected WithEvents lblUploadPhoto As Label
        Protected WithEvents lblRecordEntryList As Label
        Protected WithEvents lblItemSUnitStoS As Label
        Protected WithEvents lblItemSUnitMtoS As Label
        Protected WithEvents lblItemSUnitLtoS As Label
        Protected WithEvents lblItemCurrentSUnitID As Label
        Protected WithEvents lblItemCurrentMUnitID As Label
        Protected WithEvents lblItemCurrentLUnitID As Label

        Protected WithEvents txtLastPurchasePriceSUnit As TextBox
        Protected WithEvents txtSuggestedSalesPriceSUnit As TextBox
        Protected WithEvents txtUpDownPriceSUnit As TextBox
        Protected WithEvents lblUpDownPriceSUnitCaption As Label
        Protected WithEvents imgUpDownPriceSUnit As Image

        Protected WithEvents txtItemID As TextBox
        Protected WithEvents txtItemName As TextBox
        Protected WithEvents txtPrintName As TextBox
        Protected WithEvents txtItemSize As TextBox
        Protected WithEvents txtItemFactorStoS As TextBox
        Protected WithEvents txtItemFactorMtoS As TextBox
        Protected WithEvents txtItemFactorLtoS As TextBox
        Protected WithEvents txtSuggestedRetailPriceLUnit As TextBox
        Protected WithEvents txtSuggestedRetailPriceSUnit As TextBox
        Protected WithEvents txtSalesPriceLUnit As TextBox
        Protected WithEvents txtSalesPriceSUnit As TextBox
        Protected WithEvents txtOfficeSalesPriceLUnit As TextBox
        Protected WithEvents txtOfficeSalesPriceSUnit As TextBox
        Protected WithEvents txtMarginPct As TextBox
        Protected WithEvents txtDescription As TextBox
        Protected WithEvents txtLastNPurchase As TextBox
        Protected WithEvents txtLastNItemPrice As TextBox
        Protected WithEvents txtInActiveDescription As TextBox

        Protected WithEvents rdbIsFoodYes As RadioButton
        Protected WithEvents rdbIsFoodNo As RadioButton
        Protected WithEvents rdbIsFreshYes As RadioButton
        Protected WithEvents rdbIsFreshNo As RadioButton
        Protected WithEvents rdbIsHalalYes As RadioButton
        Protected WithEvents rdbIsHalalNo As RadioButton
        Protected WithEvents rdbIsLegalYes As RadioButton
        Protected WithEvents rdbIsLegalNo As RadioButton
        Protected WithEvents rdbIsImportYes As RadioButton
        Protected WithEvents rdbIsImportNo As RadioButton
        Protected WithEvents rdbIsHouseBrandYes As RadioButton
        Protected WithEvents rdbIsHouseBrandNo As RadioButton

        Protected WithEvents chkIsActive As CheckBox         

        Protected WithEvents RadComboBoxItemSeqNo As RadComboBox

        Protected WithEvents ddlItemStatus As DropDownList
        Protected WithEvents ddlBrandName As DropDownList
        Protected WithEvents ddlItemCategory As DropDownList
        Protected WithEvents ddlItemSubCategory As DropDownList
        Protected WithEvents ddlItemLUnit As DropDownList
        Protected WithEvents ddlItemMUnit As DropDownList
        Protected WithEvents ddlItemSUnit As DropDownList
        Protected WithEvents ddlMarginRange As DropDownList
        Protected WithEvents ddlManufacturer As DropDownList
        Protected WithEvents ddlDistributor As DropDownList
        Protected WithEvents ddlProducer As DropDownList
        Protected WithEvents ddlCountry As DropDownList

        Protected WithEvents RadGridItem As DataGrid
        Protected WithEvents RadGridLastNPurchase As DataGrid
        Protected WithEvents Toolbar As CSSToolbar

        Protected WithEvents lbtnUpload As LinkButton
        Protected WithEvents lbtnRemove As LinkButton
        Protected WithEvents txtItemPhotoSeqNo As TextBox
        Protected WithEvents lblItemPhotoSize As Label
        Protected WithEvents PhotoFile As System.Web.UI.HtmlControls.HtmlInputFile
        Protected WithEvents Image1 As Image
        Protected WithEvents Radtabstrip1 As RadTabStrip
        Protected WithEvents lblIsFoodCaption As Label
        Protected WithEvents lblIsLegalCaption As Label
        Protected WithEvents lblIsFreshCaption As Label
        Protected WithEvents lblIsImportCaption As Label
        Protected WithEvents lblIsHalalCaption As Label
        Protected WithEvents lblIsHouseBrandCaption As Label
        Protected WithEvents lblItemMUnitCaption As Label
        Protected WithEvents Radmultipage1 As RadMultiPage
        Protected WithEvents Radtabstrip4 As RadTabStrip
        Protected WithEvents Radmultipage4 As RadMultiPage
        Protected WithEvents Radtabstrip2 As RadTabStrip
        Protected WithEvents Radmultipage2 As RadMultiPage
        Protected WithEvents Radtabstrip3 As RadTabStrip
        Protected WithEvents Radmultipage3 As RadMultiPage
        Protected WithEvents Radtabstrip6 As RadTabStrip
        Protected WithEvents Radmultipage6 As RadMultiPage
        Protected WithEvents PhotoViewer As System.Web.UI.HtmlControls.HtmlImage

        Protected WithEvents txtSearchItemName As TextBox
        Protected WithEvents lbtnApplyFilter As LinkButton
        Protected WithEvents lbtnShowLastNPurchase As LinkButton

        Protected WithEvents RadStartingDate As RadDatePicker
        Protected WithEvents lbtnSaveItemPrice As LinkButton
        Protected WithEvents lbtnShowCurrentPrice As LinkButton
        Protected WithEvents lbtnShowLastPrice As LinkButton
        Protected WithEvents lbtnShowItemPriceList As LinkButton
        Protected WithEvents RadGridLastNItemPrice As DataGrid

        '// Alternate Item Unit
        Protected WithEvents lbtnSaveAltItemUnit As LinkButton
        Protected WithEvents ddlItemAlternateUnit As DropDownList
        Protected WithEvents txtItemFactorAlternatetoS As TextBox
        Protected WithEvents lblItemSUnitAlternatetoS As Label
        Protected WithEvents RadGridItemUnit As DataGrid

        '// Record Properties
        Protected WithEvents lblUserInsert As Label
        Protected WithEvents lblInsertDate As Label
        Protected WithEvents lblUserUpdate As Label
        Protected WithEvents lblUpdateDate As Label
#End Region

#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then 'And Not RadComboBoxItemSeqNo.IsCallBack Then

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

        Private Sub RadComboBoxItemSeqNo_ItemRequested(ByVal o As Object, ByVal e As RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxItemSeqNo.ItemsRequested
            Dim combo As RadComboBox = CType(o, RadComboBox)
            combo.Items.Clear()

            If Len(e.Text) >= 3 Then
                LoadItem(e.Text)
            End If
        End Sub

        Private Sub RadComboBoxItemSeqNo_ItemDataBound(ByVal o As Object, ByVal e As RadComboBoxItemEventArgs) Handles RadComboBoxItemSeqNo.ItemDataBound
            e.Item.Text = CType(e.Item.DataItem, DataRowView)("ItemSeqNo").ToString()
        End Sub

        Private Sub RadComboBoxItemSeqNo_SelectedIndexChanged(ByVal o As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxItemSeqNo.SelectedIndexChanged
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

        Private Sub ddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemCategory.SelectedIndexChanged, ddlItemSUnit.SelectedIndexChanged
            Select Case CType(sender, DropDownList).ID
                Case ddlItemCategory.ID
                    LoadItemSubCategoryComboBox(ddlItemCategory.SelectedItem.Value.Trim)

                Case ddlItemSUnit.ID
                    If ddlItemSUnit.SelectedIndex <> 0 Then
                        lblItemSUnitStoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                        lblItemSUnitMtoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                        lblItemSUnitLtoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                    Else
                        lblItemSUnitStoS.Text = String.Empty
                        lblItemSUnitMtoS.Text = String.Empty
                        lblItemSUnitLtoS.Text = String.Empty
                    End If

                    ddlItemMUnit.SelectedIndex = 0
                    ddlItemLUnit.SelectedIndex = 0
                    txtItemFactorMtoS.Text = "0"
                    txtItemFactorLtoS.Text = "0"
            End Select
        End Sub

        Private Sub rdb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbIsFoodYes.CheckedChanged, rdbIsFoodNo.CheckedChanged, _
            rdbIsFreshYes.CheckedChanged, rdbIsFreshNo.CheckedChanged, rdbIsHalalYes.CheckedChanged, rdbIsHalalNo.CheckedChanged, _
            rdbIsLegalYes.CheckedChanged, rdbIsLegalNo.CheckedChanged, rdbIsImportYes.CheckedChanged, rdbIsImportNo.CheckedChanged, _
            rdbIsHouseBrandYes.CheckedChanged, rdbIsHouseBrandNo.CheckedChanged
            Select Case CType(sender, RadioButton).ID
                Case rdbIsFoodYes.ID
                    rdbIsFoodYes.Checked = True
                    rdbIsFoodNo.Checked = Not rdbIsFoodYes.Checked

                Case rdbIsFoodNo.ID
                    rdbIsFoodYes.Checked = Not rdbIsFoodNo.Checked
                    rdbIsFoodNo.Checked = True

                Case rdbIsFreshYes.ID
                    rdbIsFreshYes.Checked = True
                    rdbIsFreshNo.Checked = Not rdbIsFreshYes.Checked

                Case rdbIsFreshNo.ID
                    rdbIsFreshYes.Checked = Not rdbIsFreshNo.Checked
                    rdbIsFreshNo.Checked = True

                Case rdbIsHalalYes.ID
                    rdbIsHalalYes.Checked = True
                    rdbIsHalalNo.Checked = Not rdbIsHalalYes.Checked

                Case rdbIsHalalNo.ID
                    rdbIsHalalYes.Checked = Not rdbIsHalalNo.Checked
                    rdbIsHalalNo.Checked = True

                Case rdbIsLegalYes.ID
                    rdbIsLegalYes.Checked = True
                    rdbIsLegalNo.Checked = Not rdbIsLegalYes.Checked

                Case rdbIsLegalNo.ID
                    rdbIsLegalYes.Checked = Not rdbIsLegalNo.Checked
                    rdbIsLegalNo.Checked = True

                Case rdbIsImportYes.ID
                    rdbIsImportYes.Checked = True
                    rdbIsImportNo.Checked = Not rdbIsImportYes.Checked

                Case rdbIsImportNo.ID
                    rdbIsImportYes.Checked = Not rdbIsImportNo.Checked
                    rdbIsImportNo.Checked = True

                Case rdbIsHouseBrandYes.ID
                    rdbIsHouseBrandYes.Checked = True
                    rdbIsHouseBrandNo.Checked = Not rdbIsHouseBrandYes.Checked

                Case rdbIsHouseBrandNo.ID
                    rdbIsHouseBrandYes.Checked = Not rdbIsHouseBrandNo.Checked
                    rdbIsHouseBrandNo.Checked = True
            End Select
        End Sub

        Private Sub lbtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnApplyFilter.Click, lbtnShowLastNPurchase.Click, _
            lbtnSaveItemPrice.Click, lbtnShowCurrentPrice.Click, lbtnShowLastPrice.Click, lbtnShowItemPriceList.Click, lbtnSaveAltItemUnit.Click
            Select Case CType(sender, LinkButton).ID
                Case lbtnApplyFilter.ID
                    UpdateViewGridItem(txtSearchItemName.Text.Trim.Replace("*", "%"))

                Case lbtnShowLastNPurchase.ID
                    '// Validate the Last n input
                    If IsNumeric(txtLastNPurchase.Text.Trim) = False Then
                        commonFunction.MsgBox(Me, "The last 'n' must be in numeric.")
                        commonFunction.Focus(Me, txtLastNPurchase.ClientID)
                        Exit Sub
                    End If

                    If CDec(txtLastNPurchase.Text.Trim) > 10 Then
                        txtLastNPurchase.Text = "10"
                    End If

                    If CDec(txtLastNPurchase.Text.Trim) <= 0 Then
                        txtLastNPurchase.Text = "3"
                    End If

                    UpdateViewGridLastNPurchase(txtLastNPurchase.Text.Trim)

                Case lbtnSaveItemPrice.ID
                    _SaveItemPrice()

                Case lbtnShowCurrentPrice.ID
                    _OpenItemPrice(True)

                Case lbtnShowLastPrice.ID
                    _OpenItemPrice(False)

                Case lbtnShowItemPriceList.ID
                    '// Validate the Last n input
                    If IsNumeric(txtLastNItemPrice.Text.Trim) = False Then
                        commonFunction.MsgBox(Me, "The last 'n' must be in numeric.")
                        commonFunction.Focus(Me, txtLastNItemPrice.ClientID)
                        Exit Sub
                    End If

                    If CDec(txtLastNItemPrice.Text.Trim) > 10 Then
                        txtLastNItemPrice.Text = "10"
                    End If

                    If CDec(txtLastNItemPrice.Text.Trim) <= 0 Then
                        txtLastNItemPrice.Text = "3"
                    End If

                    UpdateViewGridLastNItemPrice(txtLastNItemPrice.Text.Trim)

                Case lbtnSaveAltItemUnit.ID
                    _SaveAlternateItemUnit()

            End Select
        End Sub

        Private Sub txt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMarginPct.TextChanged, txtSalesPriceSUnit.TextChanged
            Select Case CType(sender, TextBox).ID
                Case txtMarginPct.ID
                    If IsNumeric(txtMarginPct.Text.Trim) = False Or Len(txtMarginPct.Text.Trim) = 0 Then
                        txtMarginPct.Text = "0.00"
                    End If

                    txtSuggestedSalesPriceSUnit.Text = Format(CDec(txtLastPurchasePriceSUnit.Text.Trim) + (CDec(txtLastPurchasePriceSUnit.Text.Trim) * (CDec(txtMarginPct.Text.Trim) / 100)), commonFunction.FORMAT_CURRENCY).Trim

                    If CDec(txtSuggestedSalesPriceSUnit.Text) = 0 Or Len(txtSuggestedSalesPriceSUnit.Text.Trim) = 0 Then
                        txtSuggestedSalesPriceSUnit.Text = txtSalesPriceSUnit.Text
                    Else
                        '// calculate up/down
                        txtUpDownPriceSUnit.Text = Format(CDec(txtSalesPriceSUnit.Text.Trim) - CDec(txtSuggestedSalesPriceSUnit.Text.Trim), commonFunction.FORMAT_CURRENCY).Trim
                        Select Case CDec(txtUpDownPriceSUnit.Text.Trim)
                            Case 0
                                '// No difference
                                lblUpDownPriceSUnitCaption.Visible = False
                                imgUpDownPriceSUnit.Visible = False
                                imgUpDownPriceSUnit.ImageUrl = ""
                            Case Is < 0
                                '// down
                                lblUpDownPriceSUnitCaption.Visible = True
                                imgUpDownPriceSUnit.Visible = True
                                imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/down.png"
                            Case Is > 0
                                '// up
                                lblUpDownPriceSUnitCaption.Visible = True
                                imgUpDownPriceSUnit.Visible = True
                                imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/up.png"
                        End Select
                    End If

                Case txtSalesPriceSUnit.ID
                    If IsNumeric(txtSalesPriceSUnit.Text.Trim) = False Or Len(txtSalesPriceSUnit.Text.Trim) = 0 Then
                        txtSalesPriceSUnit.Text = "0.00"
                    End If

                    If CDec(txtLastPurchasePriceSUnit.Text.Trim) = 0 Then
                        txtMarginPct.Text = Format(100, commonFunction.FORMAT_CURRENCY).Trim
                    Else
                        txtMarginPct.Text = Format(((CDec(txtSalesPriceSUnit.Text.Trim) - CDec(txtLastPurchasePriceSUnit.Text.Trim)) / CDec(txtLastPurchasePriceSUnit.Text.Trim) * 100), commonFunction.FORMAT_CURRENCY).Trim
                    End If

                    '// calculate up/down
                    txtUpDownPriceSUnit.Text = Format(CDec(txtSalesPriceSUnit.Text.Trim) - CDec(txtSuggestedSalesPriceSUnit.Text.Trim), commonFunction.FORMAT_CURRENCY).Trim
                    Select Case CDec(txtUpDownPriceSUnit.Text.Trim)
                        Case 0
                            '// No difference
                            lblUpDownPriceSUnitCaption.Visible = False
                            imgUpDownPriceSUnit.Visible = False
                            imgUpDownPriceSUnit.ImageUrl = ""
                        Case Is < 0
                            '// down
                            lblUpDownPriceSUnitCaption.Visible = True
                            imgUpDownPriceSUnit.Visible = True
                            imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/down.png"
                        Case Is > 0
                            '// up
                            lblUpDownPriceSUnitCaption.Visible = True
                            imgUpDownPriceSUnit.Visible = True
                            imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/up.png"
                    End Select
            End Select
        End Sub

#Region " Item Photo "
        Private Sub lbtnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnUpload.Click
            Dim strFileName As String
            Dim strFilePath As String
            Dim strFolder As String

            strFolder = Server.MapPath("ImgTmp") + "\"

            strFileName = PhotoFile.PostedFile.FileName
            strFileName = Path.GetFileName(strFileName)

            If (Not Directory.Exists(strFolder)) Then
                Directory.CreateDirectory(strFolder)
            End If

            'Save the uploaded file to the server.
            strFilePath = strFolder & RadComboBoxItemSeqNo.Text.Trim & strFileName
            If File.Exists(strFilePath) Then
                File.Delete(strFilePath)
            Else
                PhotoFile.PostedFile.SaveAs(strFilePath)
            End If

            Dim fs As New FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Read)
            Dim b(CInt(fs.Length)) As Byte
            fs.Read(b, 0, CInt(fs.Length))
            fs.Close()

            Dim br As New BussinessRules.ItemPhoto
            Dim fNotNew As Boolean = False

            With br
                .ItemPhotoSeqNo = txtItemPhotoSeqNo.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    fNotNew = True
                Else
                    .ItemPhotoSeqNo = BussinessRules.ID.GenerateIDNumber("ItemPhoto", "ItemPhotoSeqNo")
                End If
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                .ItemPhoto = New SqlBinary(b)
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNotNew Then
                    .Update()
                Else
                    .Insert()
                End If
                txtItemPhotoSeqNo.Text = .ItemPhotoSeqNo.Trim
            End With
            br.Dispose()
            br = Nothing

            File.Delete(strFilePath)
        End Sub

        Private Sub lbtnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnRemove.Click
            Dim br As New BussinessRules.ItemPhoto

            With br
                .ItemPhotoSeqNo = txtItemPhotoSeqNo.Text.Trim
                If .SelectOne.Rows.Count > 0 Then
                    .Delete()
                Else
                    commonFunction.MsgBox(Me, "File does not exist.")
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _OpenItemPhotoByItemSeqNo(ByVal ItemSeqNo As String)
            If Len(ItemSeqNo.Trim) = 0 Then Exit Sub

            Dim br As New BussinessRules.ItemPhoto

            With br
                .ItemSeqNo = ItemSeqNo.Trim
                If .SelectByItemSeqNo.Rows.Count > 0 Then
                    txtItemPhotoSeqNo.Text = .ItemPhotoSeqNo.Trim
                Else
                    txtItemPhotoSeqNo.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

#End Region

#Region " DataGrid Command Center "
        Private Sub RadGridItem_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles RadGridItem.ItemCommand
            Select Case e.CommandName
                Case "Select"
                    Dim _lblItemSeqNo As Label = CType(e.Item.FindControl("_lblItemSeqNo"), Label)

                    RadComboBoxItemSeqNo.Text = _lblItemSeqNo.Text.Trim
                    _Open(RavenRecStatus.CurrentRecord)
            End Select
        End Sub
#End Region

#Region " Main Function (CRUD) "

        Private Sub _Open(ByVal recStatus As BussinessRules.RavenRecStatus)
            If Len(RadComboBoxItemSeqNo.Text.Trim) = 0 Then
                PrepareScreen()
                Exit Sub
            End If

            Dim br As New BussinessRules.Item

            With br
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                If .SelectOne(recStatus).Rows.Count > 0 Then
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        RadComboBoxItemSeqNo.Text = .ItemID.Trim
                    End If
                    txtItemID.Text = .ItemID.Trim
                    txtItemName.Text = .ItemName.Trim
                    commonFunction.SelectListItem(ddlItemStatus, .ItemStatusID.Trim)
                    txtPrintName.Text = .PrintName.Trim
                    commonFunction.SelectListItem(ddlBrandName, .BrandNameID.Trim)
                    txtItemSize.Text = .ItemSize.Trim
                    commonFunction.SelectListItem(ddlItemCategory, .ItemCategoryID.Trim)
                    commonFunction.SelectListItem(ddlItemSubCategory, .ItemSubCategoryID.Trim)
                    commonFunction.SelectListItem(ddlManufacturer, .ManufacturerID.Trim)
                    commonFunction.SelectListItem(ddlProducer, .ProducerID.Trim)
                    commonFunction.SelectListItem(ddlDistributor, .DistributorID.Trim)
                    commonFunction.SelectListItem(ddlCountry, .CountryID.Trim)
                    rdbIsFoodYes.Checked = .IsFood
                    rdbIsFoodNo.Checked = Not .IsFood
                    rdbIsFreshYes.Checked = .IsFresh
                    rdbIsFreshNo.Checked = Not .IsFresh
                    rdbIsHalalYes.Checked = .IsHalal
                    rdbIsHalalNo.Checked = Not .IsHalal
                    rdbIsLegalYes.Checked = .IsLegal
                    rdbIsLegalNo.Checked = Not .IsLegal
                    rdbIsImportYes.Checked = .IsImport
                    rdbIsImportNo.Checked = Not .IsImport
                    rdbIsHouseBrandYes.Checked = .IsHouseBrand
                    rdbIsHouseBrandNo.Checked = Not .IsHouseBrand
                    commonFunction.SelectListItem(ddlItemSUnit, .ItemSUnitID.Trim)
                    commonFunction.SelectListItem(ddlItemMUnit, .ItemMUnitID.Trim)
                    commonFunction.SelectListItem(ddlItemLUnit, .ItemLUnitID.Trim)
                    '// untuk display keterangan satuan
                    If ddlItemSUnit.SelectedIndex <> 0 Then
                        lblItemSUnitStoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                        lblItemSUnitMtoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                        lblItemSUnitLtoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                        lblItemSUnitAlternatetoS.Text = ddlItemSUnit.SelectedItem.Text.Trim
                    Else
                        lblItemSUnitStoS.Text = String.Empty
                        lblItemSUnitMtoS.Text = String.Empty
                        lblItemSUnitLtoS.Text = String.Empty
                        lblItemSUnitAlternatetoS.Text = String.Empty
                    End If
                    '// untuk current unit
                    lblItemCurrentSUnitID.Text = .ItemSUnitID.Trim
                    lblItemCurrentMUnitID.Text = .ItemMUnitID.Trim
                    lblItemCurrentLUnitID.Text = .ItemLUnitID.Trim
                    '// untuk item factor
                    txtItemFactorStoS.Text = "1"
                    txtItemFactorMtoS.Text = .ItemMUnitFactor.ToString.Trim
                    txtItemFactorLtoS.Text = .ItemLUnitFactor.ToString.Trim
                    txtItemFactorAlternatetoS.Text = "0"

                    '// harus ambil dari ItemPrice
                    _OpenItemPrice(True)

                    commonFunction.SelectListItem(ddlMarginRange, .MarginRangeID.Trim)
                    txtDescription.Text = .Description.Trim
                    chkIsActive.Checked = .IsActive
                    txtInActiveDescription.Text = .InActiveDescription.Trim

                    '// untuk photo
                    _OpenItemPhotoByItemSeqNo(RadComboBoxItemSeqNo.Text.Trim)
                    PhotoFile.Disabled = False
                    lbtnUpload.Enabled = True
                    lbtnRemove.Enabled = True

                    lbtnSaveItemPrice.Enabled = True
                    lbtnSaveAltItemUnit.Enabled = True
                Else
                    If Not recStatus = RavenRecStatus.CurrentRecord Then
                        GoTo GoNext
                    End If
                    txtItemName.Text = String.Empty
                    ddlItemStatus.SelectedIndex = 0
                    txtPrintName.Text = String.Empty
                    ddlBrandName.SelectedIndex = 0
                    txtItemSize.Text = String.Empty
                    ddlItemCategory.SelectedIndex = 0
                    ddlItemSubCategory.SelectedIndex = 0
                    ddlManufacturer.SelectedIndex = 0
                    ddlProducer.SelectedIndex = 0
                    ddlDistributor.SelectedIndex = 0
                    ddlCountry.SelectedIndex = 0
                    rdbIsFoodYes.Checked = False
                    rdbIsFoodNo.Checked = False
                    rdbIsFreshYes.Checked = False
                    rdbIsFreshNo.Checked = False
                    rdbIsHalalYes.Checked = False
                    rdbIsHalalNo.Checked = False
                    rdbIsLegalYes.Checked = True
                    rdbIsLegalNo.Checked = False
                    rdbIsImportYes.Checked = False
                    rdbIsImportNo.Checked = False
                    rdbIsHouseBrandYes.Checked = False
                    rdbIsHouseBrandNo.Checked = True
                    ddlItemSUnit.SelectedIndex = 0
                    ddlItemMUnit.SelectedIndex = 0
                    ddlItemLUnit.SelectedIndex = 0
                    ddlItemAlternateUnit.SelectedIndex = 0
                    '// untuk current unit
                    lblItemCurrentSUnitID.Text = String.Empty
                    lblItemCurrentMUnitID.Text = String.Empty
                    lblItemCurrentLUnitID.Text = String.Empty
                    '// untuk item factor
                    txtItemFactorStoS.Text = "1"
                    txtItemFactorMtoS.Text = "0"
                    txtItemFactorLtoS.Text = "0"
                    txtItemFactorAlternatetoS.Text = "0"

                    RadStartingDate.SelectedDate = Date.Today
                    txtSuggestedRetailPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSuggestedRetailPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtMarginPct.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim

                    ddlMarginRange.SelectedIndex = 0
                    txtDescription.Text = String.Empty
                    chkIsActive.Checked = True
                    txtInActiveDescription.Text = String.Empty

                    '// photo
                    txtItemPhotoSeqNo.Text = String.Empty
                    PhotoFile.Disabled = True
                    lbtnUpload.Enabled = False
                    lbtnRemove.Enabled = False

                    lbtnSaveItemPrice.Enabled = False
                    lbtnSaveAltItemUnit.Enabled = False
                End If
            End With

GoNext:
            br.Dispose()
            br = Nothing

            GetRecordProperties()
            UpdateViewGridItemUnit()
            UpdateViewGridLastNPurchase()
            GetSuggestedSalesPriceSUnit()
            commonFunction.Focus(Me, txtItemID.ClientID)
        End Sub

        Private Sub _Save()
            If Len(txtItemID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item ID cannot empty.")
                commonFunction.Focus(Me, txtItemID.ClientID)
                Exit Sub
            End If

            If Len(txtItemName.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Item Name cannot empty.")
                commonFunction.Focus(Me, txtItemName.ClientID)
                Exit Sub
            End If

            If ddlBrandName.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Brand Name cannot empty.")
                commonFunction.Focus(Me, ddlBrandName.ClientID)
                Exit Sub
            End If

            If ddlItemCategory.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Item Category cannot empty.")
                commonFunction.Focus(Me, ddlItemCategory.ClientID)
                Exit Sub
            End If

            If ddlItemSUnit.SelectedIndex = 0 Then
                commonFunction.MsgBox(Me, "Smallest Unit (Pcs/Kg) cannot empty.")
                commonFunction.Focus(Me, ddlItemSUnit.ClientID)
                Exit Sub
            End If

            If chkIsActive.Checked = False Then
                If txtInActiveDescription.Text.Trim.Length = 0 Then
                    commonFunction.MsgBox(Me, "Inactive Description cannot empty.")
                    commonFunction.Focus(Me, txtInActiveDescription.ClientID)
                    Exit Sub
                End If
            End If

            Dim br As New BussinessRules.Item
            Dim fNew As Boolean = True

            With br
                .ItemID = txtItemID.Text.Trim
                Dim dv As New DataView(br.SelectOneByItemID)
                dv.RowFilter = "ItemSeqNo <> '" + RadComboBoxItemSeqNo.Text.Trim + "'"
                If dv.Count > 0 Then
                    commonFunction.MsgBox(Me, "Item ID already exist.")
                    _Open(RavenRecStatus.CurrentRecord)
                    commonFunction.Focus(Me, txtItemID.ClientID)
                    Exit Sub
                End If
                dv.Dispose()
                dv = Nothing

                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                If .SelectOne(RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                    fNew = False
                Else
                    .ItemSeqNo = BussinessRules.ID.GenerateIDNumber("Item", "ItemSeqNo")
                End If

                '// set the value
                .ItemID = txtItemID.Text.Trim
                .ItemName = txtItemName.Text.Trim
                .ItemStatusID = ddlItemStatus.SelectedItem.Value.Trim
                If Len(txtPrintName.Text.Trim) > 0 Then
                    .PrintName = txtPrintName.Text.Trim
                Else
                    '// set Print Name = Item Name if Print Name is empty
                    .PrintName = txtItemName.Text.Trim
                End If
                .BrandNameID = ddlBrandName.SelectedItem.Value.Trim
                .ItemCategoryID = ddlItemCategory.SelectedItem.Value.Trim
                .ItemSubCategoryID = ddlItemSubCategory.SelectedItem.Value.Trim
                .ItemSize = txtItemSize.Text.Trim
                .Description = Left(txtDescription.Text.Trim, 500).Trim
                .IsFood = rdbIsFoodYes.Checked
                .IsFresh = rdbIsFreshYes.Checked
                .IsHalal = rdbIsHalalYes.Checked
                .IsLegal = rdbIsLegalYes.Checked
                .IsImport = rdbIsImportYes.Checked
                .IsHouseBrand = rdbIsHouseBrandYes.Checked
                .ItemSUnitID = ddlItemSUnit.SelectedItem.Value.Trim
                .ItemMUnitID = ddlItemMUnit.SelectedItem.Value.Trim
                .ItemLUnitID = ddlItemLUnit.SelectedItem.Value.Trim
                '// untuk current Item Unit
                .ItemCurrentSUnitID = lblItemCurrentSUnitID.Text.Trim
                .ItemCurrentMUnitID = lblItemCurrentMUnitID.Text.Trim
                .ItemCurrentLUnitID = lblItemCurrentLUnitID.Text.Trim

                '// untuk Item Factor
                .ItemMUnitFactor = CDec(txtItemFactorMtoS.Text.Trim)
                .ItemLUnitFactor = CDec(txtItemFactorLtoS.Text.Trim)

                '.SalesPriceSUnit = CDec(txtSalesPriceSUnit.Text.Trim)
                '.SalesPriceLUnit = CDec(txtSalesPriceLUnit.Text.Trim)
                '.SalesPriceBS = CDec(txtOfficeSalesPriceLUnit.Text.Trim)
                '.MarginPct = CDec(txtMarginPct.Text.Trim)

                .MarginRangeID = ddlMarginRange.SelectedItem.Value.Trim
                .ManufacturerID = ddlManufacturer.SelectedItem.Value.Trim
                .ProducerID = ddlProducer.SelectedItem.Value.Trim
                .DistributorID = ddlDistributor.SelectedItem.Value.Trim
                .CountryID = ddlCountry.SelectedItem.Value.Trim
                .IsActive = chkIsActive.Checked
                .UserInsert = MyBase.LoggedOnUserID.Trim
                .UserUpdate = MyBase.LoggedOnUserID.Trim
                .InActiveDescription = txtInActiveDescription.Text.Trim

                If fNew Then
                    If .Insert() Then
                        RadComboBoxItemSeqNo.Text = .ItemSeqNo.Trim
                        _Open(RavenRecStatus.CurrentRecord)
                    End If
                Else
                    If .Update() Then
                        _Open(RavenRecStatus.CurrentRecord)
                        'UpdateViewGridItem()
                    End If
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _Delete()
            If Len(RadComboBoxItemSeqNo.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Nothing to delete.")
                Exit Sub
            End If

            Dim br As New BussinessRules.Item

            With br
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
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

            commonFunction.Focus(Me, txtItemID.ClientID)
        End Sub

        Private Sub _OpenItemPrice(ByVal IsShowCurrentItemPrice As Boolean)
            Dim br As New BussinessRules.ItemPrice
            With br
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                .StartingDate = Date.Today
                If .SelectOneByStartingDate(IsShowCurrentItemPrice).Rows.Count > 0 Then
                    RadStartingDate.SelectedDate = .StartingDate
                    txtSuggestedRetailPriceLUnit.Text = Format(.SuggestedRetailPriceLUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtSuggestedRetailPriceSUnit.Text = Format(.SuggestedRetailPriceSUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceLUnit.Text = Format(.SalesPriceLUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceSUnit.Text = Format(.SalesPriceSUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceLUnit.Text = Format(.OfficeSalesPriceLUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceSUnit.Text = Format(.OfficeSalesPriceSUnit, commonFunction.FORMAT_CURRENCY).Trim
                    txtMarginPct.Text = Format(.MarginPct, commonFunction.FORMAT_CURRENCY).Trim
                Else
                    RadStartingDate.SelectedDate = Date.Today
                    txtSuggestedRetailPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSuggestedRetailPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtOfficeSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                    txtMarginPct.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _SaveItemPrice()
            '// Validations
            If IsNumeric(txtSuggestedRetailPriceLUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Suggested Retail Price L Unit must be numeric")
                commonFunction.Focus(Me, txtSuggestedRetailPriceLUnit.ClientID)
                txtSuggestedRetailPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtSuggestedRetailPriceSUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Suggested Retail Price S Unit must be numeric")
                commonFunction.Focus(Me, txtSuggestedRetailPriceSUnit.ClientID)
                txtSuggestedRetailPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtSalesPriceLUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Sales Price L Unit must be numeric")
                commonFunction.Focus(Me, txtSalesPriceLUnit.ClientID)
                txtSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtSalesPriceSUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Sales Price S Unit must be numeric")
                commonFunction.Focus(Me, txtSalesPriceSUnit.ClientID)
                txtSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtOfficeSalesPriceLUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Office Sales Price L Unit must be numeric")
                commonFunction.Focus(Me, txtOfficeSalesPriceLUnit.ClientID)
                txtOfficeSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtOfficeSalesPriceSUnit.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Office Sales Price S Unit must be numeric")
                commonFunction.Focus(Me, txtOfficeSalesPriceSUnit.ClientID)
                txtOfficeSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If IsNumeric(txtMarginPct.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Margin Percent must be numeric")
                commonFunction.Focus(Me, txtMarginPct.ClientID)
                txtMarginPct.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtSuggestedRetailPriceLUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Suggested Retail Price L Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtSuggestedRetailPriceLUnit.ClientID)
                txtSuggestedRetailPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtSuggestedRetailPriceSUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Suggested Retail Price S Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtSuggestedRetailPriceSUnit.ClientID)
                txtSuggestedRetailPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtSalesPriceLUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Sales Price L Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtSalesPriceLUnit.ClientID)
                txtSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtSalesPriceSUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Sales Price S Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtSalesPriceSUnit.ClientID)
                txtSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtOfficeSalesPriceLUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Office Sales Price L Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtOfficeSalesPriceLUnit.ClientID)
                txtOfficeSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtOfficeSalesPriceSUnit.Text.Trim) < 0 Then
                commonFunction.MsgBox(Me, "Office Sales Price S Unit must be equal or greater than 0")
                commonFunction.Focus(Me, txtOfficeSalesPriceSUnit.ClientID)
                txtOfficeSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If RadStartingDate.SelectedDate.Value < Date.Today Then
                commonFunction.MsgBox(Me, "Starting Date must be equal or greater than today.")
                Exit Sub
            End If

            '// Save
            Dim fNew As Boolean = True
            Dim br As New BussinessRules.ItemPrice
            With br
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                .StartingDate = RadStartingDate.SelectedDate.Value
                If .SelectOne().Rows.Count > 0 Then
                    fNew = False
                Else
                    fNew = True
                End If

                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                .StartingDate = RadStartingDate.SelectedDate.Value
                .SuggestedRetailPriceLUnit = CDec(txtSuggestedRetailPriceLUnit.Text.Trim)
                .SuggestedRetailPriceSUnit = CDec(txtSuggestedRetailPriceSUnit.Text.Trim)
                .SalesPriceLUnit = CDec(txtSalesPriceLUnit.Text.Trim)
                .SalesPriceSUnit = CDec(txtSalesPriceSUnit.Text.Trim)
                .OfficeSalesPriceLUnit = CDec(txtOfficeSalesPriceLUnit.Text.Trim)
                .OfficeSalesPriceSUnit = CDec(txtOfficeSalesPriceSUnit.Text.Trim)
                .MarginPct = CDec(txtMarginPct.Text.Trim)
                .UserUpdate = MyBase.LoggedOnUserID.Trim

                If fNew Then
                    .Insert()
                Else
                    .Update()
                End If
            End With
            br.Dispose()
            br = Nothing
        End Sub

        Private Sub _SaveAlternateItemUnit()
            '// Validations
            If Len(lblItemCurrentSUnitID.Text.Trim) = 0 Then
                commonFunction.MsgBox(Me, "Alternate Unit can only be defined if the item already have Smallest Unit. Please define Smallest Unit first.")
                Exit Sub
            End If

            If IsNumeric(txtItemFactorAlternatetoS.Text.Trim) = False Then
                commonFunction.MsgBox(Me, "Alternate Unit Factor must be numeric.")
                commonFunction.Focus(Me, txtItemFactorAlternatetoS.ClientID)
                txtItemFactorAlternatetoS.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If CDec(txtItemFactorAlternatetoS.Text.Trim) <= 1 Then
                commonFunction.MsgBox(Me, "Alternate Unit Factor must be greater than 1.")
                commonFunction.Focus(Me, txtItemFactorAlternatetoS.ClientID)
                txtItemFactorAlternatetoS.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
                Exit Sub
            End If

            If ddlItemAlternateUnit.SelectedItem.Value.Trim = ddlItemSUnit.SelectedItem.Value.Trim Then
                commonFunction.MsgBox(Me, "Alternate Unit must be different from Smallest Unit.")
                Exit Sub
            End If

            '// Save
            Dim fNew As Boolean = True
            Dim br As New BussinessRules.ItemFactorTemplate
            With br
                .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                .ItemUnitID = ddlItemAlternateUnit.SelectedItem.Value.Trim
                .ItemFactor = CDec(txtItemFactorAlternatetoS.Text.Trim)
                If .SelectOne.Rows.Count > 0 Then
                    .ItemFactor = CDec(txtItemFactorAlternatetoS.Text.Trim)
                    If .SelectOneByPrimary().Rows.Count > 0 Then
                        fNew = False
                    Else
                        fNew = True
                    End If

                    .ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
                    .ItemUnitID = ddlItemAlternateUnit.SelectedItem.Value.Trim
                    .ItemFactor = CDec(txtItemFactorAlternatetoS.Text.Trim)
                    .UserInsert = MyBase.LoggedOnUserID.Trim
                    .UserUpdate = MyBase.LoggedOnUserID.Trim

                    If fNew Then
                        If .Insert() Then
                            PrepareScreenAlternateItemUnit()
                        End If
                    Else
                        If .Update() Then
                            PrepareScreenAlternateItemUnit()
                        End If
                    End If
                Else
                    br.Dispose()
                    br = Nothing
                    commonFunction.MsgBox(Me, "Alternate Unit must be the same as Smallest or Largest Unit.")
                    commonFunction.Focus(Me, ddlItemAlternateUnit.ClientID)
                    Exit Sub
                End If
            End With
            br.Dispose()
            br = Nothing
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
            RadComboBoxItemSeqNo.Text = String.Empty
            txtItemID.Text = String.Empty
            txtItemName.Text = String.Empty
            ddlItemStatus.SelectedIndex = 0
            txtPrintName.Text = String.Empty
            ddlBrandName.SelectedIndex = 0
            txtItemSize.Text = String.Empty
            ddlItemCategory.SelectedIndex = 0
            ddlItemSubCategory.SelectedIndex = 0
            rdbIsFoodYes.Checked = False
            rdbIsFoodNo.Checked = False
            rdbIsFreshYes.Checked = False
            rdbIsFreshNo.Checked = False
            rdbIsHalalYes.Checked = False
            rdbIsHalalNo.Checked = False
            rdbIsLegalYes.Checked = True
            rdbIsLegalNo.Checked = False
            rdbIsImportYes.Checked = False
            rdbIsImportNo.Checked = False
            rdbIsHouseBrandYes.Checked = False
            rdbIsHouseBrandNo.Checked = True
            ddlManufacturer.SelectedIndex = 0
            ddlProducer.SelectedIndex = 0
            ddlDistributor.SelectedIndex = 0
            ddlCountry.SelectedIndex = 0
            ddlItemSUnit.SelectedIndex = 0
            ddlItemMUnit.SelectedIndex = 0
            ddlItemLUnit.SelectedIndex = 0
            lblItemCurrentSUnitID.Text = String.Empty
            lblItemCurrentMUnitID.Text = String.Empty
            lblItemCurrentLUnitID.Text = String.Empty
            txtItemFactorStoS.Text = "1"
            txtItemFactorMtoS.Text = "0"
            txtItemFactorLtoS.Text = "0"
            lblItemSUnitStoS.Text = String.Empty
            lblItemSUnitMtoS.Text = String.Empty
            lblItemSUnitLtoS.Text = String.Empty

            RadStartingDate.SelectedDate = Date.Today
            txtSuggestedRetailPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtSuggestedRetailPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtOfficeSalesPriceLUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtOfficeSalesPriceSUnit.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            txtMarginPct.Text = Format(0, commonFunction.FORMAT_CURRENCY).Trim
            ddlMarginRange.SelectedIndex = 0
            lbtnSaveItemPrice.Enabled = False

            txtDescription.Text = String.Empty
            chkIsActive.Checked = True
            txtInActiveDescription.Text = String.Empty

            txtLastPurchasePriceSUnit.Text = "0.00"
            txtSuggestedSalesPriceSUnit.Text = "0.00"
            txtUpDownPriceSUnit.Text = "0.00"
            lblUpDownPriceSUnitCaption.Visible = False
            imgUpDownPriceSUnit.Visible = False
            imgUpDownPriceSUnit.ImageUrl = ""

            '//photo
            PhotoFile.Disabled = True
            lbtnUpload.Enabled = False
            lbtnRemove.Enabled = False
            txtItemPhotoSeqNo.Text = String.Empty

            LoadComboBoxes()
            LoadItemSubCategoryComboBox(String.Empty)

            txtSearchItemName.Text = "*"
            UpdateViewGridItem(String.Empty)

            txtLastNPurchase.Text = "3"
            UpdateViewGridLastNPurchase(txtLastNPurchase.Text.Trim)

            txtLastNItemPrice.Text = "3"
            UpdateViewGridLastNItemPrice(txtLastNItemPrice.Text.Trim)

            PrepareScreenAlternateItemUnit()
            lbtnSaveAltItemUnit.Enabled = False

            GetRecordProperties()

            commonFunction.Focus(Me, txtItemID.ClientID)
        End Sub

        Private Sub PrepareScreenAlternateItemUnit()
            lblItemSUnitAlternatetoS.Text = String.Empty
            ddlItemAlternateUnit.SelectedIndex = 0
            txtItemFactorAlternatetoS.Text = "0"
            UpdateViewGridItemUnit()
        End Sub

        Private Sub LoadItem(ByVal Filter As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectAll

            Dim dv As DataView = dt.DefaultView

            dv.RowFilter = "ItemID LIKE '%" + Filter.Trim + "%' OR ItemName LIKE '%" + Filter.Trim + "%'"

            RadComboBoxItemSeqNo.DataSource = dv
            RadComboBoxItemSeqNo.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub LoadComboBoxes()
            '//Item Status
            commonFunction.LoadDDLCommonSetting("ItemStatus", ddlItemStatus)

            '//Brand Name
            commonFunction.LoadDDLCommonSetting("BrandName", ddlBrandName)

            '//Manufacturer, Producer, and Distributor
            commonFunction.LoadDDLEntitesByEntitiesTypeID(ddlManufacturer, "02")
            commonFunction.LoadDDLEntitesByEntitiesTypeID(ddlProducer, "03")
            commonFunction.LoadDDLEntitesByEntitiesTypeID(ddlDistributor, "01")

            '//Country
            commonFunction.LoadDDLCommonSetting("Country", ddlCountry)

            '//ItemSUnit, ItemMUnit, ItemLUnit, dan AlternateUnit
            commonFunction.LoadDDLItemUnit(ddlItemSUnit)
            commonFunction.LoadDDLItemUnit(ddlItemMUnit)
            commonFunction.LoadDDLItemUnit(ddlItemLUnit)
            commonFunction.LoadDDLItemUnit(ddlItemAlternateUnit)

            '//ItemCategory
            ddlItemCategory.Items.Clear()

            Dim oItemCategory As New BussinessRules.ItemCategory
            Dim dtItemCategory As New DataTable

            With oItemCategory
                dtItemCategory = .SelectAllActive

                ddlItemCategory.Items.Add(New ListItem("- select record -", "none"))

                For Each row As DataRow In dtItemCategory.Rows
                    ddlItemCategory.Items.Add(New ListItem(CType(row("ItemCategoryName"), String), CType(row("ItemCategoryID"), String)))
                Next

                If dtItemCategory.Rows.Count = 1 Then
                    ddlItemCategory.SelectedIndex = 1
                End If
            End With

            oItemCategory.Dispose()
            oItemCategory = Nothing

            '//Margin Range
            ddlMarginRange.Items.Clear()

            Dim oMarginRange As New BussinessRules.MarginRangeHd
            Dim dtMarginRange As New DataTable

            With oMarginRange
                dtMarginRange = .SelectAllActive

                ddlMarginRange.Items.Add(New ListItem("- select record -", "none"))

                For Each row As DataRow In dtMarginRange.Rows
                    ddlMarginRange.Items.Add(New ListItem(CType(row("MarginRangeName"), String), CType(row("MarginRangeID"), String)))
                Next

                If dtMarginRange.Rows.Count = 1 Then
                    ddlMarginRange.SelectedIndex = 1
                End If
            End With

            oMarginRange.Dispose()
            oMarginRange = Nothing
        End Sub

        Private Sub LoadItemSubCategoryComboBox(ByVal ItemCategoryID As String)
            '//ItemSubCategory
            ddlItemSubCategory.Items.Clear()

            Dim oItemSubCategory As New BussinessRules.ItemSubCategory
            Dim dtItemSubCategory As New DataTable

            With oItemSubCategory
                .ItemCategoryID = ItemCategoryID.Trim
                dtItemSubCategory = .SelectByItemCategoryID(True)

                ddlItemSubCategory.Items.Add(New ListItem("- select record -", "none"))

                For Each row As DataRow In dtItemSubCategory.Rows
                    ddlItemSubCategory.Items.Add(New ListItem(CType(row("ItemSubCategoryName"), String), CType(row("ItemSubCategoryID"), String)))
                Next

                If dtItemSubCategory.Rows.Count = 1 Then
                    ddlItemSubCategory.SelectedIndex = 1
                End If
            End With

            oItemSubCategory.Dispose()
            oItemSubCategory = Nothing
        End Sub

        Private Sub UpdateViewGridItem(ByVal strItemName As String)
            Dim dt As DataTable
            Dim br As New BussinessRules.Item

            dt = br.SelectByFilterItemName(strItemName.Trim)

            RadGridItem.DataSource = dt.DefaultView
            RadGridItem.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridItemUnit()
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemFactorTemplate

            br.ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
            dt = br.SelectByItemSeqNo

            RadGridItemUnit.DataSource = dt.DefaultView
            RadGridItemUnit.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridLastNPurchase(Optional ByVal n As String = "3")
            Dim dt As DataTable
            Dim br As New BussinessRules.PurchaseUnitDt

            br.ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
            dt = br.SelectLastNPurchase(n)

            RadGridLastNPurchase.DataSource = dt.DefaultView
            RadGridLastNPurchase.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub UpdateViewGridLastNItemPrice(Optional ByVal n As String = "3")
            Dim dt As DataTable
            Dim br As New BussinessRules.ItemPrice

            br.ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
            dt = br.SelectLastNItemPrice(n)

            RadGridLastNItemPrice.DataSource = dt.DefaultView
            RadGridLastNItemPrice.DataBind()

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetSuggestedSalesPriceSUnit()
            Dim br As New BussinessRules.PurchaseUnitDt

            br.ItemSeqNo = RadComboBoxItemSeqNo.Text.Trim
            txtLastPurchasePriceSUnit.Text = Format(br.SelectLastOnePurchase, commonFunction.FORMAT_CURRENCY).Trim

            txtSuggestedSalesPriceSUnit.Text = Format(CDec(txtLastPurchasePriceSUnit.Text.Trim) + (CDec(txtLastPurchasePriceSUnit.Text.Trim) * (CDec(txtMarginPct.Text.Trim) / 100)), commonFunction.FORMAT_CURRENCY).Trim

            If CDec(txtSuggestedSalesPriceSUnit.Text) = 0 Or Len(txtSuggestedSalesPriceSUnit.Text.Trim) = 0 Then
                txtSuggestedSalesPriceSUnit.Text = txtSalesPriceSUnit.Text
            Else
                '// calculate up/down
                txtUpDownPriceSUnit.Text = Format(CDec(txtSalesPriceSUnit.Text.Trim) - CDec(txtSuggestedSalesPriceSUnit.Text.Trim), commonFunction.FORMAT_CURRENCY).Trim
                Select Case CDec(txtUpDownPriceSUnit.Text.Trim)
                    Case 0
                        '// No difference
                        lblUpDownPriceSUnitCaption.Visible = False
                        imgUpDownPriceSUnit.Visible = False
                        imgUpDownPriceSUnit.ImageUrl = ""
                    Case Is < 0
                        '// down
                        lblUpDownPriceSUnitCaption.Visible = True
                        imgUpDownPriceSUnit.Visible = True
                        imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/down.png"
                    Case Is > 0
                        '// up
                        lblUpDownPriceSUnitCaption.Visible = True
                        imgUpDownPriceSUnit.Visible = True
                        imgUpDownPriceSUnit.ImageUrl = "/pureravenslib/images/up.png"
                End Select
            End If

            br.Dispose()
            br = Nothing
        End Sub

        Private Sub GetRecordProperties()
            Dim br As New BussinessRules.RecordProperties

            With br
                If .GetRecordProperties("ItemSeqNo", RadComboBoxItemSeqNo.Text.Trim, "Item").Rows.Count > 0 Then
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