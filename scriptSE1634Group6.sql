
--CREATE DATABASE [SE1634_Group6_Project]
use [SE1634_Group6_Project]
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userName] [nvarchar](50) NOT NULL primary key,
	[password] [nvarchar](50) NOT NULL,
	[role] [int] not null,
)

CREATE TABLE [dbo].[Songs](
	[songNumber] [int] IDENTITY(1,1) NOT NULL primary key,
	[name] [nvarchar](100) NOT NULL,
	[author] [nvarchar](50) NOT NULL,
	[audioPath] [nvarchar](50) NOT NULL,
	[lyric] [nvarchar](1000) NULL,
	[imgPath] [nchar](50) NULL,
	[isHide] [bit] not null,
	FOREIGN KEY ([author]) REFERENCES [Users] ([userName]),
)

CREATE TABLE [dbo].[Lists](
	[listNumber] [int] IDENTITY(1,1) NOT NULL primary key,
	[author] [nvarchar](50) NOT NULL,
	[title] [nvarchar](200) NOT NULL,
	FOREIGN KEY ([author]) REFERENCES [Users] ([userName]),
)

CREATE TABLE [dbo].[List_Song](
	[listNumber] [int] NOT NULL,
	[songNumber] [int] NOT NULL,
	[dateAdded] [datetime] NULL,
	primary key ([listNumber],[songNumber]),
	FOREIGN KEY ([listNumber]) REFERENCES [Lists] ([listNumber]),
	FOREIGN KEY ([songNumber]) REFERENCES [Songs] ([songNumber])
)
INSERT [dbo].[Users] ([userName], [password], [role]) VALUES (N'admin', N'admin', 1)
INSERT [dbo].[Users] ([userName], [password], [role]) VALUES (N'nhat', N'nhat', 2)

SET IDENTITY_INSERT [dbo].[Songs] ON 
INSERT [dbo].[Songs] ([songNumber], [name], [author], [audioPath], [lyric], [imgPath], [isHide]) VALUES (21, N'nhac cua nhat', N'admin', N'sample3.mp3', N'nhac cua nhat nhac cua nhat 
nhac cua nhat
nhac cua nhatnhac cua nhatnhac cua nhat', N'a.jpg                                             ', 0)
INSERT [dbo].[Songs] ([songNumber], [name], [author], [audioPath], [lyric], [imgPath], [isHide]) VALUES (29, N'nhac 2', N'nhat', N'sample-15s.mp3', N'nhac 2
nhac 2nhac 2nhac 2
nhac 2nhac 2', N'rrrr.jpg                                          ', 0)
SET IDENTITY_INSERT [dbo].[Songs] OFF

SET IDENTITY_INSERT [dbo].[Lists] ON 
INSERT [dbo].[Lists] ([listNumber], [author], [title]) VALUES (6, N'admin', N'default')
INSERT [dbo].[Lists] ([listNumber], [author], [title]) VALUES (11, N'nhat', N'falorite list')
SET IDENTITY_INSERT [dbo].[Lists] OFF

INSERT [dbo].[List_Song] ([listNumber], [songNumber], [dateAdded]) VALUES (6, 21, NULL)

