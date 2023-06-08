


CREATE PROCEDURE [dbo].[SP_UpdateAssociateCompanyByAssociateIdAndDeletionDate]
@paramAssociateId int
AS
BEGIN
     UPDATE AssociateCompany
    SET DeletionDate = GETDATE()
    WHERE AssociateId = @paramAssociateId;
END
GO


