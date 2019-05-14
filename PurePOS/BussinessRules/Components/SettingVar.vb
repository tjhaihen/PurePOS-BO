Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SettingVar
        Inherits BRInteractionBase

#Region " Class Member Declarations "

        Private _jmbayarpribadi, _jmbayarinstansi As SqlString
        Private _jnmedisdokter, _jnmedisperawat As SqlString
        Private _noinvoicepribadi, _noinvoiceinstansi As SqlString
        Private _nokwitansi, _nopiutangpribadi, _nopiutanginstansi As SqlString
        Private _transinstansiplafon, _transinstansicoverage As SqlString
        Private _markupobatrj, _ppn As SqlDouble
        Private _cekstockobat, _admotomatis, _kartuotomatis, _member, _appointment As SqlBoolean
        Private _pembulatan As SqlMoney
        Private _kdlayanadm, _kdlayankartu, _kdpoliugd As SqlString
        Private _kdlayanregpoli, _kdlayanregugd, _jnpolipm, _jntarifumum, _kdinstansirs, _jnkunjunganmcu As SqlString
        Private _jnpengirimsendiri, _jnpengirimdokter, _kddokteradm, _jnpasienindividu, _kdlayanmcuadd, _kdgrouptarifmcu As SqlString
        Private _kdpolimcu, _kddoktermcu, _kdinstansiLPM, _kdpolifarmasi, _kdbank, _koordinatormcu, _kdlayanbalancing As SqlString
        Private _jkwaktuinvoice As SqlInt16
        Private _ubahkomptr1, _ubahkomptr2, _ubahkomptr3, _ubahkomptr1sl, _ubahkomptr2sl, _ubahkomptr3sl, _ubahkomptr1bb, _ubahkomptr2bb, _ubahkomptr3bb As SqlBoolean
        Private _buatnorm, _byrpendaftaran As SqlBoolean
        Private _kdpenunjangmedis As SqlString, _kdvisitpnjmedis As SqlString
