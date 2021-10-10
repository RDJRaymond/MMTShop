CREATE TABLE [dbo].[Products]
(
	/*
		The SKU is split into Product Id and Product Category Id
		SKU = {CategoryId}{Id}
		This mirrors real-world SKUs being composed of descriptive parts, and would allow us
			to add more "parts" to the SKU format later with minimal effect on existing products
	*/
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[CategoryId] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[Price] MONEY,
	[IsFeatured] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId]) REFERENCES [ProductCategories]([Id]),
	CONSTRAINT [CHK_Products_NoFreeLunch] CHECK([Price] > 0)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX [UIX_Products_Name] ON [dbo].[Products] ([Name])
GO

CREATE NONCLUSTERED INDEX [IX_Products_Category] on [dbo].[Products] ([CategoryId])
GO

CREATE NONCLUSTERED INDEX [IX_Products_IsFeatured] on [dbo].[Products] ([IsFeatured])
GO
