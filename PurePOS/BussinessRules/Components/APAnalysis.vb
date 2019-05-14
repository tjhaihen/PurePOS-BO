Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class APAnalysis
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _APAnalysisNo, _EntitiesSeqNo As String
        Private _UserInsert, _UserUpdate As String
        Private _StartDate, _EndDate As Date
        Private _InsertDate, _UpdateDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO APAnalysis " & _
                                        "(APAnalysisNo, StartDate, EndDate, EntitiesSeqNo, InsertDate, UpdateDate, UserInsert, UserUpdate) " & _
                                        "VALUES (@APAnalysisNo, @StartDate, @EndDate, @EntitiesSeqNo, GetDate(), GetDate(), @UserInsert, @UserUpdate)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APAnalysisNo", _APAnalysisNo)
                cmdToExecute.Parameters.Add("@StartDate", _StartDate)
                cmdToExecute.Parameters.Add("@EndDate", _EndDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

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
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE APAnalysis " & _
                                        "SET StartDate = @StartDate, " & _
                                        "EndDate = @EndDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "UserUpdate = @UserUpdate " & _
                                        "WHERE APAnalysisNo = @APAnalysisNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APAnalysisNo", _APAnalysisNo)
                cmdToExecute.Parameters.Add("@StartDate", _StartDate)
                cmdToExecute.Parameters.Add("@EndDate", _EndDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT *, CONVERT(VARCHAR,StartDate,106) + ' to ' + CONVERT(VARCHAR,EndDate,106) AS APAnalysisPeriod, " + _
                                        "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo=a.EntitiesSeqNo) AS EntitiesName, " + _
                                        "(SELECT EntitiesID FROM Entities WHERE EntitiesSeqNo=a.EntitiesSeqNo) AS EntitiesID FROM APAnalysis a ORDER BY APAnalysisNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APAnalysis")
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
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM APAnalysis WHERE APAnalysisNo = @APAnalysisNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM APAnalysis WHERE APAnalysisNo > @APAnalysisNo ORDER BY APAnalysisNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM APAnalysis WHERE APAnalysisNo < @APAnalysisNo ORDER BY APAnalysisNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("APAnalysis")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APAnalysisNo", _APAnalysisNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _APAnalysisNo = CType(toReturn.Rows(0)("APAnalysisNo"), String)
                    _StartDate = CType(toReturn.Rows(0)("StartDate"), Date)
                    _EndDate = CType(toReturn.Rows(0)("EndDate"), Date)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
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

#Region "Others Function "

#End Region

#Region " Class Property Declarations "
        Public Property [APAnalysisNo]() As String
            Get
                Return _APAnalysisNo
            End Get
            Set(ByVal Value As String)
                _APAnalysisNo = Value
            End Set
        End Property

        Public Property [EntitiesSeqNo]() As String
            Get
                Return _EntitiesSeqNo
            End Get
            Set(ByVal Value As String)
                _EntitiesSeqNo = Value
            End Set
        End Property

        Public Property [StartDate]() As Date
            Get
                Return _StartDate
            End Get
            Set(ByVal Value As Date)
                _StartDate = Value
            End Set
        End Property

        Public Property [EndDate]() As Date
            Get
                Return _EndDate
            End Get
            Set(ByVal Value As Date)
                _EndDate = Value
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
#End Region
    End Class
End Namespace