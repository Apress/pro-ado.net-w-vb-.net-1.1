USE FamilyDB
GO

IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[GrandparentSon]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GrandparentSon]

GO
CREATE PROCEDURE GrandparentSon 
AS
-- SubQuery1 -- This sub-query retrieves the columns of 
-- interest from the GrandParent table
SELECT 1 As Tag,
       0 As Parent,
       GrandParentID AS [GrandParent!1!GrandParentID],
       0 AS [Son!2!SonID]
FROM GrandParent

UNION ALL

-- SubQuery2 -- This sub-query retrieves the columns of 
-- interest from the Son table
SELECT 2, -- Tag
       1, -- Parent=1, the grandparent is the parent
       0,
       SonID
FROM GrandParent G, Son S
WHERE g.GrandParentID=S.GrandParentID

FOR XML EXPLICIT
GO
EXEC GrandparentSon
