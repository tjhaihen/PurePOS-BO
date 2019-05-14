<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserGroupAuthority.aspx.vb"
    Inherits="Raven.Web.Secure.Administrator.UserGroupAuthority" EnableSessionState="true"
    EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>User Group Authority</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
    <style>
        BODY
        {
            overflow: hidden;
        }
    </style>
</head>
<body onload="center();">
    <form runat="server">
    <table border="0" cellspacing="0" cellpadding="2" width="100%" height="100%">
        <tr>
            <td valign="top" width="80%">
                <table border="0" cellspacing="1" cellpadding="3" width="100%" height="100%">
                    <tr>
                        <td class="rheader" valign="middle" width="100%" align="left">
                            <!-- BEGIN AJAX MANAGER -->
                            <%--<telerik:RadScriptManager ID="ScriptManager" runat="server" />--%>
                            <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
										<AjaxSettings>
											<telerik:AjaxSetting AjaxControlID="RadToolbar">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadGridMenu" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridReport" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridWarehouseUnit" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridInventoryTxn" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>																							
										</AjaxSettings>
									</telerik:RadAjaxManager>--%>
                            <!-- END AJAX MANAGER -->
                            User Group Authority:
                            <asp:Label ID="lblUserGroupID" runat="server" />
                            [<asp:Label ID="lblUserGroupName" runat="server" />]
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
                                    <!-- START MENU AUTHORITY -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (MADiv.style.display == '') {MADiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {MADiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblMenuAuthorityCaption" runat="server" Text="Menu Authority"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" height="100%" colspan="2">
                                            <div id="MADiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridMenu" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridHeaderStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllMenu" id="chkSelectAllMenu" type="checkbox" onclick="javascript:checkAllv2(this.form,'_chkIsAuthorized', 'chkSelectAllMenu');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%--																				<asp:CheckBox runat="server" id="_chkIsAuthorized" enabled="True" Checked='<%# DataBinder.Eval(Container.DataItem, "IsAuthorized") %>'/>--%>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAuthorized" Enabled="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Menu ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblMenuID" Text='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Parent Menu ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblParentMenuID" Text='<%# DataBinder.Eval(Container.DataItem, "ParentMenuID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Description">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblMenuDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Read">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowRead" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowRead") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Add">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowAdd" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowAdd") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowEdit" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowEdit") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowDelete" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowDelete") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Approve">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowApprove" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowApprove") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Void">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowVoid" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowVoid") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Print">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsAllowPrint" Checked='<%# DataBinder.Eval(Container.DataItem, "isAllowPrint") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <!-- EMPTY SPACE -->
                                                    <tr>
                                                        <td height="20px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END MENU AUTHORITY -->
                                    <!-- START REPORT AUTHORITY -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RADiv.style.display == '') {RADiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RADiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblReportAuthorityCaption" runat="server" Text="Report Authority"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" height="100%" colspan="2">
                                            <div id="RADiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridReport" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridHeaderStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllReport" id="chkSelectAllReport" type="checkbox" onclick="javascript:checkAllv2(this.form,'_chkIsReportAuthorized', 'chkSelectAllReport');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsReportAuthorized" Enabled="True" Checked='<%# DataBinder.Eval(Container.DataItem, "IsAuthorized") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Report ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblReportID" Text='<%# DataBinder.Eval(Container.DataItem, "ReportID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Parent Report ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblParentReportID" Text='<%# DataBinder.Eval(Container.DataItem, "ParentReportID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Report Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblReportCaption" Text='<%# DataBinder.Eval(Container.DataItem, "ReportCaption") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <!-- EMPTY SPACE -->
                                                    <tr>
                                                        <td height="20px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END REPORT AUTHORITY -->
                                    <!-- START WAREHOUSE AND UNIT AUTHORITY -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (WUDiv.style.display == '') {WUDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {WUDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblWarehouseUnitAuthorityCaption" runat="server" Text="Warehouse and Unit Authority"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" height="100%" colspan="2">
                                            <div id="WUDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridWarehouseUnit" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridHeaderStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllWarehouseUnit" id="chkSelectAllWarehouseUnit" type="checkbox"
                                                                                onclick="javascript:checkAllv2(this.form,'_chkIsWarehouseUnitAuthorized', 'chkSelectAllWarehouseUnit');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsWarehouseUnitAuthorized" Enabled="True" Checked='<%# DataBinder.Eval(Container.DataItem, "IsAuthorized") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Warehouse ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblWhID" Text='<%# DataBinder.Eval(Container.DataItem, "WhID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUnitID" Text='<%# DataBinder.Eval(Container.DataItem, "UnitID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Warehouse Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblWhName" Text='<%# DataBinder.Eval(Container.DataItem, "WhName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "UnitName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <!-- EMPTY SPACE -->
                                                    <tr>
                                                        <td height="20px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END WAREHOUSE AND UNIT AUTHORITY -->
                                    <!-- START INVENTORY TRANSACTION AUTHORITY -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (ITDiv.style.display == '') {ITDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {ITDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblInventoryTransactionAuthorityCaption" runat="server" Text="Inventory Transaction Authority"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" height="100%" colspan="2">
                                            <div id="ITDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridInventoryTxn" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridHeaderStyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllInventoryTransaction" id="chkSelectAllInventoryTransaction"
                                                                                type="checkbox" onclick="javascript:checkAllv2(this.form,'_chkIsInventoryTransactionAuthorized', 'chkSelectAllInventoryTransaction');">
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblInventoryTxnID" Text='<%# DataBinder.Eval(Container.DataItem, "InventoryTxnID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Inventory Transaction Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblInventoryTxnName" Text='<%# DataBinder.Eval(Container.DataItem, "InventoryTxnName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <!-- EMPTY SPACE -->
                                                    <tr>
                                                        <td height="20px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END INVENTORY TRANSACTION AUTHORITY -->
                                    <!-- END FORM SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
