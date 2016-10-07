<%@ Page Inherits="DataRelnsExample" Src="DataRelnsExample.aspx.vb" %>
<%@ Import Namespace="System.Data" %>

<HTML>
<BODY>
 <FORM runat="server">
  <TABLE Border="0" CellPadding="2" CellSpacing="0">
   <TR>
    <TD valign="top">
     <asp:DataGrid runat="server" id="customersDataGrid"
                   CellPadding="4" CellSpacing="0"
                   BorderWidth="1" Gridlines="Horizontal"
                   Font-Names="Verdana, Arial, sans-serif"
                   Font-Size="x-small" HeaderStyle-Font-Bold="True"
                   AutogenerateColumns="False"
                   OnDeleteCommand="DeleteCustomer">
      <Columns>
       <asp:ButtonColumn Text="Delete" CommandName="Delete" />
       <asp:BoundColumn DataField="CustomerID" />
       <asp:TemplateColumn HeaderText="Customers">
        <ItemTemplate>
          <b><%# DataBinder.Eval(Container.DataItem, "CompanyName") %></b>
          <br><%# DataBinder.Eval(Container.DataItem, "ContactName") %>-
          <%# DataBinder.Eval(Container.DataItem, "ContactTitle") %>
        </ItemTemplate>
       </asp:TemplateColumn>
      </Columns>
     </asp:DataGrid>
    </TD>
    <TD valign="top">
     <asp:DataGrid runat="server" id="ordersDataGrid"
                   CellPadding="4" CellSpacing="0"
                   BorderWidth="1" Gridlines="Horizontal"
                   Font-Names="Verdana, Arial, sans-serif"
                   Font-Size="x-small" HeaderStyle-Font-Bold="True"
                   AutogenerateColumns="False">
      <Columns>
       <asp:TemplateColumn HeaderText="Orders">
        <ItemTemplate>
         <b><%# DataBinder.Eval(Container.DataItem, "CustomerID") %>-
         <%# DataBinder.Eval(Container.DataItem, "OrderID") %></b>
         <br>Ordered:
         <%# DataBinder.Eval(Container.DataItem, "OrderDate", "{0:d}") %>
         <br>Required:
         <%# DataBinder.Eval(Container.DataItem, "RequiredDate", "{0:d}") %>
         <br>Shipped:
         <%# DataBinder.Eval(Container.DataItem, "ShippedDate", "{0:d}") %>
        </ItemTemplate>
       </asp:TemplateColumn>
      </Columns>
     </asp:DataGrid>
    </TD>
   </TR>
  </TABLE>
 </FORM>
</BODY>
</HTML>