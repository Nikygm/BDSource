CREATE TABLE [dbo].[ProductQuantity]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [OrderFK] INT NOT NULL, 
    [ProductFK] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [OrderFK] FOREIGN KEY ([OrderFK]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [ProductFK] FOREIGN KEY ([ProductFK]) REFERENCES [Product]([Id])
)
