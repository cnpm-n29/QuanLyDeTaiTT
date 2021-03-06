USE [master]
GO
/****** Object:  Database [QLDeTai]    Script Date: 12/8/2019 10:00:40 PM ******/
CREATE DATABASE [QLDeTai]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDeTai', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.HUYENLE\MSSQL\DATA\QLDeTai.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLDeTai_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.HUYENLE\MSSQL\DATA\QLDeTai_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Branch]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Faculty]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Field]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Function]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[FunctionRoleRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Practice]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[PracticeType]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Report]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Scores]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Semester]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[StudentFieldRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[StudentNotificationRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[StudentPracticeRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[StudentSubjectRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[StudentTeacherRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Subject]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[TeacherRoleRelationship]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[Topic]    Script Date: 12/8/2019 10:00:40 PM ******/
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
/****** Object:  Table [dbo].[TopicStudent]    Script Date: 12/8/2019 10:00:40 PM ******/
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
INSERT [dbo].[Field] ([ID], [FieldName], [Description]) VALUES (3, N'Trí tuệ nhân tạo', N'')
INSERT [dbo].[Field] ([ID], [FieldName], [Description]) VALUES (4, N'Lập trình game', N'')
INSERT [dbo].[Field] ([ID], [FieldName], [Description]) VALUES (5, N'Lập trình Adroid', N'')
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

