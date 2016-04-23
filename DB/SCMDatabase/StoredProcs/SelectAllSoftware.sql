USE SCMDatabase
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 3-21-16
-- Description:	Select all software
-- =============================================
CREATE PROCEDURE usp_Select_AllSoftware 
	-- No Parameters to pass
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT   S.Name as SoftwareName,
	       S.Classification,
		   S.Description,
		   S.DesignAuthority,
		   S.Engineer,
		   S.SystemName,
		   S.Owner,
		 --  G.GroupName,
		   S.SoftwareID
	 FROM Software S
END
GO
