<asp:DataGrid	id="RadGridPurchaseUnit" 
				runat="server" 
				style="Width:100%" 
				CellPadding="1" 
				ShowFooter="False" 																				
				PageSize="20" 
				AllowPaging="false" 
				GridLines="None" 
				BorderWidth="1" 
				BorderColor="Gainsboro"
				CellSpacing="1" 
				AutoGenerateColumns="False"
				AllowSorting="True">
	<HeaderStyle CssClass="gridheaderstyle" />
    <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
    <ItemStyle CssClass="gridItemstyle" />
    <EditItemStyle Font-Bold="false" />										
	<PagerStyle Mode="NumericPages" HorizontalAlign="right" />																		
	<Columns>
		<asp:TemplateColumn HeaderStyle-Width="50"
                    ItemStyle-Width="50">
			<ItemTemplate>
				<asp:LinkButton ID="_lbtnDelete" Runat="server" CommandName="Delete" Text="<img src='/pureravenslib/images/Delete.png' border='0' align='absmiddle'/>"
										ToolTip="Delete record" />
			</ItemTemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="PU NO." >
			<itemtemplate>
				<asp:label runat="server" id="_lblPUnitNO" Text='<%# DataBinder.Eval(Container.DataItem, "PUnitNO") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="PU Date" >
			<itemtemplate>
				<asp:label runat="server" id="_lblPUnitDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "PUnitDate"),"dd-MM-yyyy") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Currency Rate" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblCurrencyRate" Text='<%# format(DataBinder.Eval(Container.DataItem, "CurrencyRate"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>

        <asp:TemplateColumn runat="server" HeaderText="Total PU" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblTotalDetailPct" Text='<%# format(DataBinder.Eval(Container.DataItem, "TotalDetail"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="DiscFinal ( % )" visible="False" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblDiscFinalPct" Text='<%# format(DataBinder.Eval(Container.DataItem, "DiscFinalPct"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Disc Final Amount" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblDiscFinalAmt" Text='<%# format(DataBinder.Eval(Container.DataItem, "DiscFinalAmt"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Tax Amount" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblPPNAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "PPNAmount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>		
    </Columns>
</asp:DataGrid>
			
			
			
			
			
			
			
		
			
			
			