USE [PermitDb]
GO
/****** Object:  Table [dbo].[Permits]    Script Date: 24/07/2022 01:13:53 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Employee_Name] [varchar](50) NOT NULL,
	[Employee_Last_Name] [varchar](50) NOT NULL,
	[PermitTypeId] [int] NOT NULL,
	[PermitDate] [date] NOT NULL,
 CONSTRAINT [PK_Permits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermitType]    Script Date: 24/07/2022 01:13:53 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermitType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NOT NULL,
 CONSTRAINT [PK_PermitType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permits] ON 
GO
INSERT [dbo].[Permits] ([Id], [Employee_Name], [Employee_Last_Name], [PermitTypeId], [PermitDate]) VALUES (7, N'RAFAEL PEDRO', N'GONZALES', 1, CAST(N'2022-07-24' AS Date))
GO
INSERT [dbo].[Permits] ([Id], [Employee_Name], [Employee_Last_Name], [PermitTypeId], [PermitDate]) VALUES (8, N'JUAN', N'GONZALES', 2, CAST(N'2022-07-22' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Permits] OFF
GO
SET IDENTITY_INSERT [dbo].[PermitType] ON 
GO
INSERT [dbo].[PermitType] ([Id], [Description]) VALUES (1, N'Enfermedad')
GO
INSERT [dbo].[PermitType] ([Id], [Description]) VALUES (2, N'Diligencias')
GO
INSERT [dbo].[PermitType] ([Id], [Description]) VALUES (3, N'Otros')
GO
SET IDENTITY_INSERT [dbo].[PermitType] OFF
GO
ALTER TABLE [dbo].[Permits]  WITH CHECK ADD  CONSTRAINT [FK_Permits_PermitType] FOREIGN KEY([PermitTypeId])
REFERENCES [dbo].[PermitType] ([Id])
GO
ALTER TABLE [dbo].[Permits] CHECK CONSTRAINT [FK_Permits_PermitType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique record identifier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the employee' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits', @level2type=N'COLUMN',@level2name=N'Employee_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Last Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits', @level2type=N'COLUMN',@level2name=N'Employee_Last_Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of permit requested' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits', @level2type=N'COLUMN',@level2name=N'PermitTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date for when the permit is requested' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits', @level2type=N'COLUMN',@level2name=N'PermitDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table to store the requests of a certain employee permissions' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador unico del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermitType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permit Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermitType', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table to store the types of permits performed by employees
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermitType'
GO
