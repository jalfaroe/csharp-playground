CREATE TABLE [dbo].[Articles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(150) NULL, 
    [Price] DECIMAL(16, 4) NOT NULL, 
    [TotalInShelf] DECIMAL(16, 4) NOT NULL, 
    [TotalInVault] DECIMAL(16, 4) NOT NULL, 
    [StoreId] INT NOT NULL, 
    CONSTRAINT [FK_Articles_Stores] FOREIGN KEY ([StoreId]) REFERENCES [Stores]([Id])
)
