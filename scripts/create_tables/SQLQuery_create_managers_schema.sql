USE [CRM]
GO

/****** Object:  Table [dbo].[Managers]    Script Date: 8/10/2018 1:29:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Managers](
	[Manager_Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Fathers_name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Skype] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Fk_Company_Id] [int] NOT NULL,
	[Fk_Office_Id] [int] NOT NULL,
	[DoB] [date] NOT NULL,
	[Joined] [date] NOT NULL,
	[Base_salary] [int] NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[Manager_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Companies] FOREIGN KEY([Fk_Company_Id])
REFERENCES [dbo].[Companies] ([Company_Id])
GO

ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [FK_Managers_Companies]
GO

ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Offices] FOREIGN KEY([Fk_Office_Id])
REFERENCES [dbo].[Offices] ([Office_Id])
GO

ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [FK_Managers_Offices]
GO


