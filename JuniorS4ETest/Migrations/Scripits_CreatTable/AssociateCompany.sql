

CREATE TABLE [dbo].[AssociateCompany](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssociateId] [bigint] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[DeletionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AssociateCompany]  WITH CHECK ADD  CONSTRAINT [FK_AssociateCompany_Associates] FOREIGN KEY([AssociateId])
REFERENCES [dbo].[Associates] ([Id])
GO

ALTER TABLE [dbo].[AssociateCompany] CHECK CONSTRAINT [FK_AssociateCompany_Associates]
GO

ALTER TABLE [dbo].[AssociateCompany]  WITH CHECK ADD  CONSTRAINT [FK_AssociateCompany_Companys] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companys] ([Id])
GO

ALTER TABLE [dbo].[AssociateCompany] CHECK CONSTRAINT [FK_AssociateCompany_Companys]
GO


