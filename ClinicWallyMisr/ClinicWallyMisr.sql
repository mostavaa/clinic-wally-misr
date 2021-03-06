USE [master]
GO
/****** Object:  Database [ClinicWallyMisr]    Script Date: 01/27/2017 07:59:25 ******/
CREATE DATABASE [ClinicWallyMisr] ON  PRIMARY 
( NAME = N'ClinicWallyMisr', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ClinicWallyMisr.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ClinicWallyMisr_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\ClinicWallyMisr_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ClinicWallyMisr] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ClinicWallyMisr].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ClinicWallyMisr] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET ARITHABORT OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ClinicWallyMisr] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ClinicWallyMisr] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ClinicWallyMisr] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET  DISABLE_BROKER
GO
ALTER DATABASE [ClinicWallyMisr] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ClinicWallyMisr] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ClinicWallyMisr] SET  READ_WRITE
GO
ALTER DATABASE [ClinicWallyMisr] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ClinicWallyMisr] SET  MULTI_USER
GO
ALTER DATABASE [ClinicWallyMisr] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ClinicWallyMisr] SET DB_CHAINING OFF
GO
USE [ClinicWallyMisr]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[id] [uniqueidentifier] NOT NULL,
	[tableName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'f6605f0e-49df-4a33-a23c-1765331966f4', N'Endoscopy')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'781bee41-57b4-43b4-92b7-17c8442395ca', N'Reservation')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'32807c37-f003-4c1f-b8c8-1916c706ccfc', N'Laboratory')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'5fb5c554-3615-47fc-bf8d-2452c521a908', N'Complaint')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'07358611-9767-4d30-9f81-3a0fe4c5167e', N'medicine')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'3f1e5832-2de4-417d-b3b8-51b3aaae05c9', N'Imaging')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'1cbad740-45c2-4e90-9e45-5ad0cd619ff2', N'Account')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'6cc1b5fb-e03b-4a61-93a5-6e0cf991dcb3', N'patient')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'3d11c199-5dec-4757-b2db-707fa373d163', N'Group')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'45491f7c-7b86-48dd-97ff-764b0e9eb105', N'Labs')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'97adc0ce-c75b-4b2a-b576-7da51871f551', N'Specialization')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'01e1daf6-5f6a-4460-a7f1-a62ddd1beddf', N'Tables')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'793cafb4-587e-416b-a857-ae3215612936', N'Permissions')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'670ba364-a787-4ff2-a87c-b45847beec3f', N'prescription')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'75cfb6d5-891c-4606-ac43-b6d9351fc9fc', N'SystemPerson')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'a629a783-695e-4358-9eef-bae2ad88d3d3', N'Job')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'9f799e9a-178d-4c8d-8824-bdedfc7223e6', N'surgicalHistory')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'35aad6fa-2d18-46cd-80e1-c9bdb67bc06c', N'visits')
