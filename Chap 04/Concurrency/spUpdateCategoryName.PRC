SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUpdateCategoryName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUpdateCategoryName]
GO

CREATE PROCEDURE dbo.spUpdateCategoryName
(
	@CatID				int,
	@OriginalCatName	nvarchar(15),
	@NewCatName			nvarchar(15)
)
AS
	UPDATE Categories
	   SET CategoryName = @NewCatName
	 WHERE CategoryID = @CatID
	   AND CategoryName = @OriginalCatName

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

