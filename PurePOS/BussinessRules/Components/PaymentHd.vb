Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PaymentHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _ReceiptNo As String
        Private _STxnNo As String
        Private _ReceiptDate As DateTime
        Private _Rounding As Decimal
        Private _UserInsert As String
        Private _InsertDate As DateTime
        Private _UserUpdate As String
        Private _UpdateDate As DateTime
        Private _IsVoid As Boolean
        Private _UserVoid As String
        Private _VoidDate As DateTime
        Private _Description As String

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Custom Function"
        Public Function UpdatePrintCounts() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "Update PaymentHd " & _
                                       "Set PrintCounts = PrintCounts + 1, " & _
                                       "UserUpdate = @UserUpdate, " & _
                                       "UpdateDate = getdate() " & _
                                       "Where ReceiptNo = @ReceiptNo "

            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReceiptNo", _ReceiptNo)
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

        Public Property [ReceiptNo]() As String
            Get
                Return _ReceiptNo
            End Get
            Set(ByVal Value As String)
                _ReceiptNo = Value
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

        Public Property [ReceiptDate]() As DateTime
            Get
                Return _ReceiptDate
            End Get
            Set(ByVal Value As DateTime)
                _ReceiptDate = Value
            End Set
        End Property

        Public Property [Rounding]() As Decimal
            Get
                Return _Rounding
            End Get
            Set(ByVal Value As Decimal)
                _Rounding = Value
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

        Public Property [Description]() As String
            Get
                Return _Description
            End Get
            Set(ByVal Value As String)
                _Description = Value
            End Set
        End Property


#End Region

    End Class
End Namespace
