Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesInvoiceHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _SalesInvoiceNo, _SalesInvoiceDate, _EntitiesSeqNo, _TermID, _BankID, _DueDate, _Description, _Currency, _CurrencyRate As String
        Private _UserInsert, _UserUpdate, _UserVoid, _UserApproval As String
        Private _InsertDate, _UpdateDate, _VoidDate, _ApprovalDate As String
        Private _IsVoid, _IsApproval As Boolean
        Private _DNAmount As Decimal
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO SalesInvoiceHd " & _
                                        "(SalesInvoiceNo, SalesInvoiceDate, EntitiesSeqNo, TermID, BankID, DueDate, Description, Currency, CurrencyRate, DNAmount, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserVoid, VoidDate, IsVoid,  " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@SalesInvoiceNo, @SalesInvoiceDate, @EntitiesSeqNo, @TermID, @BankID, @DueDate, left(@Description,500), @Currency, @CurrencyRate, @DNAmount, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, " & _
                                        "0, '', '' )"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@SalesInvoiceDate", _SalesInvoiceDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@TermID", _TermID)
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@DNAmount", _DNAmount)
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
            cmdToExecute.CommandText = "UPDATE SalesInvoiceHd " & _
                                        "SET SalesInvoiceDate = @SalesInvoiceDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "DueDate = @DueDate, " & _
                                        "TermID = @TermID, " & _
                                        "BankID = @BankID, " & _
                                        "Description = left(@Description,500), " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "DNAmount = @DNAmount, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE SalesInvoiceNo = @SalesInvoiceNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@SalesInvoiceDate", _SalesInvoiceDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@TermID", _TermID)
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@DNAmount", _DNAmount)
                cmdToExecute.Parameters.Add("@IsApproval", _IsApproval)
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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),SalesInvoiceDate,105) as formatdate FROM SalesInvoiceHd order by SalesInvoiceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
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

        Public Function SelectAllForSalesInvoiceNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.SalesInvoiceDate,105) as formatdate, " & _
                                       "case when hd.IsVoid = 1 then 'Void' " & _
                                       "when hd.IsApproval = 1 then 'Approved' " & _
                                       "else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM SalesInvoiceHd hd " & _
                                       "Where (hd.SalesInvoiceNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.SalesInvoiceDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.SalesInvoiceNo Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoiceHd WHERE SalesInvoiceNo = @SalesInvoiceNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoiceHd WHERE SalesInvoiceNo > @SalesInvoiceNo ORDER BY SalesInvoiceNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesInvoiceHd WHERE SalesInvoiceNo < @SalesInvoiceNo ORDER BY SalesInvoiceNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _SalesInvoiceNo = CType(toReturn.Rows(0)("SalesInvoiceNo"), String)
                    _SalesInvoiceDate = CType(toReturn.Rows(0)("SalesInvoiceDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _DueDate = CType(toReturn.Rows(0)("DueDate"), DateTime)
                    _TermID = CType(toReturn.Rows(0)("TermID"), String)
                    _BankID = CType(toReturn.Rows(0)("BankID"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)

                    _DNAmount = CType(toReturn.Rows(0)("DNAmount"), Decimal)
                    
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _VoidDate = CType(toReturn.Rows(0)("VoidDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserVoid = CType(toReturn.Rows(0)("UserVoid"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)

                    _IsVoid = CType(toReturn.Rows(0)("IsVoid"), Boolean)
                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
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

        Public Function Void() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update DebitCreditNote " & _
                                       "SET VoucherNo = '', " & _
                                       "IsProcess = 0, " & _
                                       "UserProcess = @UserVoid, " & _
                                       "ProcessDate = getdate() " & _
                                       "WHERE VoucherNo = @SalesInvoiceNo " & _
                                       "Update SalesInvoiceHd " & _
                                       "set IsVoid = 1, " & _
                                       "UserVoid = @UserVoid, " & _
                                       "VoidDate = getdate() " & _
                                       "WHERE IsVoid = 0 and SalesInvoiceNo = @SalesInvoiceNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SalesInvoiceNo", _SalesInvoiceNo)
                cmdToExecute.Parameters.Add("@UserVoid", _UserVoid)

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

#Region "Others Function "
        Public Function SelectForViewGridOutstandingAR() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT suh.STxnNo, suh.STxnDate, suh.EntitiesSeqNo, " & _
                                       "sud.TotalDetail, suh.DiscFinalAmt, suh.DeliveryFee, " & _
                                       "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) AS TaxAmount , " & _
                                       "(sud.TotalDetail - suh.DiscFinalAmt + " & _
                                       "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) + suh.DeliveryFee " & _
                                       ") AS Total " & _
                                       "FROM SalesUnitHd suh " & _
                                       "INNER Join " & _
                                       "( " & _
                                         "SELECT dt.STxnNo , sum((dt.Qty * dt.Price) - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt) AS TotalDetail " & _
                                         "FROM SalesUnitDt dt WHERE dt.IsDeleted = 0 " & _
                                         "GROUP BY dt.STxnNo " & _
                                       ") sud ON sud.STxnNo = suh.STxnNo " & _
                                      "WHERE suh.IsDeleted = 0 AND suh.IsApproval = 1 and suh.EntitiesSeqNo = @EntitiesSeqNo and suh.Currency = @Currency " & _
                                      "and (SELECT TOP 1 sid.STxnNo " & _
                                      "FROM SalesInvoiceHd sih " & _
                                      "INNER JOIN SalesInvoiceDt sid ON sid.SalesInvoiceNo = sih.SalesInvoiceNo " & _
                                      "WHERE sih.IsVoid = 0 AND sid.IsDeleted = 0 AND sid.STxnNo = suh.STxnNo) is null "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)

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

        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM SalesUnitHd hd " & _
                                       "inner join SalesUnitdt dt on Dt.STxnNo = hd.STxnNo " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and dt.isDeleted = 0 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "AND hd.STxnNo NOT IN (SELECT DISTINCT d.STxnNo FROM SalesInvoiceDt d INNER JOIN SalesInvoiceHd h ON h.SalesInvoiceNo = d.SalesInvoiceNo " & _
                                       "WHERE h.IsVoid = 0 AND d.IsDeleted = 0) " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
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

        Public Function SelectAllForEntitiesSeqNoARReceiving(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT DISTINCT Top " + MaxRecord + " appay.EntitiesSeqNo, " & _
                                       "appay.Currency, " & _
                                       "appay.CurrencyRate, " & _
                                       "isnull(e.EntitiesID,'') AS EntitiesID, " & _
                                       "isnull(e.EntitiesName,'') AS EntitiesName " & _
                                       "FROM " & _
                                       "( " & _
                                            "SELECT sih.SalesInvoiceNo,sih.Currency, " & _
                                            "sih.CurrencyRate,sum(ISNULL(total.Total,0)) - sih.DNAmount AS total,sih.EntitiesSeqNo " & _
                                            "FROM SalesInvoiceHd sih " & _
                                            "LEFT JOIN SalesInvoiceDt sd ON sd.SalesInvoiceNo = sih.SalesInvoiceNo " & _
                                            "LEFT JOIN " & _
                                            "( " & _
                                                "SELECT suh.STxnNo,suh.EntitiesSeqNo, " & _
                                                "sud.TotalDetail, " & _
                                                "suh.DiscFinalAmt, " & _
                                                "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) as TaxAmount, " & _
                                                "(sud.TotalDetail - suh.DiscFinalAmt + " & _
                                                "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) " & _
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
                                            "AND ISNULL(sd.IsDeleted,0) = 0 " & _
                                            "GROUP BY sih.SalesInvoiceNo,sih.Currency,sih.CurrencyRate,sih.DNAmount ,sih.EntitiesSeqNo " & _
                                        ") appay " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                            "SELECT ad.SalesInvoiceNo, sum(ad.Amount) AS PaidAmount,count(ad.SalesInvoiceNo) AS nARReceiving " & _
                                            "FROM ARReceivingHd ah " & _
                                            "INNER JOIN ARReceivingdt ad ON ad.ARReceivingNo = ah.ARReceivingNo " & _
                                            "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0  " & _
                                            "GROUP BY ad.SalesInvoiceNo " & _
                                        ") pay ON pay.SalesInvoiceNo = appay.SalesInvoiceNo " & _
                                        "LEFT JOIN Entities e ON e.EntitiesSeqNo = appay.EntitiesSeqNo " & _
                                        "WHERE (appay.Total - (isnull(pay.PaidAmount,0))) <> 0  " & _
                                        "and (E.EntitiesId LIKE '%" + Filter.Trim + "%' OR E.EntitiesName LIKE '%" + Filter.Trim + "%' OR appay.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            'cmdToExecute.CommandText = "SELECT DISTINCT Top " + MaxRecord + " appay.EntitiesSeqNo, " & _
            '                           "appay.SalesInvoiceNo, " & _
            '                           "appay.Currency, " & _
            '                           "appay.CurrencyRate, " & _
            '                           "appay.Total, " & _
            '                           "isnull(pay.PaidAmount,0) AS PaidAmount, " & _
            '                           "isnull(pay.nARReceiving,0) + 1 AS nARReceiving, " & _
            '                           "isnull(e.EntitiesID,'') AS EntitiesID, " & _
            '                           "isnull(e.EntitiesName,'') AS EntitiesName " & _
            '                           "FROM " & _
            '                           "( " & _
            '                                "SELECT sih.SalesInvoiceNo,sih.Currency, " & _
            '                                "sih.CurrencyRate,sum(total.Total) - sih.DNAmount AS total,sih.EntitiesSeqNo " & _
            '                                "FROM SalesInvoiceHd sih " & _
            '                                "INNER JOIN SalesInvoiceDt sd ON sd.SalesInvoiceNo = sih.SalesInvoiceNo " & _
            '                                "LEFT JOIN " & _
            '                                "( " & _
            '                                    "SELECT suh.STxnNo,suh.EntitiesSeqNo, " & _
            '                                    "sud.TotalDetail, " & _
            '                                    "suh.DiscFinalAmt, " & _
            '                                    "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) as TaxAmount, " & _
            '                                    "(sud.TotalDetail - suh.DiscFinalAmt + " & _
            '                                    "((sud.TotalDetail - suh.DiscFinalAmt) * suh.IsPPN * suh.PPNPct / 100) " & _
            '                                    ") AS Total " & _
            '                                    "FROM SalesUnitHd suh " & _
            '                                    "INNER JOIN " & _
            '                                    "( " & _
            '                                        "SELECT dt.STxnNo , sum((dt.Qty * dt.Price) - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt) AS TotalDetail " & _
            '                                        "FROM SalesUnitDt dt WHERE dt.IsDeleted = 0 " & _
            '                                        "GROUP BY dt.STxnNo " & _
            '                                    ") sud ON sud.STxnNo = suh.STxnNo " & _
            '                                    "WHERE suh.IsDeleted = 0 AND suh.IsApproval = 1 " & _
            '                                ") total ON total.STxnNo = sd.STxnNo " & _
            '                                "WHERE sih.IsVoid = 0 AND sih.IsApproval = 1 " & _
            '                                "AND sd.IsDeleted = 0 " & _
            '                                "GROUP BY sih.SalesInvoiceNo,sih.Currency,sih.CurrencyRate,sih.DNAmount ,sih.EntitiesSeqNo " & _
            '                            ") appay " & _
            '                            "LEFT JOIN " & _
            '                            "( " & _
            '                                "SELECT ad.SalesInvoiceNo, sum(ad.Amount) AS PaidAmount,count(ad.SalesInvoiceNo) AS nARReceiving " & _
            '                                "FROM ARReceivingHd ah " & _
            '                                "INNER JOIN ARReceivingdt ad ON ad.ARReceivingNo = ah.ARReceivingNo " & _
            '                                "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0  " & _
            '                                "GROUP BY ad.SalesInvoiceNo " & _
            '                            ") pay ON pay.SalesInvoiceNo = appay.SalesInvoiceNo " & _
            '                            "LEFT JOIN Entities e ON e.EntitiesSeqNo = appay.EntitiesSeqNo " & _
            '                            "WHERE isnull(pay.PaidAmount,0) < appay.Total " & _
            '                            "and (E.EntitiesId LIKE '%" + Filter.Trim + "%' OR E.EntitiesName LIKE '%" + Filter.Trim + "%' OR appay.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
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

        Public Function SelectForViewGridARInvoicing() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                       "appay.SalesInvoiceNo, appay.SalesInvoiceDate, " & _
                                       "appay.Currency, " & _
                                       "appay.CurrencyRate, " & _
                                       "appay.Total, " & _
                                       "appay.DNAmount, " & _
                                       "isnull(pay.PaidAmount,0) AS PaidAmount, " & _
                                       "isnull(pay.nARReceiving,0) + 1 AS nARReceiving " & _
                                       "FROM " & _
                                       "( " & _
                                            "SELECT sih.SalesInvoiceNo,sih.SalesInvoiceDate,sih.Currency, " & _
                                            "sih.CurrencyRate,sum(ISNULL(total.Total,0)) - sih.DNAmount AS total, " & _
                                            "sih.DNAmount " & _
                                            "FROM SalesInvoiceHd sih " & _
                                            "LEFT JOIN SalesInvoiceDt sd ON sd.SalesInvoiceNo = sih.SalesInvoiceNo " & _
                                            "LEFT JOIN " & _
                                            "( " & _
                                                "SELECT suh.STxnNo,suh.EntitiesSeqNo, " & _
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
                                            ") total ON total.STxnNo = sd.STxnNo " & _
                                            "WHERE sih.IsVoid = 0 AND sih.IsApproval = 1 " & _
                                            "AND ISNULL(sd.IsDeleted,0) = 0 and sih.EntitiesSeqNo = @EntitiesSeqNo and sih.Currency = @Currency " & _
                                            "GROUP BY sih.SalesInvoiceNo,sih.SalesInvoiceDate,sih.Currency,sih.CurrencyRate,sih.DNAmount " & _
                                        ") appay " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                            "SELECT ad.SalesInvoiceNo, sum(ad.Amount) AS PaidAmount,count(ad.SalesInvoiceNo) AS nARReceiving " & _
                                            "FROM ARReceivingHd ah " & _
                                            "INNER JOIN ARReceivingdt ad ON ad.ARReceivingNo = ah.ARReceivingNo " & _
                                            "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0  " & _
                                            "GROUP BY ad.SalesInvoiceNo " & _
                                        ") pay ON pay.SalesInvoiceNo = appay.SalesInvoiceNo " & _
                                        "WHERE (appay.Total - (isnull(pay.PaidAmount,0))) <> 0"

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesInvoiceHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)

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
        Public Property [SalesInvoiceNo]() As String
            Get
                Return _SalesInvoiceNo
            End Get
            Set(ByVal Value As String)
                _SalesInvoiceNo = Value
            End Set
        End Property
        Public Property [SalesInvoiceDate]() As DateTime
            Get
                Return _SalesInvoiceDate
            End Get
            Set(ByVal Value As DateTime)
                _SalesInvoiceDate = Value
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

        Public Property [DueDate]() As DateTime
            Get
                Return _DueDate
            End Get
            Set(ByVal Value As DateTime)
                _DueDate = Value
            End Set
        End Property

        Public Property [TermID]() As String
            Get
                Return _TermID
            End Get
            Set(ByVal Value As String)
                _TermID = Value
            End Set
        End Property

        Public Property [BankID]() As String
            Get
                Return _BankID
            End Get
            Set(ByVal Value As String)
                _BankID = Value
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

        Public Property [Currency]() As String
            Get
                Return _Currency
            End Get
            Set(ByVal Value As String)
                _Currency = Value
            End Set
        End Property

        Public Property [CurrencyRate]() As Decimal
            Get
                Return _CurrencyRate
            End Get
            Set(ByVal Value As Decimal)
                _CurrencyRate = Value
            End Set
        End Property

        Public Property [DNAmount]() As Decimal
            Get
                Return _DNAmount
            End Get
            Set(ByVal Value As Decimal)
                _DNAmount = Value
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

        Public Property [IsVoid]() As Boolean
            Get
                Return _IsVoid
            End Get
            Set(ByVal Value As Boolean)
                _IsVoid = Value
            End Set
        End Property

        Public Property [UserVoid]() As String
            Get
                Return _UserVoid
            End Get
            Set(ByVal Value As String)
                _UserVoid = Value
            End Set
        End Property


        Public Property [VoidDate]() As DateTime
            Get
                Return _VoidDate
            End Get
            Set(ByVal Value As DateTime)
                _VoidDate = Value
            End Set
        End Property

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
            End Set
        End Property

        Public Property [ApprovalDate]() As DateTime
            Get
                Return _ApprovalDate
            End Get
            Set(ByVal Value As DateTime)
                _ApprovalDate = Value
            End Set
        End Property

        Public Property [UserApproval]() As String
            Get
                Return _UserApproval
            End Get
            Set(ByVal Value As String)
                _UserApproval = Value
            End Set
        End Property

#End Region
    End Class
End Namespace