USE [master]
GO
/****** Object:  Database [QLDeTai]    Script Date: 5/27/2019 11:10:36 AM ******/
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
/****** Object:  Table [dbo].[Branch]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Faculty]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Function]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[FunctionRoleRelationship]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Practice]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[PracticeType]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Scores]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Semester]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 5/27/2019 11:10:37 AM ******/
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
	[FacultyID] [bigint] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentPracticeRelationship]    Script Date: 5/27/2019 11:10:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentPracticeRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
 CONSTRAINT [PK_SinhVienTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentSubjectRelationship]    Script Date: 5/27/2019 11:10:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentSubjectRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[SubjectID] [bigint] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_StudentSubjectRelationship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentTeacherRelationship]    Script Date: 5/27/2019 11:10:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentTeacherRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[TeacherID] [bigint] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_PhanCongGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[TeacherRoleRelationship]    Script Date: 5/27/2019 11:10:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherRoleRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherID] [bigint] NULL,
	[RoleID] [bigint] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_ChucVuGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topic]    Script Date: 5/27/2019 11:10:37 AM ******/
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
/****** Object:  Table [dbo].[TopicStudent]    Script Date: 5/27/2019 11:10:37 AM ******/
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
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (10, N'Xem danh sách giảng viên bộ môn')
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
SET IDENTITY_INSERT [dbo].[Scores] ON 

INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 20, 6, 9, 9, 8.5, 9, 2, CAST(0x0000AA59013B9481 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 10019, 1, 8, 8, 8.5, 8, 2, CAST(0x0000AA590142075F AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Scores] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (1, N'2018_2019_1')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (2, N'2018_2019_2')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (3, N'2018_2019_3')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (16, N'155D4802010023', N'Đinh Thị Thu ', N'Thủy', 1, CAST(0x4C200B00 AS Date), N'Hồng Lĩnh, Hà Tĩnh', N'dinhthithuthuy2105@gmail.com', N'0395824215', N'064024a0c9616c39cbdbc6b94dbac143', N'ndjncvfvnv', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (17, N'155D4802010033', N'Lê Thị ', N'Huyền', 1, CAST(0x8A200B00 AS Date), N'Hoàng Mai,Nghệ An', N'huyenle220797@gmail.com', N'0968126718', N'8511533635f950e7e09af7aeefa349f8', N'dsbtghb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (18, N'155D4802010018', N'Hoàng Thị ', N'Bích', 1, CAST(0x21210B00 AS Date), N'Nghệ An', N'Bichhoangdhv@gmail.com', N'0378901986', N'99e907a83f5cfda69d7babff2bc46b70', N'jshdehd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (19, N'155D4802010167', N'Bùi Thị Tú', N'Anh', 1, CAST(0xBA200B00 AS Date), N'Nghệ An', N'tuanh@gmail.com', N'0361678086', N'6ed19281a0918c4ade65ba5d07d998e4', N'bdjscsl', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (20, N'155D4802010093', N'Phan Văn', N'Anh', 0, CAST(0xEF1F0B00 AS Date), N'Hà Tĩnh', N'vananh@gmail.com', N'0398760124', N'26625b4db7679ceec2db137687392113', N'sgthkiu', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (21, N'165D4802010201', N'Nguyễn Văn', N'An', NULL, CAST(0x11220B00 AS Date), N'Nghệ An', N'nva1308@gmai.com', N'14567890  ', N'04c37e965650fde391bffeca48b54ade', N'YV75lTsjhf', NULL, CAST(0x0000AA5801593C11 AS DateTime), 2, CAST(0x0000AA58016A8522 AS DateTime), NULL, NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] ON 

INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (4, 19, 6)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (5, 20, 6)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (6, 16, 6)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (7, 17, 6)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (8, 18, 6)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID]) VALUES (9, 21, 1)
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] ON 

INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (26, 16, 1, 2, CAST(0x0000AA58002327FD AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (27, 17, 1, 2, CAST(0x0000AA5800232829 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (28, 18, 1, 2, CAST(0x0000AA580023282A AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (29, 19, 1, 2, CAST(0x0000AA5800232830 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (30, 20, 1, 2, CAST(0x0000AA5800232832 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (31, 21, 1, 2, CAST(0x0000AA59013F94EF AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] ON 

INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 16, 1, 1, CAST(0x0000AA580023EEA6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (6, 17, 1, 1, CAST(0x0000AA580023EED4 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (7, 18, 1, 1, CAST(0x0000AA5801719D11 AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (8, 19, 2, 1, CAST(0x0000AA58002403DD AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (9, 20, 3, 1, CAST(0x0000AA5800240B95 AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10, 21, 2, 1, CAST(0x0000AA59013FB62C AS DateTime), NULL, NULL, NULL, NULL, NULL)
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

INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (1, 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (2, 1, 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (3, 2, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 2, 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 3, 3, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TeacherRoleRelationship] OFF
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10022, 2, 2, N'123', N'123', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10023, 2, 6, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý đề tài thực tập', N'Xây dựng hệ thống quản lý đề tài thực tập cho khoa công nghệ thông tin ', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10024, 2, 6, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý bệnh viện', N'Xây dựng hệ thống quản lý bệnh viện, trong việc khám bệnh cũng như quản lý các bác sỹ, y tá', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10025, 1, 6, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý đề tài thực tập', N'Xây dựng hệ thống quản lý đề tài thực tập của sinh viên ngành CNTT', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10026, 1, 6, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý cà phê', N'Xây dựng hệ thống quản lý bán hàng và thanh toán in hóa đơn cho quán cà phê', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20023, 2, 1, N'Hình thành ý tưởng, thiết kế, triển khai website ẩm thực', N'Xây dựng website ẩm thực thành vinh dựa trên mã nguồn mở wordpress', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20024, 2, 1, N'Hình thành ý tưởng, thiết kế, triển khai website du lịch nghệ an', N'Xây dựng website quảng bá về các địa điểm du lịch ở nghệ an dựa trên mã nguồn mở wordpress', 1, NULL)
SET IDENTITY_INSERT [dbo].[Topic] OFF
SET IDENTITY_INSERT [dbo].[TopicStudent] ON 

INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (18, 7, 10025, 1, 1, NULL, CAST(0x0000AA58017B0A4F AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (19, 7, 10026, 2, NULL, NULL, CAST(0x0000AA58017B0A93 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (20, 6, 10026, 1, 1, NULL, CAST(0x0000AA58017B2FFF AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (21, 6, 10025, 2, NULL, NULL, CAST(0x0000AA58017B3002 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10018, 9, 20023, 1, NULL, NULL, CAST(0x0000AA590140F963 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10019, 9, 20024, 2, 1, NULL, CAST(0x0000AA590140F971 AS DateTime), NULL, NULL)
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
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Faculty] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Faculty]
GO
ALTER TABLE [dbo].[StudentPracticeRelationship]  WITH CHECK ADD  CONSTRAINT [FK_SinhVienTT_SinhVien] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentPracticeRelationship] CHECK CONSTRAINT [FK_SinhVienTT_SinhVien]
GO
ALTER TABLE [dbo].[StudentSubjectRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubjectRelationship_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentSubjectRelationship] CHECK CONSTRAINT [FK_StudentSubjectRelationship_Student]
GO
ALTER TABLE [dbo].[StudentSubjectRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentSubjectRelationship_Subject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[StudentSubjectRelationship] CHECK CONSTRAINT [FK_StudentSubjectRelationship_Subject]
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
