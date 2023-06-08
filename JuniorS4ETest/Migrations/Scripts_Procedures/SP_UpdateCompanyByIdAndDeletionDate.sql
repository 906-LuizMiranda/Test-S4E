

Create PROCEDURE [dbo].[SP_UpdateCompanyByIdAndDeletionDate]
@paramId Int
AS
BEGIN
     UPDATE Companys
    SET DeletionDate= GETDATE()
    WHERE Id = @paramId;
END
GO


