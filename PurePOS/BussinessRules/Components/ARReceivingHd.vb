Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ARReceivingHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ARReceivingNo, _ARReceivingDate, _EntitiesSeqNo, _ARReceivingTypeID, _DocumentNo, _DocumentDate, _BankID, _BankAccountNo, _BankGiroNo, _BankGiroSerialNo, _BankGiroGroupNo, _Currency As String
        Private _CurrencyRate, _Amount As Decimal
        Private _UserInsert, _UserUpdate, _UserApproval, _ApprovalDate, _UpdateDate, _InsertDate, _UserVoid, _VoidDate As String
        Private _IsApproval, _IsVoid As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ARReceivingHd " & _
                                        "(ARReceivingNo, ARReceivingDate, EntitiesSeqNo, ARReceivingTypeID, DocumentNo, DocumentDate, BankID, BankAccountNo, BankGiroNo, BankGiroSerialNo, BankGiroGroupNo, Currency, CurrencyRate, " & _
                                        "Amount, UserInsert, InsertDate, UserUpdate, UpdateDate, " & _
                                        "IsApproval, UserApproval, ApprovalDate, IsVoid, UserVoid, VoidDate) " & _
                                        "VALUES (@ARReceivingNo, @ARReceivingDate, @EntitiesSeqNo, @ARReceivingTypeID, @DocumentNo, @DocumentDate, @BankID, @BankAccountNo,  @BankGiroNo, @BankGiroSerialNo, @BankGiroGroupNo, @Currency, @CurrencyRate, " & _
                                        "@Amount, @UserInsert, getdate(), @UserUpdate, getdate(), " & _
                                        "0, '', '', 0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
                cmdToExecute.Parameters.Add("@ARReceivingDate", _ARReceivingDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ARReceivingTypeID", _ARReceivingTypeID)
                cmdToExecute.Parameters.Add("@DocumentNo", _DocumentNo)
                cmdToExecute.Parameters.Add("@DocumentDate", _DocumentDate)
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@BankAccountNo", _BankAccountNo)
                cmdToExecute.Parameters.Add("@BankGiroNo", _BankGiroNo)
                cmdToExecute.Parameters.Add("@BankGiroSerialNo", _BankGiroSerialNo)
                cmdToExecute.Parameters.Add("@BankGiroGroupNo", _BankGiroGroupNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
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
            cmdToExecute.CommandText = "UPDATE ARReceivingHd " & _
                                        "SET ARReceivingDate = @ARReceivingDate, " & _
                                        "EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "ARReceivingTypeID = @ARReceivingTypeID, " & _
                                        "DocumentNo = @DocumentNo, " & _
                                        "DocumentDate = @DocumentDate, " & _
                                        "BankID = @BankID, " & _
                                        "BankAccountNo = @BankAccountNo, " & _
                                        "BankGiroNo = @BankGiroNo, " & _
                                        "BankGiroSerialNo = @BankGiroSerialNo, " & _
                                        "BankGiroGroupNo = @BankGiroGroupNo, " & _
                                        "Currency = @Currency, " & _
                                        "CurrencyRate = @CurrencyRate, " & _
                                        "Amount = @Amount, " & _
                                        "IsApproval = @IsApproval, " & _
                                        "UserApproval = CASE WHEN @IsApproval = 1 THEN @UserUpdate ELSE '' END, " & _
                                        "ApprovalDate = CASE WHEN @IsApproval = 1 THEN GETDATE() ELSE '' END, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = getdate() " & _
                                        "WHERE ARReceivingNo = @ARReceivingNo"

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
                cmdToExecute.Parameters.Add("@ARReceivingDate", _ARReceivingDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ARReceivingTypeID", _ARReceivingTypeID)
                cmdToExecute.Parameters.Add("@DocumentNo", _DocumentNo)
                cmdToExecute.Parameters.Add("@DocumentDate", _DocumentDate)
                cmdToExecute.Parameters.Add("@BankID", _BankID)
                cmdToExecute.Parameters.Add("@BankAccountNo", _BankAccountNo)
                cmdToExecute.Parameters.Add("@BankGiroNo", _BankGiroNo)
                cmdToExecute.Parameters.Add("@BankGiroSerialNo", _BankGiroSerialNo)
                cmdToExecute.Parameters.Add("@BankGiroGroupNo", _BankGiroGroupNo)
                cmdToExecute.Parameters.Add("@Currency", _Currency)
                cmdToExecute.Parameters.Add("@CurrencyRate", _CurrencyRate)
                cmdToExecute.Parameters.Add("@Amount", _Amount)
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

            cmdToExecute.CommandText = "SELECT * FROM ARReceivingHd order by ARReceivingNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ARReceivingHd")
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

        Public Function SelectAllForARReceivingNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*,convert(varchar(10),hd.ARReceivingDate,105) as formatdate, " & _
                                       "(Case When hd.IsVoid = 1 then 'Void' When hd.IsApproval = 1 then 'Approved' else '' end) as Status, " & _
                                       "(SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) AS EntitiesName " & _
                                       "FROM ARReceivingHd hd " & _
                                       "Where (hd.ARReceivingNo LIKE '%" + Filter.Trim + "%' OR convert(varchar(10),hd.ARReceivingDate,105) LIKE '%" + Filter.Trim + "%' OR (SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = hd.EntitiesSeqNo) LIKE '%" + Filter.Trim + "%') " & _
                                       "order by hd.ARReceivingNo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ARReceivingHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingHd WHERE ARReceivingNo = @ARReceivingNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingHd WHERE ARReceivingNo > @ARReceivingNo ORDER BY ARReceivingNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ARReceivingHd WHERE ARReceivingNo < @ARReceivingNo ORDER BY ARReceivingNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ARReceivingHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ARReceivingNo = CType(toReturn.Rows(0)("ARReceivingNo"), String)
                    _ARReceivingDate = CType(toReturn.Rows(0)("ARReceivingDate"), DateTime)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _DocumentNo = CType(toReturn.Rows(0)("DocumentNo"), String)
                    _DocumentDate = CType(toReturn.Rows(0)("DocumentDate"), String)
                    _ARReceivingTypeID = CType(toReturn.Rows(0)("ARReceivingTypeID"), String)
                    _BankID = CType(toReturn.Rows(0)("BankID"), String)
                    _BankAccountNo = CType(toReturn.Rows(0)("BankAccountNo"), String)
                    _BankGiroNo = CType(toReturn.Rows(0)("BankGiroNo"), String)
                    _BankGiroSerialNo = CType(toReturn.Rows(0)("BankGiroSerialNo"), String)
                    _BankGiroGroupNo = CType(toReturn.Rows(0)("BankGiroGroupNo"), String)
                    _Currency = CType(toReturn.Rows(0)("Currency"), String)
                    _CurrencyRate = CType(toReturn.Rows(0)("CurrencyRate"), Decimal)
                    _Amount = CType(toReturn.Rows(0)("Amount"), Decimal)
                    _IsApproval = CType(toReturn.Rows(0)("IsApproval"), Boolean)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _IsVoid = CType(toReturn.Rows(0)("IsVoid"), Boolean)
                    _UserVoid = CType(toReturn.Rows(0)("UserVoid"), String)
                    _VoidDate = CType(toReturn.Rows(0)("VoidDate"), DateTime)
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

            cmdToExecute.CommandText = "Update ARReceivingHd " & _
                                       "Set IsVoid = 1, " & _
                                       "UserVoid = @UserVoid, " & _
                                       "VoidDate = Getdate() " & _
                                       "WHERE ARReceivingNo = @ARReceivingNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ARReceivingNo", _ARReceivingNo)
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

#Region " Class Property Declarations "
        Public Property [ARReceivingNo]() As String
            Get
                Return _ARReceivingNo
            End Get
            Set(ByVal Value As String)
                _ARReceivingNo = Value
            End Set
        End Property

        Public Property [ARReceivingDate]() As DateTime
            Get
                Return _ARReceivingDate
            End Get
            Set(ByVal Value As DateTime)
                _ARReceivingDate = Value
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

        Public Property [ARReceivingTypeID]() As String
            Get
                Return _ARReceivingTypeID
            End Get
            Set(ByVal Value As String)
                _ARReceivingTypeID = Value
            End Set
        End Property

        Public Property [DocumentNo]() As String
            Get
                Return _DocumentNo
            End Get
            Set(ByVal Value As String)
                _DocumentNo = Value
            End Set
        End Property

        Public Property [DocumentDate]() As DateTime
            Get
                Return _DocumentDate
            End Get
            Set(ByVal Value As DateTime)
                _DocumentDate = Value
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

        Public Property [BankAccountNo]() As String
            Get
                Return _BankAccountNo
            End Get
            Set(ByVal Value As String)
                _BankAccountNo = Value
            End Set
        End Property

        Public Property [BankGiroNo]() As String
            Get
                Return _BankGiroNo
            End Get
            Set(ByVal Value As String)
                _BankGiroNo = Value
            End Set
        End Property

        Public Property [BankGiroSerialNo]() As String
            Get
                Return _BankGiroSerialNo
            End Get
            Set(ByVal Value As String)
                _BankGiroSerialNo = Value
            End Set
        End Property

        Public Property [BankGiroGroupNo]() As String
            Get
                Return _BankGiroGroupNo
            End Get
            Set(ByVal Value As String)
                _BankGiroGroupNo = Value
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

        Public Property [Amount]() As Decimal
            Get
                Return _Amount
            End Get
            Set(ByVal Value As Decimal)
                _Amount = Value
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

        Public Property [IsVoid]() As Boolean
            Get
                Return _IsVoid
            End Get
            Set(ByVal Value As Boolean)
                _IsVoid = Value
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

        Public Property [UserVoid]() As String
            Get
                Return _UserVoid
            End Get
            Set(ByVal Value As String)
                _UserVoid = Value
            End Set
        End Property

#End Region
    End Class
End Namespace