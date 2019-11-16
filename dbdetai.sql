USE [master]
GO
/****** Object:  Database [QLDeTai]    Script Date: 11/16/2019 9:42:21 PM ******/
CREATE DATABASE [QLDeTai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDeTai', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.THUTHUY\MSSQL\DATA\QLDeTai.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
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
/****** Object:  Table [dbo].[Branch]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Faculty]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Field]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Field](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Field] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Function]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[FunctionRoleRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
	[Title] [nvarchar](500) NULL,
	[Content] [nvarchar](500) NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Practice]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[PracticeType]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ID] [bigint] NOT NULL,
	[StudentPracticeID] [bigint] NULL,
	[TeacherID] [bigint] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Scores]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Semester]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[StudentFieldRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentFieldRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[FieldID] [bigint] NULL,
 CONSTRAINT [PK_StudentFieldRelationship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentNotificationRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentNotificationRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[NotificationID] [bigint] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_StudentNotificationRelationship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentPracticeRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentPracticeRelationship](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[StudentID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
	[TeacherID] [bigint] NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifyBy] [bigint] NULL,
	[ModifyTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
 CONSTRAINT [PK_SinhVienTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentSubjectRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[StudentTeacherRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[TeacherRoleRelationship]    Script Date: 11/16/2019 9:42:21 PM ******/
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
/****** Object:  Table [dbo].[Topic]    Script Date: 11/16/2019 9:42:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TeacherID] [bigint] NULL,
	[PracticeTypeID] [bigint] NULL,
	[FieldID] [bigint] NULL,
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
/****** Object:  Table [dbo].[TopicStudent]    Script Date: 11/16/2019 9:42:21 PM ******/
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
	[Progress] [int] NULL,
	[Result] [bit] NULL,
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
SET IDENTITY_INSERT [dbo].[Field] ON 

INSERT [dbo].[Field] ([ID], [FieldName], [Description]) VALUES (1, N'Lập trình web', N'')
INSERT [dbo].[Field] ([ID], [FieldName], [Description]) VALUES (2, N'Khai phá dữ liệu', N'')
SET IDENTITY_INSERT [dbo].[Field] OFF
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
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (12, N'Thêm, Sửa, Xóa thông báo')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (13, N'Xem danh sách đề tài')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (14, N'Xem list thực tập')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (15, N'Xem list điểm')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (16, N'Xem list đề tài')
INSERT [dbo].[Function] ([ID], [FunctionName]) VALUES (10014, N'Phân hội đồng chấm thi')
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
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (12, 3, 12)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (13, 1, 13)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (14, 4, 14)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (15, 4, 15)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (16, 4, 16)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (17, 5, 14)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (18, 5, 15)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (19, 5, 16)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (20, 1, 14)
INSERT [dbo].[FunctionRoleRelationship] ([ID], [RoleID], [FunctionID]) VALUES (10015, 10005, 10014)
SET IDENTITY_INSERT [dbo].[FunctionRoleRelationship] OFF
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (1, 2, 1, NULL, N'aaaaaaaaaaaaaaaaa', 2, CAST(0x0000AA77016C51C8 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA77017E4250 AS DateTime))
INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (2, 2, 1, NULL, N'aaaaaaaaaaaaaaaaa', 2, CAST(0x0000AA77016C655C AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA780081EB6B AS DateTime))
INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (3, 2, 1, NULL, N'bbbbbbbbbbbbbbbbb', 2, CAST(0x0000AA77017866A7 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 2, 1, N'cccccccc', N'chaha', 2, CAST(0x0000AA77017CB7D3 AS DateTime), NULL, CAST(0x0000AA7800B5B41D AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 2, 1, N'BCTD đợt 1', N'ok', 2, CAST(0x0000AA770180FBE2 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Notification] ([ID], [TeacherID], [PracticeTypeID], [Title], [Content], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (6, 2, 6, N'BCTD đợt I', N'aaaaaaaaaaaaaaaaaa', 2, CAST(0x0000AA7701818FD1 AS DateTime), NULL, CAST(0x0000AA770181FE93 AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Notification] OFF
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
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (15, 1, 4)
INSERT [dbo].[PracticeType] ([ID], [SemesterID], [PracticeID]) VALUES (16, 3, 4)
SET IDENTITY_INSERT [dbo].[PracticeType] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (1, N'Trưởng Bộ Môn')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (2, N'Trợ Lý Đào Tạo')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (3, N'Giảng Viên')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (4, N'Viện Trưởng')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (5, N'Viện Phó')
INSERT [dbo].[Role] ([ID], [RoleName]) VALUES (10005, N'Quản Lý')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Scores] ON 

INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 20, 6, 9, 9, 8.5, 9, 2, CAST(0x0000AA59013B9481 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 10019, 1, NULL, 8, NULL, NULL, 2, CAST(0x0000AA590142075F AS DateTime), 2, CAST(0x0000AA750148B4D9 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (7, 10021, 5, 9, 10, 8.5, 9, NULL, CAST(0x0000AAC80171DA4E AS DateTime), 2, CAST(0x0000AAC9010F0CDB AS DateTime), 0, NULL, NULL)
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
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (19, N'155D4802010167', N'Bùi Thị Tú', N'Anh', NULL, CAST(0xBB200B00 AS Date), N'Nghệ An', N'tuanh@gmail.com', N'0361678086', N'88719100e49b84914cd3b73822e73efc', N'hPGWBKfc8A', NULL, NULL, 2, CAST(0x0000AAC9010A83ED AS DateTime), 1, 2, CAST(0x0000AAD600098D89 AS DateTime), NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (20, N'155D4802010093', N'Phan Văn', N'Anh', 0, CAST(0xEF1F0B00 AS Date), N'Hà Tĩnh', N'vananh@gmail.com', N'0398760124', N'26625b4db7679ceec2db137687392113', N'sgthkiu', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (21, N'165D4802010201', N'Nguyễn Văn', N'Đức', NULL, CAST(0x11220B00 AS Date), N'Nghệ An', N'nva1308@gmai.com', N'14567890  ', N'ea8111ccb0fdeb5f8b1fbf9dbbca016a', N'4QLTf5GFZP', NULL, CAST(0x0000AA5801593C11 AS DateTime), 2, CAST(0x0000AA5F0160BEAB AS DateTime), NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10021, N'165D4802010070', N'Lê Văn', N'Bình', NULL, CAST(0x4B200B00 AS Date), N'Nghệ An', N'lva@gmail.com', N'1233456789', N'4b8381972136dcdd8e92faa3179c9613', N'vrALqUHEL5', NULL, CAST(0x0000AA5F015FBDDD AS DateTime), 2, CAST(0x0000AA5F0160AF5B AS DateTime), NULL, NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentFieldRelationship] ON 

INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (4, 17, 1)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (5, 19, 1)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (6, 21, 1)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (7, 17, 1)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (8, 17, 2)
SET IDENTITY_INSERT [dbo].[StudentFieldRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentNotificationRelationship] ON 

INSERT [dbo].[StudentNotificationRelationship] ([ID], [StudentID], [NotificationID], [Status]) VALUES (1, 21, 3, 1)
INSERT [dbo].[StudentNotificationRelationship] ([ID], [StudentID], [NotificationID], [Status]) VALUES (2, 21, 4, 1)
INSERT [dbo].[StudentNotificationRelationship] ([ID], [StudentID], [NotificationID], [Status]) VALUES (3, 21, 5, 1)
SET IDENTITY_INSERT [dbo].[StudentNotificationRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] ON 

INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 19, 5, NULL, NULL, CAST(0x0000AA7700EB2D50 AS DateTime), 2, NULL, 1, 2, CAST(0x0000AA7700EDBDCE AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 20, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (6, 16, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (7, 17, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (8, 18, 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (9, 21, 1, NULL, NULL, NULL, NULL, NULL, 1, 2, CAST(0x0000AAC4017045AF AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10, NULL, 2, NULL, NULL, CAST(0x0000AA7700EA0B32 AS DateTime), 2, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (11, 21, 5, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (12, 16, 9, NULL, 2, CAST(0x0000AAC4016DD6C5 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401712852 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (13, 16, 9, NULL, 2, CAST(0x0000AAC4016DD760 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC4017189CD AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (14, 16, 9, NULL, 2, CAST(0x0000AAC4016DD761 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC40172715C AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (15, 16, 9, NULL, 2, CAST(0x0000AAC4016DD762 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (16, 16, 9, NULL, 2, CAST(0x0000AAC4016DD763 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (17, 16, 9, NULL, 2, CAST(0x0000AAC4016DD764 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (18, 16, 9, NULL, 2, CAST(0x0000AAC4016DD769 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (19, 16, 9, NULL, 2, CAST(0x0000AAC4016DD76A AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (20, 16, 9, NULL, 2, CAST(0x0000AAC4016DD76B AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAC401727441 AS DateTime))
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (21, 10021, 5, NULL, 2, CAST(0x0000AAC8013A5C7C AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD000A7A64F AS DateTime))
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] ON 

INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (26, 16, 1, 2, CAST(0x0000AA58002327FD AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA74016B1B23 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (27, 17, 1, 2, CAST(0x0000AA5800232829 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA74016B1C54 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (28, 18, 1, 2, CAST(0x0000AA580023282A AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA74016B1E0F AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (29, 19, 1, 2, CAST(0x0000AA5800232830 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA5F0168055E AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (30, 20, 1, 2, CAST(0x0000AA5800232832 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAAC01449A97 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (31, 21, 1, 2, CAST(0x0000AA59013F94EF AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (32, 10021, 1, 2, CAST(0x0000AA5F0160305B AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (33, 19, 1, 2, CAST(0x0000AA5F01694DD4 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AA5F0169534E AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (34, 19, 1, 2, CAST(0x0000AA5F01695A70 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD50165D063 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (35, 18, 1, 2, CAST(0x0000AA7500C59928 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAAC017C8302 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (36, 17, 1, 2, CAST(0x0000AA7500C59E80 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AACF0164D591 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (37, 16, 1, 2, CAST(0x0000AA7500C59E84 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AACF0164D2C5 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (38, 20, 1, 2, CAST(0x0000AAAC0144A24A AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAAC0144C515 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (39, 20, 1, 2, CAST(0x0000AAAC017BFA47 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAAC017C8194 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (40, 20, 1, 2, CAST(0x0000AAAE01287117 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD50165D224 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (41, 18, 1, 2, CAST(0x0000AAAE012871B8 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AACF0164D7ED AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (42, 18, 1, 2, CAST(0x0000AAD0000AEA9F AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD50165D325 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (43, 17, 2, 2, CAST(0x0000AAD5016609B4 AS DateTime), 2, NULL, 1, 2, CAST(0x0000AAD501663888 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (44, 16, 2, 2, CAST(0x0000AAD5016609BB AS DateTime), 2, NULL, 1, 2, CAST(0x0000AAD501663614 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10042, 19, 2, 2, CAST(0x0000AAD501660945 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD501663376 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10043, 20, 2, 2, CAST(0x0000AAD5016609A1 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD501663A9B AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10044, 18, 2, 2, CAST(0x0000AAD5016609A8 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AAD5016639A3 AS DateTime))
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10045, 17, 2, 2, CAST(0x0000AAD5016641EC AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10046, 19, 1, 2, CAST(0x0000AAD501664ACB AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10047, 20, 1, 2, CAST(0x0000AAD501664ACE AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] ON 

INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 16, 1, 1, CAST(0x0000AA580023EEA6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (6, 17, 1, 1, CAST(0x0000AA580023EED4 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (7, 18, 1, 1, CAST(0x0000AA5801719D11 AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (8, 19, 2, 1, CAST(0x0000AA58002403DD AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (9, 20, 3, 1, CAST(0x0000AA5800240B95 AS DateTime), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10, 21, 2, 1, CAST(0x0000AA59013FB62C AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (11, 10021, 2, 1, CAST(0x0000AA5F01604873 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] OFF
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (1, N'Hệ thống và mạng máy tính')
INSERT [dbo].[Subject] ([ID], [SubjectName]) VALUES (2, N'Khoa học máy tính và công nghệ phần mềm')
SET IDENTITY_INSERT [dbo].[Subject] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (1, N'123456789', 1, N'Cao Thanh', N'Sơn', 0, CAST(0xCF070B00 AS Date), N'Nghệ An', N'ctsdhv@gmail.com', N'0989123654', N'4e6fd0efba6accb969183e995cb4e8a2', N'hsgdusf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (2, N'12345678', 1, N'Lê Quốc', N'Anh', 0, CAST(0x20050B00 AS Date), N'Nghệ An', N'lqadhv@gmail.com', N'0123489021', N'1c2c10472cab4f51923bbdfd2b4ad488', N'hgfuewhf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (3, N'1234567', 1, N'Nguyễn Thị ', N'Uyên', 1, CAST(0xD00C0B00 AS Date), N'Nghệ An', N'ntudhv@gmail.com', N'0389046791', N'c650b048054ad56d58eba209bbf6eba2', N'dhytjuy', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (4, N'123456', NULL, N'Nguyễn Văn', N'A', 0, CAST(0x85080B00 AS Date), N'Nghệ An', N'nva@gmail.com', N'0283091000', N'd00037d7061241ed8933dcf2d9566d14', N'fhgdhjdgj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Teacher] ([ID], [MaGV], [SubjectID], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note]) VALUES (5, N'12345', NULL, N'Nguyễn Văn', N'B', 0, CAST(0x55FA0A00 AS Date), N'Nghệ An', N'nvb@gmail.com', N'0989231456', N'8ab38f9d893b653d1384af73fb529a04', N'sgrttgtr', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET IDENTITY_INSERT [dbo].[TeacherRoleRelationship] ON 

INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (1, 1, 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (2, 1, 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (3, 2, 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (4, 2, 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (5, 3, 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (6, 4, 4, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (7, 5, 5, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TeacherRoleRelationship] ([ID], [TeacherID], [RoleID], [CreateBy], [CreateTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10006, 1, 10005, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TeacherRoleRelationship] OFF
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10022, 2, 2, NULL, N'123', N'123', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10023, 2, 6, NULL, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý đề tài thực tập', N'Xây dựng hệ thống quản lý đề tài thực tập cho khoa công nghệ thông tin ', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10024, 2, 6, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý bệnh viện', N'Xây dựng hệ thống quản lý bệnh viện, trong việc khám bệnh cũng như quản lý các bác sỹ, y tá', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10025, 1, 6, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý đề tài thực tập', N'Xây dựng hệ thống quản lý đề tài thực tập của sinh viên ngành CNTT', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (10026, 1, 6, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý cà phê', N'Xây dựng hệ thống quản lý bán hàng và thanh toán in hóa đơn cho quán cà phê', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20023, 2, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai website ẩm thực', N'Xây dựng website ẩm thực thành vinh dựa trên mã nguồn mở wordpress', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20024, 2, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai website du lịch nghệ an', N'Xây dựng website quảng bá về các địa điểm du lịch ở nghệ an dựa trên mã nguồn mở wordpress', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20025, 2, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai website nhà hàng', N'Hình thành ý tưởng, thiết kế, triển khai website nhà hàng bao gồm đặt bàn và đặt món online', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20026, 1, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý bệnh viện', N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý bệnh viện winform', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20027, 2, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý bệnh viện', N'aaaaaaaaaaaaaaaaaaaaa', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20028, 2, 1, 1, N'Hình thành ý tưởng, thiết kế, triển khai hệ thống quản lý cà phê', N'bbb', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20029, 2, 1, 1, N'csdfdgtr', N'sdgrthtyjyu', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20030, 2, 5, 1, N'dsfdfgr', N'sdgrtgrth', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20031, 2, 5, 1, N'okkkk', N'okkkk', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20032, 1, 1, 1, N'dsgregrt', N'tgrthgryhyt', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20033, 1, 1, 1, N'fergrtyyh', N'errrrrrreee', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20034, 1, 1, 1, N'ggregtrg', N'sferfre', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20035, 1, 1, 1, N'adfegrgtrg', N'rgfrtgtrgt', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20036, 1, 1, 1, N'sgrgt', N'fdgfgtrg', 1, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20037, 2, 1, 1, N'zscdg', N'dfhfghjyj', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (20038, 2, 1, 1, N'fsdghtyhy', N'sdfdrgrt', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30032, 2, 1, 1, N'dfsdfd', N'áefreferfr', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30033, 2, 1, 1, N'àergtrh', N'tjhyukiiiiiiiiiiiu', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30034, 2, 1, 1, N'dfrefgr', N'grgrtgt', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30035, 2, 1, 1, N'okkkkkkkkkkkk', N'qqqqqqqqqqqqqqqqqqqqqq', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30036, 2, 1, 1, N'httr', N'jyjtjyt', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30037, 2, 1, 1, N'zdfsdfv', N'fdgdgs', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30038, 2, 1, 1, N'àdsfs', N'fsfers', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30039, 2, 1, 1, N'11111111111', N'11111111111111', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30040, 2, 1, 1, N'dsvfdgve', N'ảerfref', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30041, 2, 1, 1, N'sdfsdgdfg', N'sgegesdrg', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30042, 2, 1, 1, N'dsfdgv', N'gdgggggdsg', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30043, 2, 1, 1, N'aetret', N'tgreytr', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30044, 2, 1, 1, N'bxbd', N'bdbfg', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30045, 2, 1, 1, N'dfsdf', N'sgfrgre', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30046, 2, 1, 1, N'adsf', N'sdfds', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30047, 2, 1, 1, N'àewf', N'ểgtgt', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30048, 2, 1, 1, N'1111111111111111', N'111111111111111111111', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30049, 2, 1, 1, N'hhhhhhhhhhh', N'hhhhhhhhhhhhhhhhhhhh', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30050, 2, 1, 1, N'xbdb', N'dfbfgbf', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30051, 2, 1, 1, N'frefer', N'ẻgergr', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30052, 2, 1, 1, N'dsfr', N'srgergr', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30053, 2, 1, 1, N'fdszfe', N'sfref', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30054, 2, 1, 1, N'sfsf', N'éergrtgrt', 0, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30055, 2, 1, 1, N'sdfdg', N'rdgrgr', 0, 1)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30056, 2, 1, 1, N'xcdsv', N'vdfvdf', 0, NULL)
SET IDENTITY_INSERT [dbo].[Topic] OFF
SET IDENTITY_INSERT [dbo].[TopicStudent] ON 

INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (18, 7, 10025, 1, 1, 2, 1, NULL, CAST(0x0000AA58017B0A4F AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (19, 7, 10026, 2, 1, 0, NULL, NULL, CAST(0x0000AA58017B0A93 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (20, 6, 10026, 1, 1, 2, 1, NULL, CAST(0x0000AA58017B2FFF AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (21, 6, 10025, 2, 0, 0, NULL, NULL, CAST(0x0000AA58017B3002 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10018, 9, 20023, 1, 1, 2, 0, NULL, CAST(0x0000AA590140F963 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10019, 9, 20024, 2, 0, 0, NULL, NULL, CAST(0x0000AA590140F971 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10020, 10, 20023, 1, NULL, 0, NULL, NULL, CAST(0x0000AA5F01606946 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10021, 11, 20030, 1, 1, 2, 1, NULL, CAST(0x0000AAC8014FE30D AS DateTime), NULL, NULL)
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
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Teacher]
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
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_StudentPracticeRelationship] FOREIGN KEY([StudentPracticeID])
REFERENCES [dbo].[StudentPracticeRelationship] ([ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_StudentPracticeRelationship]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([ID])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Teacher]
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
ALTER TABLE [dbo].[StudentFieldRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentFieldRelationship_Field] FOREIGN KEY([FieldID])
REFERENCES [dbo].[Field] ([ID])
GO
ALTER TABLE [dbo].[StudentFieldRelationship] CHECK CONSTRAINT [FK_StudentFieldRelationship_Field]
GO
ALTER TABLE [dbo].[StudentFieldRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentFieldRelationship_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentFieldRelationship] CHECK CONSTRAINT [FK_StudentFieldRelationship_Student]
GO
ALTER TABLE [dbo].[StudentNotificationRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentNotificationRelationship_Notification] FOREIGN KEY([NotificationID])
REFERENCES [dbo].[Notification] ([ID])
GO
ALTER TABLE [dbo].[StudentNotificationRelationship] CHECK CONSTRAINT [FK_StudentNotificationRelationship_Notification]
GO
ALTER TABLE [dbo].[StudentNotificationRelationship]  WITH CHECK ADD  CONSTRAINT [FK_StudentNotificationRelationship_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentNotificationRelationship] CHECK CONSTRAINT [FK_StudentNotificationRelationship_Student]
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
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Field] FOREIGN KEY([FieldID])
REFERENCES [dbo].[Field] ([ID])
GO
ALTER TABLE [dbo].[Topic] CHECK CONSTRAINT [FK_Topic_Field]
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
