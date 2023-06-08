

CREATE PROCEDURE [dbo].[SP_GetListCompany]
AS
BEGIN
    SELECT * FROM Companys where DeletionDate IS NULL;
END
GO


