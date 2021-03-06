USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_ConfigItem]    Script Date: 3/28/2016 1:23:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2016
-- Description:	Delete Config Item, As well as the config item doc 
-- =============================================
ALTER PROCEDURE [dbo].[usp_Delete_ConfigItem]
	-- Add the parameters for the stored procedure here
	@ConfigItem_Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    DECLARE @ReturnValue INT
	DECLARE @ConfigItemDOCID INT

	SET @ConfigItemDOCID = (SELECT ConfigItemDoc.CID_ID FROM ConfigItemDoc WHERE CI = @ConfigItem_Id)

	DELETE ConfigItem 
	WHERE ConfigItem.CI_ID = @ConfigItem_Id




	EXEC dbo.usp_Delete_ConfigItemDoc  @ConfigItemDOCID

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
