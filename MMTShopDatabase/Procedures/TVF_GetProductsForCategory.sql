CREATE FUNCTION [dbo].[SP_GetProductsForCategory](@categoryId int)
RETURNS TABLE
AS
RETURN
(
	SELECT p.*, c.[Name] AS [ProductCategory_Name] FROM Products p
	INNER JOIN ProductCategories c ON p.CategoryId = c.Id
	WHERE CategoryId = @categoryId
);
