﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.209
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class dsBasket
    Inherits DataSet
    
    Private tableBasket As BasketDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("Basket")) Is Nothing) Then
                Me.Tables.Add(New BasketDataTable(ds.Tables("Basket")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property Basket As BasketDataTable
        Get
            Return Me.tableBasket
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As dsBasket = CType(MyBase.Clone,dsBasket)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("Basket")) Is Nothing) Then
            Me.Tables.Add(New BasketDataTable(ds.Tables("Basket")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableBasket = CType(Me.Tables("Basket"),BasketDataTable)
        If (Not (Me.tableBasket) Is Nothing) Then
            Me.tableBasket.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "dsBasket"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsBasket.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableBasket = New BasketDataTable
        Me.Tables.Add(Me.tableBasket)
    End Sub
    
    Private Function ShouldSerializeBasket() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub BasketRowChangeEventHandler(ByVal sender As Object, ByVal e As BasketRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BasketDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnSKU As DataColumn
        
        Private columnDescription As DataColumn
        
        Private columnQTY As DataColumn
        
        Friend Sub New()
            MyBase.New("Basket")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property SKUColumn As DataColumn
            Get
                Return Me.columnSKU
            End Get
        End Property
        
        Friend ReadOnly Property DescriptionColumn As DataColumn
            Get
                Return Me.columnDescription
            End Get
        End Property
        
        Friend ReadOnly Property QTYColumn As DataColumn
            Get
                Return Me.columnQTY
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As BasketRow
            Get
                Return CType(Me.Rows(index),BasketRow)
            End Get
        End Property
        
        Public Event BasketRowChanged As BasketRowChangeEventHandler
        
        Public Event BasketRowChanging As BasketRowChangeEventHandler
        
        Public Event BasketRowDeleted As BasketRowChangeEventHandler
        
        Public Event BasketRowDeleting As BasketRowChangeEventHandler
        
        Public Overloads Sub AddBasketRow(ByVal row As BasketRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddBasketRow(ByVal SKU As String, ByVal Description As String, ByVal QTY As Short) As BasketRow
            Dim rowBasketRow As BasketRow = CType(Me.NewRow,BasketRow)
            rowBasketRow.ItemArray = New Object() {SKU, Description, QTY}
            Me.Rows.Add(rowBasketRow)
            Return rowBasketRow
        End Function
        
        Public Function FindBySKU(ByVal SKU As String) As BasketRow
            Return CType(Me.Rows.Find(New Object() {SKU}),BasketRow)
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As BasketDataTable = CType(MyBase.Clone,BasketDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New BasketDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnSKU = Me.Columns("SKU")
            Me.columnDescription = Me.Columns("Description")
            Me.columnQTY = Me.Columns("QTY")
        End Sub
        
        Private Sub InitClass()
            Me.columnSKU = New DataColumn("SKU", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnSKU)
            Me.columnDescription = New DataColumn("Description", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnDescription)
            Me.columnQTY = New DataColumn("QTY", GetType(System.Int16), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnQTY)
            Me.Constraints.Add(New UniqueConstraint("dsBasketKey1", New DataColumn() {Me.columnSKU}, true))
            Me.columnSKU.AllowDBNull = false
            Me.columnSKU.Unique = true
        End Sub
        
        Public Function NewBasketRow() As BasketRow
            Return CType(Me.NewRow,BasketRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New BasketRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(BasketRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.BasketRowChangedEvent) Is Nothing) Then
                RaiseEvent BasketRowChanged(Me, New BasketRowChangeEvent(CType(e.Row,BasketRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.BasketRowChangingEvent) Is Nothing) Then
                RaiseEvent BasketRowChanging(Me, New BasketRowChangeEvent(CType(e.Row,BasketRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.BasketRowDeletedEvent) Is Nothing) Then
                RaiseEvent BasketRowDeleted(Me, New BasketRowChangeEvent(CType(e.Row,BasketRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.BasketRowDeletingEvent) Is Nothing) Then
                RaiseEvent BasketRowDeleting(Me, New BasketRowChangeEvent(CType(e.Row,BasketRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveBasketRow(ByVal row As BasketRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BasketRow
        Inherits DataRow
        
        Private tableBasket As BasketDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableBasket = CType(Me.Table,BasketDataTable)
        End Sub
        
        Public Property SKU As String
            Get
                Return CType(Me(Me.tableBasket.SKUColumn),String)
            End Get
            Set
                Me(Me.tableBasket.SKUColumn) = value
            End Set
        End Property
        
        Public Property Description As String
            Get
                Try 
                    Return CType(Me(Me.tableBasket.DescriptionColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBasket.DescriptionColumn) = value
            End Set
        End Property
        
        Public Property QTY As Short
            Get
                Try 
                    Return CType(Me(Me.tableBasket.QTYColumn),Short)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBasket.QTYColumn) = value
            End Set
        End Property
        
        Public Function IsDescriptionNull() As Boolean
            Return Me.IsNull(Me.tableBasket.DescriptionColumn)
        End Function
        
        Public Sub SetDescriptionNull()
            Me(Me.tableBasket.DescriptionColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsQTYNull() As Boolean
            Return Me.IsNull(Me.tableBasket.QTYColumn)
        End Function
        
        Public Sub SetQTYNull()
            Me(Me.tableBasket.QTYColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BasketRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As BasketRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As BasketRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As BasketRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
