USE [developerassessment]
GO
/****** Object:  User [RestApi]    Script Date: 18/02/2016 17:28:01 ******/
CREATE USER [RestApi] FOR LOGIN [RestApi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Episode]    Script Date: 18/02/2016 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Episode](
	[EpisodeId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[AdmissionDate] [datetime] NOT NULL,
	[DischargeDate] [datetime] NOT NULL,
	[Diagnosis] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Episode] PRIMARY KEY CLUSTERED 
(
	[EpisodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 18/02/2016 17:28:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[NhsNumber] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET IDENTITY_INSERT [dbo].[Episode] ON 

GO
INSERT [dbo].[Episode] ([EpisodeId], [PatientId], [AdmissionDate], [DischargeDate], [Diagnosis]) VALUES (1, 1, CAST(0x0000A3E100000000 AS DateTime), CAST(0x0000A3F000000000 AS DateTime), N'Irritation of inner ear')
GO
INSERT [dbo].[Episode] ([EpisodeId], [PatientId], [AdmissionDate], [DischargeDate], [Diagnosis]) VALUES (2, 1, CAST(0x0000A46100000000 AS DateTime), CAST(0x0000A46E00000000 AS DateTime), N'Sprained wrist')
GO
INSERT [dbo].[Episode] ([EpisodeId], [PatientId], [AdmissionDate], [DischargeDate], [Diagnosis]) VALUES (3, 1, CAST(0x0000A54E00000000 AS DateTime), CAST(0x0000A55000000000 AS DateTime), N'Stomach cramps')
GO
INSERT [dbo].[Episode] ([EpisodeId], [PatientId], [AdmissionDate], [DischargeDate], [Diagnosis]) VALUES (4, 2, CAST(0x0000A47E00000000 AS DateTime), CAST(0x0000A4A400000000 AS DateTime), N'Laryngitis')
GO
INSERT [dbo].[Episode] ([EpisodeId], [PatientId], [AdmissionDate], [DischargeDate], [Diagnosis]) VALUES (5, 2, CAST(0x0000A4AB00000000 AS DateTime), CAST(0x0000A4B600000000 AS DateTime), N'Athlete''s foot')
GO
SET IDENTITY_INSERT [dbo].[Episode] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

GO
INSERT [dbo].[Patient] ([PatientId], [NhsNumber], [FirstName], [LastName], [DateOfBirth]) VALUES (1, N'1111111111', N'Millicent', N'Hammond', CAST(0x000067E500000000 AS DateTime))
GO
INSERT [dbo].[Patient] ([PatientId], [NhsNumber], [FirstName], [LastName], [DateOfBirth]) VALUES (2, N'2222222222', N'Bobby', N'Atkins', CAST(0x00007C4C00000000 AS DateTime))
GO
INSERT [dbo].[Patient] ([PatientId], [NhsNumber], [FirstName], [LastName], [DateOfBirth]) VALUES (3, N'3333333333', N'Xanthe', N'Camembert', CAST(0x0000832600000000 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
ALTER TABLE [dbo].[Episode]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Episode_dbo.Patient_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patient] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Episode] CHECK CONSTRAINT [FK_dbo.Episode_dbo.Patient_PatientId]
GO

GRANT SELECT ON dbo.Patient TO RestApi
GRANT SELECT ON dbo.Episode TO RestApi