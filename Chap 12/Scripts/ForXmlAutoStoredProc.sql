USE Northwind
GO

IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[RegionTerritory]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RegionTerritory]

GO
CREATE PROCEDURE RegionTerritory 
AS
SELECT R.RegionID, RTRIM(R.RegionDescription) AS RegionDesc, 
       T.TerritoryID, RTRIM(T.TerritoryDescription) AS TerritoryDesc
FROM Region AS R, Territories AS T 
WHERE R.RegionID = T.RegionID
ORDER BY R.RegionID, T.TerritoryID
FOR XML AUTO, XMLDATA;
GO
--EXEC RegionTerritory