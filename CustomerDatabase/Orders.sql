CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerFK] INT NOT NULL, 
    CONSTRAINT [CustomerFK] FOREIGN KEY ([CustomerFK]) REFERENCES [Customer]([Id])
)
