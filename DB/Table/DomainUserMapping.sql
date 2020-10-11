/****** Object:  Table [dbo].[UserProfile]    Script Date: 11-10-2020 16:16:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DomainUserMapping](
	[DomainUserMappingID] [uniqueidentifier] NOT NULL,
	[DomainID] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[DomainUserMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


