Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules


    Public Class PrintCrystalReport
        Inherits BRInteractionBase

        Private _strPath, _ServerName, _DatabaseName, _UserID, _Password, _PrinterName, _parameter1, _parameter2 As String
        Private _field1, _field2 As String
        Private _IntegratedSecurity As Boolean


        'Public Sub setDBLogonForReport(ByVal ConnectionInfo As ConnectionInfo, ByVal ReportDocument As ReportDocument)
        '    'Procedure ini dibuat untuk mengakses database dengan menggunakan crystal report 

        '    'Deklarasikan nama variable dari table - tabel yang akan diakses 
        '    Dim tab As Tables = ReportDocument.Database.Tables

        '    'Membaca masing - masing table yang ada di file crystal report 
        '    For Each table As CrystalDecisions.CrystalReports.Engine.Table In tab
        '        Dim TableLogOnInfo As TableLogOnInfo = table.LogOnInfo

        '        'membaca apakah table - table sudah terkoneksi dengan database di server 
        '        TableLogOnInfo.ConnectionInfo = ConnectionInfo
        '        table.ApplyLogOnInfo(TableLogOnInfo)
        '    Next
        'End Sub
        'Public Sub PrintToCrystalDirectly(ByVal param1 As String)
        '    'Mendeklarasikan nama Documentnya 
        '    Dim crDoc As New ReportDocument
        '    Dim cr As New CrystalReportViewer
        '    Dim cfPr As New ParameterField
        '    'Dim cri As crystalre


        '    Dim parameter1 As ParameterField
        '    Dim ConnectionInfo As New ConnectionInfo
        '    Dim strPathLocal As String



        '    crDoc.Load(_strPath)

        '    'Deklarasi parameter 
        '    'crDoc.RecordSelectionFormula = "{reg.noreg}='RJ0707260001' " '-- & param1
        '    'crDoc.Refresh()

        '    ConnectionInfo.ServerName = _ServerName
        '    ConnectionInfo.DatabaseName = _DatabaseName
        '    ConnectionInfo.UserID = _UserID
        '    ConnectionInfo.Password = _Password


        '    setDBLogonForReport(ConnectionInfo, crDoc)

        '    Try
        '        cr.ReportSource = crDoc
        '        cr.SelectionFormula = "{command.noreg} = '" + param1.Trim + "'"
        '        ' cr.RefreshReport()
        '        ' crDoc.Refresh()
        '        ' crDoc.RecordSelectionFormula = "{command.noreg} = 'RJ0707260001'"
        '        'crDoc.Refresh()



        '        crDoc.PrintOptions.PrinterName = _PrinterName
        '        crDoc.PrintToPrinter(1, False, 0, 0)

        '    Catch ex As Exception
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        crDoc = Nothing

        '    End Try

        'End Sub

        'Public Sub SqlQueryPendaftaran(ByVal sqlText As String)
        '    Dim cmdToExecute As SqlCommand = New SqlCommand
        '    Dim strReturn As String

        '    cmdToExecute.CommandText = sqlText

        '    cmdToExecute.CommandType = CommandType.Text


        '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        '    ' // Use base class' connection object
        '    cmdToExecute.Connection = _mainConnection

        '    Try



        '        ' // Open connection.
        '        _mainConnection.Open()
        '        ' // Execute query.
        '        cmdToExecute.ExecuteNonQuery()
        '    Catch ex As Exception
        '        ' // some error occured. Bubble it to caller and encapsulate Exception object
        '        ExceptionManager.Publish(ex)
        '    Finally
        '        ' // Close connection.
        '        _mainConnection.Close()
        '        cmdToExecute.Dispose()
        '        adapter.Dispose()
        '    End Try
        'End Sub

        Public Function GetDomainName() As String
            'Procedure ini untuk mendapatkan Nama Domain 
            'jika tidak menggunakan procedure ini maka tidak akan mengakses file yang ada diserver 
            'Contohnya seperti ini http://192.168.0.27/prohms/rs_ namun di cover atau dibungkus menjadi C:\Inetpub\wwwroot\ProHMS\rs_
            'Tapi jika kita mengakses langsung \\192.168.0.37\wwwroot(shared Named)\prohms\rs_\ maka tidak akan di kenali oleh client 
            'ini bisa terjadi karena ini merupakan aplikasi web base makanya semuanya harus menggunakan cara di web.

            Dim strDomain As String
            Dim chrTemp, chrStep As Char
            Dim intCounter, strLength As Byte

            'ini merupakan syntax untuk mendapatkan domain secara lengkap 
            strDomain = AppDomain.CurrentDomain.BaseDirectory.ToString.Trim
            'Misalnya akan tampak hasil seperti ini http://192.168.0.37(NamaServernya)/prohms/rj_/

            'hitung berapa panjang karakter domain 
            strLength = strDomain.Length

            'Selanjutnya hapus nilai(nama) module dan rumah sakit hingga mendapatkan namaservernya saja 
            'hitung tiap karakter dimulai dari karakter yang paling belakang 
            For Each chrStep In strDomain
                'simpan nilai untuk masing - masing karakter 
                chrTemp = Mid(strDomain, strLength, 1)

                'Kurangi panjang karakter hingga karakter terakhir 
                strLength = strLength - 1

                'Jika menemukan karakter "/" maka dianggap batasnya 
                If chrTemp = "/" Then
                    'Tambahkan nilai counter hingga tiga atau hingga mendapatkan nama server 
                    intCounter = intCounter + 1

                    'Jika sudah mencapai 3 atau server maka harus keluar dari perulangan 
                    If intCounter >= 3 Then
                        Exit For
                    End If

                End If
            Next

            'Sekarang tinggal dipotong berapa karakter besarnya sampainya dengan nama server 
            strDomain = Left(strDomain, strLength)

            Return strDomain

        End Function

