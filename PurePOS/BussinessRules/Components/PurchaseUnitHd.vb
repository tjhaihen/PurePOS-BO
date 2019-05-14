Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PurchaseUnitHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _PUnitNO, _WhID, _UnitID, _EntitiesSeqNo, _PPNPct, _DiscFinalPct, _VoucherNo, _InvoiceNo, _Description As String
        Private _DiscFinalAmt, _Currency, _CurrencyRate, _RevNo As String
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval, _UserRev As String
        Private _PUnitDate, _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate, _RevDate As String
        Private _IsPPN, _IsDeleted, _IsApproval As Boolean
        Private _APAnalysisNo As String
        Private _IsAnalyzed As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO PurchaseUnitHd " & _
                                        "(PUnitNO, WhID, UnitID, EntitiesSeqNo, PUnitDate, " & _
                                        "IsPPN, PPNPct, DiscFinalPct, DiscFinalAmt, Currency, CurrencyRate, VoucherNo, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, InvoiceNo, Description, " & _
                                        "IsApproval, UserApproval, ApprovalDate, RevNo, UserRev, RevDate) " & _
                                        "VALUES (@PUnitNO, @WhID, @UnitID, @EntitiesSeqNo, @PUnitDate, " & _
                                        "@IsPPN, @PPNPct, @DiscFinalPct, @DiscFinalAmt, @Currency, @CurrencyRate, '', " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, @InvoiceNo, left(@Description,500), " & _
                                        "0, '', '', 0, '', '' )"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@PUnitDate", _PUnitDate)

                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cmdToExecute.Parameters.Add("@InvoiceNo", _InvoiceNo)
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
            cmdToExecute.CommandText = "UPDATE PurchaseUnitHd " & _
                                        "SET PUnitNO = @PUnitNO, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "PUnitDate = @PUnitDate, " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "DiscFinalPct = @DiscFinalPct, " & _
                                        "DiscFinalAmt = @DiscFinalAmt, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "InvoiceNo = @InvoiceNo, " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE PUnitNO = @PUnitNO"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@PUnitDate", _PUnitDate)

                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@IsApproval", _IsApproval)

                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)

                cmdToExecute.Parameters.Add("@InvoiceNo", _InvoiceNo)
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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),PUnitDate,105) as formatdate FROM PurchaseUnitHd order by PUnitNO"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectAllForPUnitNO(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " *,convert(varchar(10),puhd.PUnitDate,105) as formatdate, " & _
                                       "case when puhd.Isdeleted = 1 then 'Deleted' " & _
                                       "when puhd.IsApproval = 1 then 'Approved' else '' end as Status, " & _
                                       "puhd.EntitiesSeqNo, (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo=puhd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM PurchaseUnitHd puhd " & _
                                       "Where puhd.IsDeleted = 0 and (puhd.PUnitNO LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),puhd.PUnitDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by puhd.PUnitNO Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitHd WHERE PUnitNO = @PUnitNO"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitHd WHERE PUnitNO > @PUnitNO ORDER BY PUnitNO ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseUnitHd WHERE PUnitNO < @PUnitNO ORDER BY PUnitNO DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _PUnitNO = CType(toReturn.Rows(0)("PUnitNO"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _InvoiceNo = CType(toReturn.Rows(0)("InvoiceNo"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _VoucherNo = CType(toReturn.Rows(0)("VoucherNo"), String)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _DiscFinalPct = CType(toReturn.Rows(0)("DiscFinalPct"), Decimal)
                    _DiscFinalAmt = CType(toReturn.Rows(0)("DiscFinalAmt"), Decimal)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)
                    _RevNo = CType(toReturn.Rows(0)("RevNo"), Decimal)

                    _PUnitDate = CType(toReturn.Rows(0)("PUnitDate"), DateTime)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _RevDate = CType(toReturn.Rows(0)("RevDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _UserRev = CType(toReturn.Rows(0)("UserRev"), String)

                    _IsPPN = CType(toReturn.Rows(0)("IsPPN"), Boolean)
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

            cmdToExecute.CommandText = "Update PurchaseUnitHd " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and PUnitNO = @PUnitNO "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
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

        Public Function DeleteVouvherNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update PurchaseUnitHd " & _
                                       "set VoucherNo = @VoucherNo " & _
                                       "WHERE IsDeleted = 0 and PUnitNO = @PUnitNO "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
                cmdToExecute.Parameters.Add("@VoucherNo", _VoucherNo)

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
        Public Function SelectAllForEntitiesSeqNoPurchaseReturn(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM PurchaseUnitHD hd " & _
                                       "inner join PurchaseUnitDt dt on Dt.PUnitNO = hd.PUnitNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "LEFT JOIN " & _
                                       "( " & _
                                            "SELECT prd.IDPU, sum(prd.Qty * prd.ItemFactor) AS QtyPURT " & _
                                            "FROM PurchaseReturnHd prh " & _
                                            "INNER JOIN PurchaseReturnDt prd ON prd.PReturnNO = prh.PReturnNO AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 and prh.isApproval = 0 " & _
                                            "GROUP BY prd.IDPU " & _
                                       ") purt ON purt.IDPU = dt.ID " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1  " & _
                                       "AND (dt.qty * dt.ItemFactor) > (isnull(purt.QtyPURT,0) + dt.QtyReturn) " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectAllForPUnitNOPReturn(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT distinct Top " + MaxRecord + " hd.PUnitNO,hd.PUnitDate,convert(varchar(10),hd.PUnitDate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status " & _
                                       "FROM PurchaseUnitHd hd " & _
                                       "inner join PurchaseUnitDt dt on Dt.PUnitNO = hd.PUnitNO " & _
                                       "Left join " & _
                                       "( " & _
                                            "SELECT prd.IDPU, sum(prd.Qty * prd.ItemFactor) AS QtyPURT " & _
                                            "FROM PurchaseReturnHd prh " & _
                                            "INNER JOIN PurchaseReturnDt prd ON prd.PReturnNO = prh.PReturnNO AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 and prh.isApproval = 0" & _
                                            "GROUP BY prd.IDPU " & _
                                       ") purt ON purt.IDPU = dt.ID " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and dt.isDeleted = 0 and hd.EntitiesSeqNo = @EntitiesSeqNo and hd.WhID = @WhID and hd.UnitID = @UnitID and hd.Currency = @Currency " & _
                                       "AND (dt.qty * dt.ItemFactor) > (isnull(purt.QtyPURT,0) + dt.QtyReturn) " & _
                                       "and (hd.PUnitNO LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.PUnitDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.PUnitNO Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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

        Public Function SelectAllForEntitiesSeqNoAPInvoice(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM PurchaseUnitHD hd " & _
                                       "inner join PurchaseUnitDt dt on Dt.PUnitNO = hd.PUnitNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 and hd.VoucherNo = '' " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectForViewGridPUAPInvoice() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT puh.PUnitNO,puh.PUnitDate,puh.CurrencyRate,puh.DiscFinalPct,puh.DiscFinalAmt, " & _
                                       "sum(pud.TotalDetail) as TotalDetail, " & _
                                       "sum((pud.TotalDetail - puh.DiscFinalAmt) * puh.IsPPN * puh.PPNPct / 100) AS PPNAmount " & _
                                       "FROM PurchaseUnitHd puh " & _
                                       "INNER Join " & _
                                       "( " & _
                                         "SELECT dt.PUnitNO,(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail " & _
                                         "FROM PurchaseUnitDt dt " & _
                                         "WHERE dt.IsDeleted = 0 " & _
                                       ") pud ON pud.PUnitNO = puh.PUnitNO " & _
                                       "WHERE puh.IsDeleted = 0 AND puh.IsApproval = 1 AND puh.VoucherNo <> '' AND puh.VoucherNo = @VoucherNo " & _
                                       "GROUP BY puh.PUnitNO,puh.PUnitDate,puh.CurrencyRate,puh.DiscFinalPct,puh.DiscFinalAmt "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectForViewGridGetPUAPInvoice() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT puh.PUnitNO,puh.PUnitDate,puh.CurrencyRate,puh.DiscFinalPct,puh.DiscFinalAmt, " & _
                                       "sum(pud.TotalDetail) as TotalDetail, " & _
                                       "sum((pud.TotalDetail - puh.DiscFinalAmt) * puh.IsPPN * puh.PPNPct / 100) AS PPNAmount " & _
                                       "FROM PurchaseUnitHd puh " & _
                                       "INNER Join " & _
                                       "( " & _
                                         "SELECT dt.PUnitNO,(dt.Qty * (dt.Price - dt.Disc1Amt - dt.Disc2Amt - dt.Disc3Amt)) AS TotalDetail " & _
                                         "FROM PurchaseUnitDt dt " & _
                                         "WHERE dt.IsDeleted = 0 " & _
                                       ") pud ON pud.PUnitNO = puh.PUnitNO " & _
                                       "WHERE puh.IsDeleted = 0 AND puh.IsApproval = 1 and puh.EntitiesSeqNo = @EntitiesSeqNo and puh.Currency = @Currency AND puh.VoucherNo = '' " & _
                                       "GROUP BY puh.PUnitNO,puh.PUnitDate,puh.CurrencyRate,puh.DiscFinalPct,puh.DiscFinalAmt "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function SelectForAPInquiry(ByVal sDate As DateTime, ByVal eDate As DateTime, ByVal EntitiesID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "usp_PurchaseUnitHd_SelectForAPInquiry"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@sDate", sDate)
                cmdToExecute.Parameters.Add("@eDate", eDate)
                cmdToExecute.Parameters.Add("@EntitiesID", EntitiesID)

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

        Public Function SelectForAPInquiryByAPAnalysisNo(ByVal APAnalysisNo As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "usp_PurchaseUnitHd_SelectForAPInquiryByAPAnalysisNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try                
                cmdToExecute.Parameters.Add("@APAnalysisNo", APAnalysisNo)

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
                .Append("UPDATE PurchaseUnitHd " & _
                        "SET VoucherNo = @VoucherNo " & _
                        "WHERE PUnitNO = @PUnitNO")
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
                            .Add(New SqlParameter("@PUnitNO", New SqlString(CStr(detilRow.Rows(iRecCount)("NomorID")))))
                            .Add(New SqlParameter("@VoucherNo", _VoucherNo))
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

        Public Function UpdateAPAnalysisNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE PurchaseUnitHd " & _
                                        "SET APAnalysisNO = @APAnalysisNO, " & _
                                        "IsAnalyzed = @IsAnalyzed, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE PUnitNO = @PUnitNO"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APAnalysisNO", _APAnalysisNO)
                cmdToExecute.Parameters.Add("@IsAnalyzed", _IsAnalyzed)
                cmdToExecute.Parameters.Add("@PUnitNO", _PUnitNO)
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

#End Region

#Region " Class Property Declarations "
        Public Property [PUnitNO]() As String
            Get
                Return _PUnitNO
            End Get
            Set(ByVal Value As String)
                _PUnitNO = Value
            End Set
        End Property

        Public Property [WhID]() As String
            Get
                Return _WhID
            End Get
            Set(ByVal Value As String)
                _WhID = Value
            End Set
        End Property

        Public Property [UnitID]() As String
            Get
                Return _UnitID
            End Get
            Set(ByVal Value As String)
                _UnitID = Value
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

        Public Property [Currency]() As String
            Get
                Return _Currency
            End Get
            Set(ByVal Value As String)
                _Currency = Value
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

        Public Property [VoucherNo]() As String
            Get
                Return _VoucherNo
            End Get
            Set(ByVal Value As String)
                _VoucherNo = Value
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

        Public Property [DiscFinalPct]() As Decimal
            Get
                Return _DiscFinalPct
            End Get
            Set(ByVal Value As Decimal)
                _DiscFinalPct = Value
            End Set
        End Property

        Public Property [DiscFinalAmt]() As Decimal
            Get
                Return _DiscFinalAmt
            End Get
            Set(ByVal Value As Decimal)
                _DiscFinalAmt = Value
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

        Public Property [RevNo]() As Decimal
            Get
                Return _RevNo
            End Get
            Set(ByVal Value As Decimal)
                _RevNo = Value
            End Set
        End Property

        Public Property [PUnitDate]() As DateTime
            Get
                Return _PUnitDate
            End Get
            Set(ByVal Value As DateTime)
                _PUnitDate = Value
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

        Public Property [DeleteDate]() As DateTime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As DateTime)
                _DeleteDate = Value
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

        Public Property [RevDate]() As DateTime
            Get
                Return _RevDate
            End Get
            Set(ByVal Value As DateTime)
                _RevDate = Value
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

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
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

        Public Property [UserRev]() As String
            Get
                Return _UserRev
            End Get
            Set(ByVal Value As String)
                _UserRev = Value
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

        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
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

        Public Property [APAnalysisNo]() As String
            Get
                Return _APAnalysisNo
            End Get
            Set(ByVal Value As String)
                _APAnalysisNo = Value
            End Set
        End Property

        Public Property [IsAnalyzed]() As Boolean
            Get
                Return _IsAnalyzed
            End Get
            Set(ByVal Value As Boolean)
                _IsAnalyzed = Value
            End Set
        End Property
#End Region
    End Class
End Namespace