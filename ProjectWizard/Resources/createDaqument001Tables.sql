SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[document_store]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[document_store](
	[MUID] [nvarchar](150) NOT NULL,
	[TS] [datetime] NULL,
	[DocumentMUID] [nvarchar](150) NOT NULL,
	[DocumentImage] [image] NULL,
 	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
CONSTRAINT [PK_document_store] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[drawing_objects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[drawing_objects](
	[MUID] [nvarchar](150) NOT NULL,
	[DocumentMUID] [nvarchar](150) NOT NULL,
	[layerMUID] [nvarchar](150) NULL,
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
	[Text] [nvarchar](255)  NULL,
	[fontFamily] [nvarchar](50)  NULL,
	[fontsize] [int] NULL,
	[fontforecolor] [int] NULL,
	[fontbackcolor] [int] NULL,
	[VectorObjectType] [nvarchar](50) NULL,
	[OrgScaleX] [nvarchar](50) NULL,
	[OrgScaleY] [nvarchar](50) NULL,
	[ObjectMode] [nvarchar](50) NULL,
	[Aux05] [nvarchar](50) NULL,
	[Aux04] [nvarchar](50) NULL,
	[Aux03] [nvarchar](50) NULL,
	[Aux02] [nvarchar](50) NULL,
	[Aux01] [nvarchar](50) NULL,
 CONSTRAINT [PK_drawing_objects] PRIMARY KEY CLUSTERED 
(
	[MUID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
