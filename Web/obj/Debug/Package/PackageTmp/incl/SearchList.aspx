<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SearchList.aspx.vb" Inherits="Raven.Web.Secure.Incl.SearchList"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<HTML>
	<HEAD>
		<title>Search List</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/pureravenslib/css/styles_blue.css" type="text/css" rel="Stylesheet">
		<script language="javascript">
		<!--
			function ffocus()
				{
				try
					{
					document.getElementById('txtFilterBy').focus()
					}
				catch(e)
					{
					}
				}
				
			var pos = 0;
			function fnGoFind() 
			{
				var mytext = document.getElementById("txtFindValue")
				if (mytext.value == '') {
					alert('Nothing to find for.');
					return;
				}
				if (document.all) {
					var found = false;
					var text = document.body.createTextRange();
					for (var i=0; i<=pos && (found=text.findText(mytext.value)) != false; i++) {
						text.moveStart("character", 1);
						text.moveEnd("textedit");
					}
					if (found) {
						text.moveStart("character", -1);
						text.findText(mytext.value);
						text.select();
						text.scrollIntoView();						
						pos++;						
					}
					else {
						if (pos == '0')
							alert('"' + mytext.value +'" was not found on this page.');							
						else
							alert('No further occurences of "' + mytext.value +'" were found.');							
						pos=0;
					}
				}
				else if (document.layers) {
					find(mytext.value,false);
				}
			}
			
			function txtFindValue_OnKeyDown() {
				if (event.keyCode == 13) {
					fnGoFind();
					window.event.returnValue=false;
				}
			}
			-->
		</script>
		<script src='/pureravenslib/scripts/common/util.js' language="javascript"></script>
		<SCRIPT SRC='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' LANGUAGE="javascript"></SCRIPT>						
	</HEAD>
	
	<body onload="ffocus()" onkeydown="if (event.keyCode==27){window.close();}">
		<form id="frmInfo" runat="server">
			
			<table border="0" width="100%" height="100%" cellspacing="1" cellpadding="0" bgcolor="Gray">
				
				<tr>
					<td width="100%" height="100%" valign="top" >
						
						<table cellSpacing="1" cellPadding="0" width="100%" height="100%" border="0">
							
							<tr>
								<td align="left" colspan="2">
									
									<TABLE cellSpacing="1" cellPadding="2" width="100%" height="100%" bgcolor="gray">																														
										<TR class=rheader>
											<TD class=rheadercolinfo align=left height=25>
												<asp:Label ID="lblSearchList" Runat="server" /> [Count: <asp:label ID="lblSearchResults" Runat="server"/>]
											</TD>											
										</TR>																																								
										
										<!-- PAGE CONTENT BEGIN HERE -->
										<TR class="rbody">
											<TD class="rbodycol" align="left" height="25" >
												Filter by
												&nbsp;
												<asp:DropDownList	id="ddlFilterBy"
																	runat="server"
																	width="20%" />
												&nbsp;
												<asp:TextBox	id="txtFilterBy"
																runat="server"
																text="*"
																width="20%" />
												&nbsp;
												<asp:Button	id="btnApplyFilter"
															runat="server"
															text=" Apply "
															width="80px"
															style="height:24px;"
															CssClass="sbttn" />
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<INPUT	id="txtFindValue" 
														name="txtFindValue" 
														onchange="javascript:pos=0;"
														onkeypress="javascript:txtFindValue_OnKeyDown();"
														style="WIDTH:15%;background-image:url(/pureravenslib/images/menu_img/Find.gif);background-repeat:no-repeat;background-position:right;" >
												&nbsp;
												<INPUT	id="btnFind" 
														type="button" 
														value=" Find "																				
														name="btnFind" 
														style="width:80px; height:24px;"
														LANGUAGE="javascript" 
														title="Find word"
														onclick="javascript:return fnGoFind()" 
														class="sbttn">																							
															
												<asp:Label ID="lblSearchProcedure" Runat="server" Style="display:none" />
											</TD>
										</TR>
										
										<TR class="rbody">
											<TD class="rbodycol" align="middle" valign="top" >
												<asp:TextBox	id="txtSearchCode" 
																Runat="server" 
																Visible="false" 
																Width="100%">
												</asp:TextBox>												
												<DIV style="OVERFLOW:auto;WIDTH:100%;HEIGHT:370px;">	
													<asp:DataGrid	id=grdSearchList
																	runat="server" 
																	BorderWidth="1"  
																	Width="100%" 
																	CellPadding="2">
																
														<HeaderStyle Font-Bold="True" CssClass=rsubheadercol BackColor=Gainsboro/>
														<ItemStyle CssClass="rbody" />
														<PagerStyle Mode="NumericPages" HorizontalAlign="right" />
														<AlternatingItemStyle BackColor="WhiteSmoke" />
													
													</asp:DataGrid>											
												</DIV>
											</TD>
										</TR>
										<!-- PAGE CONTENT END HERE -->
										
									</TABLE>
									
								</TD>
							</TR>																													
						</TABLE>
						
					</TD>
				</TR>
				
			</TABLE>
		
		</FORM>
		<script src='/pureravenslib/scripts/common/common.js' language="javascript"></script>
	</BODY>
	
</HTML>