﻿Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DeliveryZoneHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _DeliveryZoneID, _DeliveryZoneName, _Description As String
        Private _DeliveryFee, _MinPurchaseAmount, _MinPurchaseQty As Decimal
        Private _DeliveryInterval As String
        Private _UserInsert, _UserUpdate As String
        Private _InsertDate, _UpdateDate As String
        Private _IsActive As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO DeliveryZoneHd " & _
                                        "(DeliveryZoneID, DeliveryZoneName, DeliveryFee, MinPurchaseAmount, MinPurchaseQty, DeliveryInterval, Description, isActive, UserInsert, InsertDate, UserUpdate, UpdateDate) " & _
                                        "VALUES (@DeliveryZoneID, @DeliveryZoneName, @DeliveryFee, @MinPurchaseAmount, @MinPurchaseQty, @DeliveryInterval, left(@Description,500), @IsActive, @UserInsert, GetDate(), @UserUpdate, GetDate())"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)
                cmdToExecute.Parameters.Add("@DeliveryZoneName", _DeliveryZoneName)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@MinPurchaseAmount", _MinPurchaseAmount)
                cmdToExecute.Parameters.Add("@MinPurchaseQty", _MinPurchaseQty)
                cmdToExecute.Parameters.Add("@DeliveryInterval", _DeliveryInterval)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
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

            cmdToExecute.CommandText = "UPDATE DeliveryZone " & _
                                        "SET DeliveryZoneName = @DeliveryZoneName, " & _
                                        "DeliveryFee = @DeliveryFee, " & _
                                        "MinPurchaseAmount = @MinPurchaseAmount, " & _
                                        "MinPurchaseQty = @MinPurchaseQty, " & _
                                        "DeliveryInterval = @DeliveryInterval, " & _
                                        "Description = left(@Description,500), " & _
                                        "IsActive = @IsActive, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate() " & _
                                        "WHERE DeliveryZoneID = @DeliveryZoneID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)
                cmdToExecute.Parameters.Add("@DeliveryZoneName", _DeliveryZoneName)
                cmdToExecute.Parameters.Add("@DeliveryFee", _DeliveryFee)
                cmdToExecute.Parameters.Add("@MinPurchaseAmount", _MinPurchaseAmount)
                cmdToExecute.Parameters.Add("@MinPurchaseQty", _MinPurchaseQty)
                cmdToExecute.Parameters.Add("@DeliveryInterval", _DeliveryInterval)
                cmdToExecute.Parameters.Add("@Description", _Description)
                cmdToExecute.Parameters.Add("@IsActive", _IsActive)
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

            cmdToExecute.CommandText = "SELECT * FROM DeliveryZoneHd ORDER BY DeliveryZoneID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryZoneHd")
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

        Public Function SelectAllActive() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM DeliveryZoneHd WHERE IsActive = 1 ORDER BY DeliveryZoneID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryZoneHd")
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

        Public Function SelectAllForDeliveryZoneId(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " * FROM DeliveryZoneHd " & _
                                       "WHERE DeliveryZoneID LIKE '%" + Filter.Trim + "%' OR DeliveryZoneName LIKE '%" + Filter.Trim + "%' " & _
                                       "ORDER BY DeliveryZoneID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryZoneHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryZoneHd WHERE DeliveryZoneID = @DeliveryZoneID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryZoneHd WHERE DeliveryZoneID > @DeliveryZoneID ORDER BY DeliveryZoneID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryZoneHd WHERE DeliveryZoneID < @DeliveryZoneID ORDER BY DeliveryZoneID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("DeliveryZoneHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _DeliveryZoneID = CType(toReturn.Rows(0)("DeliveryZoneID"), String)
                    _DeliveryZoneName = CType(toReturn.Rows(0)("DeliveryZoneName"), String)
                    _DeliveryFee = CType(toReturn.Rows(0)("DeliveryFee"), Decimal)
                    _MinPurchaseAmount = CType(toReturn.Rows(0)("MinPurchaseAmount"), Decimal)
                    _MinPurchaseQty = CType(toReturn.Rows(0)("MinPurchaseQty"), Decimal)
                    _DeliveryInterval = CType(toReturn.Rows(0)("DeliveryInterval"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _IsActive = CType(toReturn.Rows(0)("IsActive"), Boolean)
                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
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

            cmdToExecute.CommandText = "DELETE FROM DeliveryZoneHd WHERE DeliveryZoneID = @DeliveryZoneID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DeliveryZoneID", _DeliveryZoneID)

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
        Public Property [DeliveryZoneID]() As String
            Get
                Return _DeliveryZoneID
            End Get
            Set(ByVal Value As String)
                _DeliveryZoneID = Value
            End Set
        End Property

        Public Property [DeliveryZoneName]() As String
            Get
                Return _DeliveryZoneName
            End Get
            Set(ByVal Value As String)
                _DeliveryZoneName = Value
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

        Public Property [MinPurchaseAmount]() As Decimal
            Get
                Return _MinPurchaseAmount
            End Get
            Set(ByVal Value As Decimal)
                _MinPurchaseAmount = Value
            End Set
        End Property

        Public Property [MinPurchaseQty]() As Decimal
            Get
                Return _MinPurchaseQty
            End Get
            Set(ByVal Value As Decimal)
                _MinPurchaseQty = Value
            End Set
        End Property

        Public Property [DeliveryInterval]() As String
            Get
                Return _DeliveryInterval
            End Get
            Set(ByVal Value As String)
                _DeliveryInterval = Value
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

        Public Property [IsActive]() As Boolean
            Get
                Return _IsActive
            End Get
            Set(ByVal Value As Boolean)
                _IsActive = Value
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
#End Region

    End Class
End Namespace
