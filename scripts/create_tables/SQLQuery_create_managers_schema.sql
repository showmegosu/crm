USE [CRM]
GO

/****** Object:  Table [dbo].[Managers]    Script Date: 7/24/2018 12:06:02 AM ******/
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
	[Company] [nvarchar](50) NOT NULL,
	[Fk_Office_Id] [int] NOT NULL,
	[Access_lvl] [nvarchar](50) NOT NULL,
	[DoB] [datetime] NOT NULL,
	[Joined] [datetime] NOT NULL,
	[Base_salary] [int] NOT NULL,
 CONSTRAINT [PK_Managers] PRIMARY KEY CLUSTERED 
(
	[Manager_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Managers]  WITH CHECK ADD  CONSTRAINT [FK_Managers_Offices] FOREIGN KEY([Fk_Office_Id])
REFERENCES [dbo].[Offices] ([Office_Id])
GO

ALTER TABLE [dbo].[Managers] CHECK CONSTRAINT [FK_Managers_Offices]
GO


