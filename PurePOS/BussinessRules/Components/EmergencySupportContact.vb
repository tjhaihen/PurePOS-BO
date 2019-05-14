Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class EmergencySupportContact
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _contactName, _email, _phone, _PIN As String

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub


        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT * FROM EmergencySupportContact"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("EmergencySupportContact")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _contactName = CType(toReturn.Rows(0)("contactName"), String)
                    _email = CType(toReturn.Rows(0)("email"), String)
                    _phone = CType(toReturn.Rows(0)("phone"), String)
                    _PIN = CType(toReturn.Rows(0)("PIN"), String)
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

#Region " Class Property Declarations "

        Public Property [ContactName]() As String
            Get
                Return _contactName
            End Get
            Set(ByVal Value As String)
                _contactName = Value
            End Set
        End Property

        Public Property [email]() As String
            Get
                Return _email
            End Get
            Set(ByVal Value As String)
                _email = Value
            End Set
        End Property

        Public Property [phone]() As String
            Get
                Return _phone
            End Get
            Set(ByVal Value As String)
                _phone = Value
            End Set
        End Property

        Public Property [PIN]() As String
            Get
                Return _PIN
            End Get
            Set(ByVal Value As String)
                _PIN = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
