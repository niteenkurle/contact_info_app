/****** Object:  Table [dbo].[tbl_contact]    Script Date: 7/11/2018 9:39:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tbl_contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_contact] ON 

INSERT [dbo].[tbl_contact] ([Id], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (3, N'John', N'Doe', N'john.doe@gmail.com', N'9876543210', 0)
INSERT [dbo].[tbl_contact] ([Id], [FirstName], [LastName], [Email], [PhoneNumber], [Status]) VALUES (4, N'Test', N'Test', N'test.test@gmail.com', N'7854216532', 1)
SET IDENTITY_INSERT [dbo].[tbl_contact] OFF
