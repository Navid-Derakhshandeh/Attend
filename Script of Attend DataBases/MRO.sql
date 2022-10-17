USE [Attend]
GO

/****** Object:  Table [dbo].[MRO]    Script Date: 10/17/2022 11:40:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MRO](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Room_Number] [int] NOT NULL,
	[Room_Type] [varchar](max) NOT NULL,
	[Phone] [int] NOT NULL,
	[Condition] [varchar](max) NOT NULL,
 CONSTRAINT [PK_MRO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

