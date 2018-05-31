USE [CRM]
GO

/****** Object:  Table [dbo].[Phones]    Script Date: 4/17/2018 13:25:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Phones](
	[Phone_Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Fk_Client_Id] [int] NOT NULL,
 CONSTRAINT [PK_Phones] PRIMARY KEY CLUSTERED 
(
	[Phone_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Phones]  WITH CHECK ADD  CONSTRAINT [FK_Phones_Clients] FOREIGN KEY([Fk_Client_Id])
REFERENCES [dbo].[Clients] ([Client_Id])
GO

ALTER TABLE [dbo].[Phones] CHECK CONSTRAINT [FK_Phones_Clients]
GO


