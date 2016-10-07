<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DataSetConsumer.aspx.vb" Inherits="VBConsumer.DataSetConsumer"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>DataSetConsumer</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<H3>Trivial Fun Tools - AddMovieQuotes(DataSet) Consumer</H3>
			<P>
				<asp:Button id="Button1" runat="server" Text="Invoke AddMovieQuotes"></asp:Button></P>
			<TABLE id="Table1" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR>
					<TD><STRONG>Original DataSet</STRONG></TD>
					<TD><STRONG>DataSet To Add</STRONG></TD>
					<TD><STRONG>Results From AddMovieQuotes(DataSet)</STRONG></TD>
				</TR>
				<TR>
					<TD valign="top">
						<asp:DataGrid id="OriginalDataGrid" runat="server" AutoGenerateColumns="False" Font-Names="Verdana, Arial, sans-serif" Font-Size="x-small" HeaderStyle-BackColor="Maroon" HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="True" AlternatingItemStyle-BackColor="Tan">
							<Columns>
								<asp:TemplateColumn HeaderText="Movie Quote">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Quote") %>
										<br>
										<%# DataBinder.Eval(Container.DataItem, "ActorOrCharacter") %>
										-
										<%# DataBinder.Eval(Container.DataItem, "Movie") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
					<TD valign="top">
						<asp:DataGrid id="DataToAddGrid" runat="server" AutoGenerateColumns="False" Font-Names="Verdana, Arial, sans-serif" Font-Size="x-small" HeaderStyle-BackColor="Maroon" HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="True" AlternatingItemStyle-BackColor="Tan">
							<Columns>
								<asp:TemplateColumn HeaderText="Movie Quote">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Quote") %>
										<br>
										<%# DataBinder.Eval(Container.DataItem, "ActorOrCharacter") %>
										-
										<%# DataBinder.Eval(Container.DataItem, "Movie") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
					<TD vAlign="top">
						<asp:DataGrid id="ResultGrid" runat="server" AutoGenerateColumns="False" Font-Names="Verdana, Arial, sans-serif" Font-Size="x-small" HeaderStyle-BackColor="Maroon" HeaderStyle-ForeColor="White" HeaderStyle-Font-Bold="True" AlternatingItemStyle-BackColor="Tan">
							<Columns>
								<asp:TemplateColumn HeaderText="Movie Quote">
									<ItemTemplate>
										<%# DataBinder.Eval(Container.DataItem, "Quote") %>
										<br>
										<%# DataBinder.Eval(Container.DataItem, "ActorOrCharacter") %>
										-
										<%# DataBinder.Eval(Container.DataItem, "Movie") %>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
