USE [master]
GO

CREATE DATABASE [Logistics]
CREATE TABLE [Logistics].[dbo].[Invoices](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Total] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
CREATE TABLE [Logistics].[dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[BoxCapacity] [int] NOT NULL,
	[PalletCapacity] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Logistics].[dbo].[Invoices] ON 

INSERT [Logistics].[dbo].[Invoices] ([InvoiceId], [InvoiceDate], [Total]) VALUES (1, CAST(N'2009-01-01T00:00:00.000' AS DateTime), CAST(1.98 AS Decimal(18, 2)))
INSERT [Logistics].[dbo].[Invoices] ([InvoiceId], [InvoiceDate], [Total]) VALUES (4, CAST(N'2009-01-02T00:00:00.000' AS DateTime), CAST(3.96 AS Decimal(18, 2)))
INSERT [Logistics].[dbo].[Invoices] ([InvoiceId], [InvoiceDate], [Total]) VALUES (5, CAST(N'2009-01-03T00:00:00.000' AS DateTime), CAST(5.94 AS Decimal(18, 2)))
INSERT [Logistics].[dbo].[Invoices] ([InvoiceId], [InvoiceDate], [Total]) VALUES (6, CAST(N'2009-01-06T00:00:00.000' AS DateTime), CAST(8.91 AS Decimal(18, 2)))
SET IDENTITY_INSERT [Logistics].[dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [Logistics].[dbo].[Products] ON 

INSERT [Logistics].[dbo].[Products] ([Id], [Name], [Quantity], [BoxCapacity], [PalletCapacity]) VALUES (1, N'Water 500ml                                                                                         ', 108, 6, 18)
INSERT [Logistics].[dbo].[Products] ([Id], [Name], [Quantity], [BoxCapacity], [PalletCapacity]) VALUES (2, N'Water 500ml                                                                                         ', 10, 6, 18)
INSERT [Logistics].[dbo].[Products] ([Id], [Name], [Quantity], [BoxCapacity], [PalletCapacity]) VALUES (3, N'Chocolate chip                                                                                      ', 350, 24, 3)
INSERT [Logistics].[dbo].[Products] ([Id], [Name], [Quantity], [BoxCapacity], [PalletCapacity]) VALUES (4, N'Oil pump                                                                                            ', 100, 1, 12)
SET IDENTITY_INSERT [Logistics].[dbo].[Products] OFF

