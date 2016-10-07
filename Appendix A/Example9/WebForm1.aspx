<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Example9VB.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:datagrid id=dgFlights style="Z-INDEX: 101; LEFT: 7px; POSITION: absolute; TOP: 8px" runat="server" Width="938px" Height="283px" DataSource="<%# dvFlights %>" Font-Size="X-Small" Font-Names="Verdana" AutoGenerateColumns="False" DataKeyField="FLIGHTCODE" AllowSorting="True">
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana"></HeaderStyle>
				<SelectedItemStyle ForeColor="Aqua" BackColor="Black"></SelectedItemStyle>
				<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="Book" HeaderText="Click the link to book the flight" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="FLIGHTCODE" SortExpression="FLIGHTCODE" ReadOnly="True" HeaderText="FLIGHTCODE"></asp:BoundColumn>
					<asp:BoundColumn DataField="LeaveFrom" SortExpression="LeaveFrom" HeaderText="LeaveFrom"></asp:BoundColumn>
					<asp:BoundColumn DataField="GoingTo" SortExpression="GoingTo" HeaderText="GoingTo"></asp:BoundColumn>
					<asp:BoundColumn DataField="Depart" SortExpression="Depart" HeaderText="Depart"></asp:BoundColumn>
					<asp:BoundColumn DataField="Arrive" SortExpression="Arrive" HeaderText="Arrive"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
		<div id="outputText" style="LEFT: 10px; POSITION: absolute; TOP: 300px" runat="server"></div>
	</body>
</HTML>
