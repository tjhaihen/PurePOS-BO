Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesInvoicedt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _ID, _SalesInvoiceNo, _STxnNo As String
        Private _UserInsert, _UserDelete As String
        Private _InsertDate, _DeleteDate As String
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

            cmdToExecute.CommandText = "INSERT INTO SalesInvoicedt " & _
                                       "(ID, SalesInvoiceNo, STxnNo, , " & _
                                       "UserInsert, InsertDate, UserDelete, DeleteDate, IsDeleted) " & _
                                       "VALUES (@ID, @SalesInvoiceNo, @STxnNo, " & _
                                       "@UserInsert, getdate(), @, getdate(), '', '', 0) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)

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

            cmdToExecute.CommandText = "UPDATE SalesInvoicedt " & _
                                        "SET SalesInvoiceNo = @SalesInvoiceNo, " & _
                                        "STxnNo = @STxnNo, " & _
                                        " = GetDate() " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)

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

            cmdToExecute.CommandText = "SELECT * FROM SalesInvoicedt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoicedt")
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
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoicedt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoicedt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoicedt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesInvoicedt")
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
                    _SalesInvoiceNo = CType(toReturn.Rows(0)("SalesInvoiceNo"), String)
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    
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

            cmdToExecute.CommandText = "Update SalesInvoicedt " & _
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
        Public Function DeleteAllBySalesInvoiceNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update SalesInvoicedt " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE SalesInvoiceNo = @SalesInvoiceNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
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
        Public Function SelectAllBySalesInvoiceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.*, isnull(total.STxnDate,'') AS STxnDate, isnull(total.TotalDetail,0) AS TotalDetail, " & _
                                        "isnull(total.DiscFinalAmt,0) AS DiscFinalAmt, isnull(total.DeliveryFee,0) AS DeliveryFee, " & _
                                        "isnull(total.TaxAmount,0) AS TaxAmount, isnull(total.Total,0) AS total " & _
                                        "FROM SalesInvoicehd hd " & _
                                        "Inner join SalesInvoicedt dt on hd.SalesInvoiceNo = dt.SalesInvoiceNo " & _
                                        "Left Join " & _
                                        "( " & _
                                         "SELECT suh.STxnNo,suh.STxnDate,suh.EntitiesSeqNo, " & _
                                         "sud.TotalDetail, " & _
                                         "suh.DiscFinalAmt, " & _
                                         "suh.DeliveryFee, " & _
                                         "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) as TaxAmount, " & _
                                         "(sud.TotalDetail - suh.DiscFinalAmt + " & _
                                         "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) + suh.DeliveryFee " & _
                                         ") AS Total " & _
                                         "FROM SalesUnitHd suh " & _
                                         "INNER JOIN " & _
                                         "( " & _
                                          "SELECT dt.STxnNo , sum(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail " & _
                                          "FROM SalesUnitDt dt WHERE dt.IsDeleted = 0 " & _
                                          "GROUP BY dt.STxnNo " & _
                                         ") sud ON sud.STxnNo = suh.STxnNo " & _
                                         "WHERE suh.IsDeleted = 0 AND suh.IsApproval = 1 " & _
                                        ") total ON total.STxnNo = dt.STxnNo  " & _
                                        "where dt.IsDeleted = 0 AND hd.SalesInvoiceNo = @SalesInvoiceNo "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoicedt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)

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

        Public Function InsertToGridSalesInvoiceNo(ByVal detilRow As DataTable) As Boolean
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
                .Append("INSERT INTO SalesInvoicedt " & _
                        "(ID, SalesInvoiceNo, STxnNo, " & _
                        "UserInsert, InsertDate, " & _
                        "UserDelete, DeleteDate, IsDeleted ) " & _
                        "VALUES (@ID, @SalesInvoiceNo, @STxnNo, " & _
                        "@UserInsert, getdate(), " & _
                        "'', '', 0 )")
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

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesInvoicedt", "ID", conn, trans)
                        _STxnNo = CType(.Rows(iRecCount)("STxnNo"), String)

                        With cmdInsertDT.Parameters
                            .Add("@ID", _ID)
                            .Add("@SalesInvoiceNo", _SalesInvoiceNo)
                            .Add("@STxnNo", _STxnNo)
                            .Add("@UserInsert", _UserInsert)
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

        Public Function SelectOneSalesInvoicedtBySTxnNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT sd.* " & _
                                       "FROM SalesInvoiceHd sih " & _
                                       "INNER JOIN SalesInvoiceDt sd ON sd.SalesInvoiceNo = sih.SalesInvoiceNo " & _
                                       "WHERE sih.IsVoid = 0 And sd.IsDeleted = 0 " & _
                                       "AND sd.STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesInvoicedt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _SalesInvoiceNo = CType(toReturn.Rows(0)("SalesInvoiceNo"), String)
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)

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

        Public Function ValidateForSaveARReceivingDt() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                       "appay.SalesInvoiceNo, " & _
                                       "appay.Currency, " & _
                                       "appay.CurrencyRate, " & _
                                       "appay.Total, " & _
                                       "appay.DNAmount, " & _
                                       "isnull(pay.PaidAmount,0) AS PaidAmount, " & _
                                       "isnull(pay.nARReceiving,0) + 1 AS nARReceiving " & _
                                       "FROM " & _
                                       "( " & _
                                            "SELECT sih.SalesInvoiceNo,sih.Currency, " & _
                                            "sih.CurrencyRate,sum(total.Total) - sih.DNAmount AS total, " & _
                                            "sih.DNAmount " & _
                                            "FROM SalesInvoiceHd sih " & _
                                            "INNER JOIN SalesInvoiceDt sd ON sd.SalesInvoiceNo = sih.SalesInvoiceNo " & _
                                            "LEFT JOIN " & _
                                            "( " & _
                                                "SELECT suh.STxnNo,suh.EntitiesSeqNo, " & _
                                                "sud.TotalDetail, " & _
                                                "suh.DiscFinalAmt, " & _
                                                "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) as TaxAmount, " & _
                                                "(sud.TotalDetail - suh.DiscFinalAmt + " & _
                                                "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) + suh.DeliveryFee " & _
                                                ") AS Total " & _
                                                "FROM SalesUnitHd suh " & _
                                                "INNER JOIN " & _
                                                "( " & _
                                                    "SELECT dt.STxnNo , sum((dt.Qty * dt.Price) - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt) AS TotalDetail " & _
                                                    "FROM SalesUnitDt dt WHERE dt.IsDeleted = 0 " & _
                                                    "GROUP BY dt.STxnNo " & _
                                                ") sud ON sud.STxnNo = suh.STxnNo " & _
                                                "WHERE suh.IsDeleted = 0 AND suh.IsApproval = 1 " & _
                                            ") total ON total.STxnNo = sd.STxnNo " & _
                                            "WHERE sih.IsVoid = 0 AND sih.IsApproval = 1 " & _
                                            "AND sd.IsDeleted = 0 and sih.SalesInvoiceNo = @SalesInvoiceNo " & _
                                            "GROUP BY sih.SalesInvoiceNo,sih.Currency,sih.CurrencyRate,sih.DNAmount " & _
                                        ") appay " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                            "SELECT ad.SalesInvoiceNo, sum(ad.Amount) AS PaidAmount,count(ad.SalesInvoiceNo) AS nARReceiving " & _
                                            "FROM ARReceivingHd ah " & _
                                            "INNER JOIN ARReceivingdt ad ON ad.ARReceivingNo = ah.ARReceivingNo " & _
                                            "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0  " & _
                                            "GROUP BY ad.SalesInvoiceNo " & _
                                        ") pay ON pay.SalesInvoiceNo = appay.SalesInvoiceNo "

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ARReceiving")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)

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
        Public Property [SalesInvoiceNo]() As String
            Get
                Return _SalesInvoiceNo
            End Get
            Set(ByVal Value As String)
                _SalesInvoiceNo = Value
            End Set
        End Property
        Public Property [STxnNo]() As String
            Get
                Return _STxnNo
            End Get
            Set(ByVal Value As String)
                _STxnNo = Value
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
