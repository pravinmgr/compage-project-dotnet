USE [master]
GO
/****** Object:  Database [ProcurementDb]    Script Date: 12/3/2023 9:51:56 PM ******/
CREATE DATABASE [ProcurementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProcurementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProcurementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProcurementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ProcurementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProcurementDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProcurementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProcurementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProcurementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProcurementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProcurementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProcurementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProcurementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProcurementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProcurementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProcurementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProcurementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProcurementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProcurementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProcurementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProcurementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProcurementDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProcurementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProcurementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProcurementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProcurementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProcurementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProcurementDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ProcurementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProcurementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ProcurementDb] SET  MULTI_USER 
GO
ALTER DATABASE [ProcurementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProcurementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProcurementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProcurementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProcurementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProcurementDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProcurementDb', N'ON'
GO
ALTER DATABASE [ProcurementDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProcurementDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProcurementDb]
GO
/****** Object:  User [sqluser]    Script Date: 12/3/2023 9:51:58 PM ******/
CREATE USER [sqluser] FOR LOGIN [sqluser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [sqluser]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [sqluser]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 12/3/2023 9:51:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/3/2023 9:51:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [ProcurementDb] SET  READ_WRITE 
GO
