Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesReturnHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _SReturnNo, _STxnNo, _WhID, _UnitID, _EntitiesSeqNo, _SReturnDate, _PPNPct, _ReturnFeePct, _Description, _Currency, _SReturnReasonID As String
        Private _ReturnFeeAmt, _CurrencyRate As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval As String
        Private _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate As DateTime
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

            cmdToExecute.CommandText = "INSERT INTO SalesReturnHd " & _
                                        "(SReturnNo, STxnNo, WhID, UnitID, EntitiesSeqNo, SReturnDate, " & _
                                        "IsPPN, PPNPct, ReturnFeePct, ReturnFeeAmt, Currency, CurrencyRate, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, SReturnReasonID, " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@SReturnNo, @STxnNo, @WhID, @UnitID, @EntitiesSeqNo, @SReturnDate, " & _
                                        "@IsPPN, @PPNPct, @ReturnFeePct, @ReturnFeeAmt, @Currency, @CurrencyRate, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, left(@Description,500), @SReturnReasonID, " & _
                                        "0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@SReturnDate", _SReturnDate)

                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@SReturnReasonID", _SReturnReasonID)

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
            cmdToExecute.CommandText = "UPDATE SalesReturnHd " & _
                                        "SET STxnNo = @STxnNo, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "SReturnDate = @SReturnDate, " & _
                                        "IsPPN = @IsPPN, " & _
                                        "PPNPct = @PPNPct, " & _
                                        "ReturnFeePct = @ReturnFeePct, " & _
                                        "ReturnFeeAmt = @ReturnFeeAmt, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500), " & _
                                        "SReturnReasonID = left(@SReturnReasonID,500) " & _
                                        "WHERE SReturnNo = @SReturnNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@SReturnDate", _SReturnDate)

                cmdToExecute.Parameters.Add("@IsPPN", _IsPPN)
                cmdToExecute.Parameters.Add("@PPNPct", _PPNPct)
                cmdToExecute.Parameters.Add("@ReturnFeePct", _ReturnFeePct)
                cmdToExecute.Parameters.Add("@ReturnFeeAmt", _ReturnFeeAmt)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)

                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@SReturnReasonID", _SReturnReasonID)

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

            cmdToExecute.CommandText = "SELECT *,convert(varchar(10),SReturnDate,105) as formatdate FROM SalesReturnHd order by SReturnNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesReturnHd")
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

        Public Function SelectAllForSReturnNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.SReturnDate,105) as formatdate, " & _
                                       "case when hd.Isdeleted = 1 then 'Deleted' " & _
                                       "when hd.IsApproval = 1 then 'Approved' else '' end as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM SalesReturnHd hd " & _
                                       "Where IsDeleted = 0 and (SReturnNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),SReturnDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by SReturnNo Desc "

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesReturnHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturnHd WHERE SReturnNo = @SReturnNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturnHd WHERE SReturnNo > @SReturnNo ORDER BY SReturnNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesReturnHd WHERE SReturnNo < @SReturnNo ORDER BY SReturnNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesReturnHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SReturnNo", _SReturnNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _SReturnNo = CType(toReturn.Rows(0)("SReturnNo"), String)
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)

                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _SReturnReasonID = CType(toReturn.Rows(0)("SReturnReasonID"), String)

                    _PPNPct = CType(toReturn.Rows(0)("PPNPct"), Decimal)
                    _ReturnFeePct = CType(toReturn.Rows(0)("ReturnFeePct"), Decimal)
                    _ReturnFeeAmt = CType(toReturn.Rows(0)("ReturnFeeAmt"), Decimal)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)

                    _SReturnDate = CType(toReturn.Rows(0)("SReturnDate"), DateTime)

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

            cmdToExecute.CommandText = "Update SalesReturnHd " & _
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

#Region "Others Function "
  
#End Region

#Region " Class Property Declarations "
        Public Property [SReturnNo]() As String
            Get
                Return _SReturnNo
            End Get
            Set(ByVal Value As String)
                _SReturnNo = Value
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

        Public Property [SReturnReasonID]() As String
            Get
                Return _SReturnReasonID
            End Get
            Set(ByVal Value As String)
                _SReturnReasonID = Value
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

        Public Property [CurrencyRate]() As Decimal
            Get
                Return _CurrencyRate
            End Get
            Set(ByVal Value As Decimal)
                _CurrencyRate = Value
            End Set
        End Property

        Public Property [SReturnDate]() As DateTime
            Get
                Return _SReturnDate
            End Get
            Set(ByVal Value As DateTime)
                _SReturnDate = Value
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