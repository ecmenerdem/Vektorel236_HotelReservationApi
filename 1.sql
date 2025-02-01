USE [master]
GO
/****** Object:  Database [HotelReservationDB]    Script Date: 1.02.2025 13:26:04 ******/
CREATE DATABASE [HotelReservationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelReservationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HotelReservationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelReservationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HotelReservationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HotelReservationDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelReservationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelReservationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelReservationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelReservationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelReservationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelReservationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelReservationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelReservationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelReservationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelReservationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelReservationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelReservationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelReservationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelReservationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelReservationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelReservationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelReservationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelReservationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelReservationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelReservationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelReservationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelReservationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelReservationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelReservationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelReservationDB] SET  MULTI_USER 
GO
ALTER DATABASE [HotelReservationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelReservationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelReservationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelReservationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelReservationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelReservationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelReservationDB', N'ON'
GO
ALTER DATABASE [HotelReservationDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [HotelReservationDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HotelReservationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[EMail] [nvarchar](max) NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
	[FeaturedImage] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoomID] [int] NOT NULL,
	[CheckInDate] [datetime2](7) NOT NULL,
	[CheckOutDate] [datetime2](7) NOT NULL,
	[NumberOfGuest] [int] NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HotelID] [int] NOT NULL,
	[RoomType] [int] NOT NULL,
	[Capacity] [int] NOT NULL,
	[PricePerNight] [decimal](18, 2) NOT NULL,
	[IsAvalible] [bit] NOT NULL,
	[Desciption] [nvarchar](max) NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](20) NOT NULL,
	[GroupID] [int] NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroup]    Script Date: 1.02.2025 13:26:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250125065308_m1', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250201082235_m2', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 
GO
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Description], [PhoneNumber], [EMail], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP], [FeaturedImage]) VALUES (3, N'asdasd', N'sdfsdf', N'Ankara', N'sdfsdf', N'123123', N'sdfsdf@sdfsdf.com', N'b3f5d6f4-9fce-4b83-a79d-4f6cf9930bbf', 1, 0, 1, CAST(N'2025-02-01T12:37:59.9436157' AS DateTime2), N'192.168.2.1', 1, CAST(N'2025-02-01T12:37:59.9437811' AS DateTime2), N'192.168.2.1', N'otel_b91f156c-158a-4032-acac-16eb0f34e009.jpeg')
GO
INSERT [dbo].[Hotel] ([ID], [Name], [Address], [City], [Description], [PhoneNumber], [EMail], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP], [FeaturedImage]) VALUES (4, N'Hilton', N'Çankaya', N'İstanbul', N'Hilton Resort Otel 5  Yıldızlı', N'12312321', N'hilton@hilton.com', N'02322eb9-4d58-4aaa-b237-f71a7a072a33', 1, 0, 1, CAST(N'2025-02-01T13:14:33.0976834' AS DateTime2), N'192.168.2.1', 1, CAST(N'2025-02-01T13:14:33.0977955' AS DateTime2), N'192.168.2.1', N'hilton-istanbul-bosphorus_f8148180-8c41-4bbc-b868-ef6b91e74cd8.jpg')
GO
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Username], [Password], [Email], [PhoneNumber], [GroupID], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (1, N'Ecmennnnnn', N'Erdemm', N'ecmen', N'12345', N'ecmenn@ecmen.com', N'12345678', 1, N'e5099060-7350-4a7c-b39f-aa04605d2df1', 1, 0, NULL, NULL, NULL, 1, CAST(N'2025-01-26T10:52:13.4187747' AS DateTime2), N'192.168.2.1')
GO
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Username], [Password], [Email], [PhoneNumber], [GroupID], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (6, N'Ali', N'Veli', N'ali', N'12345', N'ali@veli.com', N'123456789', 1, N'6050041d-21e7-4124-8634-cb792831571d', 1, 0, 1, CAST(N'2025-01-26T11:17:49.5076844' AS DateTime2), N'192.168.2.1', 1, CAST(N'2025-01-26T11:40:32.6396154' AS DateTime2), N'192.168.2.1')
GO
INSERT [dbo].[User] ([ID], [FirstName], [LastName], [Username], [Password], [Email], [PhoneNumber], [GroupID], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (7, N'gfhfghfg', N'hfghfgh', N'asd', N'12345', N'dasdas@asdasd.com', N'1234567', NULL, N'4f44d40f-6ccf-4765-8260-e9b23d8d898a', 0, 1, 1, CAST(N'2025-01-26T13:11:08.1381760' AS DateTime2), N'192.168.2.1', 1, CAST(N'2025-01-26T13:13:37.3310487' AS DateTime2), N'192.168.2.1')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserGroup] ON 
GO
INSERT [dbo].[UserGroup] ([ID], [Name], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (1, N'Admin', N'a4d57b0c-f4ec-4638-b6ff-212b63799261', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserGroup] ([ID], [Name], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (2, N'Muhasebe', N'724221fc-ce9e-4f74-a73d-caf6dd785dcc', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserGroup] ([ID], [Name], [GUID], [IsActive], [IsDeleted], [AddedUser], [AddedTime], [AddedIP], [UpdatedUser], [UpdatedTime], [UpdatedIP]) VALUES (3, N'Müşteri', N'2df442a4-7bdb-45d5-a93c-8f21475a0f0e', 1, 0, NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserGroup] OFF
GO
/****** Object:  Index [IX_Reservation_RoomID]    Script Date: 1.02.2025 13:26:04 ******/
CREATE NONCLUSTERED INDEX [IX_Reservation_RoomID] ON [dbo].[Reservation]
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservation_UserID]    Script Date: 1.02.2025 13:26:04 ******/
CREATE NONCLUSTERED INDEX [IX_Reservation_UserID] ON [dbo].[Reservation]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Room_HotelID]    Script Date: 1.02.2025 13:26:04 ******/
CREATE NONCLUSTERED INDEX [IX_Room_HotelID] ON [dbo].[Room]
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_GroupID]    Script Date: 1.02.2025 13:26:04 ******/
CREATE NONCLUSTERED INDEX [IX_User_GroupID] ON [dbo].[User]
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Hotel] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Reservation] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Room] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[UserGroup] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserGroup] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Room_RoomID] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Room_RoomID]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_User_UserID]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel_HotelID] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel_HotelID]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserGroup_GroupID] FOREIGN KEY([GroupID])
REFERENCES [dbo].[UserGroup] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserGroup_GroupID]
GO
USE [master]
GO
ALTER DATABASE [HotelReservationDB] SET  READ_WRITE 
GO
