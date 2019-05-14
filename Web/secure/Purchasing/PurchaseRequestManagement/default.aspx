<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Purchasing.PurchaseRequestManagement"
    EnableSessionState="true" EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Purchase Request Management</title>
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
													<AjaxSettings></AjaxSettings>
												</telerik:RadAjaxManager>--%>
                                        <!-- END AJAX MANAGER -->
                                        <!-- BEGIN NAV BAR -->
                                        <Module:MENU id="Menu" runat="server">
                                        </Module:MENU>
                                        <!-- END NAV BAR -->
                                    </td>
                                </tr>
                            </table>
                            <!-- END PAGE HEADER -->
                        </td>
                    </tr>
                    <tr>
                        <td class="txtmenuname" valign="middle" width="100%" align="left">
                            Purchasing
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Purchase Request Management
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar id="Toolbar" runat="server">
                            </Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="z-index: 0; width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (PRFDiv.style.display == '') {PRFDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {PRFDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblPRFilterCaption" runat="server" Text="Purchase Request Filter"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="PRFDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblWhIDCaption" runat="server" Text="Warehouse"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlWhID" runat="Server" Width="70%" AutoPostBack="True" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblUnitIDCaption" runat="server" Text="Unit"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlUnitID" runat="Server" AutoPostBack="True" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <asp:Panel ID="PnlPONo" runat="server">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPOrdNoCaption" runat="server" Text="Result PO No. : "></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:LinkButton runat="server" ID="lbtnPOrdNo" class="MyButton"></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </asp:Panel>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblPOHeaderEntryCaption" runat="server" Text="Purchase Order Header Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdDateCaption" runat="server" Text="PO Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker id="RadPOrdDate" Runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                            Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall"></dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
																					</datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdExpiredDateCaption" runat="server" Text="PO Due Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker id="RadPOrdExpiredDate" Runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall"></dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
																					</datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblEntityID" runat="server" Text="Supplier ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:radcombobox id="RadComboBoxEntityID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="190px" Runat="server" Skin="WebBlue" maxlength="15" DataTextField="EntitiesID"
                                                                            DataValueField="EntitiesSeqNo" ShowDropDownOnTextboxClick="False">
                                                                            <itemtemplate>
																						<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																							<tr>																								
																								<td style="width:125px;">
																									<%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>
																								</td>
																								<td style="width:125px;">
																									<%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>
																								</td>
																								<td style="width:125px;">
																									<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
																								</td>
																							</tr>
																						</table>
																					</itemtemplate>
                                                                            <headertemplate>
																						<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																							<tr>
																								<td style="width:125px;">
																									<b>Supplier ID</b>
																								</td>
																								<td style="width:125px;">
																									<b>Supplier Seq. No.</b>
																								</td>
																								<td style="width:125px;">
																									<b>Supplier Name</b>
																								</td>
																							</tr>
																						</table>
																					</headertemplate>
                                                                        </telerik:radcombobox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblEntityNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtEntityName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPICNameCaption" runat="server" Text="PIC Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtPICName" runat="server" Width="70%" MaxLength="500"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdTypeIDCaption" runat="server" Text="PO Type"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlPOrdTypeID" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPaymentTypeIDCaption" runat="server" Text="Payment Type"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlPaymentTypeID" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblTermOfPaymentCaption" runat="server" Text="Term Of Payment"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlTermOfPayment" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblTermOfAgreementCaption" runat="server" Text="Term Of Agreement"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlTermOfAgreement" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblCurrencyCaption" runat="server" Text="Currency"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlCurrency" runat="Server" AutoPostBack="True" Width="70%"
                                                                            Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblCurrencyRateCaption" runat="server" Text="Currency Rate"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtCurrencyRate" runat="server" MaxLength="16" Style="text-align: right"
                                                                            Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdDeliveryDateCaption" runat="server" Text="Delivery Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker id="RadPOrdDeliveryDate" Runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall"></dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
																					</datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDeilverToCaption" runat="server" Text="Deliver To"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDeliverTo" runat="server" MaxLength="500" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDescriptionHdCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDescriptionHd" runat="server" MaxLength="500" Width="70%" TextMode="MultiLine"
                                                                            Height="40px" Style="font-size: 9pt; font-family: Tahoma"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                            <img style="cursor: hand" onclick="javascript:if (PRLDiv.style.display == '') {PRLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {PRLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblPRListCaption" runat="server" Text="Outstanding Purchase Request List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="PRLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridPurchaseRequestManagement" runat="server" Style="width: 100%"
                                                                CellPadding="1" ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None"
                                                                BorderWidth="1" BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False"
                                                                AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Action">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="_DDLStatusID" AppendDataBoundItems="true" runat="server">
                                                                                <asp:ListItem Text="[Not Selected]" Value="0" />
                                                                                <asp:ListItem Text="Process to PO" Value="1" />
                                                                                <asp:ListItem Text="Drop" Value="2" />
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="ID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="PR No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPReqNo" Text='<%# DataBinder.Eval(Container.DataItem, "PReqNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Age(in day)" HeaderStyle-HorizontalAlign="Center"
                                                                        ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAgeinday" Text='<%# DataBinder.Eval(Container.DataItem, "Ageinday") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Date" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPReqDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "PReqDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Seq No." Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Name">
                                                                        <ItemTemplate>
                                                                            <table>
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty Request" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblQtyRequestCaption" Text='<%# format(DataBinder.Eval(Container.DataItem, "Qty"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty Order" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                Width="100%" ID="_txtQty" Text='<%# format(DataBinder.Eval(Container.DataItem, "Qty"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Unit ID" ItemStyle-HorizontalAlign="Right"
                                                                        Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Unit" ItemStyle-HorizontalAlign="left">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Factor" ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                ID="_lblItemFactor" Text='<%# DataBinder.Eval(Container.DataItem, "ItemFactor") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Price" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                Width="120" ID="_txtPrice" Text='<%# format(DataBinder.Eval(Container.DataItem, "Price"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount1(%)" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                Width="80" ID="_txtDiscount1pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Discount1pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount2(%)" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                Width="80" ID="_txtDiscount2pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Discount2pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount3(%)" HeaderStyle-HorizontalAlign="Right"
                                                                        ItemStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox runat="server" Style="margin-left: 0; margin-right: 5; text-align: right;"
                                                                                Width="80" ID="_txtDiscount3pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "discount3pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Entities Name" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEntitiesName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
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
                            <Module:COPYRIGHT id="mdlCopyRight" runat="server">
                            </Module:COPYRIGHT>
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
