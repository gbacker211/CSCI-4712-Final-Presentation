/*
   Sunday, February 21, 20164:48:55 PM
   User: 
   Server: GEOFFPC2P0\SQLEXPRESS
   Database: SCMDatabase
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Software
	(
	SoftwareID int NOT NULL IDENTITY (1, 1),
	Name nchar(25) NOT NULL,
	Description text NOT NULL,
	Classification nchar(2) NOT NULL,
	SystemName nchar(25) NOT NULL,
	Engineer nchar(25) NOT NULL,
	Owner nchar(25) NOT NULL,
	DesignAuthority nchar(25) NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Software ADD CONSTRAINT
	PK_Software PRIMARY KEY CLUSTERED 
	(
	SoftwareID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Software SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
