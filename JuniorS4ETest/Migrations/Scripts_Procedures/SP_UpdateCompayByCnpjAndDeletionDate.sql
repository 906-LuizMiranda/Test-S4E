

CREATE PROCEDURE [dbo].[SP_UpdateCompayByCnpjAndDeletionDate]
@paramCnpj varchar(14)
AS
BEGIN
     UPDATE Companys
    SET DeletionDate= GETDATE()
    WHERE Cnpj = @paramCnpj;
END
GO


