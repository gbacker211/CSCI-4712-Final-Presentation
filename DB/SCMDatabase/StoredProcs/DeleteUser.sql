USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_User]    Script Date: 3/28/2016 1:23:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2016
-- Description:	Delete User
-- =============================================
ALTER PROCEDURE [dbo].[usp_Delete_User]
	@User_Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

	DECLARE @ReturnValue INT

	DELETE AccessUser
	WHERE AccessUser.User_Id = @User_Id

	IF @@ERROR <> 0
	BEGIN
	  SET @ReturnValue = -1
	END
	ELSE 
	BEGIN
	  SET @ReturnValue = 0
	END

	SELECT @ReturnValue
END
