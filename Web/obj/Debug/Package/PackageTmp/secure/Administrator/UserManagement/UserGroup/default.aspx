<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Administrator.UserManagement"
    EnableSessionState="true" EnableViewState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>User Group</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
</head>
<body ms_positioning="GridLayout" marginheight="0" marginwidth="0">
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
                                        <!-- BEGIN NAV BAR -->
                                        <Module:Menu ID="Menu" runat="server"></Module:Menu>
                                        <!-- END NAV BAR -->
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <!-- BEGIN AJAX MANAGER -->
                                        <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxUserGroupID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtUserGroupName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridUserGroup"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>														
														<%--<telerik:AjaxSetting AjaxControlID="RadGridUserGroup">
															<UpdatedControls>
															    <telerik:AjaxUpdatedControl ControlID="RadComboBoxUserGroupID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtUserGroupName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>																
																<telerik:AjaxUpdatedControl ControlID="RadGridUserGroup"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>														
													</AjaxSettings>
												</telerik:RadAjaxManager>--%>
                                        <!-- END AJAX MANAGER -->
                                    </td>
                                </tr>
                            </table>
                            <!-- END PAGE HEADER -->
                        </td>
                    </tr>
                    <tr>
                        <td class="txtmenuname" valign="middle" width="100%" align="left" colspan="2">
                            Administrator
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            User Management
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            User Group
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td  height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="24" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="24" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Record Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellspacing="1" cellpadding="2" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="lblUserGroupIDCaption" runat="server" Text="User Group ID"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <telerik:RadComboBox ID="RadComboBoxUserGroupID" ShowMoreResultBox="false" AutoPostBack="true"
                                                                AllowCustomText="true" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
                                                                EnableLoadOnDemand="true" MarkFirstMatch="true" Width="30%" Height="190px" runat="server"
                                                                MaxLength="15" DataTextField="UserGroupID" DataValueField="UserGroupName" Style="z-index: 0"
                                                                ShowDropDownOnTextboxClick="False">
                                                                <ItemTemplate>
                                                                    <table style="width: 415px; text-align: left; font-weight: normal;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "UserGroupID") %>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <%# DataBinder.Eval(Container.DataItem, "UserGroupName") %>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                                <HeaderTemplate>
                                                                    <table style="width: 415px; text-align: left;">
                                                                        <tr>
                                                                            <td style="width: 125px;">
                                                                                <b>User Group ID</b>
                                                                            </td>
                                                                            <td style="width: 125px;">
                                                                                <b>User Group Name</b>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUserGroupNameCaption" runat="server" Text="User Group Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtUserGroupName" runat="server" Width="30%" MaxLength="100"></asp:TextBox>
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
                                        <td class="rheader" height="24" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="24" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 300px; overflow: auto" id="RLDiv">
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="100%">
                                                            <asp:DataGrid ID="RadGridUserGroup" runat="server" Style="width: 100%" CellPadding="1"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                CellSpacing="1" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle CssClass="gridHeaderStyle" />                                                                
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                                <ItemStyle CssClass="gridItemStyle" />    
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="User Group ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUserGroupID" Text='<%# DataBinder.Eval(Container.DataItem, "usergroupID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="User Group Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblUserGroupName" Text='<%# DataBinder.Eval(Container.DataItem, "usergroupname") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active" ItemStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server">
                                                                        <ItemTemplate>
                                                                            <a href='#' onclick="javascript:NewWindow('<%= UrlBase + "/secure/Administrator/UserManagement/UserGroup/UserGroupAuthority.aspx?" %>ugid=<%# Trim(DataBinder.Eval(Container.DataItem, "UserGroupID")) %> ',null,800,600,'no')"
                                                                                title="User Group Authorization">
                                                                                <img src='/pureravenslib/images/detail.png' border='0' align='absmiddle' />
                                                                            </a>
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
