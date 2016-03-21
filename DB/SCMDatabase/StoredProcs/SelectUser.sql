USE [SCMDatabase]
GO
/****** Object:  StoredProcedure [dbo].[usp_Select_User]    Script Date: 3/21/2016 11:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_Select_User]
	-- Add the parameters for the stored procedure here
	@UserName VARCHAR(25),
	@PassWoard VARCHAR(25)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	   
	     SELECT DISTINCT AU.AccesGroup,
		  		   AU.User_Id
	 	FROM AccessUser AU
	    WHERE AU.UserName = @UserName AND AU.Password = @PassWoard
--Pull Group if possible

   

END
