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

Imports System.Data.SqlTypes

Imports Raven.Common


Namespace Raven.Web

    Public Class JSDLGGlobalVar
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Me.Controls.Add(New LiteralControl("var urlbdokterradio='" + PageBase.UrlBase + "/search/s_tenagaahli.htm'; //kode" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbNoBukti='" + PageBase.UrlBase + "/search/SNoBukti.htm'; //nobukti" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbKdDokter='" + PageBase.UrlBase + "/search/SMedis.htm'; //kddokter" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbKdDokterRi='" + PageBase.UrlBase + "/search/SMedisRi.htm'; //dokter rawat inap" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbKdDokterRj='" + PageBase.UrlBase + "/search/SMedisRj.htm'; //dokter rawat jalan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdokterperpoli='" + PageBase.UrlBase + "/search/SDokterPerPoli.htm'; //dokter per poli" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdokterperpolipertgl='" + PageBase.UrlBase + "/search/SDokterPerPoliPerTgl.htm'; //dokter per poli per tgl" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpoliperdokter='" + PageBase.UrlBase + "/search/sPoliPerDokter.htm'; //poli per dokter" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbbank='" + PageBase.UrlBase + "/search/SBank.htm'; //Bank" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmedis='" + PageBase.UrlBase + "/search/SMedis.htm'; //medis" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpoliklinik='" + PageBase.UrlBase + "/search/sPoliklinik.htm'; //Poliklinik" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbkasus='" + PageBase.UrlBase + "/search/SKasus.htm'; //kdkasus" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbsmf='" + PageBase.UrlBase + "/search/SSMF.htm'; //kdsmf" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdtd='" + PageBase.UrlBase + "/search/SDtd.htm'; //dtd" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdiagnosa='" + PageBase.UrlBase + "/search/SDiagnosa.htm'; //diagnosa" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbjasamedik='" + PageBase.UrlBase + "/search/SJasaMedik.htm'; //jasa medik - detil" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbGrpJasaMedis='" + PageBase.UrlBase + "/search/SJasaMedisGroup.htm'; //kdgroupjasa" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpasien='" + PageBase.UrlBase + "/search/SPasien.htm'; //pasien" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmember='" + PageBase.UrlBase + "/search/SMember.htm'; //member" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbinstansi='" + PageBase.UrlBase + "/search/SInstansi.htm'; //instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbGroupPoliklinik='" + PageBase.UrlBase + "/search/SGroupPoliklinik.htm'; //Group Poliklinik" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbplafon='" + PageBase.UrlBase + "/search/SPlafon.htm'; //plafon instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtarifgroup='" + PageBase.UrlBase + "/search/STarifGroup.htm'; //tarif - group" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtarifitem='" + PageBase.UrlBase + "/search/STarifPelayanan.htm'; //tarif - pelayanan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbkodepos='" + PageBase.UrlBase + "/search/SKodePos.htm'; //kdpos" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmtxitempoli='" + PageBase.UrlBase + "/search/s_layanpoli.htm'; //mtx pelayanan - poli" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbappointment='" + PageBase.UrlBase + "/search/SAppointment.htm'; //appointment" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbappointmentwithnorm='" + PageBase.UrlBase + "/search/SAppointmentWithNorm.htm'; //appointment" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbappointmentwithoutnorm='" + PageBase.UrlBase + "/search/SAppointmentWithoutNorm.htm'; //appointment" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasi='" + PageBase.UrlBase + "/search/SRegistrasi.htm'; //registrasi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpembayaran='" + PageBase.UrlBase + "/search/s_bayar.htm'; // pembayaran" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpembayaranbynoreg='" + PageBase.UrlBase + "/search/s_bayarbynoreg.htm'; // pembayaran berdasarkan Nomor Registrasi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbjasamedikgroup='" + PageBase.UrlBase + "/search/s018.htm'; // jasa medik - group" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdokter='" + PageBase.UrlBase + "/search/SKdDokter.htm'; // dokter rawat jalan yang aktif" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpaketmember='" + PageBase.UrlBase + "/search/s020.htm'; // paket member" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasirekal='" + PageBase.UrlBase + "/search/s021.htm'; // registrasi untuk rekalkulasi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbcutidokter='" + PageBase.UrlBase + "/search/s022.htm'; // no. bukti untuk cuti dokter" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpiutangins='" + PageBase.UrlBase + "/search/SNoInvoiceIns.htm'; //no. Invoice untuk proses piutang instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpiutangpbd='" + PageBase.UrlBase + "/search/SNoInvoicePri.htm'; //no. Invoice untuk proses piutang pribadi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbinspiutang='" + PageBase.UrlBase + "/search/SPiutangInstansi.htm'; //instansi yang masih piutang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpbdpiutang='" + PageBase.UrlBase + "/search/SPiutangPribadi.htm'; ///pribadi yang masih piutang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbbyrpiutangins='" + PageBase.UrlBase + "/search/SByrPiutInst.htm'; //no. Bayar untuk piutang instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbbyrpiutangpbd='" + PageBase.UrlBase + "/search/SByrPiutPbd.htm'; // no. Bayar untuk piutang pribadi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbinsoutstanding='" + PageBase.UrlBase + "/search/SInsOutStanding.htm'; // instansi yang masih outstanding" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpbdoutstanding='" + PageBase.UrlBase + "/search/SPbdOutStanding.htm'; // pribadi yang masih outstanding" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbstdfield='" + PageBase.UrlBase + "/search/s031.htm'; // header standard field" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasimcu2='" + PageBase.UrlBase + "/search/s032.htm'; // registrasi untuk mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasimcu='" + PageBase.UrlBase + "/search/s033.htm'; // no. bukti untuk registrasi mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpaketmcu='" + PageBase.UrlBase + "/search/s034.htm'; // paket mcu untuk pasien umum" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpaketmcuprsh='" + PageBase.UrlBase + "/search/s035.htm'; // paket mcu untuk pasien perusahaan kontrak" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtarifmcuprsh='" + PageBase.UrlBase + "/search/s036.htm'; // tarif - mcu perusahaan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbitem='" + PageBase.UrlBase + "/search/SMasterObat.htm'; //inventory item" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasihasilmcu='" + PageBase.UrlBase + "/search/s038.htm'; //registrasi untuk hasil mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbhasilmcu='" + PageBase.UrlBase + "/search/s039.htm'; //hasil mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmemberreg='" + PageBase.UrlBase + "/search/SMember.htm'; //member untuk form registrasi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpasienaktif='" + PageBase.UrlBase + "/search/SNomorRM.htm'; //pasien yang aktif" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpengirim='" + PageBase.UrlBase + "/search/SPengirim.htm'; //pengirim" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbbayarreg='" + PageBase.UrlBase + "/search/s_bayarreg.htm'; //registrasi untuk pembayaran" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbopenreg='" + PageBase.UrlBase + "/search/s044.htm'; //registrasi untuk open" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbuseraccounts='" + PageBase.UrlBase + "/search/s045.htm'; //user accounts" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbnobuktitranspaket='" + PageBase.UrlBase + "/search/SNoBuktiTransPaket.htm'; //no. bukti untuk transaksi paket" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbnobuktitranspaket2='" + PageBase.UrlBase + "/search/s_transpaket.htm'; //no. bukti untuk transaksi paket per norm dan kdpoli" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbclosereg='" + PageBase.UrlBase + "/search/SRegistrasiClose.htm'; //registrasi untuk close" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbkdnkeluar='" + PageBase.UrlBase + "/search/SKdnKeluar.htm'; //keadaan keluar" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbcarakeluar='" + PageBase.UrlBase + "/search/SCaraKeluar.htm'; //cara keluar" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtdklanjut='" + PageBase.UrlBase + "/search/STdkLanjut.htm'; //tindak lanjut" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpembjm='" + PageBase.UrlBase + "/search/s052.htm'; //Pelayanan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmorfologi='" + PageBase.UrlBase + "/search/SMorfologi.htm'; //master morfologi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbmtxdiagpoli='" + PageBase.UrlBase + "/search/SMtxDiagPoli.htm'; //mtx diagnosa - poli" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbgudang='" + PageBase.UrlBase + "/search/SGudang.htm'; //gudang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregpernorm='" + PageBase.UrlBase + "/search/s056.htm'; //registrasi per norm" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtranshdpernoreg='" + PageBase.UrlBase + "/search/s057.htm'; //trans header per noreg" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbtindakan='" + PageBase.UrlBase + "/search/STindakan.htm'; //master tindakan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbdokterans='" + PageBase.UrlBase + "/search/SDokterAnes.htm'; //dokter anestesi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregmcumassal='" + PageBase.UrlBase + "/search/s060.htm'; //registrasi mcu massal" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbhasilmcuins='" + PageBase.UrlBase + "/search/s061.htm'; //hasil mcu instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasihasilmcuins='" + PageBase.UrlBase + "/search/s062.htm'; //registrasi untuk hasil mcu instansi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbMatriksPelayananPnjMedis='" + PageBase.UrlBase + "/search/s_layanpnj.htm'; //Pelayanan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbObatpnj='" + PageBase.UrlBase + "/search/s_obatpnj.htm'; //Obat" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbObatpoli='" + PageBase.UrlBase + "/search/s_obatpoli.htm'; //Obat" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpoliklinikaktif='" + PageBase.UrlBase + "/search/SPoliklinikAktif.htm'; //Poliklinik" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpbdpiutangwriteoff='" + PageBase.UrlBase + "/search/s_writeoffpiutpbd.htm'; ///pribadi yang masih piutang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbinspiutangwriteoff='" + PageBase.UrlBase + "/search/s_writeoffpiutins.htm'; //instansi yang masih piutang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasihasilmcu2='" + PageBase.UrlBase + "/search/s_regforhasilmcu2.htm'; //registrasi untuk hasil mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbhasilmcu2='" + PageBase.UrlBase + "/search/s_hasilmcu2.htm'; //hasil mcu" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbpakettindakanrjmtx='" + PageBase.UrlBase + "/search/s_mdpaketmtx.htm'; //Transaksi Tindakan Paket Per norm penunjang" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbDokterPengirim='" + PageBase.UrlBase + "/search/s_dokterpengirim.htm'; //Dokter Pengirim" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasikb='" + PageBase.UrlBase + "/search/sRegistrasikb.htm'; //registrasi kb" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbregistrasipnjmedis='" + PageBase.UrlBase + "/search/SRegistrasimd.htm'; //registrasi penunjang medis" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbkelas='" + PageBase.UrlBase + "/search/SKelas.htm'; //master kelas" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPoliklinikTrHD='" + PageBase.UrlBase + "/search/s_politrhd.htm'; //poliklinik transaksi hd" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPnjMedis='" + PageBase.UrlBase + "/search/s_pnjmedis.htm'; //master pnj medis" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbJasaMedisAll='" + PageBase.UrlBase + "/search/s_jasamedis.htm'; //jasa medis all" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbatur='" + PageBase.UrlBase + "/search/SAtur.htm'; //Master Aturan " + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbstokitem='" + PageBase.UrlBase + "/search/SItem.htm'; //Item By Gudang and Supplier" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbRegtdkbtl='" + PageBase.UrlBase + "/search/SREGTB.htm'; //Item By Gudang and Supplier" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlblogistikrj='" + PageBase.UrlBase + "/search/s_logistikrj.htm'; //Logistik" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlblogistikpnj='" + PageBase.UrlBase + "/search/s_logistikpnj.htm'; //Logistik" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbtest='" + PageBase.UrlBase + "/search/s_test.htm'; //test lab" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPegawai='" + PageBase.UrlBase + "/search/SPEG.htm'; //pegawai" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbSuku='" + PageBase.UrlBase + "/search/s_suku.htm'; //suku" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPropinsi='" + PageBase.UrlBase + "/search/s_propinsi.htm'; //propinsi" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPekerjaan='" + PageBase.UrlBase + "/search/s_pekerjaan.htm'; //pekerjaan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbPendidikan='" + PageBase.UrlBase + "/search/s_pendidikan.htm'; //pendidikan" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbAgama='" + PageBase.UrlBase + "/search/s_agama.htm'; //agama" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbStatusKawin='" + PageBase.UrlBase + "/search/s_statuskawin.htm'; //status kawin" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbKewarganegaraan='" + PageBase.UrlBase + "/search/s_kewarganegaraan.htm'; //kewarganegaraan" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbJenisDiagnosa='" + PageBase.UrlBase + "/search/s_jenisdiagnosa.htm'; //jenis diagnosa" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbJenisKasus='" + PageBase.UrlBase + "/search/s_JenisKasus.htm'; //Jenis Kasus" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbTransaksi='" + PageBase.UrlBase + "/search/s_Transaksi.htm'; // Transaksi RJ" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbnobatchbykditem='" + PageBase.UrlBase + "/search/SNoBatchByKdItem.htm'; //No Batch By KdItem" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbAktiva='" + PageBase.UrlBase + "/search/s_aktiva.htm'; //aktiva berdasarkan kdAktiva" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbnojobynoreg='" + PageBase.UrlBase + "/search/SNoJOByNoReg.htm'; //NoJO By NoReg" + Environment.NewLine))

            Me.Controls.Add(New LiteralControl("var urlbgroup='" + PageBase.UrlBase + "/search/s_Group.htm'; // Group" + Environment.NewLine))
            Me.Controls.Add(New LiteralControl("var urlbanggotainst='" + PageBase.UrlBase + "/search/s_anggotainst.htm';//Anggota Instansi" + Environment.NewLine))
            '
            '
        End Sub

    End Class

End Namespace