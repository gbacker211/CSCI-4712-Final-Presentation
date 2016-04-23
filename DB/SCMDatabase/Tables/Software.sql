USE [SCMDatabase]
GO

/****** Object:  Table [dbo].[Software]    Script Date: 2/21/2016 5:18:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Software](
	[SoftwareID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](25) NOT NULL,
	[Description] [text] NOT NULL,
	[Classification] [nchar](2) NOT NULL,
	[SystemName] [nchar](25) NOT NULL,
	[Engineer] [nchar](25) NOT NULL,
	[Owner] [nchar](25) NOT NULL,
	[DesignAuthority] [nchar](25) NOT NULL,
 CONSTRAINT [PK_Software] PRIMARY KEY CLUSTERED 
(
	[SoftwareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

