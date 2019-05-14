<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SearchList.aspx.vb" Inherits="Raven.Web.Secure.Incl.SearchList" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Search List</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="/pureravenslib/css/styles_blue.css" type="text/css" rel="Stylesheet">
    <script language="javascript">
		<!--
        function ffocus() {
            try {
                document.getElementById('txtFilterBy').focus()
            }
            catch (e) {
            }
        }

        var pos = 0;
        function fnGoFind() {
            var mytext = document.getElementById("txtFindValue")
            if (mytext.value == '') {
                alert('Nothing to find for.');
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

        function txtFindValue_OnKeyDown() {
            if (event.keyCode == 13) {
                fnGoFind();
                window.event.returnValue = false;
            }
        }
			-->
    </script>
    <script src='/pureravenslib/scripts/common/util.js' language="javascript"></script>
    <script src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>' language="javascript"></script>
</head>
<body onload="ffocus()" onkeydown="if (event.keyCode==27){window.close();}">
    <form id="frmInfo" runat="server">
    <table border="0" width="100%" height="100%" cellspacing="1" cellpadding="0">
        <tr>
            <td width="100%" height="100%" valign="top">
                <table cellspacing="1" cellpadding="0" width="100%" height="100%" border="0">
                    <tr>
                        <td align="left" colspan="2">
                            <table cellspacing="1" cellpadding="2" width="100%" height="100%">
                                <tr class="rheader">
                                    <td class="Menu" align="left" height="25">
                                        <asp:Label ID="lblSearchList" runat="server" />
                                        [Count:
                                        <asp:Label ID="lblSearchResults" runat="server" />]
                                    </td>
                                </tr>
                                <!-- PAGE CONTENT BEGIN HERE -->
                                <tr class="rbody">
                                    <td class="rbodycol" align="left" height="25">
                                        Filter by &nbsp;
                                        <asp:DropDownList ID="ddlFilterBy" runat="server" Width="20%" />
                                        &nbsp;
                                        <asp:TextBox ID="txtFilterBy" runat="server" Text="*" Width="20%" />
                                        &nbsp;
                                        <asp:Button ID="btnApplyFilter" runat="server" Text=" Apply " Width="80px" Style="height: 24px;"
                                            CssClass="sbttn" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <input id="txtFindValue" name="txtFindValue" onchange="javascript:pos=0;" onkeypress="javascript:txtFindValue_OnKeyDown();"
                                            style="width: 15%; background-image: url(/pureravenslib/images/menu_img/Find.gif);
                                            background-repeat: no-repeat; background-position: right;">
                                        &nbsp;
                                        <input id="btnFind" type="button" value=" Find " name="btnFind" style="width: 80px;
                                            height: 24px;" language="javascript" title="Find word" onclick="javascript:return fnGoFind()"
                                            class="sbttn">
                                        <asp:Label ID="lblSearchProcedure" runat="server" Style="display: none" />
                                    </td>
                                </tr>
                                <tr class="rbody">
                                    <td class="rbodycol" align="middle" valign="top">
                                        <asp:TextBox ID="txtSearchCode" runat="server" Visible="false" Width="100%">
                                        </asp:TextBox>
                                        <div style="overflow: auto; width: 100%; height: 370px;">
                                            <asp:DataGrid ID="grdSearchList" BorderStyle="None" runat="server" BorderWidth="0"
                                                Width="100%" CellPadding="1" CellSpacing="1">
                                                <HeaderStyle CssClass="gridHeaderStyle" />
                                                <ItemStyle CssClass="gridItemStyle" />
                                                <AlternatingItemStyle CssClass="gridAlternatingItemStyle" />
                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                            </asp:DataGrid>
                                        </div>
                                    </td>
                                </tr>
                                <!-- PAGE CONTENT END HERE -->
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <script src='/pureravenslib/scripts/common/common.js' language="javascript"></script>
</body>
</html>
