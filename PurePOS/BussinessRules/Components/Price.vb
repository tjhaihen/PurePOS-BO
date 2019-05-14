Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.BussinessRules

    Public NotInheritable Class Price

        Private _price As Decimal = 0
        Private _priceTmp As Decimal = 0
        Private _discount1pct As Decimal = 0
        Private _discount1amt As Decimal = 0
        Private _discount2pct As Decimal = 0
        Private _discount2amt As Decimal = 0
        Private _discount3pct As Decimal = 0
        Private _discount3amt As Decimal = 0
        Private _markup As Decimal = 0

        Public Sub New()

        End Sub

        Public Property price() As Decimal
            Get
                Return _price
            End Get
            Set(ByVal Value As Decimal)
                _price = Value
            End Set
        End Property

        Public Property priceTmp() As Decimal
            Get
                Return _priceTmp
            End Get
            Set(ByVal Value As Decimal)
                _priceTmp = Value
            End Set
        End Property

        Public Property discount1pct() As Decimal
            Get
                Return _discount1pct
            End Get
            Set(ByVal Value As Decimal)
                _discount1pct = Value
            End Set
        End Property

        Public Property discount1amt() As Decimal
            Get
                Return _discount1amt
            End Get
            Set(ByVal Value As Decimal)
                _discount1amt = Value
            End Set
        End Property

        Public Property discount2pct() As Decimal
            Get
                Return _discount2pct
            End Get
            Set(ByVal Value As Decimal)
                _discount2pct = Value
            End Set
        End Property

        Public Property discount2amt() As Decimal
            Get
                Return _discount2amt
            End Get
            Set(ByVal Value As Decimal)
                _discount2amt = Value
            End Set
        End Property

        Public Property discount3pct() As Decimal
            Get
                Return _discount3pct
            End Get
            Set(ByVal Value As Decimal)
                _discount3pct = Value
            End Set
        End Property

        Public Property discount3amt() As Decimal
            Get
                Return _discount3amt
            End Get
            Set(ByVal Value As Decimal)
                _discount3amt = Value
            End Set
        End Property

        Public Property markup() As Decimal
            Get
                Return _markup
            End Get
            Set(ByVal Value As Decimal)
                _markup = Value
            End Set
        End Property

    End Class

    Public NotInheritable Class Functions
        Inherits BRInteractionBase

        Private Sub New()
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

        Public Shared Function GetPriceItemPO(ByVal Currency As String, ByVal ItemSeqNo As String, ByVal ItemUnitID As String) As Price
            Dim oprice As New Price
            Dim pu As New BussinessRules.PurchaseUnitDt
            pu.ItemSeqNo = ItemSeqNo.Trim
            pu.ItemUnitID = ItemUnitID.Trim
            If pu.SelectLastOneByItemAndItemUnit(Currency.Trim).Rows.Count > 0 Then
                oprice.price = pu.Price
                oprice.discount1pct = pu.Disc1Pct
                oprice.discount1amt = pu.Disc1Amt
                oprice.discount2pct = pu.Disc2Pct
                oprice.discount2amt = pu.Disc2Amt
                oprice.discount3pct = pu.Disc3Pct
                oprice.discount3amt = pu.Disc3Amt
            End If
            pu.Dispose()
            pu = Nothing

            Return oprice
        End Function

        Public Shared Function GetPriceItemDOorSales(ByVal TypeGetPrice As String, ByVal CurrencyRate As Decimal, ByVal ItemSeqNo As String, ByVal ItemUnitID As String, ByVal ItemFactor As Decimal, ByVal MemberNo As String, ByVal STxnNo As String, ByVal CurrentQty As Decimal) As Price
            Dim oprice As New Price
            Dim su As New BussinessRules.SalesUnitDt
            If su.GetPriceItemDOorSales(TypeGetPrice.Trim, CurrencyRate, ItemSeqNo.Trim, ItemUnitID.Trim, ItemFactor, MemberNo, STxnNo, CurrentQty).Rows.Count > 0 Then
                oprice.price = su.Price
                oprice.discount1pct = su.Disc1Pct
                oprice.discount1amt = su.Disc1Amt
                oprice.discount2pct = su.Disc2Pct
                oprice.discount2amt = su.Disc2Amt
                oprice.discount3pct = su.Disc3Pct
                oprice.discount3amt = su.Disc3Amt
            End If
            su.Dispose()
            su = Nothing

            Return oprice
        End Function

        'Public Shared Function GetPriceItemDOorSales(ByVal CurrencyRate As Double, ByVal ItemSeqNo As String, ByVal ItemUnitID As String) As Price
        '    Dim oprice As New Price
        '    Dim oitem As New Item

        '    oitem.ItemSeqNo = ItemSeqNo.Trim
        '    If Not oitem.SelectOne.Rows.Count > 0 Then Return oprice

        '    If oitem.SalesPriceBS <> 0 Then
        '        oprice.price = oitem.SalesPriceBS
        '    ElseIf oitem.ItemLUnitID.Trim = ItemUnitID.Trim And oitem.SalesPriceLUnit <> 0 Then
        '        oprice.price = oitem.SalesPriceLUnit
        '    ElseIf oitem.ItemSUnitID.Trim = ItemUnitID.Trim And oitem.SalesPriceSUnit <> 0 Then
        '        oprice.price = oitem.SalesPriceSUnit
        '    Else
        '        Dim puMaxPrice As Double = 0
        '        Dim PriceWithTax As Double = 0
        '        Dim tax As Double = 0
        '        Dim TaxAmount As Double = 0
        '        Dim MarginAmount As Double = 0
        '        Dim pudt As New BussinessRules.PurchaseUnitDt
        '        With pudt
        '            .ItemSeqNo = ItemSeqNo.Trim
        '            .ItemUnitID = ItemUnitID.Trim
        '            If .SelectOneMaxPriceByItemAndItemUnit.Rows.Count > 0 Then
        '                puMaxPrice = .Price
        '            End If
        '        End With
        '        pudt.Dispose()
        '        pudt = Nothing

        '        Dim tx As New BussinessRules.CommonSetting
        '        tx.GroupID = "Tax"
        '        tx.DetailID = "Tax"
        '        tx.SelecOneByGroupIDByDetailID()
        '        tax = CDbl(IIf(IsNumeric(tx.DetailDesc.Trim) AndAlso CDec(tx.DetailDesc.Trim) > 0 AndAlso CDec(tx.DetailDesc.Trim) < 100, CDec(tx.DetailDesc.Trim), 10))
        '        tx.Dispose()
        '        tx = Nothing

        '        TaxAmount = (puMaxPrice * tax / 100)
        '        PriceWithTax = (puMaxPrice + TaxAmount)

        '        If oitem.MarginPct <> 0 Then
        '            MarginAmount = (PriceWithTax * oitem.MarginPct / 100)
        '        ElseIf oitem.MarginRangeID.Trim <> "" OrElse oitem.MarginRangeID.Trim <> "none" Then
        '            Dim mgdt As New BussinessRules.MarginRangedt
        '            With mgdt
        '                .MarginRangeID = oitem.MarginRangeID.Trim
        '                .MaxAmount = PriceWithTax
        '                If .SelectOneRangeByMarginRangeID.Rows.Count > 0 Then
        '                    MarginAmount = (PriceWithTax * .MarginPct / 100)
        '                End If
        '            End With
        '            mgdt.Dispose()
        '            mgdt = Nothing
        '        End If

        '        oprice.price = PriceWithTax + MarginAmount
        '    End If

        '    oitem.Dispose()
        '    oitem = Nothing

        '    oprice.price = (oprice.price / CurrencyRate)
        '    Return oprice
        'End Function

    End Class

End Namespace
