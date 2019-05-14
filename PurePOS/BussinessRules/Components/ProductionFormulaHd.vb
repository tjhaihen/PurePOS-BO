Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ProductionFormulahd
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _FormulaID, _ItemSeqNo, _FormulaName, _Description As String
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

            cmdToExecute.CommandText = "INSERT INTO ProductionFormulahd " & _
                                        "(FormulaID, FormulaName, ItemSeqNo, " & _
                                        "UserInsert, InsertDate, UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                                        "VALUES (@FormulaID, @FormulaName, @ItemSeqNo,  " & _
                                        "@UserInsert, getdate(), @UserUpdate, getdate(), '', '', 0, left(@Description,500) )"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)
                cmdToExecute.Parameters.Add("@FormulaName", _FormulaName)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
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
            cmdToExecute.CommandText = "UPDATE ProductionFormulahd " & _
                                        "SET FormulaID = @FormulaID, " & _
                                        "FormulaName = @FormulaName, " & _
                                        "ItemSeqNo = @ItemSeqNo, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE FormulaID = @FormulaID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)
                cmdToExecute.Parameters.Add("@FormulaName", _FormulaName)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
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

            cmdToExecute.CommandText = "SELECT * FROM ProductionFormulahd order by FormulaID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProductionFormulahd")
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

        Public Function SelectAllForFormulaID(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " hd.*, isnull(i.ItemName,'') as ItemName " & _
                                       "FROM ProductionFormulahd hd " & _
                                       "Left Join Item i on i.ItemSeqNo = hd.ItemSeqNo " & _
                                       "Where hd.IsDeleted = 0 and (hd.FormulaID LIKE '%" + Filter.Trim + "%' OR hd.FormulaName LIKE '%" + Filter.Trim + "%' OR i.ItemName LIKE '%" + Filter.Trim + "%') " & _
                                       "order by FormulaID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ProductionFormulahd")
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
                    cmdToExecute.CommandText = "SELECT * FROM ProductionFormulahd WHERE Isdeleted = 0 and FormulaID = @FormulaID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM ProductionFormulahd WHERE Isdeleted = 0 and FormulaID > @FormulaID ORDER BY FormulaID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM ProductionFormulahd WHERE Isdeleted = 0 and FormulaID < @FormulaID ORDER BY FormulaID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ProductionFormulahd")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _FormulaID = CType(toReturn.Rows(0)("FormulaID"), String)
                    _FormulaName = CType(toReturn.Rows(0)("FormulaName"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)

                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)

                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)

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

            cmdToExecute.CommandText = "Update ProductionFormulahd " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and FormulaID = @FormulaID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@FormulaID", _FormulaID)
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
        Public Property [FormulaID]() As String
            Get
                Return _FormulaID
            End Get
            Set(ByVal Value As String)
                _FormulaID = Value
            End Set
        End Property

        Public Property [FormulaName]() As String
            Get
                Return _FormulaName
            End Get
            Set(ByVal Value As String)
                _FormulaName = Value
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
#End Region

    End Class
End Namespace
