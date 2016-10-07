<%@ Page Inherits="DataMergeExample" Src="DataMergeExample.aspx.vb" %>
<%@ Import Namespace="System.Data" %>
<HTML>
<BODY STYLE="font: xx-small Verdana, Arial, sans-serif;">
<FORM runat="server">
  <H3>DataSet.Merge() Method</H3>
  <TABLE Border="0" CellPadding="2" CellSpacing="0" STYLE="font: xx-small Verdana, Arial, sans-serif;">
    <TR>
      <TD valign="top">
        Choose the DataGrid to preserve changes on:<BR>
        <asp:RadioButtonList runat="server" id="PreserveChanges"
          Font-Names="Verdana, Arial, sans-serif"
          Font-Size="xx-small" >
          <asp:ListItem Text="DataGrid1" Value="1" />
          <asp:ListItem Text="DataGrid2" Value="2" Selected="True" />
        </asp:RadioButtonList>
      </TD>
      <TD valign="top">
        Do you want to add the schema to the new DataSet?<BR>
        <asp:CheckBox runat="server" id="AddSchema" Checked="True" 
          Font-Names="Verdana, Arial, sans-serif"
          Font-Size="xx-small" />
      </TD>
      <TD Width="100%">
      </TD>
    </TR>
    <TR>
      <TD valign="top">
        <asp:DataGrid runat="server" id="DataGrid1"
          CellPadding="4" CellSpacing="0"
          BorderWidth="1" Gridlines="Horizontal"
          Font-Names="Verdana, Arial, sans-serif"
          Font-Size="xx-small"
          HeaderStyle-Font-Bold="True"
          />
      </TD>
      <TD valign="top">
        <asp:DataGrid runat="server" id="DataGrid2"
          CellPadding="4" CellSpacing="0"
          BorderWidth="1" Gridlines="Horizontal"
          Font-Names="Verdana, Arial, sans-serif"
          Font-Size="xx-small"
          HeaderStyle-Font-Bold="True"
          OnEditCommand="DataGrid_OnEditCommand"
          OnUpdateCommand="DataGrid_OnUpdateCommand"
          OnCancelCommand="DataGrid_OnCancelCommand" >
          <Columns>
            <asp:EditCommandColumn 
            	EditText="Edit" 
            	UpdateText="Update"
            	CancelText="Cancel" />
          </Columns>
        </asp:DataGrid>
      </TD>
      <TD valign="top">
        <asp:DataGrid runat="server" id="DataGrid3"
          CellPadding="4" CellSpacing="0"
          BorderWidth="1" Gridlines="Horizontal"
          Font-Names="Verdana, Arial, sans-serif"
          Font-Size="xx-small"
          HeaderStyle-Font-Bold="True"
          />
      </TD>
    </TR>
  </TABLE>
</FORM>
</BODY>
</HTML>