#End Region


        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "sprj_SettingVariable_Update"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add(New SqlParameter("@jmbayarpribadi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jmbayarpribadi))
                cmdToExecute.Parameters.Add(New SqlParameter("@jmbayarinstansi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jmbayarinstansi))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnmedisdokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnmedisdokter))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnmedisperawat", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnmedisperawat))
                cmdToExecute.Parameters.Add(New SqlParameter("@noinvoicepribadi", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noinvoicepribadi))
                cmdToExecute.Parameters.Add(New SqlParameter("@noinvoiceinstansi", SqlDbType.Char, 3, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _noinvoiceinstansi))
                cmdToExecute.Parameters.Add(New SqlParameter("@nokwitansi", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nokwitansi))
                cmdToExecute.Parameters.Add(New SqlParameter("@nopiutangpribadi", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopiutangpribadi))
                cmdToExecute.Parameters.Add(New SqlParameter("@nopiutanginstansi", SqlDbType.Char, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _nopiutanginstansi))
                cmdToExecute.Parameters.Add(New SqlParameter("@transinstansiplafon", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transinstansiplafon))
                cmdToExecute.Parameters.Add(New SqlParameter("@transinstansicoverage", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _transinstansicoverage))
                cmdToExecute.Parameters.Add(New SqlParameter("@markupobatrj", SqlDbType.Float, 8, ParameterDirection.Input, False, 38, 0, "", DataRowVersion.Proposed, _markupobatrj))
                cmdToExecute.Parameters.Add(New SqlParameter("@ppn", SqlDbType.Float, 8, ParameterDirection.Input, False, 38, 0, "", DataRowVersion.Proposed, _ppn))
                cmdToExecute.Parameters.Add(New SqlParameter("@cekstockobat", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _cekstockobat))
                cmdToExecute.Parameters.Add(New SqlParameter("@pembulatan", SqlDbType.Money, 8, ParameterDirection.Input, False, 19, 4, "", DataRowVersion.Proposed, _pembulatan))
                cmdToExecute.Parameters.Add(New SqlParameter("@admotomatis", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _admotomatis))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayanadm", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayanadm))
                cmdToExecute.Parameters.Add(New SqlParameter("@kartuotomatis", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _kartuotomatis))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayankartu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayankartu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdpoliugd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpoliugd))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayanregpoli", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayanregpoli))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayanregugd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayanregugd))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnpolipm", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpolipm))
                cmdToExecute.Parameters.Add(New SqlParameter("@jntarifumum", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jntarifumum))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansirs", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansirs))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnkunjunganmcu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnkunjunganmcu))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnpengirimsendiri", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpengirimsendiri))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnpengirimdokter", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpengirimdokter))
                cmdToExecute.Parameters.Add(New SqlParameter("@kddokteradm", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddokteradm))
                cmdToExecute.Parameters.Add(New SqlParameter("@jnpasienindividu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jnpasienindividu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayanmcuadd", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayanmcuadd))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdgrouptarifmcu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdgrouptarifmcu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdpolimcu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpolimcu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kddoktermcu", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kddoktermcu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdinstansiLPM", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdinstansiLPM))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdpolifarmasi", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdpolifarmasi))
                cmdToExecute.Parameters.Add(New SqlParameter("@member", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _member))
                cmdToExecute.Parameters.Add(New SqlParameter("@appointment", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _appointment))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdbank", SqlDbType.Char, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdbank))
                cmdToExecute.Parameters.Add(New SqlParameter("@koordinatormcu", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _koordinatormcu))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdlayanbalancing", SqlDbType.VarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _kdlayanbalancing))
                cmdToExecute.Parameters.Add(New SqlParameter("@jkwaktuinvoice", SqlDbType.SmallInt, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _jkwaktuinvoice))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr1", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr1))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr2", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr2))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr3", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr3))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr1sl", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr1sl))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr2sl", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr2sl))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr3sl", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr3sl))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr1bb", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr1bb))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr2bb", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr2bb))
                cmdToExecute.Parameters.Add(New SqlParameter("@ubahkomptr3bb", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _ubahkomptr3bb))
                cmdToExecute.Parameters.Add(New SqlParameter("@buatnorm", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _buatnorm))
                cmdToExecute.Parameters.Add(New SqlParameter("@byrpendaftaran", SqlDbType.Bit, 1, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _byrpendaftaran))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdpenunjangmedis", SqlDbType.Char, 2, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _kdpenunjangmedis))
                cmdToExecute.Parameters.Add(New SqlParameter("@kdvisitpnjmedis", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 1, 0, "", DataRowVersion.Proposed, _kdvisitpnjmedis))

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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strSQL As String

            cmdToExecute.CommandText = "sprj_SettingVariable_SelectOne"
            cmdToExecute.CommandType = CommandType.StoredProcedure

            Dim toReturn As DataTable = New DataTable("rj_var")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _jmbayarpribadi = New SqlString(CType(toReturn.Rows(0)("jmbayarpribadi"), String))
                    _jmbayarinstansi = New SqlString(CType(toReturn.Rows(0)("jmbayarinstansi"), String))
                    _jnmedisdokter = New SqlString(CType(toReturn.Rows(0)("jnmedisdokter"), String))
                    _jnmedisperawat = New SqlString(CType(toReturn.Rows(0)("jnmedisperawat"), String))
                    _noinvoicepribadi = New SqlString(CType(toReturn.Rows(0)("noinvoicepribadi"), String))
                    _noinvoiceinstansi = New SqlString(CType(toReturn.Rows(0)("noinvoiceinstansi"), String))
                    _nokwitansi = New SqlString(CType(toReturn.Rows(0)("nokwitansi"), String))
                    _nopiutangpribadi = New SqlString(CType(toReturn.Rows(0)("nopiutangpribadi"), String))
                    _nopiutanginstansi = New SqlString(CType(toReturn.Rows(0)("nopiutanginstansi"), String))
                    _transinstansiplafon = New SqlString(CType(toReturn.Rows(0)("transinstansiplafon"), String))
                    _transinstansicoverage = New SqlString(CType(toReturn.Rows(0)("transinstansicoverage"), String))
                    _markupobatrj = New SqlDouble(CType(toReturn.Rows(0)("markupobatrj"), Double))
                    _ppn = New SqlDouble(CType(toReturn.Rows(0)("ppn"), Double))
                    _cekstockobat = New SqlBoolean(CType(toReturn.Rows(0)("cekstockobat"), Boolean))
                    _pembulatan = New SqlMoney(CType(toReturn.Rows(0)("pembulatan"), Decimal))
                    _admotomatis = New SqlBoolean(CType(toReturn.Rows(0)("admotomatis"), Boolean))
                    _kdlayanadm = New SqlString(CType(toReturn.Rows(0)("kdlayanadm"), String))
                    _kartuotomatis = New SqlBoolean(CType(toReturn.Rows(0)("kartuotomatis"), Boolean))
                    _kdlayankartu = New SqlString(CType(toReturn.Rows(0)("kdlayankartu"), String))
                    _kdpoliugd = New SqlString(CType(toReturn.Rows(0)("kdpoliugd"), String))
                    _kdlayanregpoli = New SqlString(CType(toReturn.Rows(0)("kdlayanregpoli"), String))
                    _kdlayanregugd = New SqlString(CType(toReturn.Rows(0)("kdlayanregugd"), String))
                    _jnpolipm = New SqlString(CType(toReturn.Rows(0)("jnpolipm"), String))
                    _jntarifumum = New SqlString(CType(toReturn.Rows(0)("jntarifumum"), String))
                    _kdinstansirs = New SqlString(CType(toReturn.Rows(0)("kdinstansirs"), String))
                    _jnkunjunganmcu = New SqlString(CType(toReturn.Rows(0)("jnkunjunganmcu"), String))
                    _jnpengirimsendiri = New SqlString(CType(toReturn.Rows(0)("jnpengirimsendiri"), String))
                    _jnpengirimdokter = New SqlString(CType(toReturn.Rows(0)("jnpengirimdokter"), String))
                    _kddokteradm = New SqlString(CType(toReturn.Rows(0)("kddokteradm"), String))
                    _jnpasienindividu = New SqlString(CType(toReturn.Rows(0)("jnpasienindividu"), String))
                    _kdlayanmcuadd = New SqlString(CType(toReturn.Rows(0)("kdlayanmcuadd"), String))
                    _kdgrouptarifmcu = New SqlString(CType(toReturn.Rows(0)("kdgrouptarifmcu"), String))
                    _kdpolimcu = New SqlString(CType(toReturn.Rows(0)("kdpolimcu"), String))
                    _kddoktermcu = New SqlString(CType(toReturn.Rows(0)("kddoktermcu"), String))
                    _kdinstansiLPM = New SqlString(CType(toReturn.Rows(0)("kdinstansiLPM"), String))
                    _kdpolifarmasi = New SqlString(CType(toReturn.Rows(0)("kdpolifarmasi"), String))
                    _member = New SqlBoolean(CType(toReturn.Rows(0)("member"), Boolean))
                    _appointment = New SqlBoolean(CType(toReturn.Rows(0)("appointment"), Boolean))
                    _kdbank = New SqlString(CType(toReturn.Rows(0)("kdbank"), String))
                    _koordinatormcu = New SqlString(CType(toReturn.Rows(0)("koordinatormcu"), String))
                    _kdlayanbalancing = New SqlString(CType(toReturn.Rows(0)("kdlayanbalancing"), String))
                    _jkwaktuinvoice = New SqlInt16(CType(toReturn.Rows(0)("jkwaktuinvoice"), Int16))
                    _ubahkomptr1 = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr1"), Boolean))
                    _ubahkomptr2 = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr2"), Boolean))
                    _ubahkomptr3 = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr3"), Boolean))
                    _ubahkomptr1sl = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr1sl"), Boolean))
                    _ubahkomptr2sl = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr2sl"), Boolean))
                    _ubahkomptr3sl = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr3sl"), Boolean))
                    _ubahkomptr1bb = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr1bb"), Boolean))
                    _ubahkomptr2bb = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr2bb"), Boolean))
                    _ubahkomptr3bb = New SqlBoolean(CType(toReturn.Rows(0)("ubahkomptr3bb"), Boolean))
                    _buatnorm = New SqlBoolean(CType(toReturn.Rows(0)("buatnorm"), Boolean))
                    _byrpendaftaran = New SqlBoolean(CType(toReturn.Rows(0)("byrpendaftaran"), Boolean))
                    _kdpenunjangmedis = New SqlString(CType(toReturn.Rows(0)("kdpenunjangmedis"), String))
                    _kdvisitpnjmedis = New SqlString(CType(toReturn.Rows(0)("kdvisitpnjmedis"), String))

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

        Public Property [jmbayarpribadi]() As SqlString
            Get
                Return _jmbayarpribadi
            End Get
            Set(ByVal Value As SqlString)
                Dim jmbayarpribadiTmp As SqlString = Value
                If jmbayarpribadiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jmbayarpribadi", "jmbayarpribadi can't be NULL")
                End If
                _jmbayarpribadi = Value
            End Set
        End Property


        Public Property [jmbayarinstansi]() As SqlString
            Get
                Return _jmbayarinstansi
            End Get
            Set(ByVal Value As SqlString)
                Dim jmbayarinstansiTmp As SqlString = Value
                If jmbayarinstansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jmbayarinstansi", "jmbayarinstansi can't be NULL")
                End If
                _jmbayarinstansi = Value
            End Set
        End Property


        Public Property [jnmedisdokter]() As SqlString
            Get
                Return _jnmedisdokter
            End Get
            Set(ByVal Value As SqlString)
                Dim jnmedisdokterTmp As SqlString = Value
                If jnmedisdokterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnmedisdokter", "jnmedisdokter can't be NULL")
                End If
                _jnmedisdokter = Value
            End Set
        End Property


        Public Property [jnmedisperawat]() As SqlString
            Get
                Return _jnmedisperawat
            End Get
            Set(ByVal Value As SqlString)
                Dim jnmedisperawatTmp As SqlString = Value
                If jnmedisperawatTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnmedisperawat", "jnmedisperawat can't be NULL")
                End If
                _jnmedisperawat = Value
            End Set
        End Property


        Public Property [noinvoicepribadi]() As SqlString
            Get
                Return _noinvoicepribadi
            End Get
            Set(ByVal Value As SqlString)
                Dim noinvoicepribadiTmp As SqlString = Value
                If noinvoicepribadiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("noinvoicepribadi", "noinvoicepribadi can't be NULL")
                End If
                _noinvoicepribadi = Value
            End Set
        End Property

        Public Property [noinvoiceinstansi]() As SqlString
            Get
                Return _noinvoiceinstansi
            End Get
            Set(ByVal Value As SqlString)
                Dim noinvoiceinstansiTmp As SqlString = Value
                If noinvoiceinstansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("noinvoiceinstansi", "noinvoiceinstansi can't be NULL")
                End If
                _noinvoiceinstansi = Value
            End Set
        End Property

        Public Property [nokwitansi]() As SqlString
            Get
                Return _nokwitansi
            End Get
            Set(ByVal Value As SqlString)
                Dim nokwitansiTmp As SqlString = Value
                If nokwitansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nokwitansi", "nokwitansi can't be NULL")
                End If
                _nokwitansi = Value
            End Set
        End Property

        Public Property [nopiutangpribadi]() As SqlString
            Get
                Return _nopiutangpribadi
            End Get
            Set(ByVal Value As SqlString)
                Dim nopiutangpribadiTmp As SqlString = Value
                If nopiutangpribadiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nopiutangpribadi", "nopiutangpribadi can't be NULL")
                End If
                _nopiutangpribadi = Value
            End Set
        End Property

        Public Property [nopiutanginstansi]() As SqlString
            Get
                Return _nopiutanginstansi
            End Get
            Set(ByVal Value As SqlString)
                Dim nopiutanginstansiTmp As SqlString = Value
                If nopiutanginstansiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("nopiutanginstansi", "nopiutanginstansi can't be NULL")
                End If
                _nopiutanginstansi = Value
            End Set
        End Property

        Public Property [transinstansiplafon]() As SqlString
            Get
                Return _transinstansiplafon
            End Get
            Set(ByVal Value As SqlString)
                Dim transinstansiplafonTmp As SqlString = Value
                If transinstansiplafonTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("transinstansiplafon", "transinstansiplafon can't be NULL")
                End If
                _transinstansiplafon = Value
            End Set
        End Property

        Public Property [transinstansicoverage]() As SqlString
            Get
                Return _transinstansicoverage
            End Get
            Set(ByVal Value As SqlString)
                Dim transinstansicoverageTmp As SqlString = Value
                If transinstansicoverageTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("transinstansicoverage", "transinstansicoverage can't be NULL")
                End If
                _transinstansicoverage = Value
            End Set
        End Property

        Public Property [markupobatrj]() As SqlDouble
            Get
                Return _markupobatrj
            End Get
            Set(ByVal Value As SqlDouble)
                Dim markupobatrjTmp As SqlDouble = Value
                If markupobatrjTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("markupobatrj", "markupobatrj can't be NULL")
                End If
                _markupobatrj = Value
            End Set
        End Property

        Public Property [ppn]() As SqlDouble
            Get
                Return _ppn
            End Get
            Set(ByVal Value As SqlDouble)
                Dim ppnTmp As SqlDouble = Value
                If ppnTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ppn", "ppn can't be NULL")
                End If
                _ppn = Value
            End Set
        End Property

        Public Property [cekstockobat]() As SqlBoolean
            Get
                Return _cekstockobat
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim cekstockobatTmp As SqlBoolean = Value
                If cekstockobatTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("cekstockobat", "cekstockobat can't be NULL")
                End If
                _cekstockobat = Value
            End Set
        End Property

        Public Property [pembulatan]() As SqlMoney
            Get
                Return _pembulatan
            End Get
            Set(ByVal Value As SqlMoney)
                Dim pembulatanTmp As SqlMoney = Value
                If pembulatanTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("pembulatan", "pembulatan can't be NULL")
                End If
                _pembulatan = Value
            End Set
        End Property

        Public Property [admotomatis]() As SqlBoolean
            Get
                Return _admotomatis
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim admotomatisTmp As SqlBoolean = Value
                If admotomatisTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("admotomatis", "admotomatis can't be NULL")
                End If
                _admotomatis = Value
            End Set
        End Property

        Public Property [kdlayanadm]() As SqlString
            Get
                Return _kdlayanadm
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayanadmTmp As SqlString = Value
                If kdlayanadmTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayanadm", "kdlayanadm can't be NULL")
                End If
                _kdlayanadm = Value
            End Set
        End Property

        Public Property [kartuotomatis]() As SqlBoolean
            Get
                Return _kartuotomatis
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim kartuotomatisTmp As SqlBoolean = Value
                If kartuotomatisTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kartuotomatis", "kartuotomatis can't be NULL")
                End If
                _kartuotomatis = Value
            End Set
        End Property

        Public Property [kdlayankartu]() As SqlString
            Get
                Return _kdlayankartu
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayankartuTmp As SqlString = Value
                If kdlayankartuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayankartu", "kdlayankartu can't be NULL")
                End If
                _kdlayankartu = Value
            End Set
        End Property

        Public Property [kdpoliugd]() As SqlString
            Get
                Return _kdpoliugd
            End Get
            Set(ByVal Value As SqlString)
                Dim kdpoliugdTmp As SqlString = Value
                If kdpoliugdTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdpoliugd", "kdpoliugd can't be NULL")
                End If
                _kdpoliugd = Value
            End Set
        End Property

        Public Property [kdlayanregpoli]() As SqlString
            Get
                Return _kdlayanregpoli
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayanregpoliTmp As SqlString = Value
                If kdlayanregpoliTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayanregpoli", "kdlayanregpoli can't be NULL")
                End If
                _kdlayanregpoli = Value
            End Set
        End Property

        Public Property [kdlayanregugd]() As SqlString
            Get
                Return _kdlayanregugd
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayanregugdTmp As SqlString = Value
                If kdlayanregugdTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayanregugd", "kdlayanregugd can't be NULL")
                End If
                _kdlayanregugd = Value
            End Set
        End Property

        Public Property [jnpolipm]() As SqlString
            Get
                Return _jnpolipm
            End Get
            Set(ByVal Value As SqlString)
                Dim jnpolipmTmp As SqlString = Value
                If jnpolipmTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnpolipm", "jnpolipm can't be NULL")
                End If
                _jnpolipm = Value
            End Set
        End Property

        Public Property [jntarifumum]() As SqlString
            Get
                Return _jntarifumum
            End Get
            Set(ByVal Value As SqlString)
                Dim jntarifumumTmp As SqlString = Value
                If jntarifumumTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jntarifumum", "jntarifumum can't be NULL")
                End If
                _jntarifumum = Value
            End Set
        End Property

        Public Property [kdinstansirs]() As SqlString
            Get
                Return _kdinstansirs
            End Get
            Set(ByVal Value As SqlString)
                Dim kdinstansirsTmp As SqlString = Value
                If kdinstansirsTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdinstansirs", "kdinstansirs can't be NULL")
                End If
                _kdinstansirs = Value
            End Set
        End Property

        Public Property [jnkunjunganmcu]() As SqlString
            Get
                Return _jnkunjunganmcu
            End Get
            Set(ByVal Value As SqlString)
                Dim jnkunjunganmcuTmp As SqlString = Value
                If jnkunjunganmcuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnkunjunganmcu", "jnkunjunganmcu can't be NULL")
                End If
                _jnkunjunganmcu = Value
            End Set
        End Property

        Public Property [jnpengirimsendiri]() As SqlString
            Get
                Return _jnpengirimsendiri
            End Get
            Set(ByVal Value As SqlString)
                Dim jnpengirimsendiriTmp As SqlString = Value
                If jnpengirimsendiriTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnpengirimsendiri", "jnpengirimsendiri can't be NULL")
                End If
                _jnpengirimsendiri = Value
            End Set
        End Property

        Public Property [jnpengirimdokter]() As SqlString
            Get
                Return _jnpengirimdokter
            End Get
            Set(ByVal Value As SqlString)
                Dim jnpengirimdokterTmp As SqlString = Value
                If jnpengirimdokterTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnpengirimdokter", "jnpengirimdokter can't be NULL")
                End If
                _jnpengirimdokter = Value
            End Set
        End Property

        Public Property [kddokteradm]() As SqlString
            Get
                Return _kddokteradm
            End Get
            Set(ByVal Value As SqlString)
                Dim kddokteradmTmp As SqlString = Value
                If kddokteradmTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddokteradm", "kddokteradm can't be NULL")
                End If
                _kddokteradm = Value
            End Set
        End Property

        Public Property [jnpasienindividu]() As SqlString
            Get
                Return _jnpasienindividu
            End Get
            Set(ByVal Value As SqlString)
                Dim jnpasienindividuTmp As SqlString = Value
                If jnpasienindividuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jnpasienindividu", "jnpasienindividu can't be NULL")
                End If
                _jnpasienindividu = Value
            End Set
        End Property

        Public Property [kdlayanmcuadd]() As SqlString
            Get
                Return _kdlayanmcuadd
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayanmcuaddTmp As SqlString = Value
                If kdlayanmcuaddTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayanmcuadd", "kdlayanmcuadd can't be NULL")
                End If
                _kdlayanmcuadd = Value
            End Set
        End Property

        Public Property [kdgrouptarifmcu]() As SqlString
            Get
                Return _kdgrouptarifmcu
            End Get
            Set(ByVal Value As SqlString)
                Dim kdgrouptarifmcuTmp As SqlString = Value
                If kdgrouptarifmcuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdgrouptarifmcu", "kdgrouptarifmcu can't be NULL")
                End If
                _kdgrouptarifmcu = Value
            End Set
        End Property

        Public Property [kdpolimcu]() As SqlString
            Get
                Return _kdpolimcu
            End Get
            Set(ByVal Value As SqlString)
                Dim kdpolimcuTmp As SqlString = Value
                If kdpolimcuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdpolimcu", "kdpolimcu can't be NULL")
                End If
                _kdpolimcu = Value
            End Set
        End Property

        Public Property [kddoktermcu]() As SqlString
            Get
                Return _kddoktermcu
            End Get
            Set(ByVal Value As SqlString)
                Dim kddoktermcuTmp As SqlString = Value
                If kddoktermcuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kddoktermcu", "kddoktermcu can't be NULL")
                End If
                _kddoktermcu = Value
            End Set
        End Property

        Public Property [kdinstansiLPM]() As SqlString
            Get
                Return _kdinstansiLPM
            End Get
            Set(ByVal Value As SqlString)
                Dim kdinstansiLPMTmp As SqlString = Value
                If kdinstansiLPMTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdinstansiLPM", "kdinstansiLPM can't be NULL")
                End If
                _kdinstansiLPM = Value
            End Set
        End Property

        Public Property [kdpolifarmasi]() As SqlString
            Get
                Return _kdpolifarmasi
            End Get
            Set(ByVal Value As SqlString)
                Dim kdpolifarmasiTmp As SqlString = Value
                If kdpolifarmasiTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdpolifarmasi", "kdpolifarmasi can't be NULL")
                End If
                _kdpolifarmasi = Value
            End Set
        End Property

        Public Property [member]() As SqlBoolean
            Get
                Return _member
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim memberTmp As SqlBoolean = Value
                If memberTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("member", "member can't be NULL")
                End If
                _member = Value
            End Set
        End Property

        Public Property [appointment]() As SqlBoolean
            Get
                Return _appointment
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim appointmentTmp As SqlBoolean = Value
                If appointmentTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("appointment", "appointment can't be NULL")
                End If
                _appointment = Value
            End Set
        End Property

        Public Property [kdbank]() As SqlString
            Get
                Return _kdbank
            End Get
            Set(ByVal Value As SqlString)
                Dim kdbankTmp As SqlString = Value
                If kdbankTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdbank", "kdbank can't be NULL")
                End If
                _kdbank = Value
            End Set
        End Property

        Public Property [koordinatormcu]() As SqlString
            Get
                Return _koordinatormcu
            End Get
            Set(ByVal Value As SqlString)
                Dim koordinatormcuTmp As SqlString = Value
                If koordinatormcuTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("koordinatormcu", "koordinatormcu can't be NULL")
                End If
                _koordinatormcu = Value
            End Set
        End Property

        Public Property [kdlayanbalancing]() As SqlString
            Get
                Return _kdlayanbalancing
            End Get
            Set(ByVal Value As SqlString)
                Dim kdlayanbalancingTmp As SqlString = Value
                If kdlayanbalancingTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdlayanbalancing", "kdlayanbalancing can't be NULL")
                End If
                _kdlayanbalancing = Value
            End Set
        End Property

        Public Property [jkwaktuinvoice]() As SqlInt16
            Get
                Return _jkwaktuinvoice
            End Get
            Set(ByVal Value As SqlInt16)
                Dim jkwaktuinvoiceTmp As SqlInt16 = Value
                If jkwaktuinvoiceTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("jkwaktuinvoice", "jkwaktuinvoice can't be NULL")
                End If
                _jkwaktuinvoice = Value
            End Set
        End Property

        Public Property [ubahkomptr1]() As SqlBoolean
            Get
                Return _ubahkomptr1
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr1Tmp As SqlBoolean = Value
                If ubahkomptr1Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr1", "ubahkomptr1 can't be NULL")
                End If
                _ubahkomptr1 = Value
            End Set
        End Property

        Public Property [ubahkomptr2]() As SqlBoolean
            Get
                Return _ubahkomptr2
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr2Tmp As SqlBoolean = Value
                If ubahkomptr2Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr2", "ubahkomptr2 can't be NULL")
                End If
                _ubahkomptr2 = Value
            End Set
        End Property

        Public Property [ubahkomptr3]() As SqlBoolean
            Get
                Return _ubahkomptr3
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr3Tmp As SqlBoolean = Value
                If ubahkomptr3Tmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr3", "ubahkomptr3 can't be NULL")
                End If
                _ubahkomptr3 = Value
            End Set
        End Property

        Public Property [ubahkomptr1sl]() As SqlBoolean
            Get
                Return _ubahkomptr1sl
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr1slTmp As SqlBoolean = Value
                If ubahkomptr1slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr1sl", "ubahkomptr1sl can't be NULL")
                End If
                _ubahkomptr1sl = Value
            End Set
        End Property

        Public Property [ubahkomptr2sl]() As SqlBoolean
            Get
                Return _ubahkomptr2sl
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr2slTmp As SqlBoolean = Value
                If ubahkomptr2slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr2sl", "ubahkomptr2sl can't be NULL")
                End If
                _ubahkomptr2sl = Value
            End Set
        End Property

        Public Property [ubahkomptr3sl]() As SqlBoolean
            Get
                Return _ubahkomptr3sl
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr3slTmp As SqlBoolean = Value
                If ubahkomptr3slTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr3sl", "ubahkomptr3sl can't be NULL")
                End If
                _ubahkomptr3sl = Value
            End Set
        End Property

        Public Property [ubahkomptr1bb]() As SqlBoolean
            Get
                Return _ubahkomptr1bb
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr1bbTmp As SqlBoolean = Value
                If ubahkomptr1bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr1bb", "ubahkomptr1bb can't be NULL")
                End If
                _ubahkomptr1bb = Value
            End Set
        End Property

        Public Property [ubahkomptr2bb]() As SqlBoolean
            Get
                Return _ubahkomptr2bb
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr2bbTmp As SqlBoolean = Value
                If ubahkomptr2bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr2bb", "ubahkomptr2bb can't be NULL")
                End If
                _ubahkomptr2bb = Value
            End Set
        End Property

        Public Property [ubahkomptr3bb]() As SqlBoolean
            Get
                Return _ubahkomptr3bb
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim ubahkomptr3bbTmp As SqlBoolean = Value
                If ubahkomptr3bbTmp.IsNull Then
                    Throw New ArgumentOutOfRangeException("ubahkomptr3bb", "ubahkomptr3bb can't be NULL")
                End If
                _ubahkomptr3bb = Value
            End Set
        End Property

        Public Property [buatnorm]() As SqlBoolean
            Get
                Return _buatnorm
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim buatnorm As SqlBoolean = Value
                If buatnorm.IsNull Then
                    Throw New ArgumentOutOfRangeException("buatnorm", "buatnorm can't be null")
                End If
                _buatnorm = Value
            End Set
        End Property

        Public Property [byrpendaftaran]() As SqlBoolean
            Get
                Return _byrpendaftaran
            End Get
            Set(ByVal Value As SqlBoolean)
                Dim byrpendaftaran As SqlBoolean = Value
                If byrpendaftaran.IsNull Then
                    Throw New ArgumentOutOfRangeException("byrpendaftaran", "byrpendaftaran can't be null")
                End If
                _byrpendaftaran = Value
            End Set
        End Property
        Public Property [kdpenunjangmedis]() As SqlString
            Get
                Return _kdpenunjangmedis
            End Get
            Set(ByVal Value As SqlString)
                Dim kdpenunjangmedis As SqlString = Value
                If kdpenunjangmedis.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdpenunjangmedis", "kdpenunjangmedis can't be null")
                End If
                _kdpenunjangmedis = Value
            End Set
        End Property
        Public Property [kdvisitpnjmedis]() As SqlString
            Get
                Return _kdvisitpnjmedis
            End Get
            Set(ByVal Value As SqlString)
                Dim kdvisitpnjmedis As SqlString = Value
                If kdvisitpnjmedis.IsNull Then
                    Throw New ArgumentOutOfRangeException("kdvisitpnjmedis", "kdvisitpnjmedis can't be null")
                End If
                _kdvisitpnjmedis = Value
            End Set
        End Property
#End Region
    End Class
End Namespace
