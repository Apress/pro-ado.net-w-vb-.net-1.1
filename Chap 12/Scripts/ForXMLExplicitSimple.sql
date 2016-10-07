
SELECT 1 AS Tag,
       0 AS Parent,
       RegionID AS [Region!1!RegionIDAsAttrbute], 
       RegionID AS [Region!1!RegionIDAsElement!element]
FROM Region
FOR XML EXPLICIT