#Region "Declaration Variable "


        Public Property strPath() As String
            Get
                Return _strPath
            End Get
            Set(ByVal Value As String)
                Dim strPathTemp As String = Value
                If strPathTemp = "" Then
                    Throw New ArgumentOutOfRangeException("strPath", "Letak File Report tidak ditemukan atau Null")
                End If
                _strPath = Value
            End Set
        End Property



        Public Property ServerName() As String
            Get
                Return _ServerName
            End Get
            Set(ByVal Value As String)
                Dim ServerNameTemp As String = Value
                If ServerNameTemp = "" Then
                    Throw New ArgumentOutOfRangeException("ServerName", "Nama server belum ada atau kosong")
                End If
                _ServerName = Value
            End Set
        End Property

        Public Property DatabaseName() As String
            Get
                Return _DatabaseName
            End Get
            Set(ByVal Value As String)
                Dim DatabaseNameTemp As String = Value
                If DatabaseNameTemp = "" Then
                    Throw New ArgumentOutOfRangeException("DatabaseName", "Nama Database belum ada atau kosong")
                End If
                _DatabaseName = Value
            End Set
        End Property

        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                Dim UserIDTemp As String = Value
                If UserIDTemp = "" Then
                    Throw New ArgumentOutOfRangeException("UserID", "User ID belum ada atau kosong")
                End If
                _UserID = Value
            End Set
        End Property

        Public Property PrinterName() As String
            Get
                Return _PrinterName
            End Get
            Set(ByVal Value As String)
                Dim PrinterNameTemp As String = Value
                If PrinterNameTemp = "" Then
                    Throw New ArgumentOutOfRangeException("PrinterName", "Nama printer belum ada atau kosong")
                End If
                _PrinterName = Value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return _Password
            End Get
            Set(ByVal Value As String)
                Dim PasswordTemp As String = Value
                If PasswordTemp = "" Then
                    Throw New ArgumentOutOfRangeException("_Password", "Password belum ada atau kosong")
                End If
                _Password = Value
            End Set
        End Property

        Public Property IntegratedSecurity() As Boolean
            Get
                Return _IntegratedSecurity
            End Get
            Set(ByVal Value As Boolean)
                _IntegratedSecurity = Value
            End Set
        End Property

        Public Property Parameter1() As String
            Get
                Return _parameter1
            End Get
            Set(ByVal Value As String)
                Dim ParameterTmp As String = Value
                If ParameterTmp = "" Then
                    Throw New ArgumentOutOfRangeException("Parameter1", "Parameter1 belum ada atau kosong")
                End If
                _parameter1 = Value

            End Set
        End Property

        Public Property Parameter2() As String
            Get
                Return _parameter2
            End Get
            Set(ByVal Value As String)
                Dim ParameterTmp As String = Value
                If ParameterTmp = "" Then
                    Throw New ArgumentOutOfRangeException("Parameter2", "Parameter2 belum ada atau kosong")
                End If
                _parameter2 = Value

            End Set
        End Property

        Public Property Field1() As String
            Get
                Return _field1
            End Get
            Set(ByVal Value As String)
                Dim ParameterTmp As String = Value
                If ParameterTmp = "" Then
                    Throw New ArgumentOutOfRangeException("Field1", "Field1 belum ada atau kosong")
                End If
                _field1 = Value

            End Set
        End Property

        Public Property Field2() As String
            Get
                Return _field2
            End Get
            Set(ByVal Value As String)
                Dim ParameterTmp As String = Value
                If ParameterTmp = "" Then
                    Throw New ArgumentOutOfRangeException("Field2", "Field2 belum ada atau kosong")
                End If
                _field2 = Value

            End Set
        End Property
#End Region
    End Class

End Namespace

