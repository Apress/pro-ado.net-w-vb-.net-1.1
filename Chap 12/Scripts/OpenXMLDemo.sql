DECLARE @newRegions NVARCHAR(2048)
SET @newRegions = N'
<Top>
  <Region RegionID="11" RegionDescription="Uptown"/>
  <Region RegionID="22" RegionDescription="DownTown"/>
</Top>'

EXEC RegionInsert @newRegions
GO

DECLARE @newRegions NVARCHAR(2048)
SET @newRegions = N'
<Top>
  <Region RegionID="11" RegionDescription="UptownX"/>
  <Region RegionID="22" RegionDescription="DownTownX"/>
</Top>'

EXEC RegionUpdate @newRegions

GO

DECLARE @newRegions NVARCHAR(2048)
SET @newRegions = N'
<Top>
  <Region RegionID="11" RegionDescription="Uptown"/>
  <Region RegionID="22" RegionDescription="DownTown"/>
</Top>'

EXEC RegionDelete @newRegions
