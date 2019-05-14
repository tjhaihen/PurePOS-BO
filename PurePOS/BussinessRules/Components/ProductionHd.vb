Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ProductionHd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ProductionNo, _FormulaID, _ProductionDate, _WhID, _UnitID, _Description As String
        Private _QtySUnit As Decimal
        Private _UserInsert, _UserUpdate, _UserDelete, _UserApproval As String
        Private _InsertDate, _UpdateDate, _DeleteDate, _ApprovalDate As DateTime
        Private _IsDeleted, _IsApproval As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO ProductionHd " & _
                                        "(ProductionNo, ProductionDate, FormulaID, WhID, UnitID, QtySUnit, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, " & _
                                        "IsApproval, UserApproval, ApprovalDate) " & _
                                        "VALUES (@ProductionNo, @ProductionDate, @FormulaID, @WhID, @UnitID, @QtySUnit, " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, left(@Description,500), " & _
                                        "0, '', '')"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ProductionNo", _ProductionNo)
                cmdToExecute.Parameters.Add("@ProductionDate", _ProductionDate)
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@QtySUnit", _QtySUnit)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
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

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE ProductionHd " & _
                                        "SET ProductionNo = @ProductionNo, " & _
                                        "ProductionDate = @ProductionDate, " & _
                                        "FormulaID = @FormulaID, " & _
                                        "WhID = @WhID, " & _
                                        "UnitID = @UnitID, " & _
                                        "QtySUnit = @QtySUnit, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE ProductionNo = @ProductionNo"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ProductionNo", _ProductionNo)
                cmdToExecute.Parameters.Add("@ProductionDate", _ProductionDate)
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
                cmdToExecute.Parameters.Add("@QtySUnit", _QtySUnit)
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

            cmdToExecute.CommandText = "SELECT * FROM ProductionHd order by ProductionNo"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProductionHd")
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

        Public Function SelectAllForProductionNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*, isnull(i.FormulaName,'') as FormulaName,CONVERT(varchar(10),hd.ProductionDate,105) as formatdate  " & _
                                       "FROM ProductionHd hd " & _
                                       "Left Join ProductionFormulaHd i on i.FormulaID = hd.FormulaID " & _
                                       "Where hd.IsDeleted = 0 and (hd.ProductionNo LIKE '%" + Filter.Trim + "%' OR CONVERT(varchar(10),hd.ProductionDate,105) LIKE '%" + Filter.Trim + "%' OR i.FormulaName LIKE '%" + Filter.Trim + "%') " & _
                                       "order by ProductionNo desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProductionHd")
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
                    cmdToExecute.CommandText = "SELECT * FROM ProductionHd WHERE Isdeleted = 0 and ProductionNo = @ProductionNo"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ProductionHd WHERE Isdeleted = 0 and ProductionNo > @ProductionNo ORDER BY ProductionNo ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ProductionHd WHERE Isdeleted = 0 and ProductionNo < @ProductionNo ORDER BY ProductionNo DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProductionHd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ProductionNo", _ProductionNo)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ProductionNo = CType(toReturn.Rows(0)("ProductionNo"), String)
                    _ProductionDate = CType(toReturn.Rows(0)("ProductionDate"), String)
                    _FormulaID = CType(toReturn.Rows(0)("FormulaID"), String)
                    _WhID = CType(toReturn.Rows(0)("WhID"), String)
                    _UnitID = CType(toReturn.Rows(0)("UnitID"), String)
                    _QtySUnit = CType(toReturn.Rows(0)("QtySUnit"), Decimal)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)
                    _ApprovalDate = CType(toReturn.Rows(0)("ApprovalDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _UserApproval = CType(toReturn.Rows(0)("UserApproval"), String)

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

            cmdToExecute.CommandText = "Update ProductionHd " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and ProductionNo = @ProductionNo"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ProductionNo", _ProductionNo)
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


#Region "Others Function"

#End Region

#Region " Class Property Declarations "
        Public Property [ProductionNo]() As String
            Get
                Return _ProductionNo
            End Get
            Set(ByVal Value As String)
                _ProductionNo = Value
            End Set
        End Property

        Public Property [ProductionDate]() As DateTime
            Get
                Return _ProductionDate
            End Get
            Set(ByVal Value As DateTime)
                _ProductionDate = Value
            End Set
        End Property

        Public Property [FormulaID]() As String
            Get
                Return _FormulaID
            End Get
            Set(ByVal Value As String)
                _FormulaID = Value
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

        Public Property [QtySUnit]() As Decimal
            Get
                Return _QtySUnit
            End Get
            Set(ByVal Value As Decimal)
                _QtySUnit = Value
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

        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
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

        Public Property [IsApproval]() As Boolean
            Get
                Return _IsApproval
            End Get
            Set(ByVal Value As Boolean)
                _IsApproval = Value
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
#End Region

    End Class
End Namespace
