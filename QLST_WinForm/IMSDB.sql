CREATE DATABASE IMSDB
GO
USE [IMSDB]
GO
/****** Object:  Table [dbo].[tblCategories]    Script Date: 10/27/2022 8:56:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategories](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[catName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCustomer]    Script Date: 10/27/2022 8:56:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomer](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](50) NULL,
	[cPhone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 10/27/2022 8:56:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[oId] [int] IDENTITY(1,1) NOT NULL,
	[odate] [date] NOT NULL,
	[pID] [int] NOT NULL,
	[cID] [int] NOT NULL,
	[qty] [int] NOT NULL,
	[price] [int] NOT NULL,
	[total] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[oId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 10/27/2022 8:56:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[pId] [int] IDENTITY(1,1) NOT NULL,
	[pname] [nvarchar](50) NOT NULL,
	[pqty] [int] NOT NULL,
	[pdescription] [nvarchar](50) NULL,
	[pcategory] [varchar](50) NOT NULL,
	[pprice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 10/27/2022 8:56:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[username] [varchar](50) NOT NULL,
	[fullname] [nvarchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[phone] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblCategories] ON 

INSERT [dbo].[tblCategories] ([CatId], [catName]) VALUES (1, N'Phone')
INSERT [dbo].[tblCategories] ([CatId], [catName]) VALUES (2, N'Watch')
SET IDENTITY_INSERT [dbo].[tblCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[tblCustomer] ON 

INSERT [dbo].[tblCustomer] ([cId], [cname], [cPhone]) VALUES (1, N'Nguyễn Thị Ngọc Châu', N'01111111')
INSERT [dbo].[tblCustomer] ([cId], [cname], [cPhone]) VALUES (4, N'Nguyễn Trần Hoàng Hải', N'01111111')
SET IDENTITY_INSERT [dbo].[tblCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[tblOrder] ON 

INSERT [dbo].[tblOrder] ([oId], [odate], [pID], [cID], [qty], [price], [total]) VALUES (15, CAST(N'2022-10-27' AS Date), 4, 1, 1, 2000000, 2000000)
INSERT [dbo].[tblOrder] ([oId], [odate], [pID], [cID], [qty], [price], [total]) VALUES (16, CAST(N'2022-10-27' AS Date), 3, 4, 2, 4000000, 4000000)
SET IDENTITY_INSERT [dbo].[tblOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[tblProduct] ON 

INSERT [dbo].[tblProduct] ([pId], [pname], [pqty], [pdescription], [pcategory], [pprice]) VALUES (1, N'Iphone 14 promax', 11, N'156GB, Màn hình mỏng', N'Phone', 2500000)
INSERT [dbo].[tblProduct] ([pId], [pname], [pqty], [pdescription], [pcategory], [pprice]) VALUES (2, N'Iphone 14 Plus', 12, N'256GB, Dung lượng lớn', N'Phone', 3500000)
INSERT [dbo].[tblProduct] ([pId], [pname], [pqty], [pdescription], [pcategory], [pprice]) VALUES (3, N'Iphone 14 promax', 12, N'256GB, Chụp ảnh siêu nét', N'Phone', 4000000)
INSERT [dbo].[tblProduct] ([pId], [pname], [pqty], [pdescription], [pcategory], [pprice]) VALUES (4, N'Iphone 13 promax', 9, N'156GB, Dung lượng lớn', N'Phone', 2000000)
SET IDENTITY_INSERT [dbo].[tblProduct] OFF
GO
INSERT [dbo].[tblUser] ([username], [fullname], [password], [phone]) VALUES (N'fullganne', N'Nguyễn Đức Ân', N'14082003', N'012345678')
INSERT [dbo].[tblUser] ([username], [fullname], [password], [phone]) VALUES (N'thuyduong', N'Phan Lương Thùy Dương', N'123', N'111111111')
INSERT [dbo].[tblUser] ([username], [fullname], [password], [phone]) VALUES (N'kienphu', N'Võ Kiến Phú', N'456', N'222222222')
INSERT [dbo].[tblUser] ([username], [fullname], [password], [phone]) VALUES (N'anhlinh', N'Nguyễn Trần Ánh Linh', N'789', N'333333333')
INSERT [dbo].[tblUser] ([username], [fullname], [password], [phone]) VALUES (N'minhquan', N'Võ Nguyễn Đình Quân', N'345', N'444444444')
GO

USE [IMSDB]
GO

CREATE PROCEDURE GetOrdersReport
(
	@Fromdate datetime,
	@Todate datetime
)
AS
	SELECT [oId], [odate], [cID], [pID], [qty], [price], [total]
	FROM [dbo].[tblOrder]
	WHERE odate between @Fromdate and @Todate
	ORDER BY odate asc
GO