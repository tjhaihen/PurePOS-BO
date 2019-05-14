Option Explicit On 

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common
    Public Class SetVar

#Region " Class Member Declarations "
        Private Shared _app, _kode, _nama, _nilai, _ket As SqlString
        Private Shared _appDef As SqlString = New SqlString(HisConfiguration.AppId)
#End Region

        Public Sub New()
        End Sub

        Public Shared Function Insert() As Boolean

        End Function


        Public Shared Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_Update"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@app", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _app))
                cmdToExecute.Parameters.Add(New SqlParameter("@kode", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kode))
                cmdToExecute.Parameters.Add(New SqlParameter("@nilai", SqlDbType.NVarChar, 75, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nilai))

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


        Public Shared Function Delete() As Boolean

        End Function


        Public Function GetActiveSetVar() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("setvar")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@app", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _app))
                cmdToExecute.Parameters.Add(New SqlParameter("@kode", SqlDbType.Char, 15, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kode))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _app = New SqlString(CType(toReturn.Rows(0)("APP"), String))
                    _kode = New SqlString(CType(toReturn.Rows(0)("kode"), String))
                    _nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
                    _nilai = New SqlString(CType(toReturn.Rows(0)("nilai"), String))
                    _ket = New SqlString(CType(toReturn.Rows(0)("ket"), String))
                    Return True
                End If

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


        Public Function GetValue(ByVal kode As String, Optional ByVal app As String = "") As String
            If Len(app) = 0 Then
                app = Common.HisConfiguration.AppId.Trim
            End If

            Dim retVal As String

            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("setvar")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@app", app))
                cmdToExecute.Parameters.Add(New SqlParameter("@kode", kode))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _app = New SqlString(CType(toReturn.Rows(0)("APP"), String))
                    _kode = New SqlString(CType(toReturn.Rows(0)("kode"), String))
                    _nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
                    _nilai = New SqlString(CType(toReturn.Rows(0)("nilai"), String))
                    _ket = New SqlString(CType(toReturn.Rows(0)("ket"), String))

                    retVal = _nilai.Value.Trim
                End If

                Return retVal
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

        Public Function GetValueFM(ByVal kode As String, Optional ByVal app As String = "") As String
            If Len(app) = 0 Then
                app = "FM_"
            End If

            Dim retVal As String

            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("setvar")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@app", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, app))
                cmdToExecute.Parameters.Add(New SqlParameter("@kode", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, kode))

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
                If toReturn.Rows.Count > 0 Then
                    _app = New SqlString(CType(toReturn.Rows(0)("APP"), String))
                    _kode = New SqlString(CType(toReturn.Rows(0)("kode"), String))
                    _nama = New SqlString(CType(toReturn.Rows(0)("nama"), String))
                    _nilai = New SqlString(CType(toReturn.Rows(0)("nilai"), String))
                    _ket = New SqlString(CType(toReturn.Rows(0)("ket"), String))

                    retVal = _nilai.Value.Trim
                End If

                Return retVal
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

        Public Shared Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_SelectAll"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("setvar")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

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

        Public Function SelectAll_byAPP() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim _mainConnection As SqlConnection = New SqlConnection(HisConfiguration.ConnectionString)
            cmdToExecute.CommandText = "sprs_setvar_SelectAll_byAPP"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("setvar")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add(New SqlParameter("@app", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _app))

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


#Region " Class Property Declarations "

        Public Shared Property [app]() As SqlString
            Get
                Return _app
            End Get
            Set(ByVal Value As SqlString)
                Dim appTmp As SqlString = Value
                If appTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("app", "app can't be NULL")
                End If
                _app = Value
            End Set
        End Property

        Public Shared Property [kode]() As SqlString
            Get
                Return _kode
            End Get
            Set(ByVal Value As SqlString)
                Dim kodeTmp As SqlString = Value
                If kodeTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kode", "kode can't be NULL")
                End If
                _kode = Value
            End Set
        End Property

        Public Shared Property [nama]() As SqlString
            Get
                Return _nama
            End Get
            Set(ByVal Value As SqlString)
                Dim namaTmp As SqlString = Value
                If namaTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nama", "nama can't be NULL")
                End If
                _nama = Value
            End Set
        End Property

        Public Shared Property [nilai]() As SqlString
            Get
                Return _nilai
            End Get
            Set(ByVal Value As SqlString)
                Dim nilaiTmp As SqlString = Value
                If nilaiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nilai", "nilai can't be NULL")
                End If
                _nilai = Value
            End Set
        End Property

        Public Shared Property [ket]() As SqlString
            Get
                Return _ket
            End Get
            Set(ByVal Value As SqlString)
                Dim ketTmp As SqlString = Value
                If ketTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ket", "ket can't be NULL")
                End If
                _ket = Value
            End Set
        End Property

#End Region

    End Class
End Namespace
