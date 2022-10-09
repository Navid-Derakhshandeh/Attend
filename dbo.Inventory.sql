USE [Attend]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 10/9/2022 3:00:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date_Added] [datetime] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Manufacture] [varchar](max) NULL,
	[Quantity] [int] NULL,
	[Cost_Price] [int] NULL,
	[Sell_Price] [int] NULL,
	[Model_Name] [varchar](max) NULL,
	[Location] [varchar](max) NULL,
	[Condition] [varchar](max) NULL,
	[Availabel] [varchar](max) NULL,
	[Allocated] [varchar](max) NULL,
	[Suppliers] [varchar](max) NULL,
	[Category] [varchar](max) NULL,
	[Serial_Number] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

