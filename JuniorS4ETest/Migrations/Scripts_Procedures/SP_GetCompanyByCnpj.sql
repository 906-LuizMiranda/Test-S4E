
CREATE PROCEDURE [dbo].[SP_GetCompanyByCnpj]
@paramCnpj Varchar(14)
AS
BEGIN
    SELECT * FROM Companys where Cnpj = @paramCnpj and DeletionDate is null;
END
GO


