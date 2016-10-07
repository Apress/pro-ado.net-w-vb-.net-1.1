<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Example11VB.WebForm1"%>
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
			<asp:DataGrid id="dgBasket" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="656px" Height="73px" DataSource="<%# dvBasket %>" DataKeyField="SKU" GridLines="None" BorderWidth="1px" BorderColor="Tan" BackColor="LightGoldenrodYellow" CellPadding="2" ForeColor="Black" AllowSorting="True">
				<FooterStyle BackColor="Tan"></FooterStyle>
				<HeaderStyle Font-Bold="True" BackColor="Tan"></HeaderStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="DarkSlateBlue" BackColor="PaleGoldenrod"></PagerStyle>
				<SelectedItemStyle ForeColor="GhostWhite" BackColor="DarkSlateBlue"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="PaleGoldenrod"></AlternatingItemStyle>
				<Columns>
					<asp:ButtonColumn Text="Delete" CommandName="Delete">
						<ItemStyle Font-Size="Smaller" Font-Names="Verdana"></ItemStyle>
					</asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
