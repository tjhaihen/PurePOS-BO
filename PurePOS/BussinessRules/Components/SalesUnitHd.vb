Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesUnitHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _STxnNo, _StxnTypeID, _WhID, _UnitID, _EntitiesSeqNo, _STxnDate, _BranchID, _PPNPct, _DiscFinalPct, _VoucherNo, _Description As String
        Private _DiscFinalAmt, _Currency, _CurrencyRate, _DONo As String
        Private _DeliveryFee As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval As String
        Private _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate As String
        Private _IsPPN, _IsDeleted, _IsApproval As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO SalesUnitHd " & _
                                        "(STxnNo, StxnTypeID, WhID, UnitID, EntitiesSeqNo, STxnDate, " & _
                                        "BranchID, IsPPN, PPNPct, DiscFinalPct, DiscFinalAmt, DeliveryFee, Currency, CurrencyRate, DONo, VoucherNo, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@STxnNo, @StxnTypeID, @WhID, @UnitID, @EntitiesSeqNo, @STxnDate, " & _
                                        "@BranchID, @IsPPN, @PPNPct, @DiscFinalPct, @DiscFinalAmt, @DeliveryFee, @Currency, @CurrencyRate, @DONo, '', " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, left(@Description,500), " & _
                                        "0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.Add("@StxnTypeID", _StxnTypeID)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@STxnDate", _STxnDate)

                cmdToExecute.Parameters.Add("@BranchID", _BranchID)

                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)

                cmdToExecute.Parameters.Add("@DONo", _DONo)

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
            cmdToExecute.CommandText = "UPDATE SalesUnitHd " & _
                                        "SET StxnTypeID = @StxnTypeID, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "STxnDate = @STxnDate, " & _
                                        "BranchID = @BranchID, " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "DiscFinalPct = @DiscFinalPct, " & _
                                        "DiscFinalAmt = @DiscFinalAmt, " & _
                                        "DeliveryFee = @DeliveryFee, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE STxnNo = @STxnNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.Add("@StxnTypeID", _StxnTypeID)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@STxnDate", _STxnDate)
                cmdToExecute.Parameters.Add("@BranchID", _BranchID)

                cmdToExecute.Parameters.Add("@IsApproval", _IsApproval)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),STxnDate,105) as formatdate FROM SalesUnitHd order by STxnNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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

        Public Function SelectAllForSTxnNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.STxnDate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM SalesUnitHd hd " & _
                                       "Where hd.IsDeleted = 0 AND (hd.STxnNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.STxnDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE  '%" + Filter.Trim + "%') " & _
                                       "order by hd.STxnNo DESC "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitHd WHERE STxnNo = @STxnNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitHd WHERE STxnNo > @STxnNo ORDER BY STxnNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitHd WHERE STxnNo < @STxnNo ORDER BY STxnNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)
                    _StxnTypeID = CType(toReturn.Rows(0)("StxnTypeID"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _BranchID = CType(toReturn.Rows(0)("BranchID"), String)

                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _VoucherNo = CType(toReturn.Rows(0)("VoucherNo"), String)
                    _DONo = CType(toReturn.Rows(0)("DONo"), String)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _DiscFinalPct = CType(toReturn.Rows(0)("DiscFinalPct"), Decimal)
                    _DiscFinalAmt = CType(toReturn.Rows(0)("DiscFinalAmt"), Decimal)
                    _DeliveryFee = CType(toReturn.Rows(0)("DeliveryFee"), Decimal)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)

                    _STxnDate = CType(toReturn.Rows(0)("STxnDate"), DateTime)

                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)


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

            cmdToExecute.CommandText = "Update SalesUnitHd " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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

            cmdToExecute.CommandText = "Update SalesUnitHd " & _
                                       "set VoucherNo = @VoucherNo " & _
                                       "WHERE IsDeleted = 0 and STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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
        Public Function SelectAllForEntitiesSeqNoSalesReturn(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM SalesUnitHd hd " & _
                                       "inner join SalesUnitdt dt on Dt.STxnNo = hd.STxnNo " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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

        Public Function SelectAllForSTxnNoSReturn(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.STxnDate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM SalesUnitHd hd " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 " & _
                                       "And (SELECT count(pud.STxnNo) " & _
                                       "FROM SalesUnitdt pud " & _
                                       "WHERE pud.STxnNo = hd.STxnNo AND pud.IsDeleted = 0 " & _
                                       "AND (pud.Qty * pud.ItemFactor) > (pud.QtyReturn + " & _
                                       "isnull((SELECT sum(srd.Qty * srd.ItemFactor) " & _
                                       "FROM SalesReturnHd srh " & _
                                       "INNER JOIN SalesReturnDt srd ON srd.SReturnNo = srh.SReturnNo " & _
                                       "WHERE srh.IsDeleted = 0 And srd.IsDeleted = 0 " & _
                                       "AND srh.STxnNo = hd.STxnNo " & _
                                       "),0)) " & _
                                       ") > 0 " & _
                                       "and (hd.STxnNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.STxnDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.STxnNo Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitHd")
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

        Public Function SelectForSalesUnitInquiry(ByVal strFieldName1 As String, ByVal strValue1 As String, _
                                                    ByVal strFieldName2 As String, ByVal strValue2 As String, _
                                                    ByVal strFieldName3 As String, ByVal strValue3 As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sp_SalesUnitInquiry"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("sp_SalesUnitInquiry")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@strFieldName1", strFieldName1)
                cmdToExecute.Parameters.Add("@strValue1", strValue1)
                'cmdToExecute.Parameters.Add("@strFieldName2", strFieldName2)
                'cmdToExecute.Parameters.Add("@strValue2", strValue2)
                'cmdToExecute.Parameters.Add("@strFieldName3", strFieldName3)
                'cmdToExecute.Parameters.Add("@strValue3", strValue3)

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
        Public Property [STxnNo]() As String
            Get
                Return _STxnNo
            End Get
            Set(ByVal Value As String)
                _STxnNo = Value
            End Set
        End Property

        Public Property [StxnTypeID]() As String
            Get
                Return _StxnTypeID
            End Get
            Set(ByVal Value As String)
                _StxnTypeID = Value
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

        Public Property [BranchID]() As String
            Get
                Return _BranchID
            End Get
            Set(ByVal Value As String)
                _BranchID = Value
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

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property

        Public Property [DONo]() As String
            Get
                Return _DONo
            End Get
            Set(ByVal Value As String)
                _DONo = Value
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

        Public Property [DeliveryFee]() As Decimal
            Get
                Return _DeliveryFee
            End Get
            Set(ByVal Value As Decimal)
                _DeliveryFee = Value
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

        Public Property [STxnDate]() As DateTime
            Get
                Return _STxnDate
            End Get
            Set(ByVal Value As DateTime)
                _STxnDate = Value
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
#End Region
    End Class
End Namespace