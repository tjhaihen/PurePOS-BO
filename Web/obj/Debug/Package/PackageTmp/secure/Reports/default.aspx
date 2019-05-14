<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Reports"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Reports</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">

    <script src='/pureravenslib/scripts/common/util.js' language="javascript"></script>

    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>

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
                            <table cellspacing="1" cellpadding="0" width="100%">
                                <tr>
                                    <td valign="top" width="100%">
                                        <!-- BEGIN AJAX MANAGER -->
                                        <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings></AjaxSettings>
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
                        <td  height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%" height="100%" cellpadding="2" cellspacing="1" border="0">
                                    <tr>
                                        <td width="20%" height="100%" valign="top" >
                                            <table width="100%" height="100%">
                                                <!-- BEGIN REPORT EXPLORER SECTION -->
                                                <tr>
                                                    <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                                        <img style="cursor: hand" onclick="javascript:if (RExDiv.style.display == '') {RExDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RExDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                            alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                                    </td>
                                                    <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                                        &nbsp;
                                                        <asp:Label ID="lblReportExplorerCaption" runat="server" Text="Report Explorer"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="100%" height="100%" colspan="2">
                                                        <div id="RExDiv" style="width: 100%; height: 100%; overflow: auto">
                                                            <table cellspacing="1" cellpadding="2" width="100%" height="100%">
                                                                <tr>
                                                                    <td>
                                                                        <telerik:RadTreeView ID="RadTreeViewReportExplorer" runat="server" Width="100%" Height="100%"
                                                                            AutoPostBack="True">
                                                                        </telerik:RadTreeView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <!-- END REPORT EXPLORER SECTION -->
                                            </table>
                                        </td>
                                        <td width="80%" height="100%" valign="top" >
                                            <table width="100%" height="100%" cellspacing="1" cellpadding="5">
                                                <!-- BEGIN PARAMETER ENTRY SECTION -->
                                                <tr>
                                                    <td class="rheader" height="25px" colspan="2" width="100%">
                                                        <asp:Label ID="lblReportAsp" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblReportName" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblReportSP" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblReportCaption" runat="server"></asp:Label>&nbsp;
                                                        <asp:Label ID="lblReportID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="25" valign="middle" width="100%" colspan="2" align="left">
                                                        <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td  valign="top" width="100%" height="100%" colspan="2">
                                                        <div id="PEDiv" style="width: 100%; height: 100%; overflow: auto">
                                                            <table cellspacing="1" cellpadding="2" width="100%" height="100%">
                                                                <!-- START Report Parameter Panels Section -->
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:Panel ID="pnlPeriod" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Period
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblDateFrom" runat="server" Text="Date from" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="RadDateFrom" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                                            Culture="Marathi (India)">
                                                                                            <DateInput Width="100px" Font-Size="XSmall">
                                                                                            </DateInput>
                                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                                            </DatePopupButton>
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblDateTo" runat="server" Text="to" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="RadDateTo" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                                            Culture="Marathi (India)">
                                                                                            <DateInput Width="100px" Font-Size="XSmall">
                                                                                            </DateInput>
                                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                                            </DatePopupButton>
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlAnalysisDate" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Analysis Date
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblAnalysisDate" runat="server" Text="Analysis Date" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="RadAnalysisDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                                            Culture="Marathi (India)">
                                                                                            <DateInput Width="100px" Font-Size="XSmall">
                                                                                            </DateInput>
                                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif" ImageUrl="/pureravenslib/images/datepicker_popup.gif">
                                                                                            </DatePopupButton>
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlSupplier" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Supplier
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblSupplier" runat="server" Text="Supplier ID" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtSupplierID" runat="server" MaxLength="15" AutoPostBack="True"
                                                                                            Width="174px" />
                                                                                        <input type="Button" class="sbttn" value="..." style="width: 22px; height: 22px;"
                                                                                            onclick="javascript:NewWindow('<%= UrlBase + "/incl/SearchList.aspx?" %>cd=200&txt=txtSupplierID&default=SupplierName','_SearchList',700,460,'no','yes')">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlWarehouse" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Warehouse
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblWarehouse" runat="server" Text="Warehouse" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlWarehouse" runat="Server" Width="200px" AutoPostBack="True"
                                                                                            Enabled="True">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="lblUnit" runat="server" Text="Unit" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlUnit" runat="Server" Width="200px" Enabled="True">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlItem" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Item
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblItemFrom" runat="server" Text="Item ID from" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtItemIDFrom" runat="server" MaxLength="15" AutoPostBack="True"
                                                                                            Width="174px" />
                                                                                        <input type="Button" class="sbttn" value="..." style="width: 22px; height: 22px;"
                                                                                            onclick="javascript:NewWindow('<%= UrlBase + "/incl/SearchList.aspx?" %>cd=100&txt=txtItemIDFrom&default=ItemName','_SearchList',700,460,'no','yes')">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="lblItemTo" runat="server" Text="to" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtItemIDTo" runat="server" MaxLength="15" AutoPostBack="True" Width="174px" />
                                                                                        <input type="Button" class="sbttn" value="..." style="width: 22px; height: 22px;"
                                                                                            onclick="javascript:NewWindow('<%= UrlBase + "/incl/SearchList.aspx?" %>cd=100&txt=txtItemIDTo&default=ItemName','_SearchList',700,460,'no','yes')">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlSingleItem" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Item
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblItem" runat="server" Text="Item ID" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtItemID" runat="server" MaxLength="15" AutoPostBack="True" Width="174px" />
                                                                                        <input type="Button" class="sbttn" value="..." style="width: 22px; height: 22px;"
                                                                                            onclick="javascript:NewWindow('<%= UrlBase + "/incl/SearchList.aspx?" %>cd=100&txt=txtItemID&default=ItemName','_SearchList',700,460,'no','yes')">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlSortBy" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Sort By
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblSortBy" runat="server" Text="Sort By" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSortBy" runat="Server" Width="200px" AutoPostBack="False" Enabled="True">
                                                                                            <asp:ListItem Text="Nilai" Value="Nilai"></asp:ListItem>
                                                                                            <asp:ListItem Text="Qty" Value="Qty"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>                                                                                
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlSortDir" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Sort Direction
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblSortDirection" runat="server" Text="Sort Direction" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSortDirection" runat="Server" Width="200px" AutoPostBack="False" Enabled="True">
                                                                                            <asp:ListItem Text="Lowest to Highest" Value="ASC"></asp:ListItem>
                                                                                            <asp:ListItem Text="Highest to Lowest" Value="DESC"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>                                                                                
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlAllCashier" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        All Cashier
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:CheckBox ID="chkAllCashier" runat="server" Enabled="False" Checked="True" />
                                                                                    </td>
                                                                                    <td>                                                                                                                                                                                
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlByCashier" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" class="rheaderexpable" style="height: 24px; margin-left: 10px;">
                                                                                        Cashier
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120px" valign="top">
                                                                                        <asp:Label ID="lblCashierID" runat="server" Text="Cashier ID" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtCashierID" runat="server" MaxLength="15" Width="174px" Enabled="False" />                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="p1" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="40%" valign="top">
                                                                                        p1
                                                                                        <asp:TextBox ID="txtp1" runat="server" MaxLength="50" Width="95%" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="p2" runat="server" Visible="False">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="40%" valign="top">
                                                                                        p2
                                                                                        <asp:TextBox ID="txtp2" runat="server" MaxLength="50" Width="95%" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <!-- END Report Parameter Panels Section -->
                                                                <!-- START Report Viewing Panels Section -->
                                                                <tr>
                                                                    <td valign="top" height="50px">
                                                                        <asp:Panel ID="pnlRptView" runat="server" Visible="True">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td width="100%" valign="top">
                                                                                        <hr />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="100%" valign="top">
                                                                                        <asp:Label ID="lblRptView" runat="server" Text="How would you like to view the report?"
                                                                                            Style="font-weight: bold" /><br />
                                                                                        <br />
                                                                                        <asp:DropDownList ID="ddlRptView" runat="server" Width="200px">
                                                                                            <asp:ListItem Value="LD" Text="Less Detail"></asp:ListItem>
                                                                                            <asp:ListItem Value="MD" Text="More Detail"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>
                                                                    </td>
                                                                </tr>
                                                                <!-- END Report Viewing Panels Section -->
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <!-- END PARAMETER ENTRY SECTION -->
                                            </table>
                                        </td>
                                    </tr>
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

    <script src='/pureravenslib/scripts/common/common.vbs' language="vbscript"></script>

    <script src='/pureravenslib/scripts/common/common.js' language="javascript"></script>

</body>
</html>
