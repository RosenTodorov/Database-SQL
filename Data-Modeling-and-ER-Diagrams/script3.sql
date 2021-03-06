USE [master]
GO
/****** Object:  Database [EducationalSystem]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
CREATE DATABASE [EducationalSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EducationalSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EducationalSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EducationalSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EducationalSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EducationalSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EducationalSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EducationalSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EducationalSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EducationalSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EducationalSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EducationalSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [EducationalSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EducationalSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EducationalSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EducationalSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EducationalSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EducationalSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EducationalSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EducationalSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EducationalSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EducationalSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EducationalSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EducationalSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EducationalSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EducationalSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EducationalSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EducationalSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EducationalSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EducationalSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EducationalSystem] SET  MULTI_USER 
GO
ALTER DATABASE [EducationalSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EducationalSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EducationalSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EducationalSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [EducationalSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [EducationalSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[course_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[department_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[faculty_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[university_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[person_id] [int] NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[person_id] [int] NOT NULL,
	[title_id] [int] NOT NULL,
	[years_of_experience] [int] NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Professors] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[persons_id] [int] NOT NULL,
	[faculty_id] [int] NOT NULL,
	[course_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[title_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[title_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Universities]    Script Date: 24.8.2014 г. 15:31:15 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[university_id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[university_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [EducationalSystem] SET  READ_WRITE 
GO
