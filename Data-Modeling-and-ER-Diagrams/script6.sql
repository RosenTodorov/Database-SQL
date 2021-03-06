USE [master]
GO
/****** Object:  Database [Dictionay]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
CREATE DATABASE [Dictionay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionay', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dictionay.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionay_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Dictionay_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionay] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionay].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionay] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionay] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionay] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionay] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionay] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionay] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionay] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionay] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionay] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionay] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionay] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionay] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionay] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionay] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionay] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionay] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionay] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionay] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionay] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionay] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionay] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionay] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionay] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Dictionay] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionay] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionay] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionay] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionay] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionay] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Dictionay]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[Explanation_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[Explanation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[Explanation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hypernyms]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernyms](
	[Hypernym_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[Hyponym_id] [int] NOT NULL,
 CONSTRAINT [PK_Hypernyms] PRIMARY KEY CLUSTERED 
(
	[Hypernym_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hyponyms]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hyponyms](
	[Hyponym_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[Hypernym_id] [int] NOT NULL,
 CONSTRAINT [PK_Hyponyms] PRIMARY KEY CLUSTERED 
(
	[Hyponym_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Language_id] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Language_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeach]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeach](
	[Part_id] [int] NOT NULL,
	[Explanation] [nvarchar](150) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[Entry_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[Synonym_id] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[Entry_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[Translation_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[Translation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[Translation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[Word_id] [int] NOT NULL,
	[Language_id] [int] NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[Translation_id] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[Word_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsInOtherLanguage]    Script Date: 24.8.2014 г. 16:27:23 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsInOtherLanguage](
	[Entry_id] [int] NOT NULL,
	[Word_id] [int] NOT NULL,
	[OtherWord_id] [int] NOT NULL,
 CONSTRAINT [PK_WordsInOtherLanguage] PRIMARY KEY CLUSTERED 
(
	[Entry_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([Word_id])
REFERENCES [dbo].[Words] ([Word_id])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([Word_id])
REFERENCES [dbo].[Words] ([Word_id])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([Word_id])
REFERENCES [dbo].[Words] ([Word_id])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([Language_id])
REFERENCES [dbo].[Languages] ([Language_id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations] FOREIGN KEY([Translation_id])
REFERENCES [dbo].[Translations] ([Translation_id])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Translations]
GO
ALTER TABLE [dbo].[WordsInOtherLanguage]  WITH CHECK ADD  CONSTRAINT [FK_WordsInOtherLanguage_Synonyms] FOREIGN KEY([Entry_id])
REFERENCES [dbo].[Synonyms] ([Entry_id])
GO
ALTER TABLE [dbo].[WordsInOtherLanguage] CHECK CONSTRAINT [FK_WordsInOtherLanguage_Synonyms]
GO
ALTER TABLE [dbo].[WordsInOtherLanguage]  WITH CHECK ADD  CONSTRAINT [FK_WordsInOtherLanguage_Words] FOREIGN KEY([Word_id])
REFERENCES [dbo].[Words] ([Word_id])
GO
ALTER TABLE [dbo].[WordsInOtherLanguage] CHECK CONSTRAINT [FK_WordsInOtherLanguage_Words]
GO
USE [master]
GO
ALTER DATABASE [Dictionay] SET  READ_WRITE 
GO
