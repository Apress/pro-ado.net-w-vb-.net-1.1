<%@ Page language="VB" Codebehind="WebForm1.aspx.vb"
         AutoEventWireup="false" Inherits="VBWebSample.WebForm1" %>
<!doctype HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
	</head>
	<body ms_positioning="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td valign="top">
						<table>
							<tr>
								<td valign="top">
									<b>Sort &amp; Filter</b>
									<br>
									Sort Field
									<br>
									<asp:dropdownlist id="SortList" runat="server" />
								</td>
							</tr>
							<tr>
								<td>
									Sort Direction
									<br>
									<asp:radiobuttonlist id="SortDirection" runat="server">
										<asp:listitem value="ASC" text="Asc" selected="True" />
										<asp:listitem value="DESC" text="Desc" />
									</asp:radiobuttonlist>
								</td>
							</tr>
							<tr>
								<td>
									Filter Field
									<br>
									<asp:dropdownlist id="FilterList" runat="server" />
								</td>
							</tr>
							<tr>
								<td>
									Filter Criteria
									<br>
									<asp:textbox id="FilterCriteria" runat="server" />
								</td>
							</tr>
							<tr>
								<td>
									<asp:button id="submit" runat="server" text="Update" />
								</td>
							</tr>
						</table>
					</td>
					<td valign="top">
						<asp:datagrid id="Authors" runat="server" />
					</td>
				</tr>
			</table>
		</form>
	</body>
</html>
