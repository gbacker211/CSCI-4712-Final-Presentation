USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_SoftwareView]    Script Date: 4/11/2016 12:35:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	Select Software View
-- =============================================
ALTER PROCEDURE [dbo].[usp_Select_SoftwareView]
	-- Add the parameters for the stored procedure here
	@GroupID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


;WITH 
     
	 Software_Name(Name, SoftwareID, GroupID)
	  AS
	 (
	    SELECT S.Name,S.SoftwareID, UG.GroupId
		FROM Software S
		INNER JOIN UserGroup UG ON UG.SoftwareID = S.SoftwareID
		INNER JOIN Groups G ON G.ID = UG.GroupId
		

	 ),

      Software_DOC_Count(SoftwareDocCount, SoftwareId)
	  AS
	  (
	     SELECT COUNT(SD.SoftwareDocID), Software_Id
		 FROM SoftwareDoc SD
		 GROUP BY Software_Id
		 
	  ),
	 
	
	  
	  ConfigItem_Count(ItemCount, CI_SoftwareID)
	  AS
	  (
	       SELECT COUNT(CI.CI_ID), Ci.SoftwareID
		   FROM ConfigItem CI
		   GROUP BY CI.SoftwareID
		  
	  ),
	  ConfigItemDOC_Count(CID_Count, SoftwareID)
	  AS
	  (
	      SELECT COUNT(CIDOC.CID_ID), S.SoftwareID
		  FROM ConfigItemDoc CIDOC
		  INNER JOIN ConfigItem CI ON CI.CI_ID = CIDOC.CI
		  INNER JOIN Software S ON S.SoftwareID = CI.SoftwareID
		  GROUP BY S.SoftwareID
		
	  ),

	    SoftwareView(Name, Software_DOC_Count, Software_CI_Count, Software_CID_Count  ,SoftwareID)
	  AS
	  (
	           SELECT ISNULL( S.Name, ''),
			    ISNULL(SDOC.SoftwareDocCount,0),
				ISNULL(CICOUNT.ItemCount, 0),
				ISNULL(CIDCOUNT.CID_Count, 0),
			  ISNULL(S.SoftwareID, 0)

			   FROM Software_Name S
			   LEFT OUTER JOIN Software_DOC_Count SDOC ON SDOC.SoftwareId = S.SoftwareID
			   LEFT OUTER JOIN ConfigItem_Count CICOUNT ON CICOUNT.CI_SoftwareID = S.SoftwareID
			   LEFT OUTER JOIN ConfigItemDOC_Count CIDCOUNT ON CIDCOUNT.SoftwareID = S.SoftwareID
			   WHERE S.GroupID = @GroupID 
			 
	  )



  SELECT *
  FROM SoftwareView







END
