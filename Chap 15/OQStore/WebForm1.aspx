<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="OQStore.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" cellspacing="0" cellpadding="2">
				<tr bgcolor="#ccffff">
					<td>
						<b><font face="verdana" size="2">Order Checkout</font></b>
					</td>
				</tr>
				<tr>
					<td>
						<table width="750" border="0" cellspacing="0" cellpadding="1">
							<tr bgcolor="#000088">
								<td>
									<font color="white">Stock No</font>
								</td>
								<td>
									<font color="white">Description</font>
								</td>
								<td>
									<font color="white">Price</font>
								</td>
								<td align="right">
									<font color="white">Quantity</font>
								</td>
							</tr>
							<tr>
								<td>
									MOVIE999
								</td>
								<td>
									A Brand New Movie on DVD
								</td>
								<td>
									$24.99
								</td>
								<td align="right">
									12
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<P>
				<br>
				<input type="submit" name="submit" value="Click To Check Out">
			</P>
			<P>
			</P>
			<P>
				<asp:Label id="lblInfo" runat="server"></asp:Label>
			</P>
		</form>
	</body>
</HTML>
