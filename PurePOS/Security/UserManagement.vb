'-----------------------------------------------------------
' FileName: UserManagement.vb
' Implementation file for user management
'
' Namespace:    Raven.Security
' Class:        UserModule
'               UserData
'
' Author:       AnthonieCh@Hotmail.com
'-----------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Xml
Imports System.Data
Imports System.Security
Imports System.Data.SqlClient
Imports System.Security.Permissions

Imports Raven
Imports Raven.Common
Imports Raven.SystemFramework

Namespace Raven.Security

    <StrongNameIdentityPermissionAttribute(SecurityAction.LinkDemand, PublicKey:="0024000004800000940000000602000000240000525341310004000001000100B5C8DAC10359BBDC968B03CC7972D770032BFCCDCE4324E01E728E0C982320E3B723CDC1C6CE9D02288D5D9225590FAD94A05E7F650281A614ED2D53FB37AFB84AFEF5D0491CF4C6B464D68565FF6CFAE3F7FB13FACD533C26D67AFC21EC7ECE6AAC5127A4043EA23D0889CF93ABD21F73B897BE75679AE6F0423EF436FC1FEB")> _
    Public Class UserManagement
        Inherits MarshalByRefObject

        Public Sub New()
        End Sub

#Region "Methods - return dataset"
        Public Overloads Function GetUserDataSetByUserGroup(ByVal UserGroupID As String, ByVal UserID As String, ByVal Password As String) As DataSet
            '
            '   validate User Name and Password
            '
            ApplicationAssert.CheckCondition(Len(UserID) > 0, "User Name is required", ApplicationAssert.LineNumber)
            ApplicationAssert.CheckCondition(Len(Password) > 0, "Password is required", ApplicationAssert.LineNumber)

            Const PRM_UGID As String = "@UserGroupID"
            Const PRM_UID As String = "@UserID"

            Dim strSQL_Menu, strSQL_User As String
            Dim cnn As SqlConnection = New SqlConnection(HisConfiguration.ConfigurationConnectionString)

            ' // Create new Dataset
            Dim ds As New DataSet
            ds.Tables.Add(New DataTable("User"))
            ds.Tables.Add(New DataTable("UserGroupMenu"))

            strSQL_Menu = _
            "select um.UserGroupID, um.MenuID, um.isAllowRead, um.isAllowAdd, um.isAllowEdit, " & _
            "um.isAllowDelete, um.isAllowApprove, um.isAllowVoid, um.isAllowPrint, " & _
            "m.Description, m.URL, m.Caption, m.[Counter], m.Line, m.ImageUrl, m.MenuType " & _
            "from UserGroupMenu um inner join Menu m on um.MenuID = m.MenuID " & _
            "where um.UserGroupID = @UserGroupID and m.appID = 'RS_' and m.IsActive = 1 "

            strSQL_User = _
            "SELECT * FROM [User] " & _
            "WHERE (IsActive=1) AND (UserID=@UserID)"

            Try
                cnn.Open()

                '// Get User data
                Dim cmdUser As New SqlCommand

                cmdUser.CommandType = CommandType.Text
                cmdUser.CommandText = strSQL_User
                cmdUser.Connection = cnn

                cmdUser.Parameters.Add(New SqlParameter(PRM_UID, SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserID))

                Dim adapterUser As SqlDataAdapter = New SqlDataAdapter(cmdUser)
                adapterUser.Fill(ds.Tables("User"))

                cmdUser.Dispose()
                cmdUser = Nothing
                adapterUser.Dispose()
                adapterUser = Nothing

                '//   verify the user's password
                With ds.Tables("User")
                    If (.Rows.Count = 1) Then
                        If CType(.Rows(0)("Password"), String).Equals(Password) Then

                            ApplicationAssert.CheckCondition(Common.ProcessNull.GetBoolean(.Rows(0)("isActive")) = True, "Your account is disabled. Please contact your System Administrator.", ApplicationAssert.LineNumber)
                            '
                            ' //  Get user's Menu
                            '
                            Dim cmdMenu As New SqlCommand

                            cmdMenu.CommandType = CommandType.Text
                            cmdMenu.CommandText = strSQL_Menu
                            cmdMenu.Connection = cnn

                            Dim adapterMenu As SqlDataAdapter = New SqlDataAdapter(cmdMenu)

                            cmdMenu.Parameters.Add(New SqlParameter(PRM_UGID, SqlDbType.VarChar, 15, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, UserGroupID))
                            adapterMenu.Fill(ds.Tables("UserGroupMenu"))

                            cmdMenu.Dispose()
                            cmdMenu = Nothing
                            adapterMenu.Dispose()
                            adapterMenu = Nothing
                        Else
                            ds = Nothing
                        End If
                    Else
                        ds = Nothing
                    End If
                End With

                cnn.Close()

            Catch e As Exception
                ExceptionManager.Publish(e)
            End Try

            Return ds

        End Function
#End Region

        Public Function GetHashString(ByVal strPassword As String, Optional ByVal HashType As String = "SHA1") As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sp_GetHashStringSQL"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("sp_GetHashStringSQL")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@TypeHashString", HashType.Trim)
                cmdToExecute.Parameters.AddWithValue("@Password", strPassword)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return CType(Common.ProcessNull.GetString(toReturn.Rows(0)("EncriptionPassword")), String)
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

    End Class

End Namespace