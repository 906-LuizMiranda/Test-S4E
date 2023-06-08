

Create PROCEDURE [dbo].[SP_UpdateAssociateByCpfDeletionDate]
@paramCpf varchar(11)
AS
BEGIN
     UPDATE Associates
    SET DeletionDate= GETDATE()
    WHERE Cpf = @paramCpf;
END
GO


