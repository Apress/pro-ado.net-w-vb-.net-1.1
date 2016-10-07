' The following is an illustration only and is not intended
' to be compiled. It is intended as a guideline and starting
' point for creating a data services component that provides
' proper separation of functionality for optimum performance

Imports System
Imports System.EnterpriseServices
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Imports MyApplication.Common

Namespace MyApplication.DAL
   ' Define read-only data service class for this particular
   ' entity.
   <Transaction(TransactionOption.NotSupported)> _
   Public Class MyObject
      Inherits DALObject

      Public Function Load(ByVal ID As Integer) As DataSet
         ' Load a single item from the database
      End Function
   End Class

   Namespace Transactional
      ' define write-access service class for this particular
      ' entity.
      <Transaction(TransactionOption.Supported)> _
      Public Class MyObject
         Inherits DALObject

         Public Function Create(...) As Integer
            ' use supplied arguments to create a new item in the DB.
         End Function

         Public Function Update(int ID, ...) As Integer
            ' use supplied arguments to update an item in the DB.
         End Function

         Public Function Delete(int ID, ...) As Integer
            ' use supplied arguments to delete an item in the DB.
         End Function
      End Class
   End Namespace
End Namespace