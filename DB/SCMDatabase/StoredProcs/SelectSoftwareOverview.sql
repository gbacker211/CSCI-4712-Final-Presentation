USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_SoftwareOverview]    Script Date: 3/20/2016 10:43:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	Select Dataview Sofware Overview
-- =============================================
ALTER PROCEDURE [dbo].[usp_Select_SoftwareOverview]
	-- Add the parameters for the stored procedure here
	@GroupID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;
	
	SELECT  S.Name as SoftwareName,
	       S.Classification,
		   S.Description,
		   S.DesignAuthority,
		   S.Engineer,
		   S.SystemName,
		   S.Owner,
		   G.GroupName,
		   S.SoftwareID
	       
	FROM Software S
	INNER JOIN UserGroup UG ON S.SoftwareID = UG.SoftwareID
	INNER JOIN Groups G ON UG.GroupId = G.ID
	WHERE G.ID = @GroupID 

	
    
	
END
