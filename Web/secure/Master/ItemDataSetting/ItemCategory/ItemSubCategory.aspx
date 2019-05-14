<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ItemSubCategory.aspx.vb"
    Inherits="Raven.Web.Secure.Master.ItemDataSetting.ItemSubCategory" EnableSessionState="true"
    EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Item Sub Category</title>
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
            overflow: hidden;
        }
    </style>
</head>
<body onload="center();">
    <form runat="server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <table border="0" cellspacing="0" cellpadding="2" width="100%" height="100%">
        <tr>
            <td valign="top" width="80%">
                <table border="0" cellspacing="1" cellpadding="3" width="100%" height="100%">
                    <tr>
                        <td class="rheader" valign="middle" width="100%" align="left">
                            <!-- BEGIN AJAX MANAGER -->
                            <%--									<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
										<AjaxSettings>
											<telerik:AjaxSetting AjaxControlID="RadToolbar">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadComboBoxItemSubCategoryID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtItemSubCategoryName"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountPct"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountAmt"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="RadComboBoxItemSubCategoryID">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="txtItemSubCategoryName"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountPct"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountAmt"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="RadGridItemSubCategory">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadComboBoxItemSubCategoryID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtItemSubCategoryName"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountPct"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtSalesDiscountAmt"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>		
													<telerik:AjaxUpdatedControl ControlID="RadGridItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
												</UpdatedControls>
											</telerik:AjaxSetting>																						
										</AjaxSettings>
									</telerik:RadAjaxManager>--%>
                            <!-- END AJAX MANAGER -->
                            Item Category:
                            <asp:Label ID="lblItemCategoryID" runat="server" />
                            [<asp:Label ID="lblItemCategoryName" runat="server" />]
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 500px; overflow: auto">
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
                                                        <td width="25%">
                                                            <asp:Label ID="lblItemSubCategoryIDCaption" runat="server" Text="Item Sub Category ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="RadComboBoxItemSubCategoryID" ShowMoreResultBox="false"
                                                                AutoPostBack="true" AllowCustomText="true" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                Width="60%" Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="ItemSubCategoryName"
                                                                DataValueField="ItemSubCategoryID" Style="z-index: 0" ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryID") %>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryName") %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <b>Item Sub Category ID</b>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <b>Item Sub Category Name</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblItemSubCategoryNameCaption" runat="server" Text="Item Sub Category Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtItemSubCategoryName" runat="server" Width="60%" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDescriptionCaption" runat="server" Text="Description"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDescription" runat="server" Width="60%" TextMode="MultiLine"
                                                                Height="40px" Style="font-family: Tahoma; font-size: 9pt;" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td>
                                                            <asp:Label ID="lblSalesDiscountPctCaption" runat="server" Text="Sales Discount ( % )"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSalesDiscountPct" runat="server" Width="60%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td>
                                                            <asp:Label ID="lblSalesDiscountAmtCaption" runat="server" Text="Sales Discount Amount"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSalesDiscountAmt" runat="server" Width="60%" Style="text-align: right"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
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
                                                            <asp:DataGrid ID="RadGridItemSubCategory" runat="server" Style="width: 100%" CellPadding="1"
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
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Sub Category ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemSubCategoryID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Item Sub Category Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblItemSubCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Discount ( % )">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesDiscountPct" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesDiscountPct"), "#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Sales Discount Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblSalesDiscountAmt" Text='<%# Format(DataBinder.Eval(Container.DataItem, "SalesDiscountAmt"), "#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
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
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
