USE SCMDatabase;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	Select Software Item View 2
-- =============================================
CREATE PROCEDURE usp_Select_SoftwareItemView2
	-- Add the parameters for the stored procedure here
	@SoftwareId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM ConfigItem C
	WHERE C.SoftwareID = @SoftwareId
END
GO
