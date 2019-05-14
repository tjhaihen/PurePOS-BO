<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Purchasing.PurchaseOrder"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Purchase Order</title>
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
														
														
														<telerik:AjaxSetting AjaxControlID="lbtnNewDetail">
															<UpdatedControls>																
																<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtItemName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsBonus"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlItemUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtItemFactor"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescriptiondt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														
														<telerik:AjaxSetting AjaxControlID="chkIsPPN">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtPPN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDPAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDiscFinalPct">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalPct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPPN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDPAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDiscFinalAmt">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalPct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPPN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDPAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDPAmt">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDPAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlWhID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="ddlUnitID"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="chkIsBonus">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlCurrency">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtCurrencyRate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														<telerik:AjaxSetting AjaxControlID="ddlItemUnitID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtItemFactor"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridPurchaseOrder">
															<UpdatedControls>
															    <telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsBonus"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxItemSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtItemName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlItemUnitID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtItemFactor"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescriptiondt"></telerik:AjaxUpdatedControl>
																
																<telerik:AjaxUpdatedControl ControlID="txtTotal"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalPct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDiscFinalAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPPN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDPAmt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtGrandTotal"></telerik:AjaxUpdatedControl>
																
																<telerik:AjaxUpdatedControl ControlID="RadGridPurchaseOrder" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtPrice">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtPrice"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc1Pct">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc2Pct">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc3Pct">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc1Amt">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc1Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc2Amt">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc2Amt"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="txtDisc3Amt">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Pct"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDisc3Amt"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
													</AjaxSettings>
												</telerik:RadAjaxManager>--%>
                                        <!-- END AJAX MANAGER -->
                                        <!-- BEGIN NAV BAR -->
                                        <Module:Menu ID="Menu" runat="server">
                                        </Module:Menu>
                                        <!-- END NAV BAR -->
                                    </td>
                                </tr>
                            </table>
                            <!-- END PAGE HEADER -->
                        </td>
                    </tr>
                    <tr>
                        <td class="txtmenuname" valign="middle" width="100%" align="left">
                            Purchasing
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Purchase Order
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server">
                            </Module:Toolbar>
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
                                                                        <asp:Label ID="lblPurchaseOrderID" runat="server" Text="PO No."></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxPurchaseOrderID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                            HighlightTemplatedItems="True" EnableLoadOnDemand="True" MarkFirstMatch="true"
                                                                            Height="200px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="POrdNo"
                                                                            DataValueField="POrdNo" ShowDropDownOnTextboxClick="False">
                                                                            <itemtemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="width: 120px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "POrdNO") %>
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <%# format(DataBinder.Eval(Container.DataItem, "POrdDate"),"dd-MM-yyyy") %>
                                                                                        </td>
                                                                                        <td style="width: 220px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Status") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </itemtemplate>
                                                                            <headertemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="width: 120px;">
                                                                                            <b>PO No.</b>
                                                                                        </td>
                                                                                        <td style="width: 80px;">
                                                                                            <b>PO Date</b>
                                                                                        </td>
                                                                                        <td style="width: 220px;">
                                                                                            <b>Supplier</b>
                                                                                        </td>
                                                                                        <td style="width: 50px;">
                                                                                            <b>Status</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </headertemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdDateCaption" runat="server" Text="PO Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker ID="RadPOrdDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                            Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall">
                                                                            </dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdExpiredDateCaption" runat="server" Text="PO Due Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker ID="RadPOrdExpiredDate" runat="server" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall">
                                                                            </dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </datepopupbutton>
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
                                                                            <itemtemplate>
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
                                                                            </itemtemplate>
                                                                            <headertemplate>
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
                                                                            </headertemplate>
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
                                                                        <asp:Label ID="lblPICNameCaption" runat="server" Text="PIC Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtPICName" runat="server" Width="70%" MaxLength="500"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdTypeIDCaption" runat="server" Text="PO Type"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlPOrdTypeID" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPaymentTypeIDCaption" runat="server" Text="Payment Type"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlPaymentTypeID" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblTermOfPaymentCaption" runat="server" Text="Term Of Payment"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlTermOfPayment" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblTermOfAgreementCaption" runat="server" Text="Term Of Agreement"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlTermOfAgreement" runat="Server" Width="70%" Enabled="True">
                                                                        </asp:DropDownList>
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
                                                                        <asp:TextBox ID="txtCurrencyRate" runat="server" MaxLength="16" Style="text-align: right"
                                                                            Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPOrdDeliveryDateCaption" runat="server" Text="Delivery Date"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadDatePicker ID="RadPOrdDeliveryDate" runat="server" MinDate="1900-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <dateinput width="40%" font-size="XSmall">
                                                                            </dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDeilverToCaption" runat="server" Text="Deliver To"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDeliverTo" runat="server" MaxLength="500" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
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
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDivdet.style.display == '') {REDivdet.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDivdet.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordDetailEntryCaption" runat="server" Text="Record Detail Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDivdet">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="3" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <asp:LinkButton runat="server" ID="lbtnNewDetail" class="my_toolbarbutton" Text="New Detail"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none;" Width="58px"></asp:LinkButton></a>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle" height="20" />
                                                                        <asp:LinkButton runat="server" ID="lbtnSaveDetail" class="my_toolbarbutton" Text="Save Detail"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none;" Width="60px"></asp:LinkButton>
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr style="display: none">
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblIDCaption" runat="server" Text="ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtID" runat="server" MaxLength="16" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemSeqNo" runat="server" Text="Item ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxItemSeqNo" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="ItemID"
                                                                            DataValueField="ItemSeqNo" ShowDropDownOnTextboxClick="False">
                                                                            <itemtemplate>
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
                                                                            </itemtemplate>
                                                                            <headertemplate>
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
                                                                            </headertemplate>
                                                                        </telerik:RadComboBox>
                                                                        &nbsp;
                                                                        <asp:CheckBox ID="chkIsBonus" runat="server" AutoPostBack="True" Width="30" Text="Bonus">
                                                                        </asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="txtItemSeqNo" runat="server" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemNameCaption" runat="server" Text="Item Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtItemName" runat="server" ReadOnly="True" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemUnitIDCaption" runat="server" Text="Item Unit"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlItemUnitID" runat="Server" Width="70%" AutoPostBack="True"
                                                                            Enabled="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemFactorCaption" runat="server" Text="Item Factor"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtItemFactor" runat="server" MaxLength="16" Style="text-align: right"
                                                                            Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblQtyCaption" runat="server" Text="Qty"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtQty" runat="server" MaxLength="16" Style="text-align: right"
                                                                            Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPriceCaption" runat="server" Text="Unit Price"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtPrice" runat="server" onblur="FormatCurrency(this);" ReadOnly="False"
                                                                            MaxLength="16" Style="text-align: right" Width="70%" AutoPostBack="True"></asp:TextBox>
                                                                        <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Inquiry/ItemPriceCatalogue.aspx?"%>iseqno='+ document.getElementById('txtItemSeqNo').value,'__ipc',800,600,'no')"
                                                                            title="Show Item Price Catalogue">
                                                                            <img src='/pureravenslib/images/search.png' border='0' align='absmiddle' />
                                                                        </a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc1PctCaption" runat="server" Text="Discount 1 ( % )"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc1Pct" runat="server" AutoPostBack="true" onblur="FormatCurrency(this);"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc1AmtCaption" runat="server" Text="Discount 1"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc1Amt" runat="server" onblur="FormatCurrency(this);" AutoPostBack="true"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc2PctCaption" runat="server" Text="Discount 2 ( % )"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc2Pct" runat="server" onblur="FormatCurrency(this);" AutoPostBack="true"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc2AmtCaption" runat="server" Text="Discount 2"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc2Amt" runat="server" onblur="FormatCurrency(this);" AutoPostBack="true"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="33%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc3PctCaption" runat="server" Text="Discount 3 ( % )"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc3Pct" runat="server" onblur="FormatCurrency(this);" AutoPostBack="true"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDisc3AmtCaption" runat="server" Text="Discount 3"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDisc3Amt" runat="server" onblur="FormatCurrency(this);" AutoPostBack="true"
                                                                            MaxLength="16" Style="text-align: right" Width="70%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDescriptiondtCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="60%">
                                                                        <asp:TextBox ID="txtDescriptiondt" runat="server" MaxLength="500" Width="70%" TextMode="MultiLine"
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
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="overflow: auto; width: 100%; height: 100%" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <asp:DataGrid ID="RadGridPurchaseOrder" runat="server" Style="width: 100%" CellPadding="1"
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
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnDelete" runat="server" CommandName="Delete" Text="<img src='/pureravenslib/images/Delete.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Delete record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Seq No." Visible="False">
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Qty">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblQty" Text='<%# format(DataBinder.Eval(Container.DataItem, "Qty"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Factor">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemFactor" Text='<%# format(DataBinder.Eval(Container.DataItem, "ItemFactor"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Price" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPrice" Text='<%# format(DataBinder.Eval(Container.DataItem, "Price"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 1 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc1Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc1Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 1" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc1Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc1Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 2 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc2Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc2Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 2" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc2Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc2Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 3 ( % )" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc3Pct" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc3Pct"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Discount 3" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDisc3Amt" Text='<%# format(DataBinder.Eval(Container.DataItem, "Disc3Amt"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-HorizontalAlign="Right">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <br>
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
                                                                Text="0.00" Width="5%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                        <td align="right" width="30%">
                                                            <asp:Label ID="lblDiscFinalAmtCaption" runat="server" Text="Discount Final [-]"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDiscFinalAmt" runat="server" AutoPostBack="True" MaxLength="16"
                                                                Text="0.00" Style="text-align: right"></asp:TextBox>
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
                                                            <asp:Label ID="lblPPNCaption" runat="server" Text="Tax [+]"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtPPN" runat="server" MaxLength="16" ReadOnly="True" Text="0.00"
                                                                Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            <asp:Label ID="lblDPAmtCaption" runat="server" Text="DP Amount [-]"></asp:Label>
                                                            &nbsp;&nbsp;
                                                            <asp:TextBox ID="txtDPAmt" runat="server" MaxLength="16" AutoPostBack="True" Text="0.00"
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
                                    <!-- END RECORD LIST SECTION -->
                                    <!-- BEGIN RECORD PROPERTIES SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RCDiv.style.display == '') {RCDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RCDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordPropertiesCaption" runat="server" Text="Record Properties"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="RCDiv">
                                                <table cellpadding="2" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="lblUserInsertCaption" runat="server" Text="Created by"></asp:Label>
                                                        </td>
                                                        <td width="2%">
                                                            :
                                                        </td>
                                                        <td width="68%">
                                                            <asp:Label ID="lblUserInsert" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInsertDateCaption" runat="server" Text="Insert date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInsertDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdateCaption" runat="server" Text="Last update by"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDateCaption" runat="server" Text="Update date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD PROPERTIES SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:Copyright ID="mdlCopyRight" runat="server">
                            </Module:Copyright>
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
