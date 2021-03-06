USE [master]
GO
/****** Object:  Database [Sokoban]    Script Date: 08/05/2016 23:24:56 ******/
CREATE DATABASE [Sokoban] ON  PRIMARY 
( NAME = N'Sokoban', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Sokoban.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Sokoban_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Sokoban_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Sokoban] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sokoban].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sokoban] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Sokoban] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Sokoban] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Sokoban] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Sokoban] SET ARITHABORT OFF
GO
ALTER DATABASE [Sokoban] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Sokoban] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Sokoban] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Sokoban] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Sokoban] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Sokoban] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Sokoban] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Sokoban] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Sokoban] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Sokoban] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Sokoban] SET  DISABLE_BROKER
GO
ALTER DATABASE [Sokoban] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Sokoban] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Sokoban] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Sokoban] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Sokoban] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Sokoban] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Sokoban] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Sokoban] SET  READ_WRITE
GO
ALTER DATABASE [Sokoban] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Sokoban] SET  MULTI_USER
GO
ALTER DATABASE [Sokoban] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Sokoban] SET DB_CHAINING OFF
GO
USE [Sokoban]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 08/05/2016 23:24:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](30) NOT NULL,
	[NICK] [nvarchar](10) NOT NULL,
	[MAXSCORE] [bigint] NOT NULL,
	[RANK] [bigint] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[NICK] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
