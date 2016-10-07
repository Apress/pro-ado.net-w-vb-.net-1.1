USE Northwind
GO
SELECT Region.RegionID, TerritoryID
FROM Region, Territories 
WHERE Region.RegionID = Territories.RegionID
ORDER BY TerritoryID
FOR XML RAW
