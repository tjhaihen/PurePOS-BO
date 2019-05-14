<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Transaction.DeliveryOrderManagement"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Delivery Order Management</title>
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
														<telerik:AjaxSetting AjaxControlID="RadToolbar">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCurrency"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlWhID"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="ddlDeliveryZone"></telerik:AjaxUpdatedControl>																	
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="RadDueDate"></telerik:AjaxUpdatedControl>	
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxEntitiesID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesID" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCurrency"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlWhID"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>	
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlCurrency">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlWhID">
															<UpdatedControls>			
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>													
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlUnitID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>	
														<telerik:AjaxSetting AjaxControlID="ddlDeliveryZone">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>	
														<telerik:AjaxSetting AjaxControlID="RadDueDate">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryOrderManagement" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
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
                            Purchasing
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Delivery Order Management
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
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDueDateCaption" runat="server" Text="Due Date Untill"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker ID="RadDueDate" runat="server" AutoPostBack="True" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="40%" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="14%">
                                                                        <asp:Label ID="lblEntitiesID" runat="server" Text="Customer ID"></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <telerik:RadComboBox ID="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="EntitiesName"
                                                                            DataValueField="EntitiesSeqNo" ShowDropDownOnTextboxClick="False">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Customer ID</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Customer Seq No.</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Customer Name</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Customer Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtEntitiesName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblCurrencyCaption" runat="server" Text="Currency"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlCurrency" runat="Server" Width="70%" AutoPostBack="True"
                                                                            Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblWhIDCaption" runat="server" Text="Warehouse Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlWhID" runat="Server" Width="70%" AutoPostBack="True" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblUnitIDCaption" runat="server" Text="Unit Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlUnitID" runat="Server" AutoPostBack="True" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDeliveryZoneCaption" runat="server" Text="Delivery Zone"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlDeliveryZone" runat="Server" AutoPostBack="True" Width="70%"
                                                                            Enabled="True">
                                                                        </asp:DropDownList>
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
                                            <div style="width: 100%; height: 100%; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridDeliveryOrderManagement" runat="server" Style="width: 100%"
                                                                CellPadding="1" ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None"
                                                                BorderWidth="1" BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False"
                                                                AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Bonus">
                                                                        <HeaderTemplate>
                                                                            Release
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsRelease" Enabled="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="DO No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDONO" Text='<%# DataBinder.Eval(Container.DataItem, "DONO") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Age (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAgeinday" Text='<%# DataBinder.Eval(Container.DataItem, "Ageinday") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="DO Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDODate" Text='<%# format(DataBinder.Eval(Container.DataItem, "DODate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Due Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDueDateDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "DueDate"),"dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Over Due (in day)">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblOverDue" Text='<%# DataBinder.Eval(Container.DataItem, "OverDueInDay") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Customer Name">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblEntitiesName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" ID="_lblDeliveryAddress" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryAddress") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        [&nbsp;<asp:Label runat="server" ID="_lblDeliveryZoneName" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryZoneName") %>' />&nbsp;]
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Phone No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPrimaryPhoneNo" Text='<%# DataBinder.Eval(Container.DataItem, "PrimaryPhoneNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Warehouse">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" ID="_lblWhName" Text='<%# DataBinder.Eval(Container.DataItem, "WhName") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" ID="_lblUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "UnitName") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Printed By">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td style="text-align: right;">
                                                                                        <asp:Label runat="server" ID="_lblPrintedBy" Text='<%# DataBinder.Eval(Container.DataItem, "UserPrinted") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak" style="text-align: right;">
                                                                                        <asp:Label runat="server" ID="_lblPrintedDate" Text='<%# DataBinder.Eval(Container.DataItem, "PrintedDate") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnPrint" runat="server" Text='<img src="/pureravenslib/images/print.png" alt="Print" border="0" align="absmiddle" />'
                                                                                CommandName="Print" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Transaction/DeliveryOrderManagement/DOManagementDetail.aspx?" %>DONo=<%# Trim(DataBinder.Eval(Container.DataItem, "DONO")) %> ',null,800,600,'no')"
                                                                                title="DO Management Detail">
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
</body>
</html>
