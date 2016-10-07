IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[RegionInsert]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RegionInsert]

IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[RegionUpdate]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RegionUpdate]

IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[RegionDelete]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[RegionDelete]

GO
-- XML Document is of the form
-- <Top>
--   <Region> region elements here </Region>
--   <Region> region elements here </Region>
--   ...
-- </Top>
CREATE PROCEDURE RegionInsert @xmlDoc NVARCHAR(4000) AS
DECLARE @docIndex INT
EXECUTE sp_xml_preparedocument @docIndex OUTPUT, @xmlDoc

-- 1 is ATTRIBUTE-centric mapping
INSERT Region 
SELECT RegionID, RegionDescription 
FROM OPENXML(@docIndex, N'/Top/Region', 1) WITH Region

EXECUTE sp_xml_removedocument @docIndex

GO

CREATE PROCEDURE RegionUpdate @xmlDoc NVARCHAR(4000) AS

  DECLARE @docIndex INT

  EXECUTE sp_xml_preparedocument @docIndex OUTPUT, @xmlDoc
  
  UPDATE Region 
    SET Region.RegionDescription = XMLRegion.RegionDescription 
  FROM OPENXML(@docIndex, N'/Top/Region',1) WITH Region AS XMLRegion
  WHERE Region.RegionID = XMLRegion.RegionID
  
  EXECUTE sp_xml_removedocument @docIndex

GO

CREATE PROCEDURE RegionDelete @xmlDoc NVARCHAR(4000) AS
  DECLARE @docIndex INT

  EXECUTE sp_xml_preparedocument @docIndex OUTPUT, @xmlDoc
  
  DELETE Region
  FROM OPENXML(@docIndex, N'/Top/Region', 1) WITH Region AS XMLRegion
  WHERE Region.RegionID=XMLRegion.RegionID
  
  EXECUTE sp_xml_removedocument @docIndex
