
CREATE TABLE [dbo].[Associates](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Cpf] [varchar](11) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[DeletionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
Go
































