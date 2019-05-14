Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class UserGroupMenu
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _usergroupID, _menuID As String
        Private _isAllowRead, _isAllowEdit, _isAllowAdd, _isAllowDelete, _isAllowApprove, _isAllowVoid, _isAllowPrint As Boolean

#End Region

        Private Sub init()
            'add more initiation here if any
        End Sub

        Public Sub New()
            ' // Nothing for now.
            init()
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
            init()
        End Sub

#Region "Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO UserGroupMenu (UserGroupID, MenuID, isAllowRead, isAllowAdd, isAllowEdit, isAllowDelete, isAllowApprove, isAllowVoid, isAllowPrint) " & _
                                        "VALUES (@UserGroupID, @MenuID, @isAllowRead, @isAllowAdd, @isAllowEdit, @isAllowDelete, @isAllowApprove, @isAllowVoid, @isAllowPrint)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _menuID)
                cmdToExecute.Parameters.AddWithValue("@isAllowRead", _isAllowRead)
                cmdToExecute.Parameters.AddWithValue("@isAllowAdd", _isAllowAdd)
                cmdToExecute.Parameters.AddWithValue("@isAllowEdit", _isAllowEdit)
                cmdToExecute.Parameters.AddWithValue("@isAllowDelete", _isAllowDelete)
                cmdToExecute.Parameters.AddWithValue("@isAllowApprove", _isAllowApprove)
                cmdToExecute.Parameters.AddWithValue("@isAllowVoid", _isAllowVoid)
                cmdToExecute.Parameters.AddWithValue("@isAllowPrint", _isAllowPrint)
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region "Delete"
        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM UserGroupMenu WHERE UserGroupID = @UserGroupID AND MenuID = @MenuID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _menuID)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

#End Region

#Region "Select All"

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM UserGroupMenu"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

#End Region

#Region " Otorisasi Menu "
        Public Function SelectOtorisasiMenuByUserGroupIDMenuID() As DataTable
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM UserGroupMenu WHERE UserGroupID=@UserGroupID AND MenuID=@MenuID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("UserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)
                cmdToExecute.Parameters.AddWithValue("@MenuID", _menuID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectMenuExOtorisasiMenu(ByVal AppID As String) As DataTable
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "[dbo].[spSelectMenuExUserGroupMenu]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("MenuExUserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)
                cmdToExecute.Parameters.AddWithValue("@AppID", AppID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectMenuInOtorisasiMenu(ByVal AppID As String) As DataTable
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "[dbo].[spSelectMenuInUserGroupMenu]"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("MenuInUserGroupMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)
                cmdToExecute.Parameters.AddWithValue("@AppID", AppID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                Return toReturn
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function ImportTemplateUserGroupMenu(ByVal TemplateUserGroupID As String) As Boolean
            Dim cn As New SqlConnection(HisConfiguration.ConfigurationConnectionString)
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "dbo.[spImportUserGroupMenu]"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = cn

            Try
                cmdToExecute.Parameters.AddWithValue("@TemplateUserGroupID", TemplateUserGroupID)
                cmdToExecute.Parameters.AddWithValue("@UserGroupID", _usergroupID)

                ' // Open connection.
                cn.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                cn.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Custom Functions "
        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("UserGroupMenu")
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

        Public Function DeleteByUserGroupID() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM UserGroupMenu " & _
                                        "WHERE UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [UserGroupID]() As String
            Get
                Return _usergroupID
            End Get
            Set(ByVal Value As String)
                _usergroupID = Value
            End Set
        End Property

        Public Property [MenuID]() As String
            Get
                Return _menuID
            End Get
            Set(ByVal Value As String)
                _menuID = Value
            End Set
        End Property

        Public Property [isAllowRead]() As Boolean
            Get
                Return _isAllowRead
            End Get
            Set(ByVal Value As Boolean)
                _isAllowRead = Value
            End Set
        End Property

        Public Property [isAllowAdd]() As Boolean
            Get
                Return _isAllowAdd
            End Get
            Set(ByVal Value As Boolean)
                _isAllowAdd = Value
            End Set
        End Property

        Public Property [isAllowEdit]() As Boolean
            Get
                Return _isAllowEdit
            End Get
            Set(ByVal Value As Boolean)
                _isAllowEdit = Value
            End Set
        End Property

        Public Property [isAllowDelete]() As Boolean
            Get
                Return _isAllowDelete
            End Get
            Set(ByVal Value As Boolean)
                _isAllowDelete = Value
            End Set
        End Property

        Public Property [isAllowApprove]() As Boolean
            Get
                Return _isAllowApprove
            End Get
            Set(ByVal Value As Boolean)
                _isAllowApprove = Value
            End Set
        End Property

        Public Property [isAllowVoid]() As Boolean
            Get
                Return _isAllowVoid
            End Get
            Set(ByVal Value As Boolean)
                _isAllowVoid = Value
            End Set
        End Property

        Public Property [isAllowPrint]() As Boolean
            Get
                Return _isAllowPrint
            End Get
            Set(ByVal Value As Boolean)
                _isAllowPrint = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
