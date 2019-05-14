<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Master.Warehouse"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Warehouse</title>
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
                                        <%--												<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
														<telerik:AjaxSetting AjaxControlID="RadToolbar">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxWarehouseID"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblWarehouseNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblUnitNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtUnitName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridWarehouse" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxWarehouseID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblWarehouseNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblUnitNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtUnitName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridWarehouse" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxUnitID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="lblUnitNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtUnitName"></telerik:AjaxUpdatedControl>																
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridWarehouse">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxWarehouseID"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblWarehouseNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWarehouseID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblUnitNameCaption"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtUnitName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lblDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridWarehouse" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
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
                            Warehouse
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
                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="lblWarehouseIDCaption" runat="server" Text="Warehouse ID"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <telerik:RadComboBox ID="RadComboBoxWarehouseID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                AllowCustomText="true" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                EnableLoadOnDemand="true" MarkFirstMatch="true" Width="65%" Height="190px" runat="server"
                                                                Skin="WebBlue" MaxLength="15" DataTextField="WhName" DataValueField="WhID" Style="z-index: 0"
                                                                ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
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
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
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
                                                        <td width="10%">
                                                            <asp:Label ID="lblUnitIDCaption" runat="server" Text="Unit ID"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <telerik:RadComboBox ID="RadComboBoxUnitID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                AllowCustomText="true" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                EnableLoadOnDemand="true" MarkFirstMatch="true" Width="65%" Height="190px" runat="server"
                                                                Skin="WebBlue" MaxLength="15" DataTextField="UnitName" DataValueField="UnitID"
                                                                Style="z-index: 0" ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "UnitID") %>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "UnitName") %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
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
                                                        <td>
                                                            <asp:Label ID="lblWarehouseNameCaption" runat="server" Text="Warehouse Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtWarehouseName" runat="server" Width="65%" MaxLength="500"></asp:TextBox>
                                                            <asp:TextBox ID="txtWarehouseID" runat="server" Width="65%" Style="display: none"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUnitNameCaption" runat="server" Text="Unit Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitName" runat="server" Width="65%" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                                                        </td>
                                                        <td valign="top">
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="65%" TextMode="MultiLine"
                                                                Height="40px" Style="font-family: Tahoma; font-size: 9pt;" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                        <td valign="top">
                                                            <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (ROPDiv.style.display == '') {ROPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {ROPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblROPListCaption" runat="server" Text="Re-Order Point [ROP] Setting"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%;" id="ROPDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle" style="height: 20px">
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" class="my_toolbarbutton" Text=".::"
                                                                            CausesValidation="false" Enabled="False" Style="color: black; text-decoration: none;
                                                                            font-weight: bold"></asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnSaveROP" class="my_toolbarbutton" Text="Save ROP"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                                                        <asp:LinkButton runat="server" ID="lbtnShowROP" class="my_toolbarbutton" Text="Show Active ROP"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none"></asp:LinkButton>
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
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
                                                        <td valign="top" colspan="2">
                                                            <asp:DataGrid ID="RadGridROP" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="100px" HeaderText="ROP-Min"
                                                                        ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="_txtROPMin" runat="server" CssClass="right" Width="100" Text='<%# DataBinder.Eval(Container.DataItem, "ROPMinSUnit") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="100px" HeaderText="ROP-Max"
                                                                        ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="_txtROPMax" runat="server" CssClass="right" Width="100" Text='<%# DataBinder.Eval(Container.DataItem, "ROPMaxSUnit") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="100px" HeaderText="Item S Unit"
                                                                        ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "ItemSUnitID") %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>                                                                    
                                                                    <asp:TemplateColumn runat="server" HeaderText="Description" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <table width="600px">
                                                                                <tr>
                                                                                    <td>
                                                                                        <%# DataBinder.Eval(Container.DataItem, "ItemName") %>
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
                                                                    <asp:TemplateColumn runat="server" HeaderStyle-Width="150px" HeaderText="Item Seq. No."
                                                                        ItemStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>' />
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
                                                            <asp:DataGrid ID="RadGridWarehouse" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Warehouse ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblWarehouseID" Text='<%# DataBinder.Eval(Container.DataItem, "WhID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Warehouse Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblWarehouseName" Text='<%# DataBinder.Eval(Container.DataItem, "WhName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "UnitID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "Unitname") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
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
                            <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
