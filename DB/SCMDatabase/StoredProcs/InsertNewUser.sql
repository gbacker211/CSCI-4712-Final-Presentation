USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_NewUser]    Script Date: 3/28/2016 1:21:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-24-2016
-- Description:	Insert new User
-- =============================================
ALTER PROCEDURE [dbo].[usp_Insert_NewUser]
(
	-- Add the parameters for the stored procedure here
	@UserName VARCHAR(10),
	@Password VARCHAR(10),
	@FirstName VARCHAR(10),
	@LastName VARCHAR(10),
	@AccessGroup INT,
	@GroupName VARCHAR(25) 
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @ReturnValue INT

	SET NOCOUNT OFF;

	
	--If Group Exists Use that
	--Otherwise
	--CreateGroup
	--Group the ID from the recently created groupd

	--Check to see if Username is already used
	IF NOT EXISTS(SELECT UserName FROM AccessUser WHERE UserName = @UserName)
		BEGIN

	 DECLARE @GroupID INT
	IF NOT EXISTS(SELECT GroupName FROM Groups WHERE GroupName = @GroupName)
	BEGIN
	     INSERT INTO Groups(GroupName)
		 VALUES(@GroupName)

		-- ID = @GroupID
		 SET @GroupID = (SELECT ID FROM Groups WHERE GroupName = @GroupName)

		 INSERT INTO AccessUser(FirstName, LastName, UserName, Password, AccesGroup, GroupID)
		 VALUES(@FirstName, @LastName, @UserName, @Password, @AccessGroup, @GroupID)

	END
	ELSE
	BEGIN
	    
		 SET @GroupID = (SELECT ID FROM Groups WHERE GroupName = @GroupName)

		 INSERT INTO AccessUser(FirstName, LastName, UserName, Password, AccesGroup, GroupID)
		 VALUES(@FirstName, @LastName, @UserName, @Password, @AccessGroup, @GroupID)   
	   
	END

		IF @@ERROR <> 0
		BEGIN
		   SET @ReturnValue = -1
		END
	ELSE
		BEGIN
		   SET @ReturnValue = 0
		END

	
END
	ELSE
		BEGIN
			SET @ReturnValue = -1
		END

		  
SELECT @ReturnValue



END