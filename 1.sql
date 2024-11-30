USE [master]
GO
/****** Object:  Database [HotelReservationDB]    Script Date: 30.11.2024 13:25:47 ******/
CREATE DATABASE [HotelReservationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelReservationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelReservationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelReservationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\HotelReservationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HotelReservationDB] SET COMPATIBILITY_LEVEL = 150
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
ALTER DATABASE [HotelReservationDB] SET AUTO_CLOSE ON 
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
ALTER DATABASE [HotelReservationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelReservationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelReservationDB] SET RECOVERY SIMPLE 
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
ALTER DATABASE [HotelReservationDB] SET QUERY_STORE = OFF
GO
USE [HotelReservationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 30.11.2024 13:25:47 ******/
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
/****** Object:  Table [dbo].[Hotel]    Script Date: 30.11.2024 13:25:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[PhoneNuber] [nvarchar](max) NOT NULL,
	[EMail] [nvarchar](max) NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[AddedUser] [int] NULL,
	[AddedTime] [datetime2](7) NULL,
	[AddedIP] [nvarchar](max) NULL,
	[UpdatedUser] [int] NULL,
	[UpdatedTime] [datetime2](7) NULL,
	[UpdatedIP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 30.11.2024 13:25:47 ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 30.11.2024 13:25:47 ******/
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
	[Desciption] [nvarchar](max) NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 30.11.2024 13:25:47 ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241124100501_M1', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241124102926_M2', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241124103100_M3', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241130065924_M4', N'8.0.11')
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
USE [master]
GO
ALTER DATABASE [HotelReservationDB] SET  READ_WRITE 
GO
