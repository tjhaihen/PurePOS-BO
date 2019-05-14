<asp:datagrid id="RadGridDebitNote" runat="server" style="width: 100%" cellpadding="1"
    showfooter="False" pagesize="20" allowpaging="false" gridlines="None" borderwidth="1"
    bordercolor="Gainsboro" cellspacing="1" autogeneratecolumns="False" allowsorting="True">
	<HeaderStyle CssClass="gridheaderstyle" />
    <AlternatingItemStyle CssClass="gridAlternatingItemstyle" />
    <ItemStyle CssClass="gridItemstyle" />
    <EditItemStyle Font-Bold="false" />										
	<PagerStyle Mode="NumericPages" HorizontalAlign="right" />																		
	<Columns>
		<asp:TemplateColumn runat="server" HeaderText="" >
		   
			<itemtemplate>
				<asp:LinkButton ID="_lbtnDelete" Runat="server" CommandName="Delete" Text="<img src='/pureravenslib/images/Delete.png' border='0' align='absmiddle'/>"
										ToolTip="Delete record" />
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Debit Note No." >
			<itemtemplate>
				<asp:label runat="server" id="_lblDNoteNo" Text='<%# DataBinder.Eval(Container.DataItem, "DCNoteNo") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		<asp:TemplateColumn runat="server" HeaderText="Reference No" >
			<itemtemplate>
				<asp:label runat="server" id="_lblReferenceNo" Text='<%# DataBinder.Eval(Container.DataItem, "ReferenceNo") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Debit Note Date" >
			<itemtemplate>
				<asp:label runat="server" id="_lblDNoteDate" Text='<%# Format(DataBinder.Eval(Container.DataItem, "DCNoteDate"),"dd-MM-yyyy") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "Amount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Tax" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblTaxAmount" Text='<%# format(DataBinder.Eval(Container.DataItem, "TaxAmount"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
		
		<asp:TemplateColumn runat="server" HeaderText="Sub Total" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
			<itemtemplate>
				<asp:label runat="server" id="_lblSubTotal" Text='<%# format(DataBinder.Eval(Container.DataItem, "Subtotal"),"#,##0.00") %>'/>
			</itemtemplate>
		</asp:TemplateColumn>
	</Columns>
</asp:datagrid>
