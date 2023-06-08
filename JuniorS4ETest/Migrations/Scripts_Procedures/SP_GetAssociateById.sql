

CREATE PROCEDURE [dbo].[SP_GetAssociateById]
    @paramId bigint
AS
BEGIN
    SELECT*FROM Associates WHERE Id = @paramId AND DeletionDate IS NULL;
END
GO


