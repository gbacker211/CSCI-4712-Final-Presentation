USE [SCMDatabase]
GO

/****** Object:  Table [dbo].[SoftwareDoc]    Script Date: 3/18/2016 10:37:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SoftwareDoc](
	[SoftwareDocID] [int] IDENTITY(1,1) NOT NULL,
	[Software_Id] [int] NOT NULL,
	[Name] [nchar](25) NOT NULL,
	[Revision] [nchar](25) NULL,
	[Date] [nchar](25) NOT NULL,
	[Description] [text] NULL,
	[Location] [text] NULL,
 CONSTRAINT [PK_SoftwareDoc] PRIMARY KEY CLUSTERED 
(
	[SoftwareDocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


