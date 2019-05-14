Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Report
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ReportID, _ParentReportID As Integer
        Private _ReportCaption, _ReportAsp, _ReportFileName, _ReportSPName, _UserGroupID, _Description As String
        Private _ParameterField As String
        Private _IsActive, _IsAllowViewingType As Boolean
        Private _PublishDate As DateTime

        '// ParameterField
        Private _AspxPanelID As String
        Private _IsVisible As Boolean
        Private _Parm As String
        Private _ReportFormat As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Overrides Functions "
        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM [Report] WHERE ReportID = @ReportID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM [Report] WHERE ReportID > @ReportID ORDER BY ReportID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM [Report] WHERE ReportID < @ReportID ORDER BY ReportID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("Report")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReportID", _ReportID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ReportID = CType(toReturn.Rows(0)("ReportID"), Integer)
                    _ParentReportID = CType(Common.ProcessNull.GetInt32(toReturn.Rows(0)("ParentReportID")), Integer)
                    _ReportCaption = CType(toReturn.Rows(0)("ReportCaption"), String)
                    _ParameterField = CType(toReturn.Rows(0)("ParameterField"), String)
                    _ReportAsp = CType(toReturn.Rows(0)("ReportAsp"), String)
                    _ReportFileName = CType(toReturn.Rows(0)("ReportFIleName"), String)
                    _ReportSPName = CType(toReturn.Rows(0)("ReportSPName"), String)
                    _ReportFormat = CType(toReturn.Rows(0)("ReportFormat"), String)
                    _Description = CType(toReturn.Rows(0)("Description"), String)
                    _PublishDate = CType(toReturn.Rows(0)("PublishDate"), DateTime)
                    _IsActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _IsAllowViewingType = CType(toReturn.Rows(0)("isAllowViewingType"), Boolean)
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

#Region " Custom Functions "
        Public Function SelectReportAuthorizationByUserGroupID(ByVal UserGroupID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT isnull(r.ReportID,'') as ReportID, " & _
                                        "r.ParentReportID, r.ReportCaption, " & _
                                        "IsAuthorized = " & _
                                        "CASE " & _
                                        "WHEN(r.ReportID in (SELECT ReportID FROM UserGroupReport WHERE UserGroupID = @UserGroupID)) THEN(1) " & _
                                        "ELSE " & _
                                        "0 " & _
                                        "END " & _
                                        "FROM Report r " & _
                                        "LEFT JOIN UserGroupReport g ON r.ReportID = g.ReportID AND g.UserGroupID = @UserGroupID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportAuthorizationByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", UserGroupID)

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

        Public Function SelectByUserGroupID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT ugr.UserGroupID, " & _
                                        "r.* " & _
                                        "FROM UserGroupReport ugr " & _
                                        "INNER JOIN Report r on r.ReportID = ugr.ReportID " & _
                                        "WHERE ugr.UserGroupID = @UserGroupID AND r.isActive = 1 " & _
                                        "AND CONVERT(varchar(8),r.PublishDate,112) <= CONVERT(varchar(8),GETDATE(),112)"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@UserGroupID", _UserGroupID)

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

        Public Function SelectAllSPParameter(ByVal SP As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT replace(rtrim(ltrim(parameter_name)),'@','') AS ParameterName " & _
                                       "FROM INFORMATION_SCHEMA.PARAMETERS " & _
                                       "WHERE specific_name = @sp "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportByUserGroupID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SP", SP)

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

        '// ParameterField
        Public Function SelectReportParameterByReportID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * " & _
                                        "FROM ReportParameter rp " & _
                                        "WHERE rp.ReportID = @ReportID"
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("ReportParameterByReportID")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ReportID", _ReportID)

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

        Public Sub AddParametersPrintReport(ByVal Parm As String, Optional ByVal IsClear As Boolean = False)
            If Not IsClear Then
                If _Parm = "" Or _Parm = Nothing Then
                    _Parm = Parm
                Else
                    _Parm = _Parm + "|" + Parm
                End If
            Else
                _Parm = String.Empty
            End If
        End Sub

        Public Function UrlPrintReport(ByVal ContextRequestUrlHost As String) As String
            If _Parm = "" OrElse _Parm = Nothing Then
                Throw New Exception("Report Parameter cannot empty.")
                Exit Function
            End If

            If (_ReportFormat <> "PDF") Then
                Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + HisConfiguration.ReportsFolder.Trim + _ReportAsp.Trim + ".asp?RptName=" + _ReportFileName.Trim + "&SP=" + _ReportSPName.Trim + "&parm=" + _Parm.Trim + "','" + Replace(_ReportCaption.Trim, " ", "") + "','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>"
            Else
                Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + Common.HisConfiguration.ModuleAppl + "CRReportViewer.aspx?opn=Report&rpt=" + _ReportID.ToString.Trim + "&par=" + _Parm.Trim + "','','status=no,resizable=yes,toolbar=no,menubar=no,location=no,scrollbars=1')</script>"
            End If

        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [UserGroupID]() As String
            Get
                Return _UserGroupID
            End Get
            Set(ByVal Value As String)
                _UserGroupID = Value
            End Set
        End Property

        Public Property [ReportID]() As Integer
            Get
                Return _ReportID
            End Get
            Set(ByVal Value As Integer)
                _ReportID = Value
            End Set
        End Property

        Public Property [ParentReportID]() As Integer
            Get
                Return _ParentReportID
            End Get
            Set(ByVal Value As Integer)
                _ParentReportID = Value
            End Set
        End Property

        Public Property [ReportCaption]() As String
            Get
                Return _ReportCaption
            End Get
            Set(ByVal Value As String)
                _ReportCaption = Value
            End Set
        End Property

        Public Property [ReportAsp]() As String
            Get
                Return _ReportAsp
            End Get
            Set(ByVal Value As String)
                _ReportAsp = Value
            End Set
        End Property

        Public Property [ReportFileName]() As String
            Get
                Return _ReportFileName
            End Get
            Set(ByVal Value As String)
                _ReportFileName = Value
            End Set
        End Property

        Public Property [ReportSPName]() As String
            Get
                Return _ReportSPName
            End Get
            Set(ByVal Value As String)
                _ReportSPName = Value
            End Set
        End Property

        Public Property [ReportFormat]() As String
            Get
                Return _ReportFormat
            End Get
            Set(ByVal Value As String)
                _ReportFormat = Value
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

        Public Property [IsAllowViewingType]() As Boolean
            Get
                Return _IsAllowViewingType
            End Get
            Set(ByVal Value As Boolean)
                _IsAllowViewingType = Value
            End Set
        End Property

        Public Property [PublishDate]() As DateTime
            Get
                Return _PublishDate
            End Get
            Set(ByVal Value As DateTime)
                _PublishDate = Value
            End Set
        End Property

        '// ParameterField
        Public Property [AspxPanelID]() As String
            Get
                Return _AspxPanelID
            End Get
            Set(ByVal Value As String)
                _AspxPanelID = Value
            End Set
        End Property

        Public Property [IsVisible]() As Boolean
            Get
                Return _IsVisible
            End Get
            Set(ByVal Value As Boolean)
                _IsVisible = Value
            End Set
        End Property

        Public Property [ParameterField]() As String
            Get
                Return _ParameterField
            End Get
            Set(ByVal Value As String)
                _ParameterField = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
