Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class UploadDownload
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _Type, _UpdateStatus, _Description As String
        Private _UserUpdate As String
        Private _UpdateDate As String
        Private _TotalRecord As Decimal
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO UploadDownload " & _
                                        "(ID, Type, TotalRecord, UpdateDate, UserUpdate, UpdateStatus, Description) " & _
                                        "VALUES (@ID, @Type, @TotalRecord, GetDate(), @UserUpdate, @UpdateStatus, @Description)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@Type", _Type)
                cmdToExecute.Parameters.Add("@TotalRecord", _TotalRecord)                
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@UpdateStatus", _UpdateStatus)
                cmdToExecute.Parameters.Add("@Description", _Description)

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

        Public Overrides Function Update() As Boolean
            
        End Function

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM UploadDownload order by Type, UpdateDate"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UploadDownload")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            
        End Function

        Public Overrides Function Delete() As Boolean
            
        End Function

#Region " Custom Functions "
        Public Function UploadItemPriceToScale() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "UploadItemPriceToScale"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("UploadItemPriceToScale")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                'ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectByTypePrefixDescription(ByVal PrefixDescription As String, Optional ByVal TopRecord As String = "10") As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT TOP " + TopRecord.Trim + " * FROM UploadDownload " + _
                                        "WHERE Type = @Type " + _
                                        "AND Description LIKE '" + PrefixDescription.Trim + "%' " + _
                                        "ORDER BY UpdateDate DESC"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("UploadDownload")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@Type", _Type)

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

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property

        Public Property [Type]() As String
            Get
                Return _Type
            End Get
            Set(ByVal Value As String)
                _Type = Value
            End Set
        End Property

        Public Property [TotalRecord]() As Decimal
            Get
                Return _TotalRecord
            End Get
            Set(ByVal Value As Decimal)
                _TotalRecord = Value
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

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
            End Set
        End Property

        Public Property [UpdateStatus]() As String
            Get
                Return _UpdateStatus
            End Get
            Set(ByVal Value As String)
                _UpdateStatus = Value
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
#End Region

    End Class
End Namespace
