USE [CRM]
GO

/****** Object:  Table [dbo].[Offices]    Script Date: 8/10/2018 1:29:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Offices](
	[Office_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Fk_Company_Id] [int] NOT NULL,
 CONSTRAINT [PK_Offices] PRIMARY KEY CLUSTERED 
(
	[Office_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_Offices_Companies] FOREIGN KEY([Fk_Company_Id])
REFERENCES [dbo].[Companies] ([Company_Id])
GO

ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_Offices_Companies]
GO


