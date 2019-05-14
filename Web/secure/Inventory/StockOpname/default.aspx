<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Inventory.StockOpname"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Stock Opname</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
</head>
<body onload="ShowPosting();" ms_positioning="GridLayout">
    <script language="javascript">
        function ShowPosting() {
            if (typeof (Popup) !== 'undefined') {
                /*x = event.clientX + document.body.scrollLeft; */
                var lebar;
                var tinggi;
                tinggi = delpx(Popup.currentStyle.height);
                lebar = delpx(Popup.currentStyle.width);
                var x = (screen.availWidth - lebar) / 2;
                var y = (screen.availHeight - tinggi) / 2;
                /* get the mouse left position */
                /*y = event.clientY + document.body.scrollTop + 10; */
                /* get the mouse top position  */
                Popup.style.display = "block";
                /* display the pop-up */
                Popup.style.left = x;
                /* set the pop-up's left */
                Popup.style.top = y;
                /* set the pop-up's top */
            }
        }
    </script>
    <form runat="server">
    <asp:Panel ID="PnlApproved" runat="server">
        <div class="transparent" id="Popup" style="width: 50%">
            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                <tr>
                    <td class="center" style="background-color: Red; color: #ffffff; font-size: 20pt;">
                        APPROVED
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
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
                            Inventory
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Stock Opname
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="overflow: auto; width: 100%; height: 100%">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
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
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblStockOpnameID" runat="server" Text="Stock Opname ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxStockOpnameID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="True" MarkFirstMatch="true"
                                                                            Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="TxnNo"
                                                                            DataValueField="TxnNo" ShowDropDownOnTextboxClick="False">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "TxnNo") %>
                                                                                        </td>
                                                                                        <td style="width: 145px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "formatdate") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "status") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Stock Opname ID</b>
                                                                                        </td>
                                                                                        <td style="width: 145px;">
                                                                                            <b>Stock Opname Date</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Status</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblStockOpnameDateCaption" runat="server" Text="Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker ID="RadStockOpnameDate" runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="40%" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                        </telerik:RadDatePicker>
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
                                                                        <asp:DropDownList ID="ddlWhID" runat="Server" Width="70%" AutoPostBack="True" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblUnitIDCaption" runat="server" Text="Unit Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlUnitID" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDescriptionHdCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDescriptionHd" runat="server" MaxLength="500" Width="70%" TextMode="MultiLine"
                                                                            Height="40px" Style="font-size: 9pt; font-family: Tahoma"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="overflow: auto; width: 100%; height: 100%" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr style="display: none">
                                                        <td valign="top" width="100%">
                                                            <strong><b>Page :
                                                                <asp:Label ID="lblPageGrid" runat="server"></asp:Label>
                                                            </b></strong>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <telerik:RadGrid ID="RadGridStockOpname" runat="server" AutoGenerateColumns="False"
                                                                AllowSorting="True" PageSize="15" EnableAJAX="False" ShowStatusBar="true" AllowPaging="True"
                                                                AllowCustomPaging="True" GridLines="None" Skin="Windows7">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <MasterTableView>
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" Visible="True">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblNumberCaption" Text="No." />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblNumber" Text='<%# DataBinder.Eval(Container.DataItem, "Number") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" Visible="True">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblIDCaption" Text="No. Stock Opname" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" Visible="False">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblTxnNoCaption" Text="Stock Opname ID" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblTxnNo" Text='<%# DataBinder.Eval(Container.DataItem, "TxnNo") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" Visible="False">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemSeqNoCaption" Text="Item ID" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemIDCaption" Text="Item ID" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemNameCaption" Text="Item Name" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td>
                                                                                            <asp:Label runat="server" ID="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblDifferencesQtyCaption" Text="Differences Qty" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:TextBox ID="txtDifferencesQty" AutoPostBack="False" runat="server" Text='<%# IIF(DataBinder.Eval(Container.DataItem, "PlusOrMinus")="-", (DataBinder.Eval(Container.DataItem, "Qty") * -1), DataBinder.Eval(Container.DataItem, "Qty")) %>'
                                                                                                Style="text-align: right" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" Visible="False">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblPlusOrMinusCaption" Text="Plus or Minus" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblPlusOrMinus" Text='<%# DataBinder.Eval(Container.DataItem, "PlusOrMinus") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1" Visible="False">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblQtyRealCaption" Text="Qty Now" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblQtyReal" Text='<%# IIF(DataBinder.Eval(Container.DataItem, "PlusOrMinus")="-", (DataBinder.Eval(Container.DataItem, "Qty") * -1), DataBinder.Eval(Container.DataItem, "Qty")) %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblQtyNowCaption" Text="Qty Now" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblQtyNow" Text='<%# DataBinder.Eval(Container.DataItem, "QtyNow") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblItemUnitNameCaption" Text="Item Unit Name" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblItemUnitName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemUnitName") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn1">
                                                                            <HeaderTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblItemFactorCaption" Text="Item Factor" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <table width="100%">
                                                                                    <tr align="left">
                                                                                        <td align="Right">
                                                                                            <asp:Label runat="server" ID="_lblItemFactor" Text='<%# DataBinder.Eval(Container.DataItem, "ItemFactor") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
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
