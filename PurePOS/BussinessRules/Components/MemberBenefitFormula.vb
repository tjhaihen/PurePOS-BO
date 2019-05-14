Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class MemberBenefitFormula
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _MBTypeID As String
        Private _MaxValue, _Point As Decimal
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO MemberBenefitFormula " & _
                                        "(ID, MaxValue, Point, MBTypeID, UserInsert, InsertDate, UserUpdate, UpdateDate) " & _
                                        "VALUES (@ID, @MaxValue, @Point, @MBTypeID, @UserInsert, GetDate(), @UserUpdate, GetDate())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@MaxValue", _MaxValue)
                cmdToExecute.Parameters.Add("@MBTypeID", _MBTypeID)
                cmdToExecute.Parameters.Add("@Point", _Point)
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

            cmdToExecute.CommandText = "UPDATE MemberBenefitFormula " & _
                                        "SET MaxValue = @MaxValue, " & _
                                        " Point = @Point, " & _
                                        "MBTypeID = @MBTypeID, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@MaxValue", _MaxValue)
                cmdToExecute.Parameters.Add("@MBTypeID", _MBTypeID)
                cmdToExecute.Parameters.Add("@Point", _Point)
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

            cmdToExecute.CommandText = "SELECT * FROM MemberBenefitFormula order by Maxvalue"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MemberBenefitFormula")
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

        Public Function SelectAllByMBTypeID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM MemberBenefitFormula where MBTypeID = @MBTypeID order by Maxvalue"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("MemberBenefitFormula")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@MBTypeID", _MBTypeID)
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

        'Public Function SelectAllForID(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
        '    Dim cmdToExecute As SqlCommand = New SqlCommand

        '    cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " * FROM MemberBenefitFormula " & _
        '                               "Where ID LIKE '%" + Filter.Trim + "%' OR MaxValue LIKE '%" + Filter.Trim + "%' " & _
        '                               "order by ID "
        '    cmdToExecute.CommandType = CommandType.Text

        '    Dim toReturn As DataTable = New DataTable("MemberBenefitFormula")
        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    cmdToExecute.Connection = _mainConnection

        '    Try
        '        _mainConnection.Open()

        '        adapter.Fill(toReturn)

        '        Return toReturn
        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM MemberBenefitFormula WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM MemberBenefitFormula WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM MemberBenefitFormula WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("MemberBenefitFormula")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _MaxValue = CType(toReturn.Rows(0)("MaxValue"), Decimal)
                    _MBTypeID = CType(toReturn.Rows(0)("MBTypeID"), String)
                    _Point = CType(toReturn.Rows(0)("Point"), Decimal)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM MemberBenefitFormula WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)

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

        Public Function DeleteAllByMBTypeID() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM MemberBenefitFormula WHERE MBTypeID = @MBTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@MBTypeID", _MBTypeID)

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

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property

        Public Property [Point]() As Decimal
            Get
                Return _Point
            End Get
            Set(ByVal Value As Decimal)
                _Point = Value
            End Set
        End Property

        Public Property [MaxValue]() As Decimal
            Get
                Return _MaxValue
            End Get
            Set(ByVal Value As Decimal)
                _MaxValue = Value
            End Set
        End Property

        Public Property [MBTypeID]() As String
            Get
                Return _MBTypeID
            End Get
            Set(ByVal Value As String)
                _MBTypeID = Value
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

        Public Property [InsertDate]() As DateTime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As DateTime)
                _InsertDate = Value
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
#End Region

    End Class
End Namespace
