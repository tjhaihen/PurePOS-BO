<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Master.ItemDataSetting.ItemCatalogue"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Item Catalogue</title>
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
                                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableOutsideScripts="True">
                                            <AjaxSettings>
                                            </AjaxSettings>
                                        </telerik:RadAjaxManager>
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
                            Item Catalogue
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
                                                            <asp:TextBox ID="txtID" runat="server" Style="display: none"></asp:TextBox>
                                                            <asp:Label ID="lblEntitiesIDCaption" runat="server" Text="Supplier ID"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <telerik:RadComboBox ID="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                AllowCustomText="True" Width="65%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="EntitiesID"
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
                                                                                <b>Supplier ID</b>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <b>Supplier Seq No.</b>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <b>Supplier Name</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                        <td width="10%">
                                                            <asp:Label ID="lblItemUnitIDCaption" runat="server" Text="Item Unit"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <asp:DropDownList ID="ddlItemUnitID" runat="Server" Width="65%" AutoPostBack="True"
                                                                Enabled="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtEntitiesName" runat="server" ReadOnly="True" Width="65%"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblItemFactorCaption" runat="server" Text="Item Factor"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtItemFactor" runat="server" MaxLength="16" Style="text-align: right"
                                                                Width="65%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblItemSeqNo" runat="server" Text="Item ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="RadComboBoxItemSeqNo" ShowMoreResultBox="false" AutoPostBack="True"
                                                                AllowCustomText="True" Width="65%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="ItemID"
                                                                DataValueField="ItemSeqNo" ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
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
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
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
                                                        <td>
                                                            <asp:Label ID="lblStartingDateCaption" runat="server" Text="Valid From Date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="RadStartingDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                Culture="Marathi (India)">
                                                                <DateInput Width="30%" Font-Size="XSmall">
                                                                </DateInput>
                                                                <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                </DatePopupButton>
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblItemNameCaption" runat="server" Text="Item Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtItemName" runat="server" ReadOnly="True" Width="65%"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUnitPriceCaption" runat="server" Text="Unit Price"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnitPrice" runat="server" onblur="FormatCurrency(this);" ReadOnly="False"
                                                                MaxLength="15" Style="text-align: right" Width="65%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="65%" TextMode="MultiLine"
                                                                Height="40px" Style="font-family: Tahoma; font-size: 9pt;" MaxLength="500"></asp:TextBox>
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
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List for Selected Supplier"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 300px; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridItemCatalogue" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="ID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblIDDt" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Unit">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Factor">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemFactor" Text='<%# DataBinder.Eval(Container.DataItem, "ItemFactor") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Valid From Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblValidFromDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "StartingDate"), "dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Unit Price">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemUnitPrice" Text='<%# Format(DataBinder.Eval(Container.DataItem, "Price"), "#,##0.00") %>' />
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
