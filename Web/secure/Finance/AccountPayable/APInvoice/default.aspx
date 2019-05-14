<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Finance.AccountPayable.APInvoice"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>A/P Invoice</title>
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
														<telerik:AjaxSetting AjaxControlID="ddlCurrency">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtCurrencyRate"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="chkIsPPN">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtPPN"></telerik:AjaxUpdatedControl>		
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDeliveryFee">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryFee"></telerik:AjaxUpdatedControl>		
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtStampDutyFee">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtStampDutyFee"></telerik:AjaxUpdatedControl>		
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtBankAdmFee">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtBankAdmFee"></telerik:AjaxUpdatedControl>		
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
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
                            Finance
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Account Payable
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            A/P Invoice
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
                                                                            <asp:Label ID="lblVoucherNo" runat="server" Text="Voucher No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadComboBox ID="RadComboBoxVoucherNo" ShowMoreResultBox="False" AutoPostBack="true"
                                                                                AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                                Height="200px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="VoucherNo"
                                                                                DataValueField="VoucherNo" ShowDropDownOnTextboxClick="True">
                                                                                <ItemTemplate>
                                                                                    <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                        cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 120px;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "VoucherNo") %>
                                                                                            </td>
                                                                                            <td style="width: 100px;">
                                                                                                <%# format(DataBinder.Eval(Container.DataItem, "VoucherDate"),"dd-MM-yyyy") %>
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
                                                                                                <b>Voucher No.</b>
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
                                                                            <asp:Label ID="lblRadVoucherDateCaption" runat="server" Text="Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadDatePicker ID="RadVoucherDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
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
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblInvoiceNoCaption" runat="server" Text="Supplier Invoice No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="500" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDueDateCaption" runat="server" Text="Due Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadDatePicker ID="RadDueDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
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
                                                                            <asp:TextBox ID="txtCurrencyRate" runat="server" ReadOnly="True" MaxLength="16" Style="text-align: right"
                                                                                onblur="FormatCurrency(this);" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top" width="33%">
                                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblRadTaxDateCaption" runat="server" Text="Tax Invoice Date"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <telerik:RadDatePicker ID="RadTaxDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
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
                                                                            <asp:Label ID="lblTaxInvoiceNoCaption" runat="server" Text="Tax Invoice No."></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
                                                                            <asp:TextBox ID="txtTaxInvoiceNo" runat="server" MaxLength="500" Width="70%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="30%">
                                                                            <asp:Label ID="lblDescriptionHdCaption" runat="server" Text="Description"></asp:Label>
                                                                        </td>
                                                                        <td width="70%">
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
                                    </asp:Panel>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <asp:Panel ID="PanelGrid" runat="server">
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
                                                        <tr>
                                                            <td class="rheader" valign="middle" width="100%" align="Center" colspan="2">
                                                                Purchase Unit in this Voucher
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <!--#include file="RadGridPurchaseUnit.incl.aspx" -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <br>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="rheader" valign="middle" width="100%" align="Center" colspan="2">
                                                                Credit Note in this Voucher
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <!--#include file="RadGridCreditNote.incl.aspx" -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <br>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="rheader" valign="middle" width="100%" align="Center" colspan="2">
                                                                Down Payment in this Voucher
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <!--#include file="RadGridDPAmount.incl.aspx" -->
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <br>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblTotalCaption" runat="server" Text="Total"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtTotal" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                    Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:CheckBox ID="chkIsPPN" runat="server" Checked="False" AutoPostBack="true" Text="Tax ( % )">
                                                                </asp:CheckBox>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtPPNpct" runat="server" ReadOnly="True" Text="0" MaxLength="16"
                                                                    Width="5%" Style="text-align: right"></asp:TextBox>
                                                                &nbsp;
                                                                <asp:Label ID="lblPPNCaption" runat="server" Text="Tax"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtPPN" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                    Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblDeliveryFeeCaption" runat="server" Text="Delivery Fee"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtDeliveryFee" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblStampDutyFeeCaption" runat="server" Text="Stamp Duty Fee"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtStampDutyFee" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblBankAdmFeeCaption" runat="server" Text="Bank Adm Fee"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtBankAdmFee" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblCNAmountCaption" runat="server" Text="CN Amount"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtCNAmount" runat="server" AutoPostBack="True" ReadOnly="True"
                                                                    MaxLength="16" Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblDPAmtCaption" runat="server" Text="DP Amount"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtDPAmt" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblRoundingAmtCaption" runat="server" Text="Rounding"></asp:Label>
                                                                &nbsp;
                                                                <asp:TextBox ID="txtRoundingAmt" runat="server" AutoPostBack="True" MaxLength="16"
                                                                    Text="0.00" Style="text-align: right"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2">
                                                                <asp:Label ID="lblGrandTotalCaption" runat="server" Text="Grand Total"></asp:Label>
                                                                &nbsp;
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
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <asp:Panel ID="PanelGridGet" runat="server">
                                        <tr>
                                            <td valign="top" align="left" colspan="3" width="100%">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                    <tr>
                                                        <td width="1" class="my_toolbarbutton_left">
                                                        </td>
                                                        <td valign="middle">
                                                            <asp:LinkButton runat="server" ID="lbtnSaveGet" class="my_toolbarbutton" CausesValidation="false"
                                                                Style="color: black; text-decoration: none; text-align: center;" Text="Save"
                                                                Width="80px">
																	Save	
                                                            </asp:LinkButton>
                                                            <img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle" height="20" />
                                                            <asp:LinkButton runat="server" ID="lbtnCancelGet" class="my_toolbarbutton" CausesValidation="false"
                                                                Style="color: black; text-decoration: none; text-align: center;" Text="Cancel"
                                                                Width="80px">
																	Cancel
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td width="1" class="my_toolbarbutton_right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" width="100%" colspan="2">
                                                <div style="overflow: auto; width: 100%; height: 100%" id="RLDiv">
                                                    <table cellspacing="0" cellpadding="0" width="100%">
                                                        <tr>
                                                            <td valign="top" width="100%" colspan="2">
                                                                <asp:Panel ID="PanelGridGetPU" runat="server">
                                                                    <!--#include file="RadGridGetPU.incl.aspx" -->
                                                                </asp:Panel>
                                                                <asp:Panel ID="PanelGridGetCN" runat="server">
                                                                    <!--#include file="RadGridGetCN.incl.aspx" -->
                                                                </asp:Panel>
                                                                <asp:Panel ID="PanelGridGetDP" runat="server">
                                                                    <!--#include file="RadGridGetDP.incl.aspx" -->
                                                                </asp:Panel>
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
