<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.Promotion"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Promotion</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">

    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>

    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>

</head>
<body ms_positioning="GridLayout">
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
                                        <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxID">
															<UpdatedControls>	
																<telerik:AjaxUpdatedControl ControlID="txtPromotionName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlPromotionTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadDatePickerStart"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadDatePickerEnd"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBuyQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGetQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSpecialPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBuyAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsMultipleApplied"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGetVoucherAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtnPurchase"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsNoEndDate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberType"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridPromotion" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridPromotion">
															<UpdatedControls>	
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPromotionName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlPromotionTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadDatePickerStart"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadDatePickerEnd"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBuyQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGetQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSpecialPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBuyAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsMultipleApplied"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGetVoucherAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtnPurchase"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>		
																<telerik:AjaxUpdatedControl ControlID="chkIsNoEndDate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberType"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridPromotion" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
															</UpdatedControls>
														</telerik:AjaxSetting>														
													</AjaxSettings>
												</telerik:RadAjaxManager>--%>
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
                            Finance
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Promotion
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td  height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Record Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="35%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="25%">
                                                                        <asp:Label ID="lblIDCaption" runat="server" Text="Promotion ID"></asp:Label>
                                                                    </td>
                                                                    <td width="82%">
                                                                        <telerik:RadComboBox ID="RadComboBoxID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                            AllowCustomText="True" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                            EnableLoadOnDemand="true" MarkFirstMatch="true" Width="82%" Height="190px" runat="server"
                                                                            Skin="WebBlue" MaxLength="15" DataTextField="ID" DataValueField="ID" Style="z-index: 0"
                                                                            ShowDropDownOnTextboxClick="False">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ID") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "PromotionName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Promotion ID</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Promotion Name</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPromotionNameCaption" runat="server" Text="Promotion Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtPromotionName" runat="server" MaxLength="500" Width="82%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPromotionTypeIDCaption" runat="server" Text="Promotion Type"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlPromotionTypeID" runat="server" Width="82%" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblDateCaption" runat="server" Text="Promotion Period"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="RadDatePickerStart" runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="32%" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                        to
                                                                        <telerik:RadDatePicker ID="RadDatePickerEnd" runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="32%" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkIsNoEndDate" runat="server" Text="No End Date" Checked="False">
                                                                        </asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="30%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblBuyGetQtyCaption" runat="server" Text="Buy - Get Qty"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtBuyQty" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="39%"></asp:TextBox>
                                                                        -
                                                                        <asp:TextBox ID="txtGetQty" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="39%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblSpecialPriceCaption" runat="server" Text="Special Price"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtSpecialPrice" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="82.2%" onblur="FormatCurrency(this);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc1PctCaption" runat="server" Text="Discount 1 ( % )"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDisc1Pct" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="82.2%" onblur="FormatCurrency(this);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="25%">
                                                                        <asp:Label ID="lblDisc2PctCaption" runat="server" Text="Discount 2 ( % )"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDisc2Pct" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="82.2%" onblur="FormatCurrency(this);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblGetVoucherAmtCaption" runat="server" Text="Get Voucher Amount"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtGetVoucherAmt" runat="server" MaxLength="18" Style="text-align: right"
                                                                            Width="82.2%" onblur="FormatCurrency(this);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="30%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="20%">
                                                                        <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="500" Width="80%" TextMode="MultiLine"
                                                                            Height="40px" Style="font-family: Tahoma; font-size: 9pt;"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="100%" colspan="3">
                                                            <telerik:RadTabStrip ID="Radtabstrip1" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                MultiPageID="RadMultiPage1">
                                                                <Tabs>
                                                                    <telerik:RadTab Text="Promotion Terms and Conditions">
                                                                    </telerik:RadTab>
                                                                </Tabs>
                                                            </telerik:RadTabStrip>
                                                            <telerik:RadMultiPage ID="Radmultipage1" runat="server" SelectedIndex="0">
                                                                <telerik:RadPageView ID="Pageview1" runat="server">
                                                                    <table cellspacing="1" cellpadding="2" width="100%">
                                                                        <tr>
                                                                            <td width="9%">
                                                                                <asp:Label ID="lblBuyAmtPctCaption" runat="server" Text="For Buy Amount"></asp:Label>
                                                                            </td>
                                                                            <td width="28%">
                                                                                <asp:TextBox ID="txtBuyAmt" runat="server" MaxLength="18" Style="text-align: right"
                                                                                    Width="80%" onblur="FormatCurrency(this);"></asp:TextBox>
                                                                            </td>
                                                                            <td width="9%">
                                                                                <asp:Label ID="lblnPurchaseCaption" runat="server" Text="For n Purchase"></asp:Label></asp:label>
                                                                            </td>
                                                                            <td width="28%">
                                                                                <asp:TextBox ID="txtnPurchase" runat="server" MaxLength="18" Style="text-align: right"
                                                                                    Width="65%"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkIsMultipleApplied" runat="server" Text="Multiple Applied"></asp:CheckBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblValidForMemberBenefitCaption" runat="server" Text="For Member Benefit"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlMemberType" runat="server" Width="65%">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </telerik:RadPageView>
                                                            </telerik:RadMultiPage>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 300px; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridPromotion" runat="server" Style="width: 100%" CellPadding="0"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="0" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle Font-Bold="True" CssClass="rheadercol" BackColor="#DEE3E7" Height="20" />
                                                                <HeaderStyle Font-Bold="false" BackColor="#DEE3E7" Height="20" />
                                                                <AlternatingItemStyle BackColor="#E3F3F9" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Promotion ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Promotion Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPromotionName" Text='<%# DataBinder.Eval(Container.DataItem, "Promotionname") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Promotion Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPromotionTypeID" Text='<%# DataBinder.Eval(Container.DataItem, "PromotionTypeID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Promotion Type Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPromotionTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "PromotionTypeName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Special Price">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSpecialPrice" Text='<%# DataBinder.Eval(Container.DataItem, "SpecialPrice") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Promotion Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPromotionDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "StartDate"),"dd-MM-yyy") + " to " + format(DataBinder.Eval(Container.DataItem, "EndDate"),"dd-MM-yyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Buy Qty">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblBuyQty" Text='<%# DataBinder.Eval(Container.DataItem, "BuyQty") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Get Qty">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblGetQty" Text='<%# DataBinder.Eval(Container.DataItem, "GetQty") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Disccount ( % ) 1 ">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc1Pct" Text='<%# DataBinder.Eval(Container.DataItem, "Disc1Pct") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Disccount ( % ) 2 ">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc2Pct" Text='<%# DataBinder.Eval(Container.DataItem, "Disc2Pct") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Buy Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblBuyAmt" Text='<%# DataBinder.Eval(Container.DataItem, "BuyAmt") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Multiple Applied">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsMultipleApplied" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsMultipleApplied") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Get Voucher Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblGetVoucherAmt" Text='<%# DataBinder.Eval(Container.DataItem, "GetVoucherAmt") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="n Purchase">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblnPurchase" Text='<%# DataBinder.Eval(Container.DataItem, "nPurchase") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Master/Finance/Promotion/PromotionDt.aspx?pdc=PromotionBrandName&" %>pid=<%# Trim(DataBinder.Eval(Container.DataItem, "ID")) %>&pnid=<%# Trim(DataBinder.Eval(Container.DataItem, "PromotionName")) %> ',null,800,600,'no')"
                                                                                title="Promotion Brand">Promotion Brand</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Master/Finance/Promotion/PromotionDt.aspx?pdc=PromotionItemCategory&" %>pid=<%# Trim(DataBinder.Eval(Container.DataItem, "ID")) %>&pnid=<%# Trim(DataBinder.Eval(Container.DataItem, "PromotionName")) %> ',null,800,600,'no')"
                                                                                title="Promotion Category">Promotion Category</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Master/Finance/Promotion/PromotionDt.aspx?pdc=PromotionItemSubCategory&" %>pid=<%# Trim(DataBinder.Eval(Container.DataItem, "ID")) %>&pnid=<%# Trim(DataBinder.Eval(Container.DataItem, "PromotionName")) %> ',null,800,600,'no')"
                                                                                title="Promotion Sub Category">Promotion Sub Category</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Master/Finance/Promotion/PromotionDt.aspx?pdc=PromotionItem&" %>pid=<%# Trim(DataBinder.Eval(Container.DataItem, "ID")) %>&pnid=<%# Trim(DataBinder.Eval(Container.DataItem, "PromotionName")) %> ',null,800,600,'no')"
                                                                                title="Promotion Item">Promotion Item</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD LIST SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:Copyright ID="mdlCopyRight" runat="server"></Module:Copyright>
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

    <script language="javascript" src="/pureravenslib/scripts/common/FormatNumber.js"></script>

</body>
</html>
