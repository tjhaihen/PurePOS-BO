<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="Raven.Web.Secure.Administrator.ChangePassword" EnableSessionState="true" EnableViewState="true"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Change Password</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/pureravenslib/css/styles_blue.css" type="text/css" rel="Stylesheet">
		<script src='/pureravenslib/scripts/common/util.js' language="javascript"></script>
		<script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script> 					
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form runat="server">
			<table border="0" width="100%" cellspacing="0" cellpadding="2" height="100%" >																											
				<td width="80%" valign="top">
					<table border="0" cellSpacing="1" cellPadding="3" width="100%" height="100%">
						<tr>
							<td colspan="2">	
								<!-- BEGIN PAGE HEADER -->
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="100%">
												<!-- BEGIN AJAX MANAGER -->
											<%--	<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
																																								
													</AjaxSettings>
												</telerik:RadAjaxManager>--%>
												<!-- END AJAX MANAGER -->
												<!-- BEGIN NAV BAR --><MODULE:MENU id="Menu" runat="server"></MODULE:MENU>
												<!-- END NAV BAR -->
											</td>
										</tr>
									</table>
									<!-- END PAGE HEADER -->					
							</td>
						</tr>
						<tr>
							<td valign="middle" class="txtmenuname" align="left" width="100%">
								Utility
								<img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
								Change Password
							</td>
						</tr>
						<tr>
							<td height="25" vAlign="middle" width="100%" colSpan="2" align="left">
								<Module:Toolbar id="Toolbar" runat="server"></Module:Toolbar>
						    </td>
						</tr>
						<tr>
							<td  height="100%" vAlign="top" width="100%" colSpan="2" align="left">
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
										<td colspan="3" valign="top">	
											<DIV id="REDiv">																															
												<table width="100%" cellpadding="2" cellspacing="1" border="0">
													<tr>
														<td width="15%" valign="middle">
															User ID
														</td>
														<td width="50%" valign="middle">
															<asp:TextBox	id="txtUserID"
																			runat="server"
																			AutoPostBack="True"
																			width="60%" />														
														</td>
														<td align="right" valign="middle">																											
														</td>
													</tr>
													<tr>
														<td width="15%" valign="middle">
															Username
														</td>
														<td width="50%" valign="middle">
															<asp:TextBox	id="txtUserName"
																			runat="server"
																			ReadOnly="True"
																			width="60%" />
														</td>
														<td align="right" valign="middle">														
														</td>
													</tr>
													<tr style="display:none">
														<td width="15%" valign="middle">
															User Group ID
														</td>
														<td width="50%" valign="middle">
															<asp:TextBox	id="txtUserGroupID"
																			runat="server"
																			width="60%" />														
														</td>
														<td align="right" valign="middle">
															
														</td>
													</tr>
													<tr>														
														<td width="15%" valign="middle">
															Current Password
														</td>
														<td width="50%" valign="middle">															
															<asp:TextBox	id="txtPasswordOld"
																			runat="server"
																			width="60%"
																			TextMode="Password" />															
														</td>
														<td align="right" valign="middle">
															
														</td>
													</tr>	
													<tr>														
														<td width="15%" valign="middle">
															New Password
														</td>
														<td width="50%" valign="middle">															
															<asp:TextBox	id="txtPasswordNew"
																			runat="server"
																			width="60%"
																			TextMode="Password" />															
														</td>
														<td align="right" valign="middle">
															
														</td>
													</tr>
													<tr>														
														<td width="15%" valign="middle">
															Confirm Password
														</td>
														<td width="50%" valign="middle">															
																<asp:TextBox	id="txtPasswordConfirm"
																				runat="server"
																				width="60%"
																				TextMode="Password" />															
														</td>
														<td align="right" valign="middle">
															
														</td>
													</tr>																																						
												</table>
											</DIV>
										</td>
									</tr>									
								</table>
							</td>
						</tr>
						<tr>
							<td ><MODULE:COPYRIGHT id="mdlCopyRight" runat="server" ></MODULE:COPYRIGHT></td>
						</tr>						
					</table>
				</td>				
			</table>			
		</form>
		
		<script src='/pureravenslib/scripts/common/common.vbs' language="vbscript"></script>
		<script src='/pureravenslib/scripts/common/common.js' language="javascript"></script>  
	</body>
</HTML>
