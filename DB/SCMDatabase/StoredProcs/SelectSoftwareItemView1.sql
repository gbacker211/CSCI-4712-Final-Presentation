USE SCMDatabase;
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	 Select Software Item View 1
-- =============================================
CREATE PROCEDURE usp_Select_SoftwareItemView1
	@SoftwareID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM SoftwareDoc SD
	WHERE SD.Software_Id = @SoftwareID


END
GO
