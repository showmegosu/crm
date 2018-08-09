USE [CRM]
GO

/****** Object:  Table [dbo].[OfficePhones]    Script Date: 8/10/2018 1:29:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OfficePhones](
	[Phone_Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Fk_Office_Id] [int] NOT NULL,
 CONSTRAINT [PK_OfficePhones] PRIMARY KEY CLUSTERED 
(
	[Phone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OfficePhones]  WITH CHECK ADD  CONSTRAINT [FK_OfficePhones_Offices] FOREIGN KEY([Fk_Office_Id])
REFERENCES [dbo].[Offices] ([Office_Id])
GO

ALTER TABLE [dbo].[OfficePhones] CHECK CONSTRAINT [FK_OfficePhones_Offices]
GO


