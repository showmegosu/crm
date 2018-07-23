USE [CRM]
GO

/****** Object:  Table [dbo].[ManagerPhone]    Script Date: 7/24/2018 12:04:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ManagerPhone](
	[Phone_Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Fk_Manager_Id] [int] NOT NULL,
 CONSTRAINT [PK_ManagerPhone] PRIMARY KEY CLUSTERED 
(
	[Phone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ManagerPhone]  WITH NOCHECK ADD  CONSTRAINT [FK_ManagerPhone_Managers] FOREIGN KEY([Fk_Manager_Id])
REFERENCES [dbo].[Managers] ([Manager_Id])
GO

ALTER TABLE [dbo].[ManagerPhone] CHECK CONSTRAINT [FK_ManagerPhone_Managers]
GO


