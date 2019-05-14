Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class PurchaseOrderDt
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ID, _POrdNO, _PReqNO, _ItemSeqNo, _ItemID, _ItemUnitID, _ItemFactor, _Qty, _Price, _Disc1Pct, _Disc1Amt, _Disc2Pct, _Disc2Amt As String
        Private _Disc3Pct, _Disc3Amt, _QtyReceived, _Description As String
        Private _UserInsert, _UserUpdate, _UserDelete As String
        Private _InsertDate, _UpdateDate, _DeleteDate As String
        Private _IsBonus, _IsDeleted, _IsRelease As Boolean
        Private _Ex As Exception
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "INSERT INTO PurchaseOrderDt " & _
                                       "(ID, POrdNO, PReqNO, ItemSeqNo, ItemUnitID, ItemFactor, Qty, Price, Disc1Pct, " & _
                                       "Disc1Amt, Disc2Pct, Disc2Amt, Disc3Pct, Disc3Amt, QtyReceived, IsBonus, UserInsert, InsertDate, " & _
                                       "UserUpdate, UpdateDate, UserDelete, DeleteDate, IsDeleted, UserRelease, ReleaseDate,IsRelease, Description) " & _
                                       "VALUES (@ID, @POrdNO, @PReqNO, @ItemSeqNo, @ItemUnitID, @ItemFactor, @Qty, @Price, @Disc1Pct, " & _
                                       "@Disc1Amt, @Disc2Pct, @Disc2Amt, @Disc3Pct, @Disc3Amt, 0, @IsBonus, @UserInsert, getdate(), " & _
                                       "@UserUpdate, getdate(), '', '', 0, '', '', 0, left(@Description,500)) "
            cmdToExecute.CommandType = CommandType.Text

            ' // Use base class' connection object
            cmdToExecute.Connection = _mainConnection

            Try

                cmdToExecute.Parameters.Add("@ID", _ID)
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
                cmdToExecute.Parameters.Add("@PReqNO", _PReqNO)
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

            cmdToExecute.CommandText = "UPDATE PurchaseOrderDt " & _
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

            cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt where IsDeleted = 0 order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
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
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt WHERE ID = @ID"
                Case RavenRecStatus.NextRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt WHERE ID > @ID ORDER BY ID ASC"
                Case RavenRecStatus.PreviousRecord
                    cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt WHERE ID < @ID ORDER BY ID DESC"
            End Select
            cmdToExecute.CommandType = CommandType.Text
            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
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
                    _POrdNO = CType(toReturn.Rows(0)("POrdNO"), String)
                    _PReqNO = CType(toReturn.Rows(0)("PReqNO"), String)
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
                    _QtyReceived = CType(toReturn.Rows(0)("QtyReceived"), Decimal)

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

            cmdToExecute.CommandText = "Update PurchaseOrderDt " & _
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

        Public Function DeleteAllByPOrdNO() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "Update PurchaseOrderDt " & _
                                       "set IsDeleted = 1, " & _
                                       "UserDelete = @UserDelete, " & _
                                       "DeleteDate = getdate() " & _
                                       "WHERE IsDeleted = 0 and POrdNO = @POrdNO"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
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
        Public Function SelectAllByPReqNO() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt where IsDeleted = 0 and RTRIM(PReqNO) <> '' and PReqNO = @PReqNO order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@PReqNO", _PReqNO)

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

        Public Function SelectAllByPOrdNO() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM PurchaseOrderDt where IsDeleted = 0 and POrdNO = @POrdNO order by ID desc"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)

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
                                       "FROM PurchaseOrderHD hd " + _
                                       "inner join PurchaseOrderDt dt ON dt.POrdNO = hd.POrdNO " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "WHERE dt.IsDeleted = 0 AND dt.POrdNO = @POrdNO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)
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

        Public Function SelectForViewGridPOManagement(ByVal ExpiredDate As DateTime, ByVal EntitiesSeqNo As String, ByVal Currency As String, ByVal IsApprovedOnly As Boolean) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            Dim strApproveFilter As String
            If IsApprovedOnly = True Then
                strApproveFilter = " AND hd.IsApproval = 1 "
            Else
                strApproveFilter = " AND hd.IsApproval = 0 "
            End If

            cmdToExecute.CommandText = "SELECT " + _
                                       "hd.POrdNO , " + _
                                       "hd.POrdDate , " + _
                                       "hd.POrdExpiredDate , " + _
                                       "hd.EntitiesSeqNo , " + _
                                       "isnull(En.EntitiesName,'') as EntitiesName , " + _
                                       "datediff(day,hd.POrdDate, @ExpiredDate) as Ageinday, " + _
                                       "datediff(day,hd.POrdExpiredDate, @ExpiredDate) as OverDueInDay " + _
                                       "FROM PurchaseOrderHD hd " + _
                                       "inner join PurchaseOrderDt dt ON dt.POrdNO = hd.POrdNO and dt.IsRelease = 0 " + strApproveFilter + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "LEFT JOIN Entities En ON En.EntitiesSeqNo = hd.EntitiesSeqNo  " + _
                                       "WHERE dt.IsDeleted = 0 " + _
                                       "and convert(varchar(8),hd.POrdExpiredDate,112) <= convert(varchar(8),@ExpiredDate,112) " + _
                                       "and hd.Currency = @Currency " + _
                                       IIf(EntitiesSeqNo.Trim = "", "", "and hd.EntitiesSeqNo = @EntitiesSeqNo ") + _
                                       "Group By hd.POrdNO,hd.POrdDate,hd.POrdExpiredDate,hd.EntitiesSeqNo,En.EntitiesName, hd.IsApproval " & _
                                       "order by hd.IsApproval, datediff(day,hd.POrdDate, @ExpiredDate) desc, En.EntitiesName, hd.POrdNO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@ExpiredDate", ExpiredDate)
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)

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

        Public Function SelectForViewGridPOManagementDetail() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY it.ItemID) as AutoNo, dt.ID, " + _
                                       "hd.POrdNO , " + _
                                       "hd.POrdDate , " + _
                                       "hd.POrdExpiredDate , " + _
                                       "hd.EntitiesSeqNo , " + _
                                       "isnull(En.EntitiesName,'') as EntitiesName , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty , " + _
                                       "dt.QtyReceived , " + _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "dt.IsBonus " + _
                                       "FROM PurchaseOrderHD hd " + _
                                       "inner join PurchaseOrderDt dt ON dt.POrdNO = hd.POrdNO and dt.IsRelease = 0 " + _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "LEFT JOIN Entities En ON En.EntitiesSeqNo = hd.EntitiesSeqNo  " + _
                                       "WHERE hd.IsDeleted = 0 and dt.IsDeleted = 0 " + _
                                       "and hd.POrdNO = @POrdNO " + _
                                       "order by it.ItemID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@POrdNO", _POrdNO)

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

        Public Function SelectForViewGridPOForPU(ByVal EntitiesSeqNo As String, ByVal Currency As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "hd.POrdNO , " + _
                                       "hd.POrdDate , " + _
                                       "hd.POrdExpiredDate , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty, " + _
                                       "dt.ItemFactor , " + _
                                       "dt.QtyReceived , " + _
                                       "isnull(pu.QtyPU,0) AS QtyPU, " & _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "datediff(day,hd.POrdDate, getdate()) as Ageinday, " + _
                                       "dt.IsBonus " + _
                                       "FROM PurchaseOrderHD hd " + _
                                       "inner join PurchaseOrderDt dt ON dt.POrdNO = hd.POrdNO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "LEFT JOIN " & _
                                       "( " & _
                                         "SELECT pudt.IDPO,pudt.POrdNO,sum(pudt.Qty * pudt.ItemFactor) AS QtyPU " & _
                                         "FROM PurchaseUnitHd puhd " & _
                                         "INNER JOIN PurchaseUnitDt pudt ON puhd.PUnitNO = pudt.PUnitNO AND puhd.IsDeleted = 0 AND pudt.IsDeleted = 0 AND puhd.IsApproval = 0 " & _
                                         "GROUP BY pudt.IDPO,pudt.POrdNO " & _
                                       ") pu ON pu.IDPO = dt.ID AND pu.POrdNO = dt.POrdNO " & _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.EntitiesSeqNo = @EntitiesSeqNo and hd.Currency = @Currency " + _
                                       "And ((dt.Qty * dt.ItemFactor) - dt.QtyReceived - isnull(pu.QtyPU,0)) > 0 " + _
                                       "order by datediff(day,hd.POrdDate, getdate()) desc, hd.POrdNO "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)

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

        Public Function UpdateStatusRelease(ByVal detilRow As DataTable, ByVal User As String) As Boolean
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
                .Append("UPDATE PurchaseOrderDt " & _
                        "SET IsRelease = @IsRelease, " & _
                        "UserRelease = @UserRelease, " & _
                        "ReleaseDate = getdate() " & _
                        "WHERE POrdNO = @POrdNO")
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
                            .Add(New SqlParameter("@POrdNO", New SqlString(CStr(detilRow.Rows(iRecCount)("POrdNO")))))
                            .Add(New SqlParameter("@IsRelease", New SqlBoolean(CBool(detilRow.Rows(iRecCount)("chkIsSelected")))))
                            .Add(New SqlParameter("@UserRelease", User.Trim))
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
                _Ex = ex
                'ExceptionManager.Publish(ex)
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

        Public Function ValidateSaveGetItemPO(ByVal EntitiesSeqNo As String, ByVal Currency As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT dt.ID, " + _
                                       "hd.POrdNO , " + _
                                       "hd.POrdDate , " + _
                                       "hd.POrdExpiredDate , " + _
                                       "dt.ItemSeqNo , " + _
                                       "isnull(it.ItemID,'') as ItemID , " + _
                                       "isnull(it.ItemName,'') as ItemName , " + _
                                       "dt.ItemUnitID , " + _
                                       "dt.ItemFactor , " + _
                                       "isnull(itut.ItemUnitName,'') as ItemUnitName , " + _
                                       "dt.Qty, " + _
                                       "dt.ItemFactor , " + _
                                       "dt.QtyReceived , " + _
                                       "isnull(pu.QtyPU,0) AS QtyPU, " & _
                                       "dt.Price , " + _
                                       "dt.Disc1Pct , " + _
                                       "dt.Disc1Amt , " + _
                                       "dt.Disc2Pct , " + _
                                       "dt.Disc2Amt , " + _
                                       "dt.Disc3Pct , " + _
                                       "dt.Disc3Amt , " + _
                                       "datediff(day,hd.POrdDate, getdate()) as Ageinday, " + _
                                       "dt.IsBonus " + _
                                       "FROM PurchaseOrderHD hd " + _
                                       "inner join PurchaseOrderDt dt ON dt.POrdNO = hd.POrdNO and hd.IsApproval = 1 and dt.IsRelease = 0 " + _
                                       "LEFT JOIN " & _
                                       "( " & _
                                         "SELECT pudt.IDPO,pudt.POrdNO,sum(pudt.Qty * pudt.ItemFactor) AS QtyPU " & _
                                         "FROM PurchaseUnitHd puhd " & _
                                         "INNER JOIN PurchaseUnitDt pudt ON puhd.PUnitNO = pudt.PUnitNO AND puhd.IsDeleted = 0 AND pudt.IsDeleted = 0 AND puhd.IsApproval = 0 " & _
                                         "GROUP BY pudt.IDPO,pudt.POrdNO " & _
                                       ") pu ON pu.IDPO = dt.ID AND pu.POrdNO = dt.POrdNO " & _
                                       "left join item it ON it.ItemSeqNo = dt.ItemSeqNo " + _
                                       "left join itemunit itut ON itut.itemunitID = dt.ItemUnitID " + _
                                       "WHERE dt.IsDeleted = 0 AND hd.EntitiesSeqNo = @EntitiesSeqNo and hd.Currency = @Currency " + _
                                       "And dt.ID = @ID "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("PurchaseOrderDt")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@EntitiesSeqNo", EntitiesSeqNo)
                cmdToExecute.Parameters.Add("@Currency", Currency)
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

        Public Function ProcessPRtoPO(ByVal detilRow As DataTable, ByVal WhID As String, ByVal UnitID As String, ByVal PICName As String, _
                                      ByVal POrdTypeID As String, ByVal PaymentTypeID As String, ByVal TermOfPayment As String, _
                                      ByVal POrdDate As DateTime, ByVal POrdExpiredDate As DateTime, ByVal DeliveryDate As DateTime, _
                                      ByVal TermOfAgreement As String, ByVal DeliverTo As String, ByVal Currency As String, ByVal CurrencyRate As String, ByVal User As String) As String
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
                .Append("UPDATE PurchaseRequestDt " & _
                        "SET IsProcess = @IsProcess, " & _
                        "UserProcess = @UserProcess, " & _
                        "ProcessDate = getdate() " & _
                        "WHERE ID = @ID")
            End With

            ' // Insert Header 
            Dim strSQLinsertHdPO As New Text.StringBuilder
            With strSQLinsertHdPO
                .Append("UPDATE PurchaseOrderDt " & _
                        "SET QtySaldo = ISNULL((SELECT SUM(ib.QtySUnit) FROM itembalance ib WHERE ib.ItemSeqNo = udt.ItemSeqNo),0), " & _
                        "LastPordDate = ISNULL((SELECT TOP 1 hd.POrdDate " & _
                        "FROM PurchaseOrderHD hd " & _
                        "INNER JOIN PurchaseOrderDt dt ON hd.POrdNO = dt.POrdNO " & _
                        "WHERE(dt.ItemSeqNo = udt.ItemSeqNo And hd.IsApproval = 1 And hd.IsDeleted = 0 And dt.IsDeleted = 0) " & _
                        "ORDER BY ID DESC),'') " & _
                        "FROM PurchaseOrderDt udt " & _
                        "WHERE udt.POrdNO = @POrdNO AND udt.IsDeleted = 0 " & _
                        "INSERT INTO PurchaseOrderHd " & _
                        "(POrdNO, EntitiesSeqNo, PICName, POrdDate, POrdExpiredDate, DeliveryDate, POrdTypeID, " & _
                        "PaymentTypeID, TermOfPayment, TermOfAgreement, IsPPN, PPNPct, DiscFinalPct, DiscFinalAmt, " & _
                        "DPAmt, Currency, CurrencyRate, UserInsert, InsertDate, UserUpdate, " & _
                        "UpdateDate, UserDelete, DeleteDate, IsDeleted, Description, DeliverTo, " & _
                        "IsApproval, UserApproval, ApprovalDate, RevNo, UserRev, RevDate, " & _
                        "VoucherNo) " & _
                        "VALUES " & _
                        "(@POrdNO,@EntitiesSeqNo,@PICName,@POrdDate,@POrdExpiredDate,@DeliveryDate,@POrdTypeID, " & _
                        "@PaymentTypeID,@TermOfPayment,@TermOfAgreement,0,0,0,0, " & _
                        "0,@Currency,@CurrencyRate,@UserProcess,getdate(),@UserProcess, " & _
                        "getdate(),'','',0,'',@DeliverTo, " & _
                        "1,@UserProcess,getdate(),0,'','', " & _
                        "'') ")
            End With

            ' // Insert Detil 
            Dim strSQLinsertDtPO As New Text.StringBuilder
            With strSQLinsertDtPO
                .Append("INSERT INTO PurchaseOrderDt " & _
                        "(ID,POrdNO,PReqNO,ItemSeqNo,ItemUnitID,ItemFactor,Qty,Price,Disc1Pct,Disc1Amt,Disc2Pct,Disc2Amt, " & _
                        "Disc3Pct,Disc3Amt,QtyReceived,IsBonus,UserInsert,InsertDate,UserUpdate,UpdateDate,UserDelete, " & _
                        "DeleteDate, IsDeleted, UserRelease, ReleaseDate, IsRelease, Description) " & _
                        "VALUES " & _
                        "(@ID,@POrdNO,@PReqNo,@ItemSeqNo,@ItemUnitID,@ItemFactor,@Qty,@Price,@Discount1Pct,@Discount1Amt,@Discount2Pct,@Discount2Amt, " & _
                        "@Discount3Pct,@Discount3Amt,0,0,@UserProcess,getdate(),@UserProcess,getdate(),'', " & _
                        "'',0,'','',0,'') ")
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

                    _POrdNO = BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PurchaseOrderHd", "POrdNO", conn, trans, "PO")
                    Dim cmdInserthdPO As New SqlCommand
                    With cmdInserthdPO
                        .CommandText = strSQLinsertHdPO.ToString
                        .CommandType = CommandType.Text
                        .Connection = conn
                        .Transaction = trans
                    End With
                    With cmdInserthdPO.Parameters
                        .Add(New SqlParameter("@POrdNO", _POrdNO))
                        .Add(New SqlParameter("@EntitiesSeqNo", New SqlString(CStr(detilRow.Rows(iRecCount)("EntitiesSeqNo")))))
                        .Add(New SqlParameter("@PICName", PICName.Trim))
                        .Add(New SqlParameter("@POrdDate", POrdDate))
                        .Add(New SqlParameter("@POrdExpiredDate", POrdExpiredDate))
                        .Add(New SqlParameter("@DeliveryDate", DeliveryDate))
                        .Add(New SqlParameter("@POrdTypeID", POrdTypeID.Trim))
                        .Add(New SqlParameter("@PaymentTypeID", PaymentTypeID.Trim))
                        .Add(New SqlParameter("@TermOfPayment", TermOfPayment.Trim))
                        .Add(New SqlParameter("@TermOfAgreement", TermOfAgreement.Trim))
                        .Add(New SqlParameter("@DeliverTo", DeliverTo.Trim))
                        .Add(New SqlParameter("@Currency", Currency.Trim))
                        .Add(New SqlParameter("@CurrencyRate", CurrencyRate.Trim))
                        .Add(New SqlParameter("@UserProcess", User.Trim))
                    End With

                    While .Rows.Count > iRecCount
                        Dim cmdUpdateDT As New SqlCommand
                        With cmdUpdateDT
                            .CommandText = strSQLUpdateDT.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With
                        With cmdUpdateDT.Parameters
                            .Add(New SqlParameter("@ID", New SqlString(CStr(detilRow.Rows(iRecCount)("ID")))))
                            .Add(New SqlParameter("@IsProcess", New SqlBoolean(CBool(detilRow.Rows(iRecCount)("IsProcess")))))
                            .Add(New SqlParameter("@UserProcess", User.Trim))
                        End With
                        cmdUpdateDT.ExecuteNonQuery()

                        Dim cmdInsertdtPO As New SqlCommand
                        With cmdInsertdtPO
                            .CommandText = strSQLinsertDtPO.ToString
                            .CommandType = CommandType.Text
                            .Connection = conn
                            .Transaction = trans
                        End With
                        With cmdInsertdtPO.Parameters
                            .Add(New SqlParameter("@ID", BussinessRules.ID.GenerateIDNumberWithBeginTransaction("PurchaseOrderdt", "ID", conn, trans)))
                            .Add(New SqlParameter("@POrdNO", _POrdNO))
                            .Add(New SqlParameter("@PReqNo", New SqlString(CStr(detilRow.Rows(iRecCount)("PReqNo")))))
                            .Add(New SqlParameter("@ItemSeqNo", New SqlString(CStr(detilRow.Rows(iRecCount)("ItemSeqNo")))))
                            .Add(New SqlParameter("@Qty", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Qty")))))
                            .Add(New SqlParameter("@ItemUnitID", New SqlString(CStr(detilRow.Rows(iRecCount)("ItemUnitID")))))
                            .Add(New SqlParameter("@ItemFactor", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("ItemFactor")))))
                            .Add(New SqlParameter("@Price", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Price")))))
                            .Add(New SqlParameter("@Discount1Pct", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount1Pct")))))
                            .Add(New SqlParameter("@Discount1Amt", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount1Amt")))))
                            .Add(New SqlParameter("@Discount2Pct", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount2Pct")))))
                            .Add(New SqlParameter("@Discount2Amt", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount2Amt")))))
                            .Add(New SqlParameter("@Discount3Pct", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount3Pct")))))
                            .Add(New SqlParameter("@Discount3Amt", New SqlDecimal(CDec(detilRow.Rows(iRecCount)("Discount3Amt")))))
                            .Add(New SqlParameter("@UserProcess", User.Trim))
                        End With

                        ' // insert detail PO
                        cmdInsertdtPO.ExecuteNonQuery()

                        iRecCount += 1
                    End While

                    cmdInserthdPO.ExecuteNonQuery()
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

            Return IIf(retVal, _POrdNO, "")
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
        Public Property [POrdNO]() As String
            Get
                Return _POrdNO
            End Get
            Set(ByVal Value As String)
                _POrdNO = Value
            End Set
        End Property
        Public Property [PReqNO]() As String
            Get
                Return _PReqNO
            End Get
            Set(ByVal Value As String)
                _PReqNO = Value
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
        Public Property [QtyReceived]() As Decimal
            Get
                Return _QtyReceived
            End Get
            Set(ByVal Value As Decimal)
                _QtyReceived = Value
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
