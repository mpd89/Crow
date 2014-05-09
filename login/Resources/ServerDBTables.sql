USE [!!SiteName!!_ServerDB]

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bugsug]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[bugsug](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[ClientMUID] [int] NULL,
	[Type] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[FName] [nvarchar](50) NULL,
	[MI] [nvarchar](1) NULL,
	[LName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Organization] [nvarchar](50) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_bugsug] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientAccess]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClientAccess](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[ClientMUID]  [nvarchar](150) NULL,
	[LastAccess] [datetime] NULL,
	[AccessIP] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Active] [int] NULL,
	[Temp] [int] NULL,
	[SyncTS] [datetime] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_ClientAccess] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClientUpdates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClientUpdates](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[FileContents] [varbinary](MAX) NULL,
	[FileExtension] [nvarchar](50) NULL,
	[FileName] [nvarchar](50) NULL,
	[FileVersion] [nvarchar](50) NULL,
	[FileDate] [datetime] NULL,
	[FileComments] [nvarchar](250) NULL,
	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_ClientUpdates] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CostCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CostCodes](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[CostCode] [nvarchar](255)  NULL,
	[CCDesc] [nvarchar](255)  NULL,
	[JobNumber] [nvarchar](50)  NULL,
	[SubJobNumber] [nvarchar](50)  NULL,
	[FixedFee] [nvarchar](50)  NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
CONSTRAINT [PK_CostCodes] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[EE] [nvarchar](50)  NOT NULL,
	[Last_Name] [nvarchar](255)  NOT NULL,
	[Middle_Init] [nvarchar](255)  NULL,
	[First_Name] [nvarchar](255)  NOT NULL,
	[Craft] [nvarchar](255)  NULL,
	[Classification] [nvarchar](255)  NULL,
	[Get_PerDiem] [nvarchar](50)  NULL,
	[Flag] [nvarchar](255)  NULL,
	[A_Rate] [money] NULL,
	[Total_Bare] [money] NULL,
	[B_Rate] [money] NULL,
	[Shift_Code] [nvarchar](255)  NULL,
	[Shift_Differ] [nvarchar](255)  NULL,
	[Check_Route_Code] [nvarchar](255)  NULL,
	[Full_Name] [nvarchar](255)  NOT NULL,
	[ST_Rate_Payroll] [money] NULL,
	[OT_Rate_Payroll] [money] NULL,
	[ST_Bill_Rate] [money] NULL,
	[OT_Bill_Rate] [money] NULL,
	[Pay_Type] [nvarchar](255)  NULL,
	[Hire_Date] [nvarchar](255)  NULL,
	[Term_Date] [nvarchar](255)  NULL,
	[BrassNum] [nvarchar](255)  NULL,
	[Address] [nvarchar](255)  NULL,
	[City] [nvarchar](255)  NULL,
	[State] [nvarchar](255)  NULL,
	[Zip] [nvarchar](255)  NULL,
	[Phone] [nvarchar](255)  NULL,
	[Notes] [nvarchar](255)  NULL,
	[Country] [nvarchar](255)  NULL,
	[PerDiemAmt] [nvarchar](50)  NULL,
	[PerDiemJobNumber] [nvarchar](50)  NULL,
	[PerDiemCostCode] [nvarchar](50)  NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee_TSGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee_TSGroup](
	[TSGroupMUID] [nvarchar](150) NOT NULL,
	[EmployeeMUID][nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
	CONSTRAINT [PK_Employee_TSGroup] PRIMARY KEY CLUSTERED 
(
	[TSGRoupMUID] ASC,
	[EmployeeMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ErrorLog](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Message] [nvarchar](500) NULL,
	[ClientMUID] [nvarchar](150) NULL,
	[Site] [nvarchar](50) NULL,
	[Project] [int] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemImages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SystemImages](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[DocumentImage] [image] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemImages] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemFeatures]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SystemFeatures](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_SystemFeatures] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permissions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Permissions](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[LevelMUID] [nvarchar](150) NULL,
	[FeatureMUID] [nvarchar](150) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userlog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[userlog](
	[MUID] [nvarchar](150) NOT NULL,
	[UserMUID] [nvarchar](150) NULL,
	[TS] [datetime] NULL,
	[Action] [nvarchar](10) NULL,
	[Time] [datetime] NULL,
	[Project] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_userlog] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[userInfo](
	[MUID] [nvarchar](150) NOT NULL,
	[UserName] [nvarchar](10) NULL,
	[TS] [datetime] NULL,
	[UserPW] [nvarchar](10) NULL,
	[Title] [nvarchar](50) NULL,
	[Number] [nvarchar](20) NULL,
	[FirstName] [nvarchar](30) NULL,
	[MI] [nvarchar](1) NULL,
	[LastName] [nvarchar](30) NULL,
	[Active] [nvarchar](5) NULL,
	[CompanyMUID] [nvarchar](150) NOT NULL,
	[LevelMUID] [nvarchar](150) NOT NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_userInfo] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


INSERT INTO userInfo (MUID,UserName,TS,UserPW,Title,CompanyMUID,LevelMUID) VALUES ('!!MID!!&0011','Admin','!!NOW!!','default','System','!!MID!!&0011','!!MID!!&0011')


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[company](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Active] [nvarchar](10) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[configuration]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[configuration](
	[MUID] [nvarchar](150) NOT NULL,
	[userid] [nvarchar](10) NULL,
	[profilename] [nvarchar](45) NULL,
	[attribute0] [nvarchar](45) NULL,
	[attribute1] [nvarchar](45) NULL,
	[attribute2] [nvarchar](45) NULL,
	[attribute3] [nvarchar](45) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_configuration] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[discipline]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[discipline](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Active] [nvarchar](10) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_discipline] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[groups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[groups](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Active] [nvarchar](10) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_groups] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[levels]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[levels](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Active] [nvarchar](10) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_levels] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[notes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[notes](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[UserName] [nvarchar](45) NULL,
	[Subject] [nvarchar](45) NULL,
	[Description] [nvarchar](max) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_notes] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[owner]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[owner](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Active] [nvarchar](10) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_owner] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[projects](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[Active] [smallint] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ServerInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ServerInfo](
	[MUID] [nvarchar](150) NOT NULL,
	[Parameter] [nvarchar](50) NULL,
	[Value] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_ServerInfo] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


