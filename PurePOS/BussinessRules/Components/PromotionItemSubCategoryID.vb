Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PromotionItemSubCategoryID
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _ItemSubCategoryID As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO PromotionItemSubCategoryID " & _
                                        "(ID, ItemSubCategoryID) " & _
                                        "VALUES (@ID, @ItemSubCategoryID)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)

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

        Public Function SelectAllByID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.*, isnull(i.ItemSubCategoryName,'') as ItemSubCategoryName FROM PromotionItemSubCategoryID dt " & _
                                       "left join ItemSubCategory i on i.ItemSubCategoryID = dt.ItemSubCategoryID " & _
                                       "where dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PromotionItemSubCategoryID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM PromotionItemSubCategoryID WHERE ID = @ID and ItemSubCategoryID = @ItemSubCategoryID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ItemSubCategoryID", _ItemSubCategoryID)

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

#Region " Others Function "
        Public Function SelectAllForGridItem() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT i.ItemSubCategoryID, i.ItemSubCategoryName " & _
                                       "FROM ItemSubCategory i " & _
                                       "WHERE i.ItemSubCategoryID NOT IN " & _
                                       "(SELECT dt.ItemSubCategoryID FROM PromotionItemSubCategoryID dt " & _
                                                            "WHERE dt.ID IN ( " & _
                                                            "SELECT hdP.ID FROM PromotionHD hdP " & _
                                                            "WHERE hdP.IsActive = 1 " & _
                                                            "AND convert(varchar(8),hdP.StartDate,112) >= CONVERT(VARCHAR(8),(SELECT hdS.StartDate FROM PromotionHD hdS WHERE hdS.IsActive = 1 AND HdS.ID = @ID),112) " & _
                                                            "AND convert(varchar(8),hdP.EndDate,112) <= CONVERT(VARCHAR(8),(SELECT hdD.EndDate FROM PromotionHD hdD WHERE hdD.IsActive = 1 AND HdD.ID = @ID),112))) "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemSubCategory")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
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

        Public Property [ItemSubCategoryID]() As String
            Get
                Return _ItemSubCategoryID
            End Get
            Set(ByVal Value As String)
                _ItemSubCategoryID = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
