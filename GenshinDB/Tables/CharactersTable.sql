CREATE TABLE [dbo].[CharactersTable]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
    [Name] NVARCHAR(150) NOT NULL, 
    [Rarity] NVARCHAR(50) NOT NULL, 
    [Birthday] NVARCHAR(50) NOT NULL, 
    [Allegiance] NVARCHAR(256) NOT NULL, 
    [Element] NVARCHAR(50) NOT NULL, 
    [Image] NVARCHAR(1024) NOT NULL, 
    [Description] NVARCHAR(1024) NOT NULL
)
