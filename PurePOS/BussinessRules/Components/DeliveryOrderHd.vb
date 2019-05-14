Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DeliveryOrderHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _DONo, _WhID, _UnitID, _EntitiesSeqNo, _BranchID, _Currency, _Description, _DeliveryAddress, _PrimaryPhoneNo, _DeliveryZoneID As String
        Private _PPNPct, _DiscFinalPct, _DiscFinalAmt, _CurrencyRate, _DeliveryFee As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval, _UserPrinted As String
        Private _DODate, _DueDate, _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate, _PrintedDate As DateTime
        Private _IsPPN, _IsDeleted, _IsApproval, _IsPrinted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Overrides Function "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO DeliveryOrderHd " & _
                                        "(DONo, WhID, UnitID, EntitiesSeqNo, DODate, DueDate, BranchID, " & _
                                        "IsPPN, PPNPct, DiscFinalPct, DiscFinalAmt, Currency, CurrencyRate, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, " & _
                                        "DeliveryZoneID, DeliveryFee, " & _
                                        "DeliveryAddress, PrimaryPhoneNo, " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@DONo, @WhID, @UnitID, @EntitiesSeqNo, @DODate, @DueDate, @BranchID, " & _
                                        "@IsPPN, @PPNPct, @DiscFinalPct, @DiscFinalAmt, @Currency, @CurrencyRate, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, left(@Description,500), " & _
                                        "@DeliveryZoneID, @DeliveryFee, " & _
                                        "@DeliveryAddress, @PrimaryPhoneNo, " & _
                                        "0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DODate", _DODate)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@BranchID", _BranchID)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@DeliveryAddress", _DeliveryAddress)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)

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
            cmdToExecute.CommandText = "UPDATE DeliveryOrderHd " & _
                                        "SET WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "DODate = @DODate, " & _
                                        "DueDate = @DueDate, " & _
                                        "BranchID = @BranchID, " & _
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
                                        "Description = left(@Description,500), " & _
                                        "DeliveryZoneID = @DeliveryZoneID, " & _
                                        "DeliveryFee = @DeliveryFee, " & _
                                        "DeliveryAddress = @DeliveryAddress, " & _
                                        "PrimaryPhoneNo = @PrimaryPhoneNo " & _
                                        "WHERE DONo = @DONo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@DODate", _DODate)
                cmdToExecute.Parameters.Add("@DueDate", _DueDate)
                cmdToExecute.Parameters.Add("@BranchID", _BranchID)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@DiscFinalPct", _DiscFinalPct)
                cmdToExecute.Parameters.Add("@DiscFinalAmt", _DiscFinalAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@IsApproval", _IsApproval)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@DeliveryAddress", _DeliveryAddress)
                cmdToExecute.Parameters.Add("@PrimaryPhoneNo", _PrimaryPhoneNo)

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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),DODate,105) as formatdate FROM DeliveryOrderHd order by DONo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderHd WHERE DONo = @DONo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderHd WHERE DONo > @DONo ORDER BY DONo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderHd WHERE DONo < @DONo ORDER BY DONo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("DeliveryOrderHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DONo = CType(toReturn.Rows(0)("DONo"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _BranchID = CType(toReturn.Rows(0)("BranchID"), String)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _DiscFinalPct = CType(toReturn.Rows(0)("DiscFinalPct"), Decimal)
                    _DiscFinalAmt = CType(toReturn.Rows(0)("DiscFinalAmt"), Decimal)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)

                    _DODate = CType(toReturn.Rows(0)("DODate"), DateTime)
                    _DueDate = CType(toReturn.Rows(0)("DueDate"), DateTime)
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

                    _DeliveryZoneID = CType(toReturn.Rows(0)("DeliveryZoneID"), String)
                    _DeliveryFee = CType(toReturn.Rows(0)("DeliveryFee"), Decimal)
                    _DeliveryAddress = CType(toReturn.Rows(0)("DeliveryAddress"), String)
                    _PrimaryPhoneNo = CType(toReturn.Rows(0)("PrimaryPhoneNo"), String)

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

            cmdToExecute.CommandText = "Update DeliveryOrderHd " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and DONo = @DONo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONo)
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
#End Region

