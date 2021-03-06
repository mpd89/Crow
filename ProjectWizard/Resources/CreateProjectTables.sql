SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_fieldmap]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_fieldmap](
	[MUID] [nvarchar](150) NOT NULL,
	[TemplateMUID] [nvarchar](150) NULL,
	[ColName] [nvarchar](45) NULL,
	[CustomName] [nvarchar](45) NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_aux_fieldmap] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_template]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_template](
	[MUID] [nvarchar](150) NOT NULL,
	[TemplateName] [nvarchar](45) NULL,
	[Type] [nvarchar](45) NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_aux_template] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_template_assoc]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_template_assoc](
	[MUID] [nvarchar](150) NOT NULL,
	[TemplateMUID] [nvarchar](150) NULL,
	[AssocMUID] [nvarchar](150) NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[SourceMUID] [nvarchar](150) NULL,
 CONSTRAINT [PK_aux_template_assoc] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_subforms_info]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_subforms_info](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[AuxData] [nvarchar](max) NOT NULL,
 	[Aux01] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
CONSTRAINT [PK_aux_subforms_info] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_subforms_fields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_subforms_fields](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[FieldName] [nvarchar](max) NOT NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_aux_subforms_fields] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_package]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_package](
	[MUID] [nvarchar](150) NOT NULL,
	[FieldmapMUID] [nvarchar](150) NOT NULL,
	[PackageMUID] [nvarchar](150) NOT NULL,
	[auxData] [nvarchar](max) NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_aux_package] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_tags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_tags](
	[MUID] [nvarchar](150) NOT NULL,
	[FieldmapMUID] [nvarchar](150) NOT NULL,
	[TagMUID] [nvarchar](150) NOT NULL,
	[auxData] [nvarchar](max) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_aux_tags] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatagridViews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DatagridViews](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[ModuleName] [nvarchar](50) NULL,
	[ModuleFilename] [nvarchar](50) NULL,
	[DatagridName] [nvarchar](50) NULL,
	[ViewName] [nvarchar](50) NULL,
	[ViewContents] [varbinary](max) NULL,
	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL
CONSTRAINT [PK_DatagridViews] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[discrepancy]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[discrepancy](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](1000) NULL,
	[Resolution] [nvarchar](1000) NULL,
	[ListedBy] [nvarchar](150) NULL,
	[ListedOn] [datetime] NULL,
	[ClosedBy] [nvarchar](50) NULL,
	[ClosedOn] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[ManHours] [smallint] NULL,
	[CrossReferenceType] [nvarchar](50) NULL,
	[CrossReferenceNumber] [nvarchar](50) NULL,
	[PackageMUID] [nvarchar](150) NULL,
	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_discrepancy] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[engineering_data]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[engineering_data](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[TagMUID] [nvarchar](150) NULL,
	[Remarks] [nvarchar](255) NULL,
	[Prefix] [nvarchar](10) NULL,
	[Description] [nvarchar](100) NULL,
	[Service] [nvarchar](100) NULL,
	[Manufacturer] [nvarchar](100) NULL,
	[ModelNumber] [nvarchar](100) NULL,
	[SerialNumber] [nvarchar](100) NULL,
	[PONumber] [nvarchar](100) NULL,
	[LineNumber] [nvarchar](100) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_engineering_data] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[equipment_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[equipment_type](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[TypeName] [nvarchar](50) NULL,
	[TypeDesc] [nvarchar](50) NULL,
	[Active] [nvarchar](5) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_equipment_type] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[NumberPages] [int] NOT NULL,
	[BaseDocument] [varBinary](max) NULL,
	[Active] [bit] NULL,
	[Comments] [nvarchar](255) NULL,
	[MultiElement] [int] NOT NULL,
	[NumberofElements] [int] NOT NULL,
  	[PackageTemplateMUID] [nvarchar](150) NULL,
	[TagTemplateMUID] [nvarchar](150) NULL,
	[SystemForm] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_forms] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_config]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_config](
	[MUID] [nvarchar](150) NOT NULL,
	[OwnerMUID] [nvarchar](150) NOT NULL,
	[LevelOrder] [nvarchar](500) NOT NULL,
	[LevelColor] [nvarchar](500) NULL,
 	[LevelDescription] [nvarchar](500) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_forms_config] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
 

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[OwnerMUID] [nvarchar](150) NOT NULL,
	[TagMUID] [nvarchar](150) NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[UserMUID] [nvarchar](150) NOT NULL,
	[Action] [int] NOT NULL,
	[Comment] [nvarchar](250) NULL,
	[Esign] [image] NULL,
	[CurrentLevel] [int] NULL,
 	[RequiredManHours] [float] NULL,
	[EarnedManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_forms_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_me_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_me_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[OwnerMUID] [nvarchar](150) NOT NULL,
	[SourceMUID] [nvarchar](150) NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[UserMUID] [nvarchar](150) NOT NULL,
	[Action] [int] NOT NULL,
	[Comment] [nvarchar](250) NULL,
	[Esign] [image] NULL,
	[CurrentLevel] [int] NULL,
 	[RequiredManHours] [float] NULL,
	[EarnedManHours] [float] NULL,
	[SourceType] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_forms_me_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_update]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_update](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
    [DateStamp] [datetime] NOT NULL,     
	[RequirementMUID] [nvarchar](150) NOT NULL,
    [SourceMUID] [nvarchar](150) NOT NULL,
	[FieldMUID] [nvarchar](150) NOT NULL,
	[FieldValue] [nvarchar](500) NULL,
	[SourceType] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_forms_update] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_image]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_image](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[PageNumber] [int] NOT NULL,
	[FormImage] [image] NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_forms_image] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[forms_storage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[forms_storage](
	[MUID] [nvarchar](150) NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[baseImage] [varbinary](max) NOT NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_forms_storage] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aux_forms_info]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aux_forms_info](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[FormMUID] [nvarchar](150) NOT NULL,
	[AuxData] [nvarchar](max) NOT NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_aux_forms_info] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[maint_number]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[maint_number](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[number] [nvarchar](45) NULL,
 	[Aux10] [nvarchar](50) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_maint_number] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mc1_number]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mc1_number](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[number] [nvarchar](45) NULL,
 	[Aux10] [nvarchar](50) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_mc1_number] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[messages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[messages](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[SenderMUID] [nvarchar](150) NULL,
	[ReceiverMUID] [nvarchar](150) NULL,
	[Subject] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[messages_sent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[messages_sent](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[SenderMUID] [nvarchar](150) NOT NULL,
	[ReceiverMUID] [nvarchar](150) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
 	[Status] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_messages_sent] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[messages_received]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[messages_received](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NOT NULL,
	[SenderMUID] [nvarchar](150) NOT NULL,
	[ReceiverMUID] [nvarchar](150) NOT NULL,
	[Subject] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
 	[Status] [int] NOT NULL,
	[Priority] [int] NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_messages_received] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[package](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[PackageNumber] [nvarchar](50) NOT NULL,
	[SystemMUID] [nvarchar](1000) NULL,
	[Description] [nvarchar](100) NULL,
	[GroupMUID] [nvarchar](150) NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[DisciplineMUID] [nvarchar](150) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_package] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package_documents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[package_documents](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[DocumentMUID] [nvarchar](150) NOT NULL,
	[PackageMUID] [nvarchar](150) NOT NULL,
 	[Notes] [nvarchar](255) NULL,
 	[TagMUID] [nvarchar](150) NULL,
	[SystemMUID] [nvarchar](1000) NULL,
	[Aux8] [nvarchar](50) NULL,
	[Aux7] [nvarchar](50) NULL,
	[Aux6] [nvarchar](50) NULL,
  	[Aux5] [int] NULL,
	[Aux4] [int] NULL,
	[Aux3] [int] NULL,
	[Aux2] [float] NULL,
	[Aux1] [float] NULL,
 CONSTRAINT [PK_package_documents] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[package_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[package_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[PackageMUID] [nvarchar](150) NULL,
	[RequiredManHours] [float] NULL,
	[CurrentLevel] [int] NULL,
	[EarnedManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_package_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectImages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectImages](
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
 CONSTRAINT [PK_ProjectImages] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[punchlist]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[punchlist](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Description] [nvarchar](255) NULL,
	[Priority] [nvarchar](255) NULL,
	[ListedBy] [nvarchar](50) NULL,
	[ListedOn] [datetime] NULL,
	[ClosedBy] [nvarchar](50) NULL,
	[ClosedOn] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[Type] [nvarchar](50) NULL,
	[ManHours] [smallint] NULL,
	[CompletedBy] [nvarchar](50) NULL,
	[CompletedOn] [datetime] NULL,
	[CompletedComments] [nvarchar](255) NULL,
	[ApprovedBy] [nvarchar](50) NULL,
	[ApprovedOn] [datetime] NULL,
	[Location] [nvarchar](50) NULL,
	[MaterialRequired] [nvarchar](10) NULL,
	[Material] [nvarchar](100) NULL,
	[ResponsiblePartymuid] [nvarchar](150) NULL,
	[ResponsibleDisciplineMUID] [nvarchar](150) NULL,
	[EstimatedDate] [datetime] NULL,
	[RequiredDate] [datetime] NULL,
	[TagMUID] [nvarchar](150) NULL,
 	[SystemMUID] [nvarchar](1000) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_punchlist] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReferenceLibrary]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReferenceLibrary](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Type] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[Rev] [nvarchar](50) NULL,
	[FileName] [nvarchar](50) NULL,
	[FileExtension] [nvarchar](50) NULL,
	[FileContents] [varbinary](max) NULL,
	[Transmittal] [smallint] NULL,
	[TransmittalNumber] [nvarchar](50) NULL,
	[TransmittalDirection] [nvarchar](50) NULL,
	[TransmittalDate] [datetime] NULL,
	[TransmittalBinderTab] [nvarchar](50) NULL,
	[TransmittalFromName] [nvarchar](50) NULL,
	[TransmittalFromCompany] [nvarchar](50) NULL,
	[TransmittalContents] [nvarchar](50) NULL,
	[TransmittalMethod] [nvarchar](50) NULL,
	[TransmittalToName] [nvarchar](50) NULL,
	[TransmittalToCompany] [nvarchar](50) NULL,
	[TransmittalToDestination] [nvarchar](50) NULL,
	[TransmittalReturnedDate] [datetime] NULL,
	[TransmittalReturnedMethod] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL
CONSTRAINT [PK_ReferenceLibrary] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[requirements]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[requirements](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[TypeMUID] [nvarchar](150) NULL,
	[FormMUID] [nvarchar](150) NULL,
	[ManHours] [float] NULL,
	[MEManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_requirements] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sh1_number]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sh1_number](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[number] [nvarchar](45) NULL,
 	[Aux10] [nvarchar](50) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_sh1_number] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_mnemonic]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[system_mnemonic](
	[MUID] [nvarchar](150) NOT NULL,
	[TierNumber] [int] NOT NULL,
	[TS] [datetime] NULL,
	[Sep] [nvarchar](2) NULL,
	[Description] [nvarchar](100) NULL,
	[SubSystem] [nvarchar](10) NULL,
	[TierColor] [nvarchar](50) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_system_mnemonic] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_number]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[system_number](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Identifier] [nvarchar](50) NULL,
	[ParentLinkMUID] [nvarchar](150) NULL,
	[Description] [nvarchar](100) NULL,
	[TierMUID] [nvarchar](150) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_system_number] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[system_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[system_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[SystemMUID] [nvarchar](1000) NULL,
	[RequiredManHours] [float] NULL,
	[CurrentLevel] [int] NULL,
	[EarnedManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_system_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tag_status]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tag_status](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[TagMUID] [nvarchar](150) NULL,
	[RequiredManhours] [float] NULL,
	[CurrentLevel] [int] NULL,
	[EarnedManHours] [float] NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_tag_status] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tags]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tags](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[TagNumber] [nvarchar](50) NULL,
	[PackageMUID] [nvarchar](150) NULL,
	[TypeMUID] [nvarchar](150) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_tags] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskList](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[p3id] [int] NOT NULL,
	[taskid] [int] NULL,
	[TaskGroup] [nvarchar](50) NULL,
	[description] [varchar](max)  NOT NULL,
	[ScheduledStart] [datetime] NOT NULL,
	[ScheduledFinish] [datetime] NOT NULL,
	[ActualStart] [datetime] NULL,
	[ActualFinish] [datetime] NULL,
	[BaseManhours] [float] NULL,
	[BaseQuantity] [float] NULL,
	[TaskGroupMUID] [nvarchar](150)  NULL,
	[Aux09] [nvarchar](50)  NULL,
	[Aux08] [nvarchar](50)  NULL,
	[Aux07] [nvarchar](50)  NULL,
	[Aux06] [nvarchar](50)  NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_TaskList] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskStatus](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[P3ID] [int] NULL,
	[OwnerMUID] [nvarchar](150) NULL,
	[TagMUID] [nvarchar](150) NULL,
	[UserMUID] [nvarchar](150) NULL,
	[PercentComplete] [float] NULL,
	[EarnedManHours] [float] NULL,
	[EarnedQuantity] [float] NULL,
	[ActualManHours] [float] NULL,
	[ActualQuantity] [float] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblForemanName]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblForemanName](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[TSGroup] [nvarchar](10)  NULL,
	[ForemanName] [nvarchar](10)  NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_tblForemanName] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblSpoolList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblSpoolList](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Disc] [nvarchar](50)  NULL,
	[TagNo] [nvarchar](50)  NOT NULL,
	[SystemMUID] [nvarchar](1000)  NULL,
	[Area] [nvarchar](10)  NULL,
	[OriginalPieceMark] [nvarchar](50)  NULL,
	[LatestSpoolPieceMark] [nvarchar](50) NULL,
	[Delivered] [nvarchar](50)  NULL,
	[LoadNumber] [nvarchar](50)  NULL,
	[Received] [nvarchar](50)  NULL,
	[ReceivedBy] [nvarchar](50)  NULL,
	[Accepted] [nvarchar](50) NULL,
	[Rejected] [nvarchar](50)  NULL,
	[LaydownLocation] [nvarchar](50)  NULL,
	[Comments] [nvarchar](1000)  NULL,
	[OnSite] [nvarchar](50)  NULL,
	[FieldReqdDate] [nvarchar](50)  NULL,
	[FieldIssuedDate] [nvarchar](50)  NULL,
	[RecdBy] [nvarchar](50)  NULL,
	[TotalCount] [nvarchar](10)  NULL,
	[TotalRcvdCount] [nvarchar](10)  NULL,
	[TotalAcceptedCount] [nvarchar](10)  NULL,
	[TotalRejectedCount] [nvarchar](10)  NULL,
	[IssuedToField] [nvarchar](50)  NULL,
	[NewSpools] [nvarchar](50)  NULL,
	[DeletedSpools] [nvarchar](50)  NULL,
	[RevSpool] [nvarchar](50)  NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_tblSpoolList] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblWeldInchesEQLookup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblWeldInchesEQLookup](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[PipeSize] [nvarchar](50)  NULL,
	[InchesOfWeld] [nvarchar](50)  NULL,
	[Diameter] [nvarchar](50)  NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_tblWeldInchesEQLookup] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblWeldersList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblWeldersList](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[TagNo] [nvarchar](10)  NOT NULL,
	[Shift] [nvarchar](10)  NULL,
	[Craft] [nvarchar](50)  NULL,
	[Name] [nvarchar](50)  NOT NULL,
	[SSNo] [nvarchar](50)  NULL,
	[DOH1] [smalldatetime] NULL,
	[DOR1] [smalldatetime] NULL,
	[CS_GTAW] [nvarchar](10)  NULL,
	[CS_SMAW] [nvarchar](10)  NULL,
	[CR_GTAW] [nvarchar](10)  NULL,
	[CR_SMAW] [nvarchar](10)  NULL,
	[SS_GTAW] [nvarchar](10)  NULL,
	[SS_SMAW] [nvarchar](10)  NULL,
	[INCO_GTAW] [nvarchar](10)  NULL,
	[INCO_SMAW] [nvarchar](10)  NULL,
	[TiGTAW] [nvarchar](10)  NULL,
	[Blank1] [nvarchar](10)  NULL,
	[Blank2] [nvarchar](10)  NULL,
	[SS_PLT_SMAW] [nvarchar](10)  NULL,
	[CS_PLT_SMAW] [nvarchar](10)  NULL,
	[CS_PLT_FCAW_BG] [nvarchar](10)  NULL,
	[W_WO_Backing] [nvarchar](10)  NULL,
	[Comments] [nvarchar](10)  NULL,
	[Disc] [nvarchar](50)  NOT NULL,
	[Active] [int] NULL,
	[Aux09] [nvarchar](10)  NULL,
	[Aux08] [nvarchar](10)  NULL,
	[Aux07] [nvarchar](10)  NULL,
	[Aux06] [nvarchar](10)  NULL,
	[Aux05] [nvarchar](10)  NULL,
	[Aux04] [nvarchar](10)  NULL,
	[Aux03] [nvarchar](10)  NULL,
	[Aux02] [nvarchar](10)  NULL,
	[Aux01] [nvarchar](10)  NULL,
 CONSTRAINT [PK_tblWeldersList] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblWeldTracking]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblWeldTracking](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Disc] [nvarchar](50)  NULL,
	[TagNo] [nvarchar](50)  NOT NULL,
	[SystemMUID] [nvarchar](1000)  NULL,
	[Area] [nvarchar](50)  NULL,
	[DWGNO] [nvarchar](50)  NOT NULL,
	[TestPkgNo] [nvarchar](50)  NULL,
	[EnteredBy] [nvarchar](50)  NULL,
	[DateEntered] [smalldatetime] NULL,
	[SpoolTo] [nvarchar](50)  NULL,
	[SpoolFrom] [nvarchar](50)  NULL,
	[PipeSize] [nvarchar](50)  NULL,
	[ConstCode] [nvarchar](50)  NULL,
	[WeldInches] [nvarchar](50)  NULL,
	[ForemanName] [nvarchar](50)  NULL,
	[SVCSPEC] [nvarchar](50)  NULL,
	[WPS] [nvarchar](50)  NULL,
	[NDEPcntReq] [nvarchar](50)  NULL,
	[Material] [nvarchar](50)  NULL,
	[WallThk] [nvarchar](50)  NULL,
	[WeldType] [nvarchar](50)  NULL,
	[WeldStn] [nvarchar](50)  NULL,
	[NDEType] [nvarchar](50)  NULL,
	[DateTested] [datetime] NULL,
	[AdvancedTesting] [nvarchar](50)  NULL,
	[TestResult] [nvarchar](50)  NULL,
	[VisInspDate] [nvarchar](50)  NULL,
	[VisInspName] [nvarchar](50)  NULL,
	[PMIDate] [datetime] NULL,
	[PMIResult] [nvarchar](50)  NULL,
	[RejInches] [nvarchar](50)  NULL,
	[PWHT] [nvarchar](50)  NULL,
	[BHN] [nvarchar](50)  NULL,
	[Comments] [nvarchar](50)  NULL,
	[Revision] [nvarchar](50)  NULL,
	[WeldID] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
	[Reserved] [nvarchar](50)  NULL,
	[DrawingMUID] [nvarchar](150) NULL,
	[WeldStatus] [nvarchar](50)  NULL,
	[VectorLink] [nvarchar](50)  NULL,
 	[tblEQMUID] [nvarchar](150) NULL,
	[tblSpoolMUID] [nvarchar](150) NULL,
	[tblWelderMUID] [nvarchar](150) NULL,
	[tblWPSMUID] [nvarchar](150) NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
