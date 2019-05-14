Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ItemROP
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSeqNo, _WhID, _UnitID As String
        Private _ROPMinSUnit, _ROPMaxSUnit As Decimal
        Private _UserUpdate As String
        Private _UpdateDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ItemROP " & _
                                        "(ItemSeqNo, WHID, UnitID, ROPMinSUnit, ROPMaxSUnit, UserUpdate, UpdateDate) " & _
                                        "VALUES (@ItemSeqNo, @WHID, @UnitID, @ROPMinSUnit, @ROPMaxSUnit, @UserUpdate, GetDate())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@WHID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)
                cmdToExecute.Parameters.AddWithValue("@ROPMinSUnit", _ROPMinSUnit)
                cmdToExecute.Parameters.AddWithValue("@ROPMaxSUnit", _ROPMaxSUnit)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", _UserUpdate)

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

            cmdToExecute.CommandText = "UPDATE ItemROP " & _
                                        "SET ROPMinSUnit = @ROPMinSUnit, " & _
                                        "ROPMaxSUnit = @ROPMaxSUnit, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ItemSeqNo=@ItemSeqNo AND WHID=@WHID AND UnitID=@UnitID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@WHID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)
                cmdToExecute.Parameters.AddWithValue("@ROPMinSUnit", _ROPMinSUnit)
                cmdToExecute.Parameters.AddWithValue("@ROPMaxSUnit", _ROPMaxSUnit)
                cmdToExecute.Parameters.AddWithValue("@UserUpdate", _UserUpdate)

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

            cmdToExecute.CommandText = "SELECT * FROM ItemROP"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemROP")
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
            cmdToExecute.CommandText = "SELECT * FROM ItemROP WHERE ItemSeqNo = @ItemSeqNo AND WHID=@WHID AND UnitID=@UnitID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ItemROP")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@WHID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _WhID = CType(toReturn.Rows(0)("WHID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _ROPMinSUnit = CType(toReturn.Rows(0)("ROPMinSUnit"), Decimal)
                    _ROPMaxSUnit = CType(toReturn.Rows(0)("ROPMaxSUnit"), Decimal)                    
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

            cmdToExecute.CommandText = "DELETE FROM ItemROP WHERE ItemSeqNo = @ItemSeqNo AND WHID=@WHID AND UnitID=@UnitID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.AddWithValue("@WHID", _WhID)
                cmdToExecute.Parameters.AddWithValue("@UnitID", _UnitID)

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
        Public Function SelectByWHIDUnitID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ib.*, i.ItemName, i.ItemSUnitID, i.ItemID FROM ItemROP ib " +
                                        "INNER JOIN Item i ON ib.ItemSeqNo=i.ItemSeqNo " +
                                        "WHERE ib.WHID=@WHID AND ib.UnitID=@UnitID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemROP")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WHID", _WhID.Trim)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID.Trim)                
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
        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
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

        Public Property [ROPMinSUnit]() As Decimal
            Get
                Return _ROPMinSUnit
            End Get
            Set(ByVal Value As Decimal)
                _ROPMinSUnit = Value
            End Set
        End Property

        Public Property [ROPMaxSUnit]() As Decimal
            Get
                Return _ROPMaxSUnit
            End Get
            Set(ByVal Value As Decimal)
                _ROPMaxSUnit = Value
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
