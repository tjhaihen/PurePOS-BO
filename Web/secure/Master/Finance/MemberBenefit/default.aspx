<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.MemberBenefit" EnableSessionState="true" EnableViewState="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Member Benefit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
		<script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
		<script language=javascript src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form runat="server">
			<table border="0" cellSpacing="0" cellPadding="2" width="100%" height="100%">
				<tr>
					<td vAlign="top" width="80%">
						<table border="0" cellSpacing="1" cellPadding="3" width="100%" height="100%">
							<tr>
								<td colSpan="2">
									<!-- BEGIN PAGE HEADER -->
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="100%">
												<!-- BEGIN AJAX MANAGER -->
												<%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
														<telerik:AjaxSetting AjaxControlID="RadToolbar">
																<UpdatedControls>
																	<telerik:AjaxUpdatedControl ControlID="txtMBTypeName"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadComboBoxMBTypeID"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadGridFormula"></telerik:AjaxUpdatedControl>														
																	<telerik:AjaxUpdatedControl ControlID="RadGridMBType" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxMBTypeID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtMBTypeName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridFormula"></telerik:AjaxUpdatedControl>														
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridMBType">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtMBTypeName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxMBTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridFormula"></telerik:AjaxUpdatedControl>														
																<telerik:AjaxUpdatedControl ControlID="RadGridMBType" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
															</UpdatedControls>
														</telerik:AjaxSetting>	
														
														<telerik:AjaxSetting AjaxControlID="lbtnNewFormula">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxValue"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPoint"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														<telerik:AjaxSetting AjaxControlID="lbtnSaveFormula">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxValue"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPoint"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridFormula" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														<telerik:AjaxSetting AjaxControlID="RadGridFormula">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxValue"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPoint"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridFormula" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
															</UpdatedControls>
														</telerik:AjaxSetting>
									
													</AjaxSettings>
														
												</telerik:RadAjaxManager>--%>
												<!-- END AJAX MANAGER -->
												<!-- BEGIN NAV BAR --><MODULE:MENU id="Menu" runat="server"></MODULE:MENU>
												<!-- END NAV BAR --></td>
										</tr>
									</table>
									<!-- END PAGE HEADER --></td>
							</tr>
							<tr>
								<td class="rheader" vAlign="middle" width="100%" align="left">
								Master
								<img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
								Finance
								<img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
								Member Benefit
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
														<tr>
															<td width="5%"><asp:label id="lblMBTypeID" runat="server" text="Member Benefit ID"></asp:label></td>
															<td Width="40%">
															<telerik:radcombobox id="RadComboBoxMBTypeID"  ShowMoreResultBox="false"
																	AutoPostBack="true" AllowCustomText="true" Width="40%" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
																	EnableLoadOnDemand="true" MarkFirstMatch="true"  Height="190px" Runat="server" Skin="WebBlue" maxlength = "15"
																	DataTextField="MBTypeID" DataValueField="MBTypeID" style="Z-INDEX: 0" ShowDropDownOnTextboxClick="False">
																	<ItemTemplate>
																		<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																			<tr>
																				<td style="width:125px;">
																					<%# DataBinder.Eval(Container.DataItem, "MBTypeID") %>
																				</td>
																				<td style="width:125px;">
																					<%# DataBinder.Eval(Container.DataItem, "MBTypeName") %>
																				</td>
																			</tr>
																		</table>
																	</ItemTemplate>
																	<HeaderTemplate>
																		<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																			<tr>
																				<td style="width:125px;">
																					<b>Member Benefit ID</b>
																				</td>
																				<td style="width:125px;">
																					<b>Member Benefit Name</b>
																				</td>
																			</tr>
																		</table>
																	</HeaderTemplate>
																</telerik:radcombobox>
															</td>
														</tr>
														<tr>
															<td width="5%"><asp:label id="lblMBTypeNameCaption" runat="server" text="Member Benefit Name" ></asp:label></td>
															<td width="40%"><asp:textbox id="txtMBTypeName" runat="server" maxlength = "500" width="40%"></asp:textbox></td>
														</tr>
														<tr>
															<td width="5%"><asp:label id="lblDescriptionCaption" runat="server" text="Description" ></asp:label></td>
															<td width="40%"><asp:textbox id="txtDescription" runat="server" maxlength = "500" width="40%" TextMode="MultiLine" Height="40px" style = "Font-Family:Tahoma;Font-Size:9pt;"></asp:textbox></td>
														</tr>														
														<tr>
															<td width="5%"></td>
															<td width="40%"><asp:checkbox id="chkIsActive" runat="server" text="Active" width="40%"></asp:checkbox></td>
														</tr>																												
													</table>
												</DIV>
											</td>
											
										</tr>
										<TR>
											<TD class="rheader" height="25" vAlign="middle" width="2%" align="center">
												<IMG style="CURSOR: hand" onclick="javascript:if (CPDiv.style.display == '') {CPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {CPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}" alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
											</TD>
											<TD class="rheader" height="25" vAlign="middle" width="98%" align="left">
												&nbsp;
												<asp:label id="lblFormulaEntryCaption" runat="server" text="Formula Entry"></asp:label>
											</TD>											
										</TR>
										<tr>											
											<td vAlign="top" width="100%" colspan="2">
												<DIV id="CPDiv">
													<table width="100%" cellpadding="0" cellspacing="0" border="0">	
														<tr>
															<td vAlign="top" align="left" colspan="3" width="100%">
																<table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
																	<tr>
																		<td width="1" class="my_toolbarbutton_left">
																		</td>																		
																		<td valign="middle">
																			<asp:linkbutton Runat="server" class="my_toolbarbutton" text=".::" CausesValidation="false" Enabled="False" style="color:black;text-decoration:none;font-weight:bold"></asp:linkbutton>																			
																			<asp:linkbutton Runat="server" id="lbtnNewFormula" class="my_toolbarbutton" text="New Formula" CausesValidation="false" style="color:black;text-decoration:none;" width="72px"></asp:linkbutton></a>
																			<img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle" height="20"/>
																			<asp:linkbutton Runat="server" id="lbtnSaveFormula" class="my_toolbarbutton" text="Save Formula" CausesValidation="false" style="color:black;text-decoration:none;" width="74px"></asp:linkbutton>
																		</td>																		
																		<td width="1" class="my_toolbarbutton_right">
																		</td>																		
																	</tr>
																</table>																	
															</td>														
														</tr>	
																									
														<tr>
															<td vAlign="top" width="100%">												
																<TABLE cellSpacing="1" cellPadding="2" width="100%">
																	<TR style="Display:none">
																		<TD Width="5%">
																			<asp:label id="lblIDCaption" runat="server" text="ID"></asp:label></TD>
																		<TD Width="40%">
																			<asp:textbox id="txtID" runat="server" readonly="True" width="40%"></asp:textbox>
																		</TD>
																	</TR>
																	<TR>
																		<TD Width="5%">
																			<asp:label id="lblMaxValueCaption" runat="server" text="Max Value"></asp:label></TD>
																		<TD Width="40%">
																			<asp:textbox id="txtMaxValue" runat="server" onblur="FormatCurrency(this);" maxlength="16" style="TEXT-ALIGN:right" width="40%"></asp:textbox>
																		</TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="lblPointCaption" runat="server" text="Point"></asp:label></TD>
																		<TD>
																			<asp:textbox id="txtPoint" runat="server" onblur="FormatCurrency(this);"  maxlength="16" style="TEXT-ALIGN:right" width="40%"></asp:textbox>
																		</TD>
																	</TR>
																																	
																</TABLE>
															</TD>
														
														</TR>
														<tr>
															<td vAlign="top" align="left" colspan="2" width="100%">
															    <asp:DataGrid	id="RadGridFormula" 
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
																		<asp:TemplateColumn HeaderStyle-Width="50"
													                                ItemStyle-Width="50">
																			<ItemTemplate>
																				<asp:LinkButton ID="_lbtnDelete" Runat="server" CommandName="Delete" Text="<img src='/pureravenslib/images/Delete.png' border='0' align='absmiddle'/>"
																										ToolTip="Delete record" />
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="ID" visible="False">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Max Value" >
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMaxValue" Text='<%# format(DataBinder.Eval(Container.DataItem, "MaxValue"),"#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Point" >
																			<itemtemplate>
																				<asp:label runat="server" id="_lblPoint" Text='<%# format(DataBinder.Eval(Container.DataItem, "Point"),"#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																	</Columns>
																</asp:DataGrid>		
															</td>														
														</tr>
														<tr>
															<td colspan="2" width="100%" height="25">
															</td>
														</tr>
													</table>
												</DIV>	
											</TD>
										</TR>
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
											<td vAlign="top" width="100%" colspan="2">
												<DIV style="WIDTH: 100%; HEIGHT: 300px; OVERFLOW: auto" id="RLDiv">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td vAlign="top" width="100%">
															     <asp:DataGrid	id="RadGridMBType" 
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
																		<asp:TemplateColumn runat="server" HeaderText="Member Benefit ID" >
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMBTypeID" Text='<%# DataBinder.Eval(Container.DataItem, "MBTypeID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Member Benefit Name" >
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMBTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "MBTypeName") %>'/>
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
												</DIV>
											</td>
										</tr>
										<!-- END RECORD LIST SECTION -->
									</table>
									</DIV>
								</td>
							</tr>
							<tr>
								<td ><MODULE:COPYRIGHT id="mdlCopyRight" runat="server"></MODULE:COPYRIGHT>
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
</HTML>
