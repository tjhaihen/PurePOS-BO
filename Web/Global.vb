Option Explicit On
Option Strict On

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Math
Imports Telerik.Web.UI
Imports Microsoft.VisualBasic

Imports System.Data.SqlTypes
Imports System.Security.Cryptography

Imports Raven.Common


Namespace Raven.Web

    Public NotInheritable Class SearchData
        Public Const QUERYSTRING_RETURNURL As String = "returnUrl"
        Public Const QUERYSTRING_BROWSETYPE As String = "bt"
        Public Const QUERYSTRING_CTRLID As String = "ctrlid"
        Public Const QUERYSTRING_FIELDNAME As String = "fn"
        Public Const QUERYSTRING_FIELDNAME1 As String = "fn1"
        Public Const QUERYSTRING_SEARCHVALUE As String = "sv"
        Public Const QUERYSTRING_SEARCHRESULT As String = "sr"
        Public Const QUERYSTRING_SEARCHRESULT2 As String = "sr2"
        Public Const QUERYSTRING_ISOK As String = "status"

        Public Const BROWSETYPE_BANK As String = "rj_bank1"
        Public Const BROWSETYPE_AHLI As String = "rj_ahli"
        Public Const BROWSETYPE_NOBUKTI As String = "rj_nobukti1"
        Public Const BROWSETYPE_MEDIS As String = "rj_kddokter1"
        Public Const BROWSETYPE_MEDISRI As String = "rj_kddokterri1"
        Public Const BROWSETYPE_MEDISRJ As String = "rj_kddokterrj1"
        Public Const BROWSETYPE_REGISTRASIKB As String = "rj_regkb1"
        Public Const BROWSETYPE_TARIFGROUP As String = "rj_tarif1"
        Public Const BROWSETYPE_TARIFPELAYANAN As String = "rj_tarif2"
        Public Const BROWSETYPE_GROUPJASAMEDIS As String = "rj_grpjasamedis1"
        Public Const BROWSETYPE_JASAMEDIK As String = "rj_jasa1"
        Public Const BROWSETYPE_MASTEROBAT As String = "rj_obat1"
        Public Const BROWSETYPE_PASIEN As String = "rj_pasien1"
        Public Const BROWSETYPE_POLIKLINIK As String = "rj_poli1"
        Public Const BROWSETYPE_POLIKLINIKAKTIF As String = "rj_poli2"
        Public Const BROWSETYPE_KODEPOS As String = "rj_kdpos1"
        Public Const BROWSETYPE_SMF As String = "rj_smf1"
        Public Const BROWSETYPE_TINDAKAN As String = "rj_tindakan1"
        Public Const BROWSETYPE_INSTANSI As String = "rj_instansi1"
        Public Const BROWSETYPE_GROUPPOLIKLINIK As String = "rj_GroupPoliklinik"
        Public Const BROWSETYPE_PLAFON As String = "rj_plafon1"
        Public Const BROWSETYPE_GUDANG As String = "rj_gudang1"
        Public Const BROWSETYPE_KELAS As String = "rj_kelas1"
        Public Const BROWSETYPE_DIAGNOSA As String = "rj_diagnosa1"
        Public Const BROWSETYPE_MORFOLOGI As String = "rj_morfologi1"
        Public Const BROWSETYPE_MEMBER As String = "rj_member1"
        Public Const BROWSETYPE_DTD As String = "rj_dtd1"
        Public Const BROWSETYPE_NOMORREKAMMEDIS As String = "rj_nomorrm1"
        Public Const BROWSETYPE_PROSESPIUTANGI As String = "rj_ppi1"
        Public Const BROWSETYPE_PROSESPIUTANGP As String = "rj_ppp1"
        Public Const BROWSETYPE_PELAYANAN2 As String = "rj_ply2"
        Public Const BROWSETYPE_APPOINTMENT As String = "rj_app1"
        Public Const BROWSETYPE_APPOINTMENTWITHNORM As String = "rj_app2"
        Public Const BROWSETYPE_APPOINTMENTWITHOUTNORM As String = "rj_app3"
        Public Const BROWSETYPE_PAKETTARIF As String = "rj_pkttarif1"
        Public Const BROWSETYPE_KDNKELUAR As String = "rj_kdnklr1"
        Public Const BROWSETYPE_CARAKELUAR As String = "rj_crklr1"
        Public Const BROWSETYPE_TDKLANJUT As String = "rj_tdklanjut"
        Public Const BROWSETYPE_DOKTERANS As String = "rj_dra1"
        Public Const BROWSETYPE_DOKTERPERPOLI As String = "dokterperpoli"
        Public Const BROWSETYPE_DOKTERPERPOLIPERTGL As String = "dokterperpolipertgl"
        Public Const BROWSETYPE_POLIPERDOKTER As String = "poliperdokter"
        Public Const BROWSETYPE_PENGIRIM As String = "rj_pgm1"
        Public Const BROWSETYPE_REGTDKBTL As String = "rj_rtb1"
        Public Const BROWSETYPE_REGISTRASI As String = "rj_reg1"
        Public Const BROWSETYPE_REGISTRASIMD As String = "rj_regmd1"
        Public Const BROWSETYPE_KASUS As String = "rj_kasus1"
        Public Const BROWSETYPE_CLOSEREGISTRASI As String = "rj_regclose1"
        Public Const BROWSETYPE_TRANSHD As String = "rj_trhd1"
        Public Const BROWSETYPE_MTXDIAGPOLI As String = "rj_dp1"
        Public Const BROWSETYPE_BYRPIUTINS As String = "bs1"
        Public Const BROWSETYPE_BYRPIUTPBD As String = "bd1"
        Public Const BROWSETYPE_PASIENPIUTANG As String = "piutpbd1"
        Public Const BROWSETYPE_INSTANSIPIUTANG As String = "piutins1"
        Public Const BROWSETYPE_INSTANSIOUTSTANDING As String = "io1"
        Public Const BROWSETYPE_PASIENOUTSTANDING As String = "po1"
        Public Const BROWSETYPE_NOBUKTITRANSPAKET As String = "rj_nbtp1"
        Public Const BROWSETYPE_NOBUKTITRANSPAKET2 As String = "nbtp2"
        Public Const BROWSETYPE_MTXLAYANPOLI As String = "layanpoli"
        Public Const BROWSETYPE_MTXOBATPOLI As String = "obatpoli"
        Public Const BROWSETYPE_POLIKLINIKTRHD As String = "politrhd"
        Public Const BROWSETYPE_PNJMEDIS As String = "pnjmedis"
        Public Const BROWSETYPE_MTXLAYANPNJ As String = "layanpnj"
        Public Const BROWSETYPE_MTXOBATPNJ As String = "obatpnj"
        Public Const BROWSETYPE_PAKETTINDAKANRJMTX As String = "md_paketmtx"
        Public Const BROWSETYPE_SISATAGIHAN As String = "bayarreg"
        Public Const BROWSETYPE_PEMBAYARAN As String = "bayar"
        Public Const BROWSETYPE_PEMBAYARANBYNOREG As String = "bayarbynoreg"
        Public Const BROWSETYPE_JASAMEDISALL As String = "jasamedis"
        Public Const BROWSETYPE_ATURAN As String = "atur"
        Public Const BROWSETYPE_ITEMPERGUDANGLOKASI As String = "obatgdlk"
        Public Const BROWSETYPE_REGTB As String = "rj_regtb1"
        Public Const BROWSETYPE_TEST As String = "test"
        Public Const BROWSETYPE_MTXLOGISTIKPOLI As String = "logistikrj"
        Public Const BROWSETYPE_MTXLOGISTIKPNJ As String = "logistikpnj"
        Public Const BROWSETYPE_PEGAWAI As String = "pg_pg1"

        Public Const BROWSETYPE_SUKU As String = "suku"
        Public Const BROWSETYPE_PROPINSI As String = "propinsi"
        Public Const BROWSETYPE_PEKERJAAN As String = "pekerjaan"
        Public Const BROWSETYPE_PENDIDIKAN As String = "pendidikan"
        Public Const BROWSETYPE_AGAMA As String = "agama"
        Public Const BROWSETYPE_STATUSKAWIN As String = "statuskawin"
        Public Const BROWSETYPE_KEWARGANEGARAAN As String = "kewarganegaraan"
        Public Const BROWSETYPE_JENISDIAGNOSA As String = "jenisdiagnosa"
        Public Const BROWSETYPE_JENISKASUS As String = "jeniskasus"

        Public Const BROWSETYPE_TRANSAKSI As String = "rj_trans"

        Public Const BROWSETYPE_NOBATCHBYKDITEM As String = "nobatchbykditem"
        Public Const BROWSETYPE_AKTIVA As String = "fa_ak1"

        Public Const BROWSETYPE_NOJOBYNOREG As String = "rj_njo"

        Public Const BROWSETYPE_GROUP As String = "lb_gr1"
        Public Const BROWSETYPE_ANGGOTAINST As String = "anginst"
    End Class

    Public NotInheritable Class App
        Public Const App_Outpatient As String = "RJ_"
    End Class

    Public NotInheritable Class commonFunction
        '
        '   Cache Name
        '

        Public Const Key_CacheLoggedOnUser As String = "CacheLoggedOnUser"
        Public Const Key_CacheErrorMessage As String = "ErrorMessage"

        Public Const KEY_CACHEUSER As String = "Cache:LoggedOnUser:"
        Public Const KEY_CACHEBROWSE_KEYFIELD As String = "Cache:BrowseKeyField:"
        Public Const KEY_CACHEBROWSE_DESCFIELD As String = "Cache:BrowseDescField:"

        Public Const KEY_CACHEBROWSE_USERTYPE As String = "Cache:BrowseUserType:"
        Public Const KEY_CACHEBROWSE_ISOK As String = "Cache:BrowseIsOK:"
        Public Const KEY_CACHEBROWSE_CTRLID As String = "Cache:BrowseCtrlID:"
        Public Const KEY_CACHEBROWSE_SEARCHRESULT As String = "Cache:BrowseSearchResult:"
        Public Const KEY_CACHEBROWSE_SEARCHRESULT2 As String = "Cache:BrowseSearchResult2:"

        Public Const CACHE_FORMNAME_APP As String = "appointment"

        Public Const KEY_CACHEFORM_NOAPP As String = "Cache:Form:App:Noapp:"
        Public Const KEY_CACHEFORM_NAME As String = "Cache:Form:Name:"

        'untuk session pada appointment yang direfer ke registrasi
        Public Const KEY_CACHEFORM_SHIFT As String = "Cache:Shift"
        Public Const KEY_CACHEFORM_NOANTRIAN As String = "Cache:NoAntrian"
        Public Const KEY_CACHEFORM_TGLAPP As String = "Cache:TglAntrian"


        Public Const CACHE_DEFAULTVALUE_REG As String = "Cache:DefaultValueReg"
        Public Const CACHE_NORMFROMPASIEN As String = "Cache:NormFromPasien"
        Public Const CACHE_NOREGFROMREGISTRATION As String = "Cache:NoregFromRegistration"
        Public Const CACHE_NOMEMBERFROMREGISTRATION As String = "Cache:NoMemberFromRegistration"
        Public Const CACHE_NORMFROMREGISTRATION As String = "Cache:NormFromRegistration"

        Public Const CACHE_CETAKKWITANSI As String = "Cache:CetakKwitansi"
        Public Const CACHE_TABLEKWITANSI As String = "Cache:TableKwitansi"

        '
        '   Row Navigator
        '
        Public Const rowPositionFirst As String = "First"
        Public Const rowPositionPrevious As String = "Previous"
        Public Const rowPositionNext As String = "Next"
        Public Const rowPositionLast As String = "Last"

        Public Const rowOpenCommand As String = "Open"
        Public Const rowSaveCommand As String = "Save"
        Public Const rowDeleteCommand As String = "Delete"
        Public Const rowVoidCommand As String = "Void"
        Public Const rowNewCommand As String = "New"
        Public Const rowRefreshCommand As String = "Refresh"
        Public Const rowPrintCommand As String = "Print"

        Public Const FORMAT_DATE As String = "dd-MM-yyyy"
        Public Const FORMAT_TIME As String = "hh:mm"
        Public Const FORMAT_CURRENCY As String = "#,##0.00"
        Public Const FORMAT_QTY As String = "#,##0.000"
        Public Const MaxRecord As String = "500"

        Public Const MSG_ACCESS_DENIED As String = "ACCESS DENIED<br/>You might not have permission to view this directory or page.<br/>If you believe you should be able to view this directory or page, please contact your System Administrator."
        Public Const MSG_CONFIRM_DELETE As String = "return confirm('Record will be deleted. Are you sure?');"
        Public Const MSG_CONFIRM_VOID As String = "return confirm('Record will be void. Are you sure?');"
        Public Const MSG_CONFIRM_SAVE As String = "return confirm('Record will be saved. Are you sure?');"

        Public Const MSG_NEW As String = "You have choose to create new record. You will lose any unsaved record. Are you sure?"
        Public Const MSG_SAVE As String = "Do you want to save this record?"
        Public Const MSG_DELETE As String = "Do you want to delete this record?"
        Public Const MSG_APPROVE As String = "Do you want to approve this record?"
        Public Const MSG_VOID As String = "Do you want to void this record?"
        Public Const MSG_PRINT As String = "Do you want to print this record?"
        Public Const MSG_REFRESH As String = "Do you want to refresh this page?"

        Public Const EqualSL As String = "[equ]"
        Public Const QuoteSL As String = "[quo]"

        Public Shared Function ValidateSerialNo() As Boolean
            Dim RetVal As Boolean = False
            Dim oCom As New BussinessRules.Company

            Dim strCompanyName As String = String.Empty
            Dim strCompanyAddress As String = String.Empty
            Dim strSerialNo As String = String.Empty

            oCom.SelectOne()
            strCompanyName = oCom.CompanyName.Trim
            strCompanyAddress = oCom.PrimaryAddress.Trim

            ' Initialize the keyed hash object using the secret key as the key
            Dim hashObject As New HMACSHA256(Encoding.UTF8.GetBytes(strCompanyName + strCompanyAddress))

            ' Computes the signature by hashing the salt with the secret key as the key
            Dim signature As Byte() = hashObject.ComputeHash(Encoding.UTF8.GetBytes(strCompanyName + strCompanyAddress))

            ' Base 64 Encode
            Dim encodedSignature As String = Convert.ToBase64String(signature)

            If encodedSignature.Trim = oCom.SerialNo Then
                RetVal = True
            Else
                RetVal = False
            End If

            Return RetVal
        End Function

        Public Shared Function ValidateNoRM(ByVal norm As String) As Boolean
            Dim osv As New Common.SetVar
            Dim formatnorm As String = osv.GetValue("format_norm", "RS_")
            Dim RetVal As Boolean = False
            Dim CheckInt As Integer

            Dim str1 As String = String.Empty

            Select Case formatnorm.Trim
                Case "99-99-99-99"
                    str1 = norm.Remove(2, 1)
                    str1 = str1.Remove(4, 1)
                    str1 = str1.Remove(6, 1)
                Case "999-999-999"
                    str1 = norm.Remove(3, 1)
                    str1 = str1.Remove(6, 1)
            End Select

            norm = str1

            CheckInt = CInt(Val(norm))
            If CheckInt <> 0 Then
                RetVal = True
            End If

            Return RetVal
        End Function

        Private Shared Function GetUpdateColumnText(ByVal grd As DataGrid) As String
            Dim col As DataGridColumn
            Dim colEdit As EditCommandColumn
            For Each col In grd.Columns
                If col.GetType.Name.Equals("EditCommandColumn") Then
                    colEdit = CType(col, EditCommandColumn)
                    Return colEdit.UpdateText
                End If
            Next
        End Function

        Public Shared Function [CDate](ByVal [Date] As String, Optional ByVal [format] As String = "dd-MM-yyyy") As Date
            Try
                Select Case [format]
                    Case "dd-MM-yyyy"
                        Return DateSerial(Convert.ToInt32([Date].Substring(6, 4)), Convert.ToInt32([Date].Substring(3, 2)), Convert.ToInt32([Date].Substring(0, 2)))
                    Case "yyyyMMdd"
                        Return DateSerial(Convert.ToInt32([Date].Substring(0, 4)), Convert.ToInt32([Date].Substring(4, 2)), Convert.ToInt32([Date].Substring(6, 2)))
                End Select
            Catch
                Return Date.Now
            End Try
        End Function

        Public Shared Function DStr(ByVal [date] As Date) As String
            Return Format([date], "yyyyMMdd")
        End Function

        Public Shared Function SelectListItem(ByRef list As DropDownList, ByVal value As String) As Boolean
            '
            '   unselect listItem
            '
            Try
                list.SelectedItem.Selected = False
            Catch e As Exception
            End Try

            Try
                list.Items.FindByValue(ProcessNull.GetString(value)).Selected = True
                Return True
            Catch e As Exception
                System.Diagnostics.Debug.WriteLine(e.Message)
                Return False
            End Try
        End Function


        Public Shared Sub SetUpdateCommandCausesValidation(ByVal grd As DataGrid, ByVal item As DataGridItem, ByVal fEnable As Boolean)
            Dim ctrl As Control
            Dim btn As Control
            If item.HasControls Then
                For Each ctrl In item.Controls
                    If ctrl.HasControls Then
                        For Each btn In ctrl.Controls
                            If btn.GetType.Name.Equals("DataGridLinkButton") Then
                                Dim lnkBtn As LinkButton = CType(btn, LinkButton)
                                If lnkBtn.Text.Equals(GetUpdateColumnText(grd)) Then
                                    lnkBtn.CausesValidation = fEnable
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        End Sub

        Public Shared Sub ShowPanel(ByRef panel As Panel, ByVal visible As Boolean)
            Dim validator As IValidator
            Dim ctrl As Control

            For Each ctrl In panel.Controls
                If TypeOf ctrl Is IValidator Then
                    validator = CType(ctrl, IValidator)
                    ctrl.Visible = visible
                    If Not visible Then
                        validator.Validate()
                    End If
                End If
            Next
            panel.Visible = visible
        End Sub

        Public Shared Sub SetDropDownLisToApp(ByVal list As DropDownList, Optional ByVal fIncludeSep As Boolean = True)
            With list
                .Items.Clear()

                Dim i As Integer = 1

                If fIncludeSep Then
                    .Items.Add(New ListItem("   ", "none"))
                End If
                .Items.Add(New ListItem("Rawat Jalan", "RJ_"))
                .Items.Add(New ListItem("Rawat Inap", "RI_"))
                .Items.Add(New ListItem("Farmasi", "FM_"))
                .Items.Add(New ListItem("Laboratorium", "LB_"))
            End With
        End Sub

        Public Shared Sub SetDropDownLisToStdData(ByVal list As DropDownList, ByVal kdField As String, Optional ByVal fIncludeSep As Boolean = True)
            Dim obj As New BussinessRules.stdfield

            obj.Kdfield = New SqlString(kdField)

            Dim dt As DataTable = obj.SelectByKdField
            Dim TotalRowCount As Integer = dt.Rows.Count
            Dim defItem As String = String.Empty

            If TotalRowCount > 0 Then
                With list
                    Dim i As Integer = 1

                    .Items.Clear()

                    If fIncludeSep Then
                        .Items.Add(New ListItem("", "none"))
                    End If

                    Do While i <= TotalRowCount
                        If Common.ProcessNull.GetBoolean(dt.Rows(i - 1)("Aktif")) = True Then
                            .Items.Add(New ListItem(Common.ProcessNull.GetString(dt.Rows(i - 1)("nmkduser")), Common.ProcessNull.GetString(dt.Rows(i - 1)("kduser"))))
                        End If
                        If Common.ProcessNull.GetBoolean(dt.Rows(i - 1)("isDefault")) = True Then
                            defItem = Common.ProcessNull.GetString(dt.Rows(i - 1)("kduser"))
                        End If

                        i += 1
                    Loop
                End With
                commonFunction.SelectListItem(list, defItem.Trim)
            End If

            dt.Dispose()
            dt = Nothing
            obj.Dispose()
            obj = Nothing
        End Sub

        Public Shared Function InsertScriptHitungUmur_aaaa(ByVal calTglLahir As Raven.Web.calendarModule2, ByVal txtUmurTahun As TextBox, ByVal txtUmurBulan As TextBox, ByVal txtUmurHari As TextBox) As Text.StringBuilder
            Dim scriptUpdateUmur As New Text.StringBuilder
            Dim scriptUpdateTgl As New Text.StringBuilder

            With scriptUpdateUmur
                .Append("<script type=""text/javascript"">" + Environment.NewLine)

                .Append("function calAge(cal) {" + Environment.NewLine)
                .Append("UpdateUmur(cal.date.getFullYear(),cal.date.getMonth()+1,cal.date.getDate());" + Environment.NewLine)
                .Append("}" + Environment.NewLine)

                .Append("</script>" + Environment.NewLine)

                .Append("<SCRIPT LANGUAGE=vbscript>" + Environment.NewLine)
                .Append("<!--" + Environment.NewLine)

                .Append("function UpdateUmur(y,m,d)" + Environment.NewLine)
                .Append("dim dtToday, dtBirthDay" + Environment.NewLine)
                .Append("dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)
                .Append("dtToday = Now" + Environment.NewLine)
                .Append("dtBirthDay = DateSerial(y,m,d)" + Environment.NewLine)
                .Append("intAgeInYears = Year(dtToday)-year(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInMonths = Month(dtToday)-month(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInDays = day(dtToday)-day(dtBirthDay)" + Environment.NewLine)

                .Append("if (intAgeInDays<0) then" + Environment.NewLine)
                .Append("intAgeInDays = intAgeInDays+day(dtToday-day(dtToday))" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if (intAgeInMonths<0) then" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths+12" + Environment.NewLine)
                .Append("intAgeInYears = intAgeInYears-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)

                .Append("end function" + Environment.NewLine)

                .Append("sub UpdateUmur2" + Environment.NewLine)
                .Append("On Error Resume Next" + Environment.NewLine)
                .Append("Dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInYears = cint(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInMonths = CInt(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInDays = cint(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if intAgeInDays>31 then " + Environment.NewLine)
                .Append("intAgeInDays=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInMonths>11 then " + Environment.NewLine)
                .Append("intAgeInMonths=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInYears>120 then " + Environment.NewLine)
                .Append("intAgeInYears=17" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("If intAgeInYears >= 0 And intAgeInYears <= 120 Then" + Environment.NewLine)
                .Append("Dim dtTglLahir" + Environment.NewLine)
                .Append("Dim iYear, iMonth, iDay " + Environment.NewLine)
                .Append("dim selDay, selMonth, selYear" + Environment.NewLine)
                .Append("dim fDate" + Environment.NewLine)

                .Append("iYear = Year(Now) - intAgeInYears" + Environment.NewLine)
                .Append("iMonth = month(dateadd(" + """" + "m" + """" + ", -intAgeInMonths, now)) 'iMonth = Month(Month(Now)-intAgeInMonths)" + Environment.NewLine)
                .Append("iDay = Day(Now) - intAgeInDays" + Environment.NewLine)

                .Append("if len(iday)=1  then" + Environment.NewLine)
                .Append("fdate=" + """" + "0" + """" + "+cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else" + Environment.NewLine)
                .Append("fdate=cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if len(iMonth)=1 then" + Environment.NewLine)
                .Append("fdate=fdate+" + """" + "0" + """" + "+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else " + Environment.NewLine)
                .Append("fdate=fdate+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("fdate=fdate+cstr(iYear)" + Environment.NewLine)

                .Append("document.getElementById(" + """" + calTglLahir.FindControl("txtPopUpCal").ClientID + """" + ").value=fdate" + Environment.NewLine)

                .Append("End If" + Environment.NewLine)
                .Append("end sub" + Environment.NewLine)
                .Append("//-->" + Environment.NewLine)
                .Append("</SCRIPT>" + Environment.NewLine)
            End With

            Return scriptUpdateUmur
        End Function

        Public Shared Function InsertScriptHitungUmur(ByVal calTglLahir As Raven.Web.calendarModule2, ByVal txtUmurTahun As TextBox, ByVal txtUmurBulan As TextBox, ByVal txtUmurHari As TextBox) As Text.StringBuilder
            Dim scriptUpdateUmur As New Text.StringBuilder
            Dim scriptUpdateTgl As New Text.StringBuilder

            With scriptUpdateUmur
                .Append("<script type=""text/javascript"">" + Environment.NewLine)

                .Append("function calAge(cal) {" + Environment.NewLine)
                .Append("UpdateUmur(cal.date.getFullYear(),cal.date.getMonth()+1,cal.date.getDate());" + Environment.NewLine)
                .Append("}" + Environment.NewLine)

                .Append("</script>" + Environment.NewLine)

                .Append("<SCRIPT LANGUAGE=vbscript>" + Environment.NewLine)
                .Append("<!--" + Environment.NewLine)

                .Append("function UpdateUmur(y,m,d)" + Environment.NewLine)
                .Append("dim dtToday, dtBirthDay" + Environment.NewLine)
                .Append("dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)
                .Append("dtToday = Now" + Environment.NewLine)
                .Append("dtBirthDay = DateSerial(y,m,d)" + Environment.NewLine)
                .Append("intAgeInYears = Year(dtToday)-year(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInMonths = Month(dtToday)-month(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInDays = day(dtToday)-day(dtBirthDay)" + Environment.NewLine)

                .Append("if (intAgeInDays<0) then" + Environment.NewLine)
                .Append("intAgeInDays = intAgeInDays+day(dtToday-day(dtToday))" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if (intAgeInMonths<0) then" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths+12" + Environment.NewLine)
                .Append("intAgeInYears = intAgeInYears-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)

                .Append("end function" + Environment.NewLine)

                .Append("sub UpdateUmur2" + Environment.NewLine)
                .Append("On Error Resume Next" + Environment.NewLine)
                .Append("Dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInYears = cint(document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInMonths = CInt(document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if IsNumeric(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value) then" + Environment.NewLine)
                .Append("intAgeInDays = cint(document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value)" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if intAgeInDays>31 then " + Environment.NewLine)
                .Append("intAgeInDays=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInMonths>11 then " + Environment.NewLine)
                .Append("intAgeInMonths=1" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("if intAgeInYears>120 then " + Environment.NewLine)
                .Append("intAgeInYears=17" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("End If " + Environment.NewLine)

                .Append("If intAgeInYears >= 0 And intAgeInYears <= 120 Then" + Environment.NewLine)
                .Append("Dim dtTglLahir" + Environment.NewLine)
                .Append("Dim iYear, iMonth, iDay " + Environment.NewLine)
                .Append("dim selDay, selMonth, selYear" + Environment.NewLine)
                .Append("dim fDate" + Environment.NewLine)

                .Append("iYear = Year(Now) - intAgeInYears" + Environment.NewLine)
                .Append("iMonth = month(dateadd(" + """" + "m" + """" + ", -intAgeInMonths, now)) 'iMonth = Month(Month(Now)-intAgeInMonths)" + Environment.NewLine)
                .Append("iDay = Day(Now) - intAgeInDays" + Environment.NewLine)

                .Append("if len(iday)=1  then" + Environment.NewLine)
                .Append("fdate=" + """" + "0" + """" + "+cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else" + Environment.NewLine)
                .Append("fdate=cstr(iday)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if len(iMonth)=1 then" + Environment.NewLine)
                .Append("fdate=fdate+" + """" + "0" + """" + "+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("else " + Environment.NewLine)
                .Append("fdate=fdate+cstr(iMonth)+" + """" + "-" + """" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("fdate=fdate+cstr(iYear)" + Environment.NewLine)

                .Append("document.getElementById(" + """" + calTglLahir.FindControl("txtPopUpCal").ClientID + """" + ").value=fdate" + Environment.NewLine)

                .Append("End If" + Environment.NewLine)
                .Append("end sub" + Environment.NewLine)


                .Append("function calChange()" + Environment.NewLine)
                .Append("dim dtToday, dtBirthDay, strDate" + Environment.NewLine)
                .Append("dim intAgeInMonths, intAgeInYears, intAgeInDays" + Environment.NewLine)
                .Append("strDate=document.getElementById(" + """" + calTglLahir.FindControl("txtPopUpCal").ClientID + """" + ").value" + Environment.NewLine)
                .Append("dtToday = Now" + Environment.NewLine)
                .Append("dtBirthDay = DateSerial(Right(strDate,4),right(left(strDate,5),2),Left(strDate,2))" + Environment.NewLine)
                .Append("intAgeInYears = Year(dtToday)-year(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInMonths = Month(dtToday)-month(dtBirthDay)" + Environment.NewLine)
                .Append("intAgeInDays = day(dtToday)-day(dtBirthDay)" + Environment.NewLine)

                .Append("if (intAgeInDays<0) then" + Environment.NewLine)
                .Append("intAgeInDays = intAgeInDays+day(dtToday-day(dtToday))" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("if (intAgeInMonths<0) then" + Environment.NewLine)
                .Append("intAgeInMonths = intAgeInMonths+12" + Environment.NewLine)
                .Append("intAgeInYears = intAgeInYears-1" + Environment.NewLine)
                .Append("end if" + Environment.NewLine)

                .Append("document.getElementById(" + """" + txtUmurTahun.ClientID + """" + ").value=cstr(intAgeInYears)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurBulan.ClientID + """" + ").value=cstr(intAgeInMonths)" + Environment.NewLine)
                .Append("document.getElementById(" + """" + txtUmurHari.ClientID + """" + ").value=cstr(intAgeInDays)" + Environment.NewLine)

                .Append("end function" + Environment.NewLine)


                .Append("//-->" + Environment.NewLine)
                .Append("</SCRIPT>" + Environment.NewLine)
            End With

            Return scriptUpdateUmur
        End Function

        Public Shared Sub MsgBox(ByVal AspxPage As Page, ByVal Msg As String)
            AspxPage.RegisterStartupScript("__MsgBox", "<script language='javascript'>alert('" + Msg.Replace("'", "").ToString + "');</script>")
        End Sub

        Public Shared Sub Focus(ByVal AspxPage As Page, ByVal ControlID As String)
            AspxPage.RegisterStartupScript("__Focus", "<script language='javascript'>document.getElementById('" + ControlID + "').focus();document.getElementById('" + ControlID + "').select();</script>")
        End Sub

        Public Shared Function ExistBirth(ByVal strmessage As String, ByVal txtObject As TextBox) As Text.StringBuilder


            Dim scriptConfirm As New Text.StringBuilder

            With scriptConfirm
                .Append("<script language='javascript'>" + Environment.NewLine)
                .Append("" + Environment.NewLine)
                .Append("" + Environment.NewLine)
                .Append(" " + Environment.NewLine)
                .Append("if (confirm( '" + strmessage + "')) " + Environment.NewLine)
                .Append("           window.document.getElementById('txtGetBirth').value = '1' " + Environment.NewLine)
                .Append("else " + Environment.NewLine)
                .Append("           window.document.getElementById('txtGetBirth').value = '2' " + Environment.NewLine)
                .Append("" + Environment.NewLine)
                .Append("" + Environment.NewLine)
                .Append("" + Environment.NewLine)
                .Append("</script>" + Environment.NewLine)

                '.Append("<script language='javascript'>" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("" + Environment.NewLine)
                '.Append("</script>" + Environment.NewLine)
            End With

            Return scriptConfirm
        End Function

        Public Shared Sub ConfirmText(ByVal AspxPage As Page, ByVal msg As String, ByVal c As WebControl)

            Dim ter As Boolean

            'AspxPage.RegisterStartupScript("__Confirm", "<script language='javascript'>var conf;   conf = window.confirm('" + msg + "'); if(conf) {  window.alert('Anda mengklik Oke " + Tekan.Replace("N", "Y").ToString + "'); __doPostBack('" + Teks + "',''); } else {window.alert('Anda Mengatakan Tidak');}   </script>")
            ter = AspxPage.IsClientScriptBlockRegistered("__Confirm")
            'If (Not AspxPage.IsClientScriptBlockRegistered("__Confirm")) Then
            'AspxPage.RegisterStartupScript("__Confirm", "<script language='javascript'>var conf ; " & vbCrLf & _
            '" " & vbCrLf & _
            '" conf = window.confirm('" + msg + "'); " & vbCrLf & _
            '" if (!conf) { window.alert('Anda ingin meneruskan dokter ini'); } " & vbCrLf & _
            '" else {document.getElementById('" & c.ClientID & "').value = '';}  " & vbCrLf & _
            '"  __doPostBack('" + c.ClientID + "','__Confirm');  </script>")

            If (Not AspxPage.IsClientScriptBlockRegistered("__Confirm")) Then
                AspxPage.RegisterStartupScript("__Confirm", "<script language='javascript'>var conf ; " & vbCrLf & _
                                            " var v = document.getElementById('" & c.ClientID & "').value ; " & vbCrLf & _
                                            " conf = window.confirm('" + msg + "'); " & vbCrLf & _
                                            " if (conf) {  v='';} " & vbCrLf & _
                                            " " & vbCrLf & _
                                            " document.getElementById('" & c.ClientID & "').value = v ; " & vbCrLf & _
                                            "  __doPostBack('" + c.ClientID + "','');  </script>")

            End If




        End Sub

        Public Shared Function pbulat(ByVal xnvalue As Double, Optional ByVal xnsetup As Double = 50) As Double
            Dim setVar As New Common.SetVar
            xnsetup = CDbl(setVar.GetValue("bulat"))

            Dim signval As Integer
            Dim sisabulat As Double
            signval = Sign(xnvalue)
            xnvalue = Abs(xnvalue)
            sisabulat = (xnvalue Mod xnsetup)
            If xnsetup > 0 Then xnsetup = xnsetup Else xnsetup = 1
            If sisabulat > 0 Then
                Return (xnvalue - (xnvalue Mod xnsetup) + xnsetup) * signval
            Else
                Return (xnvalue - (xnvalue Mod xnsetup)) * signval
            End If
        End Function

        Public Shared Function GetUangR(ByVal [kduangR] As DropDownList, ByVal [kdinstansi] As String) As Double
            Dim osv As New Common.SetVar

            Dim uangR As Double = 0
            If IsNothing(kduangR.SelectedItem) Then
                uangR = 0
            Else
                'Kalau dari instansi Instansi tertentu tidak kena uangR
                'Select Case Trim(kdinstansi)
                '    Case osv.GetValueFM("kdinstrs").Trim
                '        uangR = 0
                '    Case Else
                Select Case Trim(kduangR.SelectedItem.Value)
                    Case "01"
                        uangR = CDbl(osv.GetValue("uangr1")) 'murah
                    Case "02"
                        uangR = CDbl(osv.GetValue("uangr2")) 'sedang
                    Case "03"
                        uangR = CDbl(osv.GetValue("uangr3")) 'mahal
                End Select
                ' End Select
            End If
            Return uangR
        End Function

        Public Shared Function CurrencyAlignment(ByVal [value] As Double, Optional ByVal [size] As Integer = 10) As String
            Dim nilaiStr As String
            If value > 0 Then
                nilaiStr = Format(value, "#,##0.00")
            Else
                nilaiStr = "0.00"
            End If

            'IIf(value > 0, nilaiStr = Format(value, "#,##0"), nilaiStr = " ")

            Dim empStr As String = " "
            Dim selisih As Integer = 0

            selisih = size - Len(Trim(nilaiStr))
            If selisih > 0 Then
                Dim i As Integer = 1
                Do While i <= selisih
                    nilaiStr = empStr + nilaiStr
                    i += 1
                Loop
            End If

            Return nilaiStr
        End Function

        Public Shared Function StringLeftAlignment(ByVal [value] As String, Optional ByVal [size] As Integer = 10) As String
            Dim retVal As String = value
            Dim empStr As String = " "
            Dim selisih As Integer = 0
            Dim karakter As Char
            karakter = Chr(32)


            selisih = size - Len(retVal)
            If selisih > 0 Then
                Dim i As Integer = 1
                Do While i <= selisih
                    retVal = retVal + karakter
                    i += 1
                Loop
            End If

            Return retVal
        End Function

        Public Shared Function StringLeftAlignment(ByVal start As Integer, ByVal [value] As String, Optional ByVal [size] As Integer = 10) As String
            Dim retVal As String = value
            Dim empStr As String = " "
            Dim selisih As Integer = 0
            Dim CountCharacter As Integer
            Dim strSpaceLine As String
            CountCharacter = Len(value)


            selisih = size - Len(retVal)
            If selisih > 0 Then
                Dim i As Integer = 1
                Do While i <= selisih
                    strSpaceLine = strSpaceLine + " "
                    i += 1
                Loop
            End If

            retVal = Trim(value) + strSpaceLine

            Return retVal
        End Function

        Public Shared Function StringRightAlignment(ByVal start As Integer, ByVal [value] As String, Optional ByVal [size] As Integer = 10) As String
            Dim retVal As String = value
            Dim empStr As String = " "
            Dim selisih As Integer = 0
            Dim CountCharacter As Integer
            Dim strSpaceLine As String
            CountCharacter = Len(value)


            selisih = size - Len(retVal)
            If selisih > 0 Then
                Dim i As Integer = 1
                Do While i <= selisih
                    strSpaceLine = strSpaceLine + " "
                    i += 1
                Loop
            End If

            retVal = strSpaceLine + Trim(value)

            Return retVal
        End Function

        Public Shared Function StringRightAlignment(ByVal [value] As String, Optional ByVal [size] As Integer = 10) As String
            Dim retVal As String = value
            Dim empStr As String = " "
            Dim selisih As Integer = 0

            selisih = size - Len(retVal)
            If selisih > 0 Then
                Dim i As Integer = 1
                Do While i <= selisih
                    retVal = empStr + retVal
                    i += 1
                Loop
            End If

            Return retVal
        End Function

        Public Shared Function StringCenterAlignment(ByVal [value] As String, Optional ByVal [size] As Integer = 10) As String
            Dim retVal As String = value.Trim
            Dim empStr As String = " "
            Dim selisih As Integer = 0

            selisih = size - Len(retVal)
            If selisih > 0 Then
                Dim i As Integer = 1
                Dim j As Double = selisih / 2
                Do While i <= j
                    retVal = empStr + retVal + empStr

                    i += 2
                Loop
            End If

            Return retVal
        End Function

        Public Shared Function DateToIndonesianFormat(ByVal tanggal As DateTime) As String
            'Return tanggal dd-mmmm-yyyy

            Dim retVal As String
            Dim nmBulan As String

            Select Case Month(tanggal)
                Case 1
                    nmBulan = "Januari"
                Case 2
                    nmBulan = "Februari"
                Case 3
                    nmBulan = "Maret"
                Case 4
                    nmBulan = "April"
                Case 5
                    nmBulan = "Mei"
                Case 6
                    nmBulan = "Juni"
                Case 7
                    nmBulan = "Juli"
                Case 8
                    nmBulan = "Agustus"
                Case 9
                    nmBulan = "September"
                Case 10
                    nmBulan = "Oktober"
                Case 11
                    nmBulan = "November"
                Case 12
                    nmBulan = "Desember"
            End Select

            retVal = CStr(Day(tanggal)) + " " + nmBulan + " " + CStr(Year(tanggal))

            Return retVal
        End Function

        Public Shared Function Terbilang(ByVal InputCurrency As String) As String
            Dim strInput As String
            Dim strBilangan As String
            Dim strPecahan As String
            Dim strTemp As Integer

            'Konversi ke string
            strInput = CStr(InputCurrency)
            'Periksa apakah ada tanda "." jika ya berarti pecahan
            'Bilangan yang digunakan menggunakan standar inggris
            'Dimana tanda "." merupakan tanda pecahan (kebalikan dengan Indonesia)
            strTemp = InStr(1, strInput, ".")
            If strTemp <> 0 Then
                'If InStr(1, strInput, ".") = strTemp Then
                'Print InStr(1, strInput, ".")
                strBilangan = Left(strInput, InStr(1, strInput, ".") - 1)
                strPecahan = Right(strInput, Len(strInput) - Len(strBilangan) - 1)
                Terbilang = KonversiBilangan(strBilangan) & "KOMA " & KonversiPecahan(strPecahan) & "RUPIAH"
            Else
                Terbilang = KonversiBilangan(strInput) & "RUPIAH"
            End If

            If (Right(Terbilang, 19)) = "KOMA NOL NOL RUPIAH" Then
                Terbilang = Left(Terbilang, Len(Terbilang) - 19) & "RUPIAH"
            Else
                Terbilang = Terbilang
            End If
        End Function

        Public Shared Function KonversiPecahan(ByVal strAngka As String) As String
            Dim X As Integer
            Dim Urai As String
            Dim Bil1 As String

            If strAngka = "" Then Exit Function

            Urai = ""
            X = 0
            While (X < Len(strAngka))
                X = X + 1

                Select Case Val(Mid(strAngka, X, 1))
                    Case 0
                        Bil1 = "NOL "
                    Case 1
                        Bil1 = "SATU "
                    Case 2
                        Bil1 = "DUA "
                    Case 3
                        Bil1 = "TIGA "
                    Case 4
                        Bil1 = "EMPAT "
                    Case 5
                        Bil1 = "LIMA "
                    Case 6
                        Bil1 = "ENAM "
                    Case 7
                        Bil1 = "TUJUH "
                    Case 8
                        Bil1 = "DELAPAN "
                    Case 9
                        Bil1 = "SEMBILAN "
                    Case Else
                        Bil1 = ""
                End Select
                Urai = Urai + Bil1
            End While
            KonversiPecahan = Urai
        End Function

        Public Shared Function KonversiBilangan(ByVal Angka As String) As String
            Dim satuan(10) As String
            Dim puluhan(5) As String
            Dim i As Integer
            Dim x As Integer
            Dim s1, p1, r1 As Integer
            Dim retst As String
            Dim Angkax As Double
            Dim satuanx As String

            satuan(1) = ""
            satuan(2) = "SATU"
            satuan(3) = "DUA"
            satuan(4) = "TIGA"
            satuan(5) = "EMPAT"
            satuan(6) = "LIMA"
            satuan(7) = "ENAM"
            satuan(8) = "TUJUH"
            satuan(9) = "DELAPAN"
            satuan(10) = "SEMBILAN"
            puluhan(1) = ""
            puluhan(2) = "RIBU"
            puluhan(3) = "JUTA"
            puluhan(4) = "MILYAR"
            puluhan(5) = "TRILYUN"

            retst = ""
            Angkax = CDbl(Angka)
            While (Angkax > 0)
                Dim st As String
                Dim angkacus As Double

                st = ""
                angkacus = Angkax Mod 1000

                s1 = CType(Angkax Mod 10, Integer)
                Angkax = (Angkax - s1) / 10
                p1 = CType(Angkax Mod 10, Integer)
                Angkax = (Angkax - p1) / 10
                r1 = CType(Angkax Mod 10, Integer)
                Angkax = (Angkax - r1) / 10

                If (angkacus = 1) And (i = 1) Then
                    st = "SERIBU"
                Else
                    If p1 = 1 Then
                        If s1 = 0 Then
                            st = "SEPULUH " & st
                        Else
                            If s1 = 1 Then
                                st = "SEBELAS " & st
                            Else
                                st = satuan(s1 + 1) & " BELAS " & st
                            End If
                        End If
                    Else
                        If p1 = 0 Then
                            st = satuan(s1 + 1) & " " & st
                        Else
                            st = satuan(p1 + 1) & " PULUH " & satuan(s1 + 1)
                        End If
                    End If

                    If r1 > 0 Then
                        If r1 = 1 Then
                            st = "SERATUS " & st
                        Else
                            st = satuan(r1 + 1) & " RATUS " & st
                        End If
                    End If

                    If (angkacus > 0) Then
                        st = st & " " & puluhan(i + 1)
                    End If
                End If
                i = i + 1
                retst = st & " " & retst
            End While
            KonversiBilangan = retst
        End Function

        Public Shared Function TableUserLogin(ByVal UserID As String) As DataTable
            Dim oUser As New BussinessRules.User
            Dim dt As New DataTable
            With oUser
                .UserID = UserID.Trim
                dt = .SelectOneByUserID()
                .Dispose()
            End With
            oUser = Nothing
            Return dt
        End Function

        Public Shared Function TableMenuAuthorization(ByVal UserGroupID As String) As DataTable
            Dim oMenu As New BussinessRules.Menu
            Dim dt As New DataTable
            oMenu.UserGroupID = UserGroupID.Trim
            dt = oMenu.SelectByUserGroupID()
            oMenu.Dispose()
            oMenu = Nothing
            Return dt
        End Function

        Public Shared Function CreateMenu(ByVal MenuAuthorization As DataTable) As String
            CreateMenu = String.Empty

            Dim rows As DataRow() = MenuAuthorization.Select("ParentMenuID IS NOT Null AND HeaderDetail = 'H'", "counter")
            Dim row As DataRow
            Dim str_href As String
            Dim str_line As String
            Dim str_ImageUrl As String

            CreateMenu = CreateMenu + "<span class=""preload1""></span> <span class=""preload2""></span>"
            CreateMenu = CreateMenu + "<div style=""width:100%;border-bottom:#394376 solid 1px;"" > <ul id=""nav"">"
            For Each row In rows
                str_href = IIf((CType(row("Url"), String) = "#" Or CType(row("Url"), String) = ""), "", ("href=""" + PageBase.UrlBase + "/secure/" + CType(row("Url"), String) + """")).ToString.Trim
                str_line = IIf(CType(row("Line"), Boolean), "style=""border-bottom-style:dotted;border-bottom-color:White;border-bottom-width:1px""", "").ToString.Trim
                str_ImageUrl = IIf((CType(row("ImageUrl"), String) = "#" Or CType(row("ImageUrl"), String) = ""), "", ("<img src=""" + PageBase.UrlBase + "/" + CType(row("ImageUrl"), String) + """ alt="" border=""0"" align='absmiddle'/>&nbsp;")).ToString.Trim

                If CType(row("HeaderDetail"), String).Trim = "H" Then
                    CreateMenu = CreateMenu + "<li " + str_line + " class=""top""><a " + str_href + " class=""top_link"" ><span class=""down"">" + str_ImageUrl + CType(row("Caption"), String) + "</span></a>"
                    CreateMenu = CreateMenu + CreateSubMenu(True, MenuAuthorization, CType(row("MenuID"), String)) ', False
                    CreateMenu = CreateMenu + "</li>"
                Else
                    CreateMenu = CreateMenu + "<li " + str_line + " class=""top""><a " + str_href + " class=""top_link"" ><span>" + str_ImageUrl + CType(row("Caption"), String) + "</span></a></li>"
                End If

            Next row
            CreateMenu = CreateMenu + "</ul></div>"
        End Function

        Public Shared Function CreateSubMenu(ByVal isLevel1 As Boolean, ByVal MenuAuthorization As DataTable, ByVal MenuID As String) As String

            Dim rows As DataRow() = MenuAuthorization.Select("ParentMenuID = '" + MenuID + "'", "counter")

            Dim row As DataRow

            CreateSubMenu = ""

            If isLevel1 Then
                CreateSubMenu = CreateSubMenu + "<ul class=""sub"">"
            Else
                CreateSubMenu = CreateSubMenu + "<ul>"
            End If

            Dim str_href As String
            Dim str_line As String
            Dim str_ImageUrl As String

            For Each row In rows
                str_href = IIf((CType(row("Url"), String) = "#" Or CType(row("Url"), String) = ""), "", ("href=""" + PageBase.UrlBase + "/secure/" + CType(row("Url"), String) + """")).ToString.Trim
                str_line = IIf(CType(row("Line"), Boolean), "style=""border-bottom-style:dotted;border-bottom-color:White;border-bottom-width:1px""", "").ToString.Trim
                str_ImageUrl = IIf((CType(row("ImageUrl"), String) = "#" Or CType(row("ImageUrl"), String) = ""), "", ("<img src=""" + PageBase.UrlBase + "/" + CType(row("ImageUrl"), String) + """ alt="" border=""0"" align='absmiddle'/>&nbsp;")).ToString.Trim

                If CType(row("HeaderDetail"), String).Trim = "H" Then
                    CreateSubMenu = CreateSubMenu + "<li " + str_line + " > <a " + str_href + " class=""fly"" >" + str_ImageUrl + CType(row("Caption"), String) + "</a>"
                    CreateSubMenu = CreateSubMenu + CreateSubMenu(False, MenuAuthorization, CType(row("MenuID"), String).Trim) ', isReportMenu
                    CreateSubMenu = CreateSubMenu + "</li>"
                Else
                    CreateSubMenu = CreateSubMenu + "<li " + str_line + " > <a " + str_href + ">" + str_ImageUrl + CType(row("Caption"), String) + "</a></li>"
                End If

            Next row
            CreateSubMenu = CreateSubMenu + "</ul>"
        End Function

        Public Shared Function JSOpenSearchListWind(ByVal SearchID As String, ByVal CtrlID As String, Optional ByVal IsWithKeyCode As Boolean = False, Optional ByVal _width As String = "650", Optional ByVal _height As String = "450", Optional ByVal _resizeble As String = "no", Optional ByVal _scrollable As String = "yes") As String
            Dim strJS As String = ""
            If IsWithKeyCode Then
                strJS = "javascript:openWindowForSLKeyCode(event.keyCode,'" + PageBase.UrlBase + "/SearchList.aspx?cd=" + SearchID.Trim + "&ctrlID=" + CtrlID + "&param=&fvalue=','" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
            Else
                strJS = "javascript:openWindowForSL('" + PageBase.UrlBase + "/SearchList.aspx?cd=" + SearchID.Trim + "&ctrlID=" + CtrlID + "&param=&fvalue=','" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
            End If
            Return strJS
        End Function

        Public Shared Function JSOpenSearchListWindWithParam(ByVal SearchID As String, ByVal CtrlID As String, ByVal CtrlIDParam As String, Optional ByVal IsWithKeyCode As Boolean = False, Optional ByVal _width As String = "650", Optional ByVal _height As String = "450", Optional ByVal _resizeble As String = "no", Optional ByVal _scrollable As String = "yes") As String
            Dim i As Integer
            Dim strJS As String = ""
            Dim textResultParam As String = ""
            Dim _CtrlIDParam As String() = CtrlIDParam.Trim.Split(CChar(";"))

            Dim oparam As New BussinessRules.SearchList
            oparam.SearchID = SearchID.Trim
            Dim dtparam As New DataTable
            dtparam = oparam.GetParamSP()
            oparam = Nothing

            If _CtrlIDParam.Length = dtparam.Rows.Count Then
                For i = 0 To _CtrlIDParam.Length - 1
                    textResultParam = textResultParam + dtparam.Rows(i)("PARAMETER_NAME").ToString + EqualSL + QuoteSL + "' + document.getElementById('" + _CtrlIDParam(i).Trim + "').value + '" + QuoteSL
                Next

                If IsWithKeyCode Then
                    strJS = "javascript:openWindowForSLKeyCode(event.keyCode,'" + PageBase.UrlBase + "/SearchList.aspx?cd=" + SearchID.Trim + "&ctrlID=" + CtrlID + _
                                                        "&param=" + textResultParam + _
                                                        "&fvalue=','" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
                    '"&fvalue=' + document.getElementById('" + CtrlID + "').value,'" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
                Else
                    strJS = "javascript:openWindowForSL('" + PageBase.UrlBase + "/SearchList.aspx?cd=" + SearchID.Trim + "&ctrlID=" + CtrlID + _
                                                        "&param=" + textResultParam + _
                                                        "&fvalue=','" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
                    '"&fvalue=' + document.getElementById('" + CtrlID + "').value,'" + CtrlID + "','SL','" + _width + "','" + _height + "','" + _resizeble + "','" + _scrollable + "');"
                End If
            Else
                Throw New Exception("CtrlID Param length does not match to Param length")
            End If
            dtparam.Dispose()
            dtparam = Nothing
            Return strJS
        End Function

        Public Shared Function GetHashString(ByVal textToHash As String) As String
            Dim oUser As New BussinessRules.User
            Dim hashedText As String = String.Empty
            With oUser
                hashedText = .GetHashString(textToHash.Trim).Trim
                .Dispose()
            End With
            oUser = Nothing
            Return hashedText
        End Function

        Public Shared Sub LoadDDLCommonSetting(ByVal GroupID As String, ByRef DropDownListCommonSettingID As DropDownList, Optional ByVal fcaption As Boolean = True)
            '// Global Function for filling ASP.Net DropDownList with data from CommonSetting table
            Dim dt As DataTable
            Dim cs As New BussinessRules.CommonSetting
            cs.GroupID = GroupID
            dt = cs.SelectAllByGroupID

            DropDownListCommonSettingID.Items.Clear()

            If fcaption Then DropDownListCommonSettingID.Items.Add(New ListItem("- select record -", "none"))

            For Each row As DataRow In dt.Rows
                DropDownListCommonSettingID.Items.Add(New ListItem(CType(row("DetailDesc"), String), CType(row("DetailID"), String)))
            Next

            If dt.Rows.Count = 1 Then
                If fcaption Then
                    DropDownListCommonSettingID.SelectedIndex = 1
                End If
            End If

            cs.Dispose()
            cs = Nothing
        End Sub

        Public Shared Sub LoadDDLItemUnit(ByRef DropDownListID As DropDownList, Optional ByVal fcaption As Boolean = True)
            '// Global Function for filling ASP.Net DropDownList with data from ItemUnit table
            Dim dt As DataTable
            Dim iu As New BussinessRules.ItemUnit
            dt = iu.SelectAll

            DropDownListID.Items.Clear()

            If fcaption Then DropDownListID.Items.Add(New ListItem("- select record -", "none"))

            For Each row As DataRow In dt.Rows
                DropDownListID.Items.Add(New ListItem(CType(row("ItemUnitName"), String), CType(row("ItemUnitID"), String)))
            Next

            If dt.Rows.Count = 1 Then
                If fcaption Then
                    DropDownListID.SelectedIndex = 1
                End If
            End If

            iu.Dispose()
            iu = Nothing
        End Sub

        Public Shared Sub LoadDDLEntitesByEntitiesTypeID(ByRef DropDownListID As DropDownList, ByVal EntitiesTypeID As String, Optional ByVal fcaption As Boolean = True)
            '// Global Function for filling ASP.Net DropDownList with data from Entities table By EntitiesTypeID
            Dim dt As DataTable
            Dim iu As New BussinessRules.Entities
            iu.EntitiesTypeID = EntitiesTypeID.Trim
            dt = iu.SelectByEntitiesTypeID

            DropDownListID.Items.Clear()

            If fcaption Then DropDownListID.Items.Add(New ListItem("- select record -", "none"))

            For Each row As DataRow In dt.Rows
                DropDownListID.Items.Add(New ListItem(CType(row("EntitiesName"), String), CType(row("EntitiesSeqNo"), String)))
            Next

            If dt.Rows.Count = 1 Then
                If fcaption Then
                    DropDownListID.SelectedIndex = 1
                End If
            End If

            iu.Dispose()
            iu = Nothing
        End Sub

        Public Shared Sub LoadRadDDL(ByRef RadComboBoxID As RadComboBox, _
                                   ByVal ColumnName As String, _
                                   ByVal ColumnID As String, _
                                   ByVal dt As DataTable, _
                                   Optional ByVal HeaderCaption As String = "", _
                                   Optional ByVal Fheader As Boolean = True)
            '// Global Function for filling Rad (Telerik) DropDownList/ComboBox with data from UserDefined table

            RadComboBoxID.Items.Clear()
            RadComboBoxID.Items.Add(New RadComboBoxItem("- select " + HeaderCaption + " -", "none"))
            For Each row As DataRow In dt.Rows
                RadComboBoxID.Items.Add(New RadComboBoxItem(CType(row(ColumnName), String), CType(row(ColumnID), String)))
            Next

            dt.Dispose()
            dt = Nothing
        End Sub

        Public Shared Sub LoadDDL(ByRef DropDownListID As System.Web.UI.WebControls.DropDownList, _
                                   ByVal ColumnName As String, _
                                   ByVal ColumnID As String, _
                                   ByVal dt As DataTable, _
                                   Optional ByVal Fheader As Boolean = True, _
                                   Optional ByVal HeaderCaption As String = "record")
            '// Global Function for filling ASP.Net DropDownList with data from UserDefined table

            DropDownListID.Items.Clear()

            If Fheader Then DropDownListID.Items.Add(New ListItem("- select " + HeaderCaption + " - ", "none"))

            For Each row As DataRow In dt.Rows
                DropDownListID.Items.Add(New ListItem(CType(row(ColumnName), String), CType(row(ColumnID), String)))
            Next

            If dt.Rows.Count = 1 Then
                If Fheader Then
                    DropDownListID.SelectedIndex = 1
                End If
            End If

            dt.Dispose()
            dt = Nothing
        End Sub

        Public Shared Sub LoadIDName(ByVal ID As String, ByRef RadComboBoxID As RadComboBox, Optional ByRef TextBoxName As TextBox = Nothing, Optional ByVal IsOpen As Boolean = False)
            If IsOpen = True Then
                RadComboBoxID.Text = String.Empty
            End If
            Select Case ID
                Case "EntitiesWithTextBox"
                    If RadComboBoxID.Text.Trim.Length <> 0 Or IsOpen = True Then
                        Dim En As New BussinessRules.Entities
                        With En
                            .EntitiesSeqNo = RadComboBoxID.SelectedValue.Trim
                            .EntitiesID = RadComboBoxID.Text.Trim
                            If .SelectOneByEntitiesIDForGlobal.Rows.Count > 0 OrElse .SelectOne.Rows.Count > 0 Then
                                If .IsActive Then
                                    RadComboBoxID.SelectedValue = .EntitiesSeqNo
                                    RadComboBoxID.Text = .EntitiesID
                                    TextBoxName.Text = .EntitiesName
                                Else
                                    RadComboBoxID.SelectedValue = String.Empty
                                    RadComboBoxID.Text = String.Empty
                                    TextBoxName.Text = String.Empty
                                End If
                            Else
                                RadComboBoxID.SelectedValue = String.Empty
                                RadComboBoxID.Text = String.Empty
                                TextBoxName.Text = String.Empty
                            End If
                        End With
                        En.Dispose()
                        En = Nothing
                    Else
                        RadComboBoxID.SelectedValue = String.Empty
                        RadComboBoxID.Text = String.Empty
                        TextBoxName.Text = String.Empty
                    End If
                Case "ItemWithTextBox"
                    If RadComboBoxID.Text.Trim.Length <> 0 Or IsOpen = True Then
                        Dim it As New BussinessRules.Item
                        With it
                            'RadComboBoxID.SelectedItem.Value.Trim
                            .ItemSeqNo = RadComboBoxID.SelectedValue.Trim
                            .ItemID = RadComboBoxID.Text.Trim
                            If .SelectOneByItemIDForGlobal.Rows.Count > 0 OrElse .SelectOne.Rows.Count > 0 Then
                                If .IsActive Then
                                    'RadComboBoxID.SelectedItem.Value = .ItemSeqNo
                                    RadComboBoxID.SelectedValue = .ItemSeqNo
                                    RadComboBoxID.Text = .ItemID
                                    TextBoxName.Text = .ItemName
                                Else
                                    RadComboBoxID.SelectedValue = String.Empty
                                    RadComboBoxID.Text = String.Empty
                                    TextBoxName.Text = String.Empty
                                End If
                            Else
                                RadComboBoxID.SelectedValue = String.Empty
                                RadComboBoxID.Text = String.Empty
                                TextBoxName.Text = String.Empty
                            End If
                        End With
                        it.Dispose()
                        it = Nothing
                    Else
                        RadComboBoxID.SelectedValue = String.Empty
                        RadComboBoxID.Text = String.Empty
                        TextBoxName.Text = String.Empty
                    End If
                Case "Item"
                    If RadComboBoxID.SelectedValue.Trim.Length <> 0 Then
                        Dim it As New BussinessRules.Item
                        With it
                            .ItemSeqNo = RadComboBoxID.SelectedValue.Trim
                            If .SelectOne(BussinessRules.RavenRecStatus.CurrentRecord).Rows.Count > 0 Then
                                RadComboBoxID.Text = .ItemName
                            End If
                        End With
                        it.Dispose()
                        it = Nothing
                    End If
            End Select
        End Sub

        Public Shared Sub GetTaxPct(ByRef TextBoxTax As TextBox, Optional ByVal GroupID As String = "Tax", Optional ByVal DetailID As String = "Tax")
            Dim tx As New BussinessRules.CommonSetting
            tx.GroupID = GroupID.Trim
            tx.DetailID = DetailID.Trim
            tx.SelecOneByGroupIDByDetailID()
            TextBoxTax.Text = Format((IIf(IsNumeric(tx.DetailDesc.Trim) AndAlso CDec(tx.DetailDesc.Trim) > 0 AndAlso CDec(tx.DetailDesc.Trim) < 100, CDec(tx.DetailDesc.Trim), 10)), commonFunction.FORMAT_CURRENCY)
            tx.Dispose()
            tx = Nothing
        End Sub

        Public Shared Function GetCurrencyPos() As String
            Dim c As String
            Dim tx As New BussinessRules.CommonSetting
            tx.GroupID = "CurrencyPos"
            c = CStr(tx.SelectAllByGroupID.Rows(0)("DetailID"))
            tx.Dispose()
            tx = Nothing
            Return c
        End Function

#Region " Validation Functions "
        Public Shared Function valNumericInput(ByVal strFieldName As String, ByVal strValue As String, ByVal isAllowZero As Boolean, ByVal txtTextBox As TextBox) As String
            Dim strToReturn As String = String.Empty

            '// isNumeric validation
            If IsNumeric(strValue) = False Then
                strToReturn = strFieldName.Trim + " must be numeric."
                txtTextBox.Text = Format(0, FORMAT_CURRENCY).Trim
                Return strToReturn
            End If

            '// zero validation
            Select Case isAllowZero
                Case True
                    If CDec(strValue) < 0 Then
                        strToReturn = strFieldName.Trim + " must be equal or greater than 0."
                        txtTextBox.Text = Format(0, FORMAT_CURRENCY).Trim
                        Return strToReturn
                    End If
                Case False
                    If CDec(strValue) <= 0 Then
                        strToReturn = strFieldName.Trim + " must be greater than 0."
                        txtTextBox.Text = Format(0, FORMAT_CURRENCY).Trim
                        Return strToReturn
                    End If
            End Select
        End Function
#End Region

    End Class

End Namespace