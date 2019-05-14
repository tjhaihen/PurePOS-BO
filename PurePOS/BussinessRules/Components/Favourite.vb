Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Favourite
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _UserID, _FavouriteItemID, _FavouriteItemTypeID As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO Favourite " & _
                                        "(ID, UserID, FavouriteItemID, FavouriteItemTypeID) " & _
                                        "VALUES (@ID, @UserID, @FavouriteItemID, @FavouriteItemTypeID)"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@FavouriteItemID", _FavouriteItemID)
                cmdToExecute.Parameters.Add("@FavouriteItemTypeID", _FavouriteItemTypeID)

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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Favourite WHERE UserID = @UserID " & _
                                        "AND FavouriteItemID = @FavouriteItemID " & _
                                        "AND FavouriteItemTypeID = @FavouriteItemTypeID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Favourite")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@FavouriteItemID", _FavouriteItemID)
                cmdToExecute.Parameters.Add("@FavouriteItemTypeID", _FavouriteItemTypeID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _UserID = CType(toReturn.Rows(0)("UserID"), String)
                    _FavouriteItemID = CType(toReturn.Rows(0)("FavouriteItemID"), String)
                    _FavouriteItemTypeID = CType(toReturn.Rows(0)("FavouriteItemTypeID"), String)
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

            cmdToExecute.CommandText = "DELETE FROM Favourite WHERE UserID = @UserID " & _
                                        "AND FavouriteItemID = @FavouriteItemID " & _
                                        "AND FavouriteItemTypeID = @FavouriteItemTypeID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)
                cmdToExecute.Parameters.Add("@FavouriteItemID", _FavouriteItemID)
                cmdToExecute.Parameters.Add("@FavouriteItemTypeID", _FavouriteItemTypeID)

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
        Public Function SelectByUserID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT FavouriteItemID, " & _
                                        "FavouriteItemName = " & _
                                        "CASE WHEN(FavouriteItemTypeID = 'M') " & _
                                        "THEN(SELECT Caption FROM Menu WHERE MenuID = f.FavouriteItemID) " & _
                                        "WHEN(FavouriteItemTypeID = 'R') " & _
                                        "THEN(SELECT ReportCaption FROM Report WHERE ReportID = f.FavouriteItemID) " & _
                                        "END, " & _
                                        "FavouriteItemTypeName = " & _
                                        "CASE WHEN(FavouriteItemTypeID = 'M') " & _
                                        "THEN('Menu') " & _
                                        "WHEN(FavouriteItemTypeID = 'R') " & _
                                        "THEN('Report') " & _
                                        "END, " & _
                                        "URL = " & _
                                        "CASE WHEN(FavouriteItemTypeID = 'M') " & _
                                        "THEN(Select Url From Menu WHERE MenuID = f.FavouriteItemID) " & _
                                        "WHEN(FavouriteItemTypeID = 'R') " & _
                                        "THEN(Select Url From Report WHERE ReportID = f.FavouriteItemID) " & _
                                        "END " & _
                                        "FROM Favourite f WHERE UserID = @UserID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Favourite")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)

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

        Public Function SelectMenuByUserIDForFavourite() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT	ug.MenuID, m.ParentMenuID, m.Caption, " & _
                                        "m.[Description], " & _
                                        "IsSelected = " & _
                                        "CASE " & _
                                        "WHEN(f.ID IS NOT NULL) THEN(1) " & _
                                        "ELSE(0) " & _
                                        "END " & _
                                        "FROM	UserGroupMenu ug " & _
                                        "INNER JOIN Menu m ON ug.MenuID = m.MenuID " & _
                                        "AND m.isHeader = 0 " & _
                                        "LEFT JOIN Favourite f ON ug.MenuID = f.FavouriteItemID " & _
                                        "AND f.FavouriteItemTypeID = 'M' " & _
                                        "AND f.UserID = @UserID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("FavouriteMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)

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

        Public Function SelectReportByUserIDForFavourite() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT	ug.ReportID, m.ParentReportID, m.ReportCaption, " & _
                                        "m.[Description], " & _
                                        "IsSelected = " & _
                                        "CASE " & _
                                        "WHEN(f.ID IS NOT NULL) THEN(1) " & _
                                        "ELSE(0) " & _
                                        "END " & _
                                        "FROM	UserGroupReport ug " & _
                                        "INNER JOIN Report m ON ug.ReportID = m.ReportID " & _
                                        "AND m.isHeader = 0 " & _
                                        "LEFT JOIN Favourite f ON ug.ReportID = f.FavouriteItemID " & _
                                        "AND f.FavouriteItemTypeID = 'R' " & _
                                        "AND f.UserID = @UserID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("FavouriteMenu")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)

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

        Public Function DeleteByUserID() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "DELETE FROM Favourite WHERE UserID = @UserID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserID", _UserID)

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

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property

        Public Property [UserID]() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

        Public Property [FavouriteItemID]() As String
            Get
                Return _FavouriteItemID
            End Get
            Set(ByVal Value As String)
                _FavouriteItemID = Value
            End Set
        End Property

        Public Property [FavouriteItemTypeID]() As String
            Get
                Return _FavouriteItemTypeID
            End Get
            Set(ByVal Value As String)
                _FavouriteItemTypeID = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
