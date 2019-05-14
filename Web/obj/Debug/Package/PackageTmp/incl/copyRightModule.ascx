<%@ OutputCache Duration="3600" VaryByParam="none" VaryByControl="BannerModule.PathPrefix" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="copyRightModule.ascx.vb" Inherits="Raven.Web.copyRightModule" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="Raven.Web"%>
<table class="txtcopyright" width="100%">
    <tr>
        <td width="50%">
            <asp:Label ID="lblYear" runat="server"></asp:Label>&nbsp;© Pureravens Indonesia. All rights reserved.
        </td>
        <td width="50%" align="right">
            Terms and Condition&nbsp;&nbsp;|&nbsp;&nbsp;Privacy Policy
        </td>
    </tr>
</table>