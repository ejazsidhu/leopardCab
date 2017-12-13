CREATE TABLE [dbo].[Feedback]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NULL, 
    [DriverId] INT NULL, 
    [Feedback] NVARCHAR(MAX) NOT NULL
)
