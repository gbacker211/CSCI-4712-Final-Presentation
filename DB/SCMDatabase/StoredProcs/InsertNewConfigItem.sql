USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Insert_NewConfigItem]    Script Date: 3/28/2016 1:23:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 02/24/2016
-- Description:	Insert new ConfigItem
-- =============================================
ALTER PROCEDURE [dbo].[usp_Insert_NewConfigItem]
	-- Add the parameters for the stored procedure here
	 @SoftwareID INT,
	 @Name VARCHAR(25),
	 @Revision VARCHAR(25),
	 @Date VARCHAR(25),
	 @Description TEXT,
	 @Location TEXT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
DECLARE @ReturnValue INT


IF NOT EXISTS(SELECT Name from ConfigItem WHERE Name = @Name)
  BEGIN

			SET NOCOUNT OFF;
			IF EXISTS(SELECT Software.SoftwareID FROM Software WHERE Software.SoftwareID = @SoftwareID)
			BEGIN
				  INSERT INTO ConfigItem(SoftwareID, Name, Revision, Date, Description, Location)
				  VALUES(@SoftwareID, @Name, @Revision, @Date, @Description, @Location)

			END
			ELSE
			BEGIN
			  SET @ReturnValue = -1
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
