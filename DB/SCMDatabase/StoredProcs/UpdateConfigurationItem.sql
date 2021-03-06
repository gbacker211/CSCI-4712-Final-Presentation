USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_ConfigItem]    Script Date: 3/27/2016 5:02:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2016
-- Description:	Update Configuration Item
-- =============================================
ALTER PROCEDURE [dbo].[usp_Update_ConfigItem]
	-- Add the parameters for the stored procedure here
	@ConfigItem_Id INT,
	@Name VARCHAR(25),
	@Revision VARCHAR(25),
	@Date VARCHAR(25),
	@Description TEXT,
	@Location VARCHAR(25),
	@SoftwareID INT = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DECLARE @ReturnValue INT




		IF(@SoftwareID = 0)
			BEGIN

	UPDATE ConfigItem
	SET ConfigItem.Name = @Name,
	    ConfigItem.Revision = @Revision,
		ConfigItem.Description = @Description,
		Date = @Date,
		Location = @Location
	WHERE ConfigItem.CI_ID = @ConfigItem_Id
	END
		ELSE
		  BEGIN
	  EXEC usp_Insert_NewConfigItem @SoftwareID, @Name, @Revision, @Date, @Description, @Location
	 
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