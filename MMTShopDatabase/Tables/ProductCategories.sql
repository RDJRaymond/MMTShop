CREATE TABLE [dbo].[ProductCategories]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [UIX_ProductCategories_Name] ON [dbo].[ProductCategories] ([Name])
GO
