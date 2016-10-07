<%@ Page Language="vb" AutoEventWireup="false" Codebehind="HttpConsumer.aspx.vb" Inherits="VBConsumer.HttpConsumer"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>HttpConsumer</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<h3>
				Random Number Consumer
			</h3>
			<p>
				To get a random number, enter your number range and click Go.
			</p>
			<b>Low Number:</b>
			<br>
			<asp:TextBox Runat="server" ID="lowNumber" />
			<br>
			<b>High Number:</b>
			<br>
			<asp:TextBox Runat="server" ID="highNumber" />
			<br>
			<p>
				<asp:Button Runat="server" Text="Go" id="Button1" />
			</p>
			<asp:Label Runat="server" ID="webMethodResult" />
		</form>
	</body>
</HTML>
