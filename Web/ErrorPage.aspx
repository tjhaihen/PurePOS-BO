<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ErrorPage.aspx.vb" Inherits="Raven.Web.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body ms_positioning="GridLayout">
		<form id="Form1" method="post" runat="server">
			<H1><FONT face="Verdana" size="4">An error has occurred</FONT></H1>
			<P><FONT face="Verdana" size="2">We were unable to complete your request. This failure 
					has been logged with our system administrators, who are currently working to 
					resolve the problem. We apologize for any inconvenience caused by this 
					temporary service outage, and we appreciate your patience as we work to improve 
					our web site.</FONT></P>
			<asp:Label id="lblErrorDesc" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
