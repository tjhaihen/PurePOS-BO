<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CSSToolbar.ascx.vb"
    Inherits="Raven.CSSToolbar" %>
<%@ Import Namespace="Raven.Web" %>
<link rel="stylesheet" type="text/css" href="/pureravenslib/css/csstoolbar_blue.css" />
<div id="DivToolbarM">
    <table class="ToolbarM" cellpadding="1" cellspacing="0" border="0">
        <tr align="center" valign="middle">
            <asp:Panel runat="server" ID="TMPnlNew">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnNew" ToolTip="New" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbnew.png" alt="" border="0" /><br />New</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlSave">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnSave" ToolTip="Save" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbsave.png" alt="" border="0"/><br />Save</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowAdd" runat="server" Visible="false" />
                    <asp:CheckBox ID="chkIsAllowEdit" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlDelete">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnDelete" ToolTip="Delete" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbdelete.png" alt="" border="0" /><br />Delete</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowDelete" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlApprove">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnApprove" ToolTip="Approve" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbapprove.png" alt="" border="0" /><br />Approve</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowApprove" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlVoid">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnVoid" ToolTip="Void" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbvoid.png" alt="" border="0" /><br />Void</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowVoid" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrint">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnPrint" ToolTip="Print" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbprint.png" alt="" border="0" /><br />Print</asp:LinkButton>
                    <asp:CheckBox ID="chkIsAllowPrint" runat="server" Visible="false" />
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlPrevious">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnPrevious" ToolTip="Back" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbback.png" alt="" border="0" /><br />Back</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlNext">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnNext" ToolTip="Next" CausesValidation="false"
                        Width="70px"><img src="/pureravenslib/images/tbnext.png" alt="" border="0" /><br />Next</asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlOther1" Visible="false">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnOther1" ToolTip="Other1" Text='<img src="/pureravenslib/images/tbother1.png" alt="" border="0" /><br />Other1'
                        CausesValidation="false" Width="70px">                        
                    </asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlOther2" Visible="false">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnOther2" ToolTip="Other2" Text='<img src="/pureravenslib/images/tbother2.png" alt="" border="0" /><br />Other2'
                        CausesValidation="false" Width="70px"></asp:LinkButton>
                </td>
            </asp:Panel>
            <asp:Panel runat="server" ID="TMPnlOther3" Visible="false">
                <td align="center" valign="middle">
                    <asp:LinkButton runat="server" ID="lbtnOther3" ToolTip="Other3" Text='<img src="/pureravenslib/images/tbother3.png" alt="" border="0" /><br />Other3'
                        CausesValidation="false" Width="70px"></asp:LinkButton>
                </td>
            </asp:Panel>
        </tr>
        <tr style="display: none">
            <td>
                <asp:Label runat="server" ID="lblMenuID" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</div>
