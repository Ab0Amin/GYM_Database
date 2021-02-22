USE [the_gymD]
GO

/****** Object:  Table [dbo].[NEW_CUSTMER]    Script Date: 1/4/2021 1:07:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [NEW_CUSTMER](
	[firstName] [varchar](10) NULL,
	[lastName] [varchar](10) NULL,
	[genger] [varchar](6) NULL,
	[dateOfBirth] [date] NULL,
	[mobile] [varchar](15) primary key,
	[email] [varchar](50) NULL,
	[joinDate] [date] NULL,
	[adress] [varchar](100) NULL,
	[membershipDuration] [varchar](10) NULL
) ON [PRIMARY]
GO


