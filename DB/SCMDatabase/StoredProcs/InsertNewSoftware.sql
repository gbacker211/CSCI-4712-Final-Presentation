USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_NewSoftware]    Script Date: 3/28/2016 1:22:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 02/24/2016
-- Description:	Insert new Software
-- =============================================
ALTER PROCEDURE [dbo].[usp_Insert_NewSoftware]
	-- Add the parameters for the stored procedure here
	@SoftwareName VARCHAR(25),
	@Description TEXT,
	@Classification CHAR(2),
	@SystemName VARCHAR(25),
	@Engineer VARCHAR(25),
	@Owner VARCHAR(25),
	@DesignAuthority VARCHAR(25),
	@GroupID INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @ReturnValue INT


	IF NOT EXISTS(SELECT Name FROM Software WHERE Software.Name = @SoftwareName)
	BEGIN

	SET NOCOUNT OFF;
    INSERT INTO dbo.Software(Name, Description, Classification, SystemName, Engineer, Owner, DesignAuthority)
	VALUES(@SoftwareName, @Description, @Classification, @SystemName, @Engineer, @Owner, @DesignAuthority)


	
	DECLARE @SoftwareID INT
	--DECLARE @GroupID INT

	SET @SoftwareID = (SELECT TOP 1 SoftwareID  FROM Software ORDER BY SoftwareID DESC)
	

		   
	  INSERT INTO UserGroup(SoftwareID, GroupId)
	  VALUES(@SoftwareID, @GroupID)


	
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

    -- Insert statements for procedure here

END
