<%@ Register TagPrefix="Module" TagName="Copyright" Src="../Incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../incl/Menu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Header" Src="../incl/Header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TermsAndConditions.aspx.vb" Inherits="Raven.Web.TermsAndConditions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Terms And Condition</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
		<script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" bgColor="#ffffff" text="#000000" MS_POSITIONING="GridLayout"
		MARGINHEIGHT="0" MARGINWIDTH="0">
		<form runat="server">
			<table border="0" cellSpacing="0" cellPadding="2" width="100%" height="100%">
				<tr>
					<td vAlign="top" width="80%">
						<table border="0" cellSpacing="1" cellPadding="3" width="100%" bgColor="gray" height="100%">
							<tr>
								<td colSpan="2">
									<!-- BEGIN PAGE HEADER -->
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="100%">
												<!-- BEGIN NAV BAR --><MODULE:MENU id="Menu" runat="server"></MODULE:MENU>
												<!-- END NAV BAR --></td>
										</tr>
										<tr>
											<td class="hdr" height="20" vAlign="middle" width="100%" align="left">
												<!-- BEGIN HEADER --><MODULE:HEADER id="header" runat="server"></MODULE:HEADER>
												<!-- END HEADER --></td>
										</tr>
									</table>
									<!-- END PAGE HEADER --></td>
							</tr>
							<tr>
								<td class="rheadercol" vAlign="middle" width="100%" align="left">Terms And Condition
								</td>
								<td class="rheadercol" vAlign="middle" width="25" align="center"><IMG border="0" align="absMiddle" src="/pureravenslib/Images/Windows.gif">
								</td>
							</tr>
							<tr>
								<td  height="100%" vAlign="top" width="100%" colSpan="2" align="left">
									<DIV style="WIDTH: 100%; HEIGHT: 100%; OVERFLOW: auto">
										<table width="100%" height="100%">
											<tr>
												<td width="50%" height="100%" valign="top">
													<!-- START TERMS AND CONDITION CODE -->
													
													<!-- END TERMS AND CONDITION CODE -->
												</td>	
												<td>
												</td>											
											</tr>																					
										</table>
									</div>
								</td>
							</tr>
							<tr>
								<td bgColor="black" height="20" vAlign="middle" width="100%" colSpan="2" align="left"><MODULE:COPYRIGHT id="mdlCopyRight" runat="server" PathPrefix=".."></MODULE:COPYRIGHT></td>
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
