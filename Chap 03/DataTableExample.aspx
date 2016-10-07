<%@ Page Inherits="DataTableExample" Src="DataTableExample.aspx.vb" %>
<HTML>
<BODY>
<FORM runat="server">
  <TABLE CellPadding="4" CellSpacing="0" Border="0">
    <TR>
      <TD VALIGN="TOP">
        <H3>Products Table</H3>
        <asp:DataGrid runat="server" id="productGrid"
                      CellPadding="4" CellSpacing="0"
                      BorderWidth="1" Gridlines="Horizontal"
                      Font-Names="Verdana, Arial, sans-serif"
                      Font-Size="x-small" HeaderStyle-Font-Bold="True"
                      OnEditCommand="DataGrid_OnEditCommand"
                      OnCancelCommand="DataGrid_OnCancelCommand"
                      OnUpdateCommand="DataGrid_OnUpdateCommand"
                      OnDeleteCommand="DataGrid_OnDeleteCommand">
          <Columns>
            <asp:ButtonColumn Text="Delete" CommandName="Delete" />
            <asp:EditCommandColumn EditText="Edit"
                                   CancelText="Cancel"
                                   UpdateText="Update" />
          </Columns>
        </asp:DataGrid>
      </TD>
      <TD VALIGN="TOP">
        <H3>DataTable Events List</H3>
        <asp:Label runat="server" id="eventsList"
                   Font-Names="Verdana, Arial, sans-serif"
                   Font-Size="x-small" />
      </TD>
    </TR>
  </TABLE>
</FORM>
</BODY>
</HTML>