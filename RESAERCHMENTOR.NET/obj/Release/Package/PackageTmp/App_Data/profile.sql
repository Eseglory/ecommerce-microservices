USE [Research]
GO

/****** Object:  Table [dbo].[Research]    Script Date: 17/08/2018 17:02:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Research](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[SubTitle] [varchar](max) NULL,
	[AuthorName] [varchar](max) NULL,
	[RType] [varchar](max) NULL,
	[Status] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[FileName] [varchar](max) NULL,
	[OwnersId] [varchar](max) NULL,
	[DateCreated] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


