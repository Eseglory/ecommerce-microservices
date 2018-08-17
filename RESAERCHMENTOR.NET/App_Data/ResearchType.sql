USE [Research]
GO

/****** Object:  Table [dbo].[ResearchType]    Script Date: 17/08/2018 17:26:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ResearchType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NULL,
	[Description] [nchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


