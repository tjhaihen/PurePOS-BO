<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.BankAccount" EnableSessionState="true" EnableViewState="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Bank Account</title>
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
																	<telerik:AjaxUpdatedControl ControlID="txtBankName"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="ddlBankTxnTypeID"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtAccountNo"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtAccountTitle"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtBranch"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtAddress"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="ddlCurrencyID"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadComboBoxBankID"></telerik:AjaxUpdatedControl>
																	<telerik:AjaxUpdatedControl ControlID="RadGridBank" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxBankID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxBankID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlBankTxnTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAccountNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAccountTitle"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBranch"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCurrencyID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														
														<telerik:AjaxSetting AjaxControlID="RadGridBank">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtBankName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlBankTxnTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAccountNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAccountTitle"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBranch"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCurrencyID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxBankID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridBank" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>														
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
								Bank Account
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
																		<td width="30%"><asp:label id="lblBankID" runat="server" text="Bank ID"></asp:label></td>
																		<td Width="70%">
																		<telerik:radcombobox id="RadComboBoxBankID"  ShowMoreResultBox="false"
																				AutoPostBack="true" AllowCustomText="true" Width="70%" ItemRequestTimeout="200" DropDownWidth="423px" HighlightTemplatedItems="true"
																				EnableLoadOnDemand="true" MarkFirstMatch="true"  Height="190px" Runat="server" Skin="WebBlue" maxlength = "15"
																				DataTextField="BankID" DataValueField="BankID" style="Z-INDEX: 0" ShowDropDownOnTextboxClick="False">
																				<ItemTemplate>
																					<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																						<tr>
																							<td style="width:125px;">
																								<%# DataBinder.Eval(Container.DataItem, "BankID") %>
																							</td>
																							<td style="width:125px;">
																								<%# DataBinder.Eval(Container.DataItem, "BankName") %>
																							</td>
																						</tr>
																					</table>
																				</ItemTemplate>
																				<HeaderTemplate>
																					<table style="width:415px; text-align:left; font-family:tahoma,arial;">
																						<tr>
																							<td style="width:125px;">
																								<b>Bank ID</b>
																							</td>
																							<td style="width:125px;">
																								<b>Bank Name</b>
																							</td>
																						</tr>
																					</table>
																				</HeaderTemplate>
																			</telerik:radcombobox>
																		</td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblBankNameCaption" runat="server" text="Bank Name" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtBankName" runat="server" maxlength = "500" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblBranchCaption" runat="server" text="Branch" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtBranch" runat="server" maxlength = "500" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblAccountNoCaption" runat="server" text="Account No." ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtAccountNo" runat="server" maxlength = "15" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblAccountTitleCaption" runat="server" text="Account Title" ></asp:label></td>
																		<td width="70%"><asp:textbox id="txtAccountTitle" runat="server" maxlength = "500" width="70%"></asp:textbox></td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblAddressCaption" runat="server" text="Address" width="30%"></asp:label></td>
																		<td width="70%"><asp:textbox id="txtAddress" runat="server" maxlength = "500" width="70%"></asp:textbox></td>
																	</tr>																																																												
																</table>
															</td>
															<td vAlign="top" width="50%">
																<table cellSpacing="1" cellPadding="2" width="100%">
																	<tr>
																		<td width="30%"><asp:label id="lblBankTxnType" runat="server" text="Transaction Type" ></asp:label></td>
																		<td Width="70%">
																			<asp:DropDownList id="ddlBankTxnTypeID" runat="server" width="70%"></asp:DropDownList>
																		</td>
																	</tr>
																	<tr>
																		<td width="30%"><asp:label id="lblCurrency" runat="server" text="Currency" ></asp:label></td>
																		<td width="70%">
																			<asp:DropDownList id="ddlCurrencyID" runat="server" width="70%"></asp:DropDownList>
																		</td>
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
															    <asp:DataGrid	id="RadGridBank" 
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
																		<asp:TemplateColumn runat="server" HeaderText="Bank ID">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblBankID" Text='<%# DataBinder.Eval(Container.DataItem, "BankID") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Bank Name">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblBankName" Text='<%# DataBinder.Eval(Container.DataItem, "BankName") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Transaction Type ID">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblBankTxnType" Text='<%# DataBinder.Eval(Container.DataItem, "BankTxnType") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Transaction Type">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblBankTxnTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "BankTxnTypeName") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Branch">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblBranch" Text='<%# DataBinder.Eval(Container.DataItem, "Branch") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Account No.">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblAccountNo" Text='<%# DataBinder.Eval(Container.DataItem, "AccountNo") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Account Title">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblAccountTitle" Text='<%# DataBinder.Eval(Container.DataItem, "AccountTitle") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Address">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblAddress" Text='<%# DataBinder.Eval(Container.DataItem, "Address") %>'/>
																			</itemtemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn runat="server" HeaderText="Currency">
																			<itemtemplate>
																				<asp:label runat="server" id="_lblCurrency" Text='<%# DataBinder.Eval(Container.DataItem, "CurrencyName") %>'/>
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
								    <MODULE:COPYRIGHT id="mdlCopyRight" runat="server" ></MODULE:COPYRIGHT>
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
