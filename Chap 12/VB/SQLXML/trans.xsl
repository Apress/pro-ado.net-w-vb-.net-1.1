<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
		xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head><title>Customer Data</title></head>
			<body bgcolor="lightblue">
				<xsl:apply-templates select="CustomerData"/>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="CustomerData">
		<table>
			<tr align="left">
			<th>
				Company Name
			</th>
			<th>
				Contact Name
			</th>	
			<th>
				Country
			</th>
			</tr>	
			<xsl:apply-templates select="Customers">
				<xsl:sort select="@Country" />
				<xsl:sort select="@CompanyName" />
			</xsl:apply-templates>
		</table>
	</xsl:template>

	<xsl:template match="Customers">
		<tr>
			<td>
				<xsl:value-of select="@CompanyName" />
			</td>
			<td>
				<xsl:value-of select="@ContactName" />
			</td>	
			<td>
				<xsl:value-of select="@Country" />
			</td>
		</tr>		
	</xsl:template>	
</xsl:stylesheet>
