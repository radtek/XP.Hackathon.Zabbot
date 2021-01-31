

/****** Object:  Table [dbo].[EscalationGroup]    Script Date: 30/01/2021 10:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EscalationGroup](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](200) NULL,
	[TagName] [varchar](50) NOT NULL,
	[Channel] [varchar](5000) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_EscalationGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[Escalation]    Script Date: 30/01/2021 10:44:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escalation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupId] [bigint] NULL,
	[Sequence] [int] NOT NULL,
	[HourStart] [time](7) NULL,
	[HourEnd] [time](7) NULL,
	[Role] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](200) NULL,
	[Note] [varchar](5000) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Updated] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Escalation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Escalation]  WITH CHECK ADD  CONSTRAINT [FK_Escalation_EscalationGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[EscalationGroup] ([Id])
GO
ALTER TABLE [dbo].[Escalation] CHECK CONSTRAINT [FK_Escalation_EscalationGroup]
GO