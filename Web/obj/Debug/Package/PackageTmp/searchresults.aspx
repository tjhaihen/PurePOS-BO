<%@ Page Language="vb" AutoEventWireup="false" Codebehind="searchresults.aspx.vb" Inherits="Raven.Web.searchresults" %>
<%@ Import Namespace="Raven.Web"%>
<HTML>
  <HEAD>
		<title>Search Results</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/pureravenslib/css/styles_blue.css" type="text/css" rel="Stylesheet">
		
		<script language=javascript>
		<!--
			function CloseWindow(value)
			{
				top.returnValue=value;
				top.close();
			}			
		//-->
		</script>
		
		<script language=javascript>
		<!--
			var pos = 0;
			function fnGoSearch() 
			{
				var mytext = document.getElementById("txtSearchValue")
				if (mytext.value == '') {
					alert('Nothing to search for');
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
			
			function txtSearchValue_OnKeyDown() {
				if (event.keyCode == 13) {
					fnGoSearch();
					window.event.returnValue=false;
				}
			}
		//-->
		</script>
		
  </HEAD>
  
  <div id=loadingmsg style="position:absolute; z-index:3; left:240; top:200; width:200; height:60; 
			  border-width:1; border-style:ridge; background-color:#eeeeee">
			<center>
				<br><br><font face='Verdana' Size=1><b>Loading, Please wait ...</b></font><br><br>
			</center>
	</div>
  
  <body onkeydown="if (event.keyCode==27){window.close();}" 
		onload="try{document.getElementById('txtSearchValue').focus()}catch(e){};try{document.getElementById('txtFilterValueDlg').focus()}catch(e){}">
		
		<form id="frmSearchResult" runat="server">
			
			<asp:panel id="dialogPanel" runat="server" Height="100%" >
				<TABLE cellSpacing=0 cellPadding=5 width="100%" border="0">
					
					<TR>
						<TD align=right colspan=2>
							<!--<B>Ada lebih dari 500 record di dalam database sesuai dengan kriteria yang Anda pilih<br></B>-->
							<b><asp:Label ID="lblInfoInfoLebih" Runat="server" /><BR></b>
						</TD>
					</TR>
					
					<TR>
						<TD width="10%" align=right >
						</TD>
						<TD align=left>
							Filter data dengan kriteria sebagai berikut:
						</TD>
					</TR>
					
					<TR>
						<TD width="10%" align=right>
						</TD>
						<TD align=left>
							
							<TABLE cellSpacing=0 cellPadding=5 width="100%">
								<tr>
									<TD width="25%" align=left>
										Field: <asp:DropDownList ID="listFieldDlg" Runat="server" width="100%" /> 
									</td>
									<TD width="25%" align=left>
										Value (contoh: value*): <asp:TextBox ID="txtFilterValueDlg" onkeypress="javascript:txtFilterValueDlg_onKeyDown();" Runat="server" width="100%" text="*" />
									</td>
									<TD align=left>
									</td>
								</tr>
								<tr valign=top>
									<TD width="25%" align=left>
									</td>
									<TD width="25%" align=left>
										<asp:LinkButton ID="linkApplyFilterDlg" Runat="server" text="Apply" />
									</td>
									<TD align=right>
										<input type="button" value="Close" onClick="window.close();" class="sbttn" height="24px">
									</td>
								</tr>
							</table>
							
						</TD>
					</TR>
					
				</TABLE>
			</asp:panel>
			
			<asp:panel id="SearchResultPanel" runat="server">
		
					<TABLE width="100%" border=1 cellpadding=1 cellspacing=1 bgcolor=#98AAB1>
					
						<tr>
							<td vAlign="top" width="99%" >
							
								<table cellSpacing="10" cellPadding="0" width="100%">
								
									<tr>
										<td style="PADDING-TOP: 5px" align="left">
																				
												<TABLE cellSpacing=0 cellPadding=5 width="100%">
													
													<TR class=rheader>
														<TD class=rheadercol align=left height=25>
															<asp:Label ID="lblInfo" Runat="server" />
														</TD>
													</TR>
													
													<TR class=rbody>
														<TD align=left height="100%">
															
															<DIV style="OVERFLOW: auto; WIDTH: 100%; HEIGHT: 358px">
																
																<asp:DataGrid	id=gridSearchResult 
																				runat="server" 
																				BorderWidth="1"  
																				Width="100%" 
																				CellPadding="0">
																			
																	<HeaderStyle Font-Bold="True" CssClass=rheadercol BackColor=Gainsboro/>
																	<ItemStyle CssClass="rbody" />
																	<PagerStyle Mode="NumericPages" HorizontalAlign="right" />
																
																</asp:DataGrid>
																
															</DIV>
															
														</TD>
													</TR>
													
												</TABLE>
											
										</td>
									</tr>
									
									<TR class="rbody">
										<TD class="smalltext" align="left" height="25">
											
											<TABLE cellSpacing="0" cellPadding="5" width="100%">
												
												<TR class="rbody">
													<TD class="rbodycol" align="left" height="100%">
														
														<asp:panel id="filterPanel" runat="server">
														
															<B>Find a word in the current document :</B>
															<TABLE cellSpacing=0 cellPadding=5 width="110%">
																<tr valign=bottom>
																	<TD height="100%" width="50%" align=left>
																		<INPUT	id="txtSearchValue" 
																				name="textSearchValue" 
																				onchange="javascript:pos=0;"
																				onkeypress="javascript:txtSearchValue_OnKeyDown();"
																				style="WIDTH: 100%" >
																	</TD>
																	<TD height="100%" align="left" width="20%">
																		<INPUT	id="btnGoSearch" 
																				type="button" 
																				value="Search" 
																				name="btnGoSearch" 
																				LANGUAGE="javascript" 
																				title="Search selected text"
																				onclick="javascript:return fnGoSearch()" 
																				class="sbttn">
																				
																		<INPUT	type="button" 
																				value="Close" 
																				title="Close this window"
																				onClick="javascript:window.close();" 
																				class="sbttn">
																	</TD>
																</TR>
															</TABLE>
														
														</asp:panel>
														  
													</TD>
												</TR>
												
											</TABLE>
											
										</TD>
									</TR>
									
								
								</table>
							
							</td>
						</tr>
						
					</table>
			
			</asp:panel>
			
		</form>
	</body>
</HTML>

<script>
	if (document.all) document.all.loadingmsg.style.visibility='hidden';
</script>
<script>
	if (document.layers) document.loadingmsg.visibility='hidden'
</script>
<script>
	if (document.getElementById) document.getElementById('loadingmsg').style.visibility='hidden'
</script>

<!-- Script Document OnKeyDown -->

<script language="javascript">

try 
	{		
	var doc_tables = document.getElementById("gridSearchResult").all.tags("TR");
	doc_tables(1).style.backgroundColor='palegoldenrod';	
	}
catch(e)
	{
	}
					
</script>

<SCRIPT ID=clientEventHandlersJS LANGUAGE=javascript>
<!--

function txtFilterValueDlg_onKeyDown(){
	if (event.keyCode == 13) 
	{
		__doPostBack('linkApplyFilterDlg','');
		window.event.returnValue=false;
	}
}

function document_onclick() {
}

function salin(value){
		for (i=1; i<doc_tables.length; i++)
		{
			if (doc_tables(i).style.backgroundColor=='palegoldenrod')
			{				
				doc_tables(i).onclick();
			}
		}
}

function document_onkeydown(doc_tables){
	
	if (typeof(doc_tables)!=='undefined')
	{
	
		var keycode = event.keyCode;
		var ketemu = false;
		
		if (keycode==13)
		{
			salin('');
		}
		
		if (keycode == 38)
		{
			for (i=1; i<doc_tables.length; i++)
			{
				if (ketemu == false)
				{
					if (doc_tables(i).style.backgroundColor=='palegoldenrod')
					{
						if (i>1)
						{					
							doc_tables(i).style.backgroundColor='White';
							doc_tables(i-1).style.backgroundColor='PaleGoldenrod';	
							
							var found = false;
							var text = document.body.createTextRange();
							var doc_td = doc_tables(i-1).all.tags("TD");
							
							found=text.findText(doc_td(0).innerHTML)			
							if (found) {
								text.moveStart("character", -1);
								text.findText(doc_td(0).innerHTML);
								
								text.scrollIntoView();
								pos++;
							}
							
							ketemu = true;
							i-=1;
						}
					}
				}
				else
				{
					doc_tables(i).style.backgroundColor='white';
				}		
			}
		}
		
		if (keycode == 40)
		{
			//var doc_tables = document.all.tags("TR");			
					
			for (i=1; i<doc_tables.length; i++)
			{	
				//alert(doc_tables(i).style.backgroundColor);
				if (ketemu == false)
				{
					if (doc_tables(i).style.backgroundColor=='palegoldenrod')
					{
						if (i<doc_tables.length-1)
						{
								doc_tables(i).style.backgroundColor='White';
								doc_tables(i+1).style.backgroundColor='PaleGoldenrod';
													
								var found = false;
								var text = document.body.createTextRange();
								var doc_td = doc_tables(i+1).all.tags("TD");
								//alert(doc_td(0).innerHTML+' '+doc_td(1).innerHTML);
								found=text.findText(doc_td(0).innerHTML)			
								if (found) {
									text.moveStart("character", -1);
									text.findText(doc_td(0).innerHTML);
									//text.select();
									text.scrollIntoView();
									pos++;
								}
								
								ketemu = true;
								i+=1;
								//break;
						}
					}
				}
				else
				{
					doc_tables(i).style.backgroundColor='White';
				}
							
			}
		}		
	}
}

//-->
</SCRIPT>
<SCRIPT LANGUAGE=javascript FOR=document EVENT=onclick>
<!--
document_onclick()
//-->
</SCRIPT>
<SCRIPT LANGUAGE=javascript FOR=document EVENT=onkeydown>
<!--
document_onkeydown(doc_tables)
//-->
</SCRIPT>
