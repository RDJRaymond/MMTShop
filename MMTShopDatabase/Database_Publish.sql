GO
PRINT N'Creating Table [dbo].[ProductCategories]...';


GO
CREATE TABLE [dbo].[ProductCategories] (
    [Id]   INT            NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[ProductCategories].[UIX_ProductCategories_Name]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_ProductCategories_Name]
    ON [dbo].[ProductCategories]([Name] ASC);


GO
PRINT N'Creating Table [dbo].[Products]...';


GO
CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Price]       MONEY          NULL,
    [IsFeatured]  BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Index [dbo].[Products].[UIX_Products_Name]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [UIX_Products_Name]
    ON [dbo].[Products]([Name] ASC);


GO
PRINT N'Creating Index [dbo].[Products].[IX_Products_Category]...';


GO
CREATE NONCLUSTERED INDEX [IX_Products_Category]
    ON [dbo].[Products]([CategoryId] ASC);


GO
PRINT N'Creating Index [dbo].[Products].[IX_Products_IsFeatured]...';


GO
CREATE NONCLUSTERED INDEX [IX_Products_IsFeatured]
    ON [dbo].[Products]([IsFeatured] ASC);


GO
PRINT N'Creating Default Constraint unnamed constraint on [dbo].[Products]...';


GO
ALTER TABLE [dbo].[Products]
    ADD DEFAULT 0 FOR [IsFeatured];


GO
PRINT N'Creating Foreign Key [dbo].[FK_Products_Categories]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ProductCategories] ([Id]);


GO
PRINT N'Creating Check Constraint [dbo].[CHK_Products_NoFreeLunch]...';


GO
ALTER TABLE [dbo].[Products]
    ADD CONSTRAINT [CHK_Products_NoFreeLunch] CHECK ([Price] > 0);


GO
PRINT N'Creating Procedure [dbo].[SP_GetProductsForCategory]...';


GO
CREATE PROCEDURE [dbo].[SP_GetProductsForCategory]
	@categoryId int
AS
	SELECT p.*, c.[Name] AS [ProductCategory_Name] FROM Products p
	INNER JOIN ProductCategories c ON p.CategoryId = c.Id
	WHERE CategoryId = @categoryId
RETURN 0
GO
PRINT N'Creating Procedure [dbo].[SP_GetFeaturedProducts]...';


GO
CREATE PROCEDURE [dbo].[SP_GetFeaturedProducts]
AS
	SELECT * FROM Products WHERE IsFeatured = 1;
RETURN 0
GO
PRINT N'Creating Procedure [dbo].[SP_GetProductCategories]...';


GO
CREATE PROCEDURE [dbo].[SP_GetProductCategories]
AS
	SELECT * FROM ProductCategories
	ORDER BY Id
RETURN 0
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT TOP 1 * FROM ProductCategories)
BEGIN
	INSERT INTO ProductCategories ([Id], [Name])
	VALUES
	(1, 'Home'),
	(2, 'Garden'),
	(3, 'Electronics'),
	(4, 'Fitness'),
	(5, 'Toys');
END;

IF NOT EXISTS (SELECT TOP 1 * FROM Products)
BEGIN
	INSERT INTO Products([CategoryId], [Name], [Description], [Price], [IsFeatured])
	VALUES
	(1, 'Red Fabric Armchair', 'An armchair made of red fabric.', 300, 1),
	(1, 'Blue Fabric Armchair', 'An armchair made of blue fabric.', 310, 1),
	(1, 'Green Fabric Armchair', 'An armchair made of green fabric.', 320, 1),
	(1, 'White Leather Armchair', 'An armchair made of white leather.', 599.99, 1),
	(1, 'Black Leather Armchair', 'An armchair made of black leather.', 589.99, 1),
	(2, 'White Patio chair', 'A white plastic patio chair.', 15, 1),
	(2, 'Black Patio chair', 'A black plastic patio chair.', 15, 1),
	(2, 'Rattan Patio chair', 'A rattan patio chair.', 59.99, 1),
	(2, 'Lawn chair', 'A lawn chair.', 49.99, 1),
	(2, 'Folding lawn chair', 'A lawn chair that folds.', 74.99, 1),
	(3, 'GameStation 6', 'Next-gen gaming console.', 799.99, 1),
	(3, 'GameBox 1080', 'Next-gen gaming console.', 789.99, 1),
	(3, 'GameGuy Toggle', 'Next-gen handheld gaming console.', 499.99, 1),
	(3, 'Kettle VapourDeck', 'Next-gen handheld gaming PC.', 569.00, 1),
	(3, 'MyPhone XV', 'The latest in mobile phones.', 1200, 1),
	(4, 'Electronic treadmill', 'Electronic treadmill with variable incline.', 800, 0),
	(4, 'Free weights set', 'A set of weights.', 150, 0),
	(4, 'Home multi-gym', 'A multi-gym for your home.', 600, 0),
	(4, 'FitWatch', 'Wearable fitness tracker.', 249.99, 0),
	(5, 'SuperBlock building blocks', 'A set of 500 blocks.', 29.99, 0),
	(5, 'Foam dart gun', 'A toy gun that fires foam darts. Ages 6 and up. Darts not included.', 9.99, 0),
	(5, 'Rubik''s Cube', 'Can you solve it?', 4.99, 0),
	(5, 'Hot Wheel', 'The coolest unicycle toy around.', 1.99, 0);
END;

GO
PRINT N'Update complete.';


GO
