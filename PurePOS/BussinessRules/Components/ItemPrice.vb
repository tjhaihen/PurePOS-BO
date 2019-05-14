Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ItemPrice
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSeqNo As String
        Private _StartingDate, _UpdateDate As DateTime
        Private _SuggestedRetailPriceSUnit, _SuggestedRetailPriceLUnit As Decimal
        Private _SalesPriceSUnit, _SalesPriceLUnit As Decimal
        Private _OfficeSalesPriceSUnit, _OfficeSalesPriceLUnit As Decimal
        Private _MarginPct As Decimal
        Private _UserUpdate As String
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

            cmdToExecute.CommandText = "INSERT INTO ItemPrice " & _
                                        "(ItemSeqNo, StartingDate, SuggestedRetailPriceSUnit, SuggestedRetailPriceLUnit, " & _
                                        "SalesPriceSUnit, SalesPriceLUnit, OfficeSalesPriceSUnit, OfficeSalesPriceLUnit, MarginPct, " & _
                                        "UserUpdate, UpdateDate) " & _
                                        "VALUES (@ItemSeqNo, @StartingDate, @SuggestedRetailPriceSUnit, @SuggestedRetailPriceLUnit, " & _
                                        "@SalesPriceSUnit, @SalesPriceLUnit, @OfficeSalesPriceSUnit, @OfficeSalesPriceLUnit, @MarginPct, " & _
                                        "@UserUpdate, GetDate()) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)
                cmdToExecute.Parameters.Add("@SuggestedRetailPriceSUnit", _SuggestedRetailPriceSUnit)
                cmdToExecute.Parameters.Add("@SuggestedRetailPriceLUnit", _SuggestedRetailPriceLUnit)
                cmdToExecute.Parameters.Add("@SalesPriceSUnit", _SalesPriceSUnit)
                cmdToExecute.Parameters.Add("@SalesPriceLUnit", _SalesPriceLUnit)
                cmdToExecute.Parameters.Add("@OfficeSalesPriceSUnit", _OfficeSalesPriceSUnit)
                cmdToExecute.Parameters.Add("@OfficeSalesPriceLUnit", _OfficeSalesPriceLUnit)
                cmdToExecute.Parameters.Add("@MarginPct", _MarginPct)
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

            cmdToExecute.CommandText = "UPDATE ItemPrice " & _
                                        "SET SuggestedRetailPriceSUnit = @SuggestedRetailPriceSUnit, " & _
                                        "SuggestedRetailPriceLUnit = @SuggestedRetailPriceLUnit, " & _
                                        "SalesPriceSUnit = @SalesPriceSUnit, " & _
                                        "SalesPriceLUnit = @SalesPriceLUnit, " & _
                                        "OfficeSalesPriceSUnit = @OfficeSalesPriceSUnit, " & _
                                        "OfficeSalesPriceLUnit = @OfficeSalesPriceLUnit, " & _
                                        "MarginPct = @MarginPct, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "AND StartingDate = @StartingDate"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)
                cmdToExecute.Parameters.Add("@SuggestedRetailPriceSUnit", _SuggestedRetailPriceSUnit)
                cmdToExecute.Parameters.Add("@SuggestedRetailPriceLUnit", _SuggestedRetailPriceLUnit)
                cmdToExecute.Parameters.Add("@SalesPriceSUnit", _SalesPriceSUnit)
                cmdToExecute.Parameters.Add("@SalesPriceLUnit", _SalesPriceLUnit)
                cmdToExecute.Parameters.Add("@OfficeSalesPriceSUnit", _OfficeSalesPriceSUnit)
                cmdToExecute.Parameters.Add("@OfficeSalesPriceLUnit", _OfficeSalesPriceLUnit)
                cmdToExecute.Parameters.Add("@MarginPct", _MarginPct)
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

            cmdToExecute.CommandText = "SELECT * FROM ItemPrice"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemPrice")
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
                    cmdToExecute.CommandText = "SELECT * FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo AND StartingDate = @StartingDate"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo AND StartingDate > @StartingDate ORDER BY ItemSeqNo, StartingDate ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo AND StartingDate < @StartingDate ORDER BY ItemSeqNo, StartingDate DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ItemPrice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _StartingDate = CType(toReturn.Rows(0)("StartingDate"), DateTime)
                    _SuggestedRetailPriceSUnit = CType(toReturn.Rows(0)("SuggestedRetailPriceSUnit"), Decimal)
                    _SuggestedRetailPriceLUnit = CType(toReturn.Rows(0)("SuggestedRetailPriceLUnit"), Decimal)
                    _SalesPriceSUnit = CType(toReturn.Rows(0)("SalesPriceSUnit"), Decimal)
                    _SalesPriceLUnit = CType(toReturn.Rows(0)("SalesPriceLUnit"), Decimal)
                    _OfficeSalesPriceSUnit = CType(toReturn.Rows(0)("OfficeSalesPriceSUnit"), Decimal)
                    _OfficeSalesPriceLUnit = CType(toReturn.Rows(0)("OfficeSalesPriceLUnit"), Decimal)
                    _MarginPct = CType(toReturn.Rows(0)("MarginPct"), Decimal)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

            cmdToExecute.CommandText = "DELETE FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)

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

