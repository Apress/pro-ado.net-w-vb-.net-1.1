Imports Microsoft.Data.SqlXml
Imports System.IO
Imports System.Data.SqlClient
Imports System.Xml

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button7 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "sqlQuery"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(104, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(552, 184)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ClientXml"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(16, 72)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Transform"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(16, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Param"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(16, 136)
        Me.Button5.Name = "Button5"
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Template"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(16, 336)
        Me.Button6.Name = "Button6"
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Adapter"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(16, 216)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(648, 112)
        Me.DataGrid1.TabIndex = 7
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(16, 168)
        Me.Button7.Name = "Button7"
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "Update"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(696, 374)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button7, Me.DataGrid1, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.TextBox1, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strConnection As String = _
        "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI; Initial Catalog=Northwind"

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)

        sqlxmlcommand.CommandText = "SELECT * from Customers FOR XML AUTO"
        sqlxmlcommand.CommandType = SqlXmlCommandType.Sql

        Dim sr As StreamReader = New StreamReader(sqlxmlcommand.ExecuteStream())

        TextBox1.Text = sr.ReadToEnd()
        sr.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cmd As New SqlXmlCommand("Provider=SQLOLEDB; " & _
            "Data Source=(local);Initial Catalog=Northwind; User Id=sa; Password=sa;")


        cmd.CommandText = "SELECT * from Customers FOR XML NESTED"

        cmd.ClientSideXml = True
        cmd.RootTag = "CustomerData"
        cmd.OutputEncoding = "utf-16"

        Dim rdr As XmlTextReader
        rdr = cmd.ExecuteXmlReader()
        rdr.MoveToContent()

        Do While rdr.ReadState <> ReadState.EndOfFile
            TextBox1.Text = rdr.ReadOuterXml()
        Loop
        rdr.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim strConnection As String = _
            "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)

        sqlxmlcommand.RootTag = "CustomerData"
        sqlxmlcommand.CommandType = SqlXmlCommandType.Sql
        sqlxmlcommand.CommandText = "SELECT * from Customers FOR XML NESTED"

        sqlxmlcommand.XslPath = "trans.xsl"
        sqlxmlcommand.BasePath = "http://localhost/"
        sqlxmlcommand.ClientSideXml = True

        Dim ms As MemoryStream = sqlxmlcommand.ExecuteStream()

        Dim sr As StreamReader = New StreamReader(ms)
        TextBox1.Text = sr.ReadToEnd()

        Dim fileStream As New FileStream("CustomerData.htm", FileMode.OpenOrCreate, FileAccess.Write)

        Dim buffer(ms.Length) As Byte

        Dim bufSz As Integer = ms.Read(buffer, 0, ms.Length)

        fileStream.Write(buffer, 0, bufSz)

        fileStream.Close()
        sr.Close()
        ms.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim strConnection As String = _
            "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)
        sqlxmlcommand.CommandText = "SELECT * FROM products where ProductName LIKE ? FOR XML AUTO"

        Dim sqlxmlparam As SqlXmlParameter = sqlxmlcommand.CreateParameter()
        sqlxmlparam.Value = "Z%"

        Dim sr As StreamReader = New StreamReader(sqlxmlcommand.ExecuteStream())

        TextBox1.Text = sr.ReadToEnd()
        sr.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim strConnection As String = _
            "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"

        Dim xmlquery As FileStream = New FileStream("../FindProducts.xml", FileMode.Open)

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)
        sqlxmlcommand.CommandStream = xmlquery
        sqlxmlcommand.CommandType = SqlXmlCommandType.Template

        Dim sqlxmlparam As SqlXmlParameter = sqlxmlcommand.CreateParameter()
        sqlxmlparam.Name = "@ProductName"
        sqlxmlparam.Value = "Z%"

        'Dim sr As StreamReader = New StreamReader(sqlxmlcommand.ExecuteStream())
        'TextBox1.Text = sr.ReadToEnd()
        'sr.Close()

        'Dim rdr As XmlTextReader
        'rdr = sqlxmlcommand.ExecuteXmlReader()
        'rdr.MoveToContent()
        'TextBox1.Text = rdr.ReadInnerXml()
        'rdr.Close()

        'Dim myXmlDocument As XmlDocument = New XmlDocument
        'myXmlDocument.Load(sqlxmlcommand.ExecuteXmlReader())

        Dim da As New SqlXmlAdapter(sqlxmlcommand)
        Dim dsProducts As New DataSet
        da.Fill(dsProducts)
        DataGrid1.DataSource = dsProducts.Tables("Products")
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim strConnection As String = _
            "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)
        sqlxmlcommand.CommandText = "products"
        sqlxmlcommand.CommandType = SqlXmlCommandType.XPath
        sqlxmlcommand.SchemaPath = "../Products.xsd"
        sqlxmlcommand.ClientSideXml = True
        sqlxmlcommand.RootTag = "ProductData"

        Dim da As SqlXmlAdapter = New SqlXmlAdapter(sqlxmlcommand)
        Dim dsProducts As DataSet = New DataSet()
        da.Fill(dsProducts)
        DataGrid1.DataSource = dsProducts.Tables("products")

        'dsProducts.Tables("products").Rows(0).Item("ProductName") = "Zaanse koeken 3"
        'da.Update(dsProducts)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim strConnection As String = _
            "Provider=SQLOLEDB;Data Source=(local);Integrated Security=SSPI;Initial Catalog=Northwind"

        Dim xmlquery As FileStream = New FileStream("../UpdateGram.xml", FileMode.Open)

        Dim sqlxmlcommand As SqlXmlCommand = New SqlXmlCommand(strConnection)
        sqlxmlcommand.CommandStream = xmlquery
        sqlxmlcommand.CommandType = SqlXmlCommandType.UpdateGram

        sqlxmlcommand.ExecuteNonQuery()
        xmlquery.Close()
    End Sub
End Class
