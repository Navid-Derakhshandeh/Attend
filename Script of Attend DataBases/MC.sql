USE [Attend]
GO

/****** Object:  Table [dbo].[MC]    Script Date: 10/17/2022 11:39:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](max) NOT NULL,
	[Last_Name] [varchar](max) NOT NULL,
	[Phone_C] [int] NOT NULL,
	[Country] [varchar](max) NOT NULL,
	[Image_C] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_MC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

