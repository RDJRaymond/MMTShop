CREATE PROCEDURE [dbo].[SP_GetFeaturedProducts]
AS
	SELECT * FROM Products WHERE IsFeatured = 1;
RETURN 0
