Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesReturndt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _IDSU, _SReturnNo, _ItemSeqNo, _ItemUnitID, _ItemFactor, _Qty, _Price, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt As String
        Private _ID As String
        Private _Disc3Pct, _Disc3Amt, _ReturnFeePct, _ReturnFeeAmt, _Description As String
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

            cmdToExecute.CommandText = "INSERT INTO SalesReturndt " & _
                                       "(ID, IDSU, SReturnNo, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                                       "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, ReturnFeePct, ReturnFeeAmt, UserInsert, InsertDate, " & _
                                       "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                                       "VALUES (@ID, '', @SReturnNo, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                                       "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @ReturnFeePct, @ReturnFeeAmt, @UserInsert, getdate(), " & _
                                       "@UserUpdate, getdate(), '', '', 0, left(@Description,500)) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
                cmdToExecute.Parameters.Add("@Price", _Price)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.Add("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.Add("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
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
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "UPDATE SalesReturndt " & _
                                        "SET ItemSeqNo = @ItemSeqNo, " & _
                                        "ItemUnitID = @ItemUnitID, " & _
                                        "ItemFactor = @ItemFactor, " & _
                                        "Qty = @Qty, " & _
                                        "Price = @Price, " & _
                                        "Disc1Pct = @Disc1Pct, " & _
                                        "Disc1Amt = @Disc1Amt, " & _
                                        "Disc2Pct = @Disc2Pct, " & _
                                        "Disc2Amt = @Disc2Amt, " & _
                                        "Disc3Pct = @Disc3Pct, " & _
                                        "Disc3Amt = @Disc3Amt, " & _
                                        "ReturnFeePct = @ReturnFeePct, " & _
                                        "ReturnFeeAmt = @ReturnFeeAmt, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
                cmdToExecute.Parameters.Add("@Price", _Price)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.Add("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.Add("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM SalesReturndt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesReturndt")
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
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturndt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturndt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturndt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesReturndt")
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
                    _SReturnNo = CType(toReturn.Rows(0)("SReturnNo"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemUnitID = CType(toReturn.Rows(0)("ItemUnitID"), String)

                    _ItemFactor = CType(toReturn.Rows(0)("ItemFactor"), Decimal)
                    _Qty = CType(toReturn.Rows(0)("Qty"), Decimal)
                    _Price = CType(toReturn.Rows(0)("Price"), Decimal)
                    _Disc1Pct = CType(toReturn.Rows(0)("Disc1Pct"), Decimal)
                    _Disc1Amt = CType(toReturn.Rows(0)("Disc1Amt"), Decimal)
                    _Disc2Pct = CType(toReturn.Rows(0)("Disc2Pct"), Decimal)
                    _Disc2Amt = CType(toReturn.Rows(0)("Disc2Amt"), Decimal)
                    _Disc3Pct = CType(toReturn.Rows(0)("Disc3Pct"), Decimal)
                    _Disc3Amt = CType(toReturn.Rows(0)("Disc3Amt"), Decimal)
                    _ReturnFeePct = CType(toReturn.Rows(0)("ReturnFeePct"), Decimal)
                    _ReturnFeeAmt = CType(toReturn.Rows(0)("ReturnFeeAmt"), Decimal)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)

                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)

                    _Description = CType(toReturn.Rows(0)("Description"), String)
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

            cmdToExecute.CommandText = "Update SalesReturndt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
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
        Public Function DeleteAllBySReturnNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update SalesReturndt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and SReturnNo = @SReturnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)
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
        Public Function SelectForViewGrid() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.Qty , " + _
                                       "dt.ItemFactor , " + _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "dt.ReturnFeePct , " + _
                                       "dt.ReturnFeeAmt , " + _
                                       "isnull(pohd.CurrencyRate,1) as CurrencyRate , " + _
                                       "case when dt.IDSU <> '' then 1 else 0 end as IsDOItem " + _
                                       "FROM SalesReturnHd hd " + _
                                       "inner join SalesReturndt dt ON dt.SReturnNo = hd.SReturnNo " + _
                                       "Left join SalesUnitHd pohd ON pohd.STxnNo = hd.STxnNo and pohd.isDeleted = 0 " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND dt.SReturnNo = @SReturnNo "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesReturndt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)
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

        Public Function InsertItemSR(ByVal detilRow As DataTable, ByVal UserUpdate As String) As Boolean
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
                .Append("INSERT INTO SalesReturndt " & _
                        "(ID,IDSU, SReturnNo, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                        "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, ReturnFeePct, ReturnFeeAmt, UserInsert, InsertDate, " & _
                        "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                        "VALUES (@ID, @IDSU, @SReturnNo, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                        "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, @ReturnFeePct, @ReturnFeeAmt, @UserInsert, getdate(), " & _
                        "@UserUpdate, getdate(), '', '', 0, @Description) ")
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

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesReturndt", "ID", conn, trans, "SR")
                        _IDSU = CType(.Rows(iRecCount)("IDSU"), String)
                        _ItemSeqNo = CType(.Rows(iRecCount)("ItemSeqNo"), String)
                        _ItemUnitID = CType(.Rows(iRecCount)("ItemUnitID"), String)
                        _ItemFactor = CType(.Rows(iRecCount)("ItemFactor"), Double)
                        _Qty = CType(.Rows(iRecCount)("QtyReturn"), Double)
                        _Price = CType(.Rows(iRecCount)("Price"), Double)
                        _Disc1Pct = CType(.Rows(iRecCount)("Disc1Pct"), Double)
                        _Disc1Amt = CType(.Rows(iRecCount)("Disc1Amt"), Double)
                        _Disc2Pct = CType(.Rows(iRecCount)("Disc2Pct"), Double)
                        _Disc2Amt = CType(.Rows(iRecCount)("Disc2Amt"), Double)
                        _Disc3Pct = CType(.Rows(iRecCount)("Disc3Pct"), Double)
                        _Disc3Amt = CType(.Rows(iRecCount)("Disc3Amt"), Double)
                        _ReturnFeePct = CType(.Rows(iRecCount)("ReturnFeePct"), Double)
                        _ReturnFeeAmt = CType(.Rows(iRecCount)("ReturnFeeAmt"), Double)

                        With cmdInsertDT.Parameters
                            .Add("@ID", _ID)
                            .Add("@IDSU", _IDSU)
                            .Add("@SReturnNo", _SReturnNo)
                            .Add("@ItemSeqNo", _ItemSeqNo)
                            .Add("@ItemUnitID", _ItemUnitID)
                            .Add("@ItemFactor", _ItemFactor)
                            .Add("@Qty", _Qty)
                            .Add("@Price", _Price)
                            .Add("@Disc1Pct", _Disc1Pct)
                            .Add("@Disc1Amt", _Disc1Amt)
                            .Add("@Disc2Pct", _Disc2Pct)
                            .Add("@Disc2Amt", _Disc2Amt)
                            .Add("@Disc3Pct", _Disc3Pct)
                            .Add("@Disc3Amt", _Disc3Amt)
                            .Add("@ReturnFeePct", _ReturnFeePct)
                            .Add("@ReturnFeeAmt", _ReturnFeeAmt)
                            .Add("@UserInsert", UserUpdate)
                            .Add("@UserUpdate", UserUpdate)
                            .Add("@Description", "")
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
        Public Property [SReturnNo]() As String
            Get
                Return _SReturnNo
            End Get
            Set(ByVal Value As String)
                _SReturnNo = Value
            End Set
        End Property

        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [ItemUnitID]() As String
            Get
                Return _ItemUnitID
            End Get
            Set(ByVal Value As String)
                _ItemUnitID = Value
            End Set
        End Property

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
            End Set
        End Property

        Public Property [Qty]() As Decimal
            Get
                Return _Qty
            End Get
            Set(ByVal Value As Decimal)
                _Qty = Value
            End Set
        End Property

        Public Property [Price]() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal Value As Decimal)
                _Price = Value
            End Set
        End Property

        Public Property [Disc1Pct]() As Decimal
            Get
                Return _Disc1Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Pct = Value
            End Set
        End Property

        Public Property [Disc1Amt]() As Decimal
            Get
                Return _Disc1Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Amt = Value
            End Set
        End Property

        Public Property [Disc2Pct]() As Decimal
            Get
                Return _Disc2Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Pct = Value
            End Set
        End Property
        Public Property [Disc2Amt]() As Decimal
            Get
                Return _Disc2Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Amt = Value
            End Set
        End Property
        Public Property [Disc3Pct]() As Decimal
            Get
                Return _Disc3Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Pct = Value
            End Set
        End Property
        Public Property [Disc3Amt]() As Decimal
            Get
                Return _Disc3Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Amt = Value
            End Set
        End Property
        Public Property [ReturnFeePct]() As Decimal
            Get
                Return _ReturnFeePct
            End Get
            Set(ByVal Value As Decimal)
                _ReturnFeePct = Value
            End Set
        End Property
        Public Property [ReturnFeeAmt]() As Decimal
            Get
                Return _ReturnFeeAmt
            End Get
            Set(ByVal Value As Decimal)
                _ReturnFeeAmt = Value
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
