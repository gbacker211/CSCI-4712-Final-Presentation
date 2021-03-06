/*
   Wednesday, February 24, 20163:21:37 PM
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
CREATE TABLE dbo.[Group]
	(
	ID int NOT NULL IDENTITY (1, 1),
	GroupName nchar(25) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.[Group] ADD CONSTRAINT
	PK_Group PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.[Group] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
