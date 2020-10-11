DROP TABLE [dbo].[Domain]

/****** Object:  Table [dbo].[Domain]    Script Date: 11-10-2020 20:25:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Domain](
	[DomainID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ApiKey] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DomainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


