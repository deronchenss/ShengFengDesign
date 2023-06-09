USE [master]
GO
/****** Object:  Database [ShengFengDB]    Script Date: 2023/5/3 下午 02:43:08 ******/
CREATE DATABASE [ShengFengDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShengFengDB', FILENAME = N'D:\SQL\MS SQL SEVER\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShengFengDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShengFengDB_log', FILENAME = N'D:\SQL\MS SQL SEVER\MSSQL12.MSSQLSERVER\MSSQL\DATA\ShengFengDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShengFengDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShengFengDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShengFengDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShengFengDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShengFengDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShengFengDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShengFengDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShengFengDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShengFengDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShengFengDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShengFengDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShengFengDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShengFengDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShengFengDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShengFengDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShengFengDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShengFengDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ShengFengDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShengFengDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShengFengDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShengFengDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShengFengDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShengFengDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShengFengDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShengFengDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ShengFengDB] SET  MULTI_USER 
GO
ALTER DATABASE [ShengFengDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShengFengDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShengFengDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShengFengDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ShengFengDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ShengFengDB]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2023/5/3 下午 02:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[UserRole] [nvarchar](50) NULL,
	[Message] [nvarchar](500) NULL,
	[MessengerType] [nvarchar](10) NULL,
	[MessengerId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Album]    Script Date: 2023/5/3 下午 02:43:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Album](
	[ID] [varchar](100) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[ModifyTime] [datetime2](7) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[Author_ID] [int] NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[Language] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
USE [master]
GO
ALTER DATABASE [ShengFengDB] SET  READ_WRITE 
GO
