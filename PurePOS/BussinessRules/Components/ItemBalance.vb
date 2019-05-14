Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class ItemBalance
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _ItemSeqNo, _ItemLUnitID, _ItemSUnitID, _ItemFactor, _WhID, _UnitID, _QtySUnit, _ItemHistoryID As String
        Private _UserUpdate As String
        Private _UpdateDate As String
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region "Others Function"
        Public Function SelectAllForBalanceInformation(ByVal SourceWhID As String, ByVal DestinationWhID As String, _
                                                      ByVal SourceUnitID As String, ByVal DestinationUnitID As String, _
                                                      ByVal SourceItemSeqNo As String, ByVal DestinationItemSeqNo As String _
                                                       ) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT w.WhID,w.WhName,w.UnitID,w.UnitName, " & _
                                        "ib.ItemSeqNo, i.ItemID, i.ItemName, ib.QtySUnit, i.ItemSUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "ISNULL((SELECT ROPMinSUnit FROM ItemROP WHERE ItemSeqNo=ib.ItemSeqNo AND WHID=ib.WHID AND UnitID=ib.UnitID),0) AS ROPMinSUnit, " & _
                                        "ISNULL((SELECT ROPMaxSUnit FROM ItemROP WHERE ItemSeqNo=ib.ItemSeqNo AND WHID=ib.WHID AND UnitID=ib.UnitID),0) AS ROPMaxSUnit " & _
                                        "FROM ItemBalance ib " & _
                                        "INNER JOIN Warehouse w ON w.WhID = ib.WhID AND w.UnitID = ib.UnitID " & _
                                        "INNER JOIN Item i ON i.ItemSeqNo = ib.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = i.ItemSUnitID " & _
                                        "WHERE ((ib.WhID BETWEEN @SourceWhID AND @DestinationWhID) or (ib.WhID BETWEEN @DestinationWhID AND @SourceWhID)) " & _
                                        "AND ((ib.UnitID BETWEEN @SourceUnitID AND @DestinationUnitID) or (ib.UnitID BETWEEN @DestinationUnitID AND @SourceUnitID)) " & _
                                        "AND ((ib.ItemSeqNo BETWEEN @SourceItemSeqNo AND @DestinationItemSeqNo) or (ib.ItemSeqNo BETWEEN @DestinationItemSeqNo AND @SourceItemSeqNo)) " & _
                                        "order by w.WhID, w.UnitID, i.ItemName"

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SourceWhID", IIf(SourceWhID.Trim = "", "000", SourceWhID.Trim))
                cmdToExecute.Parameters.Add("@DestinationWhID", IIf(DestinationWhID.Trim = "", "ZZZ", DestinationWhID.Trim))
                cmdToExecute.Parameters.Add("@SourceUnitID", IIf(SourceUnitID.Trim = "", "000", SourceUnitID.Trim))
                cmdToExecute.Parameters.Add("@DestinationUnitID", IIf(DestinationUnitID.Trim = "", "ZZZ", DestinationUnitID.Trim))
                cmdToExecute.Parameters.Add("@SourceItemSeqNo", IIf(SourceItemSeqNo.Trim = "", "000", SourceItemSeqNo.Trim))
                cmdToExecute.Parameters.Add("@DestinationItemSeqNo", IIf(DestinationItemSeqNo.Trim = "", "ZZZ", DestinationItemSeqNo.Trim))
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
        Public Function SelectAllForBalanceInformationCalculateROP(ByVal SourceWhID As String, ByVal DestinationWhID As String, _
                                                      ByVal SourceUnitID As String, ByVal DestinationUnitID As String, _
                                                      ByVal SourceItemSeqNo As String, ByVal DestinationItemSeqNo As String _
                                                       ) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT rop.* FROM ( " & _
                                       "SELECT w.WhID,w.WhName,w.UnitID,w.UnitName, " & _
                                        "ib.ItemSeqNo, i.ItemID, i.ItemName, ib.QtySUnit, i.ItemSUnitID, " & _
                                        "isnull(iu.ItemUnitName,'') AS ItemUnitName, " & _
                                        "ISNULL((SELECT ROPMinSUnit FROM ItemROP WHERE ItemSeqNo=ib.ItemSeqNo AND WHID=ib.WHID AND UnitID=ib.UnitID),0) AS ROPMinSUnit, " & _
                                        "ISNULL((SELECT ROPMaxSUnit FROM ItemROP WHERE ItemSeqNo=ib.ItemSeqNo AND WHID=ib.WHID AND UnitID=ib.UnitID),0) AS ROPMaxSUnit " & _
                                        "FROM ItemBalance ib " & _
                                        "INNER JOIN Warehouse w ON w.WhID = ib.WhID AND w.UnitID = ib.UnitID " & _
                                        "INNER JOIN Item i ON i.ItemSeqNo = ib.ItemSeqNo " & _
                                        "LEFT JOIN ItemUnit iu ON iu.ItemUnitID = i.ItemSUnitID " & _
                                        "WHERE ((ib.WhID BETWEEN @SourceWhID AND @DestinationWhID) or (ib.WhID BETWEEN @DestinationWhID AND @SourceWhID)) " & _
                                        "AND ((ib.UnitID BETWEEN @SourceUnitID AND @DestinationUnitID) or (ib.UnitID BETWEEN @DestinationUnitID AND @SourceUnitID)) " & _
                                        "AND ((ib.ItemSeqNo BETWEEN @SourceItemSeqNo AND @DestinationItemSeqNo) or (ib.ItemSeqNo BETWEEN @DestinationItemSeqNo AND @SourceItemSeqNo)) " & _
                                        ") rop " & _
                                        "WHERE rop.QtySUnit <= rop.ROPMinSUnit " & _
                                        "order by rop.WhID, rop.UnitID, rop.ItemName"

            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@SourceWhID", IIf(SourceWhID.Trim = "", "000", SourceWhID.Trim))
                cmdToExecute.Parameters.Add("@DestinationWhID", IIf(DestinationWhID.Trim = "", "ZZZ", DestinationWhID.Trim))
                cmdToExecute.Parameters.Add("@SourceUnitID", IIf(SourceUnitID.Trim = "", "000", SourceUnitID.Trim))
                cmdToExecute.Parameters.Add("@DestinationUnitID", IIf(DestinationUnitID.Trim = "", "ZZZ", DestinationUnitID.Trim))
                cmdToExecute.Parameters.Add("@SourceItemSeqNo", IIf(SourceItemSeqNo.Trim = "", "000", SourceItemSeqNo.Trim))
                cmdToExecute.Parameters.Add("@DestinationItemSeqNo", IIf(DestinationItemSeqNo.Trim = "", "ZZZ", DestinationItemSeqNo.Trim))
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
        Public Function SelectAllByWhIDUnitIDForItemSeqNo(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " ib.*, " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName " + _
                                       "FROM ItemBalance ib " + _
                                       "left join item it ON it.ItemSeqNo = ib.ItemSeqNo " + _
                                       "WHERE ib.WhID = @WhID and ib.UnitID = @UnitID " + _
                                       "and (it.ItemID LIKE '%" + Filter.Trim + "%' OR it.ItemName LIKE '%" + Filter.Trim + "%' OR ib.ItemSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        Public Function SelectAllByWhIDUnitIDForItemSeqNoMutation(ByVal TxnNo As String, ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " ib.ItemSeqNo,ib.WhID,ib.UnitID,(ib.QtySUnit - isnull(MT.QtyMT,0)) as QtySUnit,ib.ItemHistoryID,ib.UserUpdate,ib.UpdateDate, " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName " + _
                                       "FROM ItemBalance ib " + _
                                       "left join " & _
                                       "( " & _
                                            "SELECT hd.SourceWHID,hd.SourceUnitID,dt.ItemSeqNo,sum(dt.Qty) AS QtyMT " & _
                                            "FROM Mutationhd hd " & _
                                            "INNER JOIN MutationDt dt ON dt.TxnNo = hd.TxnNo AND hd.IsDeleted = 0 AND dt.IsDeleted = 0 AND hd.IsApproval = 0 " & _
                                            "WHERE hd.TxnNo = @TxnNo " & _
                                            "GROUP BY hd.SourceWHID,hd.SourceUnitID,dt.ItemSeqNo " & _
                                       ") MT ON MT.SourceWHID = ib.WhID AND MT.SourceUnitID = ib.UnitID AND MT.ItemSeqNo = ib.ItemSeqNo " & _
                                       "left join item it ON it.ItemSeqNo = ib.ItemSeqNo " + _
                                       "WHERE ib.WhID = @WhID and ib.UnitID = @UnitID " + _
                                       "and (it.ItemID LIKE '%" + Filter.Trim + "%' OR it.ItemName LIKE '%" + Filter.Trim + "%' OR ib.ItemSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@TxnNo", TxnNo)
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        Public Function SelectAllByWhIDUnitIDForItemSeqNoBeginBalance(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + "  " & _
                                       "it.ItemSeqNo, it.ItemID, it.ItemName, isnull(itb.QtySUnit,0) as QtySUnit " & _
                                       "FROM item it " & _
                                       "Left Join ItemBalance itb On it.ItemSeqNo = itb.ItemSeqNo And WhID = @WhID And UnitID = @UnitID " & _
                                       "WHERE it.IsActive = 1 " & _
                                       "AND itb.ItemSeqNo Is Null " & _
                                       "and (it.ItemID LIKE '%" + Filter.Trim + "%' OR it.ItemName LIKE '%" + Filter.Trim + "%' OR it.ItemSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        Public Function SelectAllByWhIDUnitIDForItemSeqNoDOAndSU(ByVal Filter As String, ByVal MaxRecord As String) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT Top " + MaxRecord + " ib.ItemSeqNo, " + _
                                       "isnull(it.ItemID,'') as ItemID, " + _
                                       "isnull(it.ItemName,'') as ItemName " + _
                                       "FROM ItemBalance ib " + _
                                       "left join item it ON it.ItemSeqNo = ib.ItemSeqNo " + _
                                       "WHERE ib.WhID = @WhID and ib.UnitID = @UnitID and ib.QtySUnit > 0 " + _
                                       "and (it.ItemID LIKE '%" + Filter.Trim + "%' OR it.ItemName LIKE '%" + Filter.Trim + "%' OR ib.ItemSeqNo LIKE '%" + Filter.Trim + "%') "
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("ItemBalance")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.Add("@WhID", _WhID)
                cmdToExecute.Parameters.Add("@UnitID", _UnitID)
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
        Public Property [WhID]() As String
            Get
                Return _WhID
            End Get
            Set(ByVal Value As String)
                _WhID = Value
            End Set
        End Property

        Public Property [UnitID]() As String
            Get
                Return _UnitID
            End Get
            Set(ByVal Value As String)
                _UnitID = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
