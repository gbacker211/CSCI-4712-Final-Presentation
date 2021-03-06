USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_SoftwareItemOverview]    Script Date: 3/19/2016 12:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Geoffrey Backer
-- Create date: 2-27-2016
-- Description:	Select Software Item Overview
-- =============================================
ALTER PROCEDURE [dbo].[usp_Select_SoftwareItemOverview]
	-- Add the parameters for the stored procedure here
	@SoftwareId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	;WITH

	SoftwareItem(ID) AS
	(
	    SELECT Software.SoftwareID FROM Software
	),



  SoftwareDocument(ID,Name,Revision, Location, Date, Description, SoftwareID)
	  AS
	 (
	    SELECT SOD.SoftwareDocID, SOD.Name, SOD.Revision, SOD.Location, SOD.Date, SOD.Description, SOD.Software_Id
		FROM SoftwareDoc SOD
		
		

	 ),

      Config_Item(ID, Name, Revision, Date, Description, Location, SoftwareID)
	  AS
	  (
	      SELECT CI.CI_ID, CI.Name, CI.Revision, CI.Date, CI.Description, CI.Location, CI.SoftwareID
		  FROM ConfigItem CI
		
		 
		 
	  ),
	  ConfigItem_DOC(ID, Name, Revision, Date, Description, Location, ConfigItemID)
	  AS
	  (
	       SELECT CID.CID_ID, CID.Name, CID.Revision, CID.Date, CID.Description, CID.Location, CID.CI
		   FROM ConfigItemDoc CID
		 
		  
		  
	  )	,

	   

	    SoftwareItemOverview(SoftwareDocID, SoftwareDocName, SoftwareDocRevision, SoftwareDocLocation, SoftwareDocDate, SoftwareDocDesc, 
	  ConfigItemID, ConfigItemName, ConfigItemRev, ConfigItemLocal,ConfigItemDate,ConfigItemDes  ,ConfigItemDocID, ConfigItemDocName, ConfigItemDocRev, ConfigItemDocLocal, ConfigItemDocDate, ConfigItemDocDesc)
	  AS
	  (
	           SELECT  SD.ID, --0
			           ISNULL(SD.Name, 'N/A'),
					   ISNULL(SD.Revision, 'N/A'),
					   ISNULL(SD.Location, 'N/A'),
					   ISNULL(SD.Date, 'N/A'),
					   ISNULL(SD.Description, 'N/A'),
					   CI.ID, -- 6
					    ISNULL(CI.Name, 'N/A'),
					    ISNULL(CI.Revision, 'N/A'),
					   ISNULL( CI.Location, 'N/A'),
					   ISNULL( CI.Date, 'N/A'),
					  ISNULL(  CI.Description, 'N/A'),
					   CID.ID, -- 12
					   ISNULL( CID.Name, 'N/A'),
					    ISNULL(CID.Revision, 'N/A'),
					    ISNULL(CID.Location, 'N/A'),
					   ISNULL( CID.Date, 'N/A'),
					   ISNULL( CID.Description, 'N/A')

			   FROM  SoftwareItem  SI
			    LEFT OUTER JOIN SoftwareDocument SD ON SD.SoftwareID = SI.ID
				LEFT OUTER JOIN  Config_Item  CI ON CI.SoftwareID = SI.ID
				LEFT OUTER JOIN  ConfigItem_DOC CID  ON CID.ConfigItemID = CI.ID
				WHERE SI.ID = @SoftwareID
	 


	  )



	SELECT * FROM SoftwareItemOverview

END
