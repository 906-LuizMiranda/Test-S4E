
Create PROCEDURE [dbo].[SP_UpdateAssociateByIdAndDeletionDate]
@paramId bigint
AS
BEGIN
     UPDATE Associates
    SET DeletionDate= GETDATE()
    WHERE Id = @paramId;
END
GO


