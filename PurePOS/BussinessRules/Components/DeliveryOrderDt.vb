Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class DeliveryOrderDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _DONO, _ItemSeqNo, _ItemID, _ItemUnitID, _ItemFactor, _Qty, _Price, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt As String
        Private _Disc3Pct, _Disc3Amt, _QtySale, _Description As String
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As String
        Private _IsBonus, _IsDeleted, _IsRelease As Boolean
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO DeliveryOrderDt " & _
                                       "(ID, DONO, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                                       "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtySale, IsBonus, UserInsert, InsertDate, " & _
                                       "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, UserRelease, ReleaseDate,IsRelease, Description) " & _
                                       "VALUES (@ID, @DONO, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                                       "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                                       "@UserUpdate, getdate(), '', '', 0, '', '', 0, left(@Description,500)) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@DONO", _DONO)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
                cmdToExecute.Parameters.Add("@Price", _Price)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.Add("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.Add("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.Add("@IsBonus", _IsBonus)
                cmdToExecute.Parameters.Add("@UserInsert", _UserInsert)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)

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

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "UPDATE DeliveryOrderDt " & _
                                        "SET ItemSeqNo = @ItemSeqNo, " & _
                                        "ItemUnitID = @ItemUnitID, " & _
                                        "ItemFactor = @ItemFactor, " & _
                                        "Qty = @Qty, " & _
                                        "Price = @Price, " & _
                                        "Disc1Pct = @Disc1Pct, " & _
                                        "Disc1Amt = @Disc1Amt, " & _
                                        "Disc2Pct = @Disc2Pct, " & _
                                        "Disc2Amt = @Disc2Amt, " & _
                                        "Disc3Pct = @Disc3Pct, " & _
                                        "Disc3Amt = @Disc3Amt, " & _
                                        "IsBonus = @IsBonus, " & _
                                        "UserUpdate = @UserUpdate, " & _
                                        "UpdateDate = GetDate(), " & _
                                        "Description = left(@Description,500) " & _
                                        "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@ItemSeqNo", _ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", _ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", _ItemFactor)
                cmdToExecute.Parameters.Add("@Qty", _Qty)
                cmdToExecute.Parameters.Add("@Price", _Price)
                cmdToExecute.Parameters.Add("@Disc1Pct", _Disc1Pct)
                cmdToExecute.Parameters.Add("@Disc1Amt", _Disc1Amt)
                cmdToExecute.Parameters.Add("@Disc2Pct", _Disc2Pct)
                cmdToExecute.Parameters.Add("@Disc2Amt", _Disc2Amt)
                cmdToExecute.Parameters.Add("@Disc3Pct", _Disc3Pct)
                cmdToExecute.Parameters.Add("@Disc3Amt", _Disc3Amt)
                cmdToExecute.Parameters.Add("@IsBonus", _IsBonus)
                cmdToExecute.Parameters.Add("@UserUpdate", _UserUpdate)
                cmdToExecute.Parameters.Add("@Description", _Description)

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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderDt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectAllByDONO() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderDt where IsDeleted = 0 and DONO = @DONO order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONO", _DONO)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderDt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderDt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM DeliveryOrderDt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _ID = CType(toReturn.Rows(0)("ID"), String)
                    _DONO = CType(toReturn.Rows(0)("DONO"), String)
                    _ItemSeqNo = CType(toReturn.Rows(0)("ItemSeqNo"), String)
                    _ItemUnitID = CType(toReturn.Rows(0)("ItemUnitID"), String)

                    _ItemFactor = CType(toReturn.Rows(0)("ItemFactor"), Decimal)
                    _Qty = CType(toReturn.Rows(0)("Qty"), Decimal)
                    _Price = CType(toReturn.Rows(0)("Price"), Decimal)
                    _Disc1Pct = CType(toReturn.Rows(0)("Disc1Pct"), Decimal)
                    _Disc1Amt = CType(toReturn.Rows(0)("Disc1Amt"), Decimal)
                    _Disc2Pct = CType(toReturn.Rows(0)("Disc2Pct"), Decimal)
                    _Disc2Amt = CType(toReturn.Rows(0)("Disc2Amt"), Decimal)
                    _Disc3Pct = CType(toReturn.Rows(0)("Disc3Pct"), Decimal)
                    _Disc3Amt = CType(toReturn.Rows(0)("Disc3Amt"), Decimal)
                    _QtySale = CType(toReturn.Rows(0)("QtySale"), Decimal)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)

                    _IsRelease = CType(toReturn.Rows(0)("IsRelease"), Boolean)
                    _IsBonus = CType(toReturn.Rows(0)("IsBonus"), Boolean)
                    _IsDeleted = CType(toReturn.Rows(0)("IsDeleted"), Boolean)

                    _Description = CType(toReturn.Rows(0)("Description"), String)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update DeliveryOrderDt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE ID = @ID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
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

        Public Function DeleteAllByDONO() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update DeliveryOrderDt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and DONO = @DONO"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONO", _DONO)
                cmdToExecute.Parameters.Add("@UserDelete", _UserDelete)

                ' //Open Connection
                _mainConnection.Open()

                ' //Execute Query
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

