USE FamilyDB
GO
IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE ID = OBJECT_ID(N'[dbo].[ForXMLExplicitDemo]') AND 
                 OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[ForXMLExplicitDemo]

GO
CREATE PROC ForXMLExplicitDemo
AS
SELECT 1 AS Tag,
       0 AS Parent,
       GrandParentID AS [GParent!1!],
       GrandParentName AS [GParent!1!OrderByGrandParentName!hide], 
       RTRIM(GrandParentName) AS [GParent!1!GParentName], 
       Diary AS [GParent!1!!xmltext],
       0 AS [Son!2!SonID],
       '' AS [Son!2!OrderBySonName!hide],
       '' AS [Son!2!SonName],
       '' AS [Son!2!!CDATA], -- PermanentRecord
       0 AS [Daughter!3!DaughterID!element],
       '' AS [Daughter!3!OrderByDaughterName!hide],
       '' AS [Daughter!3!DaughterName!element],
       '' AS [Daughter!3!SomeData!element],
       0 AS [GrandKid!4!ChildOfSonID!element],
       '' AS [GrandKid!4!OrderByChildOfSonName!hide],
       '' AS [GrandKid!4!ChildOfSonName!element],
       '' AS [GrandKid!4!GrandKidData!xml]

FROM GrandParent

UNION ALL

SELECT 2 AS Tag,
       1 AS Parent,
       0, -- GrandParent.GrandParentID
       G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide], 
       '', -- GrandParent.Name
       '', -- GrandParent.Diary
       SonID,
       RTRIM(SonName),
       RTRIM(SonName),
       PermanentRecord,
       0, -- Daughter.DaughterID
       '', -- Daughter.OrderByDaughterName
       '', -- Daughter.DaughterName
       '', -- Daughter.SomeData,
       0, -- ChildOfSon.ChildOfOnID,
       '', -- ChildOfSon.OrderByChildOfSonName 
       '', -- ChildOfSon.ChildOfSonName 
       '' -- ChildOfSon.GrandKidData
FROM GrandParent AS G, Son AS S
WHERE G.GrandParentID=S.GrandParentID

UNION ALL

SELECT 3 AS Tag,
       1 AS Parent,
       0, -- GrandParent.GrandParentID
       G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide], 
       '', -- GrandParent.Name
       '', -- GrandParent.Diary
       0, -- Son.SonID
       '', -- Son.SonName (hidden)
       '', -- Son.SonName
       '', -- Son.PermentRecord
       DaughterID,
       RTRIM(DaughterName),
       RTRIM(DaughterName),
       SomeData,
       0, -- ChildOfSon.ChildOfOnID,
       '', -- ChildOfSon.OrderByChildOfSonName 
       '', -- ChildOfSon.ChildOfSonName 
       '' -- ChildOfSon.GrandKidData

FROM GrandParent AS G, Daughter AS D
WHERE G.GrandParentID=D.GrandParentID

UNION ALL

SELECT 4 AS Tag,
       2 AS Parent,
       0, -- GrandParent.GrandParentID
       G.GrandParentName AS [GParent!1!OrderByGrandParentName!hide], 
       '', -- GrandParent.Name
       '', -- GrandParent.Diary       
       0, -- Son.SonID
       RTRIM(S.SonName),
       '', -- Son.SonName
       '', -- Son.PermentRecord
       0, -- Daughter.DaughterID
       '', -- Daughter.OrderByDaughterName
       '', -- Daughter.DaughterName
       '', -- Daughter.SomeData,
       CS.ChildOfSonID,
       RTRIM(CS.ChildOfSonName),
       RTRIM(CS.ChildOfSonName),
       CS.GrandKidData

FROM GrandParent AS G, Son AS S, ChildOfSon AS CS
WHERE G.GrandParentID=S.GrandParentID AND 
      S.SonID=CS.SonID

ORDER BY [GParent!1!OrderByGrandParentName!hide], 
         [Son!2!OrderBySonName!hide],
         [Daughter!3!OrderByDaughterName!hide],
         [GrandKid!4!OrderByChildOfSonName!hide]

FOR XML EXPLICIT
