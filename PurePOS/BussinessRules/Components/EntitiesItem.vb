Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class EntitiesItem
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID As String
        Private _EntitiesSeqNo, _ItemSeqNo, _ItemUnitID, _Description As String
        Private _ItemFactor, _Price As Decimal
        Private _StartingDate As DateTime
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As DateTime
        Private _IsDeleted As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO EntitiesItem " & _
                                        "(ID, EntitiesSeqNo, ItemSeqNo, ItemUnitID, Description, " & _
                                        "ItemFactor, Price, StartingDate, " & _
                                        "UserInsert, UserUpdate, UserDelete, " & _
                                        "InsertDate, UpdateDate, DeleteDate, " & _
                                        "IsDeleted) " & _
                                        "VALUES " & _
                                        "(@ID, @EntitiesSeqNo, @ItemSeqNo, @ItemUnitID, @Description, " & _
                                        "@ItemFactor, @Price, @StartingDate, " & _
                                        "@UserInsert, @UserUpdate, '', " & _
                                        "GetDate(), GetDate(), '', " & _
                                        "0)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)
                cmdToExecute.Parameters.Add("@Price", _Price)
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

            cmdToExecute.CommandText = "UPDATE EntitiesItem " & _
                                        "SET EntitiesSeqNo = @EntitiesSeqNo, " & _
                                        "ItemSeqNo = @ItemSeqNo, " & _
                                        "ItemUnitID = @ItemUnitID, " & _
                                        "ItemFactor = @ItemFactor, " & _
                                        "Price = @Price, " & _
                                        "StartingDate = @StartingDate, " & _
                                        "Description = @Description, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)
                cmdToExecute.Parameters.Add("@Price", _Price)
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

            cmdToExecute.CommandText = "SELECT * FROM EntitiesItem"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EntitiesItem")
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
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesItem WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesItem WHERE IsDeleted = 0 AND (EntitiesSeqNo > @EntitiesSeqNo OR ItemSeqNo > @ItemSeqNo " & _
                        "OR ItemUnitID > @ItemUnitID OR ItemFactor > @ItemFactor OR StartingDate > @StartingDate) ORDER BY EntitiesSeqNo, ItemSeqNo, ItemUnitID, ItemFactor, StartingDate ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM EntitiesItem WHERE IsDeleted = 0 AND (EntitiesSeqNo < @EntitiesSeqNo OR ItemSeqNo < @ItemSeqNo " & _
                        "OR ItemUnitID < @ItemUnitID OR ItemFactor > @ItemFactor OR StartingDate < @StartingDate) ORDER BY EntitiesSeqNo, ItemSeqNo, ItemUnitID, ItemFactor, StartingDate DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("EntitiesItem")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                Select Case recStatus
                    Case RavenRecStatus.CurrentRecord
                        cmdToExecute.Parameters.Add("@ID", _ID)
                    Case Else
                        cmdToExecute.Parameters.Add("@EntitiesSeqNo", _EntitiesSeqNo)
                        cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                        cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                        cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                        cmdToExecute.Parameters.Add("@StartingDate", _StartingDate)
                End Select

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _EntitiesSeqNo = CType(toReturn.Rows(0)("EntitiesSeqNo"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemUnitID = CType(toReturn.Rows(0)("ItemUnitID"), String)
                    _ItemFactor = CType(toReturn.Rows(0)("ItemFactor"), Decimal)
                    _StartingDate = CType(toReturn.Rows(0)("StartingDate"), DateTime)
                    _Price = CType(toReturn.Rows(0)("Price"), Decimal)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
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

            cmdToExecute.CommandText = "Update EntitiesItem " & _
                                       "Set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = Getdate() " & _
                                       "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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

#Region " Other Functions "
        Public Function SelectAllByEntitiesSeqNo(ByVal ItemSeqNo As String, ByVal ItemUnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT E.*, isnull(i.ItemName,'') as ItemName, " & _
                                       "ISNULL(i.ItemID,'') as ItemID, " & _
                                       "ISNULL(u.ItemUnitName,'') as ItemUnitName, " & _
                                       "ISNULL((SELECT EntitiesID FROM Entities WHERE EntitiesSeqNo = E.EntitiesSeqNo),'') AS EntitiesID, " & _
                                       "ISNULL((SELECT EntitiesName FROM Entities WHERE EntitiesSeqNo = E.EntitiesSeqNo),'') AS EntitiesName " & _
                                       "FROM EntitiesItem E " & _
                                       "INNER JOIN Item i ON i.ItemSeqNo = E.ItemSeqNo " & _
                                       "LEFT JOIN ItemUnit u ON E.ItemUnitID = u.ItemUnitID " & _
                                       "WHERE E.IsDeleted = 0 " & _
                                       "AND E.EntitiesSeqNo LIKE @EntitiesSeqNo " & _
                                       "AND E.ItemSeqNo LIKE '%" & ItemSeqNo.Trim & "%' " & _
                                       "AND E.ItemUnitID LIKE '%" & ItemUnitID.Trim & "%' " & _
                                       "ORDER BY E.EntitiesSeqNo, E.ItemSeqNo, E.ItemUnitID, E.ItemFactor, E.StartingDate DESC"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("EntitiesItem")
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
#End Region

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
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

        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property

        Public Property [ItemUnitID]() As String
            Get
                Return _ItemUnitID
            End Get
            Set(ByVal Value As String)
                _ItemUnitID = Value
            End Set
        End Property

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
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

        Public Property [Price]() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal Value As Decimal)
                _Price = Value
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

        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
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
#End Region

    End Class
End Namespace
