USE [master]
GO
/****** Object:  Database [QLDeTai]    Script Date: 5/12/2019 11:32:59 PM ******/
CREATE DATABASE [QLDeTai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDeTai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.THUTHUY\MSSQL\DATA\QLDeTai.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLDeTai_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.THUTHUY\MSSQL\DATA\QLDeTai_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLDeTai] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDeTai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDeTai] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDeTai] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDeTai] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDeTai] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDeTai] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDeTai] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLDeTai] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLDeTai] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDeTai] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDeTai] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDeTai] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDeTai] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDeTai] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDeTai] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDeTai] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDeTai] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLDeTai] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDeTai] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDeTai] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDeTai] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDeTai] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDeTai] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDeTai] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDeTai] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLDeTai] SET  MULTI_USER 
GO
ALTER DATABASE [QLDeTai] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDeTai] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDeTai] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDeTai] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLDeTai]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BranchID] [bigint] NULL,
	[FacultyName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Function]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FunctionName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FunctionRoleRelationship]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FunctionRoleRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [bigint] NULL,
	[FunctionID] [bigint] NULL,
 CONSTRAINT [PK_Quyen_CV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Practice]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Practice](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[PracticeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Practice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PracticeType]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PracticeType](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SemesterID] [bigint] NULL,
	[PracticeID] [bigint] NULL,
 CONSTRAINT [PK_ThucTap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](500) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Scores]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TopicStudentID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
	[CompanyScore] [real] NULL,
	[TeacherScore] [real] NULL,
	[ReportScore] [real] NULL,
	[TotalScore] [real] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_DiemTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SemesterName] [nvarchar](50) NULL,
 CONSTRAINT [PK_HocKy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSV] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](255) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [char](10) NULL,
	[Password] [nvarchar](500) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentPracticeRelationship]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentPracticeRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_SinhVien] [bigint] NULL,
	[ID_TT] [bigint] NULL,
 CONSTRAINT [PK_SinhVienTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentTeacherRelationship]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTeacherRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[TeacherID] [bigint] NULL,
 CONSTRAINT [PK_PhanCongGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](100) NULL,
 CONSTRAINT [PK_BoMon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaGV] [nvarchar](20) NULL,
	[SubjectID] [bigint] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Password] [nvarchar](50) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_GiangVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeacherRoleRelationship]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherRoleRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherID] [bigint] NULL,
	[RoleID] [bigint] NULL,
 CONSTRAINT [PK_ChucVuGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topic]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
	[TopicName] [nvarchar](500) NULL,
	[Description] [nvarchar](500) NULL,
	[Status] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DeTai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TopicStudent]    Script Date: 5/12/2019 11:32:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicStudent](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentPracticeID] [bigint] NULL,
	[TopicID] [bigint] NULL,
	[Order] [int] NULL,
	[Status] [bit] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
 CONSTRAINT [PK_DeTaiSinhVienTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([ID], [BranchName]) VALUES (1, N'Công nghệ thông tin')
SET IDENTITY_INSERT [dbo].[Branch] OFF
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([ID], [BranchID], [FacultyName]) VALUES (1, 1, N'K56')
INSERT [dbo].[Faculty] ([ID], [BranchID], [FacultyName]) VALUES (2, 1, N'K57')
INSERT [dbo].[Faculty] ([ID], [BranchID], [FacultyName]) VALUES (3, 1, N'K58')
INSERT [dbo].[Faculty] ([ID], [BranchID], [FacultyName]) VALUES (4, 1, N'K59')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
SET IDENTITY_INSERT [dbo].[Function] ON 

INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (1, N'Chốt đề tài')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (2, N'Thêm, Sửa,Xóa đề tài')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (3, N'Xem danh sách hướng dẫn')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (4, N'Thêm, Sửa, Xóa điểm')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (5, N'Phân Bộ Môn')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (6, N'Thêm, Sửa , Xóa Danh sách thực tập')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (7, N'Thêm, Sửa , Xóa Danh sách sinh viên')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (8, N'Thêm, Sửa , Xóa Danh sách Giảng viên')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (9, N'Xem danh sách sinh viên bộ môn')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (10, N'Xem danh sách sinh viên bộ môn')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (11, N'Phân giáo viên hướng dẫn ')
SET IDENTITY_INSERT [dbo].[Function] OFF
SET IDENTITY_INSERT [dbo].[FunctionRoleRelationship] ON 

INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (1, 1, 9)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (2, 1, 10)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (3, 1, 11)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (4, 2, 4)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (5, 2, 5)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (6, 2, 6)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (7, 2, 7)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (8, 2, 8)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (9, 3, 1)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (10, 3, 2)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (11, 3, 3)
SET IDENTITY_INSERT [dbo].[FunctionRoleRelationship] OFF
SET IDENTITY_INSERT [dbo].[Practice] ON 

INSERT [dbo].[Practice] ([ID], [PracticeName]) VALUES (1, N'Thực tập cơ sở')
INSERT [dbo].[Practice] ([ID], [PracticeName]) VALUES (2, N'Thực tập chuyên ngành')
INSERT [dbo].[Practice] ([ID], [PracticeName]) VALUES (3, N'Thực tập tốt nghiệp')
INSERT [dbo].[Practice] ([ID], [PracticeName]) VALUES (4, N'Đồ án tốt nghiệp')
SET IDENTITY_INSERT [dbo].[Practice] OFF
SET IDENTITY_INSERT [dbo].[PracticeType] ON 

INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (1, 1, 1)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (2, 1, 2)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (3, 1, 3)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (5, 2, 1)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (6, 2, 2)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (7, 2, 3)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (8, 2, 4)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (9, 3, 1)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (10, 3, 2)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (11, 3, 3)
SET IDENTITY_INSERT [dbo].[PracticeType] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (1, N'Trưởng Bộ Môn')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (2, N'Trợ Lý Đào Tạo')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (3, N'Giảng Viên')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (1, N'2018_2019_1')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (2, N'2018_2019_2')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (3, N'2018_2019_3')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (1, N'155D4802010023', N'Đinh Thị Thu', N'Thủy', 1, CAST(0x4C200B00 AS Date), N'Hồng Lĩnh, Hà Tĩnh', N'dinhthithuthuy2105@gmail.com', N'0989358038', N'064024a0c9616c39cbdbc6b94dbac143', N'ndjncvfvnv', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] ON 

INSERT [dbo].[StudentPracticeRelationship] ([ID], [ID_SinhVien], [ID_TT]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] ON 

INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (1, N'Hệ thống và mạng máy tính')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (2, N'Khoa học máy tính và công nghệ phần mềm')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (1, N'123456789', 1, N'Cao Thanh', N'Sơn', 0, CAST(0xCF070B00 AS Date), N'Nghệ An', N'ctsdhv@gmail.com', N'0989123654', N'4e6fd0efba6accb969183e995cb4e8a2', N'hsgdusf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (2, N'12345678', 1, N'Lê Quốc', N'Anh', 0, CAST(0x20050B00 AS Date), N'Nghệ An', N'lqadhv@gmail.com', N'0123489021', N'1c2c10472cab4f51923bbdfd2b4ad488', N'hgfuewhf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (3, N'1234567', 1, N'Nguyễn Thị ', N'Uyên', 1, CAST(0xD00C0B00 AS Date), N'Nghệ An', N'ntudhv@gmail.com', N'0389046791', N'c650b048054ad56d58eba209bbf6eba2', N'dhytjuy', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[TeacherRoleRelationship] ON 

INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID]) VALUES (1, 1, 1)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID]) VALUES (2, 1, 3)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID]) VALUES (3, 2, 2)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID]) VALUES (4, 2, 3)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID]) VALUES (5, 3, 3)
SET IDENTITY_INSERT [dbo].[TeacherRoleRelationship] OFF
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (1, 2, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (2, 2, 6, N'123', N'123', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10002, 2, 11, N'ok', N'ok', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10003, 2, 1, N'oki', N'aaaaaaaaaaaaaaa', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10004, 2, 1, N'abc', N'11', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10005, 2, 1, N'abc', N'abc', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10006, 2, 1, N'123', N'1', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10007, 2, 1, N'hi', N'ok', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10008, 2, 1, N'hi', N'ok', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10009, 2, 5, N'sfdf', N'tthrt', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10010, 2, 9, N'dsefg', N'faeret', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10011, 2, 1, N'1234', N'ssfef', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10012, 2, 1, N'12345', N'dfef', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10013, 2, 1, N'saferfre', N'sferf', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10014, 1, 5, N'oki', N'aaaaa', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10015, 1, 1, N'123', N'111111111111111111111', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10016, 1, 1, N'345', N'aaaaaaaaaaa', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10017, 1, 1, N'Hệ thống quản lý đề tài thực tập', N'C#', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10018, 1, 1, N'Quản lý quán cà phê', N'C# winform', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10019, 1, 5, N'xcsd', N'vdvfd', 1, 1)
SET IDENTITY_INSERT [dbo].[Topic] OFF
SET IDENTITY_INSERT [dbo].[TopicStudent] ON 

INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (1, 1, 10003, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (2, 1, 10015, 1, NULL, NULL, CAST(0x0000AA4901586B5F AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (3, 1, 10016, 2, NULL, NULL, CAST(0x0000AA4901586C4C AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (4, 1, 10015, 1, NULL, NULL, CAST(0x0000AA4901587342 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (5, 1, 10016, 2, NULL, NULL, CAST(0x0000AA4901587348 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (6, 1, 10015, 1, NULL, NULL, CAST(0x0000AA49015890C7 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (7, 1, 10016, 2, NULL, NULL, CAST(0x0000AA49015890CB AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (8, 1, 10016, 1, NULL, NULL, CAST(0x0000AA4A01855F91 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (9, 1, 10018, 2, NULL, NULL, CAST(0x0000AA4A0185602D AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TopicStudent] OFF
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Khoa_Nganh] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([ID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Khoa_Nganh]
GO
ALTER TABLE [dbo].[FunctionRoleRelationship]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_CV_ChucVu] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[FunctionRoleRelationship] CHECK CONSTRAINT [FK_Quyen_CV_ChucVu]
GO
ALTER TABLE [dbo].[FunctionRoleRelationship]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_CV_Quyen] FOREIGN KEY([FunctionID])
REFERENCES [dbo].[Function] ([ID])
GO
ALTER TABLE [dbo].[FunctionRoleRelationship] CHECK CONSTRAINT [FK_Quyen_CV_Quyen]
GO
ALTER TABLE [dbo].[PracticeType]  WITH CHECK ADD  CONSTRAINT [FK_PracticeType_Practice] FOREIGN KEY([PracticeID])
REFERENCES [dbo].[Practice] ([ID])
GO
ALTER TABLE [dbo].[PracticeType] CHECK CONSTRAINT [FK_PracticeType_Practice]
GO
ALTER TABLE [dbo].[PracticeType]  WITH CHECK ADD  CONSTRAINT [FK_ThucTap_HocKy] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([ID])
GO
ALTER TABLE [dbo].[PracticeType] CHECK CONSTRAINT [FK_ThucTap_HocKy]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_DiemTT_DeTaiSinhVienTT] FOREIGN KEY([TopicStudentID])
REFERENCES [dbo].[TopicStudent] ([ID])
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_DiemTT_DeTaiSinhVienTT]
GO
ALTER TABLE [dbo].[StudentPracticeRelationship]  WITH CHECK ADD  CONSTRAINT [FK_SinhVienTT_SinhVien] FOREIGN KEY([ID_SinhVien])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentPracticeRelationship] CHECK CONSTRAINT [FK_SinhVienTT_SinhVien]
GO
ALTER TABLE [dbo].[StudentTeacherRelationship]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongGV_GiangVien] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacherRelationship] CHECK CONSTRAINT [FK_PhanCongGV_GiangVien]
GO
ALTER TABLE [dbo].[StudentTeacherRelationship]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongGV_SinhVien] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentTeacherRelationship] CHECK CONSTRAINT [FK_PhanCongGV_SinhVien]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_GiangVien_BoMon] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_GiangVien_BoMon]
GO
ALTER TABLE [dbo].[TeacherRoleRelationship]  WITH CHECK ADD  CONSTRAINT [FK_ChucVuGV_ChucVu] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[TeacherRoleRelationship] CHECK CONSTRAINT [FK_ChucVuGV_ChucVu]
GO
ALTER TABLE [dbo].[TeacherRoleRelationship]  WITH CHECK ADD  CONSTRAINT [FK_ChucVuGV_GiangVien] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[TeacherRoleRelationship] CHECK CONSTRAINT [FK_ChucVuGV_GiangVien]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_DeTai_GiangVien] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_DeTai_GiangVien]
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_DeTai_ThucTap] FOREIGN KEY([PracticeTypeID])
REFERENCES [dbo].[PracticeType] ([ID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_DeTai_ThucTap]
GO
ALTER TABLE [dbo].[TopicStudent]  WITH CHECK ADD  CONSTRAINT [FK_DeTaiSinhVienTT_DeTai] FOREIGN KEY([TopicID])
REFERENCES [dbo].[Topic] ([ID])
GO
ALTER TABLE [dbo].[TopicStudent] CHECK CONSTRAINT [FK_DeTaiSinhVienTT_DeTai]
GO
ALTER TABLE [dbo].[TopicStudent]  WITH CHECK ADD  CONSTRAINT [FK_DeTaiSinhVienTT_SinhVienTT] FOREIGN KEY([StudentPracticeID])
REFERENCES [dbo].[StudentPracticeRelationship] ([ID])
GO
ALTER TABLE [dbo].[TopicStudent] CHECK CONSTRAINT [FK_DeTaiSinhVienTT_SinhVienTT]
GO
USE [master]
GO
ALTER DATABASE [QLDeTai] SET  READ_WRITE 
GO
