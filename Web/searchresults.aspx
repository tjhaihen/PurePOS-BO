<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="searchresults.aspx.vb"
    Inherits="Raven.Web.searchresults" %>

<%@ Import Namespace="Raven.Web" %>
<html>
<head>
    <title>Search Results</title>
    <meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/pureravenslib/css/styles_blue.css" type="text/css" rel="Stylesheet">
    <script language="javascript">
		<!--
        function CloseWindow(value) {
            top.returnValue = value;
            top.close();
        }			
		//-->
    </script>
    <script language="javascript">
		<!--
        var pos = 0;
        function fnGoSearch() {
            var mytext = document.getElementById("txtSearchValue")
            if (mytext.value == '') {
                alert('Nothing to search for');
                return;
            }
            if (document.all) {
                var found = false;
                var text = document.body.createTextRange();
                for (var i = 0; i <= pos && (found = text.findText(mytext.value)) != false; i++) {
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
                        alert('"' + mytext.value + '" was not found on this page.');
                    else
                        alert('No further occurences of "' + mytext.value + '" were found.');
                    pos = 0;
                }
            }
            else if (document.layers) {
                find(mytext.value, false);
            }
        }

        function txtSearchValue_OnKeyDown() {
            if (event.keyCode == 13) {
                fnGoSearch();
                window.event.returnValue = false;
            }
        }
		//-->
    </script>
</head>
<div id="loadingmsg" style="position: absolute; z-index: 3; left: 240; top: 200;
    width: 200; height: 60; border-width: 1; border-style: ridge; background-color: #eeeeee">
    <center>
        <br>
        <br>
        <font face='Verdana' size="1"><b>Loading, Please wait ...</b></font><br>
        <br>
    </center>
</div>
<body onkeydown="if (event.keyCode==27){window.close();}" onload="try{document.getElementById('txtSearchValue').focus()}catch(e){};try{document.getElementById('txtFilterValueDlg').focus()}catch(e){}">
    <form id="frmSearchResult" runat="server">
    <asp:Panel ID="dialogPanel" runat="server" Height="100%">
        <table cellspacing="0" cellpadding="5" width="100%" border="0">
            <tr>
                <td align="right" colspan="2">
                    <!--<B>Ada lebih dari 500 record di dalam database sesuai dengan kriteria yang Anda pilih<br></B>-->
                    <b>
                        <asp:Label ID="lblInfoInfoLebih" runat="server" /><br>
                    </b>
                </td>
            </tr>
            <tr>
                <td width="10%" align="right">
                </td>
                <td align="left">
                    Filter data dengan kriteria sebagai berikut:
                </td>
            </tr>
            <tr>
                <td width="10%" align="right">
                </td>
                <td align="left">
                    <table cellspacing="0" cellpadding="5" width="100%">
                        <tr>
                            <td width="25%" align="left">
                                Field:
                                <asp:DropDownList ID="listFieldDlg" runat="server" Width="100%" />
                            </td>
                            <td width="25%" align="left">
                                Value (contoh: value*):
                                <asp:TextBox ID="txtFilterValueDlg" onkeypress="javascript:txtFilterValueDlg_onKeyDown();"
                                    runat="server" Width="100%" Text="*" />
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr valign="top">
                            <td width="25%" align="left">
                            </td>
                            <td width="25%" align="left">
                                <asp:LinkButton ID="linkApplyFilterDlg" runat="server" Text="Apply" />
                            </td>
                            <td align="right">
                                <input type="button" value="Close" onclick="window.close();" class="sbttn" height="24px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="SearchResultPanel" runat="server">
        <table width="100%" border="1" cellpadding="1" cellspacing="1" bgcolor="#98AAB1">
            <tr>
                <td valign="top" width="99%">
                    <table cellspacing="10" cellpadding="0" width="100%">
                        <tr>
                            <td style="padding-top: 5px" align="left">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr class="rheader">
                                        <td class="rheadercol" align="left" height="25">
                                            <asp:Label ID="lblInfo" runat="server" />
                                        </td>
                                    </tr>
                                    <tr class="rbody">
                                        <td align="left" height="100%">
                                            <div style="overflow: auto; width: 100%; height: 358px">
                                                <asp:DataGrid ID="gridSearchResult" BorderStyle="None" runat="server" BorderWidth="1"
                                                    Width="100%" CellPadding="1" CellSpacing="1">
                                                    <HeaderStyle CssClass="gridHeaderStyle" />
                                                    <ItemStyle CssClass="gridItemStyle" />
                                                    <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                    <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                </asp:DataGrid>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class="rbody">
                            <td class="smalltext" align="left" height="25">
                                <table cellspacing="0" cellpadding="5" width="100%">
                                    <tr class="rbody">
                                        <td class="rbodycol" align="left" height="100%">
                                            <asp:Panel ID="filterPanel" runat="server">
                                                <b>Find a word in the current document :</b>
                                                <table cellspacing="0" cellpadding="5" width="110%">
                                                    <tr valign="bottom">
                                                        <td height="100%" width="50%" align="left">
                                                            <input id="txtSearchValue" name="textSearchValue" onchange="javascript:pos=0;" onkeypress="javascript:txtSearchValue_OnKeyDown();"
                                                                style="width: 100%">
                                                        </td>
                                                        <td height="100%" align="left" width="20%">
                                                            <input id="btnGoSearch" type="button" value="Search" name="btnGoSearch" language="javascript"
                                                                title="Search selected text" onclick="javascript:return fnGoSearch()" class="sbttn">
                                                            <input type="button" value="Close" title="Close this window" onclick="javascript:window.close();"
                                                                class="sbttn">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </form>
