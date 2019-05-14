<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PromotionDt.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.Promotiondt" EnableSessionState="true" EnableViewState="true" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Promotion Detail</title>
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
								<td class="rheader" vAlign="top" width="100%" align="left">
									<!-- BEGIN AJAX MANAGER -->
									<%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
										<AjaxSettings>
											<telerik:AjaxSetting AjaxControlID="lbtnAddBrandName">
												<UpdatedControls>	
													<telerik:AjaxUpdatedControl ControlID="RadGridBrandName" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionBrandName" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnRemoveBrandName">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadGridBrandName" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionBrandName" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnAddItemCategory">
												<UpdatedControls>	
													<telerik:AjaxUpdatedControl ControlID="RadGridItemCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionItemCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnRemoveItemCategory">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadGridItemCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionItemCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnAddItemSubCategory">
												<UpdatedControls>	
													<telerik:AjaxUpdatedControl ControlID="RadGridItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnRemoveItemSubCategory">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadGridItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotionItemSubCategory" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnAdd">
												<UpdatedControls>	
													<telerik:AjaxUpdatedControl ControlID="RadGridItems" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotiondt" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>
											<telerik:AjaxSetting AjaxControlID="lbtnRemove">
												<UpdatedControls>
													<telerik:AjaxUpdatedControl ControlID="RadGridItems" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
													<telerik:AjaxUpdatedControl ControlID="RadGridPromotiondt" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
												</UpdatedControls>
											</telerik:AjaxSetting>	
											<telerik:AjaxSetting AjaxControlID="lbtnApplyFilter">
												<UpdatedControls>	
													<telerik:AjaxUpdatedControl ControlID="RadGridItems" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>													
												</UpdatedControls>
											</telerik:AjaxSetting>																									
										</AjaxSettings>
									</telerik:RadAjaxManager>--%>
									<!-- END AJAX MANAGER -->
									
									<asp:Label id="lblPromotionDetailCaption" runat="server" text="Promotion Detail" />
								</td>
							</tr>
							
							<tr>
								<td  height="100%" vAlign="top" width="100%" colSpan="2" align="left">
									<table width="100%" height="100%" >
										<!-- BEGIN FORM SECTION -->
										<tr>
											<td vAlign="top" width="100%" colspan="2">
												<table cellSpacing="1" cellPadding="2" width="100%">
													<tr>
														<td width="10%">
															<asp:label id="lblIDCaption" runat="server" text="Promotion ID"></asp:label>
														</td>
														<td width="1%">
															<asp:label id="lblmark1Caption" runat="server" text=":"></asp:label>
														</td>
														<td width="50%">
															<asp:label id="lblID" runat="server" text=""></asp:label>
														</td>
													</tr>
													<tr>
														<td width="10%"><asp:label id="lblPromotionNameCaption" runat="server" text="Promotion Name"></asp:label></td>
														<td width="1%">
															<asp:label id="lblmark2Caption" runat="server" text=":"></asp:label>
														</td>
														<td width="50%"><asp:label id="lblPromotionName" runat="server" text=""></asp:label></td>
													</tr>
												</table>
											</td>
										</tr>
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
											<td colspan="2" width="100%" height="100%" vAlign="top">
												<DIV id="RLDiv">
													<table cellspacing="1" cellpadding="0" border="0" width="100%">
														<tr>
															<td vAlign="top" width="100%" colspan="3">
																<asp:Panel id="pnlPromotionBrandName" runat="server">
																	<table cellspacing="0" cellpadding="0" border="0" width="100%">
																		<tr>
																			<td class="rheader" vAlign="middle" width="45%" align="left">
																				Brand Name List
																			</td>
																			<td class="rheader" vAlign="middle" align="center" width="10%">
																				
																			</td>
																			<td class="rheader" vAlign="middle" width="45%" align="left" >
																				Brand Name in Promotion List
																			</td>
																		</tr>	
																		<tr>
																			<td vAlign="top" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0" border="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							    <asp:DataGrid	id="RadGridBrandName" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllBrandName"
																													ID="chkSelectAllBrandName"
																													type="checkbox" 
																													onclick="javascript:checkAllv2(this.form,'_chkAddBrandName', 'chkSelectAllBrandName');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkAddBrandName" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Brand ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblBrandID" Text='<%# DataBinder.Eval(Container.DataItem, "BrandNameID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Brand Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblBrandName" Text='<%# DataBinder.Eval(Container.DataItem, "BrandName") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>												
																								    </Columns>
																                                </asp:DataGrid>			
																							</td>
																						</tr>
																					</table>
																				</div>
																			</td>
																			<td vAlign="center" align="center" style="text-align:center;">
																				<asp:linkbutton Runat="server" id="lbtnAddBrandName" class="MyButton" text="Add >>" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																				<br>
																				<asp:linkbutton Runat="server" id="lbtnRemoveBrandName" class="MyButton" text="<< Remove" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																			</td>
																			<td vAlign="top" align="left" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							    <asp:DataGrid	id="RadGridPromotionBrandName" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllPromotionBrandName"
																													ID="chkSelectAllPromotionBrandName"
																													type="checkbox" 
																													onclick="javascript:checkAllv2(this.form,'_chkRemovePromotionBrandName', 'chkSelectAllPromotionBrandName');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkRemovePromotionBrandName" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Brand ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblBrandNameIDPdt" Text='<%# DataBinder.Eval(Container.DataItem, "BrandNameID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Brand Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblBrandName" Text='<%# DataBinder.Eval(Container.DataItem, "BrandName") %>'/>
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
																	</table>
																</asp:Panel>
																
																<asp:Panel id="pnlPromotionItemCategory" runat="server">
																	<table cellspacing="0" cellpadding="0" border="0" width="100%">
																		<tr>
																			<td class="rheader" vAlign="middle" width="45%" align="left">
																				Item Category List
																			</td>
																			<td class="rheader" vAlign="middle" align="center" width="10%">
																				
																			</td>
																			<td class="rheader" vAlign="middle" width="45%" align="left" >
																				Item Category in Promotion List
																			</td>
																		</tr>	
																		<tr>
																			<td vAlign="top" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0" border="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							     <asp:DataGrid	id="RadGridItemCategory" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllItemCategory"
																													ID="chkSelectAllItemCategory"
																													type="checkbox" 
																													onclick="javascript:checkAllv2(this.form,'_chkAddItemCategory', 'chkSelectAllItemCategory');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkAddItemCategory" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Category ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemCategoryID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Category Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryName") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>												
																								    </Columns>
																                                </asp:DataGrid>		
																							</td>
																						</tr>
																					</table>
																				</div>
																			</td>
																			<td vAlign="center" align="center" style="text-align:center;">
																				<asp:linkbutton Runat="server" id="lbtnAddItemCategory" class="MyButton" text="Add >>" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																				<br>
																				<asp:linkbutton Runat="server" id="lbtnRemoveItemCategory" class="MyButton" text="<< Remove" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																			</td>
																			<td vAlign="top" align="left" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							     <asp:DataGrid	id="RadGridPromotionItemCategory" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllPromotionItemCategory"
																											        ID="chkSelectAllPromotionItemCategory"
																											        type="checkbox" 
																											        onclick="javascript:checkAllv2(this.form,'_chkRemovePromotionItemCategory', 'chkSelectAllPromotionItemCategory');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkRemovePromotionItemCategory" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Category ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemCategoryIDPdt" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Category Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCategoryName") %>'/>
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
																	</table>
																</asp:Panel>
																
																<asp:Panel id="pnlPromotionItemSubCategory" runat="server">
																	<table cellspacing="0" cellpadding="0" border="0" width="100%">
																		<tr>
																			<td class="rheader" vAlign="middle" width="45%" align="left">
																				Item Sub Category List
																			</td>
																			<td class="rheader" vAlign="middle" align="center" width="10%">
																				
																			</td>
																			<td class="rheader" vAlign="middle" width="45%" align="left" >
																				Item Sub Category in Promotion List
																			</td>
																		</tr>	
																		<tr>
																			<td vAlign="top" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0" border="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							    <asp:DataGrid	id="RadGridItemSubCategory" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllItemSubCategory"
																													ID="chkSelectAllItemSubCategory"
																													type="checkbox" 
																													onclick="javascript:checkAllv2(this.form,'_chkAddItemSubCategory', 'chkSelectAllItemSubCategory');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkAddItemSubCategory" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Sub Category ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSubCategoryID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Sub Category Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSubCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryName") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>												
																								    </Columns>
																                                </asp:DataGrid>		
																							</td>
																						</tr>
																					</table>
																				</div>
																			</td>
																			<td vAlign="center" align="center" style="text-align:center;">
																				<asp:linkbutton Runat="server" id="lbtnAddItemSubCategory" class="MyButton" text="Add >>" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																				<br>
																				<asp:linkbutton Runat="server" id="lbtnRemoveItemSubCategory" class="MyButton" text="<< Remove" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																			</td>
																			<td vAlign="top" align="left" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							     <asp:DataGrid	id="RadGridPromotionItemSubCategory" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllPromotionItemSubCategory"
																													ID="chkSelectAllPromotionItemSubCategory"
																													type="checkbox" 
																													onclick="javascript:checkAllv2(this.form,'_chkRemovePromotionItemSubCategory', 'chkSelectAllPromotionItemSubCategory');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkRemovePromotionItemSubCategory" enabled="True" />
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Sub Category ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSubCategoryIDPdt" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Sub Category Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSubCategoryName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSubCategoryName") %>'/>
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
																	</table>
																</asp:Panel>
																
																<asp:Panel id="pnlPromotionItem" runat="server">
																	<table cellspacing="0" cellpadding="0" border="0" width="100%">
																		<tr>
																			<td vAlign="center" width="100%" colspan="3">																
																				<TABLE cellSpacing="1" cellPadding="2" width="100%">
																					<TR>
																						<TD width="10%" valign="center">
																							<asp:label id="lblSearchItemName" runat="server" text="Search Item Name"></asp:label>
																						<TD width="30%" valign="center">
																							<asp:textbox id="txtSearchItemName" runat="server" width="80%" text="*"></asp:textbox>		
																							<asp:linkbutton CssClass="MyButton" id="lbtnApplyFilter" runat="server" text="Apply" width="50"></asp:linkbutton>
																						</TD>
																					</TR>
																					<TR>
																						<TD colspan="2">
																							<asp:label style="color:gray;font-size:8pt;" id="lblSearchItemNameNotes" runat="server" text="(e.g.: [Search Text]*; *[Search Text]; *[Search Text]*. Notes: Showing all items (*) will take longer time to get the data.)"></asp:label>
																						</TD>
																					</TR>
																				</TABLE>
																			</td>															
																		</tr>
																		<tr>
																			<td class="rheader" vAlign="middle" width="45%" align="left">
																				Item List
																			</td>
																			<td class="rheader" vAlign="middle" align="center" width="10%">
																				
																			</td>
																			<td class="rheader" vAlign="middle" width="45%" align="left" >
																				Item in Promotion List
																			</td>
																		</tr>	
																		<tr>
																			<td vAlign="top" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0" border="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							    <asp:DataGrid	id="RadGridItems" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllItems"
																																		ID="chkSelectAllItems"
																																		type="checkbox" 
																																		onclick="javascript:checkAllv2(this.form,'_chkAdd', 'chkSelectAllItems');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkAdd" enabled="True" />																					
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Seq No.">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>												
																								    </Columns>
																                                </asp:DataGrid>	
																							</td>
																						</tr>
																					</table>
																				</div>
																			</td>
																			<td vAlign="center" align="center" style="text-align:center;">
																				<asp:linkbutton Runat="server" id="lbtnAdd" class="MyButton" text="Add >>" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																				<br>
																				<asp:linkbutton Runat="server" id="lbtnRemove" class="MyButton" text="<< Remove" CausesValidation="false" width="100" style="padding: 5px 5px 5px 5px"></asp:linkbutton>
																			</td>
																			<td vAlign="top" align="left" height="100%" bgcolor="#AFBEC5">
																				<DIV style="WIDTH: 100%; HEIGHT: 390px; OVERFLOW: auto">
																					<table cellSpacing="0" cellPadding="0"  width="100%">
																						<tr>
																							<td vAlign="top" width="100%" >
																							    <asp:DataGrid	id="RadGridPromotiondt" 
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
													                                                    <HeaderTemplate>
													                                                        <input	name="chkSelectAllPromotiondt"
																																		ID="chkSelectAllPromotiondt"
																																		type="checkbox" 
																																		onclick="javascript:checkAllv2(this.form,'_chkRemove', 'chkSelectAllPromotiondt');">
													                                                    </HeaderTemplate>
																			                            <ItemTemplate>
																				                            <asp:CheckBox runat="server" id="_chkRemove" enabled="True" />																					
																			                            </ItemTemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Seq No.">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemSeqNoPdt" Text='<%# DataBinder.Eval(Container.DataItem, "ItemSeqNo") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>
																		                            <asp:TemplateColumn runat="server" HeaderText="Item ID">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ItemID") %>'/>
																			                            </itemtemplate>
																		                            </asp:TemplateColumn>	
																		                            <asp:TemplateColumn runat="server" HeaderText="Item Name">
																			                            <itemtemplate>
																				                            <asp:label runat="server" id="_lblItemName" Text='<%# DataBinder.Eval(Container.DataItem, "ItemName") %>'/>
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
																	</table>
																</asp:Panel>
															</td>
														</tr>																												
													</table>
												</DIV>
											</td>
										</tr>																													
										<!-- END FORM SECTION -->
									</table>									
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
	</body>
</HTML>
