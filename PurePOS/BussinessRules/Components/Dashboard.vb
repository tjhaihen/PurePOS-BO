Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules
    Public Class Dashboard
        Inherits BRInteractionBase

#Region " Class Member Declarations "

#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Function SelectCountIncompleteTransaction() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand

            cmdToExecute.CommandText = "SELECT * FROM ( " & _
                                        "SELECT '01' AS Number, '01-Purchasing' AS TransactionGroup, " & _
                                        "'Purchase Request' AS TransactionName, " & _
                                        "COUNT(hd.PReqNo) AS TransactionCount " & _
                                        "FROM PurchaseRequestHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '01' AS Number, '01-Purchasing' AS TransactionGroup, " & _
                                        "'Purchase Order' AS TransactionName, " & _
                                        "COUNT(hd.POrdNo) AS TransactionCount " & _
                                        "FROM PurchaseOrderHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '01' AS Number, '01-Purchasing' AS TransactionGroup, " & _
                                        "'Purchase Unit' AS TransactionName, " & _
                                        "COUNT(hd.PUnitNo) AS TransactionCount " & _
                                        "FROM PurchaseUnitHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '01' AS Number, '01-Purchasing' AS TransactionGroup, " & _
                                        "'Purchase Return' AS TransactionName, " & _
                                        "COUNT(hd.PReturnNo) AS TransactionCount " & _
                                        "FROM PurchaseReturnHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '02' AS Number, '02-Inventory' AS TransactionGroup, " & _
                                        "'Mutation' AS TransactionName, " & _
                                        "COUNT(hd.TxnNo) AS TransactionCount " & _
                                        "FROM MutationHD hd " & _
                                        "WHERE hd.InventoryTxnID IN (SELECT InventoryTxnID FROM InventoryTxn WHERE IsMutation = 1) " & _
                                        "AND hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '02' AS Number, '02-Inventory' AS TransactionGroup, " & _
                                        "'Production' AS TransactionName, " & _
                                        "COUNT(hd.ProductionNo) AS TransactionCount " & _
                                        "FROM ProductionHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '02' AS Number, '02-Inventory' AS TransactionGroup, " & _
                                        "'Stock Opname' AS TransactionName, " & _
                                        "COUNT(hd.TxnNo) AS TransactionCount " & _
                                        "FROM MutationHD hd " & _
                                        "WHERE hd.InventoryTxnID = '109' " & _
                                        "AND hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '03' AS Number, '03-Transaction' AS TransactionGroup, " & _
                                        "'Delivery Order' AS TransactionName, " & _
                                        "COUNT(hd.DONo) AS TransactionCount " & _
                                        "FROM DeliveryOrderHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '03' AS Number, '03-Transaction' AS TransactionGroup, " & _
                                        "'Sales Unit' AS TransactionName, " & _
                                        "COUNT(hd.STxnNo) AS TransactionCount " & _
                                        "FROM SalesUnitHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '03' AS Number, '03-Transaction' AS TransactionGroup, " & _
                                        "'Sales Return' AS TransactionName, " & _
                                        "COUNT(hd.SReturnNo) AS TransactionCount " & _
                                        "FROM SalesReturnHD hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '04' AS Number, '04-Finance' AS TransactionGroup, " & _
                                        "'A/P Invoice' AS TransactionName, " & _
                                        "COUNT(hd.VoucherNo) AS TransactionCount " & _
                                        "FROM APInvoice hd " & _
                                        "WHERE hd.IsDeleted = 0 " & _
                                        "AND hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '04' AS Number, '04-Finance' AS TransactionGroup, " & _
                                        "'A/P Payment' AS TransactionName, " & _
                                        "COUNT(hd.APPaymentNo) AS TransactionCount " & _
                                        "FROM APPaymentHD hd " & _
                                        "WHERE hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '04' AS Number, '04-Finance' AS TransactionGroup, " & _
                                        "'A/R Invoicing' AS TransactionName, " & _
                                        "COUNT(hd.SalesInvoiceNo) AS TransactionCount " & _
                                        "FROM SalesInvoiceHD hd " & _
                                        "WHERE hd.IsApproval = 0 " & _
                                        "UNION ALL " & _
                                        "SELECT '04' AS Number, '04-Finance' AS TransactionGroup, " & _
                                        "'A/R Receiving' AS TransactionName, " & _
                                        "COUNT(hd.ARReceivingNo) AS TransactionCount " & _
                                        "FROM ARReceivingHD hd " & _
                                        "WHERE hd.IsApproval = 0 " & _
                                        ") x ORDER BY x.Number"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("IncompleteTransaction")
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

#Region " Class Property Declarations "

#End Region

    End Class
End Namespace
