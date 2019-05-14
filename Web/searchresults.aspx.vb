Option Strict On
Option Explicit On 

Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports Microsoft.VisualBasic

Imports Raven.Web

Namespace Raven.Web

    Public Class searchresults
        Inherits PageBase

#Region "  Class Member Declaration  "

        Protected WithEvents gridSearchResult As System.Web.UI.WebControls.DataGrid
        Protected WithEvents SearchResultPanel As System.Web.UI.WebControls.Panel
        Protected WithEvents CancelButton As System.Web.UI.WebControls.Button
        Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
        Protected WithEvents lblInfoInfoLebih As System.Web.UI.WebControls.Label
        Protected WithEvents listField As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFilterValue As System.Web.UI.WebControls.TextBox
        Protected WithEvents dialogPanel As System.Web.UI.WebControls.Panel
        Protected WithEvents listFieldDlg As System.Web.UI.WebControls.DropDownList
        Protected WithEvents txtFilterValueDlg As System.Web.UI.WebControls.TextBox
        Protected WithEvents filterPanel As System.Web.UI.WebControls.Panel
        Protected WithEvents linkApplyFilterDlg As System.Web.UI.WebControls.LinkButton

        Private strSearchValue, strFieldName, strBrowseType As String

#End Region


#Region "  Control Events  "
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Me.IsPostBack Then
                strBrowseType = CStr(Request.QueryString(SearchData.QUERYSTRING_BROWSETYPE))
                strFieldName = CStr(Request.QueryString(SearchData.QUERYSTRING_FIELDNAME))
                strSearchValue = CStr(Request.QueryString(SearchData.QUERYSTRING_SEARCHVALUE))

                GenerateSearchData()

                Page.DataBind()
            End If
        End Sub

        Private Sub linkApplyFilterDlg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkApplyFilterDlg.Click
            strBrowseType = CStr(Request.QueryString(SearchData.QUERYSTRING_BROWSETYPE))
            strFieldName = listFieldDlg.SelectedItem.Text
            strSearchValue = txtFilterValueDlg.Text.Trim.Replace("*", "%")

            GenerateSearchData()
        End Sub

        Private Sub gridSearchResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridSearchResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim _drv As DataRowView = CType(e.Item.DataItem, DataRowView)

                    If _drv Is Nothing Then Exit Sub

                    Dim s0 As String = CType(_drv.Row.Item(0), String).Trim
                    Dim s1 As String = CType(_drv.Row.Item(1), String).Trim

                    Dim a As String = "'"

                    s1 = Replace(s1, "'", " ")
                    s1 = Replace(s1, """", " ")

                    e.Item.Attributes.Add("onmouseover", "javascript:this.style.backgroundColor='PaleGoldenrod';this.focus;")
                    e.Item.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='white'")
                    e.Item.Attributes.Add("onclick", "CloseWindow(new Array('" + s0 + "', '" + s1 + "'))")
                    'e.Item.Attributes.Add("onkeypress", "KeyEnter(new Array('" + s0 + "', '" + s1 + "'))")
            End Select
        End Sub
#End Region


#Region "  Main Function  "
        Private Sub GenerateSearchData()
            Dim dt As DataTable
            Dim paramName(0) As String
            Dim paramValue(0) As String
            Dim se As New SearchEngine

            commonFunction.ShowPanel(SearchResultPanel, True)
            commonFunction.ShowPanel(dialogPanel, False)
            commonFunction.ShowPanel(filterPanel, True)

            Select Case strBrowseType
                Case ""

                Case SearchData.BROWSETYPE_PAKETTINDAKANRJMTX
                    ' // total parameter:
                    ' //    0: nobukti
                    ' //    1: kdpmedis
                    ' //    2: norm

                    ReDim paramName(2)
                    ReDim paramValue(2)

                    '// kode paket
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// norm
                    paramName(1) = "norm"
                    paramValue(1) = CStr(Request.QueryString("norm"))

                    '// kode poli
                    paramName(2) = "kdpmedis"
                    paramValue(2) = CStr(Request.QueryString("kdpmedis"))

                Case SearchData.BROWSETYPE_PLAFON
                    ReDim paramName(2)
                    ReDim paramValue(2)

                    '// nomor rekam medis
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// kode instansi
                    paramName(1) = "kdinstansi"
                    paramValue(1) = CStr(Request.QueryString("nid"))

                    '// kode aplikasi
                    paramName(2) = "app"
                    paramValue(2) = CStr(Request.QueryString("pid"))

                Case SearchData.BROWSETYPE_PEMBAYARANBYNOREG
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    '// nomor rekam medis
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// Nomor Registrasi
                    paramName(1) = "noreg"
                    paramValue(1) = CStr(Request.QueryString("noreg"))

                Case SearchData.BROWSETYPE_DOKTERPERPOLI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    '// nomor rekam medis
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// Kode Poliklinik
                    paramName(1) = "kdpoli"
                    paramValue(1) = CStr(Request.QueryString("kdpoli"))

                Case SearchData.BROWSETYPE_DOKTERPERPOLIPERTGL
                    ReDim paramName(2)
                    ReDim paramValue(2)

                    '// nomor rekam medis
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// Kode Poliklinik
                    paramName(1) = "kdpoli"
                    paramValue(1) = CStr(Request.QueryString("kdpoli"))

                    '// tgl Registrasi
                    paramName(2) = "tanggal"
                    paramValue(2) = CStr(Request.QueryString("tanggal"))

                Case SearchData.BROWSETYPE_POLIPERDOKTER
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    '// nomor rekam medis
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// Nomor Registrasi
                    paramName(1) = "kddokter"
                    paramValue(1) = CStr(Request.QueryString("kddokter"))

                Case SearchData.BROWSETYPE_NOBUKTITRANSPAKET2
                    ReDim paramName(2)
                    ReDim paramValue(2)

                    '// kode paket
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// norm
                    paramName(1) = "norm"
                    paramValue(1) = CStr(Request.QueryString("norm"))

                    '// kode poli
                    paramName(2) = "kode"
                    paramValue(2) = CStr(Request.QueryString("poli"))
                Case SearchData.BROWSETYPE_TRANSAKSI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // nomor bukti
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group transaksi
                    paramName(1) = "noreg"
                    paramValue(1) = CStr(Request.QueryString("inoreg"))

                Case SearchData.BROWSETYPE_PENGIRIM
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // nomor pengirim
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group pengirim
                    paramName(1) = "Pengirim"
                    paramValue(1) = CStr(Request.QueryString("kds"))

                Case SearchData.BROWSETYPE_REGTDKBTL
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // Registrasi Per Norm
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group pengirim
                    paramName(1) = "norm"
                    paramValue(1) = CStr(Request.QueryString("kds"))

                Case SearchData.BROWSETYPE_TRANSHD
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // Registrasi Per Norm
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // Parameter Send
                    paramName(1) = "noreg"
                    paramValue(1) = CStr(Request.QueryString("kds"))

                Case SearchData.BROWSETYPE_JASAMEDIK
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    paramName(1) = "kdgroupjasa"
                    paramValue(1) = CStr(Request.QueryString("kgj"))

                Case SearchData.BROWSETYPE_MTXDIAGPOLI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    '// Matrix DiagnosaPoli
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '//Parameter Send
                    paramName(1) = "poliklinik"
                    paramValue(1) = CStr(Request.QueryString("kds"))

                Case SearchData.BROWSETYPE_MTXLAYANPOLI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode layan
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // kode poli
                    paramName(1) = "Poliklinik"
                    paramValue(1) = CStr(Request.QueryString("kds"))

                Case SearchData.BROWSETYPE_JENISKASUS
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode layan
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // kode poli
                    paramName(1) = "Poliklinik"
                    paramValue(1) = CStr(Request.QueryString("kds"))


                Case SearchData.BROWSETYPE_MTXOBATPOLI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode obat
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group ruang
                    paramName(1) = "kdpoli"
                    paramValue(1) = CStr(Request.QueryString("kdr"))

                Case SearchData.BROWSETYPE_MTXLOGISTIKPOLI
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode layan
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // kode poli
                    paramName(1) = "kdpoli"
                    paramValue(1) = CStr(Request.QueryString("kdr"))


                Case SearchData.BROWSETYPE_MTXLAYANPNJ
                    ReDim paramName(2)
                    ReDim paramValue(2)

                    ' // kode obat
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group ruang
                    paramName(1) = "kdpmedis"
                    paramValue(1) = CStr(Request.QueryString("kdr"))

                    '// group kelas
                    paramName(2) = "kdkelas"
                    paramValue(2) = CStr(Request.QueryString("kls"))

                Case SearchData.BROWSETYPE_MTXOBATPNJ
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode obat
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group ruang
                    paramName(1) = "kdpmedis"
                    paramValue(1) = CStr(Request.QueryString("kdr"))

                Case SearchData.BROWSETYPE_MTXLOGISTIKPNJ
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode obat
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group ruang
                    paramName(1) = "kdpmedis"
                    paramValue(1) = CStr(Request.QueryString("kdr"))

                Case SearchData.BROWSETYPE_POLIKLINIKTRHD
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    ' // kode obat
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    ' // group ruang
                    paramName(1) = "noreg"
                    paramValue(1) = CStr(Request.QueryString("kdr"))

                Case SearchData.BROWSETYPE_ITEMPERGUDANGLOKASI
                    ReDim paramName(2)
                    ReDim paramValue(2)

                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    paramName(1) = "kdgudang"
                    paramValue(1) = CStr(Request.QueryString("kdg"))

                    paramName(2) = "kdlokasi"
                    paramValue(2) = CStr(Request.QueryString("kdl"))

                Case SearchData.BROWSETYPE_NOBATCHBYKDITEM
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// Kode Item
                    paramName(1) = "kdbarang"
                    paramValue(1) = CStr(Request.QueryString("kdi"))

                Case SearchData.BROWSETYPE_NOJOBYNOREG
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    '// NoJO
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    '// NoReg
                    paramName(1) = "noreg"
                    paramValue(1) = CStr(Request.QueryString("noreg"))

                Case SearchData.BROWSETYPE_ANGGOTAINST
                    ReDim paramName(1)
                    ReDim paramValue(1)

                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue

                    paramName(1) = "kdinstansi"
                    paramValue(1) = CStr(Request.QueryString("kdNI"))

                Case Else '// default
                    paramName(0) = strFieldName
                    paramValue(0) = strSearchValue
            End Select

            dt = se.GenerateSearchData(getSPSearchName, paramValue, paramName)

            '// looks like there are lot of records, show filter dialog
            If (Not dt.Columns.Count > 0) And (se.TotalRowsCount > 0) Then
                ShowFilterDlg()
            Else
                lblInfo.Text = "Hasil pencarian: " + CStr(se.TotalRowsCount) + " Record(s)"
                lblInfoInfoLebih.Text = "Hasil pencarian: " + CStr(se.TotalRowsCount) + " Record(s)"

                gridSearchResult.DataSource = dt.DefaultView
                gridSearchResult.DataBind()

                '// Buat True Karena pada kasus tertentu column pertama adalah counter, tidak perlu ditampilkan
                'gridSearchResult.Columns(0).Visible = True

                'Select Case cachedBrowseType
                '    Case SearchData.BROWSETYPE_COUNTERTERIMA
                '        gridSearchResult.Columns(0).Visible = False '// Column pertama adalah counter
                'End Select
            End If
        End Sub
#End Region


#Region "  Private Function  "
        Private Function ShowFilterDlg() As Boolean
            commonFunction.ShowPanel(SearchResultPanel, False)
            commonFunction.ShowPanel(dialogPanel, True)
            commonFunction.ShowPanel(filterPanel, False)

            Dim tbl As DataTable
            tbl = SearchEngine.GetParamList(getSPSearchName)

            If Not listFieldDlg.Items Is Nothing Then
                listFieldDlg.Items.Clear()
            End If

            If Not tbl Is Nothing Then
                If tbl.Rows.Count > 0 Then
                    Dim rows() As DataRow = tbl.Select
                    Dim row As DataRow

                    For Each row In rows
                        If (Common.ProcessNull.GetInt32(row("length")) >= 1024) Then
                            listFieldDlg.Items.Add(New ListItem(CType(row("NAME"), String).Replace("@", ""), CType(row("NAME"), String).Replace("@", "")))
                        End If
                    Next
                End If
            End If

            commonFunction.SelectListItem(listFieldDlg, strFieldName)

            Select Case strBrowseType

                Case SearchData.BROWSETYPE_MTXOBATPNJ
                    commonFunction.SelectListItem(listFieldDlg, "nmbarang")
                Case SearchData.BROWSETYPE_MTXLOGISTIKPNJ
                    commonFunction.SelectListItem(listFieldDlg, "nmbarang")
                Case SearchData.BROWSETYPE_MTXOBATPOLI
                    commonFunction.SelectListItem(listFieldDlg, "nmbarang")
                    'Case SearchData.BROWSETYPE_PASIEN
                    '    commonFunction.SelectListItem(listFieldDlg, "Nama")
                Case SearchData.BROWSETYPE_MTXLAYANPNJ
                    commonFunction.SelectListItem(listFieldDlg, "nmlayan")
                Case SearchData.BROWSETYPE_TRANSAKSI
                    commonFunction.SelectListItem(listFieldDlg, "Tanggal")
                    txtFilterValueDlg.Text = Format(Date.Now, commonFunction.FORMAT_DATE) & "*"
                Case SearchData.BROWSETYPE_TEST
                    commonFunction.SelectListItem(listFieldDlg, "nmtest")
                Case SearchData.BROWSETYPE_MEDIS, SearchData.BROWSETYPE_SISATAGIHAN
                    commonFunction.SelectListItem(listFieldDlg, "Nama")
                Case SearchData.BROWSETYPE_INSTANSI
                    commonFunction.SelectListItem(listFieldDlg, "nminstansi")
                Case SearchData.BROWSETYPE_GROUPPOLIKLINIK
                    commonFunction.SelectListItem(listFieldDlg, "Nama")
                Case SearchData.BROWSETYPE_REGTDKBTL
                    commonFunction.SelectListItem(listFieldDlg, "Nama")
                Case Else
                    commonFunction.SelectListItem(listFieldDlg, strFieldName)
            End Select

        End Function

        Private Function getSPSearchName() As String
            Select Case strBrowseType
                Case SearchData.BROWSETYPE_TRANSAKSI
                    Return "sprj_view_Transaksi"
                Case SearchData.BROWSETYPE_TEST
                    Return "splb_view_Test"
                Case SearchData.BROWSETYPE_AHLI
                    Return "sprj_view_TenagaAhli"
                Case SearchData.BROWSETYPE_PELAYANAN2
                    Return "sprj_view_Pelayanan2"
                Case SearchData.BROWSETYPE_REGISTRASI
                    Return "sprj_view_Registrasi"
                    'Case SearchData.BROWSETYPE_CLOSEREGISTRASI
                    '   Return "vwRegistrasiClose"
                Case SearchData.BROWSETYPE_APPOINTMENT
                    Return "sprj_view_Appointment"
                Case SearchData.BROWSETYPE_APPOINTMENTWITHNORM
                    Return "sprj_view_AppointmentWithNorm"
                Case SearchData.BROWSETYPE_APPOINTMENTWITHOUTNORM
                    Return "sprj_view_AppointmentWithoutNorm"
                    'Case SearchData.BROWSETYPE_PENJAMINBAYAR
                    '    Return "sprj_view_JaminBayar"
                    'Case SearchData.BROWSETYPE_HUBUNGANPB
                    '    Return "sprj_view_HubKry"
                    'Case SearchData.BROWSETYPE_HUBUNGANPJ
                    '    Return "sprj_view_HubKlg"
                    'Case SearchData.BROWSETYPE_JENISKUNJUNGAN
                    '    Return "sprj_view_TipeVisit"
                    'Case SearchData.BROWSETYPE_TIPECHARGE
                    '    Return "sprj_view_TipeCharge"
                    'Case SearchData.BROWSETYPE_KODEPOSID
                    '    Return "sprj_view_KodePos"
                    'Case SearchData.BROWSETYPE_SMFID
                    '    Return "sprj_view_Smf"
                    'Case SearchData.BROWSETYPE_BANKID
                    '    Return "sprj_view_Bank"
                Case SearchData.BROWSETYPE_PAKETTARIF
                    Return "sprj_view_Pelayanan"
                    'Case SearchData.BROWSETYPE_STDFIELDHD
                    '    Return "sprj_view_StdFieldHd"
                Case SearchData.BROWSETYPE_PEMBAYARAN
                    Return "sprj_view_Pembayaran"
                Case SearchData.BROWSETYPE_PEMBAYARANBYNOREG
                    Return "sprj_view_PembayaranByNoReg"
                    'Case SearchData.BROWSETYPE_GROUPTARIF
                    '    Return "sprj_view_GroupTarif"
                    'Case SearchData.BROWSETYPE_JENISMEDIS
                    '    Return "sprj_view_JenisMedis"
                    'Case SearchData.BROWSETYPE_PENDIDIKANTERAKHIR
                    '    Return "sprj_view_PDDN"
                    'Case SearchData.BROWSETYPE_AGAMA
                    '    Return "sprj_view_Agama"
                Case SearchData.BROWSETYPE_BANK
                    Return "sprj_view_Bank"
                    'Case SearchData.BROWSETYPE_MEMBERID
                    '    Return "sprj_view_Member"
                    'Case SearchData.BROWSETYPE_JENISDOKTER
                    '    Return "sprj_view_JenisDokter"
                    'Case SearchData.BROWSETYPE_JENISINSTANSI
                    '    Return "sprj_view_JenisInstansi"
                    'Case SearchData.BROWSETYPE_ACCOUNTOFFICER
                    '    Return "sprj_view_AccountOfficer"
                    'Case SearchData.BROWSETYPE_TIPEMEMBER
                    '    Return "sprj_view_TipeMember"
                    'Case SearchData.BROWSETYPE_PAKETMEMBER
                    '    Return "sprj_view_PaketMember"
                    'Case SearchData.BROWSETYPE_SEKS
                    '    Return "sprj_view_Seks"
                    'Case SearchData.BROWSETYPE_NORM
                    '    Return "sprj_view_Pasien"
                    'Case SearchData.BROWSETYPE_STATUSKAWIN
                    '    Return "sprj_view_StatusKawin"
                    'Case SearchData.BROWSETYPE_PEKERJAAN
                    '    Return "sprj_view_Pekerjaan"
                    'Case SearchData.BROWSETYPE_KEWARGANEGARAAN
                    '    Return "sprj_view_WargaNegara"
                    'Case SearchData.BROWSETYPE_PROPINSI
                    '    Return "sprj_view_Propinsi"
                    'Case SearchData.BROWSETYPE_DOKTER
                    '    Return "sprj_view_DokterSearch"
                    'Case SearchData.BROWSETYPE_PELAYANAN
                    '    Return "sprj_view_PelayananSearch"
                Case SearchData.BROWSETYPE_MTXLAYANPOLI
                    Return "sprj_view_MtxLayanPoli"
                Case SearchData.BROWSETYPE_SISATAGIHAN
                    Return "sprj_view_SisaPembayaran"
                    'Case SearchData.BROWSETYPE_JENISPOLIKLINIK
                    '    Return "sprj_view_JenisPoli"
                    'Case SearchData.BROWSETYPE_LANTAI
                    '    Return "sprj_view_Lantai"
                    'Case SearchData.BROWSETYPE_PAKETCOVERAGE
                    '    Return "sprj_view_PaketCoverage"
                Case SearchData.BROWSETYPE_BYRPIUTPBD
                    Return "sprj_view_ByrPiutPbd"
                Case SearchData.BROWSETYPE_BYRPIUTINS
                    Return "sprj_view_ByrPiutIns"
                    'Case SearchData.BROWSETYPE_PAKETMCU
                    '    Return "sprj_view_PaketMcu"
                    'Case SearchData.BROWSETYPE_PAKETMCUPRSH
                    '    Return "sprj_view_PaketMcuPrsh"
                    'Case SearchData.BROWSETYPE_REGISTRASIMCU
                    '    Return "sprj_view_RegistrasiMcu"
                    'Case SearchData.BROWSETYPE_REGISTRASIMCU2
                    '    Return "sprj_view_RegistrasiMcu2"
                Case SearchData.BROWSETYPE_PASIENPIUTANG
                    Return "sprj_view_PasienPiutang"
                Case SearchData.BROWSETYPE_INSTANSIPIUTANG
                    Return "sprj_view_InstansiPiutang"
                Case SearchData.BROWSETYPE_PASIENOUTSTANDING
                    Return "sprj_view_PasienOutstanding"
                Case SearchData.BROWSETYPE_INSTANSIOUTSTANDING
                    Return "sprj_view_InstansiOutstanding"
                    'Case SearchData.BROWSETYPE_REGISTRASIREKAL
                    '    Return "sprj_view_RegistrasiRekal"
                    'Case SearchData.BROWSETYPE_PASIENALL
                    '    Return "sprj_view_PasienAll"
                    'Case SearchData.BROWSETYPE_GROUPJASAMEDIK
                    '    Return "sprj_view_GroupJasaMedik"
                    'Case SearchData.BROWSETYPE_CUTIDOKTER
                    '    Return "sprj_view_CutiDokter"
                    'Case SearchData.BROWSETYPE_TARIFMCUPRSH
                    '    Return "sprj_view_TarifMCUPrsh"
                    'Case SearchData.BROWSETYPE_MASTERITEM
                    '    Return "sprj_view_MasterItem"
                    'Case SearchData.BROWSETYPE_REGISTRASIHASILMCU
                    '    Return "sprj_view_RegistrasiHasilMCU"
                    'Case SearchData.BROWSETYPE_HASILMCU
                    '    Return "sprj_view_HasilMCU"
                    'Case SearchData.BROWSETYPE_MEMBERREG
                    '    Return "sprj_view_MemberReg"
                Case SearchData.BROWSETYPE_PENGIRIM
                    Return "sprj_view_Pengirim"
                    'Case SearchData.BROWSETYPE_OPENREGISTRASI
                    '    Return "sprj_view_RegistrasiOpen"
                    'Case SearchData.BROWSETYPE_USERACCOUNTS
                    '    Return "sprj_view_Users"
                Case SearchData.BROWSETYPE_NOBUKTITRANSPAKET
                    Return "sprj_view_NoBuktiTransPaket"
                Case SearchData.BROWSETYPE_NOBUKTITRANSPAKET2
                    Return "sprj_view_NoBuktiTransPaket2"
                    'Case SearchData.BROWSETYPE_CLOSEREGISTRASI
                    '    Return "sprj_view_RegistrasiClose"
                Case SearchData.BROWSETYPE_KDNKELUAR
                    Return "sprj_view_KdnKeluar"
                Case SearchData.BROWSETYPE_CARAKELUAR
                    Return "sprj_view_CaraKeluar"
                Case SearchData.BROWSETYPE_TDKLANJUT
                    Return "sprj_view_TdkLanjut"
                    'Case SearchData.BROWSETYPE_PEMBJM
                    '    Return "sprj_view_PembyJM"
                Case SearchData.BROWSETYPE_MTXDIAGPOLI
                    Return "sprj_view_MtxDiagPoli"
                    '    Return "sprj_view_Gudang"
                Case SearchData.BROWSETYPE_REGTDKBTL
                    Return "sprj_view_RegistrasiTidakBatal"
                Case SearchData.BROWSETYPE_TRANSHD
                    Return "sprj_view_TransHD"
                Case SearchData.BROWSETYPE_DOKTERANS
                    Return "sprj_view_DokterAns"
                    'Case SearchData.BROWSETYPE_REGMCUMASSAL
                    '    Return "sprj_view_RegMCUMassal"
                    'Case SearchData.BROWSETYPE_HASILMCUINS
                    '    Return "sprj_view_HasilMCUIns"
                    'Case SearchData.BROWSETYPE_REGISTRASIHASILMCUINS
                    '    Return "sprj_view_RegistrasiHasilMCUIns"

                Case SearchData.BROWSETYPE_MTXLAYANPNJ
                    Return "spmd_view_MatriksPelayananPnjMedis"
                Case SearchData.BROWSETYPE_MTXOBATPNJ
                    Return "spmd_view_ObatByPnjMedis"

                Case SearchData.BROWSETYPE_MTXOBATPOLI
                    Return "sprj_view_ObatByPoliklinik"
                    'Case SearchData.BROWSETYPE_PASIENPIUTANGWRITEOFF
                    '    Return "sprj_view_PasienPiutangWriteOff"
                    'Case SearchData.BROWSETYPE_INSTANSIPIUTANGWRITEOFF
                    '    Return "sprj_view_InstansiPiutangWriteOff"
                    'Case SearchData.BROWSETYPE_REGISTRASIHASILMCU2
                    '    Return "sprj_view_RegistrasiHasilMCU2"
                    'Case SearchData.BROWSETYPE_HASILMCU2
                    '    Return "sprj_view_HasilMCU2"
                Case SearchData.BROWSETYPE_PAKETTINDAKANRJMTX
                    Return "spmd_view_PaketTindakanRJMTX"
                    'Case SearchData.BROWSETYPE_DOKTERPENGIRIM
                    '    Return "spmd_view_DokterPengirim"
                    'Case SearchData.BROWSETYPE_REGISTRASIPNJMEDIS
                    'Return "sprj_view_RegistrasiPnjMedis"


                    '**********************************************
                    'New one

                    'new
                Case SearchData.BROWSETYPE_BANK
                    Return "sprj_view_bank"

                Case SearchData.BROWSETYPE_TARIFGROUP
                    Return "sprj_view_grouptarif"

                Case SearchData.BROWSETYPE_TARIFPELAYANAN
                    Return "sprj_view_tarifpelayanan"

                Case SearchData.BROWSETYPE_GROUPJASAMEDIS
                    Return "sprj_view_GroupJasaMedis"

                Case SearchData.BROWSETYPE_JASAMEDIK
                    Return "sprj_view_jasamedik"

                Case SearchData.BROWSETYPE_NOBUKTI
                    Return "sprj_view_NoBuktiCutiDr"

                Case SearchData.BROWSETYPE_MEDIS
                    Return "sprj_view_Medis"

                Case SearchData.BROWSETYPE_MEDISRI
                    Return "sprj_view_MedisRi"

                Case SearchData.BROWSETYPE_MEDISRJ
                    Return "sprj_view_MedisRj"

                Case SearchData.BROWSETYPE_MASTEROBAT
                    Return "sprj_view_MasterItem"

                Case SearchData.BROWSETYPE_PASIEN
                    Return "sprj_view_pasien"

                Case SearchData.BROWSETYPE_POLIKLINIK
                    Return "sprj_view_poli"

                Case SearchData.BROWSETYPE_POLIKLINIKAKTIF
                    Return "sprj_view_poli_aktif"

                Case SearchData.BROWSETYPE_KODEPOS
                    Return "sprj_view_KodePos"

                Case SearchData.BROWSETYPE_SMF
                    Return "sprj_view_SMF"

                Case SearchData.BROWSETYPE_TINDAKAN
                    Return "sprj_view_Tindakan"

                Case SearchData.BROWSETYPE_REGISTRASIKB
                    Return "sprj_view_RegistrasiKB"

                Case SearchData.BROWSETYPE_REGISTRASIMD
                    Return "sprj_view_RegistrasiMD"

                Case SearchData.BROWSETYPE_INSTANSI
                    Return "sprj_view_Instansi"

                Case SearchData.BROWSETYPE_GROUPPOLIKLINIK
                    Return "sprs_view_GroupPoliklinik"

                Case SearchData.BROWSETYPE_PLAFON
                    Return "sprs_view_plafon"

                Case SearchData.BROWSETYPE_GUDANG
                    Return "sprj_view_gudang"

                Case SearchData.BROWSETYPE_KELAS
                    Return "sprj_view_kelas"

                Case SearchData.BROWSETYPE_DIAGNOSA
                    Return "sprj_view_Diagnosa"

                Case SearchData.BROWSETYPE_MORFOLOGI
                    Return "sprj_view_Morfologi"

                Case SearchData.BROWSETYPE_DTD
                    Return "sprj_view_DTD"

                Case SearchData.BROWSETYPE_NOMORREKAMMEDIS
                    Return "sprj_view_nomorrm"

                Case SearchData.BROWSETYPE_PROSESPIUTANGI
                    Return "sprj_view_ProsesPiutangInstansi"

                Case SearchData.BROWSETYPE_PROSESPIUTANGP
                    Return "sprj_view_ProsesPiutangPribadi"

                Case SearchData.BROWSETYPE_MEMBER
                    Return "sprj_view_Member"

                Case SearchData.BROWSETYPE_POLIKLINIKTRHD
                    Return "sprj_view_TransHD"

                Case SearchData.BROWSETYPE_PNJMEDIS
                    Return "sprj_view_PnjMedis"

                Case SearchData.BROWSETYPE_KASUS
                    Return "sprj_view_kasus"

                Case SearchData.BROWSETYPE_JASAMEDISALL
                    Return "sprj_view_JasaMedisAll"

                Case SearchData.BROWSETYPE_DOKTERPERPOLI
                    Return "sprj_view_medisrjperpoli"

                Case SearchData.BROWSETYPE_DOKTERPERPOLIPERTGL
                    Return "sprj_view_medisrjperpolipertgl"

                Case SearchData.BROWSETYPE_POLIPERDOKTER
                    Return "sprj_view_PoliRjPerDokter"

                Case SearchData.BROWSETYPE_ATURAN
                    'Return "fm_vwAturan"
                    Return "spfm_View_Aturan"

                Case SearchData.BROWSETYPE_ITEMPERGUDANGLOKASI
                    Return "spfm_View_SaldoInventoryByGdLokasi"

                Case SearchData.BROWSETYPE_REGTB
                    Return "sprj_view_RegistrasiTdkBtl"

                Case SearchData.BROWSETYPE_MTXLOGISTIKPOLI
                    Return "sprj_view_LogistikByPoliklinik"

                Case SearchData.BROWSETYPE_MTXLOGISTIKPNJ
                    Return "spmd_view_LogistikByPnjMedis"

                Case SearchData.BROWSETYPE_PEGAWAI
                    Return "sppg_view_pegawai"

                    '************************************

                Case SearchData.BROWSETYPE_SUKU
                    Return "sprs_view_Suku"
                Case SearchData.BROWSETYPE_PROPINSI
                    Return "sprs_view_Propinsi"
                Case SearchData.BROWSETYPE_PEKERJAAN
                    Return "sprs_view_Pekerjaan"
                Case SearchData.BROWSETYPE_PENDIDIKAN
                    Return "sprs_view_Pendidikan"
                Case SearchData.BROWSETYPE_AGAMA
                    Return "sprs_view_Agama"
                Case SearchData.BROWSETYPE_STATUSKAWIN
                    Return "sprs_view_StatusKawin"
                Case SearchData.BROWSETYPE_KEWARGANEGARAAN
                    Return "sprs_view_Kewarganegaraan"
                Case SearchData.BROWSETYPE_JENISDIAGNOSA
                    Return "sprs_view_JenisDiagnosa"
                Case SearchData.BROWSETYPE_JENISKASUS
                    Return "sprs_view_JenisKasus"
                Case SearchData.BROWSETYPE_NOBATCHBYKDITEM
                    Return "spfm_view_NoBatchByKdItem"
                Case SearchData.BROWSETYPE_AKTIVA
                    Return "spgl_view_aktiva"
                Case SearchData.BROWSETYPE_NOJOBYNOREG
                    Return "sprj_view_OrderPnjByNoReg"
                Case SearchData.BROWSETYPE_GROUP
                    Return "splb_view_Group"
                Case SearchData.BROWSETYPE_ANGGOTAINST
                    Return "sprs_view_AnggotaInstansi"
            End Select
        End Function

#End Region


    End Class

#Region " SEARCH ENGINE  "

    Public Class SearchEngine
        Private _TotalRowsCount As Integer

        Public ReadOnly Property TotalRowsCount() As Integer
            Get
                Return _TotalRowsCount
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Shared Function GetParamList(ByVal spName As String) As DataTable
            Dim cn As New SqlClient.SqlConnection(Raven.Common.HisConfiguration.ConnectionString)
            Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
            Dim tbl As DataTable = New DataTable
            Dim da As SqlClient.SqlDataAdapter
            Dim strSQL As String

            strSQL = "select name, type, length from syscolumns where id = object_id('" + spName + "') and type  = '39'"

            Try
                cn.Open()
                cmd.Connection = cn
                cmd.CommandText = strSQL
                cmd.CommandType = CommandType.Text
                cmd.CommandTimeout = 600

                da = New SqlClient.SqlDataAdapter(cmd)
                da.Fill(tbl)

                Return tbl
            Catch ex As Exception
                Raven.Common.ExceptionManager.Publish(ex)
            Finally
                If Not cn Is Nothing Then
                    cn.Dispose()
                    cn = Nothing
                End If
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not da Is Nothing Then
                    da.Dispose()
                    da = Nothing
                End If
            End Try
        End Function

        Public Function GenerateSearchData(ByVal spName As String, ByVal prmValues() As Object, ByVal prmNames() As String) As DataTable
            Dim arParameters() As SqlClient.SqlParameter
            Dim i As Integer = 1
            Dim prmName As String

            ReDim arParameters(prmNames.Length)
            arParameters(0) = New SqlClient.SqlParameter("@recCount", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _TotalRowsCount)
            'For i = 0 To arParameters.Length
            '    If i <> 0 Then
            '        arParameters(i - 1) = New SqlClient.SqlParameter("@" + prmName(i - 2), prmValue(i - 2))
            '    End If
            '    i += 1
            'Next
            'For i = 0 To prmName.Length
            '    'If (i > 0) And (i < arParameters.Length) Then
            '    arParameters(i) = New SqlClient.SqlParameter("@" + prmName(i - 1), prmValue(i - 1))
            '    'End If
            '    'i += 1
            '    arParameters(i + 1) = New SqlClient.SqlParameter("@" + prmName(i - 1), prmValue(i - 1))
            '    i += 1
            'Next

            For Each prmName In prmNames
                arParameters(i) = New SqlClient.SqlParameter("@" + prmName, prmValues(i - 1))
                i += 1
            Next

            Return GetSearchData(spName, arParameters)
        End Function

        Private Function GetSearchData(ByVal commandText As String, Optional ByVal commandParameters() As SqlClient.SqlParameter = Nothing) As DataTable
            Dim cn As New SqlClient.SqlConnection(Raven.Common.HisConfiguration.ConnectionString)
            Dim cmd As SqlClient.SqlCommand
            Dim tbl As DataTable
            Dim da As SqlClient.SqlDataAdapter

            Try
                cn.Open()

                cmd = New SqlClient.SqlCommand
                tbl = New DataTable
                da = New SqlClient.SqlDataAdapter

                With cmd
                    .Connection = cn
                    .CommandText = commandText
                    .CommandType = CommandType.StoredProcedure
                    .CommandTimeout = 600
                End With

                If Not (commandParameters Is Nothing) Then
                    Dim p As SqlClient.SqlParameter
                    For Each p In commandParameters
                        If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
                            p.Value = Nothing
                        End If
                        cmd.Parameters.Add(p)
                    Next p
                End If

                da = New SqlClient.SqlDataAdapter(cmd)
                da.Fill(tbl)

                _TotalRowsCount = CType(commandParameters(0).Value, Integer)
                cmd.Parameters.Clear()

                Return tbl
            Catch ex As Exception
                Raven.Common.ExceptionManager.Publish(ex)
            Finally
                If Not cn Is Nothing Then
                    cn.Dispose()
                    cn = Nothing
                End If
                If Not cmd Is Nothing Then
                    cmd.Dispose()
                    cmd = Nothing
                End If
                If Not da Is Nothing Then
                    da.Dispose()
                    da = Nothing
                End If
                If Not tbl Is Nothing Then
                    tbl.Dispose()
                    tbl = Nothing
                End If
            End Try
        End Function

    End Class

#End Region

End Namespace