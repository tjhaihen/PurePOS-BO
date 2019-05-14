<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Purchasing.PurchaseRequest"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Purchase Request</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
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
</head>
<body onload="ShowPosting();" ms_positioning="GridLayout">
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
                            Purchase Request
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
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN HEADER FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RHDiv.style.display == '') {RHDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RHDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblHeaderRecordEntryCaption" runat="server" Text="Record Header Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="RHDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblPReqNoCaption" runat="server" Text="Purchase Request No."></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxPurchaseRequestNo" ShowMoreResultBox="true" AutoPostBack="true"
                                                                            AllowCustomText="True" ItemRequestTimeout="200" DropDownWidth="500px" HighlightTemplatedItems="true"
                                                                            EnableLoadOnDemand="true" MarkFirstMatch="true" Width="80%" Height="200px" runat="server"
                                                                            Skin="WebBlue" MaxLength="15" DataValueField="PReqNo" Style="z-index: 0" ShowDropDownOnTextboxClick="False">
                                                                            <itemtemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellspacing="0"
                                                                                    cellpadding="1">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "PReqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "formatdate") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "Status") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </itemtemplate>
                                                                            <headertemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellspacing="0"
                                                                                    cellpadding="1">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>PR No.</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>PR Date</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Status</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </headertemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPReqDateCaption" runat="server" Text="Purchase Request Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="RadPReqDate" runat="server" MinDate="2006-01-01" SharedCalendarID="sharedCalendar"
                                                                            Culture="Marathi (India)">
                                                                            <dateinput width="30%" font-size="XSmall">
                                                                            </dateinput>
                                                                            <datepopupbutton hoverimageurl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                imageurl="/pureravenslib/images/datepicker_popup.gif">
                                                                            </datepopupbutton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblWH" runat="server" Text="Warehouse"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlWH" AutoPostBack="true" Width="80%" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlUnit" AutoPostBack="true" Width="80%" runat="server">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr rowspan="2">
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDescription" runat="server" Width="80%" TextMode="MultiLine"
                                                                            Height="40px" Style="font-family: Tahoma; font-size: 9pt;" MaxLength="500"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkIsApproval" runat="server" Text="Approval" Style="display: none">
                                                                        </asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END HEADER FORM SECTION -->
                                    <!-- BEGIN DETAIL FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RDDiv.style.display == '') {RDDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RDDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblDetailRecordEntryCaption" runat="server" Text="Record Detail Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="RDDiv">
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
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr style="display: none">
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblIDCaption" runat="server" Text="ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtID" runat="server" MaxLength="16" Width="80%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemIDCaption" runat="server" Text="Item ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxItemSeqNo" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="80%" ItemRequestTimeout="200" DropDownWidth="423px"
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemNameCaption" runat="server" Text="Item Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtItemName" runat="server" ReadOnly="true" Width="80%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemUnitCaption" runat="server" Text="Item Unit"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:DropDownList ID="ddlItemUnit" runat="server" Width="80%" AutoPostBack="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblItemFactorCaption" runat="server" Text="Item Factor"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtItemFactor" runat="server" ReadOnly="true" Width="30%" Style="text-align: right"></asp:TextBox>
                                                                        <asp:Label ID="lblItemSUnitName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblQtyCaption" runat="server" Text="Qty"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtQty" runat="server" Width="30%" Style="text-align: right"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr style="display: none">
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblEntitiesSeqNoCaption" runat="server" Text="Supplier ID"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <telerik:RadComboBox ID="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="False" Width="80%" ItemRequestTimeout="200" DropDownWidth="423px"
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
                                                                <tr style="display: none">
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtEntityName" runat="server" Width="80%" ReadOnly="true"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%">
                                                                        <asp:Label ID="lblDescriptionDtCaption" runat="server" Text="Description"></asp:Label>
                                                                    </td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="txtDescriptionDt" runat="server" Width="80%" TextMode="MultiLine"
                                                                            Height="40px" Style="font-family: Tahoma; font-size: 9pt;" MaxLength="500"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END DETAIL FORM SECTION -->
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
                                                            <asp:DataGrid ID="RadGridPurchaseRequest" runat="server" Style="width: 100%" CellPadding="1"
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Seq No.">
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
                                                                </Columns>
                                                            </asp:DataGrid>
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
</body>
</html>
