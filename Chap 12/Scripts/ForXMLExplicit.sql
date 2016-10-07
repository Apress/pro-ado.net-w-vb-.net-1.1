-- Drop from bottom to top of hierarchy.  This insures that
-- the child FOREIGN KEY to parent's primary key references
-- are cleaned up so the parent can then be dropped
IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE id = OBJECT_ID(N'[dbo].[ChildOfSon]') AND 
                 OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[ChildOfSon]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE id = OBJECT_ID(N'[dbo].[Daughter]') AND 
                 OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[Daughter]
GO
IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE id = OBJECT_ID(N'[dbo].[Son]') AND 
                 OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[Son]
GO 
IF EXISTS (SELECT * FROM dbo.sysobjects 
           WHERE id = OBJECT_ID(N'[dbo].[GrandParent]') AND 
                 OBJECTPROPERTY(id, N'IsUserTable') = 1)
    DROP TABLE [dbo].[GrandParent]
GO
CREATE TABLE [dbo].[GrandParent] (
    [GrandParentID] [INT] PRIMARY KEY ,
    [GrandParentName] [NCHAR] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
    [Diary] [NVARCHAR](3000)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Son] (
    [SonID] [INT] PRIMARY KEY ,
    [GrandParentID] [INT] NOT NULL 
        REFERENCES GrandParent(GrandParentID),
    [SonName] [NCHAR] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
    [PermanentRecord]  [NVARCHAR](3000)
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Daughter] (
    [DaughterID] [INT] PRIMARY KEY ,
    [GrandParentID] [INT] NOT NULL 
        REFERENCES GrandParent(GrandParentID),
    [DaughterName] [NCHAR] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
    [SomeData]  [NVARCHAR](3000)
) ON [PRIMARY]
GO
GO
CREATE TABLE [dbo].[ChildOfSon] (
    [ChildOfSonID] [INT] PRIMARY KEY ,
    [SonID] [INT] NOT NULL 
        REFERENCES Son(SonID),
    [ChildOfSonName] [NCHAR] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL, 
    [GrandKidData]  [NVARCHAR](3000)
) ON [PRIMARY]
GO 
INSERT INTO GrandParent (GrandParentID, GrandParentName, Diary)
VALUES (1, 'Jeb', '<Book><Chapter> ChapNum="1" Body="They call me Ishmael"</Chapter><Chapter> ChapNum="2" Body="Whale sinks"</Chapter></Book>')
GO 
INSERT INTO GrandParent (GrandParentID, GrandParentName, Diary)
VALUES (2, 'Olivia', '<Book><Chapter> ChapNum="1" Body="It was the best of times"</Chapter><Chapter> ChapNum="2" Body="If is a far, far"</Chapter></Book>')
GO 
INSERT INTO GrandParent (GrandParentID, GrandParentName, Diary)
VALUES (3, 'Rex', '<Book><Chapter> ChapNum="1" Body="Dad takes over spice world"</Chapter><Chapter> ChapNum="2" Body="Revenge"</Chapter></Book>')
GO 
INSERT INTO Son (SonID, GrandParentID, SonName, PermanentRecord)
VALUES (1, 2, 'Luke', '<Book><Chapter> ChapNum="1" Body="A new hope"</Chapter><Chapter> ChapNum="2" Body="Exploding Death Star"</Chapter></Book>')
GO 
INSERT INTO Son (SonID, GrandParentID, SonName, PermanentRecord)
VALUES (2, 2, 'Darth', '<Book><Chapter> ChapNum="1" Body="Bye, Bye ice planet"</Chapter><Chapter> ChapNum="2" Body="Luke, you are my son"</Chapter></Book>')
GO 
INSERT INTO Son (SonID, GrandParentID, SonName, PermanentRecord)
VALUES (3, 1, 'Han', '<Book><Chapter> ChapNum="1" Body="Bye, Bye Yoda"</Chapter><Chapter> ChapNum="2" Body="Yet another Death Star, boom boom"</Chapter></Book>')
GO
INSERT INTO Daughter (DaughterID, GrandParentID, DaughterName, SomeData)
VALUES (1, 1, 'Sade', 'abcd<>''')
GO 
INSERT INTO Daughter (DaughterID, GrandParentID, DaughterName, SomeData)
VALUES (2, 2, 'Avril', 'efg><''''&&&"...')
GO 
INSERT INTO Daughter (DaughterID, GrandParentID, DaughterName, SomeData)
VALUES (3, 2, 'Sonya', '<><><><><>')
GO 
INSERT INTO ChildOfSon (ChildOfSonID, SonID, ChildOfSonName, GrandKidData)
VALUES (1, 1, 'Jasmine', '%%%%%%%%%%')
GO 
INSERT INTO ChildOfSon (ChildOfSonID, SonID, ChildOfSonName, GrandKidData)
VALUES (2, 1, 'Sophia', '"/?%#')
GO 
INSERT INTO ChildOfSon (ChildOfSonID, SonID, ChildOfSonName, GrandKidData)
VALUES (3, 3, 'Kyle', '?????"""???')


