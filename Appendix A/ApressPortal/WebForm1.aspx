<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="ApressPortalVB.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="dg" style="Z-INDEX: 101; LEFT: 112px; POSITION: absolute; TOP: 128px" runat="server"
				Width="816px" Height="156px" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" BackColor="White"
				CellPadding="4">
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<HeaderStyle Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" Height="30px" BorderWidth="2px"
					ForeColor="#FFFFCC" BorderStyle="Double" BorderColor="SkyBlue" VerticalAlign="Top" BackColor="#990000"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<ItemStyle Font-Size="Smaller" Font-Names="Verdana" BorderWidth="2px" ForeColor="#330099" BorderStyle="Solid"
					BorderColor="SkyBlue" BackColor="White"></ItemStyle>
			</asp:DataGrid>
			<asp:Panel id="Panel1" style="Z-INDEX: 103; LEFT: 90px; POSITION: absolute; TOP: 11px" runat="server"
				BackColor="Maroon" Height="62px" Width="855px" ForeColor="White" HorizontalAlign="Center"
				Font-Names="Impact" Font-Size="XX-Large">Flights 
List</asp:Panel>
		</form>
	</body>
</HTML>
