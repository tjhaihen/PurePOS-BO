<asp:DataGrid	id="RadGridGetDP" 
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
										onclick="javascript:checkAllv2(this.form,'_chkDP', 'chkSelectAllItems');">													
            </HeaderTemplate>
			<ItemTemplate>
				<asp:CheckBox runat="server" id="_chkDP" enabled="True" />	
			</ItemTemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="PO NO." >
			<itemtemplate>
				<asp:label runat="server" id="_lblPOrdNO" Text='<%# DataBinder.Eval(Container.DataItem, "POrdNO") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="PO Date" >
			<itemtemplate>
				<asp:label runat="server" id="_lblPOrdDate" Text='<%# format(DataBinder.Eval(Container.DataItem, "POrdDate"),"dd-MM-yyyy") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblDPAmt" Text='<%# format(DataBinder.Eval(Container.DataItem, "DPAmt"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:DataGrid>	