USE [Attend]
GO

/****** Object:  Table [dbo].[MRE]    Script Date: 10/17/2022 11:40:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MRE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Reserv_ID] [int] NOT NULL,
	[Client_ID] [int] NOT NULL,
	[Room_T] [varchar](max) NOT NULL,
	[Room_N] [int] NOT NULL,
	[Date_IN] [datetime] NOT NULL,
	[Date_OUT] [datetime] NOT NULL,
 CONSTRAINT [PK_MRE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

