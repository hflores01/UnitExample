USE [CORE_EXAMEN]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19/08/2022 21:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 19/08/2022 21:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 19/08/2022 21:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 19/08/2022 21:14:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (1, N'Wolfgang', N'Ofner', 30)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (2, N'Wolfgang', N'Ofner', 30)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (3, N'hector', N'flores', 43)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (4, N'hector', N'flores', 43)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (5, N'JHON', N'DOE', 43)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (6, N'JHON', N'DOE', 43)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (7, N'Luis', N'Vargas', 20)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (8, N'Juan', N'Laguna', 20)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (9, N'Eduardo', N'Claros', 55)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Age]) VALUES (10, N'juan luis', N'Claros', 55)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomerId], [Fecha]) VALUES (1, 1, CAST(N'2022-07-07 16:29:20.677' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [Fecha]) VALUES (2, 10, CAST(N'2022-07-07 16:29:20.677' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [Fecha]) VALUES (3, 10, CAST(N'2022-07-07 16:29:20.677' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [Fecha]) VALUES (4, 9, CAST(N'2022-07-07 16:29:20.677' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (1, 1, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (2, 2, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (3, 3, 2)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (4, 3, 3)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (5, 4, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId]) VALUES (6, 4, 2)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Description], [Price]) VALUES (1, N'Phone', N'This is a Phone', CAST(99.99 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price]) VALUES (2, N'tablet', N'My tablet', CAST(100.23 AS Decimal(10, 2)))
INSERT [dbo].[Product] ([Id], [Name], [Description], [Price]) VALUES (3, N'computer', N'the tablet', CAST(700.23 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
