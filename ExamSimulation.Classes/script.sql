USE [master]
GO
/****** Object:  Database [BachelorParty]    Script Date: 09/07/2018 22:58:25 ******/
CREATE DATABASE [BachelorParty]
 CONTAINMENT = NONE
 ON  PRIMARY
( NAME = N'AddioCelibato', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\AddioCelibato.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON
( NAME = N'AddioCelibato_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\AddioCelibato_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BachelorParty] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BachelorParty].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BachelorParty] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BachelorParty] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BachelorParty] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BachelorParty] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BachelorParty] SET ARITHABORT OFF
GO
ALTER DATABASE [BachelorParty] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BachelorParty] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BachelorParty] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BachelorParty] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BachelorParty] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BachelorParty] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BachelorParty] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BachelorParty] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BachelorParty] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BachelorParty] SET  DISABLE_BROKER
GO
ALTER DATABASE [BachelorParty] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BachelorParty] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BachelorParty] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BachelorParty] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BachelorParty] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BachelorParty] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BachelorParty] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BachelorParty] SET RECOVERY SIMPLE
GO
ALTER DATABASE [BachelorParty] SET  MULTI_USER
GO
ALTER DATABASE [BachelorParty] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BachelorParty] SET DB_CHAINING OFF
GO
ALTER DATABASE [BachelorParty] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [BachelorParty] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO
ALTER DATABASE [BachelorParty] SET DELAYED_DURABILITY = DISABLED
GO
ALTER DATABASE [BachelorParty] SET QUERY_STORE = OFF
GO
USE [BachelorParty]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BachelorParty]
GO
/****** Object:  Table [dbo].[Activities]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Place] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DateList]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DateList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_DateList] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizer]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdDateList] [int] NOT NULL,
	[IdActivity] [int] NOT NULL,
 CONSTRAINT [PK_Organizer] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUser](
	[IdTypeUser] [int] IDENTITY(1,1) NOT NULL,
	[TypeUser] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TypeUser] PRIMARY KEY CLUSTERED
(
	[IdTypeUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Surname] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[IdTypeUser] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Activities] ON

INSERT [dbo].[Activities] ([Id], [Title], [Description], [Place]) VALUES (1, N'Cena                                                                                                                                                                                                                                                           ', N'Festaccia                                                                                                                                                                                                                                                      ', N'Torino                                                                                                                                                                                                                                                         ')
INSERT [dbo].[Activities] ([Id], [Title], [Description], [Place]) VALUES (4, N'Pinball                                                                                                                                                                                                                                                        ', N'Massacro                                                                                                                                                                                                                                                       ', N'Venaria                                                                                                                                                                                                                                                        ')
INSERT [dbo].[Activities] ([Id], [Title], [Description], [Place]) VALUES (5, N'Escort                                                                                                                                                                                                                                                         ', N'Sesso                                                                                                                                                                                                                                                          ', N'Aosta                                                                                                                                                                                                                                                          ')
SET IDENTITY_INSERT [dbo].[Activities] OFF
SET IDENTITY_INSERT [dbo].[DateList] ON

INSERT [dbo].[DateList] ([Id], [Date]) VALUES (1, CAST(N'2018-06-15' AS Date))
INSERT [dbo].[DateList] ([Id], [Date]) VALUES (2, CAST(N'2018-06-16' AS Date))
INSERT [dbo].[DateList] ([Id], [Date]) VALUES (3, CAST(N'2018-06-17' AS Date))
SET IDENTITY_INSERT [dbo].[DateList] OFF
SET IDENTITY_INSERT [dbo].[Organizer] ON

INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (2, 2, 1, 4)
INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (3, 3, 1, 1)
INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (4, 1, 3, 5)
INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (5, 2, 3, 1)
INSERT [dbo].[Organizer] ([Id], [IdUser], [IdDateList], [IdActivity]) VALUES (6, 3, 2, 5)
SET IDENTITY_INSERT [dbo].[Organizer] OFF
SET IDENTITY_INSERT [dbo].[TypeUser] ON

INSERT [dbo].[TypeUser] ([IdTypeUser], [TypeUser]) VALUES (1, N'Organizzatore                                                                                                                                                                                                                                                  ')
INSERT [dbo].[TypeUser] ([IdTypeUser], [TypeUser]) VALUES (2, N'Invitato                                                                                                                                                                                                                                                       ')
INSERT [dbo].[TypeUser] ([IdTypeUser], [TypeUser]) VALUES (3, N'Utente                                                                                                                                                                                                                                                         ')
SET IDENTITY_INSERT [dbo].[TypeUser] OFF
SET IDENTITY_INSERT [dbo].[Users] ON

INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (1, N'Admin                                                                                                                                                                                                                                                          ', N'Admin                                                                                                                                                                                                                                                          ', N'admin@admin.com                                                                                                                                                                                                                                                ', N'admin', 1)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (2, N'Utente                                                                                                                                                                                                                                                         ', N'Utente                                                                                                                                                                                                                                                         ', N'utente@utente.com                                                                                                                                                                                                                                              ', N'utente                                                                                                                                                                                                                                                         ', 3)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (3, N'Invitato                                                                                                                                                                                                                                                       ', N'Invitato                                                                                                                                                                                                                                                       ', N'invitato@invitato.com                                                                                                                                                                                                                                          ', N'invitato                                                                                                                                                                                                                                                       ', 2)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (10, N'pippoaaaaaa', N'pippo', N'pippo', N'pippo', 3)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (16, N'pippo00000', N'pippo', N'pippo', N'pippo', 3)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (17, N'pippoaaaaaaaaaaaaaaaaaaaaaaa', N'pippo', N'pippo', N'pippo', 3)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (18, N'pippo00000', N'pippo', N'pippo', N'pippo', 3)
INSERT [dbo].[Users] ([Id], [Name], [Surname], [Email], [Password], [IdTypeUser]) VALUES (21, N'pippo', N'pippo', N'pippo', N'pippo', 3)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Organizer]  WITH CHECK ADD  CONSTRAINT [FK_Organizer_Activities] FOREIGN KEY([IdActivity])
REFERENCES [dbo].[Activities] ([Id])
GO
ALTER TABLE [dbo].[Organizer] CHECK CONSTRAINT [FK_Organizer_Activities]
GO
ALTER TABLE [dbo].[Organizer]  WITH CHECK ADD  CONSTRAINT [FK_Organizer_DateList1] FOREIGN KEY([IdDateList])
REFERENCES [dbo].[DateList] ([Id])
GO
ALTER TABLE [dbo].[Organizer] CHECK CONSTRAINT [FK_Organizer_DateList1]
GO
ALTER TABLE [dbo].[Organizer]  WITH CHECK ADD  CONSTRAINT [FK_Organizer_Users] FOREIGN KEY([IdUser])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Organizer] CHECK CONSTRAINT [FK_Organizer_Users]
GO
/****** Object:  StoredProcedure [dbo].[DeleteActivity]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteActivity]
	@id int,
	@idDate int,
	@date datetime,
	@count int
AS
BEGIN
select @idDate = id from DateList where @date = Date
delete Organizer where IdActivity = @id and @idDate=IdDateList
select @count = count(*) from Organizer where IdActivity = @id
if(@count<=0)
delete Activities where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
delete [Users] where Id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActivity]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllActivity]
AS
BEGIN
SELECT a.*,d.Date
From Activities a inner join Organizer o on a.Id=o.IdActivity
inner join DateList d on d.Id=o.IdDateList
order by d.Date asc
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllActivityForUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllActivityForUser]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT d.Date, a.Title as 'Name Activity', a.Description as 'Description Activity', a.Place, u.Name, u.Surname
From Activities a inner join Organizer o on a.Id=o.IdActivity
inner join DateList d on d.Id=o.IdDateList
inner join Users u on u.Id = d.Id
inner join TypeUser t on t.IdTypeUser=u.IdTypeUser
order by d.Date asc
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUser]
AS
BEGIN
SELECT u.Id
      ,u.Name
      ,u.Surname
      ,u.Email
      ,u.Password
      ,t.TypeUser
  FROM Users u
  inner join TypeUser t
  on t.IdTypeUser = u.IdTypeUser
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUserWithIdTypeUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllUserWithIdTypeUser]
AS
BEGIN
	SET NOCOUNT ON;
SELECT *
  FROM Users
  END
GO
/****** Object:  StoredProcedure [dbo].[GetCountForDate]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCountForDate]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT COUNT(IdDateList) AS CountPartecipant,
  d.Date AS 'Date'
FROM Organizer o inner join DateList d on d.Id=o.IdDateList
GROUP BY d.Date
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserByEmailAndPassword]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByEmailAndPassword]
	@email nvarchar(255),
	@password nvarchar(255)
AS
BEGIN
	SELECT * FROM [Users] WHERE [Email] = @email and [Password] = @password
END
GO
/****** Object:  StoredProcedure [dbo].[InsertActivity]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertActivity]
	-- Add the parameters for the stored procedure here
	@title nvarchar(255),
	@description nvarchar(255),
	@place nvarchar(255),
	@date nvarchar(255),
	@count int
AS
BEGIN
insert into Activities(Title,Description,Place) values(@title,@description,@place)
select @count = count(id) from DateList where @date = Date
if(@count<=0)
insert into DateList(Date) values(@date)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertUser]
	-- Add the parameters for the stored procedure here
	@name nvarchar(255),
	@surname nvarchar(255),
	@email nvarchar(255),
	@password nvarchar(255),
	@idTypeUser int
AS
BEGIN
insert into [Users](Name,Surname,Email,Password,IdTypeUser) values(@name,@surname,@email,@password,@idTypeUser)
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 09/07/2018 22:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
	@id int,
	@name nvarchar(255),
	@surname nvarchar(255),
	@email nvarchar(255),
	@password nvarchar(255),
	@idTypeUser int
AS
BEGIN
update [Users] set Name=@name,Surname=@surname,Email=@email,Password=@password,IdTypeUser=@idTypeUser where Id=@id
END
GO
USE [master]
GO
ALTER DATABASE [BachelorParty] SET  READ_WRITE
GO
