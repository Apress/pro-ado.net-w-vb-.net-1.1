<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Client_StoredProc.aspx.vb" Inherits="DALWebApp.Client_StoredProc"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Client_StoredProc</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:dropdownlist id="ddlDataSource" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">
				<asp:ListItem Value="Sql">SQL Server</asp:ListItem>
				<asp:ListItem Value="OleDb">OLE DB - Access</asp:ListItem>
				<asp:ListItem Value="Odbc">ODBC - SQL Server</asp:ListItem>
				<asp:ListItem Value="Oracle">Oracle</asp:ListItem>
			</asp:dropdownlist>
			<asp:datagrid id="grdProducts" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 39px" runat="server" Height="180px" Width="323px"></asp:datagrid>
			<asp:button id="Button1" style="Z-INDEX: 103; LEFT: 192px; POSITION: absolute; TOP: 8px" runat="server" Text="Run"></asp:button>
		</form>
	</body>
</HTML>
