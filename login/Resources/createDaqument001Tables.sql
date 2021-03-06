USE [!!SiteName!!_Daqument001]

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[document_store]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[document_store](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TS] [datetime] NULL,
	[DocumentID] [int] NOT NULL,
	[DocumentImage] [image] NULL,
 CONSTRAINT [PK_document_store] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[drawing_objects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[drawing_objects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DrawingID] [int] NOT NULL,
	[layerID] [int] NULL,
	[VectorType] [int] NOT NULL,
	[StartPointX] [int] NOT NULL,
	[StartPointY] [int] NOT NULL,
	[endPointX] [int] NULL,
	[endPointY] [int] NULL,
	[lineWidth] [int] NULL,
	[lineend] [int] NULL,
	[penArgb] [int] NULL,
	[Visibility] [int] NULL,
	[VectorImage] [image] NULL,
	[Text] [ntext]  NULL,
	[fontFamily] [nvarchar](50)  NULL,
	[fontsize] [int] NULL,
	[fontforecolor] [int] NULL,
	[fontbackcolor] [int] NULL,
	[Aux01] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
 CONSTRAINT [PK_drawing_objects] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
