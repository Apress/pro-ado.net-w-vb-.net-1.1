CREATE TABLE [dbo].[PageViews] (
	[HitDate] [datetime] NULL ,
	[TotalHits] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Unique] (
	[HitDate] [datetime] NOT NULL ,
	[TotalHits] [float] NOT NULL 
) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[HitsTotal] 
@todaysdate datetime
AS
DECLARE @TOTAL int
SET @TOTAL = (SELECT COUNT(*) FROM [PageViews] WHERE HitDate = @todaysdate)

IF @TOTAL > 0
	BEGIN
		UPDATE PageViews
			SET TotalHits = ((SELECT TotalHits FROM PageViews WHERE HitDate = @todaysdate) + 1)
			WHERE HitDate = @todaysdate
	END
ELSE
	BEGIN
		INSERT INTO PageViews
			(
				HitDate,
				TotalHits
			)
			VALUES
			(
				@todaysdate,
				1
			)
	END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[HitsUnique] 
@todaysdate datetime
AS
DECLARE @TOTAL int

SET @TOTAL = (SELECT COUNT(*) FROM [Unique] WHERE HitDate = @todaysdate)

IF   @TOTAL > 0
	BEGIN
		UPDATE [Unique]
			SET 
			TotalHits = 
          ((SELECT TotalHits FROM [Unique] WHERE HitDate = @todaysDate ) +1)
			WHERE HitDate = @todaysdate
	END
ELSE
	BEGIN
		INSERT INTO [Unique]
			(
				HitDate,
				TotalHits
			)
			VALUES
			(
				@todaysdate,
				1
			)
	END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO