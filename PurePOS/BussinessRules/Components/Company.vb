Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Company
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _CompanyName, _PrimaryAddress, _SecondaryAddress As String
        Private _City, _Country, _ZipCode, _PrimaryPhoneNo, _SecondaryPhoneNo1, _SecondaryPhoneNo2 As String
        Private _FaxNo, _Email, _Website, _TIN, _LegalNo, _DirectorName As String
        Private _SerialNo As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM Company"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Company")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _CompanyName = CType(toReturn.Rows(0)("CompanyName"), String)
                    _PrimaryAddress = CType(toReturn.Rows(0)("PrimaryAddress"), String)
                    _SerialNo = CType(toReturn.Rows(0)("SerialNo"), String)
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

#Region " Class Property Declarations "
        Public Property [CompanyName]() As String
            Get
                Return _CompanyName
            End Get
            Set(ByVal Value As String)
                _CompanyName = Value
            End Set
        End Property

        Public Property [PrimaryAddress]() As String
            Get
                Return _PrimaryAddress
            End Get
            Set(ByVal Value As String)
                _PrimaryAddress = Value
            End Set
        End Property

        Public Property [SerialNo]() As String
            Get
                Return _SerialNo
            End Get
            Set(ByVal Value As String)
                _SerialNo = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
