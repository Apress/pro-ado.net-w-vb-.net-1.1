Imports System
Imports System.Data
Imports System.Text.RegularExpressions

Public Class USPhoneNumberConstraint

    ' The column we are interested in
    Private m_constrainedColumn As DataColumn

    ' The name of our constraint
    Private m_constraintName As String

    ' A test to see if the constraint is currently violated
    Private IsViolated As Boolean

    ' A static definition of the regular expression that defines
    ' the format required for a value to meet this constraint
    Private Const comparisonValue As String = "\d{3} \d{3}-\d{4}"

    ' Checks to see if the constraint and the data table are in
    ' a state in which the constraint can be successfully applied
    Private Function CanApplyConstraint() As Boolean

        ' If the column or table are null, then return False. Otherwise, check.
        If Not m_constrainedColumn Is Nothing And _
           Not m_constrainedColumn.Table Is Nothing Then

            ' Try to check the existing values.
            ' If this throws an exception, return False. Otherwise, return True.
            Try
                CheckExistingValues()
            Catch e As InvalidConstraintException
                Return False
            End Try

            Return True
        Else
            Return False
        End If
    End Function

    ' Identifies whether the constraint is currently violated
    Public Function IsConstraintViolated() As Boolean
        Return IsViolated
    End Function

    Public Sub New()
    End Sub

    Public Sub New(ByVal constrainedColumn As DataColumn)
        Me.new("USPhoneNumberConstraint", constrainedColumn)
    End Sub

    Public Sub New(ByVal constraintName As String, _
                   ByVal constrainedColumn As DataColumn)

        ' Make sure the column isn't null
        If constrainedColumn Is Nothing Then
            Throw New InvalidConstraintException( _
                   "Constraints cannot be applied to DataColumns with Null value")
        End If

        ' Make sure our column is in a table
        If constrainedColumn.Table Is Nothing Then
            Throw New InvalidConstraintException( _
                   "US Phone Number constraint can only be " & _
                   "applied to columns that are in a table.")
        End If

        ' Set our local variable to the passed in column
        m_constrainedColumn = constrainedColumn

        ' Set the constraint name
        m_constraintName = constraintName

        ' Make sure the existing values meet the criteria
        CheckExistingValues()

        ' Hook up to the DataColumn's ColumnChanged event if we have a valid column
        If Not constrainedColumn Is Nothing Then
            AddHandler constrainedColumn.Table.ColumnChanged, _
                       AddressOf DataColumn_OnChange
        End If
    End Sub

    ' Checks the values in the data table associated with the constrained
    ' column and throws an exception if they don't all meet the criteria
    Private Sub CheckExistingValues()

        Dim row As DataRow
        For Each row In m_constrainedColumn.Table.Rows
            If Regex.IsMatch( _
                   row(m_constrainedColumn, DataRowVersion.Current).ToString(), _
                                                      comparisonValue) = False Then

                ' Nullify the column so we don't use this constraint
                m_constrainedColumn = Nothing
                Throw New InvalidConstraintException( _
                     "The existing values in the data table " & _
                     "do not meet the US Phone Number constraint.")
            End If
        Next
    End Sub

    ' Check any values that occur when data column we are constraining is changed
    Public Sub DataColumn_OnChange(ByVal sender As Object, _
                                   ByVal eArgs As DataColumnChangeEventArgs)

        ' Check to see that it is the column we are interested in,
        ' and that constraints are being enforced for the DataSet
        If eArgs.Column Is m_constrainedColumn And _
               m_constrainedColumn.Table.DataSet.EnforceConstraints = True Then

            ' If it is the constrained column, check the value
            If Regex.IsMatch( _
                 eArgs.Row(m_constrainedColumn, DataRowVersion.Proposed).ToString(), _
                                                      comparisonValue) = False Then

                ' If no match found, indicate violated constraint and throw exception
                IsViolated = True
                eArgs.Row(m_constrainedColumn) = _
                               eArgs.Row(m_constrainedColumn, DataRowVersion.Original)
                Throw New ConstraintException( _
                     "The value in column " & m_constrainedColumn.ColumnName & _
                     " violates the US Phone Number Constraint.")
            End If
        End If
    End Sub

    ' Public accessor for the constraint name
    Public Property ConstraintName() As String
        Get
            Return m_constraintName
        End Get
        Set(ByVal Value As String)
            m_constraintName = Value
        End Set
    End Property

    ' Public read-only accessor for the data table of the constrained column
    Public ReadOnly Property Table() As DataTable
        Get
            If Not m_constrainedColumn Is Nothing Then
                Return m_constrainedColumn.Table
            Else
                Return Nothing
            End If
        End Get
    End Property

    ' Property for access to the data column to be constrained
    ' Allows for setting the column after the constraint has been created
    Public Property Column() As DataColumn
        Get
            Return m_constrainedColumn
        End Get
        Set(ByVal Value As DataColumn)

            ' If the column is a new column then check constraint for the new column
            If Not Value Is m_constrainedColumn Then
                m_constrainedColumn = Value
                CheckExistingValues()
            End If
        End Set
    End Property
End Class