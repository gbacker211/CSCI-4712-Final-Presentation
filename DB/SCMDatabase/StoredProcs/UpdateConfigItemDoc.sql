USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_ConfigItemDOC]    Script Date: 3/28/2016 1:19:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date:  2-29-2016
-- Description:	Update ConfigItemDoc
-- =============================================
ALTER PROCEDURE [dbo].[usp_Update_ConfigItemDOC]
	-- Add the parameters for the stored procedure here
	@ConfigItemDOC_ID INT,
	@Name VARCHAR(25),
	@Revision VARCHAR(25),
	@Date VARCHAR(25),
	@Description TEXT,
	@Location VARCHAR(25),
	@SoftwareID INT =0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

	DECLARE @ReturnValue INT

    IF(@SoftwareID = 0)
	BEGIN
	UPDATE ConfigItemDoc
	SET Name = @Name, Revision = @Revision, Date = @Date, Description= @Description, Location = @Location
	WHERE ConfigItemDoc.CID_ID = @ConfigItemDOC_ID
	END
	ELSE
	BEGIN
	   DECLARE @CI INT 

	   --Get the most recent configuration item by the software id
	   SET @CI = (SELECT TOP 1 CI.CI_ID FROM ConfigItem CI WHERE CI.SoftwareID = @SoftwareID ORDER BY CI.CI_ID DESC)

	  
	  EXEC usp_Insert_NewConfigItemDOC @CI, @Name, @Revision, @Date, @Description, @Location
	END

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
