Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ARReceivingDt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _ID, _ARReceivingNo, _SalesInvoiceNo As String
        Private _Amount, _ForeignExchange As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As String
        Private _IsDeleted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ARReceivingDt " & _
                                       "(ID, ARReceivingNo, SalesInvoiceNo, Amount, ForeignExchange, " & _
                                       "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted) " & _
                                       "VALUES (@ID, @ARReceivingNo, @SalesInvoiceNo, @Amount, ForeignExchange, " & _
                                       "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@ForeignExchange", _ForeignExchange)
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

            cmdToExecute.CommandText = "UPDATE ARReceivingDt " & _
                                        "SET ARReceivingNo = @ARReceivingNo, " & _
                                        "SalesInvoiceNo = @SalesInvoiceNo, " & _
                                        "Amount = @Amount, " & _
                                        "ForeignExchange = @ForeignExchange, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@ForeignExchange", _ForeignExchange)
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

            cmdToExecute.CommandText = "SELECT * FROM ARReceivingDt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ARReceivingDt")
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
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingDt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingDt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingDt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ARReceivingDt")
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
                    _ARReceivingNo = CType(toReturn.Rows(0)("ARReceivingNo"), String)
                    _SalesInvoiceNo = CType(toReturn.Rows(0)("SalesInvoiceNo"), String)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                    _ForeignExchange = CType(toReturn.Rows(0)("ForeignExchange"), Decimal)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
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

            cmdToExecute.CommandText = "Update ARReceivingDt " & _
                                       "Set UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate(), " & _
                                       "IsDeleted = 1 " & _
                                       "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

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

#Region "Others Function"
        Public Function DeleteAllByARReceivingN0() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update ARReceivingDt " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE ARReceivingNo = @ARReceivingNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

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

        Public Function SelectForRadGridARReceiving() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                        "case when hd.isvoid = 1 then 0 else ( " & _
                                            "Select count(ad1.ARReceivingNo) " & _
                                            "FROM ARReceivingHd ah1 " & _
                                            "INNER JOIN ARReceivingDt ad1 ON ad1.ARReceivingNo = ah1.ARReceivingNo " & _
                                            "WHERE ad1.IsDeleted = 0 AND ah1.IsVoid = 0 AND ad1.ARReceivingNo = dt.ARReceivingNo AND ad1.ID <= dt.ID " & _
                                        ") end as nARReceiving, " & _
                                        "dt.*, isnull(ie.CurrencyRate,0) as CurrencyRateIE, " & _
                                        "isnull(ie.SalesInvoiceDate,'') as SalesInvoiceDate " & _
                                        "FROM ARReceivingHd hd " & _
                                        "INNER JOIN ARReceivingDt dt ON dt.ARReceivingNo = hd.ARReceivingNo " & _
                                        "LEFT JOIN SalesInvoiceHd ie ON ie.SalesInvoiceNo = dt.SalesInvoiceNo " & _
                                        "WHERE dt.IsDeleted = 0 " & _
                                        "AND dt.ARReceivingNo = @ARReceivingNo " & _
                                        "ORDER BY dt.ARReceivingNo,dt.ID "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ARReceivingDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)

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

        Public Function SelectSalesInvoiceNoInValidARReceiving() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT d.SalesInvoiceNo FROM ARReceivingDt d " & _
                                        "INNER JOIN ARReceivingHd h ON d.ARReceivingNo = h.ARReceivingNo " & _
                                        "WHERE d.IsDeleted = 0 AND h.IsVoid = 0 AND d.SalesInvoiceNo = @SalesInvoiceNo"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ARReceivingDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)

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

        Public Function InsertToGridARReceiving(ByVal detilRow As DataTable) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Insert Detil 
            Dim strSQLInsertDT As New Text.StringBuilder
            With strSQLInsertDT
                .Append("INSERT INTO ARReceivingDt " & _
                        "(ID, ARReceivingNo, SalesInvoiceNo, Amount, ForeignExchange, " & _
                        "UserInsert, InsertDate, " & _
                        "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted ) " & _
                        "VALUES (@ID, @ARReceivingNo, @SalesInvoiceNo, @Amount, @ForeignExchange, " & _
                        "@UserInsert, getdate(), " & _
                        "@UserUpdate, getdate(), '', '', 0 )")
            End With
            conn.Open()
            Try
                ' // begin the transaction
                trans = conn.BeginTransaction
                ' // detil 
                With detilRow

                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdInsertDT As New SqlCommand
                        With cmdInsertDT
                            .CommandText = strSQLInsertDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("ARReceivingDt", "ID", conn, trans)
                        _SalesInvoiceNo = CType(.Rows(iRecCount)("InvoiceNo"), String)
                        _Amount = CType(.Rows(iRecCount)("payment"), Double)
                        _ForeignExchange = (CType(.Rows(iRecCount)("payment"), Double) * CType(.Rows(iRecCount)("CurrencyRateIE"), Double)) - (CType(.Rows(iRecCount)("payment"), Double) * CType(.Rows(iRecCount)("CurrencyRateAP"), Double))

                        With cmdInsertDT.Parameters
                            .Add("@ID", _ID)
                            .Add("@ARReceivingNo", _ARReceivingNo)
                            .Add("@SalesInvoiceNo", _SalesInvoiceNo)
                            .Add("@Amount", _Amount)
                            .Add("@ForeignExchange", _ForeignExchange)
                            .Add("@UserInsert", _UserInsert)
                            .Add("@UserUpdate", _UserUpdate)

                        End With

                        ' // insert detil
                        cmdInsertDT.ExecuteNonQuery()
                        iRecCount += 1
                    End While
                End With
                trans.Commit()
                retVal = True
            Catch ex As Exception
                trans.Rollback()
                ' // do not throw an exception, just return ..!!
                '_Ex = ex
                ExceptionManager.Publish(ex)
            Finally
                If Not detilRow Is Nothing Then
                    detilRow.Dispose()
                End If
                detilRow = Nothing

                trans.Dispose()
                trans = Nothing

                If Not conn Is Nothing Then
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End If
                conn.Dispose()
                conn = Nothing
            End Try

            Return retVal
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
        Public Property [ARReceivingNo]() As String
            Get
                Return _ARReceivingNo
            End Get
            Set(ByVal Value As String)
                _ARReceivingNo = Value
            End Set
        End Property
        Public Property [SalesInvoiceNo]() As String
            Get
                Return _SalesInvoiceNo
            End Get
            Set(ByVal Value As String)
                _SalesInvoiceNo = Value
            End Set
        End Property


        Public Property [Amount]() As Decimal
            Get
                Return _Amount
            End Get
            Set(ByVal Value As Decimal)
                _Amount = Value
            End Set
        End Property

        Public Property [ForeignExchange]() As Decimal
            Get
                Return _ForeignExchange
            End Get
            Set(ByVal Value As Decimal)
                _ForeignExchange = Value
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

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

        Public Property [DeleteDate]() As DateTime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As DateTime)
                _DeleteDate = Value
            End Set
        End Property
        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
