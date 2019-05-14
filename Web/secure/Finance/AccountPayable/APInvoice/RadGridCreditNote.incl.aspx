<asp:datagrid id="RadGridCreditNote" runat="server" style="width: 100%" cellpadding="1"
    showfooter="False" pagesize="20" allowpaging="false" gridlines="None" borderwidth="1"
    bordercolor="Gainsboro" cellspacing="1" autogeneratecolumns="False" allowsorting="True">
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
		
		<asp:TemplateColumn runat="server" HeaderText="Tax" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblTaxAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "TaxAmount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign ="Right" headerStyle-HorizontalAlign ="Right" >
			<itemtemplate>
				<asp:label runat="server" id="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
    </Columns>
</asp:datagrid>
