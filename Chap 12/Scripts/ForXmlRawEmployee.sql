USE Northwind
GO
SELECT FirstName, LastName, Photo 
FROM Employees 
ORDER BY LastName, FirstName
FOR XML RAW, BINARY BASE64