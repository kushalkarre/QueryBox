CREATE TABLE [dbo].[Faculty]
(
	[Id_faculty] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name_faculty] VARCHAR(50) NULL, 
    [password_faculty] VARCHAR(50) NULL, 
    [lab_faculty] VARCHAR(50) NULL, 
    [stutus_faculty] INT NULL
)
