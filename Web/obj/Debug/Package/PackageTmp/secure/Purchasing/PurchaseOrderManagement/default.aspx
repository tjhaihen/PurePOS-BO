<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Purchasing.PurchaseOrderManagement"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Purchase Order Management</title>
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
														<telerik:AjaxSetting AjaxControlID="RadComboBoxEntitiesID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesID" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCurrency"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlWhID"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlCurrency">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlWhID">
															<UpdatedControls>			
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>													
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlUnitID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>		
														<telerik:AjaxSetting AjaxControlID="RadPOrdExpiredDate">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>																						
													</AjaxSettings>
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
                            Purchase Order Management
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                <tr>
                                    <td width="1" class="my_toolbarbutton_left">
                                    </td>
                                    <td valign="middle">
                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbtnRefresh" class="my_toolbarbutton" Text="Refresh"
                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                    </td>
                                    <td width="1" class="my_toolbarbutton_right">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
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
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Record Filter"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdExpiredDateCaption" runat="server" Text="Due Date Untill"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker id="RadPOrdExpiredDate" Runat="server" autopostback="True"
                                                                            MinDate="2006-01-01" SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall"></dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
																				</datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="14%">
                                                                        <asp:Label ID="lblEntitiesID" runat="server" Text="Supplier ID"></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <telerik:radcombobox id="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="190px" Runat="server" Skin="WebBlue" maxlength="15" DataTextField="EntitiesName"
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
																								<b>Supplier Seq No.</b>
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
                                                                        <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtEntitiesName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCurrencyCaption" runat="server" Text="Currency"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCurrency" runat="Server" Width="70%" AutoPostBack="True"
                                                                            Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN UNAPPROVED RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLUDiv.style.display == '') {RLUDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLUDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblUnapprovedRecordListCaption" runat="server" Text="Unapproved Purchase Order List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                <tr>
                                                    <td width="1" class="my_toolbarbutton_left">
                                                    </td>
                                                    <td valign="middle">
                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lbtnApproval" class="my_toolbarbutton" Text="Approve"
                                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle" height="20" />
                                                        <asp:LinkButton runat="server" ID="lbtnClose" class="my_toolbarbutton" Text="Close"
                                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                                    </td>
                                                    <td width="1" class="my_toolbarbutton_right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="RLUDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridUnapprovedPurchaseOrderManagement" runat="server" Style="width: 100%"
                                                                CellPadding="1" ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None"
                                                                BorderWidth="1" BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False"
                                                                AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <HeaderTemplate>
                                                                            <input name="UnapprovedPO_chkSelectAllItems" id="UnapprovedPO_chkSelectAllItems"
                                                                                type="checkbox" onclick="javascript:checkAllv2(this.form,'UnapprovedPO_chkIsSelected', 'UnapprovedPO_chkSelectAllItems');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="UnapprovedPO_chkIsSelected" Enabled="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="PO NO.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdNO" Text='<%# DataBinder.Eval(Container.DataItem, "POrdNO") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Age (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblAgeinday" Text='<%# DataBinder.Eval(Container.DataItem, "Ageinday") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="PO Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "POrdDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Due Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdExpiredDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "POrdExpiredDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Over Due (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblOverDue" Text='<%# DataBinder.Eval(Container.DataItem, "OverDueInDay") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Supplier Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblEntitiesName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Purchasing/PurchaseOrderManagement/POManagementDetail.aspx?" %>PONo=<%# Trim(DataBinder.Eval(Container.DataItem, "POrdNO")) %> ',null,800,600,'no')"
                                                                                title="PO Management Detail">
                                                                                <img src='/pureravenslib/images/detail.png' border='0' align='absmiddle' />
                                                                            </a>
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
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Outstanding Purchase Order List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                <tr>
                                                    <td width="1" class="my_toolbarbutton_left">
                                                    </td>
                                                    <td valign="middle">
                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                        <asp:LinkButton runat="server" ID="lbtnRelease" class="my_toolbarbutton" Text="Release"
                                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                                    </td>
                                                    <td width="1" class="my_toolbarbutton_right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridPurchaseOrderManagement" runat="server" Style="width: 100%"
                                                                CellPadding="1" ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None"
                                                                BorderWidth="1" BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False"
                                                                AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllItems" id="chkSelectAllItems" type="checkbox" onclick="javascript:checkAllv2(this.form,'_chkIsSelected', 'chkSelectAllItems');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsSelected" Enabled="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="PO NO.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdNO" Text='<%# DataBinder.Eval(Container.DataItem, "POrdNO") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Age (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblAgeinday" Text='<%# DataBinder.Eval(Container.DataItem, "Ageinday") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="PO Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "POrdDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Due Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPOrdExpiredDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "POrdExpiredDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Over Due (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblOverDue" Text='<%# DataBinder.Eval(Container.DataItem, "OverDueInDay") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Supplier Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblEntitiesName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Purchasing/PurchaseOrderManagement/POManagementDetail.aspx?" %>PONo=<%# Trim(DataBinder.Eval(Container.DataItem, "POrdNO")) %> ',null,800,600,'no')"
                                                                                title="PO Management Detail">
                                                                                <img src='/pureravenslib/images/detail.png' border='0' align='absmiddle' />
                                                                            </a>
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