CONSTRAINT [PK_tblWeldTracking] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblWeldTrackingAdvanced]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblWeldTrackingAdvanced](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Disc] [nvarchar](50)  NOT NULL,
	[TagNo] [nvarchar](50)  NOT NULL,
	[SystemMUID] [nvarchar](1000)  NULL,
	[Area] [nvarchar](50)  NULL,
	[Phase0] [nvarchar](255)  NULL,
	[Phase1] [nvarchar](50)  NULL,
	[Phase2] [nvarchar](255)  NULL,
	[Phase3] [nvarchar](50)  NULL,
	[Phase4] [nvarchar](255)  NULL,
	[Phase5] [nvarchar](255)  NULL,
	[Phase6] [nvarchar](255)  NULL,
	[Phase7] [nvarchar](50)  NULL,
	[Phase8] [nvarchar](50)  NULL,
	[Phase9] [nvarchar](50)  NULL,
	[Phase10] [nvarchar](50)  NULL,
	[Phase11] [nvarchar](255)  NULL,
	[Phase12] [nvarchar](255)  NULL,
	[Phase13] [nvarchar](255)  NULL,
	[Phase14] [nvarchar](255)  NULL,
	[Phase15] [nvarchar](255)  NULL,
	[Phase16] [nvarchar](255)  NULL,
	[Phase17] [nvarchar](255)  NULL,
	[Phase18] [nvarchar](255)  NULL,
	[Phase19] [nvarchar](255)  NULL,
	[Phase20] [nvarchar](255)  NULL,
	[Phase21] [nvarchar](255)  NULL,
	[Phase22] [nvarchar](50)  NULL,
	[Phase23] [nvarchar](50)  NULL,
	[Phase24] [nvarchar](50)  NULL,
	[Phase25] [nvarchar](50)  NULL,
	[Phase26] [nvarchar](50)  NULL,
	[Phase27] [nvarchar](50)  NULL,
	[Phase28] [nvarchar](50)  NULL,
	[Phase29] [nvarchar](50)  NULL,
	[Phase30] [nvarchar](50)  NULL,
	[Phase31] [nvarchar](50)  NULL,
	[Reserved] [nvarchar](50)  NULL,
	[Pending] [nvarchar](50)  NOT NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_tblWeldTrackingAdvanced] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblWeldWPSLookup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblWeldWPSLookup](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[ClassID] [nvarchar](50)  NOT NULL,
	[WPS] [nvarchar](50)  NULL,
	[NDEPcntReq] [nvarchar](50)  NULL,
	[Active] [int] NULL,
	[Aux05] [nvarchar](50)  NULL,
	[Aux04] [nvarchar](50)  NULL,
	[Aux03] [nvarchar](50)  NULL,
	[Aux02] [nvarchar](50)  NULL,
	[Aux01] [nvarchar](50)  NULL,
 CONSTRAINT [PK_tblWeldWPSLookup] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[workpack_number]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[workpack_number](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[number] [nvarchar](45) NULL,
 	[Aux10] [nvarchar](50) NULL,
 	[Aux09] [nvarchar](50) NULL,
	[Aux08] [nvarchar](50) NULL,
	[Aux07] [nvarchar](50) NULL,
	[Aux06] [nvarchar](50) NULL,
  	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_workpack_number] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WPS_fields]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WPS_fields](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[WPS_No] [nvarchar](50)NULL,
	[WPS_CompanyName] [nvarchar](50)NULL,
	[WPS_Date] [nvarchar](50)NULL,
	[WPS_Prequalified] [nvarchar](50)NULL,
	[WPS_QlfdByTesting] [nvarchar](50)NULL,
	[WPS_RevNo] [nvarchar](50)NULL,
	[WPS_RevDate] [nvarchar](50)NULL,
	[WPS_WeldProcess] [nvarchar](50)NULL,
	[WPS_WeldType] [nvarchar](50)NULL,
	[WPS_AuthorizedBy] [nvarchar](50)NULL,
	[WPS_PreparedBy] [nvarchar](50)NULL,
	[WPS_SupportingPQRs] [nvarchar](50)NULL,
	[JDU_JointType] [nvarchar](50)NULL,
	[JDU_Single_Dbl_Weld] [nvarchar](50)NULL,
	[JDU_Backing_YesNo] [nvarchar](50)NULL,
	[JDU_BackingMaterial] [nvarchar](50)NULL,
	[JDU_RootOpening] [nvarchar](50)NULL,
	[JDU_RootFaceDim] [nvarchar](50)NULL,
	[JDU_GrooveAngle] [nvarchar](50)NULL,
	[JDU_BackGouging_YesNO] [nvarchar](50)NULL,
	[BM_AWSGroupNoFrom] [nvarchar](50)NULL,
	[BM_AWSGroupNoTo] [nvarchar](50)NULL,
	[BM_SampleTypeFrom] [nvarchar](50)NULL,
	[BM_SampleTypeTo] [nvarchar](50)NULL,
	[BM_GradeFrom] [nvarchar](50)NULL,
	[BM_GradeTo] [nvarchar](50)NULL,
	[BM_SpecType] [nvarchar](50)NULL,
	[BM_ChemAnalysis] [nvarchar](50)NULL,
	[BM_SampleWeldSizeDia] [nvarchar](50)NULL,
	[BM_SampleWeldSizeThick] [nvarchar](50)NULL,
	[BM_ThicknessRangeGroove] [nvarchar](50)NULL,
	[BM_ThicknessRangeFillet] [nvarchar](50)NULL,
	[BM_PipeDiaRangeGroove] [nvarchar](50)NULL,
	[BM_PipeDiaRangeFillet] [nvarchar](50)NULL,
	[BM_Other] [nvarchar](250)NULL,
	[FM_SpecNo_A_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_SpecNo_A_Process1] [nvarchar](50)NULL,
	[FM_SpecNo_A_Process2] [nvarchar](50)NULL,
	[FM_AWSNoClass_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_AWSNoClass_Process1] [nvarchar](50)NULL,
	[FM_AWSNoClass_Process2] [nvarchar](50)NULL,
	[FM_F_No_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_F_No_Process1] [nvarchar](50)NULL,
	[FM_F_No_Process2] [nvarchar](50)NULL,
	[FM_FillerMtrlSize_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_FillerMtrlSize_Process1] [nvarchar](50)NULL,
	[FM_FillerMtrlSize_Process2] [nvarchar](50)NULL,
	[FM_DpstWeldMetal_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_DpstWeldMetal_Process1] [nvarchar](50)NULL,
	[FM_DpstWeldMetal_Process2] [nvarchar](50)NULL,
	[FM_ThckRangeGroove_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_ThckRangeGroove_Process1] [nvarchar](50)NULL,
	[FM_ThckRangeGroove_Process2] [nvarchar](50)NULL,
	[FM_ThckRangeFillet_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_ThckRangeFillet_Process1] [nvarchar](50)NULL,
	[FM_ThckRangeFillet_Process2] [nvarchar](50)NULL,
	[FM_ConsmInsert_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_ConsmInsert_Process1] [nvarchar](50)NULL,
	[FM_ConsmInsert_Process2] [nvarchar](50)NULL,
	[FM_Mfg_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_Mfg_Process1] [nvarchar](50)NULL,
	[FM_Mfg_Process2] [nvarchar](50)NULL,
	[FM_Other_ProcessFCAW_G] [nvarchar](50)NULL,
	[FM_Other_Process1] [nvarchar](50)NULL,
	[FM_Other_Process2] [nvarchar](50)NULL,
	[CLIENT_Name] [nvarchar](50)NULL,
	[CLIENT_Date] [nvarchar](50)NULL,
	[POS_PosOfGroove] [nvarchar](50)NULL,
	[POS_WeldProgressionUpDown] [nvarchar](50)NULL,
	[POS_PosOfFillet] [nvarchar](50)NULL,
	[PRE_HT_TempMin] [nvarchar](50)NULL,
	[PRE_HT_TempMax] [nvarchar](50)NULL,
	[PRE_HT_InterPassMaint] [nvarchar](250)NULL,
	[PST_HT_TempRange] [nvarchar](50)NULL,
	[PST_HT_TimeRange] [nvarchar](50)NULL,
	[SHLD_Shielding_Gas_Flux] [nvarchar](50)NULL,
	[SHLD_ShieldingCupSize] [nvarchar](50)NULL,
	[SHLD_ShieldingGases] [nvarchar](50)NULL,
	[SHLD_ShieldingMixture] [nvarchar](50)NULL,
	[SHLD_ShieldingFlowRateCFH] [nvarchar](50)NULL,
	[SHLD_TrailingGases] [nvarchar](50)NULL,
	[SHLD_TrailingMixture] [nvarchar](50)NULL,
	[SHLD_TrailingFlowRateCFH] [nvarchar](50)NULL,
	[SHLD_BackingGases] [nvarchar](50)NULL,
	[SHLD_BackingMixture] [nvarchar](50)NULL,
	[SHLD_BackingFlowRateCFH] [nvarchar](50)NULL,
	[SHLD_ElctrodeFluxClassMixture] [nvarchar](50)NULL,
	[SHLD_ElctrodeFluxClassFlowRate] [nvarchar](50)NULL,
	[ELEC_Current_AC_DCEP_DCEN_PULSED] [nvarchar](50)NULL,
	[ELEC_AmpRange] [nvarchar](50)NULL,
	[ELEC_VoltRange] [nvarchar](50)NULL,
	[ELEC_ModeOfMetalTrnansferForGMAW] [nvarchar](50)NULL,
	[ELEC_Mode_ShortCircuiting_Globular_Spray] [nvarchar](50)NULL,
	[ELEC_ContactTubeToWorkDist] [nvarchar](50)NULL,
	[ELEC_ElectrodeWireFeedSpeedRange] [nvarchar](50)NULL,
	[ELEC_Other] [nvarchar](250)NULL,
	[TCHN_StringOrWeaveBead] [nvarchar](50)NULL,
	[TCHN_MultiPassOrSinglePass] [nvarchar](50)NULL,
	[TCHN_MultipleOrSingleElectrode] [nvarchar](50)NULL,
	[TCHN_TravelSpeedRange] [nvarchar](50)NULL,
	[TCHN_MthdOfBackGouging] [nvarchar](50)NULL,
	[TCHN_InterpassCleaning] [nvarchar](50)NULL,
	[TCHN_ElectrodeSpacingLongitudinal] [nvarchar](50)NULL,
	[TCHN_ElectrodeSpacingLateral] [nvarchar](50)NULL,
	[TCHN_ElectrodeSpacingAngle] [nvarchar](50)NULL,
	[TCHN_ContactTubeToWorkDist] [nvarchar](50)NULL,
	[TCHN_Oscillation] [nvarchar](50)NULL,
	[TCHN_Peening] [nvarchar](50)NULL,
	[TCHN_Other] [nvarchar](250)NULL,
	[WLD_PROC_WLDLayer1_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer1_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer2_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer3_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer4_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer5_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer6_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer7_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer8_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer9_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer10_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer11_Other] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_Name] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_Prcss] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_FillerMtrlClass] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_FillerMtrlDia] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_CrntTypePolarity] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_WireFeedSpeed] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_VoltRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_TrvlSpdRange] [nvarchar](50)NULL,
	[WLD_PROC_WLDLayer12_Other] [nvarchar](50)NULL,
	[NOTES_Others] [nvarchar](2000)NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_WPS_fields] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


--Create Default values
INSERT INTO equipment_type (MUID,TS,TypeName, TypeDesc,Active) VALUES ('!!MID!!&0011','!!NOW!!','UDF','Undefined','True')







