<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="APInfo.aspx.vb" Inherits="Raven.Web.Secure.Inquiry.APInfo"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>A/P Information</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
</head>
<body onload="ShowPosting();" ms_positioning="GridLayout">
    <form runat="server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <table border="0" cellspacing="0" cellpadding="2" width="100%" height="100%">
        <tr>
            <td valign="top" width="80%">
                <table border="0" cellspacing="1" cellpadding="3" width="100%" height="100%">
                    <tr>
                        <td class="rheader" valign="middle" width="100%" align="left">
                            A/P Information:
                            <asp:Label ID="lblAPInfoType" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="overflow: auto; width: 100%; height: 100%">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <asp:Panel ID="PanelHeader" runat="server">
                                        <tr>
                                            <td valign="top" width="100%" colspan="2">
                                                <div id="REDiv">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblNo" runat="server" Text="Txn No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtNo" runat="server" Width="70%" Enabled="False" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDateCaption" runat="server" Text="Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtDate" runat="server" Width="70%" Enabled="False" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblEntitiesID" runat="server" Text="Supplier ID"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="EntitiesID"
                                                                                DataValueField="EntitiesSeqNo" ShowDropDownOnTextboxClick="False" Enabled="False">
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
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtEntitiesName" runat="server" Enabled="False" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblWhIDCaption" runat="server" Text="Warehouse Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlWhID" runat="Server" Width="70%" AutoPostBack="True" Enabled="False">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblUnitIDCaption" runat="server" Text="Unit Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlUnitID" runat="Server" Width="70%" Enabled="False">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblCurrencyCaption" runat="server" Text="Currency"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlCurrency" runat="Server" Width="70%" Enabled="False" AutoPostBack="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblCurrencyRateCaption" runat="server" Text="Currency Rate"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtCurrencyRate" runat="server" MaxLength="16" Style="text-align: right"
                                                                                Width="70%" Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblInvoiceNoCaption" runat="server" Text="Invoice No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="500" Width="70%" Enabled="False"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDescriptionHdCaption" runat="server" Text="Description"></asp:Label>
                                                                        </td>
                                                                        <td width="60%">
                                                                            <asp:TextBox ID="txtDescriptionHd" runat="server" MaxLength="500" Width="70%" TextMode="MultiLine"
                                                                                Height="40px" Style="font-size: 9pt; font-family: Tahoma" Enabled="False"></asp:TextBox>
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
                                            <td valign="top" width="100%" colspan="2">
                                                <div style="overflow: auto; width: 100%; height: 100%" id="RLDiv">
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <asp:DataGrid ID="RadGridInfo" runat="server" Style="width: 100%" CellPadding="1"
                                                                    ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                    BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                    <HeaderStyle CssClass="gridheaderstyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                    <ItemStyle CssClass="gridItemstyle" />
                                                                    <EditItemStyle Font-Bold="false" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="ID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Bonus">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="_chkIsBonus" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsBonus") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item Seq No" Visible="False">
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
                                                                                <asp:Label runat="server" ID="_lblQty" Text='<%# DataBinder.Eval(Container.DataItem, "Qty") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Item Factor" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblItemFactor" Text='<%# DataBinder.Eval(Container.DataItem, "ItemFactor") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Price" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblPrice" Text='<%# format(DataBinder.Eval(Container.DataItem, "Price"), "#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 1 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc1Pct" Text='<%# DataBinder.Eval(Container.DataItem, "Disc1Pct") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 1" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc1Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc1Amt"), "#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 2 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc2Pct" Text='<%# DataBinder.Eval(Container.DataItem, "Disc2Pct") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 2" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc2Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc2Amt"), "#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 3 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc3Pct" Text='<%# DataBinder.Eval(Container.DataItem, "Disc3Pct") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Discount 3" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDisc3Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc3Amt"), "#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"), "#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <br />
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
                                                            <td align="right" width="60%">
                                                                <asp:Label ID="lblDiscFinalPctCaption" runat="server" Text="Discount Final ( % )"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtDiscFinalPct" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Width="5%" Style="text-align: right" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td align="right" width="20%">
                                                                <asp:Label ID="lblDiscFinalAmtCaption" runat="server" Text="Discount Final"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtDiscFinalAmt" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:CheckBox ID="chkIsPPN" runat="server" Checked="False" AutoPostBack="true" Text="Tax ( % )">
                                                                </asp:CheckBox>
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtPPNpct" runat="server" ReadOnly="True" Text="0" MaxLength="16"
                                                                    Width="5%" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                            <td align="right" width="20%">
                                                                <asp:Label ID="lblPPNCaption" runat="server" Text="Tax"></asp:Label>
                                                                &nbsp;&nbsp;
                                                                <asp:TextBox ID="txtPPN" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                    Style="text-align: right"></asp:TextBox>
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
                                    </asp:Panel>
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
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/FormatNumber.js"></script>
</body>
</html>
