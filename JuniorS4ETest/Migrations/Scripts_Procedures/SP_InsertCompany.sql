

Create PROCEDURE [dbo].[SP_InsertCompany]
    @paramName VARCHAR(200),
    @paramCnpj VARCHAR(14)
AS
BEGIN
    DECLARE @CompanyId BIGINT
    
    INSERT INTO Companys 
	(Name, Cnpj, CreationDate, UpdateDate)
    VALUES 
	(@paramName, @paramCnpj, GETDATE(), GETDATE())

    SET @CompanyId = SCOPE_IDENTITY()

    SELECT * FROM Companys WHERE Id = @CompanyId
END
GO


