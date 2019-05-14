<asp:DataGrid	id="RadGridDPAmount" 
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
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" >
			<itemtemplate>
				<asp:label runat="server" id="_lblDPAmt" Text='<%# format(DataBinder.Eval(Container.DataItem, "DPAmt"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:DataGrid>	
			