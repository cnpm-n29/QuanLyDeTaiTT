USE [master]
GO
/****** Object:  Database [QLDeTai]    Script Date: 5/6/2019 6:02:40 AM ******/
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
/****** Object:  Table [dbo].[BoMon]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoMon](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TenBM] [nvarchar](100) NULL,
 CONSTRAINT [PK_BoMon] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ChucVu] [nvarchar](500) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChucVuGV]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVuGV](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_GV] [bigint] NULL,
	[ID_ChucVu] [bigint] NULL,
 CONSTRAINT [PK_ChucVuGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeTai]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeTai](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_GiangVien] [bigint] NULL,
	[ID_ThucTap] [bigint] NULL,
	[TenDeTai] [nvarchar](500) NULL,
	[MoTa] [nvarchar](500) NULL,
	[TrangThai] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DeTai] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeTaiSinhVienTT]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeTaiSinhVienTT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_SinhVienTT] [bigint] NULL,
	[ID_DeTai] [bigint] NULL,
	[DoUuTien] [int] NULL,
	[Status] [nchar](10) NULL,
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
/****** Object:  Table [dbo].[DiemTT]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemTT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_DeTaiSinhVienTT] [bigint] NULL,
	[ID_ThucTap] [bigint] NULL,
	[DiemCongTy] [real] NULL,
	[DiemGVHD] [real] NULL,
	[DiemBaoCao] [real] NULL,
	[DiemTong] [real] NULL,
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
/****** Object:  Table [dbo].[GiangVien]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaGV] [nvarchar](20) NULL,
	[MaBM] [bigint] NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [nchar](10) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_GiangVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocKy]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKy](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TenHocKy] [nvarchar](50) NULL,
 CONSTRAINT [PK_HocKy] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_Nganh] [bigint] NULL,
	[TenKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiTT]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiTT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TenThucTap] [nvarchar](100) NULL,
 CONSTRAINT [PK_LoaiTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TenNganh] [nvarchar](500) NULL,
 CONSTRAINT [PK_Nganh] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanCongGV]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCongGV](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_SinhVien] [bigint] NULL,
	[ID_GiangVien] [bigint] NULL,
 CONSTRAINT [PK_PhanCongGV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Quyen] [nvarchar](500) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen_CV]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen_CV](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_ChucVu] [bigint] NULL,
	[ID_Quyen] [bigint] NULL,
 CONSTRAINT [PK_Quyen_CV] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SinhVien](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSV] [nvarchar](20) NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[Email] [nvarchar](50) NULL,
	[SDT] [char](10) NULL,
	[MatKhau] [nvarchar](500) NULL,
	[PasswordSalt] [nvarchar](10) NULL,
	[CreateBy] [bigint] NULL,
	[CreateTime] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeletedBy] [bigint] NULL,
	[DeletedTime] [datetime] NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SinhVienTT]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVienTT](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_SinhVien] [bigint] NULL,
	[ID_TT] [bigint] NULL,
 CONSTRAINT [PK_SinhVienTT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThucTap]    Script Date: 5/6/2019 6:02:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThucTap](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ID_HocKy] [bigint] NULL,
	[ID_LoaiTT] [bigint] NULL,
 CONSTRAINT [PK_ThucTap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BoMon] ON 

INSERT [dbo].[BoMon] ([ID], [TenBM]) VALUES (1, N'Hệ thống và mạng máy tính')
INSERT [dbo].[BoMon] ([ID], [TenBM]) VALUES (2, N'Khoa học máy tính và công nghệ phần mềm')
SET IDENTITY_INSERT [dbo].[BoMon] OFF
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([ID], [ChucVu]) VALUES (1, N'Trưởng Bộ Môn')
INSERT [dbo].[ChucVu] ([ID], [ChucVu]) VALUES (2, N'Trợ Lý Đào Tạo')
INSERT [dbo].[ChucVu] ([ID], [ChucVu]) VALUES (3, N'Giảng Viên')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
SET IDENTITY_INSERT [dbo].[ChucVuGV] ON 

INSERT [dbo].[ChucVuGV] ([ID], [ID_GV], [ID_ChucVu]) VALUES (1, 1, 1)
INSERT [dbo].[ChucVuGV] ([ID], [ID_GV], [ID_ChucVu]) VALUES (2, 1, 3)
INSERT [dbo].[ChucVuGV] ([ID], [ID_GV], [ID_ChucVu]) VALUES (3, 2, 2)
INSERT [dbo].[ChucVuGV] ([ID], [ID_GV], [ID_ChucVu]) VALUES (4, 2, 3)
INSERT [dbo].[ChucVuGV] ([ID], [ID_GV], [ID_ChucVu]) VALUES (5, 3, 3)
SET IDENTITY_INSERT [dbo].[ChucVuGV] OFF
SET IDENTITY_INSERT [dbo].[DeTai] ON 

INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (1, 2, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (2, 2, 6, N'123', N'123', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10002, 2, 11, N'ok', N'ok', 0, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10003, 2, 1, N'oki', N'aaaaaaaaaaaaaaa', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10004, 2, 1, N'abc', N'11', 0, 1)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10005, 2, 1, N'abc', N'abc', 0, 1)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10006, 2, 1, N'123', N'1', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10007, 2, 1, N'hi', N'ok', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10008, 2, 1, N'hi', N'ok', 0, 1)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10009, 2, 5, N'sfdf', N'tthrt', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10010, 2, 9, N'dsefg', N'faeret', 0, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10011, 2, 1, N'1234', N'ssfef', 0, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10012, 2, 1, N'12345', N'dfef', 0, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10013, 2, 1, N'saferfre', N'sferf', 0, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10014, 1, 5, N'oki', N'aaaaa', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10015, 1, 1, N'123', N'111111', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10016, 1, 1, N'345', N'aaaaaaaaaaa', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10017, 1, 1, N'Hệ thống quản lý đề tài thực tập', N'C#', 1, NULL)
INSERT [dbo].[DeTai] ([ID], [ID_GiangVien], [ID_ThucTap], [TenDeTai], [MoTa], [TrangThai], [IsDeleted]) VALUES (10018, 1, 1, N'Quản lý quán cà phê', N'C# winform', 1, NULL)
SET IDENTITY_INSERT [dbo].[DeTai] OFF
SET IDENTITY_INSERT [dbo].[DeTaiSinhVienTT] ON 

INSERT [dbo].[DeTaiSinhVienTT] ([ID], [ID_SinhVienTT], [ID_DeTai], [DoUuTien], [Status], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime]) VALUES (1, 1, 10003, 1, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DeTaiSinhVienTT] OFF
SET IDENTITY_INSERT [dbo].[GiangVien] ON 

INSERT [dbo].[GiangVien] ([ID], [MaGV], [MaBM], [Ho], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [Email], [SDT], [MatKhau], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [GhiChu]) VALUES (1, N'123456789', 1, N'Cao Thanh', N'Sơn', 0, CAST(0xCF070B00 AS Date), N'Nghệ An', N'ctsdhv@gmail.com', N'0989123654', N'4e6fd0efba6accb969183e995cb4e8a2', N'hsgdusf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[GiangVien] ([ID], [MaGV], [MaBM], [Ho], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [Email], [SDT], [MatKhau], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [GhiChu]) VALUES (2, N'12345678', 1, N'Lê Quốc', N'Anh', 0, CAST(0x20050B00 AS Date), N'Nghệ An', N'lqadhv@gmail.com', N'0123489021', N'1c2c10472cab4f51923bbdfd2b4ad488', N'hgfuewhf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[GiangVien] ([ID], [MaGV], [MaBM], [Ho], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [Email], [SDT], [MatKhau], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [GhiChu]) VALUES (3, N'1234567', 1, N'Nguyễn Thị ', N'Uyên', 1, CAST(0xD00C0B00 AS Date), N'Nghệ An', N'ntudhv@gmail.com', N'0389046791', N'c650b048054ad56d58eba209bbf6eba2', N'dhytjuy', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[GiangVien] OFF
SET IDENTITY_INSERT [dbo].[HocKy] ON 

INSERT [dbo].[HocKy] ([ID], [TenHocKy]) VALUES (1, N'2018_2019_1')
INSERT [dbo].[HocKy] ([ID], [TenHocKy]) VALUES (2, N'2018_2019_2')
INSERT [dbo].[HocKy] ([ID], [TenHocKy]) VALUES (3, N'2018_2019_3')
SET IDENTITY_INSERT [dbo].[HocKy] OFF
SET IDENTITY_INSERT [dbo].[Khoa] ON 

INSERT [dbo].[Khoa] ([ID], [ID_Nganh], [TenKhoa]) VALUES (1, 1, N'K56')
INSERT [dbo].[Khoa] ([ID], [ID_Nganh], [TenKhoa]) VALUES (2, 1, N'K57')
INSERT [dbo].[Khoa] ([ID], [ID_Nganh], [TenKhoa]) VALUES (3, 1, N'K58')
INSERT [dbo].[Khoa] ([ID], [ID_Nganh], [TenKhoa]) VALUES (4, 1, N'K59')
SET IDENTITY_INSERT [dbo].[Khoa] OFF
SET IDENTITY_INSERT [dbo].[LoaiTT] ON 

INSERT [dbo].[LoaiTT] ([ID], [TenThucTap]) VALUES (1, N'Thực tập cơ sở')
INSERT [dbo].[LoaiTT] ([ID], [TenThucTap]) VALUES (2, N'Thực tập chuyên ngành')
INSERT [dbo].[LoaiTT] ([ID], [TenThucTap]) VALUES (3, N'Thực tập tốt nghiệp')
INSERT [dbo].[LoaiTT] ([ID], [TenThucTap]) VALUES (4, N'Đồ án tốt nghiệp')
SET IDENTITY_INSERT [dbo].[LoaiTT] OFF
SET IDENTITY_INSERT [dbo].[Nganh] ON 

INSERT [dbo].[Nganh] ([ID], [TenNganh]) VALUES (1, N'Công nghệ thông tin')
SET IDENTITY_INSERT [dbo].[Nganh] OFF
SET IDENTITY_INSERT [dbo].[PhanCongGV] ON 

INSERT [dbo].[PhanCongGV] ([ID], [ID_SinhVien], [ID_GiangVien]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[PhanCongGV] OFF
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (1, N'Chốt đề tài')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (2, N'Thêm, Sửa,Xóa đề tài')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (3, N'Xem danh sách hướng dẫn')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (4, N'Thêm, Sửa, Xóa điểm')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (5, N'Phân Bộ Môn')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (6, N'Thêm, Sửa , Xóa Danh sách thực tập')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (7, N'Thêm, Sửa , Xóa Danh sách sinh viên')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (8, N'Thêm, Sửa , Xóa Danh sách Giảng viên')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (9, N'Xem danh sách sinh viên bộ môn')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (10, N'Xem danh sách sinh viên bộ môn')
INSERT [dbo].[Quyen] ([ID], [Quyen]) VALUES (11, N'Phân giáo viên hướng dẫn ')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
SET IDENTITY_INSERT [dbo].[Quyen_CV] ON 

INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (1, 1, 9)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (2, 1, 10)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (3, 1, 11)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (4, 2, 4)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (5, 2, 5)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (6, 2, 6)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (7, 2, 7)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (8, 2, 8)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (9, 3, 1)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (10, 3, 2)
INSERT [dbo].[Quyen_CV] ([ID], [ID_ChucVu], [ID_Quyen]) VALUES (11, 3, 3)
SET IDENTITY_INSERT [dbo].[Quyen_CV] OFF
SET IDENTITY_INSERT [dbo].[SinhVien] ON 

INSERT [dbo].[SinhVien] ([ID], [MaSV], [Ho], [Ten], [GioiTinh], [NgaySinh], [DiaChi], [Email], [SDT], [MatKhau], [PasswordSalt], [CreateBy], [CreateTime], [ModifiedBy], [ModifiedTime], [IsDeleted], [DeletedBy], [DeletedTime], [GhiChu]) VALUES (1, N'155D4802010023', N'Đinh Thị Thu', N'Thủy', 1, CAST(0x4C200B00 AS Date), N'Hồng Lĩnh, Hà Tĩnh', N'dinhthithuthuy2105@gmail.com', N'0989358038', N'064024a0c9616c39cbdbc6b94dbac143', N'ndjncvfvnv', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SinhVien] OFF
SET IDENTITY_INSERT [dbo].[SinhVienTT] ON 

INSERT [dbo].[SinhVienTT] ([ID], [ID_SinhVien], [ID_TT]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[SinhVienTT] OFF
SET IDENTITY_INSERT [dbo].[ThucTap] ON 

INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (1, 1, 1)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (2, 1, 2)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (3, 1, 3)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (5, 2, 1)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (6, 2, 2)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (7, 2, 3)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (8, 2, 4)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (9, 3, 1)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (10, 3, 2)
INSERT [dbo].[ThucTap] ([ID], [ID_HocKy], [ID_LoaiTT]) VALUES (11, 3, 3)
SET IDENTITY_INSERT [dbo].[ThucTap] OFF
ALTER TABLE [dbo].[ChucVuGV]  WITH CHECK ADD  CONSTRAINT [FK_ChucVuGV_ChucVu] FOREIGN KEY([ID_ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[ChucVuGV] CHECK CONSTRAINT [FK_ChucVuGV_ChucVu]
GO
ALTER TABLE [dbo].[ChucVuGV]  WITH CHECK ADD  CONSTRAINT [FK_ChucVuGV_GiangVien] FOREIGN KEY([ID_GV])
REFERENCES [dbo].[GiangVien] ([ID])
GO
ALTER TABLE [dbo].[ChucVuGV] CHECK CONSTRAINT [FK_ChucVuGV_GiangVien]
GO
ALTER TABLE [dbo].[DeTai]  WITH CHECK ADD  CONSTRAINT [FK_DeTai_GiangVien] FOREIGN KEY([ID_GiangVien])
REFERENCES [dbo].[GiangVien] ([ID])
GO
ALTER TABLE [dbo].[DeTai] CHECK CONSTRAINT [FK_DeTai_GiangVien]
GO
ALTER TABLE [dbo].[DeTai]  WITH CHECK ADD  CONSTRAINT [FK_DeTai_ThucTap] FOREIGN KEY([ID_ThucTap])
REFERENCES [dbo].[ThucTap] ([ID])
GO
ALTER TABLE [dbo].[DeTai] CHECK CONSTRAINT [FK_DeTai_ThucTap]
GO
ALTER TABLE [dbo].[DeTaiSinhVienTT]  WITH CHECK ADD  CONSTRAINT [FK_DeTaiSinhVienTT_DeTai] FOREIGN KEY([ID_DeTai])
REFERENCES [dbo].[DeTai] ([ID])
GO
ALTER TABLE [dbo].[DeTaiSinhVienTT] CHECK CONSTRAINT [FK_DeTaiSinhVienTT_DeTai]
GO
ALTER TABLE [dbo].[DeTaiSinhVienTT]  WITH CHECK ADD  CONSTRAINT [FK_DeTaiSinhVienTT_SinhVienTT] FOREIGN KEY([ID_SinhVienTT])
REFERENCES [dbo].[SinhVienTT] ([ID])
GO
ALTER TABLE [dbo].[DeTaiSinhVienTT] CHECK CONSTRAINT [FK_DeTaiSinhVienTT_SinhVienTT]
GO
ALTER TABLE [dbo].[DiemTT]  WITH CHECK ADD  CONSTRAINT [FK_DiemTT_DeTaiSinhVienTT] FOREIGN KEY([ID_DeTaiSinhVienTT])
REFERENCES [dbo].[DeTaiSinhVienTT] ([ID])
GO
ALTER TABLE [dbo].[DiemTT] CHECK CONSTRAINT [FK_DiemTT_DeTaiSinhVienTT]
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD  CONSTRAINT [FK_GiangVien_BoMon] FOREIGN KEY([MaBM])
REFERENCES [dbo].[BoMon] ([ID])
GO
ALTER TABLE [dbo].[GiangVien] CHECK CONSTRAINT [FK_GiangVien_BoMon]
GO
ALTER TABLE [dbo].[Khoa]  WITH CHECK ADD  CONSTRAINT [FK_Khoa_Nganh] FOREIGN KEY([ID_Nganh])
REFERENCES [dbo].[Nganh] ([ID])
GO
ALTER TABLE [dbo].[Khoa] CHECK CONSTRAINT [FK_Khoa_Nganh]
GO
ALTER TABLE [dbo].[PhanCongGV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongGV_GiangVien] FOREIGN KEY([ID_GiangVien])
REFERENCES [dbo].[GiangVien] ([ID])
GO
ALTER TABLE [dbo].[PhanCongGV] CHECK CONSTRAINT [FK_PhanCongGV_GiangVien]
GO
ALTER TABLE [dbo].[PhanCongGV]  WITH CHECK ADD  CONSTRAINT [FK_PhanCongGV_SinhVien] FOREIGN KEY([ID_SinhVien])
REFERENCES [dbo].[SinhVien] ([ID])
GO
ALTER TABLE [dbo].[PhanCongGV] CHECK CONSTRAINT [FK_PhanCongGV_SinhVien]
GO
ALTER TABLE [dbo].[Quyen_CV]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_CV_ChucVu] FOREIGN KEY([ID_ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[Quyen_CV] CHECK CONSTRAINT [FK_Quyen_CV_ChucVu]
GO
ALTER TABLE [dbo].[Quyen_CV]  WITH CHECK ADD  CONSTRAINT [FK_Quyen_CV_Quyen] FOREIGN KEY([ID_Quyen])
REFERENCES [dbo].[Quyen] ([ID])
GO
ALTER TABLE [dbo].[Quyen_CV] CHECK CONSTRAINT [FK_Quyen_CV_Quyen]
GO
ALTER TABLE [dbo].[SinhVienTT]  WITH CHECK ADD  CONSTRAINT [FK_SinhVienTT_SinhVien] FOREIGN KEY([ID_SinhVien])
REFERENCES [dbo].[SinhVien] ([ID])
GO
ALTER TABLE [dbo].[SinhVienTT] CHECK CONSTRAINT [FK_SinhVienTT_SinhVien]
GO
ALTER TABLE [dbo].[ThucTap]  WITH CHECK ADD  CONSTRAINT [FK_ThucTap_HocKy] FOREIGN KEY([ID_HocKy])
REFERENCES [dbo].[HocKy] ([ID])
GO
ALTER TABLE [dbo].[ThucTap] CHECK CONSTRAINT [FK_ThucTap_HocKy]
GO
ALTER TABLE [dbo].[ThucTap]  WITH CHECK ADD  CONSTRAINT [FK_ThucTap_LoaiTT] FOREIGN KEY([ID_LoaiTT])
REFERENCES [dbo].[LoaiTT] ([ID])
GO
ALTER TABLE [dbo].[ThucTap] CHECK CONSTRAINT [FK_ThucTap_LoaiTT]
GO
USE [master]
GO
ALTER DATABASE [QLDeTai] SET  READ_WRITE 
GO
