USE SCMDatabase
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 3-16-2016
-- Description:	Select Users for edit user
-- =============================================
CREATE PROCEDURE usp_Select_UserForEditing 
	-- Add the parameters for the stored procedure here
	@UserId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT  AU.FirstName,
	        AU.LastName,
			AU.UserName,
			AU.Password,
			AU.AccesGroup
	FROM AccessUser AU
	WHERE AU.User_Id = @UserId
    -- Insert statements for procedure here
	
END
GO
