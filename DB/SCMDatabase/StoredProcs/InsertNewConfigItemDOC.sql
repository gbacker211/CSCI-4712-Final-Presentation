USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_NewConfigItemDOC]    Script Date: 3/28/2016 1:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_Insert_NewConfigItemDOC]
-- Add the parameters for the stored procedure here
	 @CI INT,
	 @Name VARCHAR(25),
	 @Revision VARCHAR(25),
	 @Date VARCHAR(25),
	 @Description TEXT,
	 @Location VARCHAR(25)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
DECLARE @ReturnValue INT
DECLARE @CI_ID INT


   IF(@CI != 0)
   BEGIN
	SET NOCOUNT OFF;
	IF EXISTS(SELECT ConfigItem.CI_ID FROM ConfigItem WHERE ConfigItem.CI_ID = @CI)
	BEGIN
	      INSERT INTO ConfigItemDoc(CI, Name, Revision, Date, Description, Location)
		  VALUES(@CI, @Name, @Revision, @Date, @Description, @Location)

	END
	ELSE
		BEGIN
		  SET @ReturnValue = -1
		END
   END
   ELSE
   BEGIN
      --Get the most recent configitem
      SET @CI_ID = (SELECT TOP 1 ConfigItem.CI_ID FROM ConfigItem ORDER BY ConfigItem.CI_ID DESC)

	    INSERT INTO ConfigItemDoc(CI, Name, Revision, Date, Description, Location)
		  VALUES(@CI_ID, @Name, @Revision, @Date, @Description, @Location)


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
