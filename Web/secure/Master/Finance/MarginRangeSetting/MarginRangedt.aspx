<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MarginRangedt.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.MarginRangedt" EnableSessionState="true" EnableViewState="true" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Margin Range Detail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
		<script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
		<script language=javascript src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>				
		<style>
			BODY { BACKGROUND: #cfe2fb; OVERFLOW: hidden }
		</style>
	</HEAD>
	<body onload="center();">
		<form runat="server">
			<table border="0" cellSpacing="0" cellPadding="2" width="100%" height="100%">
				<tr>
					<td vAlign="top" width="80%">
						<table border="0" cellSpacing="1" cellPadding="3" width="100%" height="100%">
							<tr>
								<td class="rheader" vAlign="middle" width="100%" align="left">
									<!-- BEGIN AJAX MANAGER -->
									<%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
										<AjaxSettings>
											<telerik:AjaxSetting AjaxControlID="RadToolbar">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMarginRangeID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMaxAmount"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMarginPct"></telerik:AjaxUpdatedControl>	
													<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>	
													<telerik:AjaxUpdatedControl ControlID="RadGridMarginRangedt" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="RadGridMarginRangedt">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMarginRangeID"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMaxAmount"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="txtMarginPct"></telerik:AjaxUpdatedControl>	
													<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>		
													<telerik:AjaxUpdatedControl ControlID="RadGridMarginRangedt" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
												</UpdatedControls>
											</telerik:AjaxSetting>																
										</AjaxSettings>
									</telerik:RadAjaxManager>--%>
									<!-- END AJAX MANAGER -->
									
									Margin Range Detail
								</td>
							</tr>
							<tr>
								<td height="25" vAlign="middle" width="100%" colSpan="2" align="left">
									<Module:Toolbar id="Toolbar" runat="server"></Module:Toolbar>
							    </td>
							</tr>
							<tr>
								<td  height="100%" vAlign="top" width="100%" colSpan="2" align="left">
									<DIV style="WIDTH: 100%; HEIGHT: 100%; OVERFLOW: auto">
									<table width="100%">
										<!-- BEGIN FORM SECTION -->
										<tr>
											<TD class="rheader" height="25" vAlign="middle" width="2%" align="center">
												<IMG style="CURSOR: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}" alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
											</TD>
											<TD class="rheader" height="25" vAlign="middle" width="98%" align="left">
												&nbsp;
												<asp:label id="lblRecordEntryCaption" runat="server" text="Record Entry"></asp:label>
											</TD>
										</tr>
										<tr>
											<td vAlign="top" width="100%" colspan="2">
												<DIV id="REDiv">
													<table cellSpacing="1" cellPadding="2" width="100%">
														<tr style = 'Display:none'>
															<td width="10%"><asp:label id="lblIDCaption" runat="server" text="ID"></asp:label></td>
															<td width="40%"><asp:textbox id="txtID" runat="server" readonly = "True" maxlength = "15" width="40%"></asp:textbox></td>
														</tr>
														<tr>
															<td width="10%">
																<asp:label id="lblMarginRangeIDCaption" runat="server" text="Margin Range ID"></asp:label>																
															</td>
															<td width="1%">
																<asp:label id="lblmark1Caption" runat="server" text=":"></asp:label>
															</td>
															<td width="40%">
																<asp:label id="lblMarginRangeID" runat="server"></asp:label>
															</td>
														</tr>
														<tr>
															<td width="10%">
																<asp:label id="lblMarginRangeNameCaption" runat="server" text="Margin Range Name"></asp:label>																
															</td>
															<td width="1%">
																<asp:label id="lblmark2Caption" runat="server" text=":"></asp:label>
															</td>
															<td width="40%">
																<asp:label id="lblMarginRangeName" runat="server"></asp:label>
															</td>
														</tr>
														<tr>
															<td width="10%" ><asp:label id="lblMarginMaxAmountCaption" runat="server" text="Max Amount"></asp:label></td>
															<td width="40%" colspan="2"><asp:textbox id="txtMaxAmount" runat="server" maxlength = "16" style="text-align:right" width="40%" onblur="FormatCurrency(this);"></asp:textbox></td>
														</tr>
														<tr>
															<td width="10%" ><asp:label id="lblMarginPctCaption" runat="server" text="Margin Percent ( % )"></asp:label></td>
															<td width="40%" colspan="2"><asp:textbox id="txtMarginPct" runat="server" maxlength = "16" style="text-align:right" width="40%" onblur="FormatCurrency(this);"></asp:textbox></td>
														</tr>
														<tr>
															<td width="10" ></td>
															<td width="40%" colspan="2"><asp:checkbox id="chkIsActive" runat="server" text="Active" width="40%"></asp:checkbox></td>
														</tr>
													</table>
												</DIV>
											</td>
										</tr>
										<!-- END FORM SECTION -->
										<!-- BEGIN RECORD LIST SECTION -->
										<tr>
											<TD class="rheader" height="25" vAlign="middle" width="2%" align="center">
												<IMG style="CURSOR: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}" alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
											</TD>
											<TD class="rheader" height="25" vAlign="middle" width="98%" align="left">
												&nbsp;
												<asp:label id="lblRecordListCaption" runat="server" text="Record List"></asp:label>
											</TD>
										</tr>										
										<tr>
											<td vAlign="top" width="100%" height="100%" colspan="2">
												<DIV style="WIDTH: 100%; HEIGHT: 300px; OVERFLOW: auto" id="RLDiv">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td valign="top" width="100%">
																<asp:DataGrid	id="RadGridMarginRangedt" 
																				runat="server" 
																				style="Width:100%" 
																				CellPadding="0" 
																				ShowFooter="False" 																				
																				PageSize="20" 
																				AllowPaging="false" 
																				GridLines="None" 
																				BorderWidth="1" 
																				BorderColor="Gainsboro"
																				CellSpacing="0" 
																				AutoGenerateColumns="False"
																				AllowSorting="True">
																	<HeaderStyle	Font-Bold="True" 
																					CssClass="rheadercol" 
																					BackColor="#DEE3E7" 
																					Height="20" />
																	<HeaderStyle Font-Bold="false" BackColor=#DEE3E7  Height=20 />								
					                                                <AlternatingItemStyle BackColor=#E3F3F9  />
					                                                <EditItemStyle Font-Bold="false" />										
																	<PagerStyle Mode="NumericPages" HorizontalAlign="right" />																		
																	<Columns>
																	    <asp:TemplateColumn HeaderStyle-Width="50"
													                                ItemStyle-Width="50">
																			<ItemTemplate>
																				<asp:LinkButton ID="_lbtnSelect" Runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
																									ToolTip="Edit record" />
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="ID" visible = "False">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Margin Range ID">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMarginRangeID" Text='<%# DataBinder.Eval(Container.DataItem, "MarginRangeID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Max Amount" ItemStyle-HorizontalAlign="Right">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMaxAmount" Text='<%# Format(DataBinder.Eval(Container.DataItem, "MaxAmount"),"#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Margin Percent ( % )" ItemStyle-HorizontalAlign="Right">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMarginPct" Text='<%# format(DataBinder.Eval(Container.DataItem, "MarginPct"),"#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Active" >
																			<itemtemplate>
																				<asp:CheckBox runat="server" id="_chkIsActive" enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>'/>
																			</itemtemplate>
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
									</DIV>
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
</HTML>
