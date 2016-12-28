SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[AspNetUsers_SearchUserByKeyTop10]', 'P') IS NOT NULL
DROP PROC [dbo].[AspNetUsers_SearchUserByKeyTop10] 
GO

CREATE PROCEDURE [dbo].[AspNetUsers_SearchUserByKeyTop10] 
	@Keyword nvarchar(256)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 10 * FROM dbo.AspNetUsers 
	WHERE dbo.AspNetUsers.Name LIKE '%'+@Keyword+'%'
	OR dbo.AspNetUsers.UserName LIKE '%'+@Keyword+'%'
END
