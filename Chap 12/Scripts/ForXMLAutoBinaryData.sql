USE Northwind
GO
SELECT EmployeeID, FirstName, LastName, Photo 
FROM Employees 
ORDER BY LastName, FirstName
FOR XML AUTO
