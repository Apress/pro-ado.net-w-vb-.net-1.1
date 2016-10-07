CREATE PROCEDURE RegionInsert @xmlDoc VARCHAR(4000) AS
DECLARE @docIndex INT
EXECUTE sp_xml_preparedocument @docIndex OUTPUT, @xmlDoc
