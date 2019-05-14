<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Inventory.BalanceInformation"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Balance Information</title>
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
														<telerik:AjaxSetting AjaxControlID="RadComboBoxSourceWhID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceWhID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceWhName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxDestinationWhID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationWhID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationWhName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxSourceUnitID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceUnitName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxDestinationUnitID">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationUnitName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxSourceItemSeqNo">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceItemName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxDestinationItemSeqNo">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationItemName"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadToolbar">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceWhID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceWhName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationWhID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationWhName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceUnitName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationUnitName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxSourceItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSourceItemName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDestinationItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDestinationItemName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridQuery" ></telerik:AjaxUpdatedControl>
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
                            Inventory
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Balance Information
                        </td>
                    </tr>
                    <asp:Panel ID="PanelToolbar" runat="server">
                        <tr>
                            <td height="25" valign="middle" width="100%" colspan="2" align="left">
                                <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="overflow: auto; width: 100%; height: 100%">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <asp:Panel ID="PanelHeader" runat="server">
                                        <tr>
                                            <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                                <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                    alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
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
                                                                            <asp:Label ID="lblSourceWhID" runat="server" Text="Source Warehouse ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxSourceWhID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="WhID"
                                                                                DataValueField="WhID" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "WhID") %>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "WhName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Warehouse ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Warehouse Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationWhID" runat="server" Text="Destination Warehouse ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxDestinationWhID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="WhID"
                                                                                DataValueField="WhID" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "WhID") %>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "WhName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Warehouse ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Warehouse Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblSourceUnitID" runat="server" Text="Source Unit ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxSourceUnitID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="unitID"
                                                                                DataValueField="unitID" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "unitID") %>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "unitName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Unit ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Unit Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationUnitID" runat="server" Text="Destination Unit ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxDestinationUnitID" ShowMoreResultBox="false"
                                                                                AutoPostBack="True" AllowCustomText="True" Width="70%" ItemRequestTimeout="200"
                                                                                DropDownWidth="500px" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                                MarkFirstMatch="true" Height="190px" runat="server" Skin="WebBlue" MaxLength="15"
                                                                                DataTextField="unitID" DataValueField="unitID" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "unitID") %>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "unitName") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Unit ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Unit Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblSourceItemSeqNo" runat="server" Text="Source Item ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxSourceItemSeqNo" ShowMoreResultBox="false" AutoPostBack="True"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="ItemID"
                                                                                DataValueField="ItemSeqNo" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
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
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item Seq No.</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationItemSeqNo" runat="server" Text="Destination Item ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxDestinationItemSeqNo" ShowMoreResultBox="false"
                                                                                AutoPostBack="True" AllowCustomText="True" Width="70%" ItemRequestTimeout="200"
                                                                                DropDownWidth="500px" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                                MarkFirstMatch="true" Height="190px" runat="server" Skin="WebBlue" MaxLength="15"
                                                                                DataTextField="ItemID" DataValueField="ItemSeqNo" ShowDropDownOnTextboxClick="False">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
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
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;">
                                                                                        <tr>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item Seq No.</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item ID</b>
                                                                                            </td>
                                                                                            <td style="width: 125px;">
                                                                                                <b>Item Name</b>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </HeaderTemplate>
                                                                            </telerik:RadComboBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="50%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblSourceWhNameCaption" runat="server" Text="Source Warehouse Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtSourceWhName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationWhNameCaption" runat="server" Text="Destination Warehouse Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtDestinationWhName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblSourceUnitNameCaption" runat="server" Text="Source Unit Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtSourceUnitName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationUnitNameCaption" runat="server" Text="Destination Unit Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtDestinationUnitName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblSourceItemNameCaption" runat="server" Text="Source Item Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtSourceItemName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDestinationItemNameCaption" runat="server" Text="Destination Item Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtDestinationItemName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <asp:Panel ID="PanelGrid" runat="server">
                                        <tr>
                                            <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                                <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                    alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                            </td>
                                            <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                                &nbsp;
                                                <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="100%" colspan="2">
                                                <div style="overflow: auto; width: 100%; height: 300px" id="RLDiv">
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <asp:DataGrid ID="RadGridQuery" runat="server" Style="width: 100%" CellPadding="1"
                                                                    ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                    BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                    <HeaderStyle CssClass="gridheaderstyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                    <ItemStyle CssClass="gridItemstyle" />
                                                                    <EditItemStyle Font-Bold="false" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Warehouse ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblWhID" Text='<%# DataBinder.Eval(Container.DataItem, "WhID") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Warehouse Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblWhName" Text='<%# DataBinder.Eval(Container.DataItem, "WhName") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Unit ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "UnitID") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Unit Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "UnitName") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item Seq No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Qty" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblQtySUnit" Text='<%# DataBinder.Eval(Container.DataItem, "QtySUnit") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item Unit Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblItemUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitName") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ROP Min" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "ROPMinSUnit") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ROP Max" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "ROPMaxSUnit") %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ROP Qty" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <%# IIf((DataBinder.Eval(Container.DataItem, "ROPMaxSUnit") - DataBinder.Eval(Container.DataItem, "QtySUnit")) > 0, (DataBinder.Eval(Container.DataItem, "ROPMaxSUnit") - DataBinder.Eval(Container.DataItem, "QtySUnit")), 0) %>
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
                                    </asp:Panel>
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
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/FormatNumber.js"></script>
</body>
</html>
