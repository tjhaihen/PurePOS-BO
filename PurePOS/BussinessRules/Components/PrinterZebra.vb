Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common
'Imports Raven.Zebra

Namespace Raven.BussinessRules


    Public Class PrinterZebra
        Inherits BRInteractionBase


        Public Function DisplayRJLabel(ByVal Noreg As String) As DataTable
            Dim cmd As New SqlCommand
            Dim tbl As New DataTable("Pasien")

            cmd.CommandText = "sprj_LabelPasien_RawatJalan"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@noreg", Noreg))

            cmd.Connection = _mainconnection

            Try
                _mainconnection.Open()
                Dim adapter As New SqlDataAdapter(cmd)

                adapter.Fill(tbl)
                Return tbl

                adapter.Dispose()
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                cmd.Dispose()
                _mainconnection.Close()
            End Try
        End Function

        Public Function GetAddressPrinter() As String
            Dim cmd As New SqlCommand

            cmd.CommandText = "sprj_GetPrintAddres"
            cmd.CommandType = CommandType.StoredProcedure


            cmd.Parameters.Add("@nmkduser", SqlDbType.Char, 50)
            cmd.Parameters("@nmkduser").Direction = ParameterDirection.Output


            cmd.Connection = _mainconnection
            Try
                _mainconnection.Open()
                cmd.ExecuteNonQuery()
                Return cmd.Parameters("@nmkduser").Value

            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainconnection.Close()
                cmd.Dispose()

            End Try
        End Function
        Public Function DisplayRJCoverLabel(ByVal noreg As String) As DataTable
            Dim cmd As New SqlCommand
            Dim tbl As New DataTable("Pasien")

            cmd.CommandText = "sprj_Labelcover_Pasien"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@noreg", noreg))

            cmd.Connection = _mainconnection

            Try
                _mainconnection.Open()
                Dim adapter As New SqlDataAdapter(cmd)

                adapter.Fill(tbl)
                Return tbl

                adapter.Dispose()
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                cmd.Dispose()
                _mainconnection.Close()
            End Try
        End Function
        Public Function ChangeSqlQuery(ByVal strSql As String) As String
            Dim cmd As New SqlCommand

            cmd.CommandText = strSql
            cmd.CommandType = CommandType.Text

            cmd.Connection = _mainconnection

            Try
                _mainconnection.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                cmd.Dispose()
                _mainconnection.Close()
            End Try
        End Function
        Public Function PrintlabelRJ(ByVal NoReg As String) As Boolean
            'Untuk Printer Zebra 

            'Dim print As New BussinessRules.PrinterZebra
            'Dim brStfield As New BussinessRules.stdfield
            'Dim prin As New Zebra.DirectPrint
            'Dim err As String
            'Dim strTest As New DataTable("Pasien")
            'Dim strTesti As String
            'Dim GetAddressPrinter, strAddressPrinter, strTemp As String
            'Dim CountPrint, i As Byte
            'strTest = DisplayRJLabel(NoReg.Trim)

            ''Untuk mendapatkan alamat Printer Zebra 
            'GetAddressPrinter = brStfield.GetValueStdfield("PrintRSOIAS", "PRSIOAS06")
            'CountPrint = brStfield.GetIntValueStdfield("COUNTPRINTZEBRA", "CPZ01")



            'Try

            '    'Jumlah print 
            '    For i = 1 To CountPrint

            '        prin.OpenPrinter(GetAddressPrinter)
            '        prin.StartDocPrinter()
            '        prin.SendLine("")
            '        prin.SendLine("^XA")
            '        prin.SendLine("^LL230")
            '        prin.SendLine("^PW824")
            '        prin.SendLine("^LH10,20^MD30")
            '        prin.SendLine("^FO0,0^ADN,16")
            '        strTemp = CType(strTest.Rows(0)("namalengkap"), String)
            '        If strTemp.Length >= 22 Then
            '            prin.SendLine("^FO25,^ADN,16^FB400,1,4,J^FD" + CType(strTest.Rows(0)("namalengkap"), String) + "^FS")
            '        Else
            '            prin.SendLine("^FO25,^ABN,22^FB400,1,4,J^FD" + CType(strTest.Rows(0)("namalengkap"), String) + "^FS")
            '        End If




            '        prin.SendLine("^FO340,25^ADN,16^FD" + "(" + Trim(strTest.Rows(0)("kdseks")) + ")" + "^FS")


            '        prin.Send("^FO25,40^ADN,16^FDTgl Lhr^FS")
            '        prin.SendLine("^FO115,40^ADN,16^FD: " + Format(strTest.Rows(0)("tgllahir"), "dd-MMMM-yyyy") + "^FS")

            '        prin.Send("^FO25,65^ADN,16^FDNoRM^FS")
            '        prin.SendLine("^FO115,65^ADN,16^FD: " + strTest.Rows(0)("norm") + "^FS")

            '        'prin.Send("^FO10,45^ABN,15^FDDokter^FS")
            '        'prin.SendLine("^FO115,45^ABN,15^FD: " + strTest.Rows(0)("namaDokter") + "^FS")

            '        prin.SendLine("^Fo25,90^ADN,16^FB350,2,2,J,^FD" + strTest.Rows(0)("alamat") + "^FS")

            '        prin.Send("^FO25,135^ADN,16^FDTelp/HP^FS")
            '        prin.SendLine("^FO115,135^ADN,16^FD: " + Trim(strTest.Rows(0)("telp")) + "^FS")

            '        prin.Send("^FO25,155^ADN,16^FDHP^FS")
            '        prin.SendLine("^FO115,155^ADN,16^FD: " + Trim(strTest.Rows(0)("hp")) + "^FS")

            '        prin.SendLine("^FO50,175^BCN,50,N,N,N^FD" + Trim(strTest.Rows(0)("norm")) + "^FS")

            '        'VERSI KE DUA 412
            '        '========================================================================================================
            '        If strTemp.Length >= 22 Then
            '            prin.SendLine("^FO430,^ADN,16^FB400,1,4,J^FD" + CType(strTest.Rows(0)("namalengkap"), String) + "^FS")
            '        Else
            '            prin.SendLine("^FO430,^ABN,22^FB400,1,4,J^FD" + CType(strTest.Rows(0)("namalengkap"), String) + "^FS")
            '        End If
            '        prin.SendLine("^FO752,25^ADN,16^FD" + "(" + Trim(strTest.Rows(0)("kdseks")) + ")" + "^FS")


            '        prin.Send("^FO430,40^ADN,16^FDTgl Lhr^FS")
            '        prin.SendLine("^FO527,40^ADN,16^FD: " + Format(strTest.Rows(0)("tgllahir"), "dd-MMMM-yyyy") + "^FS")

            '        prin.Send("^FO430,65^ADN,16^FDNoRM^FS")
            '        prin.SendLine("^FO527,65^ADN,16^FD: " + strTest.Rows(0)("norm") + "^FS")


            '        prin.SendLine("^Fo430,90^ADN,16^FB350,2,2,J,^FD" + strTest.Rows(0)("alamat") + "^FS")

            '        prin.Send("^FO430,135^ADN,16^FDTelp^FS")
            '        prin.SendLine("^FO527,135^ADN,16^FD: " + Trim(strTest.Rows(0)("telp")) + "^FS")

            '        prin.Send("^FO430,155^ADN,16^FDHP^FS")
            '        prin.SendLine("^FO527,155^ADN,16^FD: " + Trim(strTest.Rows(0)("hp") + "^FS"))

            '        prin.SendLine("^FO455,175^BCN,50,N,N,N^FD" + Trim(strTest.Rows(0)("norm")) + "^FS")

            '        prin.SendLine("")
            '        prin.SendLine("^XZ")
            '        prin.EndPagePrinter()
            '        prin.EndDocPrinter()
            '        prin.ClosePrinter()
            '    Next i
            'Catch ex As Exception
            '    ExceptionManager.Publish(ex)
            'Finally
            '    brStfield.Dispose()
            '    '  print.Dispose()
            '    prin = Nothing
            'End Try
        End Function


        Public Function PrintCoverRJ(ByVal noreg As String) As Boolean
            'Untuk Printer Zebra 

            'Dim print As New BussinessRules.PrinterZebra
            'Dim prin As New Zebra.DirectPrint
            'Dim brStfield As New BussinessRules.stdfield
            'Dim strTest As New DataTable("Pasien")
            'Dim strTesti As String
            'Dim GetAddressPrinter, strAddressPrinter As String
            'Dim CountPrint, i As Byte

            'strTest = DisplayRJCoverLabel(noreg.Trim)

            ''Untuk mendapatkan alamat Printer Zebra 

            'GetAddressPrinter = brStfield.GetValueStdfield("PrintRSOIAS", "PRSIOAS12")
            'CountPrint = brStfield.GetValueStdfield("COUNTPRINTZEBRA", "CPZ02")

            'strTesti = "(" + Trim(String.Format(strTest.Rows(0)("kdseks")).ToString) + ")"

            'Try


            '    'prin.OpenPrinter("Zebra  TLP2844-Zi")

            '    For i = 1 To CountPrint

            '        prin.OpenPrinter(GetAddressPrinter)
            '        prin.StartDocPrinter()
            '        prin.SendLine("")
            '        prin.SendLine("^XA")
            '        prin.SendLine("^LL376")
            '        prin.SendLine("^PW824")
            '        prin.SendLine("^LH20,30^MD30")
            '        prin.SendLine("^FO0,0^ABN,22")



            '        'prin.SendLine("^FO20,^ABN,33^FD" + CType(strTest.Rows(0)("nama"), String) + "^FS")
            '        prin.SendLine("^FO10,^ABN,33^FD" + strTest.Rows(0)("namalengkap") + "^FS")
            '        prin.Send("^FO720,40^ABN,22^FD" + strTesti + "^FS")

            '        prin.Send("^FO10,70^ABN,22^FDTanggal Lahir^FS")
            '        prin.SendLine("^FO300,70^ABN,22^FD: " + Format(strTest.Rows(0)("tgllahir"), "dd-MMMM-yyyy") + "^FS")

            '        prin.Send("^FO10,105^ABN,22^FDNoRM^FS")
            '        prin.SendLine("^FO300,105^ABN,22^FD: " + strTest.Rows(0)("norm") + "^FS")

            '        'prin.Send("^FO10,140^ABN,22^FDAlamat^FS")
            '        prin.SendLine("^FO10,140^ABN,22^FB780,2,4,J,^FD" + Trim(strTest.Rows(0)("alamat")) + "^FS")

            '        prin.Send("^FO10,200^ABN,22^FDTelp/HP^FS")
            '        prin.SendLine("^FO300,200^ABN,22^FD: " + Trim(strTest.Rows(0)("notelepon")) + "/" + Trim(strTest.Rows(0)("nohp")) + "^FS")

            '        prin.SendLine("^FO190,240^BCN,90,N,N,N^FD" + Trim(strTest.Rows(0)("norm")) + "^FS")
            '        ' prin.SendLine("^FO20,200^B3,N,N,7^FD" + Trim(strTest.Rows(0)("noreg")) + "^FS")
            '        'prin.SendLine("FO20,180^BCN,50,Y,N,N")
            '        'prin.SendLine("^FDRI0611080007^FS")
            '        prin.SendLine("")
            '        prin.SendLine("^XZ")
            '        prin.EndPagePrinter()
            '        prin.EndDocPrinter()
            '        prin.ClosePrinter()

            '    Next i
            'Catch ex As Exception
            '    ExceptionManager.Publish(ex)
            'Finally
            '    brStfield.Dispose()
            '    ' print.Dispose()
            '    prin = Nothing
            'End Try
        End Function


        Public Function PrintSlipJasaDokter(ByVal noreg As String) As DataTable
            Dim cmd As New SqlCommand
            Dim tbl As New DataTable("Pasien")

            cmd.CommandText = "sprjrpt_Cetak_Slip_JasaDokter_To_Print"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlParameter("@noreg", noreg))

            cmd.Connection = _mainconnection

            Try
                _mainconnection.Open()
                Dim adapter As New SqlDataAdapter(cmd)

                adapter.Fill(tbl)
                Return tbl

                adapter.Dispose()
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                cmd.Dispose()
                _mainconnection.Close()
            End Try
        End Function



    End Class
End Namespace
