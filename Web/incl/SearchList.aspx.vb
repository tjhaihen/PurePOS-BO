Option Strict On
Option Explicit On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.DataGridColumn
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.Web.Secure.Incl

    Public Class SearchList
        Inherits PageBase


#Region " Private Variables (web form designer generated code and user code) "

#End Region


#Region " Control Events "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.IsPostBack Then
            Else
                Dim fQueryStringExist As Boolean

                fQueryStringExist = ReadQueryString()

                prepareScreen()

                FillFilterDropDownList()

                'DataBind()
            End If
        End Sub

        Private Sub grdSearchList_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdSearchList.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item
                    On Error Resume Next

                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)

                    If _drv Is Nothing Then Exit Sub

                    Dim s1 As String = CType(_drv.Row.Item(0), String).Trim

                    Dim a As String = "'"

                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='AliceBlue';this.focus;this.style.cursor='hand';")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='white'")
                    'e.Item.Attributes.Add("onclick", "closeWindowWOPostBack('" + s1 + "', '" + Trim(Request.QueryString("txt")) + "')")
                    e.Item.Attributes.Add("onclick", "closeWindow('" + s1 + "', '" + Trim(Request.QueryString("txt")) + "')")

                Case ListItemType.AlternatingItem
                    On Error Resume Next

                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)

                    If _drv Is Nothing Then Exit Sub

                    Dim s1 As String = CType(_drv.Row.Item(0), String).Trim

                    Dim a As String = "'"

                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='AliceBlue';this.focus;this.style.cursor='hand';")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='whiteSmoke'")
                    e.Item.Attributes.Add("onclick", "closeWindowWOPostBack('" + s1 + "', '" + Trim(Request.QueryString("txt")) + "')")
            End Select
        End Sub

        Private Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApplyFilter.Click
            Select Case CType(sender, Button).ID
                Case "btnApplyFilter"
                    UpdateViewGrid(ddlFilterBy.SelectedItem.Text.Trim, txtFilterBy.Text.Trim.Replace("*", "%"))
            End Select
        End Sub
#End Region


#Region " Support functions for navigation bar (Controls) "
#End Region


#Region " Additional: Private Function "
        Private Function ReadQueryString() As Boolean
            Dim b As Boolean = (Len(Trim(Request.QueryString("cd"))) > 0) And (Len(Trim(Request.QueryString("txt"))) > 0)
            Return b
        End Function

        Private Sub prepareScreen()
            txtSearchCode.Text = Trim(Request.QueryString("cd"))
            _OpenSearch()
            UpdateViewGrid(Trim(Request.QueryString("filterfield")), Trim(Request.QueryString("filtervalue")))
        End Sub

        Private Sub UpdateViewGrid(Optional ByVal FieldName As String = Nothing, Optional ByVal FilterValue As String = Nothing)
            Dim dt As DataTable
            Dim br As New BussinessRules.Search

            br.SearchID = CStr(Trim(Request.QueryString("cd")))
            dt = br.SelectSearchList

            '// Filter by... View
            Dim dr As New DataView(dt)
            If (Not FieldName Is Nothing And Not FilterValue Is Nothing) And (Len(FieldName.Trim) > 0 And Len(FilterValue.Trim) > 0) Then
                dr.RowFilter = FieldName + " like '" + FilterValue + "'"
                grdSearchList.DataSource = dr
                grdSearchList.DataBind()
            Else
                grdSearchList.DataSource = dt.DefaultView
                grdSearchList.DataBind()
            End If

            '// display record count
            lblSearchResults.Text = grdSearchList.Items.Count.ToString.Trim

            br.Dispose()
            br = Nothing

            dr.Dispose()
            dr = Nothing
        End Sub

        Private Function FillFilterDropDownList() As Boolean
            Dim tbl As DataTable
            tbl = GetParamList(lblSearchProcedure.Text.Trim)

            If Not ddlFilterBy.Items Is Nothing Then
                ddlFilterBy.Items.Clear()
            End If

            If Not tbl Is Nothing Then
                If tbl.Rows.Count > 0 Then
                    Dim rows() As DataRow = tbl.Select
                    Dim row As DataRow

                    For Each row In rows
                        ddlFilterBy.Items.Add(New ListItem(CType(row("NAME"), String).Replace("@", ""), CType(row("NAME"), String).Replace("@", "")))
                    Next
                End If
            End If

            '// Default Filter By
            commonFunction.SelectListItem(ddlFilterBy, Trim(Request.QueryString("default")))
        End Function

        Private Function GetParamList(ByVal spName As String) As DataTable
            Dim cn As New SqlClient.SqlConnection(Raven.Common.HisConfiguration.ConnectionString)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
            Dim tbl As DataTable = New DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim strSQL As String

            strSQL = "select name, type, length from syscolumns where id = object_id('" + spName + "') and type  = '39'"

            Try
                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = strSQL
                cmd.CommandType = CommandType.Text

                da = New SqlClient.SqlDataAdapter(cmd)
                da.Fill(tbl)

                Return tbl
            Catch ex As Exception
                Raven.Common.ExceptionManager.Publish(ex)
            Finally
                If Not cn Is Nothing Then
                    cn.Dispose()
                    cn = Nothing
                End If
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not da Is Nothing Then
                    da.Dispose()
                    da = Nothing
                End If
            End Try
        End Function
#End Region


#Region " Main Function: Open, Save Delete Data "
        Private Sub _OpenSearch()
            If Len(Trim(Request.QueryString("cd"))) = 0 Then Exit Sub

            Dim br As New BussinessRules.Search

            With br
                .SearchID = CStr(Trim(Request.QueryString("cd")))

                If (.SelectOne.Rows.Count > 0) Then
                    lblSearchList.Text = .SearchCaption.Trim
                    lblSearchProcedure.Text = .SearchProcedure.Trim
                Else
                    lblSearchList.Text = String.Empty
                    lblSearchProcedure.Text = String.Empty
                End If
            End With

            br.Dispose()
            br = Nothing
        End Sub
#End Region

    End Class

End Namespace