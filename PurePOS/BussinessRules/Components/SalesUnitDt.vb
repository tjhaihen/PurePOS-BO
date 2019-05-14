Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class SalesUnitDt
        Inherits BRInteractionBase
#Region " Class Member Declarations "
        Private _IDDO, _STxnNo, _ItemSeqNo, _ItemUnitID, _ItemFactor, _Qty, _Price, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt As String
        Private _ID As String
        Private _Disc3Pct, _Disc3Amt, _QtyReturn, _Description As String
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

            cmdToExecute.CommandText = "INSERT INTO SalesUnitDt " & _
                                       "(ID, IDDO, STxnNo, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                                       "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtyReturn, IsBonus, UserInsert, InsertDate, " & _
                                       "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                                       "VALUES (@ID, '', @STxnNo, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                                       "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                                       "@UserUpdate, getdate(), '', '', 0, left(@Description,500)) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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

            cmdToExecute.CommandText = "UPDATE SalesUnitDt " & _
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

            cmdToExecute.CommandText = "SELECT * FROM SalesUnitDt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Select Case recStatus
                Case RavenRecStatus.CurrentRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitDt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitDt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM SalesUnitDt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
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
                    _STxnNo = CType(toReturn.Rows(0)("STxnNo"), String)
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
                    _QtyReturn = CType(toReturn.Rows(0)("QtyReturn"), Decimal)

                    _UserInsert = CType(toReturn.Rows(0)("UserInsert"), String)
                    _InsertDate = CType(toReturn.Rows(0)("InsertDate"), DateTime)
                    _UserUpdate = CType(toReturn.Rows(0)("UserUpdate"), String)
                    _UpdateDate = CType(toReturn.Rows(0)("UpdateDate"), DateTime)
                    _UserDelete = CType(toReturn.Rows(0)("UserDelete"), String)
                    _DeleteDate = CType(toReturn.Rows(0)("DeleteDate"), DateTime)

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

            cmdToExecute.CommandText = "Update SalesUnitDt " & _
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

        Public Function DeleteAllBySTxnNo() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update SalesUnitDt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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
                                       "hd.DONO, " + _
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
                                       "isnull(pohd.CurrencyRate,1) as CurrencyRate , " + _
                                       "dt.IsBonus, " + _
                                       "case when dt.IDDO <> '' then 1 else 0 end as IsDOItem " + _
                                       "FROM SalesUnitHd hd " + _
                                       "inner join SalesUnitDt dt ON dt.STxnNo = hd.STxnNo " + _
                                       "Left join DeliveryOrderHd pohd ON pohd.DONO = hd.DONO and pohd.isDeleted = 0 " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND dt.STxnNo = @STxnNo "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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

        Public Function InsertItemSu(ByVal detilRow As DataTable) As Boolean
            Dim conn As SqlConnection = New SqlConnection(ConnectionString)
            Dim trans As SqlTransaction
            Dim retVal As Boolean

            If detilRow Is Nothing Then
                Return False
            Else
                If detilRow.Rows.Count = 0 Then
                    Return False
                End If
            End If

            ' // Insert Detil 
            Dim strSQLInsertDT As New Text.StringBuilder
            With strSQLInsertDT
                .Append("INSERT INTO SalesUnitDt " & _
                        "(ID,IDDO, STxnNo, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                        "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtyReturn, IsBonus, UserInsert, InsertDate, " & _
                        "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, Description) " & _
                        "VALUES (@ID, @IDDO, @STxnNo, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                        "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                        "@UserUpdate, getdate(), '', '', 0, left(@Description,500)) ")
            End With
            conn.Open()
            Try
                ' // begin the transaction
                trans = conn.BeginTransaction
                ' // detil 
                With detilRow

                    Dim iRecCount As Integer = 0
                    While .Rows.Count > iRecCount
                        Dim cmdInsertDT As New SqlCommand
                        With cmdInsertDT
                            .CommandText = strSQLInsertDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With

                        _ID = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("SalesUnitDt", "ID", conn, trans, "SU")
                        _IDDO = CType(.Rows(iRecCount)("IDDO"), String)
                        _ItemSeqNo = CType(.Rows(iRecCount)("ItemSeqNo"), String)
                        _ItemUnitID = CType(.Rows(iRecCount)("ItemUnitID"), String)
                        _ItemFactor = CType(.Rows(iRecCount)("ItemFactor"), Double)
                        _Qty = CType(.Rows(iRecCount)("QtySale"), Double)
                        _Price = CType(.Rows(iRecCount)("Price"), Double)
                        _Disc1Pct = CType(.Rows(iRecCount)("Disc1Pct"), Double)
                        _Disc1Amt = CType(.Rows(iRecCount)("Disc1Amt"), Double)
                        _Disc2Pct = CType(.Rows(iRecCount)("Disc2Pct"), Double)
                        _Disc2Amt = CType(.Rows(iRecCount)("Disc2Amt"), Double)
                        _Disc3Pct = CType(.Rows(iRecCount)("Disc3Pct"), Double)
                        _Disc3Amt = CType(.Rows(iRecCount)("Disc3Amt"), Double)
                        _IsBonus = CType(.Rows(iRecCount)("IsBonus"), Boolean)

                        With cmdInsertDT.Parameters
                            .Add("@ID", _ID)
                            .Add("@IDDO", _IDDO)
                            .Add("@STxnNo", _STxnNo)
                            .Add("@ItemSeqNo", _ItemSeqNo)
                            .Add("@ItemUnitID", _ItemUnitID)
                            .Add("@ItemFactor", _ItemFactor)
                            .Add("@Qty", _Qty)
                            .Add("@Price", _Price)
                            .Add("@Disc1Pct", _Disc1Pct)
                            .Add("@Disc1Amt", _Disc1Amt)
                            .Add("@Disc2Pct", _Disc2Pct)
                            .Add("@Disc2Amt", _Disc2Amt)
                            .Add("@Disc3Pct", _Disc3Pct)
                            .Add("@Disc3Amt", _Disc3Amt)
                            .Add("@IsBonus", _IsBonus)
                            .Add("@UserInsert", _UserInsert)
                            .Add("@UserUpdate", _UserInsert)
                            .Add("@Description", "")
                        End With

                        ' // insert detil
                        cmdInsertDT.ExecuteNonQuery()
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

                trans.Dispose()
                trans = Nothing

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

        Public Function SelectForViewGridSU(ByVal EntitiesSeqNo As String, ByVal Currency As String, ByVal WhID As String, ByVal UnitID As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " & _
                                        "dt.ItemSeqNo , " & _
                                        "isnull(it.ItemID,'') as ItemID, " & _
                                        "isnull(it.ItemName,'') as ItemName , " & _
                                        "dt.ItemUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "it.ItemSUnitID, " & _
                                        "(SELECT ItemUnitName FROM ItemUnit WHERE ItemUnitID = it.ItemSUnitID) AS ItemSUnitName, " & _
                                        "dt.ItemFactor, " & _
                                        "dt.Qty , " & _
                                        "dt.QtyReturn , " & _
                                        "isnull(purt.QtySURT,0) AS QtySURT, " & _
                                        "dt.Price , " & _
                                        "dt.Disc1Pct , " & _
                                        "dt.Disc1Amt , " & _
                                        "dt.Disc2Pct , " & _
                                        "dt.Disc2Amt , " & _
                                        "dt.Disc3Pct , " & _
                                        "dt.Disc3Amt , " & _
                                        "dt.IsBonus " & _
                                        "FROM SalesUnitHd hd " & _
                                        "inner join SalesUnitDt dt ON dt.STxnNo = hd.STxnNo " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                         "SELECT prd.IDSU, sum(prd.Qty) AS QtySURT " & _
                                         "FROM SalesReturnHd prh " & _
                                         "INNER JOIN SalesReturndt prd ON prd.SReturnNo = prh.SReturnNo AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 AND prh.IsApproval = 0 " & _
                                         "GROUP BY prd.IDSU " & _
                                        ") purt ON purt.IDSU = dt.ID " & _
                                        "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = dt.ItemUnitID " & _
                                        "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND hd.IsApproval = 1 AND dt.STxnNo = @STxnNo " & _
                                        "And hd.EntitiesSeqNo = @EntitiesSeqNo and hd.Currency = @Currency and hd.WhID = @WhID and hd.UnitID = @UnitID " & _
                                        "And (dt.Qty - dt.QtyReturn - isnull(purt.QtySURT,0)) > 0 "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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

        Public Function ValidateGetItemSU() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " & _
                                        "dt.ItemSeqNo , " & _
                                        "isnull(it.ItemID,'') as ItemID, " & _
                                        "isnull(it.ItemName,'') as ItemName , " & _
                                        "dt.ItemUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "dt.ItemFactor, " & _
                                        "dt.Qty , " & _
                                        "dt.QtyReturn , " & _
                                        "isnull(purt.QtySURT,0) AS QtySURT, " & _
                                        "dt.Price , " & _
                                        "dt.Disc1Pct , " & _
                                        "dt.Disc1Amt , " & _
                                        "dt.Disc2Pct , " & _
                                        "dt.Disc2Amt , " & _
                                        "dt.Disc3Pct , " & _
                                        "dt.Disc3Amt , " & _
                                        "dt.IsBonus " & _
                                        "FROM SalesUnitHd hd " & _
                                        "inner join SalesUnitDt dt ON dt.STxnNo = hd.STxnNo And dt.Qty > dt.QtyReturn " & _
                                        "LEFT JOIN " & _
                                        "( " & _
                                         "SELECT prd.IDSU, sum(prd.Qty) AS QtySURT " & _
                                         "FROM SalesReturnHd prh " & _
                                         "INNER JOIN SalesReturndt prd ON prd.SReturnNo = prh.SReturnNo AND prh.IsDeleted = 0 AND prd.IsDeleted = 0 AND prh.IsApproval = 0 " & _
                                         "GROUP BY prd.IDSU " & _
                                        ") purt ON purt.IDSU = dt.ID " & _
                                        "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = dt.ItemUnitID " & _
                                        "WHERE dt.IsDeleted = 0 AND hd.IsDeleted = 0 AND hd.IsApproval = 1 AND dt.STxnNo = @STxnNo " & _
                                        "And dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("SalesUnitDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@STxnNo", _STxnNo)
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

        Public Function GetPriceItemDOorSales(ByVal TypeGetPrice As String, ByVal CurrencyRate As Decimal, ByVal ItemSeqNo As String, ByVal ItemUnitID As String, ByVal ItemFactor As Decimal, ByVal MemberNo As String, ByVal STxnNo As String, ByVal CurrentQty As Decimal) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "sp_GetPriceItemDOorSales"
            cmdToExecute.CommandType = CommandType.StoredProcedure
            Dim toReturn As DataTable = New DataTable("GetPriceItemDOorSales")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TypeGetPrice", TypeGetPrice)
                cmdToExecute.Parameters.Add("@ItemSeqNo", ItemSeqNo)
                cmdToExecute.Parameters.Add("@ItemUnitID", ItemUnitID)
                cmdToExecute.Parameters.Add("@ItemFactor", ItemFactor)
                cmdToExecute.Parameters.Add("@CurrencyRate", CurrencyRate)
                cmdToExecute.Parameters.Add("@MemberNo", MemberNo)
                cmdToExecute.Parameters.Add("@STxnNo", STxnNo)
                cmdToExecute.Parameters.Add("@CurrentQty", CurrentQty)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _Price = CType(toReturn.Rows(0)("UnitPrice"), Decimal)
                    _Disc1Pct = CType(toReturn.Rows(0)("Disc1Pct"), Decimal)
                    _Disc1Amt = CType(toReturn.Rows(0)("Disc1Amt"), Decimal)
                    _Disc2Pct = CType(toReturn.Rows(0)("Disc2Pct"), Decimal)
                    _Disc2Amt = CType(toReturn.Rows(0)("Disc2Amt"), Decimal)
                    _Disc3Pct = CType(toReturn.Rows(0)("Disc3Pct"), Decimal)
                    _Disc3Amt = CType(toReturn.Rows(0)("Disc3Amt"), Decimal)
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

#Region " Class Property Declarations "
        Public Property [ID]() As String
            Get
                Return _ID
            End Get
            Set(ByVal Value As String)
                _ID = Value
            End Set
        End Property
        Public Property [STxnNo]() As String
            Get
                Return _STxnNo
            End Get
            Set(ByVal Value As String)
                _STxnNo = Value
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
        Public Property [QtyReturn]() As Decimal
            Get
                Return _QtyReturn
            End Get
            Set(ByVal Value As Decimal)
                _QtyReturn = Value
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