#Region " Others Function "
        Public Function SelectOneByStartingDate(ByVal IsShowCurrentItemPrice As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            If IsShowCurrentItemPrice = True Then
                cmdToExecute.CommandText = "SELECT TOP 1 * FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo AND StartingDate <= @StartingDate " & _
                                                        "ORDER BY StartingDate DESC"
            Else
                '// Last Item Price by ItemSeqNo
                cmdToExecute.CommandText = "SELECT TOP 1 * FROM ItemPrice WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "ORDER BY StartingDate DESC"
            End If
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ItemPrice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _StartingDate = CType(toReturn.Rows(0)("StartingDate"), DateTime)
                    _SuggestedRetailPriceSUnit = CType(toReturn.Rows(0)("SuggestedRetailPriceSUnit"), Decimal)
                    _SuggestedRetailPriceLUnit = CType(toReturn.Rows(0)("SuggestedRetailPriceLUnit"), Decimal)
                    _SalesPriceSUnit = CType(toReturn.Rows(0)("SalesPriceSUnit"), Decimal)
                    _SalesPriceLUnit = CType(toReturn.Rows(0)("SalesPriceLUnit"), Decimal)
                    _OfficeSalesPriceSUnit = CType(toReturn.Rows(0)("OfficeSalesPriceSUnit"), Decimal)
                    _OfficeSalesPriceLUnit = CType(toReturn.Rows(0)("OfficeSalesPriceLUnit"), Decimal)
                    _MarginPct = CType(toReturn.Rows(0)("MarginPct"), Decimal)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

        Public Function SelectLastNItemPrice(ByVal n As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT TOP " & n.Trim & " * FROM ItemPrice " & _
                                        "WHERE ItemSeqNo = @ItemSeqNo " & _
                                        "ORDER BY StartingDate DESC"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ItemPrice")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

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
#End Region

#Region " Class Property Declarations "
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [StartingDate]() As DateTime
            Get
                Return _StartingDate
            End Get
            Set(ByVal Value As DateTime)
                _StartingDate = Value
            End Set
        End Property

        Public Property [SuggestedRetailPriceSUnit]() As Decimal
            Get
                Return _SuggestedRetailPriceSUnit
            End Get
            Set(ByVal Value As Decimal)
                _SuggestedRetailPriceSUnit = Value
            End Set
        End Property

        Public Property [SuggestedRetailPriceLUnit]() As Decimal
            Get
                Return _SuggestedRetailPriceLUnit
            End Get
            Set(ByVal Value As Decimal)
                _SuggestedRetailPriceLUnit = Value
            End Set
        End Property

        Public Property [SalesPriceSUnit]() As Decimal
            Get
                Return _SalesPriceSUnit
            End Get
            Set(ByVal Value As Decimal)
                _SalesPriceSUnit = Value
            End Set
        End Property

        Public Property [SalesPriceLUnit]() As Decimal
            Get
                Return _SalesPriceLUnit
            End Get
            Set(ByVal Value As Decimal)
                _SalesPriceLUnit = Value
            End Set
        End Property

        Public Property [OfficeSalesPriceSUnit]() As Decimal
            Get
                Return _OfficeSalesPriceSUnit
            End Get
            Set(ByVal Value As Decimal)
                _OfficeSalesPriceSUnit = Value
            End Set
        End Property

        Public Property [OfficeSalesPriceLUnit]() As Decimal
            Get
                Return _OfficeSalesPriceLUnit
            End Get
            Set(ByVal Value As Decimal)
                _OfficeSalesPriceLUnit = Value
            End Set
        End Property

        Public Property [MarginPct]() As Decimal
            Get
                Return _MarginPct
            End Get
            Set(ByVal Value As Decimal)
                _MarginPct = Value
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
#End Region

    End Class
End Namespace
