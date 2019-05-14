Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class APPaymentDt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _ID, _APPaymentNo, _VoucherNo As String
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

            cmdToExecute.CommandText = "INSERT INTO APPaymentdt " & _
                                       "(ID, APPaymentNo, VoucherNo, Amount, ForeignExchange, " & _
                                       "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted) " & _
                                       "VALUES (@ID, @APPaymentNo, @VoucherNo, @Amount, ForeignExchange, " & _
                                       "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@APPaymentNo", _APPaymentNo)
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
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

            cmdToExecute.CommandText = "UPDATE APPaymentdt " & _
                                        "SET APPaymentNo = @APPaymentNo, " & _
                                        "VoucherNo = @VoucherNo, " & _
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
                cmdToExecute.Parameters.Add("@APPaymentNo", _APPaymentNo)
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
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

            cmdToExecute.CommandText = "SELECT * FROM APPaymentdt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APPaymentdt")
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
                    cmdToExecute.CommandText = "SELECT * FROM APPaymentdt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM APPaymentdt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM APPaymentdt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("APPaymentdt")
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
                    _APPaymentNo = CType(toReturn.Rows(0)("APPaymentNo"), String)
                    _VoucherNo = CType(toReturn.Rows(0)("VoucherNo"), String)
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

            cmdToExecute.CommandText = "Update APPaymentdt " & _
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
        Public Function DeleteAllByAPPaymentNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update APPaymentdt " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE APPaymentNo = @APPaymentNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APPaymentNo", _APPaymentNo)
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
        Public Function SelectForRadGridAPPayment() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                       "case when hd.isvoid = 1 then 0 else ( " & _
                                        "Select count(ad1.VoucherNo) " & _
                                        "FROM APPaymentHd ah1 " & _
                                        "INNER JOIN APPaymentDt ad1 ON ad1.APPaymentNo = ah1.APPaymentNo " & _
                                        "WHERE ad1.IsDeleted = 0 AND ah1.IsVoid = 0 AND ad1.VoucherNo = dt.VoucherNo AND ad1.ID <= dt.ID " & _
                                       ") end as nAPPayment, " & _
                                       "dt.*, isnull(ie.CurrencyRate,0) as CurrencyRateIE, " & _
                                       "ie.VoucherDate, ie.DueDate " & _
                                       "FROM APPaymentHd hd " & _
                                       "INNER JOIN APPaymentDt dt ON dt.APPaymentNo = hd.APPaymentNo " & _
                                       "LEFT JOIN APInvoice ie ON ie.VoucherNo = dt.VoucherNo " & _
                                       "WHERE dt.IsDeleted = 0 " & _
                                       "AND dt.APPaymentNo = @APPaymentNo " & _
                                       "ORDER BY dt.VoucherNo, dt.ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APPaymentdt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APPaymentNo", _APPaymentNo)

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

        Public Function InsertToGridAPPayment(ByVal detilRow As DataTable) As Boolean
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
                .Append("INSERT INTO APPaymentdt " & _
                        "(ID, APPaymentNo, VoucherNo, Amount, ForeignExchange, " & _
                        "UserInsert, InsertDate, " & _
                        "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted ) " & _
                        "VALUES (@ID, @APPaymentNo, @VoucherNo, @Amount, @ForeignExchange, " & _
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

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("APPaymentdt", "ID", conn, trans)
                        _VoucherNo = CType(.Rows(iRecCount)("VoucherNo"), String)
                        _Amount = CType(.Rows(iRecCount)("payment"), Double)
                        _ForeignExchange = (CType(.Rows(iRecCount)("payment"), Double) * CType(.Rows(iRecCount)("CurrencyRateIE"), Double)) - (CType(.Rows(iRecCount)("payment"), Double) * CType(.Rows(iRecCount)("CurrencyRateAP"), Double))

                        With cmdInsertDT.Parameters
                            .Add("@ID", _ID)
                            .Add("@APPaymentNo", _APPaymentNo)
                            .Add("@VoucherNo", _VoucherNo)
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

        Public Function ValidateForSaveAPPaymentDt() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                       "appay.VoucherNo, " & _
                                       "(appay.TotalPU + appay.TaxAmount + appay.BankAdmFee +  " & _
                                       "appay.DeliveryFee + appay.StampDutyFee - appay.CNAmount -  " & _
                                       "appay.DPAmt) AS TotalAmtVoucher, " & _
                                       "isnull(pay.PaidAmount,0) AS PaidAmount, " & _
                                       "isnull(pay.nAPPayment,0) + 1 AS nAPPayment " & _
                                       "FROM " & _
                                       "( " & _
                                         "SELECT ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate, " & _
                                         "ie.Currency,ie.CurrencyRate, " & _
                                         "sum((pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt)) AS TotalPU, " & _
                                         "sum((ie.IsPPN * ie.PPNPct * (pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt) / 100)) AS TaxAmount, " & _
                                         "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt " & _
                                         "FROM APInvoice ie " & _
                                         "INNER JOIN PurchaseUnitHd puh ON puh.VoucherNo = ie.VoucherNo AND puh.EntitiesSeqNo = ie.EntitiesSeqNo AND puh.Currency = ie.Currency " & _
                                         "INNER JOIN " & _
                                         "( " & _
                                          "SELECT dt.PUnitNO,((((dt.Qty * dt.Price) - dt.Disc1Amt) - dt.Disc2Amt) - dt.Disc3Amt) AS TotalDetail " & _
                                          "FROM PurchaseUnitDt dt " & _
                                          "WHERE dt.IsDeleted = 0 " & _
                                         ") pudt ON pudt.PUnitNO = puh.PUnitNO " & _
                                         "WHERE Ie.IsVerified = 1 and ie.VoucherNo = @VoucherNo " & _
                                         "GROUP BY ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate,ie.Currency,ie.CurrencyRate, " & _
                                         "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt " & _
                                        ") appay " & _
                                        "LEFT JOIN  " & _
                                        "( " & _
                                         "SELECT ad.VoucherNo, sum(ad.Amount) AS PaidAmount,count(ad.VoucherNo) AS nAPPayment " & _
                                         "FROM APPaymentHd ah " & _
                                         "INNER JOIN APPaymentDt ad ON ad.APPaymentNo = ah.APPaymentNo " & _
                                         "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0 " & _
                                         "GROUP BY ad.VoucherNo " & _
                                        ") pay ON pay.VoucherNo = appay.VoucherNo "

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("APInvoice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)

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
        Public Property [APPaymentNo]() As String
            Get
                Return _APPaymentNo
            End Get
            Set(ByVal Value As String)
                _APPaymentNo = Value
            End Set
        End Property
        Public Property [VoucherNo]() As String
            Get
                Return _VoucherNo
            End Get
            Set(ByVal Value As String)
                _VoucherNo = Value
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
