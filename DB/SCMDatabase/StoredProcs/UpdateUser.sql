USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_User]    Script Date: 4/25/2016 11:37:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2016
-- Description:	Update User
-- =============================================
ALTER PROCEDURE [dbo].[usp_Update_User]
	-- Add the parameters for the stored procedure here
	@UserID INT,
	--@UserName VARCHAR(25),
	@Password VARCHAR(25),
	@AccessGroup INT,
	@FirstName VARCHAR(25),
	@LastName VARCHAR(25),
	@GroupID INT = 0,
	@GroupName VARCHAR(25) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

	DECLARE @ReturnValue INT




	

	IF(@GroupID <> 0)
	BEGIN

	 IF(@Password <> '')
	 BEGIN
		UPDATE AccessUser
		SET Password = @Password, AccesGroup = @AccessGroup, FirstName = @FirstName, LastName = @LastName , GroupID = @GroupID
		WHERE User_Id = @UserID
	 END
	 ELSE
	 BEGIN
	   UPDATE AccessUser
		SET  AccesGroup = @AccessGroup, FirstName = @FirstName, LastName = @LastName , GroupID = @GroupID
		WHERE User_Id = @UserID
	 END
	END
	ELSE
	BEGIN
	      DECLARE @NewGroupID INT
	    
	    IF NOT EXISTS(SELECT GroupName FROM Groups WHERE GroupName = @GroupName)
			BEGIN
		       INSERT INTO Groups(GroupName)
		       VALUES(@GroupName)

		-- ID = @GroupID
		 SET @NewGroupID = (SELECT ID FROM Groups WHERE GroupName = @GroupName)

		    UPDATE AccessUser
	        SET  Password = @Password, AccesGroup = @AccessGroup, FirstName = @FirstName, LastName = @LastName , GroupID = @NewGroupID
	        WHERE User_Id = @UserID


			 IF(@Password <> '')
			 BEGIN
				 UPDATE AccessUser
	             SET  Password = @Password, AccesGroup = @AccessGroup, FirstName = @FirstName, LastName = @LastName , GroupID = @NewGroupID
	             WHERE User_Id = @UserID
			 END
			 ELSE
				 BEGIN
				   UPDATE AccessUser
	              SET  AccesGroup = @AccessGroup, FirstName = @FirstName, LastName = @LastName , GroupID = @NewGroupID
	              WHERE User_Id = @UserID
				 END

		END
		ELSE
			BEGIN
			 SET @ReturnValue =  -1

		END
	  
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




   SELECT @ReturnValue


