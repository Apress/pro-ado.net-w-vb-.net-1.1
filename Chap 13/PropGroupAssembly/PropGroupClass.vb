Imports System
Imports System.Data
Imports System.EnterpriseServices
Imports System.Data.SqlClient

Public Class PropGroupClass
   Inherits ServicedComponent

   Public Function FetchCategoryList(ByRef FromCache As Boolean) As String
      Dim fExist As Boolean
      fExist = True
      Dim oLock As PropertyLockMode = PropertyLockMode.SetGet
      Dim oRel As PropertyReleaseMode = PropertyReleaseMode.Process
      Dim grpMan As SharedPropertyGroupManager = _
         New SharedPropertyGroupManager()
      Dim grpCache As SharedPropertyGroup = _
         grpMan.CreatePropertyGroup("CategoryCacheGroup", oLock, oRel, _
                                    fExist)
      Dim propCache As SharedProperty = _
         grpCache.CreateProperty("CategoryCache", fExist)
      If fExist Then
         FromCache = True
         Return CType(propCache.Value, String)
      Else
         FromCache = False
         Dim Connection As SqlConnection = New SqlConnection( _
            "Data Source=(local); Initial Catalog=Northwind; " _
            & "Integrated Security=SSPI;")
         Dim MyDA As SqlDataAdapter = New SqlDataAdapter( _
            "SELECT CategoryID, CategoryName, Description, Picture FROM " _
            & "Categories", Connection)
         Dim MyDS As DataSet = New DataSet()
         MyDA.Fill(MyDS, "Categories")
         propCache.Value = MyDS.GetXml()
         Connection.Close()
         MyDA.Dispose()
         Return CType(propCache.Value, String)
      End If
   End Function

End Class
