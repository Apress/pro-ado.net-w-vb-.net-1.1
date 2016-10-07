<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PrivateSoapConsumer.aspx.vb" Inherits="VBConsumer.PrivateSoapConsumer"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PrivateSoapConsumer</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<h3>
				PrivateServices - GetMySecret() SOAP Authentication
			</h3>
			<P>
				User Name:
				<BR>
				<asp:TextBox id="Username" runat="server" />
			</P>
			<P>
				Password:
				<BR>
				<asp:TextBox id="Password" runat="server" />
			</P>
			<P>
				<asp:Button id="Button1" runat="server" Text="Get Secret!" />
			</P>
			<P>
				<asp:Label id="Result" runat="server" />
			</P>
		</form>
	</body>
</HTML>
