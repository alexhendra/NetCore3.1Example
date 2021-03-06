USE [TestAlex]
GO
/****** Object:  Table [dbo].[MMenu]    Script Date: 6/18/2020 5:00:53 PM ******/
DROP TABLE IF EXISTS [dbo].[MMenu]
GO
/****** Object:  Table [dbo].[MMenu]    Script Date: 6/18/2020 5:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Descriptions] [varchar](300) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MMenu] ON 

INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (1, NULL, N'All Category', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (2, NULL, N'Mobile Phones', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (3, NULL, N'Cars', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (4, NULL, N'Motorcycles', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (5, NULL, N'Houses', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (6, NULL, N'TV - Video - Audio', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (7, NULL, N'Tablets', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (8, NULL, N'Land & Plots', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (9, 1, N'Mobiles', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (10, 9, N'Tablets', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (11, 9, N'Accessories', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (12, 9, N'Mobile Phones', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (13, 1, N'Vehicles', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (14, 13, N'Cars', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (15, 13, N'Cars on Installments', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (16, 1, N'Menu Level 2', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (17, 16, N'Menu Level 3.1', 1)
INSERT [dbo].[MMenu] ([Id], [ParentId], [Descriptions], [IsActive]) VALUES (18, 16, N'Menu Level 3.2', 1)
SET IDENTITY_INSERT [dbo].[MMenu] OFF