#Region "Others Function"
        Public Function SelectAllForDONo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.DODate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM DeliveryOrderHd hd " & _
                                       "Where hd.IsDeleted = 0 and (hd.DONo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.DODate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.DONo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderHd")
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

        Public Function SelectAllForDONoSaleUnit(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT distinct Top " + MaxRecord + " hd.DONO, convert(varchar(10),hd.DODate,105) as formatdate, " & _
                                       "convert(varchar(10),hd.DueDate,105) as FormatedDueDate, " & _
                                       "DATEDIFF(DAY,hd.DueDate,CAST(CONVERT(VARCHAR,GETDATE(),112) AS DATE)) AS OverDueInDay, " & _
                                       "hd.EntitiesSeqNo, (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM DeliveryOrderHd hd " & _
                                       "inner join DeliveryOrderdt dt on hd.DONO = dt.DONO " & _
                                       "Left Join " & _
                                       "(" & _
                                         "SELECT sud.IDDO,sum(sud.Qty * sud.ItemFactor) AS QtySU " & _
                                         "FROM SalesUnitHd suh " & _
                                         "INNER JOIN SalesUnitDt sud ON sud.STxnNo = suh.STxnNo " & _
                                         "WHERE suh.IsDeleted = 0 AND sud.IsDeleted = 0 " & _
                                         "GROUP BY sud.IDDO " & _
                                       ") su ON su.IDDO = dt.ID " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 " & _
                                       "and  dt.IsDeleted = 0 and dt.IsRelease = 0 " & _
                                       "AND (dt.Qty * dt.ItemFactor) - dt.QtySale - isnull(su.QtySU,0) > 0 " & _
                                       "and (hd.DONo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.DODate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.DONo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderHd")
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

        Public Function SelectAllForEntitiesSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct Top " + MaxRecord + " hd.EntitiesSeqNo, " & _
                                       "isnull(En.EntitiesId,'') as EntitiesId, " & _
                                       "isnull(En.EntitiesName,'') as EntitiesName " & _
                                       "FROM DeliveryOrderHd hd " & _
                                       "inner join DeliveryOrderDt dt on Dt.DONo = hd.DONo and dt.IsRelease = 0 " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and dt.IsDeleted = 0 and En.IsDeleted = 0 and En.IsActive = 1 " & _
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

        Public Function SelectAllForCurrency() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Distinct hd.Currency, " & _
                                       "isnull(cs.DetailDesc,'') as CurrencyName " & _
                                       "FROM DeliveryOrderHd hd " & _
                                       "inner join DeliveryOrderDt dt on Dt.DONo = hd.DONo and dt.IsRelease = 0 " & _
                                       "LEFT join (select * from CommonSetting WHERE GroupID = 'Currency') cs on cs.DetailID = hd.Currency " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and dt.IsDeleted = 0 and cs.IsDeleted = 0 and cs.IsActive = 1 " & _
                                       "and hd.EntitiesSeqNo = @EntitiesSeqNo "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseUnitHd")
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

        Public Function UpdatePrint() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE DeliveryOrderHd " & _
                                        "SET IsPrinted = 1, " & _
                                        "UserPrinted = @UserPrinted, " & _
                                        "PrintedDate = GetDate() " & _
                                        "WHERE DONo = @DONo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONo)
                cmdToExecute.Parameters.Add("@UserPrinted", _UserPrinted)

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
        Public Property [DONo]() As String
            Get
                Return _DONo
            End Get
            Set(ByVal Value As String)
                _DONo = Value
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

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
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

        Public Property [DODate]() As DateTime
            Get
                Return _DODate
            End Get
            Set(ByVal Value As DateTime)
                _DODate = Value
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

        Public Property [DeliveryZoneID]() As String
            Get
                Return _DeliveryZoneID
            End Get
            Set(ByVal Value As String)
                _DeliveryZoneID = Value
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

        Public Property [DeliveryAddress]() As String
            Get
                Return _DeliveryAddress
            End Get
            Set(ByVal Value As String)
                _DeliveryAddress = Value
            End Set
        End Property

        Public Property [PrimaryPhoneNo]() As String
            Get
                Return _PrimaryPhoneNo
            End Get
            Set(ByVal Value As String)
                _PrimaryPhoneNo = Value
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

        Public Property [PrintedDate]() As DateTime
            Get
                Return _PrintedDate
            End Get
            Set(ByVal Value As DateTime)
                _PrintedDate = Value
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

        Public Property [UserPrinted]() As String
            Get
                Return _UserPrinted
            End Get
            Set(ByVal Value As String)
                _UserPrinted = Value
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

        Public Property [IsPrinted]() As Boolean
            Get
                Return _IsPrinted
            End Get
            Set(ByVal Value As Boolean)
                _IsPrinted = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
