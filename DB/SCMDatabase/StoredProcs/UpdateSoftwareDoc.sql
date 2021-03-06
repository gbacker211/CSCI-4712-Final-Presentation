USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Update_SoftwareDoc]    Script Date: 3/31/2016 8:55:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer	
-- Create date: 2-29-2016
-- Description:	Update Software Doc
-- =============================================
ALTER PROCEDURE [dbo].[usp_Update_SoftwareDoc] 
	-- Add the parameters for the stored procedure here
	@SoftwareDOCID INT,
	@Name VARCHAR(25),
	@Revision VARCHAR(25),
	@Date VARCHAR(25),
	@Description TEXT,
	@Location TEXT,
	@SoftwareID INT = 0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;
	DECLARE @ReturnValue INT
    -- Insert statements for procedure here

	IF(@SoftwareID = 0)
	BEGIN

	UPDATE SoftwareDoc
	SET Name = @Name, Revision = @Revision, Date = @Date, Description = @Description, Location = @Location
	WHERE SoftwareDocID = @SoftwareDOCID

	END
	ELSE
	BEGIN
	  EXEC usp_Insert_NewSoftwareDOC @SoftwareID, @Name, @Revision, @Date, @Description, @Location
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
