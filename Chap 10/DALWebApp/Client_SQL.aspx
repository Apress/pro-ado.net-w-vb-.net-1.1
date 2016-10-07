<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Client_SQL.aspx.vb" Inherits="DALWebApp.Client_SQL"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Client_SQL</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:dropdownlist id="ddlDataSource" style="Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 9px" runat="server">
				<asp:ListItem Value="Sql">SQL Server</asp:ListItem>
				<asp:ListItem Value="OleDb">OLE DB - Access</asp:ListItem>
				<asp:ListItem Value="Odbc">ODBC - SQL Server</asp:ListItem>
				<asp:ListItem Value="Oracle">Oracle</asp:ListItem>
			</asp:dropdownlist><asp:datagrid id="grdProducts" style="Z-INDEX: 105; LEFT: 13px; POSITION: absolute; TOP: 76px" runat="server" Width="323px" Height="180px"></asp:datagrid><asp:label id="lblMessage" style="Z-INDEX: 104; LEFT: 14px; POSITION: absolute; TOP: 45px" runat="server" Width="362px">lblMessage...</asp:label><asp:dropdownlist id="ddlFunction" style="Z-INDEX: 102; LEFT: 192px; POSITION: absolute; TOP: 8px" runat="server">
				<asp:ListItem Value="Select">Select</asp:ListItem>
				<asp:ListItem Value="Insert">Insert</asp:ListItem>
				<asp:ListItem Value="Edit">Edit</asp:ListItem>
				<asp:ListItem Value="Delete">Delete</asp:ListItem>
			</asp:dropdownlist><asp:button id="Button1" style="Z-INDEX: 103; LEFT: 339px; POSITION: absolute; TOP: 8px" runat="server" Text="Run"></asp:button></form>
	</body>
</HTML>
