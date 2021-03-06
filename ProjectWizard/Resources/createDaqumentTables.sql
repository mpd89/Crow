USE [!!SiteName!!_Daqument]


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[drawing_layers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[drawing_layers](
	[MUID] [nvarchar](150) NOT NULL,
	[DrawingMUID] [nvarchar](150) NOT NULL,
	[layerRevDate] [datetime] NOT NULL,
	[LastUserMUID] [nvarchar](150) NOT NULL,
	[layerStatus] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[layerDescription] [nvarchar](max) NULL,
	[layerTitle] [nvarchar](50) NULL,
	[Cabinet] [nvarchar](10) NOT NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_drawing_layers] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[document_type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[document_type](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[Code] [nvarchar](10) NULL,
	[Description] [nvarchar](100) NULL,
	[ParentMUID] [nvarchar](150) NULL,
	[Aux05] [nvarchar](10) NULL,
	[Aux04] [nvarchar](10) NULL,
	[Aux03] [nvarchar](10) NULL,
	[Aux02] [nvarchar](10) NULL,
	[Aux01] [nvarchar](50) NULL,
	[Disable11x17] [nvarchar](10) NULL,
 CONSTRAINT [PK_document_type] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[documents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[documents](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[EngCode] [nvarchar](50) NULL,
	[ClientCode] [nvarchar](50) NULL,
	[Revision] [nvarchar](5) NULL,
	[DateLoaded] [datetime] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Sheet] [nvarchar](5) NULL,
	[Sheets] [nvarchar](5) NULL,
	[Location] [nvarchar](50) NULL,
	[DocumentTypeMUID] [nvarchar](150) NOT NULL,
	[ProjectMUID] [nvarchar](150) NULL,
	[DocumentPath] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_documents] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


--Create Defaults
INSERT INTO document_type (MUID,TS,Code, Description,ParentMUID) Values ('!!MID!!&0011','!!NOW!!','UDF','Undefined',0)
