CREATE PROCEDURE [dbo].[SP_GetProductCategories]
AS
	SELECT * FROM ProductCategories
	ORDER BY Id
RETURN 0