-- Server Info Parameters
INSERT INTO ServerInfo (MUID,Parameter, Value) Values ('!!MID!!&0011','P1','+DZdkAIGhg5WyqYRsvgXqg==') --5 clients
INSERT INTO ServerInfo (MUID,Parameter, Value) Values ('!!MID!!&0012','P2','') --date loaded
INSERT INTO ServerInfo (MUID,Parameter, Value) Values ('!!MID!!&0013','P3','1.0.2.6') --database version


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[project_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[project_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[OwnerMUID] [nvarchar](150) NOT NULL,
	[ProjectMUID] [nvarchar](150) NOT NULL,
	[RequiredManHours] [float] NULL,
	[CurrentLevel] [int] NULL,
	[EarnedManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_project_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TSGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TSGroup](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[tsgroup] [nvarchar](10)  NULL,
	[Name] [nvarchar](50)  NULL,
	[Description] [nvarchar](255)  NULL,
	[Shift] [nvarchar](50)  NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_TSGroup] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_discipline]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_discipline](
	[UserMUID] [nvarchar](150) NOT NULL,
	[DisciplineMUID] [nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_discipline_1] PRIMARY KEY CLUSTERED 
(
	[UserMUID] ASC,
	[DisciplineMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_group](
	[UserMUID] [nvarchar](150) NOT NULL,
	[GroupMUID] [nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_group_1] PRIMARY KEY CLUSTERED 
(
	[UserMUID] ASC,
	[GroupMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_owner]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_owner](
	[UserMUID] [nvarchar](150) NOT NULL,
	[OwnerMUID] [nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_owner_1] PRIMARY KEY CLUSTERED 
(
	[UserMUID] ASC,
	[OwnerMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_levels]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_levels](
	[UserMUID] [nvarchar](150) NOT NULL,
	[LevelMUID] [nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_levels_1] PRIMARY KEY CLUSTERED 
(
	[UserMUID] ASC,
	[LevelMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_projects](
	[UserMUID] [nvarchar](150) NOT NULL,
	[ProjectMUID] [nvarchar](150) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_user_projects_1] PRIMARY KEY CLUSTERED 
(
	[UserMUID] ASC,
	[ProjectMUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

--Create Defaults
INSERT INTO company (MUID,TS,Name, Description) Values ('!!MID!!&0011','!!NOW!!','Undefined','No Company Selected')
INSERT INTO discipline (MUID,TS,Name, Description) Values ('!!MID!!&0011','!!NOW!!','Undefined','No Discipline Selected')
INSERT INTO groups (MUID,TS,Name, Description) Values ('!!MID!!&0011','!!NOW!!','Undefined','No Group Selected')
INSERT INTO levels (MUID,TS,Name, Description) Values ('!!MID!!&0011','!!NOW!!','Undefined','No Level Selected')
INSERT INTO owner (MUID,TS,Name, Description) Values ('!!MID!!&0011','!!NOW!!','Undefined','No Owner Selected')

--System Feature Defaults
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0011','!!NOW!!','ProjectAdd', 'PRO001', 'Add a Project', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0012','!!NOW!!','ProjectArchive', 'PRO002', 'Archive a Project', '0', '0')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0013','!!NOW!!','ProjectRestore', 'PRO003', 'Restore a project', '0', '0')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0014','!!NOW!!','ProjectDelete', 'PRO004', 'Delete a Project', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0015','!!NOW!!','SystemAdd', 'SYS001', 'Add a System Number', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0016','!!NOW!!','SystemEdit', 'SYS002', 'Edit a System Number', '0', '0')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0017','!!NOW!!','SystemDelete', 'SYS003', 'Delete a System Number', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0018','!!NOW!!','PackageManage', 'PKG001', 'Manage Packages', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&0019','!!NOW!!','PackageEdit', 'PKG002', 'Edit a Package', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00110','!!NOW!!','PackageAdd', 'PKG003', 'Add a Package', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00111','!!NOW!!','PackageDelete', 'PKG004', 'Delete a Package', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00112','!!NOW!!','PackageImport', 'PKG005', 'Import Packages', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00113','!!NOW!!','PackageExport', 'PKG006', 'Export Packages', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00114','!!NOW!!','PackageCover', 'PKG007', 'Import Package Coversheet', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00115','!!NOW!!','TagAdd', 'TAG001', 'Add a Tag', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00116','!!NOW!!','TagEdit', 'TAG002', 'Edit a Tag', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00117','!!NOW!!','TagDelete', 'TAG003', 'Delete a Tag', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00118','!!NOW!!','TagImport', 'TAG004', 'Import Tags', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00119','!!NOW!!','TagExport', 'TAG005', 'Export Tags', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00120','!!NOW!!','PackageEditAuxInfo', 'PKG008', 'Edit Package Auxiliary Info', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00121','!!NOW!!','PackageAddDoc', 'PKG009', 'Add Package Document Association', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00122','!!NOW!!','PackageEditDoc', 'PKG010', 'Edit Package Document Association', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00123','!!NOW!!','PackageDeleteDoc', 'PKG011', 'Delete Package Document Association', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00124','!!NOW!!','TagEditEngData', 'TAG006', 'Edit Tag Engineering Data', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00125','!!NOW!!','TagEditAuxInfo', 'TAG007', 'Edit Tag Auxiliary Data', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00126','!!NOW!!','PunchlistAdd', 'PUN001', 'Add a Punchlist Item', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00127','!!NOW!!','PunchlistOpen', 'PUN002', 'Open a Punchlist Item', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00128','!!NOW!!','PunchlistComplete', 'PUN003', 'Complete a Punchlist Item', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00129','!!NOW!!','PunchlistClose', 'PUN004', 'Close a Punchlist Item', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00130','!!NOW!!','PunchlistEdit', 'PUN005', 'Edit a Punchlist Item', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00131','!!NOW!!','DiscrepancyAdd', 'DIS001', 'Add a Package Discrepancy', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00132','!!NOW!!','DiscrepancyEdit', 'DIS002', 'Edit a Package Discrepancy', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00133','!!NOW!!','DataManagerCompany', 'DMR001', 'Manage Companies', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00134','!!NOW!!','DataManagerDiscipline', 'DMR002', 'Manage Disciplines', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00135','!!NOW!!','DataManagerGroups', 'DMR003', 'Manage Groups', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00136','!!NOW!!','DataManagerLevels', 'DMR004', 'Manage Permission Levels', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00137','!!NOW!!','DataManagerOwners', 'DMR005', 'Manage Owners', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00138','!!NOW!!','DataManagerUsers', 'DMR006', 'Manage Users', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00139','!!NOW!!','DataManagerEquipmentTypes', 'DMR007', 'Manage Equipment Types', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00140','!!NOW!!','DataManagerFormRequirements', 'DMR008', 'Manage Form Requirements', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00141','!!NOW!!','DataManagerSignOff', 'DMR009', 'Manage For Sign-Off Configuration', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00142','!!NOW!!','FormBuilderManager', 'FMB001', 'Use Form Designer', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00143','!!NOW!!','DaqumentManageCategory', 'DAQ001', 'Add Document Categories', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00144','!!NOW!!','DaqumentAddDocument', 'DAQ002', 'Add a Document', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00145','!!NOW!!','DaqumentEditDocument', 'DAQ003', 'Edit a Document', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00146','!!NOW!!','DaqumentDeleteDocument', 'DAQ004', 'Delete a Document', '1', '1')
INSERT INTO SystemFeatures (MUID,TS,Name,Code,Description,Status,Active) VALUES ('!!MID!!&00147','!!NOW!!','ToolsManage', 'TLS001', 'Access System Tools', '1', '1')



--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_discipline_discipline]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_discipline]'))
--ALTER TABLE [dbo].[user_discipline]  WITH CHECK ADD  CONSTRAINT [FK_user_discipline_discipline] FOREIGN KEY([DisciplineMUID])
--REFERENCES [dbo].[discipline] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_discipline_userInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_discipline]'))
--ALTER TABLE [dbo].[user_discipline]  WITH CHECK ADD  CONSTRAINT [FK_user_discipline_userInfo] FOREIGN KEY([UserMUID])
--REFERENCES [dbo].[userInfo] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_group_groups]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_group]'))
--ALTER TABLE [dbo].[user_group]  WITH CHECK ADD  CONSTRAINT [FK_user_group_groups] FOREIGN KEY([GroupMUID])
--REFERENCES [dbo].[groups] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_group_userInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_group]'))
--ALTER TABLE [dbo].[user_group]  WITH CHECK ADD  CONSTRAINT [FK_user_group_userInfo] FOREIGN KEY([UserMUID])
--REFERENCES [dbo].[userInfo] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_owner_owner]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_owner]'))
--ALTER TABLE [dbo].[user_owner]  WITH CHECK ADD  CONSTRAINT [FK_user_owner_owner] FOREIGN KEY([OwnerMUID])
--REFERENCES [dbo].[owner] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_owner_userInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_owner]'))
--ALTER TABLE [dbo].[user_owner]  WITH CHECK ADD  CONSTRAINT [FK_user_owner_userInfo] FOREIGN KEY([UserMUID])
--REFERENCES [dbo].[userInfo] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_levels_levels]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_levels]'))
--ALTER TABLE [dbo].[user_levels]  WITH CHECK ADD  CONSTRAINT [FK_user_levels_levels] FOREIGN KEY([LevelMUID])
--REFERENCES [dbo].[levels] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_levels_userInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_levels]'))
--ALTER TABLE [dbo].[user_levels]  WITH CHECK ADD  CONSTRAINT [FK_user_levels_userInfo] FOREIGN KEY([UserMUID])
--REFERENCES [dbo].[userInfo] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_projects_projects]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_projects]'))
--ALTER TABLE [dbo].[user_projects]  WITH CHECK ADD  CONSTRAINT [FK_user_projects_projects] FOREIGN KEY([ProjectMUID])
--REFERENCES [dbo].[projects] ([MUID])

--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_user_projects_userInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[user_projects]'))
--ALTER TABLE [dbo].[user_projects]  WITH CHECK ADD  CONSTRAINT [FK_user_projects_userInfo] FOREIGN KEY([UserMUID])
--REFERENCES [dbo].[userInfo] ([MUID])
