<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Master.ItemDataSetting.ItemList"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Item List</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" ms_positioning="GridLayout">
    <form runat="server">
    <table border="0" cellspacing="0" cellpadding="2" width="100%" height="100%">
        <tr>
            <td valign="top" width="80%">
                <table border="0" cellspacing="1" cellpadding="3" width="100%" height="100%">
                    <tr>
                        <td colspan="2">
                            <!-- BEGIN PAGE HEADER -->
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td valign="top" width="100%">
                                        <!-- BEGIN AJAX MANAGER -->
                                        <!-- END AJAX MANAGER -->
                                        <!-- BEGIN NAV BAR -->
                                        <Module:Menu ID="Menu" runat="server"></Module:Menu>
                                        <!-- END NAV BAR -->
                                    </td>
                                </tr>
                            </table>
                            <!-- END PAGE HEADER -->
                        </td>
                    </tr>
                    <tr>
                        <td class="txtmenuname" valign="middle" width="100%" align="left">
                            Master
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Item Data Setting
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Item List
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%" cellspacing="1">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Item Record Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <!-- BEGIN FIRST COLUMN -->
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblItemSeqNoCaption" runat="server" Text="Item Seq. No."></asp:Label>
                                                                    </td>
                                                                    <td width="30%">
                                                                        <telerik:RadComboBox Style="z-index: 0" ID="RadComboBoxItemSeqNo" runat="server"
                                                                            AutoPostBack="true" Skin="WebBlue" ShowMoreResultBox="false" AllowCustomText="true"
                                                                            ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                            EnableLoadOnDemand="true" MarkFirstMatch="true" Width="90%" Height="190px" DataTextField="ItemName"
                                                                            DataValueField="ItemSeqNo" ShowDropDownOnTextboxClick="False">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ItemID") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ItemName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            Item Seq No
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            Item ID
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            Item Name
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblItemIDCaption" runat="server" Text="Item ID"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtItemID" runat="server" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblItemNameCaption" runat="server" Text="Item Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtItemName" runat="server" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtInActiveDescription" runat="server" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <telerik:RadTabStrip ID="Radtabstrip1" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage1">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Item Basic Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage1" runat="server" SelectedIndex="0" BorderStyle="Solid"
                                                                            BorderWidth="1" BorderColor="#C8D6E5">
                                                                            <telerik:RadPageView ID="Pageview1" runat="server">
                                                                                <table cellspacing="1" cellpadding="3" width="100%">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblItemStatusCaption" runat="server" Text="Item Status"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:DropDownList ID="ddlItemStatus" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPrintNameCaption" runat="server" Text="Print Name"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPrintName" runat="server" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBrandNameCaption" runat="server" Text="Brand Name"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlBrandName" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemSizeCaption" runat="server" Text="Item Size"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtItemSize" runat="server" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemCategoryCaption" runat="server" Text="Item Category"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlItemCategory" runat="server" Width="90%" AutoPostBack="True">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemSubCategoryCaption" runat="server" Text="Item Sub Category"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlItemSubCategory" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                                                                <tr>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="lblIsFoodCaption" runat="server" Text="Food"></asp:Label>
                                                                                                    </td>
                                                                                                    <td width="30%">
                                                                                                        <asp:RadioButton ID="rdbIsFoodYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsFoodNo" runat="server" AutoPostBack="True" Text="No"></asp:RadioButton>
                                                                                                    </td>
                                                                                                    <td width="20%">
                                                                                                        <asp:Label ID="lblIsLegalCaption" runat="server" Text="Legal"></asp:Label>
                                                                                                    </td>
                                                                                                    <td width="30%">
                                                                                                        <asp:RadioButton ID="rdbIsLegalYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsLegalNo" runat="server" AutoPostBack="True" Text="No">
                                                                                                        </asp:RadioButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblIsFreshCaption" runat="server" Text="Fresh"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:RadioButton ID="rdbIsFreshYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsFreshNo" runat="server" AutoPostBack="True" Text="No">
                                                                                                        </asp:RadioButton>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblIsImportCaption" runat="server" Text="Import"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:RadioButton ID="rdbIsImportYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsImportNo" runat="server" AutoPostBack="True" Text="No">
                                                                                                        </asp:RadioButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblIsHalalCaption" runat="server" Text="Halal"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:RadioButton ID="rdbIsHalalYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsHalalNo" runat="server" AutoPostBack="True" Text="No">
                                                                                                        </asp:RadioButton>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblIsHouseBrandCaption" runat="server" Text="House Brand"></asp:Label>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:RadioButton ID="rdbIsHouseBrandYes" runat="server" AutoPostBack="True" Text="Yes">
                                                                                                        </asp:RadioButton>
                                                                                                        <asp:RadioButton ID="rdbIsHouseBrandNo" runat="server" AutoPostBack="True" Text="No">
                                                                                                        </asp:RadioButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <telerik:RadTabStrip ID="Radtabstrip6" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            SkinsPath="/pureravenslib/RadControls/TabStrip/Skins" MultiPageID="RadMultiPage6">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Item Description">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage6" runat="server" SelectedIndex="0" BorderStyle="Solid"
                                                                            BorderWidth="1" BorderColor="#C8D6E5">
                                                                            <telerik:RadPageView ID="Pageview6" runat="server">
                                                                                <table cellspacing="1" cellpadding="3" width="100%">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox Style="font-family: Tahoma; font-size: 9pt" ID="txtDescription" runat="server"
                                                                                                Width="90%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <!-- END FIRST COLUMN -->
                                                        <!-- BEGIN SECOND COLUMN -->
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <telerik:RadTabStrip ID="Radtabstrip4" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            SkinsPath="/pureravenslib/RadControls/TabStrip/Skins" MultiPageID="RadMultiPage4">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Manufacturer, Distributor and Producer">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage4" runat="server" SelectedIndex="0" BorderStyle="Solid"
                                                                            BorderWidth="1" BorderColor="#C8D6E5">
                                                                            <telerik:RadPageView ID="Pageview4" runat="server">
                                                                                <table cellspacing="1" cellpadding="3" width="100%">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblManufacturerCaption" runat="server" Text="Manufacturer"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:DropDownList ID="ddlManufacturer" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDistributorCaption" runat="server" Text="Distributor/Supplier"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlDistributor" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblProducerCaption" runat="server" Text="Producer"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:DropDownList ID="ddlProducer" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblCountryCaption" runat="server" Text="Country Origin"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadTabStrip ID="Radtabstrip2" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            SkinsPath="/pureravenslib/RadControls/TabStrip/Skins" MultiPageID="RadMultiPage2">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Item Unit and Conversion">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage2" runat="server" SelectedIndex="0" BorderStyle="Solid"
                                                                            BorderWidth="1" BorderColor="#C8D6E5">
                                                                            <telerik:RadPageView ID="Pageview2" runat="server">
                                                                                <table cellspacing="1" cellpadding="3" width="100%">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblItemSUnitCaption" runat="server" Text="Smallest Unit (Pcs/Kg)"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:Label ID="lblItemCurrentSUnitID" runat="server" Visible="False"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlItemSUnit" runat="server" Width="40%" AutoPostBack="True">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;=&nbsp;
                                                                                            <asp:TextBox Style="text-align: right" ID="txtItemFactorStoS" runat="server" Width="10%"
                                                                                                Enabled="False"></asp:TextBox>&nbsp;
                                                                                            <asp:Label ID="lblItemSUnitStoS" runat="server" Width="10%"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemMUnitCaption" runat="server" Text="Middle Unit (Box)"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemCurrentMUnitID" runat="server" Visible="False"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlItemMUnit" runat="server" Width="40%">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;=&nbsp;
                                                                                            <asp:TextBox Style="text-align: right" ID="txtItemFactorMtoS" runat="server" Width="10%"></asp:TextBox>&nbsp;
                                                                                            <asp:Label ID="lblItemSUnitMtoS" runat="server" Width="10%"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemLUnitCaption" runat="server" Text="Largest Unit (Dus)"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemCurrentLUnitID" runat="server" Visible="False"></asp:Label>
                                                                                            <asp:DropDownList ID="ddlItemLUnit" runat="server" Width="40%">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;=&nbsp;
                                                                                            <asp:TextBox Style="text-align: right" ID="txtItemFactorLtoS" runat="server" Width="10%"></asp:TextBox>&nbsp;
                                                                                            <asp:Label ID="lblItemSUnitLtoS" runat="server" Width="10%"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <!-- BEGIN ALTERNATE ITEM UNIT SECTION -->
                                                                                    <tr>
                                                                                        <td colspan="2" width="100%">
                                                                                            <table width="100%" cellpadding="1" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td class="rheader" height="25" valign="middle" width="100%" align="left">
                                                                                                        &nbsp;
                                                                                                        <asp:Label ID="lblAlternateItemUnitCaption" runat="server" Text="Alternate Item Unit"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top" align="left" colspan="2" width="100%">
                                                                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                                                            <tr>
                                                                                                                <td width="1" class="my_toolbarbutton_left">
                                                                                                                </td>
                                                                                                                <td valign="middle">
                                                                                                                    <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                                                                                        Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                                                                                    <asp:LinkButton runat="server" ID="lbtnSaveAltItemUnit" class="my_toolbarbutton"
                                                                                                                        Text="Save Alternate Item Unit" CausesValidation="false" Style="color: black;
                                                                                                                        text-decoration: none;" Width="130px"></asp:LinkButton>
                                                                                                                </td>
                                                                                                                <td width="1" class="my_toolbarbutton_right">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblItemAlternateUnitCaption" runat="server" Text="Alternate Unit"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlItemAlternateUnit" runat="server" Width="40%">
                                                                                            </asp:DropDownList>
                                                                                            &nbsp;=&nbsp;
                                                                                            <asp:TextBox Style="text-align: right" ID="txtItemFactorAlternatetoS" runat="server"
                                                                                                Width="10%"></asp:TextBox>&nbsp;
                                                                                            <asp:Label ID="lblItemSUnitAlternatetoS" runat="server" Width="10%"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:DataGrid ID="RadGridItemUnit" runat="server" Style="width: 100%" CellPadding="1"
                                                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                                                <EditItemStyle Font-Bold="false" />
                                                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                                                <Columns>
                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Unit ID">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="_lblItemUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitID") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateColumn>
                                                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Factor">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label runat="server" ID="_lblItemFactor" Text='<%# Format(DataBinder.Eval(Container.DataItem, "ItemFactor"), "#,##.000") %>' />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <!-- END ALTERNATE ITEM UNIT SECTION -->
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <!-- END SECOND COLUMN -->
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN LAST PURCHASE SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (LPDiv.style.display == '') {LPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {LPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblLastPurchaseCaption" runat="server" Text="Item Last Purchase Information"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="LPDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnShowLastNPurchase" class="my_toolbarbutton"
                                                                            Text="Show Last Purchase" CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <table cellspacing="1" cellpadding="3" width="100%">
                                                                <tr>
                                                                    <td valign="top" width="100%" align="left">
                                                                        Last Purchase to Show
                                                                        <asp:TextBox Style="text-align: right;" align="top" ID="txtLastNPurchase" runat="server"
                                                                            Width="50px" Height="20px"></asp:TextBox>
                                                                        (Max. 10)
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="middle" width="100%" align="center">
                                                                        <asp:DataGrid ID="RadGridLastNPurchase" runat="server" Style="width: 100%" CellPadding="1"
                                                                            ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                            BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                            <HeaderStyle CssClass="gridheaderstyle" />
                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                            <ItemStyle CssClass="gridItemstyle" />
                                                                            <EditItemStyle Font-Bold="false" />
                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                            <Columns>
                                                                                <asp:TemplateColumn runat="server" HeaderText="PU Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="_lblPUnitDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "PUnitDate"), "dd-MM-yyyy") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="PU No.">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="_lblPUnitNo" Text='<%# DataBinder.Eval(Container.DataItem, "PUnitNo") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Supplier">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="_lblSupplierName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Qty" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="_lblQty" Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Item Unit" ItemStyle-HorizontalAlign="Center"
                                                                                    HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" Style="margin-left: 0; margin-right: 0" ID="_lblItemUnit"
                                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitName") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Item Factor" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" Style="margin-left: 0; margin-right: 0" ID="_lblItemFactor"
                                                                                            Text='<%# DataBinder.Eval(Container.DataItem, "ItemFactor") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Nett Unit Price" ItemStyle-HorizontalAlign="Right"
                                                                                    HeaderStyle-HorizontalAlign="Right">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" Style="margin-left: 0; margin-right: 0" ID="_lblNettPrice"
                                                                                            Text='<%# Format(DataBinder.Eval(Container.DataItem, "NettUnitPrice"), "#,##.00") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" width="100%" height="25">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END LAST PURCHASE SECTION -->
                                    <!-- BEGIN ITEM PRICE SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (IPDiv.style.display == '') {IPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {IPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblItemPriceCaption" runat="server" Text="Item Price"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="IPDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnSaveItemPrice" class="my_toolbarbutton" Text="Save Item Price"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                                                        <asp:LinkButton runat="server" ID="lbtnShowCurrentPrice" class="my_toolbarbutton"
                                                                            Text="Show Current Item Price" CausesValidation="false" Style="color: black;
                                                                            text-decoration: none"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                                                        <asp:LinkButton runat="server" ID="lbtnShowLastPrice" class="my_toolbarbutton" Text="Show Last Item Price"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                                                        <asp:LinkButton runat="server" ID="lbtnShowItemPriceList" class="my_toolbarbutton"
                                                                            Text="Show Item Price List" CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="26%">
                                                                        <asp:Label ID="lblLastPurchasePriceSUnitCaption" runat="server" Text="Last S Unit Purchase Price"></asp:Label>
                                                                    </td>
                                                                    <td width="30%">
                                                                        <asp:TextBox Style="text-align: right" ID="txtLastPurchasePriceSUnit" runat="server"
                                                                            Width="100%" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtLastPurchasePriceSUnitCaption" Height="23px" runat="server" Text="From last purchase nett unit price"
                                                                            Width="100%" Style="text-align: center; background-color: gray; color: white;
                                                                            align: middle;" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblMarginPctCaption" runat="server" Text="Item Sales Margin (%)"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtMarginPct" runat="server" Width="100%"
                                                                            AutoPostBack="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSuggestedSalesPriceSUnitCaption" runat="server" Text="Sggt. S Unit Sales Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtSuggestedSalesPriceSUnit" runat="server"
                                                                            Width="100%" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSuggestedSalesPriceSUnitCaption" Height="23px" runat="server"
                                                                            Text="Suggested S unit sales price after margin" Width="100%" Style="text-align: center;
                                                                            background-color: gray; color: white; align: middle;" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblStartingDateCaption" runat="server" Text="Valid From Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="RadStartingDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                            Culture="Marathi (India)">
                                                                            <DateInput Width="60%" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSalesPriceSUnitCaption" runat="server" Text="S Unit (Pcs/Kg) Sales Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtSalesPriceSUnit" runat="server" Width="100%"
                                                                            AutoPostBack="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtUpDownPriceSUnit" runat="server" Width="50%"
                                                                            Enabled="False"></asp:TextBox>
                                                                        <asp:Image ID="imgUpDownPriceSUnit" runat="server" align="absmiddle"></asp:Image>
                                                                        <asp:Label ID="lblUpDownPriceSUnitCaption" runat="server" Text="From Suggested"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSalesPriceLUnitCaption" runat="server" Text="L Unit (Dus) Sales Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtSalesPriceLUnit" runat="server" Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOfficeSalesPriceSUnitCaption" runat="server" Text="S Unit Office Sales Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtOfficeSalesPriceSUnit" runat="server"
                                                                            Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOfficeSalesPriceLUnitCaption" runat="server" Text="L Unit Office Sales Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtOfficeSalesPriceLUnit" runat="server"
                                                                            Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSuggestedRetailPriceSUnitCaption" runat="server" Text="S Unit Suggested Retail Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtSuggestedRetailPriceSUnit" runat="server"
                                                                            Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSuggestedRetailPriceLUnitCaption" runat="server" Text="L Unit Suggested Retail Price"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox Style="text-align: right" ID="txtSuggestedRetailPriceLUnit" runat="server"
                                                                            Width="100%"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblMarginRangeCaption" runat="server" Text="Margin Range"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlMarginRange" runat="server" Width="100%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="100%">
                                                                        <asp:Label ID="lblLastItemPriceToShowCaption" runat="server" Text="Last Item Price to Show"></asp:Label>
                                                                        <asp:TextBox Style="text-align: right" ID="txtLastNItemPrice" runat="server" Width="10%"></asp:TextBox>
                                                                        <asp:Label ID="lblMaxLastItemPriceToShowCaption" runat="server" Text="(Max. 10)"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <asp:DataGrid ID="RadGridLastNItemPrice" runat="server" Style="width: 100%" CellPadding="1"
                                                                            ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="Both" BorderWidth="1"
                                                                            BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                            <HeaderStyle CssClass="gridheaderstyle" />
                                                                            <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                            <ItemStyle CssClass="gridItemstyle" />
                                                                            <EditItemStyle Font-Bold="false" />
                                                                            <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                            <Columns>
                                                                                <asp:TemplateColumn runat="server" HeaderText="Valid from Date" HeaderStyle-Width="100px"
                                                                                    ItemStyle-Width="100px">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label runat="server" ID="_lblValidFromDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "StartingDate"), "dd-MM-yyyy") %>' />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderStyle-Width="270px" ItemStyle-Width="270px">
                                                                                    <HeaderTemplate>
                                                                                        <table width="270px" cellpadding="0">
                                                                                            <tr>
                                                                                                <td colspan="3" style="text-align: center;">
                                                                                                    Sales Price
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 134px; text-align: center;">
                                                                                                    S Unit
                                                                                                </td>
                                                                                                <td style="width: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                                <td style="width: 134px; text-align: center;">
                                                                                                    L Unit
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table width="270px" cellpadding="0">
                                                                                            <tr>
                                                                                                <td style="width: 134px; text-align: right;">
                                                                                                    <asp:Label runat="server" ID="_lblSalesPriceSUnit" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesPriceSUnit"), "#,##.00") %>' />
                                                                                                </td>
                                                                                                <td style="width: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                                <td style="width: 134px; text-align: right;">
                                                                                                    <asp:Label runat="server" ID="_lblSalesPriceLUnit" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesPriceLUnit"), "#,##.00") %>' />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                                <asp:TemplateColumn runat="server" HeaderStyle-Width="270px" ItemStyle-Width="270px">
                                                                                    <HeaderTemplate>
                                                                                        <table width="270px" cellpadding="0">
                                                                                            <tr>
                                                                                                <td colspan="3" style="text-align: center; border-width: 1px;">
                                                                                                    Office Sales Price
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 134px; text-align: center;">
                                                                                                    S Unit
                                                                                                </td>
                                                                                                <td style="width: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                                <td style="width: 134px; text-align: center;">
                                                                                                    L Unit
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <table width="270px" cellpadding="0">
                                                                                            <tr>
                                                                                                <td style="width: 134px; text-align: right;">
                                                                                                    <asp:Label runat="server" ID="_lblOfficeSalesPriceSUnit" Text='<%# Format(DataBinder.Eval(Container.DataItem, "OfficeSalesPriceSUnit"), "#,##.00") %>' />
                                                                                                </td>
                                                                                                <td style="width: 1px; background-color: #999999;">
                                                                                                </td>
                                                                                                <td style="width: 134px; text-align: right;">
                                                                                                    <asp:Label runat="server" ID="_lblOfficeSalesPriceLUnit" Text='<%# Format(DataBinder.Eval(Container.DataItem, "OfficeSalesPriceLUnit"), "#,##.00") %>' />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateColumn>
                                                                            </Columns>
                                                                        </asp:DataGrid>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END ITEM PRICE SECTION -->
                                    <!-- BEGIN UPLOAD PHOTO SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (UPDiv.style.display == '') {UPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {UPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle" />
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblUploadPhoto" runat="server" Text="Item Photo"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: auto; overflow: auto" id="UPDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle" style="height: 20px">
                                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnUpload" class="my_toolbarbutton" Text="Upload Photo"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                                                        <asp:LinkButton runat="server" ID="lbtnRemove" class="my_toolbarbutton" Text="Remove Photo"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <table cellspacing="1" cellpadding="3" width="100%">
                                                                <tr>
                                                                    <td valign="top" width="100%" align="center">
                                                                        <input id="PhotoFile" class="upload" size="100" type="file" name="PhotoFile" runat="server">
                                                                        <asp:TextBox ID="txtItemPhotoSeqNo" runat="server" Width="100%" Style="display: none"
                                                                            ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="middle" width="100%" align="center">
                                                                        <div style="width: 800px; height: 100%; overflow: auto">
                                                                            <img id="PhotoViewer" src='<%= UrlBase + "/secure/Master/ItemDataSetting/ItemList/GetItemPic.aspx?no=" + RadComboBoxItemSeqNo.Text.Trim %>'
                                                                                alt="Item photo">
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END UPLOAD PHOTO SECTION -->
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryList" runat="server" Text="Item Record List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <!-- BEGIN FIRST COLUMN -->
                                                        <td valign="center" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%" valign="center">
                                                                        <asp:Label ID="lblSearchItemName" runat="server" Text="Search Item Name"></asp:Label>
                                                                    </td>
                                                                    <td width="30%" valign="center">
                                                                        <asp:TextBox ID="txtSearchItemName" runat="server" Width="80%" Text="*"></asp:TextBox>
                                                                        <asp:LinkButton CssClass="MyButton" ID="lbtnApplyFilter" runat="server" Text="Apply"
                                                                            Width="50"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label Style="color: gray; font-size: 8pt;" ID="lblSearchItemNameNotes" runat="server"
                                                                            Text="(e.g.: [Search Text]*; *[Search Text]; *[Search Text]*. Notes: Showing all items (*) will take longer time to get the data.)"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="center" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="100%" align="left" valign="center">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <asp:DataGrid ID="RadGridItem" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="25px" ItemStyle-Width="25px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="150px" HeaderText="Item Seq. No."
                                                                        ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <table width="600px">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" ID="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="300px" ItemStyle-Width="300px">
                                                                        <HeaderTemplate>
                                                                            <table width="300px" cellpadding="0">
                                                                                <tr>
                                                                                    <td colspan="5" style="text-align: center; border-width: 1px;">
                                                                                        Item Unit
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="5" style="height: 1px; background-color: #999999;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        S
                                                                                    </td>
                                                                                    <td style="width: 1px; background-color: #999999;">
                                                                                    </td>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        M
                                                                                    </td>
                                                                                    <td style="width: 1px; background-color: #999999;">
                                                                                    </td>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        L
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table width="300px" cellpadding="0">
                                                                                <tr>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        <asp:Label runat="server" ID="_lblItemSUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSUnitID") %>' />
                                                                                    </td>
                                                                                    <td style="width: 1px; background-color: #999999;">
                                                                                    </td>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        <asp:Label runat="server" ID="_lblItemMUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemMUnitID") %>' />
                                                                                    </td>
                                                                                    <td style="width: 1px; background-color: #999999;">
                                                                                    </td>
                                                                                    <td style="width: 99px; text-align: center;">
                                                                                        <asp:Label runat="server" ID="_lblItemLUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemLUnitID") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="100px" HeaderText="Active"
                                                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" width="100%" height="25">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD LIST SECTION -->
                                    <!-- BEGIN RECORD PROPERTIES SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RCDiv.style.display == '') {RCDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RCDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordPropertiesCaption" runat="server" Text="Record Properties"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="RCDiv">
                                                <table cellpadding="2" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="lblUserInsertCaption" runat="server" Text="Created by"></asp:Label>
                                                        </td>
                                                        <td width="2%">
                                                            :
                                                        </td>
                                                        <td width="68%">
                                                            <asp:Label ID="lblUserInsert" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInsertDateCaption" runat="server" Text="Insert date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInsertDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdateCaption" runat="server" Text="Last update by"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDateCaption" runat="server" Text="Update date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD PROPERTIES SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadCalendar ID="sharedCalendar" runat="server" EnableMultiSelect="false"
        RangeMinDate="2006/01/01">
    </telerik:RadCalendar>
    <asp:PlaceHolder ID="sharedCalendarPlaceHolder" runat="server"></asp:PlaceHolder>
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
