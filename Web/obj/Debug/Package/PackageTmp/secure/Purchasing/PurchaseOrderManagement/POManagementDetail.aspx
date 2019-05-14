<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="POManagementDetail.aspx.vb"
    Inherits="Raven.Web.Secure.Purchasing.POManagementDetail" EnableSessionState="true"
    EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>PO Management Detail</title>
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
            background: #cfe2fb;
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
                            <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
										<AjaxSettings>
											
										</AjaxSettings>
									</telerik:RadAjaxManager>--%>
                            <!-- END AJAX MANAGER -->
                            Purchase Order Detail
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
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                    <tr>
                                                        <td width="5%">
                                                            <asp:Label ID="lblPONOCaption" runat="server" Text="PO No."></asp:Label>
                                                        </td>
                                                        <td width="1%">
                                                            <asp:Label ID="lblmark1Caption" runat="server" Text=":"></asp:Label>
                                                        </td>
                                                        <td width="40%">
                                                            <asp:Label ID="lblPONO" runat="server"></asp:Label>
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
                                        <td valign="top" width="100%" height="100%" colspan="2">
                                            <div style="width: 100%; height: 300px; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <asp:DataGrid ID="RadGridPurchaseOrderManagementDetail" runat="server" Style="width: 100%"
                                                                CellPadding="1" ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None"
                                                                BorderWidth="1" BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False"
                                                                AllowSorting="True">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblAutoNo" Text='<%# DataBinder.Eval(Container.DataItem, "AutoNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty Ordered">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblQty" Text='<%# format(DataBinder.Eval(Container.DataItem, "Qty"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty Received">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblQtyReceived" Text='<%# format(DataBinder.Eval(Container.DataItem, "QtyReceived"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Price">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblPrice" Text='<%# format(DataBinder.Eval(Container.DataItem, "Price"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" Visible="false" HeaderText="Disc 1 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc1Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc1Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Disc 1" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc1Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc1Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" Visible="false" HeaderText="Disc 2 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc2Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc2Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Disc 2" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc2Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc2Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" Visible="false" HeaderText="Disc 3 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc3Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc3Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Disc 3" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblDisc3Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc3Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" Width="100%" ID="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Bonus">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" Width="100%" ID="_chkIsBonus" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsBonus") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Label ID="lblTotalCaption" runat="server" Text="Total"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtTotal" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblDiscFinalPctCaption" runat="server" Text="Discount Final ( % )"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDiscFinalPct" runat="server" AutoPostBack="True" MaxLength="16"
                                                                Text="0.00" Width="10%" Style="text-align: right" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                        <td align="right" width="40%">
                                                            <asp:Label ID="lblDiscFinalAmtCaption" runat="server" Text="Discount Final"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDiscFinalAmt" runat="server" AutoPostBack="True" MaxLength="16"
                                                                Text="0.00" Style="text-align: right" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:CheckBox ID="chkIsPPN" runat="server" Checked="False" AutoPostBack="true" Text="Tax ( % )"
                                                                Enabled="false"></asp:CheckBox>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtPPNpct" runat="server" ReadOnly="True" Text="0" MaxLength="16"
                                                                Width="10%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                        <td align="right" width="40%">
                                                            <asp:Label ID="lblPPNCaption" runat="server" Text="Tax"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtPPN" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Label ID="lblDPAmtCaption" runat="server" Text="DP Amount"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDPAmt" runat="server" MaxLength="16" AutoPostBack="True" Text="0.00"
                                                                Style="text-align: right" ReadOnly="true"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Label ID="lblGrandTotalCaption" runat="server" Text="Grand Total"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtGrandTotal" runat="server" ReadOnly="True" MaxLength="16" Text="0.00"
                                                                Style="text-align: right"></asp:TextBox>
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
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/FormatNumber.js"></script>
</body>
</html>