INSERT [dbo].[Tables] ([id], [tableName]) VALUES (N'2a3badfb-0b00-49b6-b94d-e7e59c384189', N'examination')
/****** Object:  Table [dbo].[Group]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Group] ([id], [name]) VALUES (N'230868c0-d851-40dd-8cbe-0c03857071f6', N'Admin')
/****** Object:  Table [dbo].[Job]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Job](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Job] ([id], [name]) VALUES (N'069d4577-e71e-4ac9-8909-92459a0fce2f', N'Doctor')
INSERT [dbo].[Job] ([id], [name]) VALUES (N'1ffe1f3e-8fd3-4d05-b6d2-c05c8694023e', N'Employee')
/****** Object:  Table [dbo].[Specialization]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialization](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NULL,
	[jobId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Specialization] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Specialization] ([id], [name], [jobId]) VALUES (N'e1a3c86a-9256-4ed6-a6d5-dcfb90917257', N'Data Entry', N'1ffe1f3e-8fd3-4d05-b6d2-c05c8694023e')
INSERT [dbo].[Specialization] ([id], [name], [jobId]) VALUES (N'ec93ce9c-a5d9-4f5c-8e67-ebe5eed0582b', N'Ophthalmologist', N'069d4577-e71e-4ac9-8909-92459a0fce2f')
INSERT [dbo].[Specialization] ([id], [name], [jobId]) VALUES (N'c263b1ff-15ed-4566-8ab5-fcd59d11d8ca', N'Dentist', N'069d4577-e71e-4ac9-8909-92459a0fce2f')
INSERT [dbo].[Specialization] ([id], [name], [jobId]) VALUES (N'f0d6da03-78cf-47c6-8ace-feb9a84c9e05', N'Nurse', N'1ffe1f3e-8fd3-4d05-b6d2-c05c8694023e')
/****** Object:  Table [dbo].[Permissions]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[id] [uniqueidentifier] NOT NULL,
	[groupId] [uniqueidentifier] NULL,
	[tableId] [uniqueidentifier] NULL,
	[canAdd] [bit] NOT NULL,
	[canEdit] [bit] NOT NULL,
	[canDelete] [bit] NOT NULL,
	[canRead] [bit] NOT NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'dd6df9d2-c158-4b25-b573-13e9557eb214', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'97adc0ce-c75b-4b2a-b576-7da51871f551', 1, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'bffbd698-3802-44d7-af36-177deb2722d3', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'75cfb6d5-891c-4606-ac43-b6d9351fc9fc', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'31d0fd8c-59bc-421f-a2fb-1a45c928addb', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'a629a783-695e-4358-9eef-bae2ad88d3d3', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'fcd28d75-a994-4500-9ae6-22e212f2b4de', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'07358611-9767-4d30-9f81-3a0fe4c5167e', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'b9070f20-1245-4fec-91ed-25844342bc61', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'6cc1b5fb-e03b-4a61-93a5-6e0cf991dcb3', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'ac19f9ec-ddf5-4279-9d54-3e4ac1c00813', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'1cbad740-45c2-4e90-9e45-5ad0cd619ff2', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'c3fbddb3-6396-4227-8a53-41f7a805b710', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'f6605f0e-49df-4a33-a23c-1765331966f4', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'407fab47-0425-4432-ab0e-475f91722a75', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'793cafb4-587e-416b-a857-ae3215612936', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'ed4d3da0-61d0-48dc-b65e-6fc1b9428dfc', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'781bee41-57b4-43b4-92b7-17c8442395ca', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'c14de1e0-710c-4a19-a88d-7803e2a08f25', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'35aad6fa-2d18-46cd-80e1-c9bdb67bc06c', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'e3d8255b-f249-4ad6-a103-7c78d3ff5fbe', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'3d11c199-5dec-4757-b2db-707fa373d163', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'4013bbaf-0e31-4d28-a3bd-83e30496a7af', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'3f1e5832-2de4-417d-b3b8-51b3aaae05c9', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'f810cf3d-b16a-4ae9-825e-8427183b5268', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'2a3badfb-0b00-49b6-b94d-e7e59c384189', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'1a248158-0ad0-430e-9fe6-984c8dc74e24', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'670ba364-a787-4ff2-a87c-b45847beec3f', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'd363b3e0-e534-4fec-acdc-99f4a22ceec6', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'45491f7c-7b86-48dd-97ff-764b0e9eb105', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'98f28069-01e1-487b-98f6-9f25ab071c90', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'9f799e9a-178d-4c8d-8824-bdedfc7223e6', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'44b44938-93ba-422c-a378-a599bf38e6a0', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'01e1daf6-5f6a-4460-a7f1-a62ddd1beddf', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'28cb5e67-832f-4720-a4d7-a746ca097916', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'32807c37-f003-4c1f-b8c8-1916c706ccfc', 0, 0, 0, 0)
INSERT [dbo].[Permissions] ([id], [groupId], [tableId], [canAdd], [canEdit], [canDelete], [canRead]) VALUES (N'9fc65f9f-e95a-4857-b716-a9f119cb74de', N'230868c0-d851-40dd-8cbe-0c03857071f6', N'5fb5c554-3615-47fc-bf8d-2452c521a908', 0, 0, 0, 0)
/****** Object:  Table [dbo].[Account]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[creationDate] [datetime] NULL,
	[isAdmin] [bit] NOT NULL,
	[groupId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([id], [name], [password], [email], [creationDate], [isAdmin], [groupId]) VALUES (N'4b7e2848-5a43-402d-a24d-6e899b971b7f', N'mostava', N'mostava', N'mosl.hamed@hotmao.cpom', CAST(0x0000A6C30156650F AS DateTime), 0, N'230868c0-d851-40dd-8cbe-0c03857071f6')
INSERT [dbo].[Account] ([id], [name], [password], [email], [creationDate], [isAdmin], [groupId]) VALUES (N'2dd38227-168e-4606-a338-d4ae005a9ced', N'ahmed', N'ahmed', N'mosl.hamed@hotmao.cpom', NULL, 1, N'230868c0-d851-40dd-8cbe-0c03857071f6')
/****** Object:  Table [dbo].[SystemPerson]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemPerson](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](250) NULL,
	[gender] [nvarchar](20) NULL,
	[religion] [nvarchar](20) NULL,
	[nationality] [nvarchar](50) NULL,
	[maritalStatus] [nvarchar](50) NULL,
	[insuranceNo] [nvarchar](50) NULL,
	[SSN] [nvarchar](14) NULL,
	[DateofBirth] [datetime] NULL,
	[Phone] [nvarchar](10) NULL,
	[mobile1] [nvarchar](15) NULL,
	[mobile2] [nvarchar](15) NULL,
	[place] [nvarchar](50) NULL,
	[cv] [nvarchar](50) NULL,
	[joinDate] [datetime] NULL,
	[leaveDate] [datetime] NULL,
	[leaveReason] [nvarchar](150) NULL,
	[scientificDegree] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[jobId] [uniqueidentifier] NULL,
	[specializationId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_SystemPerson] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SystemPerson] ([id], [name], [address], [gender], [religion], [nationality], [maritalStatus], [insuranceNo], [SSN], [DateofBirth], [Phone], [mobile1], [mobile2], [place], [cv], [joinDate], [leaveDate], [leaveReason], [scientificDegree], [Type], [jobId], [specializationId]) VALUES (N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'mostava', N'asldh', N'Male', N'Muslim', N'Egyptian', N'Single', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4d8f1d2b-3707-44f5-93ea-14ec17547f79seobook53.pdf', NULL, NULL, NULL, N'Doctor', NULL, N'069d4577-e71e-4ac9-8909-92459a0fce2f', N'ec93ce9c-a5d9-4f5c-8e67-ebe5eed0582b')
INSERT [dbo].[SystemPerson] ([id], [name], [address], [gender], [religion], [nationality], [maritalStatus], [insuranceNo], [SSN], [DateofBirth], [Phone], [mobile1], [mobile2], [place], [cv], [joinDate], [leaveDate], [leaveReason], [scientificDegree], [Type], [jobId], [specializationId]) VALUES (N'b56a6915-5b14-43c2-9e52-afe550de4342', N'ahmed', N'2ss', N'Male', N'Muslim', N'Egyptian', N'Single', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Doctor', NULL, N'069d4577-e71e-4ac9-8909-92459a0fce2f', N'c263b1ff-15ed-4566-8ab5-fcd59d11d8ca')
/****** Object:  Table [dbo].[patient]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patient](
	[id] [uniqueidentifier] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[diagnosis] [nvarchar](100) NULL,
	[diagnosisCode] [nvarchar](50) NULL,
	[notes] [nvarchar](150) NULL,
	[masterStatus] [nvarchar](50) NULL,
	[dateofDiagnosis] [datetime] NULL,
	[firstStatus] [nvarchar](50) NULL,
	[dateofRelapse] [datetime] NULL,
	[firstPresentationDate] [datetime] NULL,
	[birthDate] [datetime] NULL,
	[doctorId] [uniqueidentifier] NULL,
	[age] [int] NULL,
	[gender] [nvarchar](10) NULL,
	[referredFrom] [nvarchar](50) NULL,
	[education] [nvarchar](50) NULL,
	[nationality] [nvarchar](50) NULL,
	[maritalStatus] [nvarchar](50) NULL,
	[occupation] [nvarchar](50) NULL,
	[noofChildren] [int] NULL,
	[ageofOldest] [int] NULL,
	[ageofYoungest] [int] NULL,
	[phone1] [nvarchar](15) NULL,
	[phone2] [nvarchar](15) NULL,
	[phone3] [nvarchar](15) NULL,
	[email] [nvarchar](50) NULL,
	[governorate] [nvarchar](50) NULL,
	[address] [nvarchar](250) NULL,
	[relationName] [nvarchar](50) NULL,
	[relation] [nvarchar](50) NULL,
	[relationPhone1] [nvarchar](15) NULL,
	[relationPhone2] [nvarchar](15) NULL,
	[relationPhone3] [nvarchar](15) NULL,
	[relationAddress] [nvarchar](250) NULL,
	[relationGovernorate] [nvarchar](50) NULL,
	[demographic] [nvarchar](50) NULL,
	[demographicType] [nvarchar](50) NULL,
	[demographicSince] [nvarchar](4) NULL,
	[packsNumber] [int] NULL,
	[alcoholIntake] [bit] NOT NULL,
	[menstrual] [nvarchar](50) NULL,
	[LMP] [bit] NOT NULL,
	[LMPDate] [datetime] NULL,
	[contraception] [nvarchar](50) NULL,
	[pregnancyatDiagnosis] [bit] NOT NULL,
	[RelationDisease] [nvarchar](50) NULL,
	[RelationAgeatDiagnosis] [int] NULL,
	[Diabetes] [bit] NOT NULL,
	[diabetesSince] [datetime] NULL,
	[diabetesType] [nvarchar](50) NULL,
	[hypertension] [bit] NOT NULL,
	[hypertensionSince] [datetime] NULL,
	[hypertensionType] [nvarchar](50) NULL,
	[hepatitiesC] [bit] NOT NULL,
	[hepatitiesCSince] [datetime] NULL,
	[hepatitiesCType] [nvarchar](50) NULL,
	[bilharziasis] [bit] NOT NULL,
	[bilharziasisSince] [datetime] NULL,
	[bilharziasisType] [nvarchar](50) NULL,
	[cardiac] [bit] NOT NULL,
	[cardiacSince] [datetime] NULL,
	[cardiacType] [nvarchar](50) NULL,
	[autoImmuneDisease] [bit] NOT NULL,
	[autoImmuneDiseaseSince] [datetime] NULL,
	[autoImmuneDiseaseType] [nvarchar](50) NULL,
	[allergy] [bit] NOT NULL,
	[allergySince] [datetime] NULL,
	[allergyType] [nvarchar](50) NULL,
 CONSTRAINT [PK_patient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[patient] ([id], [name], [diagnosis], [diagnosisCode], [notes], [masterStatus], [dateofDiagnosis], [firstStatus], [dateofRelapse], [firstPresentationDate], [birthDate], [doctorId], [age], [gender], [referredFrom], [education], [nationality], [maritalStatus], [occupation], [noofChildren], [ageofOldest], [ageofYoungest], [phone1], [phone2], [phone3], [email], [governorate], [address], [relationName], [relation], [relationPhone1], [relationPhone2], [relationPhone3], [relationAddress], [relationGovernorate], [demographic], [demographicType], [demographicSince], [packsNumber], [alcoholIntake], [menstrual], [LMP], [LMPDate], [contraception], [pregnancyatDiagnosis], [RelationDisease], [RelationAgeatDiagnosis], [Diabetes], [diabetesSince], [diabetesType], [hypertension], [hypertensionSince], [hypertensionType], [hepatitiesC], [hepatitiesCSince], [hepatitiesCType], [bilharziasis], [bilharziasisSince], [bilharziasisType], [cardiac], [cardiacSince], [cardiacType], [autoImmuneDisease], [autoImmuneDiseaseSince], [autoImmuneDiseaseType], [allergy], [allergySince], [allergyType]) VALUES (N'6d0f8c5f-94e7-4400-b74c-ce36add7db28', N'test1', N'asd', N'asda', N'sdfd', N'Under Treatment', CAST(0x0000A6A500000000 AS DateTime), NULL, CAST(0x0000A69D00000000 AS DateTime), CAST(0x0000A69B00000000 AS DateTime), CAST(0x0000A69300000000 AS DateTime), N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', 0, N'Male', NULL, NULL, N'Egyptian', N'Single', N'here', 2, 4, 3, NULL, NULL, NULL, NULL, N'Cairo', NULL, NULL, N'Brother', NULL, NULL, NULL, NULL, N'Cairo', N'Smoking', N'Cigerette', NULL, 5, 1, NULL, 0, NULL, NULL, 0, NULL, 12, 0, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, 1, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL, 0, NULL, NULL)
/****** Object:  Table [dbo].[Reservation]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[id] [uniqueidentifier] NOT NULL,
	[patientName] [nvarchar](50) NULL,
	[fromTime] [datetime] NULL,
	[toTime] [datetime] NULL,
	[reservationType] [nvarchar](50) NULL,
	[notes] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL,
	[doctorId] [uniqueidentifier] NULL,
	[roomNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Reservation] ([id], [patientName], [fromTime], [toTime], [reservationType], [notes], [status], [doctorId], [roomNumber]) VALUES (N'9dd67edf-7e93-4840-9624-14e6f751a0c4', N'asd', CAST(0x0000A68700000000 AS DateTime), CAST(0x0000A6B900000000 AS DateTime), N'asd', N'asd', N'asd', N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'12')
INSERT [dbo].[Reservation] ([id], [patientName], [fromTime], [toTime], [reservationType], [notes], [status], [doctorId], [roomNumber]) VALUES (N'a2a98f7b-4fd9-409d-989f-81b13b346f1e', N'asd', CAST(0x0000A6B200000000 AS DateTime), CAST(0x0000A6B100000000 AS DateTime), N'as', N'das', N'sad', N'b56a6915-5b14-43c2-9e52-afe550de4342', N'13')
INSERT [dbo].[Reservation] ([id], [patientName], [fromTime], [toTime], [reservationType], [notes], [status], [doctorId], [roomNumber]) VALUES (N'f51e2c10-ec3a-4c99-983f-8c73e7a82eef', N'asd', CAST(0x0000A6B100000000 AS DateTime), CAST(0x0000A6BA00000000 AS DateTime), N'asd', N'asd', N'da', N'b56a6915-5b14-43c2-9e52-afe550de4342', N'12')
INSERT [dbo].[Reservation] ([id], [patientName], [fromTime], [toTime], [reservationType], [notes], [status], [doctorId], [roomNumber]) VALUES (N'634b048d-ca24-49ae-984c-acae132b063a', N'kashd', CAST(0x0000A6B100000000 AS DateTime), CAST(0x0000A6B400000000 AS DateTime), N'dasd', N'asd', N'asd', N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'12')
INSERT [dbo].[Reservation] ([id], [patientName], [fromTime], [toTime], [reservationType], [notes], [status], [doctorId], [roomNumber]) VALUES (N'7f9ae937-77fc-4c39-9f59-b9f680e0c4a5', N'sad', CAST(0x0000A6B100000000 AS DateTime), CAST(0x0000A6C100000000 AS DateTime), N'asd', N'asd', N'asd', N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'13')
/****** Object:  Table [dbo].[visits]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[visits](
	[id] [uniqueidentifier] NOT NULL,
	[visitDate] [datetime] NULL,
	[visitStatus] [nvarchar](50) NULL,
	[visitSite] [nvarchar](50) NULL,
	[complaintType] [nvarchar](50) NULL,
	[PresentHistory] [nvarchar](max) NULL,
	[decision] [nvarchar](max) NULL,
	[requestedInvestigations] [nvarchar](50) NULL,
	[GeneralAppearance] [nvarchar](50) NULL,
	[mentality] [nvarchar](50) NULL,
	[Built] [nvarchar](50) NULL,
	[Pallor] [bit] NOT NULL,
	[jaundice] [bit] NOT NULL,
	[cyanosis] [bit] NOT NULL,
	[postureDuringWalking] [bit] NOT NULL,
	[postureStanding] [bit] NOT NULL,
	[postureSitting] [bit] NOT NULL,
	[postureLyingSupineorPhone] [bit] NOT NULL,
	[vitalSigns] [nvarchar](50) NULL,
	[DoctorId] [uniqueidentifier] NULL,
	[patientId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_visits] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[visits] ([id], [visitDate], [visitStatus], [visitSite], [complaintType], [PresentHistory], [decision], [requestedInvestigations], [GeneralAppearance], [mentality], [Built], [Pallor], [jaundice], [cyanosis], [postureDuringWalking], [postureStanding], [postureSitting], [postureLyingSupineorPhone], [vitalSigns], [DoctorId], [patientId]) VALUES (N'4289d834-2f7f-4e31-b718-4f312c956ae1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[visits] ([id], [visitDate], [visitStatus], [visitSite], [complaintType], [PresentHistory], [decision], [requestedInvestigations], [GeneralAppearance], [mentality], [Built], [Pallor], [jaundice], [cyanosis], [postureDuringWalking], [postureStanding], [postureSitting], [postureLyingSupineorPhone], [vitalSigns], [DoctorId], [patientId]) VALUES (N'db2d6f7a-2fe2-4ecb-8ae0-8f4349eb5647', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', NULL)
INSERT [dbo].[visits] ([id], [visitDate], [visitStatus], [visitSite], [complaintType], [PresentHistory], [decision], [requestedInvestigations], [GeneralAppearance], [mentality], [Built], [Pallor], [jaundice], [cyanosis], [postureDuringWalking], [postureStanding], [postureSitting], [postureLyingSupineorPhone], [vitalSigns], [DoctorId], [patientId]) VALUES (N'3c580489-7b6f-427b-9285-ae62cc330796', CAST(0x0000A6A600000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'6d0f8c5f-94e7-4400-b74c-ce36add7db28')
INSERT [dbo].[visits] ([id], [visitDate], [visitStatus], [visitSite], [complaintType], [PresentHistory], [decision], [requestedInvestigations], [GeneralAppearance], [mentality], [Built], [Pallor], [jaundice], [cyanosis], [postureDuringWalking], [postureStanding], [postureSitting], [postureLyingSupineorPhone], [vitalSigns], [DoctorId], [patientId]) VALUES (N'47a6f72c-e0c5-4e9a-b0c8-fc76f683726d', CAST(0x0000A69500000000 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, NULL, N'4d8f1d2b-3707-44f5-93ea-14ec17547f79', N'6d0f8c5f-94e7-4400-b74c-ce36add7db28')
/****** Object:  Table [dbo].[surgicalHistory]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[surgicalHistory](
	[id] [uniqueidentifier] NOT NULL,
	[operationName] [nvarchar](50) NULL,
	[operationDate] [datetime] NULL,
	[patientId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_surgicalHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[surgicalHistory] ([id], [operationName], [operationDate], [patientId]) VALUES (N'13d7b048-5c72-4156-a144-ee71f4b4f2e4', N'one', CAST(0x0000A69400000000 AS DateTime), N'6d0f8c5f-94e7-4400-b74c-ce36add7db28')
/****** Object:  Table [dbo].[Laboratory]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Laboratory](
	[id] [uniqueidentifier] NOT NULL,
	[Laboratory] [nvarchar](50) NULL,
	[DateofLab] [datetime] NULL,
	[visitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Laboratory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Laboratory] ([id], [Laboratory], [DateofLab], [visitId]) VALUES (N'5e0ad891-7673-4980-af2d-e08993db1543', N'mostavaaa', CAST(0x0000A69E00000000 AS DateTime), N'3c580489-7b6f-427b-9285-ae62cc330796')
/****** Object:  Table [dbo].[Imaging]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imaging](
	[id] [uniqueidentifier] NOT NULL,
	[ImageDate] [datetime] NULL,
	[ImageCenter] [nvarchar](50) NULL,
	[TypeofImage] [nvarchar](50) NULL,
	[Site] [nvarchar](50) NULL,
	[Comments] [nvarchar](max) NULL,
	[ImageName] [nvarchar](50) NULL,
	[VisitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Imaging] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Imaging] ([id], [ImageDate], [ImageCenter], [TypeofImage], [Site], [Comments], [ImageName], [VisitId]) VALUES (N'c759f602-9604-4ce4-b410-086398c9a095', CAST(0x0000A69C00000000 AS DateTime), N'hena', N'pngg', N'hnak', N'mfesh', N'mos', N'3c580489-7b6f-427b-9285-ae62cc330796')
INSERT [dbo].[Imaging] ([id], [ImageDate], [ImageCenter], [TypeofImage], [Site], [Comments], [ImageName], [VisitId]) VALUES (N'1a2f1641-de64-41a9-90c2-46ded2dd9b7c', CAST(0x0000A6B200000000 AS DateTime), N'lkdsf', N'lkds', N'klsdf', N'la', N'd', N'3c580489-7b6f-427b-9285-ae62cc330796')
/****** Object:  Table [dbo].[examination]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examination](
	[id] [uniqueidentifier] NOT NULL,
	[redness] [bit] NOT NULL,
	[swelling] [bit] NOT NULL,
	[scars] [bit] NOT NULL,
	[LTWastingofQuadriceps] [bit] NOT NULL,
	[RTWastingofQuadriceps] [bit] NOT NULL,
	[LTWastingofQuadricepsCompare] [nvarchar](50) NULL,
	[RTWastingofQuadricepsCompare] [nvarchar](50) NULL,
	[LTWastingofScapula] [bit] NOT NULL,
	[RTWastingofScapula] [bit] NOT NULL,
	[LTLognThoracicNerveInjury] [bit] NOT NULL,
	[RTLognThoracicNerveInjury1] [bit] NOT NULL,
	[Effusion] [bit] NOT NULL,
	[EffusionType] [nvarchar](50) NULL,
	[NearByJoints] [bit] NOT NULL,
	[NearByJointsType] [nvarchar](50) NULL,
	[GaitPattern] [bit] NOT NULL,
	[GaitPatternType] [nvarchar](50) NULL,
	[visitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_examination] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[examination] ([id], [redness], [swelling], [scars], [LTWastingofQuadriceps], [RTWastingofQuadriceps], [LTWastingofQuadricepsCompare], [RTWastingofQuadricepsCompare], [LTWastingofScapula], [RTWastingofScapula], [LTLognThoracicNerveInjury], [RTLognThoracicNerveInjury1], [Effusion], [EffusionType], [NearByJoints], [NearByJointsType], [GaitPattern], [GaitPatternType], [visitId]) VALUES (N'bc1f276e-d10c-4b8f-8945-456f467a1ec7', 1, 1, 0, 1, 0, NULL, NULL, 0, 0, 0, 1, 0, N'asd', 0, N'asd', 0, N'ad', NULL)
INSERT [dbo].[examination] ([id], [redness], [swelling], [scars], [LTWastingofQuadriceps], [RTWastingofQuadriceps], [LTWastingofQuadricepsCompare], [RTWastingofQuadricepsCompare], [LTWastingofScapula], [RTWastingofScapula], [LTLognThoracicNerveInjury], [RTLognThoracicNerveInjury1], [Effusion], [EffusionType], [NearByJoints], [NearByJointsType], [GaitPattern], [GaitPatternType], [visitId]) VALUES (N'e085ce9c-9f6a-4de3-8c29-696e8661a16e', 1, 0, 1, 0, 0, NULL, NULL, 0, 0, 0, 0, 1, NULL, 0, NULL, 1, NULL, NULL)
INSERT [dbo].[examination] ([id], [redness], [swelling], [scars], [LTWastingofQuadriceps], [RTWastingofQuadriceps], [LTWastingofQuadricepsCompare], [RTWastingofQuadricepsCompare], [LTWastingofScapula], [RTWastingofScapula], [LTLognThoracicNerveInjury], [RTLognThoracicNerveInjury1], [Effusion], [EffusionType], [NearByJoints], [NearByJointsType], [GaitPattern], [GaitPatternType], [visitId]) VALUES (N'c4cd1978-f75a-4ed6-9727-beaf98b2f21b', 0, 1, 1, 0, 1, NULL, NULL, 0, 0, 0, 0, 0, N'sdf', 0, N'sd', 1, NULL, N'3c580489-7b6f-427b-9285-ae62cc330796')
/****** Object:  Table [dbo].[Endoscopy]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endoscopy](
	[id] [uniqueidentifier] NOT NULL,
	[Endoscopy] [nvarchar](50) NULL,
	[EndoscopyType] [nvarchar](50) NULL,
	[site] [nvarchar](50) NULL,
	[comments] [nvarchar](max) NULL,
	[graph] [nvarchar](50) NULL,
	[visitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Endoscopy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Endoscopy] ([id], [Endoscopy], [EndoscopyType], [site], [comments], [graph], [visitId]) VALUES (N'137c0f4c-19a1-4363-a090-09ebd1ba0317', N'ind', N'hos', N'oamsd', N'kansd', N'sada', N'3c580489-7b6f-427b-9285-ae62cc330796')
/****** Object:  Table [dbo].[Complaint]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complaint](
	[id] [uniqueidentifier] NOT NULL,
	[complaintName] [nvarchar](50) NULL,
	[visitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Complaint] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prescription]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prescription](
	[id] [uniqueidentifier] NOT NULL,
	[notes] [nvarchar](max) NULL,
	[visitId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_prescription] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[prescription] ([id], [notes], [visitId]) VALUES (N'4a46dc5c-3207-4715-b081-fc12a7b833a6', N's', N'3c580489-7b6f-427b-9285-ae62cc330796')
/****** Object:  Table [dbo].[medicine]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[medicine](
	[id] [uniqueidentifier] NOT NULL,
	[code] [nvarchar](50) NULL,
	[scientificName] [nvarchar](50) NULL,
	[commercialName] [nvarchar](50) NULL,
	[activeIngredient] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[dose] [nvarchar](50) NULL,
	[sideEffects] [nvarchar](150) NULL,
	[notes] [nvarchar](150) NULL,
	[UOM] [nvarchar](50) NULL,
	[Route] [nvarchar](50) NULL,
	[Duration] [nvarchar](50) NULL,
	[Frequency] [nvarchar](50) NULL,
	[prescriptionId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_medicine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[medicine] ([id], [code], [scientificName], [commercialName], [activeIngredient], [type], [dose], [sideEffects], [notes], [UOM], [Route], [Duration], [Frequency], [prescriptionId]) VALUES (N'f9b652c8-ef35-405e-9cad-29c1c9499cd5', N'asd', N'asd', N'asd', N'ads', NULL, NULL, N'ads', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[medicine] ([id], [code], [scientificName], [commercialName], [activeIngredient], [type], [dose], [sideEffects], [notes], [UOM], [Route], [Duration], [Frequency], [prescriptionId]) VALUES (N'182819bc-2c47-4679-84fb-349d65590d41', N'asd', N'asd', N'asd', N'ads', NULL, NULL, N'ads', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[medicine] ([id], [code], [scientificName], [commercialName], [activeIngredient], [type], [dose], [sideEffects], [notes], [UOM], [Route], [Duration], [Frequency], [prescriptionId]) VALUES (N'afcab269-3a79-4578-8b10-47ea483fabd4', N'asd', N'asd', N'asd', N'asd', NULL, NULL, N'asd', N'asd', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[medicine] ([id], [code], [scientificName], [commercialName], [activeIngredient], [type], [dose], [sideEffects], [notes], [UOM], [Route], [Duration], [Frequency], [prescriptionId]) VALUES (N'd49b089f-2bf0-4ed0-8c2e-bec081fc9388', N'asda', N'as', N'as', N'as', NULL, NULL, N'as', N'as', NULL, N'as', N'as', NULL, N'4a46dc5c-3207-4715-b081-fc12a7b833a6')
/****** Object:  Table [dbo].[Labs]    Script Date: 01/27/2017 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labs](
	[id] [uniqueidentifier] NOT NULL,
	[LabType] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[result] [int] NULL,
	[Unit] [nvarchar](50) NULL,
	[ResultStatus] [nvarchar](50) NULL,
	[graph] [nvarchar](50) NULL,
	[LaboratoryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Labs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Labs] ([id], [LabType], [Name], [result], [Unit], [ResultStatus], [graph], [LaboratoryId]) VALUES (N'24af1c2b-e0ae-4015-b968-e5982184f0c4', N'cbc', N'hge', 15, N'd/dl', N'Low', NULL, N'5e0ad891-7673-4980-af2d-e08993db1543')
/****** Object:  Default [DF_Tables_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Tables] ADD  CONSTRAINT [DF_Tables_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_Job_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Job] ADD  CONSTRAINT [DF_Job_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_Specialization_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Specialization] ADD  CONSTRAINT [DF_Specialization_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_Permissions_canAdd]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Permissions_canAdd]  DEFAULT ((0)) FOR [canAdd]
GO
/****** Object:  Default [DF_Table_1_canAdd1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Table_1_canAdd1]  DEFAULT ((0)) FOR [canEdit]
GO
/****** Object:  Default [DF_Table_1_canAdd1_1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Table_1_canAdd1_1]  DEFAULT ((0)) FOR [canDelete]
GO
/****** Object:  Default [DF_Table_1_canDelete1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions] ADD  CONSTRAINT [DF_Table_1_canDelete1]  DEFAULT ((0)) FOR [canRead]
GO
/****** Object:  Default [DF_Account_isAdmin]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_isAdmin]  DEFAULT ((0)) FOR [isAdmin]
GO
/****** Object:  Default [DF_SystemPerson_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[SystemPerson] ADD  CONSTRAINT [DF_SystemPerson_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_patient_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_patient_alcoholIntake]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_alcoholIntake]  DEFAULT ((0)) FOR [alcoholIntake]
GO
/****** Object:  Default [DF_patient_LMP]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_LMP]  DEFAULT ((0)) FOR [LMP]
GO
/****** Object:  Default [DF_patient_pregnancyatDiagnosis]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_pregnancyatDiagnosis]  DEFAULT ((0)) FOR [pregnancyatDiagnosis]
GO
/****** Object:  Default [DF_patient_Diabetes]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_Diabetes]  DEFAULT ((0)) FOR [Diabetes]
GO
/****** Object:  Default [DF_patient_hypertension]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_hypertension]  DEFAULT ((0)) FOR [hypertension]
GO
/****** Object:  Default [DF_patient_hepatitiesC]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_hepatitiesC]  DEFAULT ((0)) FOR [hepatitiesC]
GO
/****** Object:  Default [DF_patient_bilharziasis]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_bilharziasis]  DEFAULT ((0)) FOR [bilharziasis]
GO
/****** Object:  Default [DF_patient_cardiac]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_cardiac]  DEFAULT ((0)) FOR [cardiac]
GO
/****** Object:  Default [DF_patient_autoImmuneDisease]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_autoImmuneDisease]  DEFAULT ((0)) FOR [autoImmuneDisease]
GO
/****** Object:  Default [DF_patient_allergy]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient] ADD  CONSTRAINT [DF_patient_allergy]  DEFAULT ((0)) FOR [allergy]
GO
/****** Object:  Default [DF_visits_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_visits_Pallor]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_Pallor]  DEFAULT ((0)) FOR [Pallor]
GO
/****** Object:  Default [DF_visits_jaundice]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_jaundice]  DEFAULT ((0)) FOR [jaundice]
GO
/****** Object:  Default [DF_visits_cyanosis]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_cyanosis]  DEFAULT ((0)) FOR [cyanosis]
GO
/****** Object:  Default [DF_visits_postureDuringWalking]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_postureDuringWalking]  DEFAULT ((0)) FOR [postureDuringWalking]
GO
/****** Object:  Default [DF_visits_postureStanding]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_postureStanding]  DEFAULT ((0)) FOR [postureStanding]
GO
/****** Object:  Default [DF_visits_postureSitting]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_postureSitting]  DEFAULT ((0)) FOR [postureSitting]
GO
/****** Object:  Default [DF_visits_postureLyingSupineorPhone]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits] ADD  CONSTRAINT [DF_visits_postureLyingSupineorPhone]  DEFAULT ((0)) FOR [postureLyingSupineorPhone]
GO
/****** Object:  Default [DF_Table_1_scars1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_scars1]  DEFAULT ((0)) FOR [redness]
GO
/****** Object:  Default [DF_Table_1_scars2]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_scars2]  DEFAULT ((0)) FOR [swelling]
GO
/****** Object:  Default [DF_examination_scars]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_examination_scars]  DEFAULT ((0)) FOR [scars]
GO
/****** Object:  Default [DF_Table_1_scars1_1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_scars1_1]  DEFAULT ((0)) FOR [LTWastingofQuadriceps]
GO
/****** Object:  Default [DF_examination_RTWastingofQuadriceps]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_examination_RTWastingofQuadriceps]  DEFAULT ((0)) FOR [RTWastingofQuadriceps]
GO
/****** Object:  Default [DF_Table_1_LTWastingofQuadriceps1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_LTWastingofQuadriceps1]  DEFAULT ((0)) FOR [LTWastingofScapula]
GO
/****** Object:  Default [DF_Table_1_LTWastingofScapula1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_LTWastingofScapula1]  DEFAULT ((0)) FOR [RTWastingofScapula]
GO
/****** Object:  Default [DF_examination_LTLognThoracicNerveInjury]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_examination_LTLognThoracicNerveInjury]  DEFAULT ((0)) FOR [LTLognThoracicNerveInjury]
GO
/****** Object:  Default [DF_Table_1_LTLognThoracicNerveInjury1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_LTLognThoracicNerveInjury1]  DEFAULT ((0)) FOR [RTLognThoracicNerveInjury1]
GO
/****** Object:  Default [DF_Table_1_RTLognThoracicNerveInjury11]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_RTLognThoracicNerveInjury11]  DEFAULT ((0)) FOR [Effusion]
GO
/****** Object:  Default [DF_Table_1_Effusion1]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_Table_1_Effusion1]  DEFAULT ((0)) FOR [NearByJoints]
GO
/****** Object:  Default [DF_examination_GaitPattern]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination] ADD  CONSTRAINT [DF_examination_GaitPattern]  DEFAULT ((0)) FOR [GaitPattern]
GO
/****** Object:  Default [DF_Complaint_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Complaint] ADD  CONSTRAINT [DF_Complaint_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_medicine_id]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[medicine] ADD  CONSTRAINT [DF_medicine_id]  DEFAULT (newid()) FOR [id]
GO
/****** Object:  Default [DF_Labs_result]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Labs] ADD  CONSTRAINT [DF_Labs_result]  DEFAULT ((0)) FOR [result]
GO
/****** Object:  ForeignKey [FK_Specialization_Job]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Specialization]  WITH CHECK ADD  CONSTRAINT [FK_Specialization_Job] FOREIGN KEY([jobId])
REFERENCES [dbo].[Job] ([id])
GO
ALTER TABLE [dbo].[Specialization] CHECK CONSTRAINT [FK_Specialization_Job]
GO
/****** Object:  ForeignKey [FK_Permissions_Group]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Group] FOREIGN KEY([groupId])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Group]
GO
/****** Object:  ForeignKey [FK_Permissions_Tables]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_Tables] FOREIGN KEY([tableId])
REFERENCES [dbo].[Tables] ([id])
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_Tables]
GO
/****** Object:  ForeignKey [FK_Account_Group]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Group] FOREIGN KEY([groupId])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Group]
GO
/****** Object:  ForeignKey [FK_SystemPerson_Job]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[SystemPerson]  WITH CHECK ADD  CONSTRAINT [FK_SystemPerson_Job] FOREIGN KEY([jobId])
REFERENCES [dbo].[Job] ([id])
GO
ALTER TABLE [dbo].[SystemPerson] CHECK CONSTRAINT [FK_SystemPerson_Job]
GO
/****** Object:  ForeignKey [FK_SystemPerson_Specialization]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[SystemPerson]  WITH CHECK ADD  CONSTRAINT [FK_SystemPerson_Specialization] FOREIGN KEY([specializationId])
REFERENCES [dbo].[Specialization] ([id])
GO
ALTER TABLE [dbo].[SystemPerson] CHECK CONSTRAINT [FK_SystemPerson_Specialization]
GO
/****** Object:  ForeignKey [FK_patient_SystemPerson]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[patient]  WITH CHECK ADD  CONSTRAINT [FK_patient_SystemPerson] FOREIGN KEY([doctorId])
REFERENCES [dbo].[SystemPerson] ([id])
GO
ALTER TABLE [dbo].[patient] CHECK CONSTRAINT [FK_patient_SystemPerson]
GO
/****** Object:  ForeignKey [FK_Reservation_SystemPerson]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_SystemPerson] FOREIGN KEY([doctorId])
REFERENCES [dbo].[SystemPerson] ([id])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_SystemPerson]
GO
/****** Object:  ForeignKey [FK_visits_patient]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits]  WITH CHECK ADD  CONSTRAINT [FK_visits_patient] FOREIGN KEY([patientId])
REFERENCES [dbo].[patient] ([id])
GO
ALTER TABLE [dbo].[visits] CHECK CONSTRAINT [FK_visits_patient]
GO
/****** Object:  ForeignKey [FK_visits_SystemPerson]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[visits]  WITH CHECK ADD  CONSTRAINT [FK_visits_SystemPerson] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[SystemPerson] ([id])
GO
ALTER TABLE [dbo].[visits] CHECK CONSTRAINT [FK_visits_SystemPerson]
GO
/****** Object:  ForeignKey [FK_surgicalHistory_patient]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[surgicalHistory]  WITH CHECK ADD  CONSTRAINT [FK_surgicalHistory_patient] FOREIGN KEY([patientId])
REFERENCES [dbo].[patient] ([id])
GO
ALTER TABLE [dbo].[surgicalHistory] CHECK CONSTRAINT [FK_surgicalHistory_patient]
GO
/****** Object:  ForeignKey [FK_Laboratory_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Laboratory]  WITH CHECK ADD  CONSTRAINT [FK_Laboratory_visits] FOREIGN KEY([visitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[Laboratory] CHECK CONSTRAINT [FK_Laboratory_visits]
GO
/****** Object:  ForeignKey [FK_Imaging_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Imaging]  WITH CHECK ADD  CONSTRAINT [FK_Imaging_visits] FOREIGN KEY([VisitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[Imaging] CHECK CONSTRAINT [FK_Imaging_visits]
GO
/****** Object:  ForeignKey [FK_examination_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[examination]  WITH CHECK ADD  CONSTRAINT [FK_examination_visits] FOREIGN KEY([visitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[examination] CHECK CONSTRAINT [FK_examination_visits]
GO
/****** Object:  ForeignKey [FK_Endoscopy_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Endoscopy]  WITH CHECK ADD  CONSTRAINT [FK_Endoscopy_visits] FOREIGN KEY([visitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[Endoscopy] CHECK CONSTRAINT [FK_Endoscopy_visits]
GO
/****** Object:  ForeignKey [FK_Complaint_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Complaint]  WITH CHECK ADD  CONSTRAINT [FK_Complaint_visits] FOREIGN KEY([visitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[Complaint] CHECK CONSTRAINT [FK_Complaint_visits]
GO
/****** Object:  ForeignKey [FK_prescription_visits]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[prescription]  WITH CHECK ADD  CONSTRAINT [FK_prescription_visits] FOREIGN KEY([visitId])
REFERENCES [dbo].[visits] ([id])
GO
ALTER TABLE [dbo].[prescription] CHECK CONSTRAINT [FK_prescription_visits]
GO
/****** Object:  ForeignKey [FK_medicine_prescription]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[medicine]  WITH CHECK ADD  CONSTRAINT [FK_medicine_prescription] FOREIGN KEY([prescriptionId])
REFERENCES [dbo].[prescription] ([id])
GO
ALTER TABLE [dbo].[medicine] CHECK CONSTRAINT [FK_medicine_prescription]
GO
/****** Object:  ForeignKey [FK_Labs_Laboratory]    Script Date: 01/27/2017 07:59:27 ******/
ALTER TABLE [dbo].[Labs]  WITH CHECK ADD  CONSTRAINT [FK_Labs_Laboratory] FOREIGN KEY([LaboratoryId])
REFERENCES [dbo].[Laboratory] ([id])
GO
ALTER TABLE [dbo].[Labs] CHECK CONSTRAINT [FK_Labs_Laboratory]
GO
