USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Delete_SoftwareDOC]    Script Date: 3/28/2016 1:23:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-29-2015
-- Description:	Delete Software DOC
-- =============================================
ALTER PROCEDURE [dbo].[usp_Delete_SoftwareDOC] 
	-- Add the parameters for the stored procedure here
	@SoftwareDOC_Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	DECLARE @ReturnValue INT

	DELETE SoftwareDoc
	WHERE SoftwareDocID = @SoftwareDOC_Id


	IF @@ERROR <> 0
	BEGIN
	 SET @ReturnValue = -1
	END
	ELSE
	BEGIN
	 SET @ReturnValue = 0
	END

END
