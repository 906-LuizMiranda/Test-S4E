
CREATE PROCEDURE [dbo].[SP_DeletionAssociateCompanyByAssociateIdAndCompanyId]
    @paramAssociateId INT,
    @paramCompanyId INT
AS
BEGIN
    UPDATE AssociateCompany
    SET DeletionDate = GETDATE()
    WHERE AssociateId = @paramAssociateId AND CompanyId = @paramCompanyId;
END
GO


