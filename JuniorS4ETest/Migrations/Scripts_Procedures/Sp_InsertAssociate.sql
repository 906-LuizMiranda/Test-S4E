

CREATE PROCEDURE [dbo].[Sp_InsertAssociate]
    @paramName VARCHAR(200),
    @paramCpf VARCHAR(11),
    @paramDateOfBirth DATE
AS
BEGIN
    DECLARE @AssociateId BIGINT
    
    INSERT INTO Associates 
	(Name, Cpf, DateOfBirth, CreationDate, UpdateDate)
    VALUES 
	(@paramName, @paramCpf, @paramDateOfBirth, GETDATE(), GETDATE())

    SET @AssociateId = SCOPE_IDENTITY()

    SELECT * FROM Associates WHERE Id = @AssociateId
END
GO


