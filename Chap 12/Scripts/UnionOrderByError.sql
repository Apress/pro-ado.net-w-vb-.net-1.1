SELECT G.GrandParentID, 0
FROM GrandParent G, Son S

UNION ALL

SELECT 0, SonID
FROM Son AS S, GrandParent G
WHERE S.GrandParentID = G.GrandParentID

ORDER BY G.GrandParentID, S.SonID
