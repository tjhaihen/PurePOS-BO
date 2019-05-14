Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PrintForm
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _PrintFormID, _MenuID As Integer
        Private _PrintFormCaption, _PrintFormSPName, _PrintFormAsp, _PrintFormFileName, _ParameterField, _Parm As String
        Private _PrintFormFormat As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Custom Function "
        Public Function SelectOneByPrintFormIDAndMenuID() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM PrintForm WHERE isActive = 1 and PrintFormID = @PrintFormID and MenuID = @MenuID "
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PrintForm")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PrintFormID", _PrintFormID)
                cmdToExecute.Parameters.Add("@MenuID", _MenuID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _PrintFormID = CType(toReturn.Rows(0)("PrintFormID"), String)
                    _MenuID = CType(toReturn.Rows(0)("MenuID"), String)
                    _PrintFormCaption = CType(toReturn.Rows(0)("PrintFormCaption"), String)
                    _PrintFormSPName = CType(toReturn.Rows(0)("PrintFormSPName"), String)
                    _PrintFormAsp = CType(toReturn.Rows(0)("PrintFormAsp"), String)
                    _PrintFormFileName = CType(toReturn.Rows(0)("PrintFormFileName"), String)
                    _PrintFormFormat = CType(toReturn.Rows(0)("PrintFormFormat"), String)
                    _ParameterField = CType(toReturn.Rows(0)("ParameterField"), String)
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

        Public Sub AddParametersPrintForm(ByVal Parm As String, Optional ByVal IsClear As Boolean = False)
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

        Public Function UrlPrintForm(ByVal ContextRequestUrlHost As String, Optional ByVal ModuleName As String = "PurePOS") As String
            If Not SelectOneByPrintFormIDAndMenuID.Rows.Count > 0 Then
                Throw New Exception("Print form ID not found")
                Exit Function
            End If
            If _Parm = "" OrElse _Parm = Nothing Then
                Throw New Exception("Parameter Print form cannot empty")
                Exit Function
            End If

            If (_PrintFormFormat <> "PDF") Then
                Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + Common.HisConfiguration.ReportsFolder.Trim + _PrintFormAsp.Trim + ".asp?RptName=" + _PrintFormFileName.Trim + "&SP=" + _PrintFormSPName.Trim + "&parm=" + _Parm.Trim + "&moduleName=" + ModuleName.Trim + "','','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>"
            Else
                Return "<script language=javascript>window.open('http://" + ContextRequestUrlHost + Common.HisConfiguration.ModuleAppl + "CRReportViewer.aspx?opn=PrintForm&rpt=" + _PrintFormID.ToString.Trim + "&par=" + _Parm.Trim + "&mnu=" + _MenuID.ToString.Trim + "','','status=no,resizable=yes,toolbar=no,menubar=no,location=no,scrollbars=1')</script>"
                'Return String.Format("<script language=javascript>window.open('http://{0}/{1}/Libs/XReportViewer.aspx?id={2}&RptName={3}&parm={4}&showCriteria={5}','','status=no,resizable=yes,toolbar=no,menubar=no,location=no;')</script>", ContextRequestUrlHost, SysConfig.ModuleAppl, _reportID.Trim, _reportFileName.Trim, _Parameters.Trim, SysConfig.IsDisplayReportCriteria)
            End If
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [PrintFormID]() As Integer
            Get
                Return _PrintFormID
            End Get
            Set(ByVal Value As Integer)
                _PrintFormID = Value
            End Set
        End Property

        Public Property [MenuID]() As Integer
            Get
                Return _MenuID
            End Get
            Set(ByVal Value As Integer)
                _MenuID = Value
            End Set
        End Property

        Public Property [PrintFormCaption]() As String
            Get
                Return _PrintFormCaption
            End Get
            Set(ByVal Value As String)
                _PrintFormCaption = Value
            End Set
        End Property

        Public Property [PrintFormSPName]() As String
            Get
                Return _PrintFormSPName
            End Get
            Set(ByVal Value As String)
                _PrintFormSPName = Value
            End Set
        End Property

        Public Property [PrintFormAsp]() As String
            Get
                Return _PrintFormAsp
            End Get
            Set(ByVal Value As String)
                _PrintFormAsp = Value
            End Set
        End Property

        Public Property [PrintFormFileName]() As String
            Get
                Return _PrintFormFileName
            End Get
            Set(ByVal Value As String)
                _PrintFormFileName = Value
            End Set
        End Property

        Public Property [PrintFormFormat]() As String
            Get
                Return _PrintFormFormat
            End Get
            Set(ByVal Value As String)
                _PrintFormFormat = Value
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
