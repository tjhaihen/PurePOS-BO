Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class APInvoice
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _VoucherNo, _VoucherDate, _TaxDate, _EntitiesSeqNo, _Currency, _CurrencyRate, _TaxInvoiceNo, _InvoiceNo, _Description, _PPNPct As String
        Private _DueDate As DateTime
        Private _BankAdmFee, _DeliveryFee, _StampDutyFee, _CNAmount, _DPAmt, _RoundingAmt As Decimal
        Private _UserVerified, _UserInsert, _UserUpdate, _UserDelete, _UserApproval As String
        Private _VerifiedDate, _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate As DateTime
        Private _IsPPN, _IsVerified, _IsDeleted, _IsApproval As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO APInvoice " & _
                                        "(VoucherNo, VoucherDate, TaxDate, EntitiesSeqNo, DueDate, Currency, CurrencyRate, TaxInvoiceNo, InvoiceNo, Description, IsPPN, PPNPct, " & _
                                        "BankAdmFee, DeliveryFee, StampDutyFee, CNAmount, DPAmt, RoundingAmt, IsVerified, UserVerified, VerifiedDate, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted,  " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@VoucherNo, @VoucherDate, @TaxDate, @EntitiesSeqNo, @DueDate, @Currency, @CurrencyRate, @TaxInvoiceNo, @InvoiceNo, left(@Description,500), @IsPPN, @PPNPct, " & _
                                        "@BankAdmFee, @DeliveryFee, @StampDutyFee, @CNAmount, @DPAmt, @RoundingAmt, 0, '', '', " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, " & _
                                        "0, '', '' )"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
                cmdToExecute.Parameters.Add("@VoucherDate", _VoucherDate)
                cmdToExecute.Parameters.Add("@TaxDate", _TaxDate)

                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@InvoiceNo", _InvoiceNo)
                cmdToExecute.Parameters.Add("@TaxInvoiceNo", _TaxInvoiceNo)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@BankAdmFee", _BankAdmFee)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@StampDutyFee", _StampDutyFee)
                cmdToExecute.Parameters.Add("@CNAmount", _CNAmount)
                cmdToExecute.Parameters.Add("@DPAmt", _DPAmt)
                cmdToExecute.Parameters.Add("@RoundingAmt", _RoundingAmt)
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
            cmdToExecute.CommandText = "UPDATE APInvoice " & _
                                        "SET VoucherDate = @VoucherDate, " & _
                                        "TaxDate = @TaxDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "DueDate = @DueDate, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "InvoiceNo = @InvoiceNo, " & _
                                        "TaxInvoiceNo = @TaxInvoiceNo, " & _
                                        "Description = left(@Description,500), " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "BankAdmFee = @BankAdmFee, " & _
                                        "DeliveryFee = @DeliveryFee, " & _
                                        "StampDutyFee = @StampDutyFee, " & _
                                        "CNAmount = @CNAmount, " & _
                                        "DPAmt = @DPAmt, " & _
                                        "RoundingAmt = @RoundingAmt, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE VoucherNo = @VoucherNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
                cmdToExecute.Parameters.Add("@VoucherDate", _VoucherDate)
                cmdToExecute.Parameters.Add("@TaxDate", _TaxDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@InvoiceNo", _InvoiceNo)
                cmdToExecute.Parameters.Add("@TaxInvoiceNo", _TaxInvoiceNo)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@BankAdmFee", _BankAdmFee)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@StampDutyFee", _StampDutyFee)
                cmdToExecute.Parameters.Add("@CNAmount", _CNAmount)
                cmdToExecute.Parameters.Add("@DPAmt", _DPAmt)
                cmdToExecute.Parameters.Add("@RoundingAmt", _RoundingAmt)
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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),VoucherDate,105) as formatdate FROM APInvoice order by VoucherNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function SelectAllForVoucherNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " a.*,convert(varchar(10),a.VoucherDate,105) as formatdate, " & _
                                       "case when a.IsVerified = 1 then 'Verified' " & _
                                       "when a.IsApproval = 1 then 'Approved' " & _
                                       "when a.Isdeleted = 1 then 'Deleted' " & _
                                       "else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = a.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM APInvoice a " & _
                                       "Where a.IsDeleted = 0 and (a.VoucherNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),a.VoucherDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = a.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by a.VoucherNo Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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
                    cmdToExecute.CommandText = "SELECT * FROM APInvoice WHERE VoucherNo = @VoucherNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM APInvoice WHERE VoucherNo > @VoucherNo ORDER BY VoucherNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM APInvoice WHERE VoucherNo < @VoucherNo ORDER BY VoucherNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("APInvoice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _VoucherNo = CType(toReturn.Rows(0)("VoucherNo"), String)
                    _VoucherDate = CType(toReturn.Rows(0)("VoucherDate"), DateTime)
                    _TaxDate = CType(toReturn.Rows(0)("TaxDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _DueDate = CType(toReturn.Rows(0)("DueDate"), DateTime)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _InvoiceNo = CType(toReturn.Rows(0)("InvoiceNo"), String)
                    _TaxInvoiceNo = CType(toReturn.Rows(0)("TaxInvoiceNo"), String)
                    _IsPPN = CType(toReturn.Rows(0)("IsPPN"), Boolean)
                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _BankAdmFee = CType(toReturn.Rows(0)("BankAdmFee"), Decimal)
                    _DeliveryFee = CType(toReturn.Rows(0)("DeliveryFee"), Decimal)
                    _StampDutyFee = CType(toReturn.Rows(0)("StampDutyFee"), Decimal)
                    _CNAmount = CType(toReturn.Rows(0)("CNAmount"), Decimal)
                    _DPAmt = CType(toReturn.Rows(0)("DPAmt"), Decimal)
                    _RoundingAmt = CType(toReturn.Rows(0)("RoundingAmt"), Decimal)

                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _VerifiedDate = CType(toReturn.Rows(0)("VerifiedDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _UserVerified = CType(toReturn.Rows(0)("UserVerified"), String)

                    _IsVerified = CType(toReturn.Rows(0)("IsVerified"), Boolean)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update APInvoice " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and VoucherNo = @VoucherNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)
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

#Region "Others Function "
        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM APInvoice hd " & _
                                       "inner join PurchaseUnitDt dt on Dt.VoucherNo = hd.VoucherNo " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function SelectAllForVoucherNoPReturn(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " *,convert(varchar(10),hd.VoucherDate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status " & _
                                       "FROM APInvoice hd " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and hd.EntitiesSeqNo = @EntitiesSeqNo and hd. = @ and hd. = @ and hd.Currency = @Currency " & _
                                       "And (SELECT count(pud.VoucherNo) " & _
                                       "FROM PurchaseUnitDt pud " & _
                                       "WHERE pud.VoucherNo = hd.VoucherNo AND pud.IsDeleted = 0 " & _
                                       "AND (pud.Qty * pud.ItemFactor) > pud.QtyReturn) > 0 " & _
                                       "and (hd.VoucherNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.VoucherDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.VoucherNo Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function SelectForViewGridAPVerification() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate, " & _
                                       "ie.Currency,ie.CurrencyRate, " & _
                                       "isnull(En.EntitiesID,'') as EntitiesID , " + _
                                       "isnull(En.EntitiesName,'') as EntitiesName , " + _
                                       "sum((pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt)) AS TotalPU, " & _
                                       "sum((ie.IsPPN * ie.PPNPct * (pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt) / 100)) AS TaxAmount, " & _
                                       "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt " & _
                                       "FROM APInvoice ie " & _
                                       "INNER JOIN PurchaseUnitHd puh ON puh.VoucherNo = ie.VoucherNo AND puh.EntitiesSeqNo = ie.EntitiesSeqNo AND puh.Currency = ie.Currency " & _
                                       "INNER JOIN " & _
                                       "( " & _
                                            "SELECT dt.PUnitNO,(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail " & _
                                            "FROM PurchaseUnitDt dt " & _
                                            "WHERE dt.IsDeleted = 0 " & _
                                       ") pudt ON pudt.PUnitNO = puh.PUnitNO " & _
                                       "LEFT JOIN Entities En ON En.EntitiesSeqNo = ie.EntitiesSeqNo  " + _
                                       "WHERE Ie.IsVerified = 0 AND ie.Currency = @Currency " & _
                                       "AND CONVERT(varchar(8),ie.DueDate,112) <= CONVERT(varchar(8),@DueDate,112) " & _
                                       IIf(_EntitiesSeqNo.Trim = "", "", "and ie.EntitiesSeqNo = @EntitiesSeqNo ") + _
                                       "GROUP BY ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,En.EntitiesID,En.EntitiesName,ie.DueDate,ie.Currency,ie.CurrencyRate, " & _
                                       "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
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

        Public Function SelectAllForEntitiesSeqNoAPVerification(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM APInvoice hd " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsVerified = 0 and hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function SelectAllForCurrencyAPVerification() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct hd.Currency, " & _
                                       "isnull(cs.DetailDesc,'') as CurrencyName " & _
                                       "FROM APInvoice hd " & _
                                       "LEFT join (select * from CommonSetting WHERE GroupID = 'Currency') cs on cs.DetailID = hd.Currency " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and hd.IsVerified = 0 and cs.IsDeleted = 0 and cs.IsActive = 1 " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function UpdateStatusVerification(ByVal detilRow As DataTable) As Boolean
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
                .Append("UPDATE APInvoice " & _
                        "SET IsVerified = @IsVerified, " & _
                        "UserVerified = @UserVerified, " & _
                        "VerifiedDate = getdate() " & _
                        "WHERE VoucherNo = @VoucherNo")
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
                            .Add(New SqlParameter("@VoucherNo", New SqlString(CStr(detilRow.Rows(iRecCount)("VoucherNo")))))
                            .Add(New SqlParameter("@IsVerified", New SqlBoolean(CBool(detilRow.Rows(iRecCount)("chkIsVerification")))))
                            .Add(New SqlParameter("@UserVerified", _UserVerified))
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

        Public Function DeleteAllByVoucherNo() As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim da As SqlDataAdapter
            Dim trans As SqlTransaction
            Dim retVal As Boolean


            Dim strSQLUpdateDT As New Text.StringBuilder
            With strSQLUpdateDT
                .Append("UPDATE PurchaseOrderHd " & _
                        "SET VoucherNo = '' " & _
                        "WHERE VoucherNo = @VoucherNo " & _
                        "Update DebitCreditNote " & _
                        "SET VoucherNo = '', " & _
                        "IsProcess = 0, " & _
                        "UserProcess = @UserProcess, " & _
                        "ProcessDate = getdate() " & _
                        "WHERE VoucherNo = @VoucherNo " & _
                        "Update PurchaseUnitHd " & _
                        "SET VoucherNo = '' " & _
                        "WHERE VoucherNo = @VoucherNo " & _
                        "Update APInvoice " & _
                        "SET UserDelete = @UserDelete, " & _
                        "isdeleted = 1, " & _
                        "DeleteDate = getdate() " & _
                        "WHERE VoucherNo = @VoucherNo ")
            End With

            conn.Open()

            Try
                trans = conn.BeginTransaction

                Dim cmdUpdateDT As New SqlCommand
                With cmdUpdateDT
                    .CommandText = strSQLUpdateDT.ToString
                    .CommandType = CommandType.Text
                    .Connection = conn
                    .Transaction = trans
                End With
                With cmdUpdateDT.Parameters
                    .Add(New SqlParameter("@VoucherNo", _VoucherNo))
                    .Add(New SqlParameter("@UserDelete", _UserDelete))
                    .Add(New SqlParameter("@UserProcess", _UserDelete))
                End With
                cmdUpdateDT.ExecuteNonQuery()

                trans.Commit()
                retVal = True
            Catch ex As Exception
                trans.Rollback()
                ' // do not throw an exception, just return ..!!
                ExceptionManager.Publish(ex)
            Finally
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

        Public Function SelectForViewGridAPVerified() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT " & _
                                       "appay.VoucherNo, appay.VoucherDate, appay.DueDate, " & _
                                       "(appay.TotalPU + appay.TaxAmount + appay.BankAdmFee +  " & _
                                       "appay.DeliveryFee + appay.StampDutyFee - appay.CNAmount -  " & _
                                       "appay.DPAmt + appay.RoundingAmt) AS TotalAmtVoucher, " & _
                                       "isnull(pay.PaidAmount,0) AS PaidAmount, " & _
                                       "isnull(pay.nAPPayment,0) + 1 AS nAPPayment, appay.CurrencyRate " & _
                                       "FROM " & _
                                       "( " & _
                                         "SELECT ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate, " & _
                                         "ie.Currency,ie.CurrencyRate, " & _
                                         "sum((pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt)) AS TotalPU, " & _
                                         "sum((ie.IsPPN * ie.PPNPct * (pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt) / 100)) AS TaxAmount, " & _
                                         "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt " & _
                                         "FROM APInvoice ie " & _
                                         "INNER JOIN PurchaseUnitHd puh ON puh.VoucherNo = ie.VoucherNo AND puh.EntitiesSeqNo = ie.EntitiesSeqNo AND puh.Currency = ie.Currency " & _
                                         "INNER JOIN " & _
                                         "( " & _
                                          "SELECT dt.PUnitNO,(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail " & _
                                          "FROM PurchaseUnitDt dt " & _
                                          "WHERE dt.IsDeleted = 0 " & _
                                         ") pudt ON pudt.PUnitNO = puh.PUnitNO " & _
                                         "WHERE Ie.IsVerified = 1 and ie.EntitiesSeqNo = @EntitiesSeqNo AND ie.Currency = @Currency " & _
                                         "GROUP BY ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate,ie.Currency,ie.CurrencyRate, " & _
                                         "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt " & _
                                        ") appay " & _
                                        "LEFT JOIN  " & _
                                        "( " & _
                                         "SELECT ad.VoucherNo, sum(ad.Amount) AS PaidAmount,count(ad.VoucherNo) AS nAPPayment " & _
                                         "FROM APPaymentHd ah " & _
                                         "INNER JOIN APPaymentDt ad ON ad.APPaymentNo = ah.APPaymentNo " & _
                                         "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0 " & _
                                         "GROUP BY ad.VoucherNo " & _
                                        ") pay ON pay.VoucherNo = appay.VoucherNo " & _
                                        "WHERE isnull(pay.PaidAmount,0) < (appay.TotalPU + appay.TaxAmount + appay.BankAdmFee + " & _
                                        "appay.DeliveryFee + appay.StampDutyFee - appay.CNAmount - " & _
                                        "appay.DPAmt + appay.RoundingAmt) " & _
                                        "ORDER BY appay.DueDate "

            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("APInvoice")
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

        Public Function SelectAllForEntitiesSeqNoAPPayment(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT DISTINCT Top " + MaxRecord + " appay.EntitiesSeqNo, " & _
                                       "isnull(E.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(E.EntitiesName,'') as EntitiesName " & _
                                       "FROM " & _
                                       "( " & _
                                            "SELECT ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate, " & _
                                            "ie.Currency,ie.CurrencyRate, " & _
                                            "sum((pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt)) AS TotalPU, " & _
                                            "sum((ie.IsPPN * ie.PPNPct * (pudt.TotalDetail + (puh.IsPPN * puh.PPNPct * (pudt.TotalDetail - puh.DiscFinalAmt) /100) - puh.DiscFinalAmt) / 100)) AS TaxAmount, " & _
                                            "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt " & _
                                            "FROM APInvoice ie " & _
                                            "INNER JOIN PurchaseUnitHd puh ON puh.VoucherNo = ie.VoucherNo AND puh.EntitiesSeqNo = ie.EntitiesSeqNo AND puh.Currency = ie.Currency " & _
                                            "INNER JOIN " & _
                                            "( " & _
                                                "SELECT dt.PUnitNO,(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail  " & _
                                                "FROM PurchaseUnitDt dt " & _
                                                "WHERE dt.IsDeleted = 0 " & _
                                            ") pudt ON pudt.PUnitNO = puh.PUnitNO " & _
                                            "WHERE Ie.IsVerified = 1 " & _
                                            "GROUP BY ie.VoucherNo,ie.VoucherDate,ie.EntitiesSeqNo,ie.DueDate,ie.Currency,ie.CurrencyRate, " & _
                                            "ie.BankAdmFee, ie.DeliveryFee, ie.StampDutyFee, ie.CNAmount, ie.DPAmt, ie.RoundingAmt " & _
                                        ") appay " & _
                                        "LEFT JOIN Entities e ON e.EntitiesSeqNo = appay.EntitiesSeqNo AND e.IsDeleted = 0 AND e.IsActive = 1 " & _
                                        "LEFT JOIN  " & _
                                        "( " & _
                                            "SELECT ad.VoucherNo, sum(ad.Amount) AS PaidAmount,count(ad.VoucherNo) AS nAPPayment " & _
                                            "FROM APPaymentHd ah " & _
                                            "INNER JOIN APPaymentDt ad ON ad.APPaymentNo = ah.APPaymentNo " & _
                                            "WHERE ad.IsDeleted = 0 AND ah.IsVoid = 0 " & _
                                            "GROUP BY ad.VoucherNo " & _
                                        ") pay ON pay.VoucherNo = appay.VoucherNo " & _
                                        "WHERE isnull(pay.PaidAmount,0) < (appay.TotalPU + appay.TaxAmount + appay.BankAdmFee + " & _
                                        "appay.DeliveryFee + appay.StampDutyFee - appay.CNAmount - " & _
                                        "appay.DPAmt + appay.RoundingAmt) " & _
                                        "and (E.EntitiesId LIKE '%" + Filter.Trim + "%' OR E.EntitiesName LIKE '%" + Filter.Trim + "%' OR appay.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("APInvoice")
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

#End Region

#Region " Class Property Declarations "
        Public Property [VoucherNo]() As String
            Get
                Return _VoucherNo
            End Get
            Set(ByVal Value As String)
                _VoucherNo = Value
            End Set
        End Property

        Public Property [VoucherDate]() As DateTime
            Get
                Return _VoucherDate
            End Get
            Set(ByVal Value As DateTime)
                _VoucherDate = Value
            End Set
        End Property

        Public Property [TaxDate]() As DateTime
            Get
                Return _TaxDate
            End Get
            Set(ByVal Value As DateTime)
                _TaxDate = Value
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

        Public Property [TaxInvoiceNo]() As String
            Get
                Return _TaxInvoiceNo
            End Get
            Set(ByVal Value As String)
                _TaxInvoiceNo = Value
            End Set
        End Property

        Public Property [InvoiceNo]() As String
            Get
                Return _InvoiceNo
            End Get
            Set(ByVal Value As String)
                _InvoiceNo = Value
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

        Public Property [IsPPN]() As Boolean
            Get
                Return _IsPPN
            End Get
            Set(ByVal Value As Boolean)
                _IsPPN = Value
            End Set
        End Property

        Public Property [PPNPct]() As Decimal
            Get
                Return _PPNPct
            End Get
            Set(ByVal Value As Decimal)
                _PPNPct = Value
            End Set
        End Property

        Public Property [BankAdmFee]() As Decimal
            Get
                Return _BankAdmFee
            End Get
            Set(ByVal Value As Decimal)
                _BankAdmFee = Value
            End Set
        End Property

        Public Property [DeliveryFee]() As Decimal
            Get
                Return _DeliveryFee
            End Get
            Set(ByVal Value As Decimal)
                _DeliveryFee = Value
            End Set
        End Property

        Public Property [StampDutyFee]() As Decimal
            Get
                Return _StampDutyFee
            End Get
            Set(ByVal Value As Decimal)
                _StampDutyFee = Value
            End Set
        End Property

        Public Property [CNAmount]() As Decimal
            Get
                Return _CNAmount
            End Get
            Set(ByVal Value As Decimal)
                _CNAmount = Value
            End Set
        End Property

        Public Property [DPAmt]() As Decimal
            Get
                Return _DPAmt
            End Get
            Set(ByVal Value As Decimal)
                _DPAmt = Value
            End Set
        End Property

        Public Property [RoundingAmt]() As Decimal
            Get
                Return _RoundingAmt
            End Get
            Set(ByVal Value As Decimal)
                _RoundingAmt = Value
            End Set
        End Property

        Public Property [IsVerified]() As Boolean
            Get
                Return _IsVerified
            End Get
            Set(ByVal Value As Boolean)
                _IsVerified = Value
            End Set
        End Property

        Public Property [UserVerified]() As String
            Get
                Return _UserVerified
            End Get
            Set(ByVal Value As String)
                _UserVerified = Value
            End Set
        End Property

        Public Property [VerifiedDate]() As DateTime
            Get
                Return _VerifiedDate
            End Get
            Set(ByVal Value As DateTime)
                _VerifiedDate = Value
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

        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
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