<asp:DataGrid	id="RadGridGetCN" 
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
            <HeaderTemplate>
                    <input	name="chkSelectAllItems"
										ID="chkSelectAllItems"
										type="checkbox"																								
										onclick="javascript:checkAllv2(this.form,'_chkCN', 'chkSelectAllItems');">													
            </HeaderTemplate>
			<ItemTemplate>
				<asp:CheckBox runat="server" id="_chkCN" enabled="True" />	
			</ItemTemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Credit Note No." >
			<itemtemplate>
				<asp:label runat="server" id="_lblCNoteNo" Text='<%# DataBinder.Eval(Container.DataItem, "DCNoteNo") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Reference No" >
			<itemtemplate>
				<asp:label runat="server" id="_lblReferenceNo" Text='<%# DataBinder.Eval(Container.DataItem, "ReferenceNo") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Credit Note Date" >
			<itemtemplate>
				<asp:label runat="server" id="_lblCNoteDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "DCNoteDate"),"dd-MM-yyyy") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Amount" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "Amount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Tax Amount" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblTaxAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "TaxAmount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>


		<asp:TemplateColumn runat="server" HeaderText="Amount Differences" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblAmtDifferences" Text='<%# format(DataBinder.Eval(Container.DataItem, "AmtDifferences"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:DataGrid>	
			