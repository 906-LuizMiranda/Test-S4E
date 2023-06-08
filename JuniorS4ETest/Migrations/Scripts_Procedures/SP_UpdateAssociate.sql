

CREATE PROCEDURE [dbo].[SP_UpdateAssociate]
    @paramAssociateId INT,
    @paramName VARCHAR(200) = NULL,
    @paramCpf VARCHAR(11) = NULL,
    @paramDateOfBirth DATE = NULL
AS
BEGIN
    UPDATE [dbo].[Associates]
    SET
        [Name] = ISNULL(@paramName, [Name]),
        [Cpf] = ISNULL(@paramCpf, [Cpf]),
        [DateOfBirth] = ISNULL(@paramDateOfBirth, [DateOfBirth]),
        [UpdateDate] = GETDATE()
    WHERE
        [Id] = @paramAssociateId;
END
GO


