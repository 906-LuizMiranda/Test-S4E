
CREATE PROCEDURE [dbo].[SP_GetListAssociate]
AS
BEGIN
    SELECT * FROM Associates where DeletionDate IS NULL;
END
GO


