USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_SoftwareItemView3]    Script Date: 3/16/2016 1:49:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	Select Software Item View 3
-- =============================================
ALTER PROCEDURE [dbo].[usp_Select_SoftwareItemView3] 
	-- Add the parameters for the stored procedure here
	@SoftwareId INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CD.CID_ID,
	       CD.Name,
	       CD.Description,
		   CD.Location,
		   CD.Revision,
		   CD.Date
	        
	FROM ConfigItemDoc CD
	INNER JOIN ConfigItem CI ON CI.CI_ID = CD.CI
	WHERE CI.SoftwareID = @SoftwareId


END
