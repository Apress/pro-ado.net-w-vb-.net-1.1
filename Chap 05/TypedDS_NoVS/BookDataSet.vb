﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
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

'
'This source code was auto-generated by xsd, Version=1.1.4322.573.
'

<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class BookDataSet
    Inherits DataSet
    
    Private tableBooks As BooksDataTable
    
    Private tableBookReviews As BookReviewsDataTable
    
    Private relationKeyBookIDRef As DataRelation
    
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
            If (Not (ds.Tables("Books")) Is Nothing) Then
                Me.Tables.Add(New BooksDataTable(ds.Tables("Books")))
            End If
            If (Not (ds.Tables("BookReviews")) Is Nothing) Then
                Me.Tables.Add(New BookReviewsDataTable(ds.Tables("BookReviews")))
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
    Public ReadOnly Property Books As BooksDataTable
        Get
            Return Me.tableBooks
        End Get
    End Property
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property BookReviews As BookReviewsDataTable
        Get
            Return Me.tableBookReviews
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As BookDataSet = CType(MyBase.Clone,BookDataSet)
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
        If (Not (ds.Tables("Books")) Is Nothing) Then
            Me.Tables.Add(New BooksDataTable(ds.Tables("Books")))
        End If
        If (Not (ds.Tables("BookReviews")) Is Nothing) Then
            Me.Tables.Add(New BookReviewsDataTable(ds.Tables("BookReviews")))
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
        Me.tableBooks = CType(Me.Tables("Books"),BooksDataTable)
        If (Not (Me.tableBooks) Is Nothing) Then
            Me.tableBooks.InitVars
        End If
        Me.tableBookReviews = CType(Me.Tables("BookReviews"),BookReviewsDataTable)
        If (Not (Me.tableBookReviews) Is Nothing) Then
            Me.tableBookReviews.InitVars
        End If
        Me.relationKeyBookIDRef = Me.Relations("KeyBookIDRef")
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "BookDataSet"
        Me.Prefix = ""
        Me.Namespace = "urn:apress-proadonet-chapter5-BookDataSet.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableBooks = New BooksDataTable
        Me.Tables.Add(Me.tableBooks)
        Me.tableBookReviews = New BookReviewsDataTable
        Me.Tables.Add(Me.tableBookReviews)
        Dim fkc As ForeignKeyConstraint
        fkc = New ForeignKeyConstraint("KeyBookIDRef", New DataColumn() {Me.tableBooks.BookIDColumn}, New DataColumn() {Me.tableBookReviews.BookIDColumn})
        Me.tableBookReviews.Constraints.Add(fkc)
        fkc.AcceptRejectRule = System.Data.AcceptRejectRule.None
        fkc.DeleteRule = System.Data.Rule.Cascade
        fkc.UpdateRule = System.Data.Rule.Cascade
        Me.relationKeyBookIDRef = New DataRelation("KeyBookIDRef", New DataColumn() {Me.tableBooks.BookIDColumn}, New DataColumn() {Me.tableBookReviews.BookIDColumn}, false)
        Me.Relations.Add(Me.relationKeyBookIDRef)
    End Sub
    
    Private Function ShouldSerializeBooks() As Boolean
        Return false
    End Function
    
    Private Function ShouldSerializeBookReviews() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub BooksRowChangeEventHandler(ByVal sender As Object, ByVal e As BooksRowChangeEvent)
    
    Public Delegate Sub BookReviewsRowChangeEventHandler(ByVal sender As Object, ByVal e As BookReviewsRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BooksDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnBookID As DataColumn
        
        Private columnTitle As DataColumn
        
        Private columnPublisher As DataColumn
        
        Friend Sub New()
            MyBase.New("Books")
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
        
        Friend ReadOnly Property BookIDColumn As DataColumn
            Get
                Return Me.columnBookID
            End Get
        End Property
        
        Friend ReadOnly Property TitleColumn As DataColumn
            Get
                Return Me.columnTitle
            End Get
        End Property
        
        Friend ReadOnly Property PublisherColumn As DataColumn
            Get
                Return Me.columnPublisher
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As BooksRow
            Get
                Return CType(Me.Rows(index),BooksRow)
            End Get
        End Property
        
        Public Event BooksRowChanged As BooksRowChangeEventHandler
        
        Public Event BooksRowChanging As BooksRowChangeEventHandler
        
        Public Event BooksRowDeleted As BooksRowChangeEventHandler
        
        Public Event BooksRowDeleting As BooksRowChangeEventHandler
        
        Public Overloads Sub AddBooksRow(ByVal row As BooksRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddBooksRow(ByVal BookID As Long, ByVal Title As String, ByVal Publisher As String) As BooksRow
            Dim rowBooksRow As BooksRow = CType(Me.NewRow,BooksRow)
            rowBooksRow.ItemArray = New Object() {BookID, Title, Publisher}
            Me.Rows.Add(rowBooksRow)
            Return rowBooksRow
        End Function
        
        Public Function FindByBookID(ByVal BookID As Long) As BooksRow
            Return CType(Me.Rows.Find(New Object() {BookID}),BooksRow)
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As BooksDataTable = CType(MyBase.Clone,BooksDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New BooksDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnBookID = Me.Columns("BookID")
            Me.columnTitle = Me.Columns("Title")
            Me.columnPublisher = Me.Columns("Publisher")
        End Sub
        
        Private Sub InitClass()
            Me.columnBookID = New DataColumn("BookID", GetType(System.Int64), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnBookID)
            Me.columnTitle = New DataColumn("Title", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnTitle)
            Me.columnPublisher = New DataColumn("Publisher", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnPublisher)
            Me.Constraints.Add(New UniqueConstraint("KeyBookID", New DataColumn() {Me.columnBookID}, true))
            Me.columnBookID.AllowDBNull = false
            Me.columnBookID.Unique = true
        End Sub
        
        Public Function NewBooksRow() As BooksRow
            Return CType(Me.NewRow,BooksRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New BooksRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(BooksRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.BooksRowChangedEvent) Is Nothing) Then
                RaiseEvent BooksRowChanged(Me, New BooksRowChangeEvent(CType(e.Row,BooksRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.BooksRowChangingEvent) Is Nothing) Then
                RaiseEvent BooksRowChanging(Me, New BooksRowChangeEvent(CType(e.Row,BooksRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.BooksRowDeletedEvent) Is Nothing) Then
                RaiseEvent BooksRowDeleted(Me, New BooksRowChangeEvent(CType(e.Row,BooksRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.BooksRowDeletingEvent) Is Nothing) Then
                RaiseEvent BooksRowDeleting(Me, New BooksRowChangeEvent(CType(e.Row,BooksRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveBooksRow(ByVal row As BooksRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BooksRow
        Inherits DataRow
        
        Private tableBooks As BooksDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableBooks = CType(Me.Table,BooksDataTable)
        End Sub
        
        Public Property BookID As Long
            Get
                Return CType(Me(Me.tableBooks.BookIDColumn),Long)
            End Get
            Set
                Me(Me.tableBooks.BookIDColumn) = value
            End Set
        End Property
        
        Public Property Title As String
            Get
                Try 
                    Return CType(Me(Me.tableBooks.TitleColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBooks.TitleColumn) = value
            End Set
        End Property
        
        Public Property Publisher As String
            Get
                Try 
                    Return CType(Me(Me.tableBooks.PublisherColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBooks.PublisherColumn) = value
            End Set
        End Property
        
        Public Function IsTitleNull() As Boolean
            Return Me.IsNull(Me.tableBooks.TitleColumn)
        End Function
        
        Public Sub SetTitleNull()
            Me(Me.tableBooks.TitleColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsPublisherNull() As Boolean
            Return Me.IsNull(Me.tableBooks.PublisherColumn)
        End Function
        
        Public Sub SetPublisherNull()
            Me(Me.tableBooks.PublisherColumn) = System.Convert.DBNull
        End Sub
        
        Public Function GetBookReviewsRows() As BookReviewsRow()
            Return CType(Me.GetChildRows(Me.Table.ChildRelations("KeyBookIDRef")),BookReviewsRow())
        End Function
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BooksRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As BooksRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As BooksRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As BooksRow
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
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BookReviewsDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnBookID As DataColumn
        
        Private columnRating As DataColumn
        
        Private columnReview As DataColumn
        
        Friend Sub New()
            MyBase.New("BookReviews")
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
        
        Friend ReadOnly Property BookIDColumn As DataColumn
            Get
                Return Me.columnBookID
            End Get
        End Property
        
        Friend ReadOnly Property RatingColumn As DataColumn
            Get
                Return Me.columnRating
            End Get
        End Property
        
        Friend ReadOnly Property ReviewColumn As DataColumn
            Get
                Return Me.columnReview
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As BookReviewsRow
            Get
                Return CType(Me.Rows(index),BookReviewsRow)
            End Get
        End Property
        
        Public Event BookReviewsRowChanged As BookReviewsRowChangeEventHandler
        
        Public Event BookReviewsRowChanging As BookReviewsRowChangeEventHandler
        
        Public Event BookReviewsRowDeleted As BookReviewsRowChangeEventHandler
        
        Public Event BookReviewsRowDeleting As BookReviewsRowChangeEventHandler
        
        Public Overloads Sub AddBookReviewsRow(ByVal row As BookReviewsRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddBookReviewsRow(ByVal parentBooksRowByKeyBookIDRef As BooksRow, ByVal Rating As Long, ByVal Review As String) As BookReviewsRow
            Dim rowBookReviewsRow As BookReviewsRow = CType(Me.NewRow,BookReviewsRow)
            rowBookReviewsRow.ItemArray = New Object() {parentBooksRowByKeyBookIDRef(0), Rating, Review}
            Me.Rows.Add(rowBookReviewsRow)
            Return rowBookReviewsRow
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As BookReviewsDataTable = CType(MyBase.Clone,BookReviewsDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New BookReviewsDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnBookID = Me.Columns("BookID")
            Me.columnRating = Me.Columns("Rating")
            Me.columnReview = Me.Columns("Review")
        End Sub
        
        Private Sub InitClass()
            Me.columnBookID = New DataColumn("BookID", GetType(System.Int64), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnBookID)
            Me.columnRating = New DataColumn("Rating", GetType(System.Int64), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnRating)
            Me.columnReview = New DataColumn("Review", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnReview)
        End Sub
        
        Public Function NewBookReviewsRow() As BookReviewsRow
            Return CType(Me.NewRow,BookReviewsRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New BookReviewsRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(BookReviewsRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.BookReviewsRowChangedEvent) Is Nothing) Then
                RaiseEvent BookReviewsRowChanged(Me, New BookReviewsRowChangeEvent(CType(e.Row,BookReviewsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.BookReviewsRowChangingEvent) Is Nothing) Then
                RaiseEvent BookReviewsRowChanging(Me, New BookReviewsRowChangeEvent(CType(e.Row,BookReviewsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.BookReviewsRowDeletedEvent) Is Nothing) Then
                RaiseEvent BookReviewsRowDeleted(Me, New BookReviewsRowChangeEvent(CType(e.Row,BookReviewsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.BookReviewsRowDeletingEvent) Is Nothing) Then
                RaiseEvent BookReviewsRowDeleting(Me, New BookReviewsRowChangeEvent(CType(e.Row,BookReviewsRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveBookReviewsRow(ByVal row As BookReviewsRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BookReviewsRow
        Inherits DataRow
        
        Private tableBookReviews As BookReviewsDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableBookReviews = CType(Me.Table,BookReviewsDataTable)
        End Sub
        
        Public Property BookID As Long
            Get
                Try 
                    Return CType(Me(Me.tableBookReviews.BookIDColumn),Long)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBookReviews.BookIDColumn) = value
            End Set
        End Property
        
        Public Property Rating As Long
            Get
                Try 
                    Return CType(Me(Me.tableBookReviews.RatingColumn),Long)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBookReviews.RatingColumn) = value
            End Set
        End Property
        
        Public Property Review As String
            Get
                Try 
                    Return CType(Me(Me.tableBookReviews.ReviewColumn),String)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBookReviews.ReviewColumn) = value
            End Set
        End Property
        
        Public Property BooksRow As BooksRow
            Get
                Return CType(Me.GetParentRow(Me.Table.ParentRelations("KeyBookIDRef")),BooksRow)
            End Get
            Set
                Me.SetParentRow(value, Me.Table.ParentRelations("KeyBookIDRef"))
            End Set
        End Property
        
        Public Function IsBookIDNull() As Boolean
            Return Me.IsNull(Me.tableBookReviews.BookIDColumn)
        End Function
        
        Public Sub SetBookIDNull()
            Me(Me.tableBookReviews.BookIDColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsRatingNull() As Boolean
            Return Me.IsNull(Me.tableBookReviews.RatingColumn)
        End Function
        
        Public Sub SetRatingNull()
            Me(Me.tableBookReviews.RatingColumn) = System.Convert.DBNull
        End Sub
        
        Public Function IsReviewNull() As Boolean
            Return Me.IsNull(Me.tableBookReviews.ReviewColumn)
        End Function
        
        Public Sub SetReviewNull()
            Me(Me.tableBookReviews.ReviewColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class BookReviewsRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As BookReviewsRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As BookReviewsRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As BookReviewsRow
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
