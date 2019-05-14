Option Explicit On 

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class stdfield
        Inherits BRInteractionBase


#Region " Class Member Declarations "

        Private _aktif As SqlBoolean
        Private _nmkduser, _kdfield, _kduser As SqlString

#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub


#Region "Update & Insert"
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sprs_stdfield_detil_update"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", _kdfield)
                cmdToExecute.Parameters.Add("@kduser", _kduser)
                cmdToExecute.Parameters.Add("@nmkduser", _nmkduser)
                cmdToExecute.Parameters.Add("@aktif", _aktif)

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

#Region "Delete"
        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sprs_stdfield_detil_delete"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", _kdfield)
                cmdToExecute.Parameters.Add("@kduser", _kduser)

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

#Region "Select All"
        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sprs_stdfield_detil_selectall"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("stdfield")
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
#End Region

#Region "Select One"
        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "sprs_stdfield_detil_SelectByKdFieldKdUser"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "sprs_stdfield_detil_SelectByKdFieldKdUserNext"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "sprs_stdfield_detil_SelectByKdFieldKdUserPrev"
            End Select

            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("stdfield")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", _kdfield)
                cmdToExecute.Parameters.Add("@kdUser", _kduser)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _kdfield = New SqlString(CType(toReturn.Rows(0)("kdfield"), String))
                    _kduser = New SqlString(CType(toReturn.Rows(0)("kduser"), String))
                    _nmkduser = New SqlString(CType(toReturn.Rows(0)("nmkduser"), String))
                    _aktif = New SqlBoolean(CType(toReturn.Rows(0)("aktif"), Boolean))
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
#End Region

#Region "Select By Kode Field"
        Public Function SelectByKdField() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sprs_StdField_Detil_SelectByKdfield"

            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("stdfield")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", _kdfield)

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
#Region "Select Value Stdfielddt "

        Public Function GetValueStdfield(ByVal kdfield As String, ByVal kduser As String) As String
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strReturn As String

            cmdToExecute.CommandText = "sprs_stdfield_getName"

            cmdToExecute.CommandType = CommandType.StoredProcedure


            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", kdfield)
                cmdToExecute.Parameters.Add("@kduser", kduser)
                cmdToExecute.Parameters.Add("@getName", SqlDbType.Char, 100)

                cmdToExecute.Parameters("@getName").Direction = ParameterDirection.Output
                ' // Open connection.
                _mainConnection.Open()
                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                strReturn = Convert.ToString(cmdToExecute.Parameters("@getName").Value).Trim

                Return strReturn
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

        Public Function GetIntValueStdfield(ByVal kdfield As String, ByVal kduser As String) As Byte
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strReturn As String
            Dim byteReturn As Byte

            cmdToExecute.CommandText = "sprs_stdfield_getName"

            cmdToExecute.CommandType = CommandType.StoredProcedure


            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@kdfield", kdfield)
                cmdToExecute.Parameters.Add("@kduser", kduser)
                cmdToExecute.Parameters.Add("@getName", SqlDbType.Char, 100)

                cmdToExecute.Parameters("@getName").Direction = ParameterDirection.Output
                ' // Open connection.
                _mainConnection.Open()
                ' // Execute query.
                cmdToExecute.ExecuteNonQuery()

                strReturn = Convert.ToString(cmdToExecute.Parameters("@getName").Value).Trim

                byteReturn = CType(strReturn, Byte)

                Return byteReturn
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

        Public Property [Aktif]() As SqlBoolean
            Get
                Return _aktif
            End Get
            Set(ByVal Value As SqlBoolean)
                _aktif = Value
            End Set
        End Property

        Public Property [Nmkduser]() As SqlString
            Get
                Return _nmkduser
            End Get
            Set(ByVal Value As SqlString)
                _nmkduser = Value
            End Set
        End Property

        Public Property [Kdfield]() As SqlString
            Get
                Return _kdfield
            End Get
            Set(ByVal Value As SqlString)
                _kdfield = Value
            End Set
        End Property

        Public Property [Kduser]() As SqlString
            Get
                Return _kduser
            End Get
            Set(ByVal Value As SqlString)
                _kduser = Value
            End Set
        End Property

#End Region



    End Class
End Namespace
