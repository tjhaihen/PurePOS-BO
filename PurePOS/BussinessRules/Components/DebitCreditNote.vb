Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DebitCreditNote
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _DCNoteNo, _DCNoteDate, _EntitiesSeqNo, _ReferenceNo, _DCNoteID, _Description, _TaxPct, _VoucherNo, _Currency As String
        Private _Amount, _AmtDifferences As Decimal
        Private _UserInsert, _UserUpdate, _UserProcess, _ProcessDate, _UpdateDate, _InsertDate, _UserDelete, _DeleteDate As String
        Private _IsProcess, _IsDeleted, _IsTax As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO DebitCreditNote " & _
                                        "(DCNoteNo, DCNoteDate, EntitiesSeqNo, DCNoteID, ReferenceNo, Currency, IsTax, TaxPct, AmtDifferences, " & _
                                        "Amount, Description, UserInsert, InsertDate, UserUpdate, UpdateDate, " & _
                                        "IsProcess, UserProcess, ProcessDate, IsDeleted, UserDelete, DeleteDate, VoucherNo) " & _
                                        "VALUES (@DCNoteNo, @DCNoteDate, @EntitiesSeqNo, @DCNoteID, @ReferenceNo, @Currency, @IsTax, @TaxPct, @AmtDifferences, " & _
                                        "@Amount, left(@Description,500), @UserInsert, getdate(), @UserUpdate, getdate(), " & _
                                        "0, '', '', 0, '', '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
                cmdToExecute.Parameters.Add("@DCNoteDate", _DCNoteDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@IsTax", _IsTax)
                cmdToExecute.Parameters.Add("@TaxPct", _TaxPct)
                cmdToExecute.Parameters.Add("@AmtDifferences", _AmtDifferences)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@Description", _Description)
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
            cmdToExecute.CommandText = "UPDATE DebitCreditNote " & _
                                        "SET DCNoteDate = @DCNoteDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "DCNoteID = @DCNoteID, " & _
                                        "ReferenceNo = @ReferenceNo, " & _
                                        "Currency = @Currency, " & _
                                        "IsTax = @IsTax, " & _
                                        "TaxPct = @TaxPct, " & _
                                        "AmtDifferences = @AmtDifferences, " & _
                                        "Amount = @Amount, " & _
                                        "Description = left(@Description,500), " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = getdate() " & _
                                        "WHERE DCNoteNo = @DCNoteNo"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
                cmdToExecute.Parameters.Add("@DCNoteDate", _DCNoteDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@IsTax", _IsTax)
                cmdToExecute.Parameters.Add("@TaxPct", _TaxPct)
                cmdToExecute.Parameters.Add("@AmtDifferences", _AmtDifferences)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
                cmdToExecute.Parameters.Add("@Description", _Description)
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

            cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote order by DCNoteNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectAllForDCNoteNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " dc.*, convert(varchar(10),dc.DCNoteDate,105) as formatdate, " & _
                                       "(Case When dc.IsProcess = 1 then 'Processed' else '' end) as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = dc.EntitiesSeqNo) AS EntitiesName, " & _
                                       "CONVERT(VARCHAR, dc.Amount, 105) AS strAmount " & _
                                       "FROM DebitCreditNote dc " & _
                                       "Where dc.IsDeleted = 0 and dc.DCNoteID = @DCNoteID and (dc.DCNoteNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),dc.DCNoteDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = dc.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by dc.DCNoteNo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteID", _DCNoteID)
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

        Public Function SelectOneByReferenceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote where IsDeleted = 0 and ReferenceNo = @ReferenceNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
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
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo = @DCNoteNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo > @DCNoteNo ORDER BY DCNoteNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM DebitCreditNote WHERE DCNoteNo < @DCNoteNo ORDER BY DCNoteNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DCNoteNo = CType(toReturn.Rows(0)("DCNoteNo"), String)
                    _DCNoteDate = CType(toReturn.Rows(0)("DCNoteDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)

                    _DCNoteID = CType(toReturn.Rows(0)("DCNoteID"), String)

                    _ReferenceNo = CType(toReturn.Rows(0)("ReferenceNo"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _IsTax = CType(toReturn.Rows(0)("IsTax"), Boolean)

                    _TaxPct = CType(toReturn.Rows(0)("TaxPct"), String)
                    _AmtDifferences = CType(toReturn.Rows(0)("AmtDifferences"), Decimal)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _VoucherNo = CType(toReturn.Rows(0)("VoucherNo"), String)

                    _IsProcess = CType(toReturn.Rows(0)("IsProcess"), Boolean)
                    _UserProcess = CType(toReturn.Rows(0)("UserProcess"), String)
                    _ProcessDate = CType(toReturn.Rows(0)("ProcessDate"), DateTime)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)

                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
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

            cmdToExecute.CommandText = "Update DebitCreditNote " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE DCNoteNo = @DCNoteNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
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

        Public Function DeleteVoucherNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update DebitCreditNote " & _
                                       "Set VoucherNo = @VoucherNo, " & _
                                       "IsProcess = @IsProcess " & _
                                       "WHERE DCNoteNo = @DCNoteNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DCNoteNo", _DCNoteNo)
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
                cmdToExecute.Parameters.Add("@IsProcess", _IsProcess)

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
        Public Function SelectAllForReferenceNoCN(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.PReturnNO as ReferenceNo,convert(varchar(10),hd.PReturnDate,105) as formatdate " & _
                                       "from PurchaseReturnHd hd " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.PReturnNO) is null " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo and (hd.PReturnNO LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.PReturnDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.PReturnNO desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
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
        Public Function SelectAllForReferenceNoDN(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.SReturnNO as ReferenceNo,convert(varchar(10),hd.SReturnDate,105) as formatdate " & _
                                       "from SalesReturnHd hd " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.SReturnNO) is null " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo and (hd.SReturnNO LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.SReturnDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.SReturnNO desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
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

        Public Function SelectAllForEntitiesSeqNoCN(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM PurchaseReturnHd hd " & _
                                       "inner join PurchaseReturndt dt on Dt.PReturnNO = hd.PReturnNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.PReturnNO) is null " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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
        Public Function SelectAllForEntitiesSeqNoDN(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM SalesReturnHd hd " & _
                                       "inner join SalesReturndt dt on Dt.SReturnNO = hd.SReturnNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (select top 1 dc.DCNoteNo from DebitCreditNote dc where dc.isDeleted = 0 and dc.ReferenceNo = hd.SReturnNO) is null " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectOneForReferenceNo() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT hd.PReturnNO as DCNoteNo, dt.TotalDetail , ((dt.TotalDetail - ReturnFeeAmt) * (hd.IsPPN * hd.PPNPct)) AS Tax, " & _
                                       "hd.ReturnFeeAmt , (dt.TotalDetail + ((dt.TotalDetail - ReturnFeeAmt) * (hd.IsPPN * hd.PPNPct / 100)) - hd.ReturnFeeAmt) AS Amount, hd.Currency " & _
                                       "FROM PurchaseReturnHd hd " & _
                                       "inner Join " & _
                                       "( " & _
                                         "SELECT t.PReturnNO, SUM(t.Qty * (t.price - t.Disc1Amt - t.Disc2Amt - t.Disc3Amt - t.ReturnFeeAmt)) AS TotalDetail " & _
                                         "FROM PurchaseReturndt t WHERE IsDeleted = 0 " & _
                                         "GROUP BY t.PReturnNO " & _
                                       ") dt ON dt.PReturnNO = hd.PReturnNO " & _
                                       "Where hd.IsDeleted = 0 AND hd.IsApproval = 1 and hd.PReturnNO = @ReferenceNo " & _
                                       " Union All " & _
                                       "SELECT hd.SReturnNO as DCNoteNo, dt.TotalDetail , ((dt.TotalDetail - ReturnFeeAmt) * (hd.IsPPN * hd.PPNPct)) AS Tax, " & _
                                       "hd.ReturnFeeAmt , (dt.TotalDetail + ((dt.TotalDetail - ReturnFeeAmt) * (hd.IsPPN * hd.PPNPct / 100)) - hd.ReturnFeeAmt) AS Amount, hd.Currency " & _
                                       "FROM SalesReturnHd hd " & _
                                       "inner Join " & _
                                       "( " & _
                                         "SELECT t.SReturnNO, SUM(t.Qty * (t.price - t.Disc1Amt - t.Disc2Amt - t.Disc3Amt - t.ReturnFeeAmt)) AS TotalDetail " & _
                                         "FROM SalesReturndt t WHERE IsDeleted = 0 " & _
                                         "GROUP BY t.SReturnNO " & _
                                       ") dt ON dt.SReturnNO = hd.SReturnNO " & _
                                       "Where hd.IsDeleted = 0 AND hd.IsApproval = 1 and hd.SReturnNO = @ReferenceNo  "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReferenceNo", _ReferenceNo)
                _mainConnection.Open()

                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DCNoteNo = CType(toReturn.Rows(0)("DCNoteNo"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                End If

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectAllForViewGridCNDN() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT *, (Amount * IsTax * TaxPct / 100) as TaxAmount " & _
                                       "FROM DebitCreditNote dcn " & _
                                       "WHERE IsDeleted = 0 And IsProcess = 1 " & _
                                       "AND dcn.VoucherNo <> '' AND dcn.VoucherNo = @VoucherNo "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
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

        Public Function SelectAllForViewGridGetCNAPInvoice(ByVal Currency As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dcn.*, (Amount * IsTax * TaxPct / 100) as TaxAmount " & _
                                       "FROM DebitCreditNote dcn " & _
                                       "left join PurchaseReturnHd prh on prh.PReturnNO = dcn.ReferenceNo " & _
                                       "WHERE dcn.IsDeleted = 0 And dcn.IsProcess = 0 " & _
                                       "AND dcn.VoucherNo = '' and prh.Currency = @Currency " & _
                                       "AND dcn.EntitiesSeqNo = @EntitiesSeqNo and dcn.DCNoteID = '01' "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
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

        Public Function UpdateVoucherNo(ByVal detilRow As DataTable) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim da As SqlDataAdapter
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Update Detil 
            Dim strSQLUpdateDT As New Text.StringBuilder
            With strSQLUpdateDT
                .Append("UPDATE DebitCreditNote " & _
                        "SET VoucherNo = @VoucherNo, " & _
                        "IsProcess = 1, " & _
                        "ProcessDate = getdate(), " & _
                        "UserProcess = @UserProcess " & _
                        "WHERE DCNoteNo = @DCNoteNo")
            End With

            conn.Open()

            Try
                '
                ' // begin the transaction
                '
                trans = conn.BeginTransaction

                ' // detil 
                With detilRow
                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdUpdateDT As New SqlCommand
                        With cmdUpdateDT
                            .CommandText = strSQLUpdateDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With
                        With cmdUpdateDT.Parameters
                            .Add(New SqlParameter("@DCNoteNo", New SqlString(CStr(detilRow.Rows(iRecCount)("NomorID")))))
                            .Add(New SqlParameter("@VoucherNo", _VoucherNo))
                            .Add(New SqlParameter("@UserProcess", _UserUpdate))
                        End With
                        ' // update detil
                        cmdUpdateDT.ExecuteNonQuery()
                        iRecCount += 1
                    End While

                End With

                trans.Commit()
                retVal = True
            Catch ex As Exception
                trans.Rollback()
                ' // do not throw an exception, just return ..!!
                ExceptionManager.Publish(ex)
            Finally
                If Not detilRow Is Nothing Then
                    detilRow.Dispose()
                End If
                detilRow = Nothing

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

        Public Function SelectAllForViewGridGetARInvoicing(ByVal Currency As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dcn.*, (Amount * IsTax * TaxPct / 100) as TaxAmount " & _
                                       "FROM DebitCreditNote dcn " & _
                                       "left join SalesReturnHd prh on prh.SReturnNO = dcn.ReferenceNo " & _
                                       "WHERE dcn.IsDeleted = 0 And dcn.IsProcess = 0 " & _
                                       "AND dcn.VoucherNo = '' and prh.Currency = @Currency " & _
                                       "AND dcn.EntitiesSeqNo = @EntitiesSeqNo and dcn.DCNoteID = '02' "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DebitCreditNote")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
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
        Public Property [DCNoteNo]() As String
            Get
                Return _DCNoteNo
            End Get
            Set(ByVal Value As String)
                _DCNoteNo = Value
            End Set
        End Property

        Public Property [DCNoteDate]() As DateTime
            Get
                Return _DCNoteDate
            End Get
            Set(ByVal Value As DateTime)
                _DCNoteDate = Value
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

        Public Property [DCNoteID]() As String
            Get
                Return _DCNoteID
            End Get
            Set(ByVal Value As String)
                _DCNoteID = Value
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

        Public Property [ReferenceNo]() As String
            Get
                Return _ReferenceNo
            End Get
            Set(ByVal Value As String)
                _ReferenceNo = Value
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

        Public Property [IsTax]() As Boolean
            Get
                Return _IsTax
            End Get
            Set(ByVal Value As Boolean)
                _IsTax = Value
            End Set
        End Property

        Public Property [TaxPct]() As String
            Get
                Return _TaxPct
            End Get
            Set(ByVal Value As String)
                _TaxPct = Value
            End Set
        End Property

        Public Property [AmtDifferences]() As Decimal
            Get
                Return _AmtDifferences
            End Get
            Set(ByVal Value As Decimal)
                _AmtDifferences = Value
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


        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property [IsProcess]() As Boolean
            Get
                Return _IsProcess
            End Get
            Set(ByVal Value As Boolean)
                _IsProcess = Value
            End Set
        End Property

        Public Property [UserProcess]() As String
            Get
                Return _UserProcess
            End Get
            Set(ByVal Value As String)
                _UserProcess = Value
            End Set
        End Property

        Public Property [ProcessDate]() As DateTime
            Get
                Return _ProcessDate
            End Get
            Set(ByVal Value As DateTime)
                _ProcessDate = Value
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

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
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

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

#End Region
    End Class
End Namespace