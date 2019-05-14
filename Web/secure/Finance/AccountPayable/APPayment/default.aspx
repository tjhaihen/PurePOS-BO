<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Finance.AccountPayable.APPayment"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>A/P Payment</title>
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
    <asp:Panel ID="PnlVoid" runat="server">
        <div class="transparent" id="Popup" style="width: 50%">
            <table cellpadding="2" cellspacing="1" style="background-color: Red;">
                <tr>
                    <td class="center" style="background-color: Red; color: #ffffff; font-size: 20pt;">
                        VOID
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="PnlApproved" runat="server">
        <div class="transparent" id="Div1" style="width: 50%">
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
                            Finance
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Account Payable
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            A/P Payment
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
                                                <asp:Label ID="lblRecordHeaderEntryCaption" runat="server" Text="Record Header Entry"></asp:Label>
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
                                                                            <asp:Label ID="lblAPPaymentID" runat="server" Text="A/P Payment No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxAPPaymentID" ShowMoreResultBox="False" AutoPostBack="true"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="200px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="APPaymentNo"
                                                                                DataValueField="APPaymentNo" ShowDropDownOnTextboxClick="True">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                        cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 120px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "APPaymentNo") %>
                                                                                            </td>
                                                                                            <td style="width: 100px;">
                                                                                                <%# format(DataBinder.Eval(Container.DataItem, "APPaymentDate"),"dd-MM-yyyy") %>
                                                                                            </td>
                                                                                            <td style="width: 200px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
                                                                                            </td>
                                                                                            <td style="width: 50px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "Status") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                        cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 120px;">
                                                                                                <b>AP Payment No.</b>
                                                                                            </td>
                                                                                            <td style="width: 100px;">
                                                                                                <b>Date</b>
                                                                                            </td>
                                                                                            <td style="width: 200px;">
                                                                                                <b>Supplier</b>
                                                                                            </td>
                                                                                            <td style="width: 50px;">
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
                                                                            <asp:Label ID="lblAPPaymentDateCaption" runat="server" Text="Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadDatePicker ID="RadAPPaymentDate" runat="server" MinDate="2006-01-01"
                                                                                SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                                <DateInput Width="40%" Font-Size="XSmall">
                                                                                </DateInput>
                                                                                <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                    ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                            </telerik:RadDatePicker>
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
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtEntitiesName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblAmountCaption" runat="server" Text="Amount"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtAmount" runat="server" ReadOnly="True" MaxLength="16" Style="text-align: right"
                                                                                onblur="FormatCurrency(this);" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblCurrencyCaption" runat="server" Text="Currency"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlCurrency" runat="Server" AutoPostBack="True" Width="70%"
                                                                                Enabled="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblCurrencyRateCaption" runat="server" Text="Currency Rate"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtCurrencyRate" runat="server" MaxLength="16" Style="text-align: right"
                                                                                onblur="FormatCurrency(this);" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDocumentNoCaption" runat="server" Text="Document No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtDocumentNo" runat="server" ReadOnly="False" Width="70%" MaxLength="500"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDocumentDateCaption" runat="server" Text="Document Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadDatePicker ID="RadDocumentDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                                Culture="Marathi (India)">
                                                                                <DateInput Width="40%" Font-Size="XSmall">
                                                                                </DateInput>
                                                                                <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                    ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                            </telerik:RadDatePicker>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblAPPaymentTypeIDCaption" runat="server" Text="A/P Payment Type"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlAPPaymentTypeID" runat="Server" AutoPostBack="True" Width="70%"
                                                                                Enabled="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblBankIDCaption" runat="server" Text="Bank"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:DropDownList ID="ddlBankID" runat="Server" AutoPostBack="True" Width="70%" Enabled="True">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblBankAccountNoCaption" runat="server" Text="Bank Account No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtBankAccountNo" runat="server" ReadOnly="False" Width="70%" MaxLength="500"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblBankGiroNoCaption" runat="server" Text="Bank Giro No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtBankGiroNo" runat="server" ReadOnly="False" Width="70%" MaxLength="500"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblBankGiroSerialNoCaption" runat="server" Text="Bank Giro Serial No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtBankGiroSerialNo" runat="server" ReadOnly="False" Width="70%"
                                                                                MaxLength="500"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblBankGiroGroupNoCaption" runat="server" Text="Bank Giro Group No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtBankGiroGroupNo" runat="server" ReadOnly="False" Width="70%"
                                                                                MaxLength="500"></asp:TextBox>
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
                                    <asp:Panel ID="PanelGrid" runat="server">
                                        <tr>
                                            <td valign="top" width="100%" colspan="2">
                                                <div style="overflow: auto; width: 100%; height: 100%" id="RLDiv">
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td class="rheadercol" valign="middle" width="100%" align="left" colspan="2">
                                                                Outstanding A/P
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <asp:DataGrid ID="RadGridAPVerified" runat="server" Style="width: 100%" CellPadding="1"
                                                                    ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                    BorderColor="Gainsboro" CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                    <HeaderStyle CssClass="gridheaderstyle" />
                                                                    <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                    <ItemStyle CssClass="gridItemstyle" />
                                                                    <EditItemStyle Font-Bold="false" />
                                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                    <Columns>
                                                                        <asp:TemplateColumn runat="server" HeaderText="">
                                                                            <HeaderTemplate>
                                                                                <input name="chkSelectAllItems" id="chkSelectAllItems" type="checkbox" onclick="javascript:checkAllv2(this.form,'_chkpayment', 'chkSelectAllItems');">
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox runat="server" ID="_chkpayment" Enabled="True" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Voucher No.">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblVoucherNo" Text='<%# DataBinder.Eval(Container.DataItem, "VoucherNo") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" Style="margin-left: 0; margin-right: 5; display: none;"
                                                                                    ID="_lblVoucherDate" Text='<%# DataBinder.Eval(Container.DataItem, "VoucherDate") %>' />
                                                                                <asp:Label runat="server" ID="_lblFormatedVoucherDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "VoucherDate"), "dd-MM-yyyy") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Due Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblDueDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "DueDate"), "dd-MM-yyyy") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="n Payment">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblnAPPayment" Text='<%# DataBinder.Eval(Container.DataItem, "nAPPayment") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Currency Rate" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblCurrencyRate" Text='<%# DataBinder.Eval(Container.DataItem, "CurrencyRate") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblTotalAmtVoucher" Text='<%# format(DataBinder.Eval(Container.DataItem, "TotalAmtVoucher"),"#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblPaidAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "PaidAmount"),"#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Balance Due" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="_lblbalancedue" Text='<%# format(DataBinder.Eval(Container.DataItem, "TotalAmtVoucher") - DataBinder.Eval(Container.DataItem, "PaidAmount"),"#,##0.00") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn runat="server" HeaderText="Payment" ItemStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-HorizontalAlign="Right">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="_txtpayment" AutoPostBack="False" runat="server" Text='<%# format(DataBinder.Eval(Container.DataItem, "TotalAmtVoucher") - DataBinder.Eval(Container.DataItem, "PaidAmount"),"#,##0.00")  %>'
                                                                                    Style="text-align: right" onblur="FormatCurrency(this);" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <br>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </asp:Panel>
                                    <!-- END RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" valign="middle" width="100%" align="left" colspan="2">
                                            Paid A/P
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="overflow: auto; width: 100%; height: 100%" id="RLDivP">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <asp:DataGrid ID="RadGridAPPayment" runat="server" Style="width: 100%" CellPadding="1"
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
                                                                            <asp:LinkButton ID="_lbtnDelete" runat="server" CommandName="Delete" Text="<img src='/pureravenslib/images/Delete.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Delete record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="ID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblIDP" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Payment No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAPPaymentNo" Text='<%# DataBinder.Eval(Container.DataItem, "APPaymentNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Voucher No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAVoucherNo" Text='<%# DataBinder.Eval(Container.DataItem, "VoucherNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblFormatedVoucherDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "VoucherDate"), "dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Due Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDueDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "DueDate"), "dd-MM-yyyy") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="n Payment">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblnAPPaymentP" Text='<%# DataBinder.Eval(Container.DataItem, "nAPPayment") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Currency Rate" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblCurrencyRateIE" Text='<%# format(DataBinder.Eval(Container.DataItem, "CurrencyRateIE"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Foreign Exchange" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblForeignExchange" Text='<%# format(DataBinder.Eval(Container.DataItem, "ForeignExchange"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Amount" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "Amount"),"#,##0.00") %>' />
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
        RangeMinDate="2011/04/01">
    </telerik:RadCalendar>
    <asp:PlaceHolder ID="sharedCalendarPlaceHolder" runat="server"></asp:PlaceHolder>
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/FormatNumber.js"></script>
</body>
</html>
