<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Inquiry.SalesUnitInquiryandReprint"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Sales Unit Inquiry and Re-Print</title>
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
                            Inquiry
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Sales Unit Inquiry and Re-Print
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
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
                                                                    <td width="5%">
                                                                        <asp:Label ID="lblFilterByCaption" runat="server" Text="Filter by"></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <asp:DropDownList ID="ddlFilter" runat="server" Width="150px">
                                                                            <asp:ListItem Value="ReceiptDate">Receipt Date</asp:ListItem>
                                                                            <asp:ListItem Value="ReceiptNo">Receipt No.</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesName">Customer Name</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesID">Customer ID</asp:ListItem>
                                                                            <asp:ListItem Value="MemberNo">Member No.</asp:ListItem>
                                                                            <asp:ListItem Value="ItemName">Item Name</asp:ListItem>
                                                                            <asp:ListItem Value="ItemID">Item ID</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtFilter" runat="server" Text="*" Width="20%" />
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none;">
                                                                    <td width="5%">
                                                                        <asp:Label ID="lblFilterThenBy1Caption" runat="server" Text="Then by"></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <asp:DropDownList ID="ddlFilterThen1" runat="server" Width="150px">
                                                                            <asp:ListItem Value="ReceiptDate">Receipt Date</asp:ListItem>
                                                                            <asp:ListItem Value="ReceiptNo">Receipt No.</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesName">Customer Name</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesID">Customer ID</asp:ListItem>
                                                                            <asp:ListItem Value="MemberNo">Member No.</asp:ListItem>
                                                                            <asp:ListItem Value="ItemName">Item Name</asp:ListItem>
                                                                            <asp:ListItem Value="ItemID">Item ID</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtFilterThen1" runat="server" Text="*" Width="20%" />
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none;">
                                                                    <td width="5%">
                                                                        <asp:Label ID="lblFilterThenBy2Caption" runat="server" Text="Then by"></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <asp:DropDownList ID="ddlFilterThen2" runat="server" Width="150px">
                                                                            <asp:ListItem Value="ReceiptDate">Receipt Date</asp:ListItem>
                                                                            <asp:ListItem Value="ReceiptNo">Receipt No.</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesName">Customer Name</asp:ListItem>
                                                                            <asp:ListItem Value="EntitiesID">Customer ID</asp:ListItem>
                                                                            <asp:ListItem Value="MemberNo">Member No.</asp:ListItem>
                                                                            <asp:ListItem Value="ItemName">Item Name</asp:ListItem>
                                                                            <asp:ListItem Value="ItemID">Item ID</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtFilterThen2" runat="server" Text="*" Width="20%" />
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
                                                            <asp:DataGrid ID="RadGridSalesUnit" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Unit No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesUnitNo" Text='<%# DataBinder.Eval(Container.DataItem, "STxnNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesUnitDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "STxnDate"),"dd-MMM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="DO No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDONo" Text='<%# DataBinder.Eval(Container.DataItem, "DONo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Receipt No.">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblReceiptNo" Text='<%# DataBinder.Eval(Container.DataItem, "ReceiptNo") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak">
                                                                                        <asp:Label runat="server" ID="_lblCustomerName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Member No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblMemberNo" Text='<%# DataBinder.Eval(Container.DataItem, "MemberNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Total" HeaderStyle-HorizontalAlign="right"
                                                                        ItemStyle-HorizontalAlign="right" HeaderStyle-Width="120px" ItemStyle-Width="120px">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "PurchaseTotal"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="#Print" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                                                                        HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPrintCountTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "PrintCounts"),"#,##0") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Last Print By" HeaderStyle-HorizontalAlign="right"
                                                                        ItemStyle-HorizontalAlign="right">
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td style="text-align: right;">
                                                                                        <asp:Label runat="server" ID="_lblLastPrintBy" Text='<%# DataBinder.Eval(Container.DataItem, "UserUpdate") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txtweak" style="text-align: right;">
                                                                                        <asp:Label runat="server" ID="_lblLastPrintDate" Text='<%# DataBinder.Eval(Container.DataItem, "LastPrintDate") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="" Visible="false">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Inquiry/SalesUnitDetailInquiry.aspx?" %>stxn=<%# Trim(DataBinder.Eval(Container.DataItem, "STxnNo")) %> ',null,800,600,'no')"
                                                                                title="Sales Unit Detail">
                                                                                <img src='/pureravenslib/images/detail.png' border='0' align='absmiddle' />
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton runat="server" ID="__ibtnPrint" CausesValidation="False" ImageUrl="/pureravenslib/images/print.png"
                                                                                alt="Print or Reprint Sales Receipt" CommandName="__PrintReceipt" />
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
