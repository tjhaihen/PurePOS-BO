Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class RecordProperties
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _UserInsert, _UserUpdate As String
        Private _UserInsertName, _UserUpdateName As String
        Private _InsertDate, _UpdateDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Function Global "
        Public Function GetRecordProperties(ByVal FieldIDName As String, ByVal IDNo As String, ByVal TableName As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = _
            "SELECT TOP 1 n.UserInsert, (SELECT UserName FROM [User] WHERE UserID = n.UserInsert) AS UserInsertName, " & _
            "n.UserUpdate, (SELECT UserName FROM [User] WHERE UserID = n.UserUpdate) AS UserUpdateName, " & _
            "n.InsertDate, n.UpdateDate " & _
            "FROM " + TableName.Trim + " n " & _
            "WHERE n." + FieldIDName.Trim + " = '" + IDNo.Trim + "'"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("GetRecordProperties")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _UserInsert = CType(ProcessNull.GetString(toReturn.Rows(0)("UserInsert")), String)
                    _UserInsertName = CType(ProcessNull.GetString(toReturn.Rows(0)("UserInsertName")), String)
                    _UserUpdate = CType(ProcessNull.GetString(toReturn.Rows(0)("UserUpdate")), String)
                    _UserUpdateName = CType(ProcessNull.GetString(toReturn.Rows(0)("UserUpdateName")), String)
                    _InsertDate = CType(ProcessNull.GetDateTime2(toReturn.Rows(0)("InsertDate")), DateTime)
                    _UpdateDate = CType(ProcessNull.GetDateTime2(toReturn.Rows(0)("UpdateDate")), DateTime)
                End If

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
        Public Property [UserInsert]() As String
            Get
                Return _UserInsert
            End Get
            Set(ByVal Value As String)
                _UserInsert = Value
            End Set
        End Property

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
            End Set
        End Property

        Public Property [UserInsertName]() As String
            Get
                Return _UserInsertName
            End Get
            Set(ByVal Value As String)
                _UserInsertName = Value
            End Set
        End Property

        Public Property [UserUpdateName]() As String
            Get
                Return _UserUpdateName
            End Get
            Set(ByVal Value As String)
                _UserUpdateName = Value
            End Set
        End Property

        Public Property [InsertDate]() As DateTime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As DateTime)
                _InsertDate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
