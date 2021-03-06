USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_Software]    Script Date: 3/28/2016 1:23:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2016
-- Description:	Delete Software
-- Note: Should delete all child information
-- =============================================
ALTER PROCEDURE [dbo].[usp_Delete_Software]
	@SoftwareId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DECLARE @ReturnValue INT

	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DELETE FROM Software 
	WHERE SoftwareID = @SoftwareId

	DELETE FROM UserGroup
	WHERE SoftwareID = @SoftwareId


	DECLARE @SoftwareDOCID INT
	SET @SoftwareDOCID = (SELECT SD.SoftwareDocID FROM SoftwareDoc SD WHERE SD.Software_Id = @SoftwareId)

	EXEC usp_Delete_SoftwareDOC @SoftwareDOCID


	DECLARE @ConfigItemID INT
	SET @ConfigItemID = (SELECT CI.CI_ID FROM ConfigItem CI WHERE CI.SoftwareID = @SoftwareId)

	DECLARE @ConfigItemDOCID INT
	SET @ConfigItemDOCID = (SELECT ConfigItemDoc.CID_ID FROM ConfigItemDoc WHERE CI = @ConfigItemID)

	EXEC usp_Delete_ConfigItem @ConfigItemID

	EXEC usp_Delete_ConfigItemDoc @ConfigItemDOCID


	
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
