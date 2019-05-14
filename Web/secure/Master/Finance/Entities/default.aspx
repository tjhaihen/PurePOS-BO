<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="Raven.Web.Secure.Master.Finance.Entities"
    EnableSessionState="true" EnableViewState="true" %>

<%@ Register TagPrefix="Module" TagName="Copyright" Src="../../../../incl/copyRightModule.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../../../../incl/RadMenu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Toolbar" Src="../../../../incl/CSSToolbar.ascx" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Entities</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="Stylesheet" type="text/css" href="/pureravenslib/css/styles_blue.css">

    <script language="javascript" src="/pureravenslib/scripts/common/util.js"></script>

    <script language="javascript" src='<%= UrlBase + "/JSDLGGlobalVar.aspx" %>'></script>

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
                                        <%--<telerik:radajaxmanager id="RadAjaxManager1" runat="server" EnableOutsideScripts="True" >
													<AjaxSettings>
														<telerik:AjaxSetting AjaxControlID="RadToolbar">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlEntitiesTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtTIN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtFaxNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWebsite"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtZipCode"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCityID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCountryID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlDeliveryZoneID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxParentEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtParentEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlRelationshipID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBank"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAccountNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankBranch"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxPOrdAmount"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMemberNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadMemberSinceDate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lbtnNewDetail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lbtnSaveDetail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntities" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxEntitiesSeqNo">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlEntitiesTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtTIN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtFaxNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWebsite"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtZipCode"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCityID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCountryID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlDeliveryZoneID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxParentEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtParentEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlRelationshipID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBank"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAccountNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankBranch"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxPOrdAmount"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMemberNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadMemberSinceDate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lbtnNewDetail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="lbtnSaveDetail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntities" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxParentEntitiesSeqNo">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtParentEntitiesName"></telerik:AjaxUpdatedControl>																
																<telerik:AjaxUpdatedControl ControlID="ddlRelationshipID"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadComboBoxCPContactSeqNo">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>																
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridEntitiesContact">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="RadGridEntities">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlEntitiesTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtTIN"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtFaxNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtWebsite"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtPrimaryAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtSecondaryAddress2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtZipCode"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCityID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCountryID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlDeliveryZoneID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxParentEntitiesSeqNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtParentEntitiesName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlRelationshipID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBank"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAccountNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankBranch"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtBankAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMaxPOrdAmount"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberTypeID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtMemberNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadMemberSinceDate"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtDescription"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>																
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntities" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="lbtnNewDetail">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="lbtnSaveDetail">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="RadComboBoxCPContactSeqNo"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="txtCPFullName"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="ddlCPJobTitleID"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPAddress"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPPrimaryPhoneNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo1"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPSecondaryPhoneNo2"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="txtCPEmail"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="chkCPIsActive"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadGridEntitiesContact" LoadingPanelID="AjaxLoadingPanel1"></telerik:AjaxUpdatedControl>								
															</UpdatedControls>
														</telerik:AjaxSetting>
														<telerik:AjaxSetting AjaxControlID="ddlEntitiesTypeID">
															<UpdatedControls>
																<telerik:AjaxUpdatedControl ControlID="ddlMemberTypeID"></telerik:AjaxUpdatedControl>								
																<telerik:AjaxUpdatedControl ControlID="txtMemberNo"></telerik:AjaxUpdatedControl>
																<telerik:AjaxUpdatedControl ControlID="RadMemberSinceDate"></telerik:AjaxUpdatedControl>																
															</UpdatedControls>
														</telerik:AjaxSetting>																												
													</AjaxSettings>
												</telerik:radajaxmanager>--%>
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
                            Master
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Finance
                            <img src="/pureravenslib/images/rightarrow.png" border="0" align="absMiddle">
                            Entities
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" width="100%" colspan="2" align="left">
                            <Module:Toolbar ID="Toolbar" runat="server"></Module:Toolbar>
                        </td>
                    </tr>
                    <tr>
                        <td  height="100%" valign="top" width="100%" colspan="2" align="left">
                            <div style="width: 100%; height: 100%; overflow: auto">
                                <table width="100%" cellspacing="1">
                                    <!-- BEGIN FORM SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (REDiv.style.display == '') {REDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {REDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordEntryCaption" runat="server" Text="Record Entry"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="REDiv">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblEntitiesSeqNoCaption" runat="server" Text="Entities Seq. No."></asp:Label>
                                                                    </td>
                                                                    <td width="30%">
                                                                        <telerik:RadComboBox ID="RadComboBoxEntitiesSeqNo" runat="server" AutoPostBack="true"
                                                                            Skin="WebBlue" ShowMoreResultBox="false" AllowCustomText="True" EntitiesRequestTimeout="200"
                                                                            DropDownWidth="423px" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                            MarkFirstMatch="true" Width="90%" Height="190px" DataTextField="EntitiesID" DataValueField="EntitiesSeqNo"
                                                                            ShowDropDownOnTextboxClick="False" MaxLength="15">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>
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
                                                                                            <b>Entities Seq No</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Entities ID</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Entities Name</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblEntitiesIDCaption" runat="server" Text="Entities ID"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEntitiesID" runat="server" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblEntitiesNameCaption" runat="server" Text="Entities Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEntitiesName" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblEntitiesTypeCaption" runat="server" Text="Entities Type"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlEntitiesTypeID" runat="server" Width="90%" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTINCaption" runat="server" Text="Taxpayer Identification No."></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtTIN" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip2" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage2">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Entity Contact Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage2" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview2" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblPrimaryPhoneNoCaption" runat="server" Text="Primary Phone No."></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox ID="txtPrimaryPhoneNo" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSecondaryPhoneNo1Caption" runat="server" Text="Secondary Phone No. 1"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSecondaryPhoneNo1" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSecondaryPhoneNo2Caption" runat="server" Text="Secondary Phone No. 2"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSecondaryPhoneNo2" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblFaxNoCaption" runat="server" Text="Fax No."></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblEmailCaption" runat="server" Text="Email Address"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblWebsiteCaption" runat="server" Text="Website"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtWebsite" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip1" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage2">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Entity Address Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage1" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview1" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblPrimaryAddressCaption" runat="server" Text="Primary Address"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox ID="txtPrimaryAddress" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSecondaryAddress1Caption" runat="server" Text="Secondary Address 1"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSecondaryAddress1" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblSecondaryAddress2Caption" runat="server" Text="Secondary Address 2"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtSecondaryAddress2" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblZipCodeCaption" runat="server" Text="Zip Code"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtZipCode" runat="server" MaxLength="15" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblCityCaption" runat="server" Text="City"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlCityID" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblCountryCaption" runat="server" Text="Country"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlCountryID" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblDeliveryZoneCaption" runat="server" Text="Delivery Zone"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlDeliveryZoneID" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip4" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage4">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Relationship Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage4" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview4" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblParentEntitiesSeqNoCaption" runat="server" Text="Parent Entities Seq. No."></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <telerik:RadComboBox ID="RadComboBoxParentEntitiesSeqNo" runat="server" AutoPostBack="true"
                                                                                                Skin="WebBlue" ShowMoreResultBox="false" AllowCustomText="True" EntitiesRequestTimeout="200"
                                                                                                DropDownWidth="423px" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                                                MarkFirstMatch="true" Width="90%" Height="190px" DataTextField="EntitiesID" DataValueField="EntitiesSeqNo"
                                                                                                ShowDropDownOnTextboxClick="False" MaxLength="15">
                                                                                                <ItemTemplate>
                                                                                                    <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                                        <tr>
                                                                                                            <td style="width: 125px;">
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>
                                                                                                            </td>
                                                                                                            <td style="width: 125px;">
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>
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
                                                                                                                <b>Entities Seq No</b>
                                                                                                            </td>
                                                                                                            <td style="width: 125px;">
                                                                                                                <b>Entities ID</b>
                                                                                                            </td>
                                                                                                            <td style="width: 125px;">
                                                                                                                <b>Entities Name</b>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </HeaderTemplate>
                                                                                            </telerik:RadComboBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblParentEntitiesNameCaption" runat="server" Text="Parent Entities Name"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtParentEntitiesName" runat="server" MaxLength="500" Width="90%"
                                                                                                Enabled="False"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblRelationshipCaption" runat="server" Text="Relationship"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlRelationshipID" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip3" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage3">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Entity Bank Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="RadMultiPage3" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview3" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblBankCaption" runat="server" Text="Bank"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox ID="txtBank" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBankAccountNoCaption" runat="server" Text="Account No."></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtBankAccountNo" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBankBranchCaption" runat="server" Text="Branch"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtBankBranch" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblBankAddressCaption" runat="server" Text="Bank Address"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtBankAddress" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip6" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage6">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Purchase Order Validation">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage6" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview6" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblMaxPOrdAmountCaption" runat="server" Text="Max. P.O. Amount"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox ID="txtMaxPOrdAmount" runat="server" Width="90%" Style="text-align: right"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip5" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage5">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Entity Membership Information">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage5" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview5" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblMemberTypeCaption" runat="server" Text="Member Benefit"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:DropDownList ID="ddlMemberTypeID" runat="server" Width="90%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblMemberNoCaption" runat="server" Text="Member No."></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox ID="txtMemberNo" runat="server" Width="90%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblMemberSinceCaption" runat="server" Text="Member Since"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <telerik:RadDatePicker ID="RadMemberSinceDate" runat="server" MinDate="2006-01-01"
                                                                                                SharedCalendarID="sharedCalendar" Culture="Marathi (India)">
                                                                                                <DateInput Width="30%" Font-Size="XSmall">
                                                                                                </DateInput>
                                                                                                <DatePopupButton HoverImageUrl="/pureravenslib/images/datepicker_popuphover.gif"
                                                                                                    ImageUrl="/pureravenslib/images/datepicker_popup.gif"></DatePopupButton>
                                                                                            </telerik:RadDatePicker>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="100%">
                                                                        <telerik:RadTabStrip ID="Radtabstrip7" runat="server" Skin="Windows7" SelectedIndex="0"
                                                                            MultiPageID="RadMultiPage5">
                                                                            <Tabs>
                                                                                <telerik:RadTab Text="Entity Description">
                                                                                </telerik:RadTab>
                                                                            </Tabs>
                                                                        </telerik:RadTabStrip>
                                                                        <telerik:RadMultiPage ID="Radmultipage7" runat="server" SelectedIndex="0">
                                                                            <telerik:RadPageView ID="Pageview7" runat="server">
                                                                                <table cellspacing="1" cellpadding="2" width="100%" >
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            <asp:Label ID="lblDescriptionCaption" runat="server" maxlength="500" Text="Description"></asp:Label>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                            <asp:TextBox Style="font-family: Tahoma; font-size: 9pt" ID="txtDescription" runat="server"
                                                                                                Width="90%" Height="40px" TextMode="MultiLine"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </telerik:RadPageView>
                                                                        </telerik:RadMultiPage>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (CPDiv.style.display == '') {CPDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {CPDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="AbsMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblContactPersonCaption" runat="server" Text="Contact Persons"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="CPDiv">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="my_toolbarbutton_horizontal">
                                                                <tr>
                                                                    <td width="1" class="my_toolbarbutton_left">
                                                                    </td>
                                                                    <td valign="middle">
                                                                        <asp:LinkButton runat="server" class="my_toolbarbutton" Text=".::" CausesValidation="false"
                                                                            Enabled="False" Style="color: black; text-decoration: none; font-weight: bold"></asp:LinkButton>
                                                                        <asp:LinkButton runat="server" ID="lbtnNewDetail" class="my_toolbarbutton" Text="New Contact"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle"
                                                                            height="20" />
                                                                        <asp:LinkButton runat="server" ID="lbtnSaveDetail" class="my_toolbarbutton" Text="Save Contact"
                                                                            CausesValidation="false" Style="color: black; text-decoration: none;"></asp:LinkButton>
                                                                        <img src="/pureravenslib/images/separator_h.gif" border="0" align="absmiddle"
                                                                            height="20" />
                                                                    </td>
                                                                    <td width="1" class="my_toolbarbutton_right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblCPContactSeqNoCaption" runat="server" Text="Contact Person Seq. No."></asp:Label>
                                                                    </td>
                                                                    <td width="30%">
                                                                        <telerik:RadComboBox ID="RadComboBoxCPContactSeqNo" runat="server" AutoPostBack="true"
                                                                            Skin="WebBlue" ShowMoreResultBox="false" AllowCustomText="True" EntitiesRequestTimeout="200"
                                                                            DropDownWidth="423px" HighlightTemplatedItems="true" EnableLoadOnDemand="true"
                                                                            MarkFirstMatch="true" Width="90%" Height="190px" ShowDropDownOnTextboxClick="False"
                                                                            MaxLength="15">
                                                                            <ItemTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "ContactSeqNo") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "FullName") %>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <%# DataBinder.Eval(Container.DataItem, "JobTitleName") %>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                            <HeaderTemplate>
                                                                                <table style="width: 415px; text-align: left; font-family: tahoma,arial;">
                                                                                    <tr>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Contact Seq No</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Full Name</b>
                                                                                        </td>
                                                                                        <td style="width: 125px;">
                                                                                            <b>Job Title</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </HeaderTemplate>
                                                                        </telerik:RadComboBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPFullNameCaption" runat="server" Text="Full Name"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCPFullName" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPJobTitleCaption" runat="server" Text="Job Title"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlCPJobTitleID" runat="server" Width="90%">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPAddressCaption" runat="server" Text="Address"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCPAddress" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblCPPrimaryPhoneNoCaption" runat="server" Text="Primary Phone No."></asp:Label>
                                                                    </td>
                                                                    <td width="30%">
                                                                        <asp:TextBox ID="txtCPPrimaryPhoneNo" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPSecondaryPhoneNo1Caption" runat="server" Text="Secondary Phone No. 1"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCPSecondaryPhoneNo1" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPSecondaryPhoneNo2Caption" runat="server" Text="Secondary Phone No. 2"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCPSecondaryPhoneNo2" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblCPEmailCaption" runat="server" Text="Email Address"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCPEmail" runat="server" MaxLength="500" Width="90%"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkCPIsActive" runat="server" Text="Active"></asp:CheckBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left" colspan="2" width="100%">
                                                            <asp:DataGrid ID="RadGridEntitiesContact" runat="server" Style="width: 100%" CellPadding="0"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="0" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle Font-Bold="True" CssClass="rheadercol" BackColor="#DEE3E7" Height="20" />
                                                                <HeaderStyle Font-Bold="false" BackColor="#DEE3E7" Height="20" />
                                                                <AlternatingItemStyle BackColor="#E3F3F9" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Contact Person Seq No">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblContactSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "ContactSeqNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Full Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblFullName" Text='<%# DataBinder.Eval(Container.DataItem, "FullName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Job Title Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblJobTitleName" Text='<%# DataBinder.Eval(Container.DataItem, "JobTitleName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Primary Phone No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblPrimaryPhoneNo" Text='<%# DataBinder.Eval(Container.DataItem, "PrimaryPhoneNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Email Address">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEmail" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" width="100%" height="25">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END FORM SECTION -->
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
                                                <table cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td valign="center" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="10%" valign="center">
                                                                        <asp:Label ID="lblSearchEntitiesName" runat="server" Text="Search Entities Name"></asp:Label>
                                                                        <td width="30%" valign="center">
                                                                            <asp:TextBox ID="txtSearchEntitiesName" runat="server" Width="80%" Text="*"></asp:TextBox>
                                                                            <asp:LinkButton CssClass="MyButton" ID="lbtnApplyFilter" runat="server" Text="Apply"
                                                                                Width="50"></asp:LinkButton>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:Label Style="color: gray; font-size: 8pt;" ID="lblSearchEntitiesNameNotes" runat="server"
                                                                            Text="(e.g.: [Search Text]*; *[Search Text]; *[Search Text]*. Notes: Showing all entities (*) will take longer time to get the data.)"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="center" width="50%">
                                                            <table cellspacing="1" cellpadding="2" width="100%">
                                                                <tr>
                                                                    <td width="100%" align="left" valign="center">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" width="100%" colspan="2">
                                                            <asp:DataGrid ID="RadGridEntities" runat="server" Style="width: 100%" CellPadding="0"
                                                                ShowFooter="False" PageSize="20" AllowPaging="false" GridLines="None" BorderWidth="1"
                                                                BorderColor="Gainsboro" CellSpacing="0" AutoGenerateColumns="False" AllowSorting="True">
                                                                <HeaderStyle Font-Bold="True" CssClass="rheadercol" BackColor="#DEE3E7" Height="20" />
                                                                <HeaderStyle Font-Bold="false" BackColor="#DEE3E7" Height="20" />
                                                                <AlternatingItemStyle BackColor="#E3F3F9" />
                                                                <EditItemStyle Font-Bold="false" />
                                                                <PagerStyle Mode="NumericPages" HorizontalAlign="right" />
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderStyle-Width="50" ItemStyle-Width="50">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="_lbtnSelect" runat="server" CommandName="Select" Text="<img src='/pureravenslib/images/edit.png' border='0' align='absmiddle'/>"
                                                                                ToolTip="Edit record" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Entities Seq No">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEntitiesSeqNo" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesSeqNo") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Entities ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEntitiesID" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Entities Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEntitiesName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Entities Type Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label runat="server" ID="_lblEntitiesTypeName" Text='<%# DataBinder.Eval(Container.DataItem, "EntitiesTypeName") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn runat="server" HeaderText="Active">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox runat="server" ID="_chkIsActive" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                            </asp:DataGrid>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" width="100%" height="25">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD LIST SECTION -->
                                    <!-- BEGIN RECORD PROPERTIES SECTION -->
                                    <tr>
                                        <td class="rheader" height="25" valign="middle" width="2%" align="center">
                                            <img style="cursor: hand" onclick="javascript:if (RCDiv.style.display == '') {RCDiv.style.display = 'none'; this.src='/pureravenslib/images/expand_arrow.png'; } else {RCDiv.style.display = ''; this.src='/pureravenslib/images/collapse_arrow.png';}"
                                                alt="Expand/Collapse" src="/pureravenslib/images/collapse_arrow.png" align="absMiddle">
                                        </td>
                                        <td class="rheader" height="25" valign="middle" width="98%" align="left">
                                            &nbsp;
                                            <asp:Label ID="lblRecordPropertiesCaption" runat="server" Text="Record Properties"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="100%" colspan="2">
                                            <div id="RCDiv">
                                                <table cellpadding="2" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="10%">
                                                            <asp:Label ID="lblUserInsertCaption" runat="server" Text="Created by"></asp:Label>
                                                        </td>
                                                        <td width="2%">
                                                            :
                                                        </td>
                                                        <td width="68%">
                                                            <asp:Label ID="lblUserInsert" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblInsertDateCaption" runat="server" Text="Insert date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInsertDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdateCaption" runat="server" Text="Last update by"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUserUpdate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDateCaption" runat="server" Text="Update date"></asp:Label>
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUpdateDate" runat="server" Width="70%"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- END RECORD PROPERTIES SECTION -->
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <Module:Copyright ID="mdlCopyRight" runat="server"></Module:Copyright>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <telerik:RadCalendar ID="sharedCalendar" runat="server" EnableMultiSelect="false"
        RangeMinDate="2006/01/01">
    </telerik:RadCalendar>
    <asp:PlaceHolder ID="sharedCalendarPlaceHolder" runat="server"></asp:PlaceHolder>
    </form>

    <script language="vbscript" src="/pureravenslib/scripts/common/common.vbs"></script>

    <script language="javascript" src="/pureravenslib/scripts/common/common.js"></script>

</body>
</html>
