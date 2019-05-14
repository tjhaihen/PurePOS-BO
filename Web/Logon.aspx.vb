Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Common

Imports Raven.SystemFramework

Namespace Raven.Web

    Public Class Logon
        Inherits PageBase

        Protected WithEvents pnlLogin As Panel
        Protected WithEvents txtUserName As TextBox
        Protected WithEvents rfvUsername As RequiredFieldValidator
        Protected WithEvents txtPassword As TextBox
        Protected WithEvents rfvPassword As RequiredFieldValidator
        Protected WithEvents btnLogin As Button
        Protected WithEvents lblErrLogin As Label

        Private logonUserData As DataSet

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            logonUserData = PB_CacheLoggedOnUser

            If Me.IsPostBack Then
            Else
                'ShowPanel(pnlLogin, True)
                'lblErrLogin.Visible = False

                'ShowPanel(LoggedOnPanel, False)
                If logonUserData Is Nothing Then
                    ShowPanel(pnlLogin, True)
                Else
                    FormsAuthentication.RedirectFromLoginPage("*", False)
                End If
            End If
        End Sub

        Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
            If Not Page.IsValid Then
                Return
            End If

            If Not MyBase.PB_CacheLoggedOnUser Is Nothing Then
                commonFunction.ShowPanel(pnlLogin, False)
                Me.ViewState("target") = "logon"
                Exit Sub
            End If

            commonFunction.ShowPanel(pnlLogin, True)

            Dim dtUser As New DataTable
            dtUser = commonFunction.TableUserLogin(txtUserName.Text.Trim)
            With dtUser
                If .Rows.Count = 1 Then
                    If CType(.Rows(0)("Password"), String).Trim = commonFunction.GetHashString(txtPassword.Text.Trim) Then 'FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.Trim, "sha1") Then
                        Dim ds As New DataSet
                        Dim dtUserGroupMenu As New DataTable
                        dtUserGroupMenu = commonFunction.TableMenuAuthorization(CType(.Rows(0)("UserGroupID"), String).Trim)
                        dtUser.TableName = "User"
                        dtUserGroupMenu.TableName = "UserGroupMenu"
                        ds.Tables.Add(dtUser)
                        ds.Tables.Add(dtUserGroupMenu)
                        MyBase.PB_CacheLoggedOnUser = ds
                        dtUserGroupMenu = Nothing
                        ds = Nothing
                        ShowPanel(pnlLogin, False)
                        FormsAuthentication.RedirectFromLoginPage("*", False)
                    Else
                        lblErrLogin.Visible = True
                    End If
                Else
                    lblErrLogin.Visible = True
                End If
            End With
            dtUser = Nothing
        End Sub

        Private Sub ShowPanel(ByRef panel As Panel, ByVal visible As Boolean)
            Dim validator As IValidator
            Dim ctrl As Control

            For Each ctrl In panel.Controls
                If TypeOf ctrl Is IValidator Then
                    validator = CType(ctrl, IValidator)
                    ctrl.Visible = visible
                    If Not visible Then
                        validator.Validate()
                    End If
                End If
            Next
            panel.Visible = visible
        End Sub

    End Class

End Namespace