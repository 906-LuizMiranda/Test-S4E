

CREATE PROCEDURE [dbo].[SP_InsertAssociateCompany]
    @paramAssociateId Int,
    @paramCompanyId Int
AS
BEGIN
    INSERT INTO [dbo].[AssociateCompany] ([AssociateId], [CompanyId])
    VALUES (@paramAssociateId, @paramCompanyId);
END
GO


