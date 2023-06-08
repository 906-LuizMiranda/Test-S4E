

CREATE PROCEDURE [dbo].[SP_GetCompanyById]
    @paramId bigint
AS
BEGIN
    SELECT*FROM Companys WHERE Id = @paramId AND DeletionDate IS NULL;
END
GO


