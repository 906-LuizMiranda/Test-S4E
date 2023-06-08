

CREATE PROCEDURE [dbo].[SP_GetAssociateByCpf]
@paramCpf Varchar(11)
AS
BEGIN
    SELECT * FROM Associates where Cpf = @paramCpf and DeletionDate is null;
END
GO