</body>
</html>
<script>
    if (document.all) document.all.loadingmsg.style.visibility = 'hidden';
</script>
<script>
    if (document.layers) document.loadingmsg.visibility = 'hidden'
</script>
<script>
    if (document.getElementById) document.getElementById('loadingmsg').style.visibility = 'hidden'
</script>
<!-- Script Document OnKeyDown -->
<script language="javascript">

    try {
        var doc_tables = document.getElementById("gridSearchResult").all.tags("TR");
        doc_tables(1).style.backgroundColor = 'palegoldenrod';
    }
    catch (e) {
    }
					
</script>
<script id="clientEventHandlersJS" language="javascript">
<!--

    function txtFilterValueDlg_onKeyDown() {
        if (event.keyCode == 13) {
            __doPostBack('linkApplyFilterDlg', '');
            window.event.returnValue = false;
        }
    }

    function document_onclick() {
    }

    function salin(value) {
        for (i = 1; i < doc_tables.length; i++) {
            if (doc_tables(i).style.backgroundColor == 'palegoldenrod') {
                doc_tables(i).onclick();
            }
        }
    }

    function document_onkeydown(doc_tables) {

        if (typeof (doc_tables) !== 'undefined') {

            var keycode = event.keyCode;
            var ketemu = false;

            if (keycode == 13) {
                salin('');
            }

            if (keycode == 38) {
                for (i = 1; i < doc_tables.length; i++) {
                    if (ketemu == false) {
                        if (doc_tables(i).style.backgroundColor == 'palegoldenrod') {
                            if (i > 1) {
                                doc_tables(i).style.backgroundColor = 'White';
                                doc_tables(i - 1).style.backgroundColor = 'PaleGoldenrod';

                                var found = false;
                                var text = document.body.createTextRange();
                                var doc_td = doc_tables(i - 1).all.tags("TD");

                                found = text.findText(doc_td(0).innerHTML)
                                if (found) {
                                    text.moveStart("character", -1);
                                    text.findText(doc_td(0).innerHTML);

                                    text.scrollIntoView();
                                    pos++;
                                }

                                ketemu = true;
                                i -= 1;
                            }
                        }
                    }
                    else {
                        doc_tables(i).style.backgroundColor = 'white';
                    }
                }
            }

            if (keycode == 40) {
                //var doc_tables = document.all.tags("TR");			

                for (i = 1; i < doc_tables.length; i++) {
                    //alert(doc_tables(i).style.backgroundColor);
                    if (ketemu == false) {
                        if (doc_tables(i).style.backgroundColor == 'palegoldenrod') {
                            if (i < doc_tables.length - 1) {
                                doc_tables(i).style.backgroundColor = 'White';
                                doc_tables(i + 1).style.backgroundColor = 'PaleGoldenrod';

                                var found = false;
                                var text = document.body.createTextRange();
                                var doc_td = doc_tables(i + 1).all.tags("TD");
                                //alert(doc_td(0).innerHTML+' '+doc_td(1).innerHTML);
                                found = text.findText(doc_td(0).innerHTML)
                                if (found) {
                                    text.moveStart("character", -1);
                                    text.findText(doc_td(0).innerHTML);
                                    //text.select();
                                    text.scrollIntoView();
                                    pos++;
                                }

                                ketemu = true;
                                i += 1;
                                //break;
                            }
                        }
                    }
                    else {
                        doc_tables(i).style.backgroundColor = 'White';
                    }

                }
            }
        }
    }

//-->
</script>
<script language="javascript" for="document" event="onclick">
<!--
document_onclick()
//-->
</script>
<script language="javascript" for="document" event="onkeydown">
<!--
document_onkeydown(doc_tables)
//-->
</script>
