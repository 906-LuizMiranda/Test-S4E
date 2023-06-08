
CREATE PROCEDURE [dbo].[SP_UpdateCompanyAssociateByCompanyIdAndDeletionDate]
@paramCompanyId int
AS
BEGIN
     UPDATE AssociateCompany
    SET DeletionDate = GETDATE()
    WHERE CompanyId = @paramCompanyId;
END
GO


