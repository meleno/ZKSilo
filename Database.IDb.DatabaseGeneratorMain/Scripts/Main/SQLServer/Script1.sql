/****** Object:  Table [dbo].[users]    Script Date: 05/05/2019 19:50:20 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[users](
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[clients](
	[user_name] [nvarchar](50) NOT NULL,
	[client_id] [nvarchar](50) NOT NULL,
	[client_secret] [nvarchar](100) NOT NULL,
	[allowed_grant_types] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_clients] PRIMARY KEY CLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[clients]  WITH CHECK ADD  CONSTRAINT [FK_clients_users] FOREIGN KEY([user_name])
REFERENCES [dbo].[users] ([username])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[clients] CHECK CONSTRAINT [FK_clients_users]

/****** Object:  Table [dbo].[databases]    Script Date: 05/05/2019 19:50:01 ******/
CREATE TABLE [dbo].[databases](
	[db_name] [nvarchar](50) NOT NULL,
	[db_user] [nvarchar](50) NOT NULL,
	[db_password] [nvarchar](50) NOT NULL,
	[db_server_address] [nvarchar](15) NOT NULL,
	[db_server_port] [numeric](5, 0) NOT NULL,
 CONSTRAINT [PK_databases] PRIMARY KEY CLUSTERED 
(
	[db_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[databases]  WITH CHECK ADD  CONSTRAINT [FK_databases_users] FOREIGN KEY([db_name])
REFERENCES [dbo].[users] ([username])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[databases] CHECK CONSTRAINT [FK_databases_users]

/****** Object:  Table [dbo].[scopes]    Script Date: 05/05/2019 19:50:46 ******/
CREATE TABLE [dbo].[scopes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[scope] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_scopes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


/****** Object:  Table [dbo].[client_scopes]    Script Date: 05/05/2019 19:48:40 ******/
CREATE TABLE [dbo].[client_scopes](
	[user_name] [nvarchar](50) NOT NULL,
	[scope_id] [int] NOT NULL,
 CONSTRAINT [PK_client_scopes] PRIMARY KEY CLUSTERED 
(
	[user_name] ASC,
	[scope_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[client_scopes]  WITH CHECK ADD  CONSTRAINT [FK_client_scopes_clients] FOREIGN KEY([user_name])
REFERENCES [dbo].[clients] ([user_name])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[client_scopes] CHECK CONSTRAINT [FK_client_scopes_clients]

ALTER TABLE [dbo].[client_scopes]  WITH CHECK ADD  CONSTRAINT [FK_client_scopes_scopes] FOREIGN KEY([scope_id])
REFERENCES [dbo].[scopes] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE

ALTER TABLE [dbo].[client_scopes] CHECK CONSTRAINT [FK_client_scopes_scopes]


