USE [master]
GO
/****** Object:  Database [ZEMOGA_TEST]    Script Date: 2/9/2023 11:10:04 PM ******/
CREATE DATABASE [ZEMOGA_TEST]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ZEMOGA_TEST', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZEMOGA_TEST.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ZEMOGA_TEST_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ZEMOGA_TEST_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ZEMOGA_TEST] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ZEMOGA_TEST].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ZEMOGA_TEST] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ARITHABORT OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ZEMOGA_TEST] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ZEMOGA_TEST] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ZEMOGA_TEST] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ZEMOGA_TEST] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET RECOVERY FULL 
GO
ALTER DATABASE [ZEMOGA_TEST] SET  MULTI_USER 
GO
ALTER DATABASE [ZEMOGA_TEST] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ZEMOGA_TEST] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ZEMOGA_TEST] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ZEMOGA_TEST] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ZEMOGA_TEST] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ZEMOGA_TEST] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ZEMOGA_TEST', N'ON'
GO
ALTER DATABASE [ZEMOGA_TEST] SET QUERY_STORE = OFF
GO
USE [ZEMOGA_TEST]
GO
/****** Object:  Table [dbo].[COMMENT]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMENT](
	[id_comment] [int] IDENTITY(1,1) NOT NULL,
	[text_comment] [varchar](max) NOT NULL,
	[id_post] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[comment_type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_comment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COMMENT_TYPE]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COMMENT_TYPE](
	[id_comment_type] [int] IDENTITY(1,1) NOT NULL,
	[type_description] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_comment_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POST]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POST](
	[id_post] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[content_text] [varchar](max) NOT NULL,
	[publication_date] [datetime] NULL,
	[id_user] [int] NOT NULL,
	[state_post] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_post] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POST_STATE]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POST_STATE](
	[id_state] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](30) NULL,
 CONSTRAINT [PK_POST_STATE] PRIMARY KEY CLUSTERED 
(
	[id_state] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ROL]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[name_rol] [varchar](20) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 2/9/2023 11:10:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[id_rol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[COMMENT] ON 

INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (6, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 13, 2, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (7, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 13, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (8, N'This post is rejected', 13, 5, 2)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (10, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 10, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (11, N'This post is rejected', 1004, 5, 2)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (12, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 14, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (13, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 14, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (14, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 34, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (15, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 35, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (16, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1003, 1, 1)
INSERT [dbo].[COMMENT] ([id_comment], [text_comment], [id_post], [id_user], [comment_type]) VALUES (17, N'Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1003, 7, 1)
SET IDENTITY_INSERT [dbo].[COMMENT] OFF
GO
SET IDENTITY_INSERT [dbo].[COMMENT_TYPE] ON 

INSERT [dbo].[COMMENT_TYPE] ([id_comment_type], [type_description]) VALUES (1, N'public')
INSERT [dbo].[COMMENT_TYPE] ([id_comment_type], [type_description]) VALUES (2, N'rejected')
SET IDENTITY_INSERT [dbo].[COMMENT_TYPE] OFF
GO
SET IDENTITY_INSERT [dbo].[POST] ON 

INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (8, N'Water', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2022-01-01T00:00:00.000' AS DateTime), 2, 1)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (9, N'Fire', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 1)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (10, N'Air', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (11, N'Cat', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 4)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (12, N'Dog', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 4)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (13, N'Ball', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (14, N'Bear', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (29, N'Wolf', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 4)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (30, N'Lion', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 1)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (31, N'Gorilla', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 1)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (32, N'Tiger', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 4)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (33, N'Snake', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 4)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (34, N'Squirrel', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (35, N'Crocodile', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 7, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (1002, N'Car', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 1)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (1003, N'cow', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 3)
INSERT [dbo].[POST] ([id_post], [title], [content_text], [publication_date], [id_user], [state_post]) VALUES (1004, N'Horse', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat', CAST(N'2023-02-08T18:02:15.480' AS DateTime), 2, 3)
SET IDENTITY_INSERT [dbo].[POST] OFF
GO
SET IDENTITY_INSERT [dbo].[POST_STATE] ON 

INSERT [dbo].[POST_STATE] ([id_state], [description]) VALUES (1, N'Created')
INSERT [dbo].[POST_STATE] ([id_state], [description]) VALUES (2, N'Pending Approval')
INSERT [dbo].[POST_STATE] ([id_state], [description]) VALUES (3, N'Published')
INSERT [dbo].[POST_STATE] ([id_state], [description]) VALUES (4, N'Rejected')
SET IDENTITY_INSERT [dbo].[POST_STATE] OFF
GO
SET IDENTITY_INSERT [dbo].[ROL] ON 

INSERT [dbo].[ROL] ([id_rol], [name_rol], [active]) VALUES (1, N'Public', 1)
INSERT [dbo].[ROL] ([id_rol], [name_rol], [active]) VALUES (2, N'Writer', 1)
INSERT [dbo].[ROL] ([id_rol], [name_rol], [active]) VALUES (4, N'Editor', 1)
SET IDENTITY_INSERT [dbo].[ROL] OFF
GO
SET IDENTITY_INSERT [dbo].[USER] ON 

INSERT [dbo].[USER] ([id_user], [user_name], [password], [id_rol]) VALUES (1, N'Will', N'123', 1)
INSERT [dbo].[USER] ([id_user], [user_name], [password], [id_rol]) VALUES (2, N'Jose', N'123', 2)
INSERT [dbo].[USER] ([id_user], [user_name], [password], [id_rol]) VALUES (5, N'Pepe', N'123', 4)
INSERT [dbo].[USER] ([id_user], [user_name], [password], [id_rol]) VALUES (7, N'pablo', N'123', 2)
SET IDENTITY_INSERT [dbo].[USER] OFF
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD FOREIGN KEY([id_post])
REFERENCES [dbo].[POST] ([id_post])
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[USER] ([id_user])
GO
ALTER TABLE [dbo].[COMMENT]  WITH CHECK ADD  CONSTRAINT [FK_CommentType] FOREIGN KEY([comment_type])
REFERENCES [dbo].[COMMENT_TYPE] ([id_comment_type])
GO
ALTER TABLE [dbo].[COMMENT] CHECK CONSTRAINT [FK_CommentType]
GO
ALTER TABLE [dbo].[POST]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[USER] ([id_user])
GO
ALTER TABLE [dbo].[POST]  WITH CHECK ADD FOREIGN KEY([state_post])
REFERENCES [dbo].[POST_STATE] ([id_state])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([id_rol])
REFERENCES [dbo].[ROL] ([id_rol])
GO
USE [master]
GO
ALTER DATABASE [ZEMOGA_TEST] SET  READ_WRITE 
GO
