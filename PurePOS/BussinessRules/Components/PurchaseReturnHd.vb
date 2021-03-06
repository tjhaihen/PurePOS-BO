Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PurchaseReturnHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _PReturnNO, _PReturnDate, _EntitiesSeqNo, _WhID, _UnitID, _Description, _Currency, _PReturnReasonID As String
        Private _PPNPct, _CurrencyRate, _ReturnFeePct, _ReturnFeeAmt As Decimal
        Private _UserInsert, _UserUpdate, _UserApproval, _ApprovalDate, _UpdateDate, _InsertDate, _UserDelete, _DeleteDate As String
        Private _IsApproval, _IsDeleted, _IsPPN As Boolean
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

            cmdToExecute.CommandText = "INSERT INTO PurchaseReturnHd " & _
                                        "(PReturnNO, PReturnDate, EntitiesSeqNo, WhID, UnitID, IsPPN, PPNPct, ReturnFeePct, ReturnFeeAmt, " & _
                                        "Currency, CurrencyRate, PReturnReasonID, Description, UserInsert, InsertDate, UserUpdate, UpdateDate, " & _
                                        "IsApproval, UserApproval, ApprovalDate, IsDeleted, UserDelete, DeleteDate) " & _
                                        "VALUES (@PReturnNO, @PReturnDate, @EntitiesSeqNo, @WhID, @UnitID, @IsPPN, @PPNPct, @ReturnFeePct, @ReturnFeeAmt, " & _
                                        "@Currency, @CurrencyRate, @PReturnReasonID, left(@Description,500), @UserInsert, getdate(), @UserUpdate, getdate(), " & _
                                        "0, '', '', 0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReturnNO", _PReturnNO)
                cmdToExecute.Parameters.Add("@PReturnDate", _PReturnDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@PReturnReasonID", _PReturnReasonID)
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
            cmdToExecute.CommandText = "UPDATE PurchaseReturnHd " & _
                                        "SET PReturnDate = @PReturnDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "ReturnFeePct = @ReturnFeePct, " & _
                                        "ReturnFeeAmt = @ReturnFeeAmt, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "PReturnReasonID = @PReturnReasonID, " & _
                                        "Description = left(@Description,500), " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = getdate() " & _
                                        "WHERE PReturnNO = @PReturnNO"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReturnNO", _PReturnNO)
                cmdToExecute.Parameters.Add("@PReturnDate", _PReturnDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@PReturnReasonID", _PReturnReasonID)
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

            cmdToExecute.CommandText = "SELECT * FROM PurchaseReturnHd order by PReturnNO"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseReturnHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseReturnHd WHERE PReturnNO = @PReturnNO"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseReturnHd WHERE PReturnNO > @PReturnNO ORDER BY PReturnNO ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseReturnHd WHERE PReturnNO < @PReturnNO ORDER BY PReturnNO DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PurchaseReturnHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReturnNO", _PReturnNO)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _PReturnNO = CType(toReturn.Rows(0)("PReturnNO"), String)
                    _PReturnDate = CType(toReturn.Rows(0)("PReturnDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)

                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)

                    _IsPPN = CType(toReturn.Rows(0)("IsPPN"), Boolean)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), String)
                    _ReturnFeePct = CType(toReturn.Rows(0)("ReturnFeePct"), Decimal)
                    _ReturnFeeAmt = CType(toReturn.Rows(0)("ReturnFeeAmt"), Decimal)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)
                    _PReturnReasonID = CType(toReturn.Rows(0)("PReturnReasonID"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
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

            cmdToExecute.CommandText = "Update PurchaseReturnHd " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE PReturnNO = @PReturnNO"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReturnNO", _PReturnNO)
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

#Region " Custom Functions "
        Public Function SelectAllForPReturnNO(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " phd.*,convert(varchar(10),phd.PReturnDate,105) as formatdate, " & _
                                       "(Case When phd.IsApproval = 1 then 'Approved' else '' end) as Status, " & _
                                       "phd.EntitiesSeqNo, (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo=phd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM PurchaseReturnHd phd " & _
                                       "Where phd.IsDeleted = 0 and (phd.PReturnNO LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),phd.PReturnDate,105) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by phd.PReturnNO desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseReturnHd")
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
                                       "FROM PurchaseUnitHd hd " & _
                                       "inner join PurchaseUnitDt dt on Dt.PUnitNO = hd.PUnitNO " & _
                                       "inner join Entities En on En.EntitiesSeqNo = hd.EntitiesSeqNo " & _
                                       "Where hd.IsDeleted = 0 and hd.IsApproval = 1 and dt.IsDeleted = 0 and En.IsDeleted = 0 and En.IsActive = 1 " & _
                                       "and (En.EntitiesId LIKE '%" + Filter.Trim + "%' OR En.EntitiesName LIKE '%" + Filter.Trim + "%' OR En.EntitiesSeqNo LIKE '%" + Filter.Trim + "%') " & _
                                       "ORDER BY hd.EntitiesSeqNo "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EntitiesForPurchaseReturnHd")
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

        Public Function SelectForAPInquiry(ByVal sDate As DateTime, ByVal eDate As DateTime, ByVal EntitiesID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "usp_PurchaseReturnHd_SelectForAPInquiry"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("PurchaseReturnHd")
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

            cmdToExecute.CommandText = "usp_PurchaseReturnHd_SelectForAPInquiryByAPAnalysisNo"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("PurchaseReturnHd")
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

        Public Function UpdateAPAnalysisNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE PurchaseReturnHd " & _
                                        "SET APAnalysisNO = @APAnalysisNO, " & _
                                        "IsAnalyzed = @IsAnalyzed, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE PReturnNO = @PReturnNO"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@APAnalysisNO", _APAnalysisNO)
                cmdToExecute.Parameters.Add("@IsAnalyzed", _IsAnalyzed)
                cmdToExecute.Parameters.Add("@PReturnNO", _PReturnNO)
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
        Public Property [PReturnNO]() As String
            Get
                Return _PReturnNO
            End Get
            Set(ByVal Value As String)
                _PReturnNO = Value
            End Set
        End Property

        Public Property [PReturnDate]() As DateTime
            Get
                Return _PReturnDate
            End Get
            Set(ByVal Value As DateTime)
                _PReturnDate = Value
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

        Public Property [PReturnReasonID]() As String
            Get
                Return _PReturnReasonID
            End Get
            Set(ByVal Value As String)
                _PReturnReasonID = Value
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

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
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