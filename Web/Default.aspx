<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="Raven.Web._Default" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="incl/copyRightModule.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>PurePOS</title>
		<link rel="shortcut icon" type="image/x-icon" href="/pureravenslib/images/ravenicon.ico" />
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href='/pureravenslib/css/styles_blue.css' type="text/css" rel="Stylesheet">
  </HEAD>
	<body ms_positioning="GridLayout">
		<form id="frmDefault" runat="server">			
			<table border="0" width="100%" height="100%" cellspacing="0" cellpadding="0" >
				<tr align=left style="background-color: #E3F3F9">
				    <td style="width:80px">
				        <img src="/pureravenslib/images/pureposlogo.png" border="0" alt="" align="absmiddle" width="80px" height="80px" />
				    </td>
					<td class="txttitle" valign="middle" style="padding-left: 20px; height: 32px; width: 100%">
		                PurePOS
		            </td>				
				</tr>
				<tr align=center>
					<td width="100%" height=35 colspan="2">
					    <h5> </h5>
					    <br>
					    <br>
					    <br>
					    <br>
						    <IMG src="/pureravenslib/images/companylogo.png">
					    <br>
					</td>
				</tr>
				<tr align=center>
					<td width="100%" height=50 colspan="2">
					    <a href="JavaScript:openMainWindow()">Enter</a>
					</td>
					
				</tr>
				<tr align="center">
				    <td valign="bottom" width="100%" colspan="2">
				        <!-- BEGIN PAGE FOOTER-->
			            <MODULE:COPYRIGHT id="mdlCopyRight" runat="server" PathPrefix=".."></MODULE:COPYRIGHT>
			            <!-- END PAGE FOOTER-->	
				    </td>
				</tr>
			</table>				
		</form>
	
	</body>
</HTML>