INSERT [dbo].[Scores] ([ID], [TopicStudentID], [PracticeTypeID], [CompanyScore], [TeacherScore], [ReportScore], [TotalScore], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (9, 10022, 1, NULL, 9, NULL, NULL, 1, CAST(0x0000AB0E00C69B66 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Scores] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (1, N'2018_2019_1')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (2, N'2018_2019_2')
INSERT [dbo].[Semester] ([ID], [SemesterName]) VALUES (3, N'2018_2019_3')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10034, N'155D4802010124', N'Lê Khánh', N'Huyền', 1, CAST(0xAF1D0B00 AS Date), N'Nghệ An', N'huyenle@gmail.com', N'0981240562', N'd46df1978e95612fef61db15972df93d', N'xj4NnSlRMv', NULL, CAST(0x0000AB0E00ACF8C4 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10035, N'155D4802010345', N'Nguyễn Đức', N'Bảo', 0, CAST(0x0A1F0B00 AS Date), N'Hà Tĩnh', N'tuannguyen@gmail.com', N'0983747478', N'e46a89e7d52a342245db5b965c4b591d', N'ica10chZ0g', NULL, CAST(0x0000AB0E00ACF8D7 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10036, N'155D4802010678', N'Bùi Minh', N'Quân', 0, CAST(0xDF220B00 AS Date), N'Hà Tĩnh', N'ducbui@gmail.com', N'0283737374', N'471aba9b32ec4c4dd3a09fce64afe9eb', N'ica10chZ0g', NULL, CAST(0x0000AB0E00ACF8DA AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10037, N'155D4802010675', N'Nguyễn Thị', N'Thảo', 1, CAST(0x3C220B00 AS Date), N'Vinh', N'maimai@gmail.com', N'0373736362', N'9b81ab4a3e64a3119e4732461ef60e5b', N'4JlREbsbza', NULL, CAST(0x0000AB0E00ACF8DC AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AB0E00B2D5A1 AS DateTime), NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10038, N'155D4802010676', N'Đậu Minh', N'Nam', 0, CAST(0x9B200B00 AS Date), N'Thanh Hóa', N'minhnam@gmail.com', N'0933736252', N'6e9cbe25fef13f971f9cb7a8a7a78d69', N'4JlREbsbza', NULL, CAST(0x0000AB0E00ACF8DD AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10039, N'155D4802010677', N'Trần Minh', N'Nam', NULL, CAST(0xF21E0B00 AS Date), N'Vinh', N'minhvuong@gmail.com', N'0373635255', N'4edc1319bf72d288c62ba5f538fa3441', N'I2D9jcUkYE', NULL, CAST(0x0000AB0E00ACF8E0 AS DateTime), 2, CAST(0x0000AB0E00AF3855 AS DateTime), NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10040, N'155D4802010679', N'Hoàng Lý ', N'Lan', 1, CAST(0x3B200B00 AS Date), N'Hoàng Mai', N'HoangLan', N'0927225242', N'92deb505caf18a7793724bddff99329c', N'Q0xrSa2cyU', NULL, CAST(0x0000AB0E00ACF8E4 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10041, N'155D4802010665', N'Nguyễn Thu', N'Hiền', 1, CAST(0x3C220B00 AS Date), N'Vinh', N'maimai@gmail.com', N'0373736362', N'ce7598c433746ca7001b4d81744bcb44', N'GPR3Ehl9p1', NULL, CAST(0x0000AB0E00ACF8E7 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10042, N'155D4802010666', N'Đậu Dương', N'Lương', 0, CAST(0x9B200B00 AS Date), N'Thanh Hóa', N'minhnam@gmail.com', N'0933736252', N'9823b9dd290c83f00205f9631a795b4a', N'GPR3Ehl9p1', NULL, CAST(0x0000AB0E00ACF8E9 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10043, N'155D4802010667', N'Trần Minh', N'Ngọc', 0, CAST(0xF21E0B00 AS Date), N'Vinh', N'minhvuong@gmail.com', N'0373635255', N'3444873988756f2568508b20d8ebaba3', N'd6cTSgwAnv', NULL, CAST(0x0000AB0E00ACF8EB AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10044, N'155D4802010668', N'Hoàng Minh', N'Hồng', 1, CAST(0x3B200B00 AS Date), N'Vinh', N'HoangLan', N'0927225242', N'feca07ff515f02d3e001b406b6d33c2b', N'd6cTSgwAnv', NULL, CAST(0x0000AB0E00ACF8ED AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10045, N'155D4802010073', N'Đậu Minh', N'Nam', 0, CAST(0x9B200B00 AS Date), N'Thanh Hóa', N'minhnam@gmail.com', N'0933736252', N'99c4e8b23600e4345fb27a7749970c80', N'IWWsfgh2bO', NULL, CAST(0x0000AB0E00AE3DBE AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AB0E00B507AD AS DateTime), NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10046, N'155D4802010083', N'Trần Minh', N'Vương', 0, CAST(0xF21E0B00 AS Date), N'Vinh', N'minhvuong@gmail.com', N'0373635255', N'97487da343766983d914d218fb9c7c7b', N'UcBUembbRp', NULL, CAST(0x0000AB0E00AE3DC7 AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AB0E00B50A1E AS DateTime), NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10047, N'155D4802010093', N'Hoàng Lý ', N'Lan', 1, CAST(0x3B200B00 AS Date), N'Vinh', N'HoangLan', N'0927225242', N'cfb291a955ab96ca4cd39c4e012eedb3', N'qJNusllcQj', NULL, CAST(0x0000AB0E00AE3DCB AS DateTime), NULL, NULL, 1, 2, CAST(0x0000AB0E00B5050D AS DateTime), NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10048, N'155D4802010675', N'Nguyễn Thị', N'Thảo', 1, CAST(0x3C220B00 AS Date), N'Vinh', N'maimai@gmail.com', N'0373736362', N'f8ff50574126cdeaf7a7ab254d048ae4', N'HSUiZb7Jqh', NULL, CAST(0x0000AB0E00B3DD06 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10049, N'155D4802010775', N'Trần Minh', N'Đức', 0, CAST(0x3C220B00 AS Date), N'Quảng Trị', N'maimai@gmail.com', N'0373736362', N'1958f52c874cc8b3fd595e39cacff1a4', N'd9f7naHKpb', NULL, CAST(0x0000AB0E00B3DD09 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10050, N'155D4802010875', N'Trần Ngọc', N'Đại', 0, CAST(0x3C220B00 AS Date), N'Huế', N'maimai@gmail.com', N'0373736362', N'49883e5f56b9d7678eec7475c1f230f0', N'd9f7naHKpb', NULL, CAST(0x0000AB0E00B3DD0A AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10051, N'155D4802010975', N'Hoàng Khánh', N'Mai', 1, CAST(0x3C220B00 AS Date), N'Nghệ An', N'maimai@gmail.com', N'0373736362', N'b6576f79e0532604e7b628510e88492b', N'TY9KZh0rg8', NULL, CAST(0x0000AB0E00B3DD0C AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10052, N'155D4802010073', N'Đậu Minh', N'Nam', 0, CAST(0x9B200B00 AS Date), N'Thanh Hóa', N'minhnam@gmail.com', N'0933736252', N'6c458a8c677e1829b25608da84f5eaa0', N'3Z1WhmEouX', NULL, CAST(0x0000AB0E00B51458 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10053, N'155D4802010083', N'Trần Minh', N'Vương', 0, CAST(0xF21E0B00 AS Date), N'Vinh', N'minhvuong@gmail.com', N'0373635255', N'7240bff820f027cbd68d01c630da4170', N'PGCwvlPptR', NULL, CAST(0x0000AB0E00B5145C AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10054, N'155D4802010093', N'Hoàng Lý ', N'Lan', 1, CAST(0x3B200B00 AS Date), N'Vinh', N'HoangLan', N'0927225242', N'a7228ce16cd204f6db72212eebc088fb', N'PGCwvlPptR', NULL, CAST(0x0000AB0E00B5145E AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10055, N'155D4802010023', N'Đinh Thị Thu ', N'Thủy', 1, CAST(0x4C200B00 AS Date), N'Hồng Lĩnh', N'dinhthithuthuy2105@gmail.com', N'0123345678', N'd3d24a1d8e252e569ff157e84f2faada', N'hdHUwNKa0q', NULL, CAST(0x0000AB0E00B75441 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10056, N'155D4802010033', N'Lê Thị', N'Huyền', 1, CAST(0xAF1D0B00 AS Date), N'Nghệ An', N'huyenle@gmail.com', N'0981240562', N'6c96cba163c80cd39a55b0e9b93ab0d5', N'X1lgiU26rN', NULL, CAST(0x0000AB0E00B75447 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10057, N'155D4802010043', N'Nguyễn Văn', N'Tuấn', 0, CAST(0x0A1F0B00 AS Date), N'Hà Tĩnh', N'tuannguyen@gmail.com', N'0983747478', N'6c73f0da020592c589a474f8fe0ceaa7', N'tix6wTD8qH', NULL, CAST(0x0000AB0E00B7544A AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10058, N'155D4802010053', N'Bùi Quốc', N'Đức', 0, CAST(0xDF220B00 AS Date), N'Hà Tĩnh', N'ducbui@gmail.com', N'0283737374', N'481364916a4c243856d89c1a2ad8f7cf', N'tix6wTD8qH', NULL, CAST(0x0000AB0E00B7544B AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10059, N'155D4802010063', N'Nguyễn Thị', N'Mai', 1, CAST(0x3C220B00 AS Date), N'Vinh', N'maimai@gmail.com', N'0373736362', N'401ace05693a98bff65cd42918f40cbf', N'j7RJiZwfho', NULL, CAST(0x0000AB0E00B7544D AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Student] ([ID], [MaSV], [FirstName], [LastName], [Sex], [Birthday], [Address], [Email], [Phone], [Password], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [Note], [FacultyID]) VALUES (10060, N'155D4802010123', N'Đinh Hồng', N'Thủy', 1, CAST(0x4C200B00 AS Date), N'Nghệ An', N'dinhthithuthuy2105@gmail.com', N'0123995678', N'6c0260dd81a79d3781e526282effa5e7', N'mi548rceSd', NULL, CAST(0x0000AB0E00B7D773 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentFieldRelationship] ON 

INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (9, 10055, 1)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (10, 10055, 2)
INSERT [dbo].[StudentFieldRelationship] ([ID], [StudentID], [FieldID]) VALUES (11, 10057, 1)
SET IDENTITY_INSERT [dbo].[StudentFieldRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] ON 

INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (26, 10055, 1, NULL, 2, CAST(0x0000AB0E00B9F25E AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (27, 10056, 1, NULL, 2, CAST(0x0000AB0E00B9F265 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (28, 10057, 1, NULL, 2, CAST(0x0000AB0E00B9F266 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (29, 10058, 1, NULL, 2, CAST(0x0000AB0E00B9F268 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (30, 10055, 6, NULL, 2, CAST(0x0000AB0E00BA1FB3 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (31, 10056, 6, NULL, 2, CAST(0x0000AB0E00BA1FB6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (32, 10057, 6, NULL, 2, CAST(0x0000AB0E00BA1FB9 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (33, 10058, 6, NULL, 2, CAST(0x0000AB0E00BA1FBB AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (34, 10055, 11, NULL, 2, CAST(0x0000AB0E00BA34D4 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (35, 10056, 11, NULL, 2, CAST(0x0000AB0E00BA34D6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (36, 10057, 11, NULL, 2, CAST(0x0000AB0E00BA34D8 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentPracticeRelationship] ([ID], [StudentID], [PracticeTypeID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (37, 10058, 11, NULL, 2, CAST(0x0000AB0E00BA34D9 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentPracticeRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] ON 

INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10048, 10035, 1, 2, CAST(0x0000AB0E00BCC581 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10049, 10041, 1, 2, CAST(0x0000AB0E00BCC585 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10050, 10044, 1, 2, CAST(0x0000AB0E00BCC586 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10051, 10034, 1, 2, CAST(0x0000AB0E00BCC587 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10052, 10040, 1, 2, CAST(0x0000AB0E00BCC588 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10053, 10042, 1, 2, CAST(0x0000AB0E00BCC589 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10054, 10038, 1, 2, CAST(0x0000AB0E00BCC58B AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10055, 10058, 2, 2, CAST(0x0000AB0E00BCD1C0 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10056, 10056, 2, 2, CAST(0x0000AB0E00BCD1C2 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10057, 10059, 2, 2, CAST(0x0000AB0E00BCD1C3 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10058, 10055, 1, 2, CAST(0x0000AB0E00BD05EA AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10059, 10057, 1, 2, CAST(0x0000AB0E00BD05EC AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10060, 10039, 2, 2, CAST(0x0000AB0E00BD2136 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10061, 10043, 2, 2, CAST(0x0000AB0E00BD213A AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10062, 10036, 2, 2, CAST(0x0000AB0E00BD213D AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10063, 10054, 2, 2, CAST(0x0000AB0E00BD31F3 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10064, 10052, 2, 2, CAST(0x0000AB0E00BD31F5 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10065, 10060, 2, 2, CAST(0x0000AB0E00BD31F6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10066, 10053, 2, 2, CAST(0x0000AB0E00BD31F7 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10067, 10050, 1, 2, CAST(0x0000AB0E00BD4912 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10068, 10049, 1, 2, CAST(0x0000AB0E00BD4914 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10069, 10051, 1, 2, CAST(0x0000AB0E00BD4915 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentSubjectRelationship] ([ID], [StudentID], [SubjectID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (10070, 10048, 1, 2, CAST(0x0000AB0E00BD4916 AS DateTime), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StudentSubjectRelationship] OFF
SET IDENTITY_INSERT [dbo].[StudentTeacherRelationship] ON 

INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (12, 10035, 1, 1, CAST(0x0000AB0E00BD7D23 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (13, 10041, 1, 1, CAST(0x0000AB0E00BD7D2A AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (14, 10044, 1, 1, CAST(0x0000AB0E00BD7D2C AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (15, 10034, 1, 1, CAST(0x0000AB0E00BD7D2E AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (16, 10055, 1, 1, CAST(0x0000AB0E00BD8656 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (17, 10057, 1, 1, CAST(0x0000AB0E00BD8657 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (18, 10040, 2, 1, CAST(0x0000AB0E00BDBEB5 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (19, 10042, 2, 1, CAST(0x0000AB0E00BDBEB7 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (20, 10038, 2, 1, CAST(0x0000AB0E00BDBEB8 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (21, 10050, 3, 1, CAST(0x0000AB0E00BDDBE4 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (22, 10049, 3, 1, CAST(0x0000AB0E00BDDBE9 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (23, 10051, 3, 1, CAST(0x0000AB0E00BDDBEC AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StudentTeacherRelationship] ([ID], [StudentID], [TeacherID], [CreateBy], [CreateTime], [ModifyBy], [ModifyTime], [IsDeleted], [DeletedBy], [DeletedTime]) VALUES (24, 10048, 3, 1, CAST(0x0000AB0E00BDDBEE AS DateTime), NULL, NULL, NULL, NULL, NULL)
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

INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30057, 1, 1, 1, N'Hình thành ý tưởng thiết kế, triển khai và vận hành website ẩm thực thành phố Vinh', N'Sử dụng Wordpress', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30058, 1, 1, 1, N'Hình thành ý tưởng thiết kế, triển khai và vận hành website ẩm thực thành phố Vinh', N'Sử dụng PHP', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30059, 1, 1, 1, N'Hình thành ý tưởng thiết kế, triển khai và vận hành hệ thống bán quần áo', N'Sử dụng ngôn ngữ lập trình C#', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30060, 1, 5, 1, N'Hình thành ý tưởng thiết kế, triển khai và vận hành hệ thống quán coffee', N'Sử dụng ngôn ngữ lập trình PHP', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30061, 1, 6, 1, N'Hình thành ý tưởng thiết kế, triển khai hệ thống quản lý đề tài thực tập của sinh viên CNTT Trường Đại học Vinh', N'Sử dụng ngôn ngữ lập trình C#', 1, NULL)
INSERT [dbo].[Topic] ([ID], [TeacherID], [PracticeTypeID], [FieldID], [TopicName], [Description], [Status], [IsDeleted]) VALUES (30062, 1, 6, 1, N'Hình thành ý tưởng thiết kế, triển khai và vận hành hệ thống quản lý salon hair', N'Sử dụng ngôn ngữ lập trình Python', 1, NULL)
SET IDENTITY_INSERT [dbo].[Topic] OFF
SET IDENTITY_INSERT [dbo].[TopicStudent] ON 

INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10022, 26, 30057, 1, 1, 2, 1, NULL, CAST(0x0000AB0E00C5BE7D AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10023, 26, 30058, 2, NULL, 0, NULL, NULL, CAST(0x0000AB0E00C5BE81 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10024, 28, 30057, 1, NULL, 0, NULL, NULL, CAST(0x0000AB0E00C60433 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10025, 28, 30059, 2, NULL, 0, NULL, NULL, CAST(0x0000AB0E00C60437 AS DateTime), NULL, NULL)
INSERT [dbo].[TopicStudent] ([ID], [StudentPracticeID], [TopicID], [Order], [Status], [Progress], [Result], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (10026, 28, 30058, 3, 1, 0, NULL, NULL, CAST(0x0000AB0E00C6043A AS DateTime), NULL, NULL)
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
