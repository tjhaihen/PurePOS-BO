<%@ Page CodeBehind="default.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="Raven.Web.Secure.Inquiry.APInquiry" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../incl/copyRightModule.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>A/P Inquiry</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">
    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>
    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>
    <script language="javascript">
        function count(chkvalue, chk) {
            var PUnitTotal;
            PUnitTotal = CurVal(document.getElementById('txtPurchaseUnitTotal').value);

            var PReturnTotal;
            PReturnTotal = CurVal(document.getElementById('txtPurchaseReturnTotal').value);

            var APDueTotal;
            APDueTotal = CurVal(document.getElementById('txtAPDueTotal').value);

            tambah = parseFloat(chkvalue);

            var cb = event.srcElement;
            var curElement = cb;

            if (cb.checked) {
                PUnitTotal = PUnitTotal + tambah
                document.getElementById('txtPurchaseUnitTotal').value = FmtCur(PUnitTotal);
            }
            else {
                PUnitTotal = PUnitTotal - tambah
                document.getElementById('txtPurchaseUnitTotal').value = FmtCur(PUnitTotal);
            }

            document.getElementById('txtAPDueTotal').value = FmtCur(PUnitTotal - PReturnTotal);
        }
        function countAll() {
            var isChecked = document.all.chkSelectAllPUnit.checked;
            if (isChecked) {
                document.getElementById('txtPurchaseUnitTotal').value = document.getElementById('lblTotalPUnit').innerHTML;
            }
            else {
                document.getElementById('txtPurchaseUnitTotal').value = '0.00';
            }
            document.getElementById('txtAPDueTotal').value = FmtCur(CurVal(document.getElementById('txtPurchaseUnitTotal').value) - CurVal(document.getElementById('txtPurchaseReturnTotal').value));
        }
        function countPReturn(chkvalue, chk) {
            var PUnitTotal;
            PUnitTotal = CurVal(document.getElementById('txtPurchaseUnitTotal').value);

            var PReturnTotal;
            PReturnTotal = CurVal(document.getElementById('txtPurchaseReturnTotal').value);

            var APDueTotal;
            APDueTotal = CurVal(document.getElementById('txtAPDueTotal').value);

            tambah = parseFloat(chkvalue);

            var cb = event.srcElement;
            var curElement = cb;

            if (cb.checked) {
                PReturnTotal = PReturnTotal + tambah
                document.getElementById('txtPurchaseReturnTotal').value = FmtCur(PReturnTotal);
            }
            else {
                PReturnTotal = PReturnTotal - tambah
                document.getElementById('txtPurchaseReturnTotal').value = FmtCur(PReturnTotal);
            }

            document.getElementById('txtAPDueTotal').value = FmtCur(PUnitTotal - PReturnTotal);
        }
        function countAllPReturn() {
            var isChecked = document.all.chkSelectAllPReturn.checked;
            if (isChecked) {
                document.getElementById('txtPurchaseReturnTotal').value = document.getElementById('lblTotalPReturn').innerHTML;
            }
            else {
                document.getElementById('txtPurchaseReturnTotal').value = '0.00';
            }
            document.getElementById('txtAPDueTotal').value = FmtCur(CurVal(document.getElementById('txtPurchaseUnitTotal').value) - CurVal(document.getElementById('txtPurchaseReturnTotal').value));
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form runat="server">
    <table border="0" cellspacing="0" cellpadding="2" width="100%" height="100%">
        <tr>
            <td valign="top" width="80%">
                <table border="0" cellspacing="1" cellpadding="3" width="100%" height="100%">
                    <tr>
                        <td colspan="2">
                            <!-- BEGIN PAGE HEADER -->
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td valign="top" width="100%">
                                        <!-- BEGIN AJAX MANAGER -->
                                        <%--<telerik:RadAjaxManager id="RadAjaxManager1" runat="server"  EnableOutsideScripts="True">
													<AjaxSettings>
																															
													</AjaxSettings>
												</telerik:RadAjaxManager>--%>
                                        <!-- END AJAX MANAGER -->
                                        <!-- BEGIN NAV BAR -->
                                        <Module:Menu ID="Menu" runat="server"></Module:Menu>
                                        <!-- END NAV BAR -->
                                    </td>
                                </tr>
                            </table>
                            <!-- END PAGE HEADER -->
                        </td>
                    </tr>
                    <tr>
                        <td class="txtmenuname" valign="middle" width="100%" align="left">
                            Inquiry
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            A/P Inquiry
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                <tr>
                                    <td width="1" class="my_toolbarbutton_left">
                                    </td>
                                    <td valign="middle">
                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbtnNew" class="my_toolbarbutton" Text="New" CausesValidation="false"
                                            Style="color: black; text-decoration: none;"></asp:LinkButton>
                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                        <asp:LinkButton runat="server" ID="lbtnRefresh" class="my_toolbarbutton" Text="Refresh"
                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                        <asp:LinkButton runat="server" ID="lbtnSave" class="my_toolbarbutton" Text="Save"
                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                        <asp:LinkButton runat="server" ID="lbtnPrint" class="my_toolbarbutton" Text="Print A/P Payment Order"
                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absMiddle" height="20">
                                        <asp:LinkButton runat="server" ID="lbtnPrintAPAnalysisReport" class="my_toolbarbutton"
                                            Text="Print A/P Analysis Report" CausesValidation="false" Style="color: black;
                                            text-decoration: none;"></asp:LinkButton>
                                    </td>
                                    <td width="1" class="my_toolbarbutton_right">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Record Filter"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblAPAnalysisNo" runat="server" Text="A/P Analysis No."></asp:Label>
                                                                    </td>
                                                                    <td width="40%">
                                                                        <telerik:RadComboBox ID="RadComboBoxAPAnalysisNo" ShowMoreResultBox="False" AutoPostBack="true"
                                                                            AllowCustomText="True" Width="360px" ItemRequestTimeout="200" DropDownWidth="500px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="200px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="APAnalysisNo"
                                                                            DataValueField="APAnalysisNo" ShowDropDownOnTextboxClick="True">
                                                                            <ItemTemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="width: 120px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "APAnalysisNo") %>
                                                                                        </td>
                                                                                        <td style="width: 100px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "APAnalysisPeriod") %>
                                                                                        </td>
                                                                                        <td style="width: 200px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 500px; text-align: left; font-family: tahoma,arial;" cellpadding="1"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="width: 120px;">
                                                                                            <b>A/P Analysis No.</b>
                                                                                        </td>
                                                                                        <td style="width: 100px;">
                                                                                            <b>Period</b>
                                                                                        </td>
                                                                                        <td style="width: 200px;">
                                                                                            <b>Supplier</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPeriod" runat="server" Text="Period"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadDatePicker ID="RadSDate" runat="server" AutoPostBack="false" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="100px" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                        &nbsp;&nbsp;to&nbsp;&nbsp;
                                                                        <telerik:RadDatePicker ID="RadEDate" runat="server" AutoPostBack="false" MinDate="2006-01-01"
                                                                            SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                            <DateInput Width="100px" Font-Size="XSmall">
                                                                            </DateInput>
                                                                            <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                        </telerik:RadDatePicker>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSupplierIDCaption" runat="server" Text="Supplier ID"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <telerik:RadComboBox ID="RadComboBoxEntitiesID" ShowMoreResultBox="false" AutoPostBack="True"
                                                                            AllowCustomText="True" Width="360px" ItemRequestTimeout="200" DropDownWidth="423px"
                                                                            HighlightTemplatedItems="true" EnableLoadOnDemand="true" MarkFirstMatch="true"
                                                                            Height="190px" runat="server" Skin="WebBlue" MaxLength="15" DataTextField="EntitiesName"
                                                                            DataValueField="EntitiesSeqNo" ShowDropDownOnTextboxClick="False">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Supplier ID</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Supplier Seq No.</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Supplier Name</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSupplierNameCaption" runat="server" Text="Supplier Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEntitiesName" runat="server" ReadOnly="True" Width="360px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkShowOutstandingOnly" runat="server" Text="Show Outstanding Only"
                                                                            AutoPostBack="True"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
                                    <!-- BEGIN RECORD LIST SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RLDiv.style.display == '') {RLDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RLDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordListCaption" runat="server" Text="Record List"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div style="width: 100%; height: 100%; overflow: auto" id="RLDiv">
                                                <table cellspacing="2" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td width="50%" class="rheader" style="text-align: center">
                                                            <asp:Label ID="lblPurchaseUnitCaption" runat="server" Text="Purchase Unit"></asp:Label>
                                                        </td>
                                                        <td width="50%" class="rheader" style="text-align: center">
                                                            <asp:Label ID="lblPurchaseReturnCaption" runat="server" Text="Purchase Return"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%">
                                                            <asp:LinkButton ID="lbtnSelectAllPUnit" runat="server" Text="[Select All]"></asp:LinkButton>
                                                            &nbsp;&nbsp;
                                                            <asp:LinkButton ID="lbtnDeselectAllPUnit" runat="server" Text="[Deselect All]"></asp:LinkButton>
                                                        </td>
                                                        <td width="50%">
                                                            <asp:LinkButton ID="lbtnSelectAllPReturn" runat="server" Text="[Select All]"></asp:LinkButton>
                                                            &nbsp;&nbsp;
                                                            <asp:LinkButton ID="lbtnDeselectAllPReturn" runat="server" Text="[Deselect All]"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <asp:DataGrid ID="grdPUnit" runat="server" AutoGenerateColumns="False" BorderColor="Gainsboro"
                                                                BorderWidth="0" GridLines="None" Width="100%" AllowPaging="False" AllowSorting="True"
                                                                PageSize="20" DataKeyField="" ShowFooter="false" CellPadding="2" CellSpacing="1">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Pilih" HeaderStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsAnalyzed") %>'
                                                                                Enabled='<%# NOT (DataBinder.Eval(Container.DataItem, "IsAnalyzed")) %>' ID="_chkPUnit" />
                                                                        </ItemTemplate>
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllPUnit" id="chkSelectAllPUnit" type="checkbox" style="display: none;"
                                                                                onclick="javascript:checkAllv2(this.form,'_chkPUnit', 'chkSelectAllPUnit');countAll();">
                                                                        </HeaderTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="PUnitNo" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseUnitNoCaption" Text="Purchase Unit No." />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td style="color: #000000;">
                                                                                        <asp:Label runat="server" ID="_lblPurchaseUnitNo" Text='<%# DataBinder.Eval(Container.DataItem, "PUnitNo") %>'
                                                                                            Style="display: none;" />
                                                                                        <asp:LinkButton runat="server" ID="_lbtnPUnitNo" Text='<%# DataBinder.Eval(Container.DataItem, "PUnitNo") %>'
                                                                                            CommandName="_PUnit" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblPurchaseUnitDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "PUnitDate"),"dd-MM-yyyy") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="VoucherNo" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="120" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblAPInvoiceNoCaption" Text="A/P Invoice No." />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAPInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "VoucherNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="total" HeaderText="Total" HeaderStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100"
                                                                        FooterStyle-HorizontalAlign="Right" FooterStyle-Width="100">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseTotalCaption" Text="Total" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Total"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <asp:DataGrid ID="grdPReturn" runat="server" AutoGenerateColumns="False" CellSpacing="1"
                                                                BorderColor="Gainsboro" BorderWidth="0" GridLines="None" Width="100%" AllowPaging="False"
                                                                AllowSorting="True" PageSize="20" DataKeyField="" ShowFooter="false" CellPadding="2">
                                                                <HeaderStyle CssClass="gridheaderstyle" />
                                                                <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
                                                                <ItemStyle CssClass="gridItemstyle" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Pilih" HeaderStyle-HorizontalAlign="Center"
                                                                        HeaderStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsAnalyzed") %>'
                                                                                Enabled='<%# NOT (DataBinder.Eval(Container.DataItem, "IsAnalyzed")) %>' ID="_chkPReturn" />
                                                                        </ItemTemplate>
                                                                        <HeaderTemplate>
                                                                            <input name="chkSelectAllPReturn" id="chkSelectAllPReturn" type="checkbox" style="display: none;"
                                                                                onclick="javascript:checkAllv2(this.form,'_chkPReturn', 'chkSelectAllPReturn');countAllPReturn();">
                                                                        </HeaderTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="PReturnNo" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="150" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseReturnNoCaption" Text="Purchase Return No." />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td style="color: #000000;">
                                                                                        <asp:Label runat="server" ID="_lblPurchaseReturnNo" Text='<%# DataBinder.Eval(Container.DataItem, "PReturnNo") %>'
                                                                                            Style="display: none;" />
                                                                                        <asp:LinkButton runat="server" ID="_lbtnPReturnNo" Text='<%# DataBinder.Eval(Container.DataItem, "PReturnNo") %>'
                                                                                            CommandName="_PReturn" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="_lblPurchaseReturnDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "PReturnDate"),"dd-MM-yyyy") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="DCNoteNo" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="120" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblDCNoteNoCaption" Text="Credit Note No." />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblDCNoteNo" Text='<%# DataBinder.Eval(Container.DataItem, "DCNoteNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="VoucherNo" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="120" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblAPInvoiceNoCaption" Text="A/P Invoice No." />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblAPInvoiceNo" Text='<%# DataBinder.Eval(Container.DataItem, "VoucherNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" SortExpression="total" HeaderText="Total" HeaderStyle-HorizontalAlign="Right"
                                                                        HeaderStyle-Width="100" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100"
                                                                        FooterStyle-HorizontalAlign="Right" FooterStyle-Width="100">
                                                                        <HeaderTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseTotalCaption" Text="Total" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPurchaseTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Total"),"#,##0.00") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" width="100%">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" align="right">
                                                            <asp:Label ID="lblPurchaseUnitTotalCaption" runat="server" Text="Purchase Unit Total"></asp:Label>
                                                            <asp:TextBox ID="txtPurchaseUnitTotal" runat="server" ReadOnly="true" Width="150px"
                                                                Style="text-align: right" />
                                                            <asp:Label ID="lblTotalPUnit" runat="server" Style="display: none" />
                                                        </td>
                                                        <td width="50%" align="right">
                                                            <asp:Label ID="lblPurchaseReturnTotalCaption" runat="server" Text="Purchase Return Total"></asp:Label>
                                                            <asp:TextBox ID="txtPurchaseReturnTotal" runat="server" ReadOnly="true" Width="150px"
                                                                Style="text-align: right" />
                                                            <asp:Label ID="lblTotalPReturn" runat="server" Style="display: none" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" align="left">
                                                            <table cellpadding="2" cellspacing="1" style="background-color: #999999;">
                                                                <tr>
                                                                    <td style="background-color: #F4921B; width: 24px;">
                                                                    </td>
                                                                    <td style="background-color: #EEEEEE; width: 80px;">
                                                                        Paid
                                                                    </td>
                                                                    <td style="background-color: #9CC525; width: 24px;">
                                                                    </td>
                                                                    <td style="background-color: #EEEEEE; width: 80px;">
                                                                        Analyzed
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="50%" align="right">
                                                            <asp:Label ID="lblAPDueTotalCaption" runat="server" Text="A/P Due Total"></asp:Label>
                                                            <asp:TextBox ID="txtAPDueTotal" runat="server" ReadOnly="true" Width="150px" Style="text-align: right" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD LIST SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Copyright ID="mdlCopyRight" runat="server" PathPrefix=".."></Module:Copyright>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadCalendar ID="sharedCalendar" runat="server" EnableMultiSelect="false"
        RangeMinDate="2011/04/01">
    </telerik:RadCalendar>
    <asp:PlaceHolder ID="sharedCalendarPlaceHolder" runat="server"></asp:PlaceHolder>
    </form>
    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>
    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>
</body>
</html>
