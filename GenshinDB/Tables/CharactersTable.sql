CREATE TABLE [dbo].[CharactersTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Rarity] NVARCHAR(50) NOT NULL, 
    [Birthday] NVARCHAR(50) NOT NULL, 
    [Allegiance] NVARCHAR(50) NOT NULL, 
    [Element] NVARCHAR(50) NOT NULL, 
    [Image] NVARCHAR(256) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL
)
