USE [FashionShop]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Fullname] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[AccountId] [int] NOT NULL,
	[IssuedDate] [datetime2](7) NOT NULL,
	[ShippingAddress] [nvarchar](max) NULL,
	[ShippingPhone] [nvarchar](max) NULL,
	[Total] [int] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SKU] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 2023-02-01 21:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (1, N'admin', N'Admin12345', N'admin@FashionShop.com', N'01234567890', N'Tp.Hồ Chí Minh', N'Nguyễn Văn Ad Min', 1, N'admin.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (2, N'john', N'John123445', N'john@gmail.com', N'0905486957', N'Đà Nẵng', N'John Henry', 0, N'john.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (3, N'ncbao', N'Ncb12345', N'ncbao@gmail.com', N'0904863125', N'Tp.Hồ Chí Minh', N'Ngô Chí Bảo', 0, N'ncbao.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (4, N'tvh', N'Tvh12345', N'tvh@gmail.com', N'0987654321', N'Củ Chi', N'Trần Văn Huy', 0, N'tvh.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (5, N'ptdat', N'Ptd12345', N'ptdat@gmail.com', N'0987654321', N'Bình Dương', N'Phạm Tấn Đạt', 0, N'ptdat.jpg', 1)
INSERT [dbo].[Accounts] ([Id], [Username], [Password], [Email], [Phone], [Adress], [Fullname], [IsAdmin], [Avatar], [Status]) VALUES (6, N'tqchien', N'Tqc12345', N'tqc@gmail.com', N'0987654321', N'Bến Tre', N'Trần Quyết Chiến', 0, N'tqc.jpg', 1)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 

INSERT [dbo].[Carts] ([Id], [AccountId], [ProductId], [Quantity]) VALUES (1, 5, 1, 2)
INSERT [dbo].[Carts] ([Id], [AccountId], [ProductId], [Quantity]) VALUES (2, 2, 1, 4)
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceDetails] ON 

INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [UnitPrice]) VALUES (1, 1, 1, 2, 45000)
INSERT [dbo].[InvoiceDetails] ([Id], [InvoiceId], [ProductId], [Quantity], [UnitPrice]) VALUES (2, 2, 1, 4, 59000)
SET IDENTITY_INSERT [dbo].[InvoiceDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 

INSERT [dbo].[Invoices] ([Id], [Code], [AccountId], [IssuedDate], [ShippingAddress], [ShippingPhone], [Total], [Status]) VALUES (1, N'299541176755', 5, CAST(N'2020-01-15T15:06:12.0000000' AS DateTime2), N'Quận 3, Tp.HCM', N'0987654321', 618000, 1)
INSERT [dbo].[Invoices] ([Id], [Code], [AccountId], [IssuedDate], [ShippingAddress], [ShippingPhone], [Total], [Status]) VALUES (2, N'527777447269', 2, CAST(N'2020-01-16T10:30:19.0000000' AS DateTime2), N'Quận 1, Tp.HCM', N'0983564782', 167000, 1)
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (1, N'WT3WPGZ9BTWB', N'Áo sơ mi trắng dài tay', N'vải mền mại', 350000, 40, 5, N'aosomi1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (2, N'98IOWWXWYVQ4', N'Áo sơ mi trắng dài tay', N'vải thoáng mát', 410000, 15, 2, N'aosomi2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (3, N'FWIIEUIE4222', N'Áo sơ mi xanh', N'vải mềm thoáng mát', 210000, 15, 2, N'aosomi3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (4, N'432HHFHFOE56', N'Áo thun đen họa tiết', N'thoáng mát trẻ trung', 210000, 15, 2, N'aosomi4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (5, N'DNIEWIEI3532', N'Áo thun xanh họa tiết', N'thoáng mát trẻ trung thấm hút tốt', 210000, 15, 2, N'aosomi5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (6, N'21RH48HRFXX8', N'Quần jeans xanh', N'xanh ống rộng', 300000, 29, 6, N'jeans1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (7, N'QOXYSDE605P5', N'Quần jeans đen', N'đen óng bó', 535000, 1, 3, N'jeans2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (8, N'64NHFHHHSST6', N'Quần jeans xanh nhạt nữ', N'trẻ trung năng động', 255000, 1, 3, N'jeans3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (9, N'VXDNMKR46U5H', N'Quần jeans xanh đậm nữ', N'trẻ trung năng động', 355000, 1, 3, N'jeans4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (10, N'FBDFSDE605P5', N'Quần jeans xanh nhạt nam', N'trẻ trung năng động', 325000, 1, 3, N'jeans5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (11, N'6YI6TZ3JPO1L', N'Đồ bơi hoa liền', N'hoa liền', 90000, 36, 4, N'swimwear1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (12, N'YHB5JTSVRF8E', N'Đồ bikini', N'Bikini xanh', 100000, 9, 3, N'swimwear2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (13, N'GGEV9TSVRF8E', N'Đồ bikini trắng bơi', N'Bikini trắng', 150000, 9, 3, N'swimwear3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (14, N'3122JTSVRF8E', N'Đồ bikini đen bơi', N'Bikini đen ngợi cảm', 200000, 9, 3, N'swimwear4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (15, N'3525JTSVRF8E', N'Đồ bikini sọc đỏ', N'bơi sọc đỏ', 190000, 9, 3, N'swimwear5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (16, N'LXL64LZAR5M2', N'Đồ ngủ trắng ngợi cảm', N'quyến rũ', 420000, 7, 3, N'sleepwear1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (17, N'C5V645HVP91W', N'Đồ ngủ xanh', N'thoải mái', 320000, 0, 2, N'sleepwear2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (18, N'VSS645HVP91W', N'Đồ ngủ trắng', N'thoải mái thoải mái', 220000, 0, 2, N'sleepwear3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (19, N'892245HVP91W', N'Đồ ngủ trắng hoa', N'thoải mái mền mại', 250000, 0, 2, N'sleepwear4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (20, N'JDV645HVP91W', N'Đồ ngủ hoa', N'thoải mái mền mại vải mỏng ', 320000, 0, 2, N'sleepwear5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (21, N'4KLYT2UF7VB9', N'Quần thể thao', N'đỏ sang chảnh', 62000, 18, 6, N'sportwear1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (22, N'KBD67VI81M80', N'Đồ bộ thể dục', N'đồ tập thể dục', 56000, 64, 5, N'sportwear2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (23, N'VCV67VI81M80', N'Đồ bộ thể dục xanh', N'đồ tập thể dục', 106000, 64, 5, N'sportwear3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (24, N'4267VI81M80', N'Đồ bộ thể thao trắng', N'đồ tập thể dục vải mền', 156000, 64, 5, N'sportwear4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (25, N'HF67VI81M80', N'Quần thể thao đem', N'quần mền thoáng mát', 126000, 64, 5, N'sportwear5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (26, N'3RISEFVDWYVF', N'Áo liền quần hoa', N'năng động', 230000, 120, 6, N'jumpsuits1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (27, N'VIAZXR3Y24IY', N'Áo liền quần văn phòng', N'trẻ trung', 360000, 46, 5, N'jumpsuits2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (28, N'13DZXR3Y24IY', N'Áo liền quần xanh  ', N'trẻ trung thời thượng', 320000, 46, 5, N'jumpsuits3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (29, N'VXVZXR3Y24IY', N'Áo liền quần trắng ', N'trẻ trung năng động', 250000, 46, 5, N'jumpsuits4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (30, N'EVCZXR3Y24IY', N'Áo liền quần đen ngợi cảm', N'trẻ trung ngợi cảm', 400000, 46, 5, N'jumpsuits5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (31, N'VIAZXR3Y24IY', N'Blazer xanh', N'xanh lịch lãm', 365000, 46, 5, N'blazer1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (32, N'SVVDXR3Y24IY', N'Blazer vàng', N' vàng trẻ trung', 362000, 46, 5, N'blazer2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (33, N'23AZXR3Y24IY', N'Blazer hồng', N' hồng trẻ trung', 362000, 46, 5, N'blazer3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (34, N'35EFXR3Y24IY', N'Blazer nâu', N' nâu trẻ trung thanh lịch', 312000, 46, 5, N'blazer4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (35, N'DBFHTHRU6565', N'Blazer đen', N' đen quý phái', 362000, 46, 5, N'blazer5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (36, N'DGSDVCXT464G', N'Áo khoác xanh thể thao', N'trẻ trung, thể thao', 300000, 46, 5, N'jacket1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (37, N'ERGCBRYRYHFG', N'Áo khoác đen', N'trẻ trung lịch lãm', 420000, 46, 5, N'jacket2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (38, N'35DFGBHVGTTR', N'Áo khoác xám đen', N'trẻ trung lịch lãm', 320000, 46, 5, N'jacket3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (39, N'456FBCVBDGRY', N'Áo khoác đen sọc', N'trẻ trung lịch lãm', 220000, 46, 5, N'jacket4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (40, N'GG5FDBFBTHTR', N'Áo khoác trắng', N'trẻ trung lịch lãm', 220000, 46, 5, N'jacket5.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (41, N'546FBCBCBFHT', N'Giày thể thao xanh', N'thoáng mát', 360000, 46, 5, N'shoes1.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (42, N'57GFBCVBVCBH', N'Giày thể thao trắng', N'trẻ trung', 290000, 46, 5, N'shoes2.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (43, N'GNVNRTY4GFBF', N'Giày thể thao đỏ', N'trẻ trung năng động', 250000, 46, 5, N'shoes3.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (44, N'5756GFHBVCBB', N'Giày thể thao hồng', N'trẻ trung', 320000, 46, 5, N'shoes4.jpg', 1)
INSERT [dbo].[Products] ([Id], [SKU], [Name], [Description], [Price], [Stock], [ProductTypeId], [Image], [Status]) VALUES (45, N'5475BCBCBFGH', N'Giày thể thao trắng cổ cao', N'trẻ trung', 400000, 46, 5, N'shoes5.jpg', 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTypes] ON 

INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (1, N'Shirts', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (2, N'Jeans', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (3, N'Swimwear', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (4, N'Sleepwear', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (5, N'Sportwear', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (6, N'Jumpsuits', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (7, N'Blazers', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (8, N'Jackets', 1)
INSERT [dbo].[ProductTypes] ([Id], [Name], [Status]) VALUES (9, N'Shoes', 1)
SET IDENTITY_INSERT [dbo].[ProductTypes] OFF
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products_ProductId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices_InvoiceId]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Accounts_AccountId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes_ProductTypeId]
GO
