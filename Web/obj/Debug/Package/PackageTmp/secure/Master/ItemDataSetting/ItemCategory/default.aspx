<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Master.ItemDataSetting.ItemCategory"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Item Category</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
</head>
<body ms_positioning="GridLayout" marginheight="0" marginwidth="0">
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
                            Item Category
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
                                                            <asp:Label ID="lblItemCategoryIDCaption" runat="server" Text="Item Category ID"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <telerik:RadComboBox ID="RadComboBoxItemCategoryID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                AllowCustomText="true" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                EnableLoadOnDemand="true" MarkFirstMatch="true" Width="65%" Height="190px" runat="server"
                                                                MaxLength="15" DataTextField="ItemCategoryID" DataValueField="ItemCategoryID"
                                                                Style="z-index: 0" ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "ItemCategoryID") %>
                                                                            </td>
                                                                            <td style="width: 150px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "ItemCategoryName") %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                Item Category ID
                                                                            </td>
                                                                            <td style="width: 150px;">
                                                                                Item Category Name
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td width="15%" style="display: none">
                                                            <asp:Label ID="lblSalesDiscountPctCaption" runat="server" Text="Sales Discount (%)"></asp:Label>
                                                        </td>
                                                        <td width="35%" style="display: none">
                                                            <asp:TextBox ID="txtSalesDiscountPct" runat="server" Width="30%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblItemCategoryNameCaption" runat="server" Text="Item Category Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtItemCategoryName" runat="server" Width="65%" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                        <td style="display: none">
                                                            <asp:Label ID="lblSalesDiscountAmtCaption" runat="server" Text="Sales Discount Amount"></asp:Label>
                                                        </td>
                                                        <td style="display: none">
                                                            <asp:TextBox ID="txtSalesDiscountAmt" runat="server" Width="30%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblSalesMarginPctCaption" runat="server" Text="Sales Margin (%)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSalesMarginPct" runat="server" Width="65%" MaxLength="16" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                        <td style="display: none">
                                                        </td>
                                                        <td style="display: none">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="500" Width="65%" TextMode="MultiLine"
                                                                Height="40px" Style="font-family: Tahoma; font-size: 9pt;"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkIsFormula" runat="server" Text="Formula"></asp:CheckBox>
                                                            &nbsp;
                                                            <asp:CheckBox ID="chkIsInventory" runat="server" Text="Inventory"></asp:CheckBox>
                                                            &nbsp;
                                                            <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
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
                                                            <asp:DataGrid ID="RadGridItemCategory" runat="server" Style="width: 100%" CellPadding="1"
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Category ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemCategoryID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Category Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Discount ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesDiscountPct" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesDiscountPct"), "#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Discount Amount" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesDiscountAmt" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesDiscountAmt"), "#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Formula" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsFormula" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsFormula") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Inventory" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsInventory" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsInventory") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Master/ItemDataSetting/ItemCategory/ItemSubCategory.aspx?" %>cid=<%# Trim(DataBinder.Eval(Container.DataItem, "ItemCategoryID")) %> ',null,800,600,'no')"
                                                                                title="Item Sub Category">
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
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
