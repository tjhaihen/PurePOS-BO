Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Menu
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _MenuID, _ParentMenuID As String
        Private _Caption, _Url, _ImageUrl, _Description, _UserGroupID As String
        Private _IsActive As Boolean

#End Region

        Public Sub New()
            ConnectionString = HisConfiguration.ConnectionString
        End Sub

#Region " Custom Functions "
        Public Function SelectMenuAuthorizationByUserGroupID(ByVal UserGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ISNULL(ugm.UserGroupID,'') AS UserGroupID, " & _
                                        "ISNULL(ugm.IsAllowRead,0) AS IsAllowRead, ISNULL(ugm.IsAllowAdd,0) AS IsAllowAdd, ISNULL(ugm.IsAllowEdit,0) AS IsAllowEdit, " & _
                                        "ISNULL(ugm.IsAllowDelete,0) AS IsAllowDelete, ISNULL(ugm.isAllowApprove,0) AS isAllowApprove, ISNULL(ugm.isAllowVoid,0) AS isAllowVoid, " & _
                                        "ISNULL(ugm.isAllowPrint,0) AS isAllowPrint, m.*, " & _
                                        "CASE WHEN (SELECT TOP 1 MenuID FROM Menu WHERE ParentMenuID = m.MenuID) IS NOT NULL " & _
                                        "THEN 'H' Else 'D' END AS HeaderDetail " & _
                                        "FROM Menu m " & _
                                        "LEFT JOIN UserGroupMenu ugm ON m.MenuID = ugm.MenuID AND ugm.UserGroupID = @UserGroupID " & _
                                        "WHERE m.isActive = 1 "
            '"AND m.AppID LIKE @AppID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MenuAuthorizationByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", UserGroupID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                Throw New Exception(ex.Message)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ugm.UserGroupID, " & _
                                        "ugm.IsAllowRead, ugm.IsAllowEdit, " & _
                                        "ugm.IsAllowDelete, m.* " & _
                                        "FROM UserGroupMenu ugm " & _
                                        "INNER JOIN Menu m on m.MenuID = ugm.MenuID " & _
                                        "WHERE ugm.UserGroupID = @UserGroupID AND m.isActive = 1"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MenuByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                Return toReturn
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
#End Region

#Region " Class Property Declarations "
        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property

        Public Property [MenuID]() As String
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As String)
                _MenuID = Value
            End Set
        End Property

        Public Property [ParentMenuID]() As String
            Get
                Return _ParentMenuID
            End Get
            Set(ByVal Value As String)
                _ParentMenuID = Value
            End Set
        End Property

        Public Property [Caption]() As String
            Get
                Return _Caption
            End Get
            Set(ByVal Value As String)
                _Caption = Value
            End Set
        End Property

        Public Property [Url]() As String
            Get
                Return _Url
            End Get
            Set(ByVal Value As String)
                _Url = Value
            End Set
        End Property

        Public Property [ImgUrl]() As String
            Get
                Return _ImageUrl
            End Get
            Set(ByVal Value As String)
                _ImageUrl = Value
            End Set
        End Property

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