#Region "Others Function"
        Public Function SelectForViewGrid() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.Qty , " + _
                                       "dt.ItemFactor , " + _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "dt.IsBonus " + _
                                       "FROM DeliveryOrderHD hd " + _
                                       "inner join DeliveryOrderDt dt ON dt.DONO = hd.DONO " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "WHERE dt.IsDeleted = 0 AND dt.DONO = @DONO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONO", _DONO)
                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectForViewGridDOManagement(ByVal DueDate As DateTime, ByVal EntitiesSeqNo As String, ByVal Currency As String, ByVal WhID As String, ByVal UnitID As String, ByVal DeliveryZoneID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT DISTINCT x.* FROM ( " + _
                                       "SELECT " + _
                                       "hd.DONO , " + _
                                       "hd.DODate , " + _
                                       "hd.DueDate , " + _
                                       "hd.EntitiesSeqNo , " + _
                                       "isnull(En.EntitiesName,'') as EntitiesName , " + _
                                       "hd.WhID , " + _
                                       "hd.UnitID , " + _
                                       "isnull(w.WhName,'') as WhName , " + _
                                       "isnull(w.UnitName,'') as UnitName , " + _
                                       "datediff(day,hd.DODate, @DueDate) as Ageinday, " + _
                                       "datediff(day,hd.DueDate, @DueDate) as OverDueInDay, " + _
                                       "hd.DeliveryAddress, hd.PrimaryPhoneNo, hd.DeliveryZoneID, " + _
                                       "ISNULL((SELECT DeliveryZoneName FROM DeliveryZoneHd WHERE DeliveryZoneID = hd.DeliveryZoneID), '') AS DeliveryZoneName, " + _
                                       "hd.IsPrinted, hd.UserPrinted, ISNULL(CONVERT(varchar,hd.PrintedDate,105) + ' ' + CONVERT(varchar,hd.PrintedDate,108), '') AS PrintedDate " + _
                                       "FROM DeliveryOrderHD hd " + _
                                       "inner join DeliveryOrderDt dt ON dt.DONO = hd.DONO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "LEFT JOIN Warehouse w ON w.WhID = hd.WhID AND w.UnitID = hd.UnitID " + _
                                       "LEFT JOIN Entities En ON En.EntitiesSeqNo = hd.EntitiesSeqNo  " + _
                                       "WHERE dt.IsDeleted = 0 " + _
                                       "and convert(varchar(8),hd.DueDate,112) <= convert(varchar(8),@DueDate,112) " + _
                                       "and hd.Currency = @Currency " + _
                                       IIf(WhID.Trim = "none" OrElse WhID.Trim = "", "", "AND hd.WhID = @WhID ") + _
                                       IIf(UnitID.Trim = "none" OrElse UnitID.Trim = "", "", "and hd.UnitID = @UnitID ") + _
                                       IIf(EntitiesSeqNo.Trim = "", "", "and hd.EntitiesSeqNo = @EntitiesSeqNo ") + _
                                       IIf(DeliveryZoneID.Trim = "none" OrElse DeliveryZoneID.Trim = "", "", "and hd.DeliveryZoneID = @DeliveryZoneID ") + _
                                       ") x " + _
                                       "ORDER BY x.AgeInDay DESC, x.EntitiesName, x.DONO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DueDate", DueDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
                cmdToExecute.Parameters.Add("@WhID", WhID)
                cmdToExecute.Parameters.Add("@UnitID", UnitID)
                cmdToExecute.Parameters.Add("@DeliveryZoneID", DeliveryZoneID)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectForViewGridDOManagementDetail() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY it.ItemID) as AutoNo, dt.ID, " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty , " + _
                                       "dt.QtySale , " + _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "dt.IsBonus " + _
                                       "FROM DeliveryOrderHD hd " + _
                                       "inner join DeliveryOrderDt dt ON dt.DONO = hd.DONO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "WHERE hd.IsDeleted = 0 and dt.IsDeleted = 0 " + _
                                       "and hd.DONO = @DONO " + _
                                       "order by it.ItemID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONo", _DONO)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function SelectForViewGridDOForSU(ByVal EntitiesSeqNo As String, ByVal Currency As String, ByVal WhID As String, ByVal UnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "hd.DONO , " + _
                                       "hd.DODate , " + _
                                       "hd.DueDate , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty, " + _
                                       "dt.ItemFactor , " + _
                                       "dt.QtySale , " + _
                                       "isnull(pu.QtySU,0) AS QtySU, " & _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "datediff(day,hd.DODate, getdate()) as Ageinday, " + _
                                       "dt.IsBonus " + _
                                       "FROM DeliveryOrderHD hd " + _
                                       "inner join DeliveryOrderDt dt ON dt.DONO = hd.DONO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "LEFT JOIN " & _
                                       "( " & _
                                         "SELECT pudt.IDDO,puhd.DONO,sum(pudt.Qty * pudt.ItemFactor) AS QtySU " & _
                                         "FROM SalesUnitHd puhd " & _
                                         "INNER JOIN SalesUnitdt pudt ON puhd.STxnNo = pudt.STxnNo AND puhd.IsDeleted = 0 AND pudt.IsDeleted = 0 AND puhd.IsApproval = 0 " & _
                                         "GROUP BY pudt.IDDO,puhd.DONO " & _
                                       ") pu ON pu.IDDO = dt.ID AND pu.DONO = dt.DONO " & _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.WhID = @WhID and hd.UnitID = @UnitID and hd.EntitiesSeqNo = @EntitiesSeqNo and hd.Currency = @Currency " + _
                                       "And hd.DONO = @DONO " + _
                                       "And ((dt.Qty * dt.ItemFactor) - dt.QtySale - isnull(pu.QtySU,0)) > 0 " + _
                                       "order by datediff(day,hd.DODate, getdate()) desc, hd.DONO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@DONO", _DONO)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
                cmdToExecute.Parameters.Add("@WhID", WhID)
                cmdToExecute.Parameters.Add("@UnitID", UnitID)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function

        Public Function UpdateStatusRelease(ByVal detilRow As DataTable) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim da As SqlDataAdapter
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Update Detil 
            Dim strSQLUpdateDT As New Text.StringBuilder
            With strSQLUpdateDT
                .Append("UPDATE DeliveryOrderDt " & _
                        "SET IsRelease = @IsRelease, " & _
                        "UserRelease = @UserRelease, " & _
                        "ReleaseDate = getdate() " & _
                        "WHERE DONO = @DONO")
            End With

            conn.Open()

            Try
                '
                ' // begin the transaction
                '
                trans = conn.BeginTransaction

                ' // detil 
                With detilRow
                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdUpdateDT As New SqlCommand
                        With cmdUpdateDT
                            .CommandText = strSQLUpdateDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With
                        With cmdUpdateDT.Parameters
                            .Add(New SqlParameter("@DONO", New SqlString(CStr(detilRow.Rows(iRecCount)("DONO")))))
                            .Add(New SqlParameter("@IsRelease", New SqlBoolean(CBool(detilRow.Rows(iRecCount)("chkIsRelease")))))
                            .Add(New SqlParameter("@UserRelease", _UserUpdate))
                        End With
                        ' // update detil
                        cmdUpdateDT.ExecuteNonQuery()
                        iRecCount += 1
                    End While

                End With

                trans.Commit()
                retVal = True
            Catch ex As Exception
                trans.Rollback()
                ' // do not throw an exception, just return ..!!
                '_Ex = ex
                ExceptionManager.Publish(ex)
            Finally
                If Not detilRow Is Nothing Then
                    detilRow.Dispose()
                End If
                detilRow = Nothing

                If Not conn Is Nothing Then
                    If conn.State = ConnectionState.Open Then
                        conn.Close()
                    End If
                End If
                conn.Dispose()
                conn = Nothing
            End Try

            Return retVal
        End Function

        Public Function ValidateSaveGetItemDO(ByVal EntitiesSeqNo As String, ByVal Currency As String, ByVal WhID As String, ByVal UnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "hd.DONO , " + _
                                       "hd.DODate , " + _
                                       "hd.DueDate , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty, " + _
                                       "dt.ItemFactor , " + _
                                       "dt.QtySale , " + _
                                       "isnull(pu.QtySU,0) AS QtySU, " & _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "datediff(day,hd.DODate, getdate()) as Ageinday, " + _
                                       "dt.IsBonus " + _
                                       "FROM DeliveryOrderHD hd " + _
                                       "inner join DeliveryOrderDt dt ON dt.DONO = hd.DONO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "LEFT JOIN " & _
                                       "( " & _
                                         "SELECT pudt.IDDO,pudt.STxnNo,sum(pudt.Qty * pudt.ItemFactor) AS QtySU " & _
                                         "FROM SalesUnitHd puhd " & _
                                         "INNER JOIN SalesUnitdt pudt ON puhd.STxnNo = pudt.STxnNo AND puhd.IsDeleted = 0 AND pudt.IsDeleted = 0 AND puhd.IsApproval = 0 " & _
                                         "GROUP BY pudt.IDDO,pudt.STxnNo " & _
                                       ") pu ON pu.IDDO = dt.ID " & _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.WhID = @WhID and hd.UnitID = @UnitID and hd.EntitiesSeqNo = @EntitiesSeqNo and hd.Currency = @Currency " + _
                                       "And dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("DeliveryOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
                cmdToExecute.Parameters.Add("@WhID", WhID)
                cmdToExecute.Parameters.Add("@UnitID", UnitID)
                cmdToExecute.Parameters.Add("@ID", _ID)

                _mainConnection.Open()

                adapter.Fill(toReturn)

                Return toReturn
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try
        End Function
#End Region

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property
        Public Property [DONO]() As String
            Get
                Return _DONO
            End Get
            Set(ByVal Value As String)
                _DONO = Value
            End Set
        End Property

        Public Property [ItemSeqNo]() As String
            Get
                Return _ItemSeqNo
            End Get
            Set(ByVal Value As String)
                _ItemSeqNo = Value
            End Set
        End Property
        Public Property [ItemID]() As String
            Get
                Return _ItemID
            End Get
            Set(ByVal Value As String)
                _ItemID = Value
            End Set
        End Property

        Public Property [ItemUnitID]() As String
            Get
                Return _ItemUnitID
            End Get
            Set(ByVal Value As String)
                _ItemUnitID = Value
            End Set
        End Property

        Public Property [ItemFactor]() As Decimal
            Get
                Return _ItemFactor
            End Get
            Set(ByVal Value As Decimal)
                _ItemFactor = Value
            End Set
        End Property

        Public Property [Qty]() As Decimal
            Get
                Return _Qty
            End Get
            Set(ByVal Value As Decimal)
                _Qty = Value
            End Set
        End Property

        Public Property [Price]() As Decimal
            Get
                Return _Price
            End Get
            Set(ByVal Value As Decimal)
                _Price = Value
            End Set
        End Property

        Public Property [Disc1Pct]() As Decimal
            Get
                Return _Disc1Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Pct = Value
            End Set
        End Property

        Public Property [Disc1Amt]() As Decimal
            Get
                Return _Disc1Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc1Amt = Value
            End Set
        End Property

        Public Property [Disc2Pct]() As Decimal
            Get
                Return _Disc2Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Pct = Value
            End Set
        End Property
        Public Property [Disc2Amt]() As Decimal
            Get
                Return _Disc2Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc2Amt = Value
            End Set
        End Property
        Public Property [Disc3Pct]() As Decimal
            Get
                Return _Disc3Pct
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Pct = Value
            End Set
        End Property
        Public Property [Disc3Amt]() As Decimal
            Get
                Return _Disc3Amt
            End Get
            Set(ByVal Value As Decimal)
                _Disc3Amt = Value
            End Set
        End Property
        Public Property [QtySale]() As Decimal
            Get
                Return _QtySale
            End Get
            Set(ByVal Value As Decimal)
                _QtySale = Value
            End Set
        End Property
        Public Property [UserInsert]() As String
            Get
                Return _UserInsert
            End Get
            Set(ByVal Value As String)
                _UserInsert = Value
            End Set
        End Property

        Public Property [InsertDate]() As DateTime
            Get
                Return _InsertDate
            End Get
            Set(ByVal Value As DateTime)
                _InsertDate = Value
            End Set
        End Property

        Public Property [UserUpdate]() As String
            Get
                Return _UserUpdate
            End Get
            Set(ByVal Value As String)
                _UserUpdate = Value
            End Set
        End Property

        Public Property [UpdateDate]() As DateTime
            Get
                Return _UpdateDate
            End Get
            Set(ByVal Value As DateTime)
                _UpdateDate = Value
            End Set
        End Property

        Public Property [UserDelete]() As String
            Get
                Return _UserDelete
            End Get
            Set(ByVal Value As String)
                _UserDelete = Value
            End Set
        End Property

        Public Property [DeleteDate]() As DateTime
            Get
                Return _DeleteDate
            End Get
            Set(ByVal Value As DateTime)
                _DeleteDate = Value
            End Set
        End Property

        Public Property [IsBonus]() As Boolean
            Get
                Return _IsBonus
            End Get
            Set(ByVal Value As Boolean)
                _IsBonus = Value
            End Set
        End Property
        Public Property [IsDeleted]() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property
        Public Property [IsRelease]() As Boolean
            Get
                Return _IsRelease
            End Get
            Set(ByVal Value As Boolean)
                _IsRelease = Value
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
#End Region

    End Class
End Namespace
