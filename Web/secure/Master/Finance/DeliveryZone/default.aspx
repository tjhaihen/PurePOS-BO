<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.DeliveryZone" EnableSessionState="true" EnableViewState="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Delivery Zone</title>
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
																	<telerik:AjaxUpdatedControl ControlID="txtDeliveryZoneName"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseAmount"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseQty"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtDeliveryFee"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtDeliveryInterval"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadComboBoxDeliveryZoneID"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryZone" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxDeliveryZoneID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDeliveryZoneID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryZoneName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseAmount"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryFee"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryInterval"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														<telerik:AjaxSetting AjaxControlID="RadGridDeliveryZone">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryZoneName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseAmount"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMinPurchaseQty"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryFee"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDeliveryInterval"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxDeliveryZoneID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridDeliveryZone" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
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
								<td class="txtmenuname" vAlign="middle" width="100%" align="left">
								Master
								<img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
								Finance
								<img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
								Delivery Zone
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
													<table cellspacing="0" cellpadding="0" border="0" width="100%">
														<tr>
															<td width="50%">
																<table cellSpacing="1" cellPadding="2" width="100%">
																	<tr>
																		<td width="30%"><asp:label id="lblDeliveryZoneID" runat="server" text="Delivery Zone ID"></asp:label></td>
																		<td Width="70%">
																		<telerik:radcombobox id="RadComboBoxDeliveryZoneID"  ShowMoreResultBox="false"
																				AutoPostBack="true" AllowCustomText="true" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
																				EnableLoadOnDemand="true" MarkFirstMatch="true"  Height="190px" Runat="server" Skin="WebBlue" maxlength = "15"
																				DataTextField="DeliveryZoneID" DataValueField="DeliveryZoneID" style="Z-INDEX: 0" ShowDropDownOnTextboxClick="False">
																				<ItemTemplate>
																					<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																						<tr>
																							<td style="width:125px;">
																								<%# DataBinder.Eval(Container.DataItem, "DeliveryZoneID") %>
																							</td>
																							<td style="width:125px;">
																								<%# DataBinder.Eval(Container.DataItem, "DeliveryZoneName") %>
																							</td>
																						</tr>
																					</table>
																				</ItemTemplate>
																				<HeaderTemplate>
																					<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																						<tr>
																							<td style="width:125px;">
																								<b>Delivery Zone ID</b>
																							</td>
																							<td style="width:125px;">
																								<b>Delivery Zone Name</b>
																							</td>
																						</tr>
																					</table>
																				</HeaderTemplate>
																			</telerik:radcombobox>
																		</td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblDeliveryZoneNameCaption" runat="server" text="Delivery Zone Name" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtDeliveryZoneName" runat="server" maxlength = "500" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblDeliveryFee" runat="server" text="Delivery Fee" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtDeliveryFee" runat="server" maxlength="19" width="70%" style="text-align:right"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblMinPurchaseAmountCaption" runat="server" text="Min. Purchase Amount" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtMinPurchaseAmount" runat="server" maxlength="19" width="70%" style="text-align:right"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblMinPurchaseQtyCaption" runat="server" text="Min. Purchase Qty" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtMinPurchaseQty" runat="server" maxlength="19" width="70%" style="text-align:right"></asp:textbox></td>
																	</tr>																										
																</table>
															</td>
															<td vAlign="top" width="50%">
																<table cellSpacing="1" cellPadding="2" width="100%">
																	<tr>
																		<td width="30%"><asp:label id="lblDeliveryIntervalCaption" runat="server" text="Delivery Interval" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtDeliveryInterval" runat="server" maxlength="50" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblDescriptionCaption" runat="server" text="Description" ></asp:label></td>
																		<td width="60%"><asp:textbox id="txtDescription" runat="server" maxlength = "500" width="70%" TextMode="MultiLine" Height="40px" style = "Font-Family:Tahoma;Font-Size:9pt;"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"></td>
																		<td width="70%"><asp:checkbox id="chkIsActive" runat="server" text="Active" width="70%"></asp:checkbox></td>
																	</tr>
																</table>
															</td>
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
											<td vAlign="top" width="100%" colspan="2">
												<DIV style="WIDTH: 100%; HEIGHT: 300px; OVERFLOW: auto" id="RLDiv">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<tr>
															<td vAlign="top" width="100%">
															    <asp:DataGrid	id="RadGridDeliveryZone" 
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
																		<asp:TemplateColumn runat="server" HeaderText="Delivery Zone ID">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblDeliveryZoneID" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryZoneID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Delivery Zone Name">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblDeliveryZoneName" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryZoneName") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Delivery Fee">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblDeliveryFee" Text='<%# Format(DataBinder.Eval(Container.DataItem, "DeliveryFee"), "#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Min. Purchase Amt">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMinPurchaseAmount" Text='<%# Format(DataBinder.Eval(Container.DataItem, "MinPurchaseAmount"),"#,##0.00") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Min. Purchase Qty">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblMinPurchaseQty" Text='<%# Format(DataBinder.Eval(Container.DataItem, "MinPurchaseQty"),"#,##0.000") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Delivery Interval">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblDeliveryInterval" Text='<%# DataBinder.Eval(Container.DataItem, "DeliveryInterval") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Active">
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
								<td>
								    <MODULE:COPYRIGHT id="mdlCopyRight" runat="server"></MODULE:COPYRIGHT>
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
</HTML>
