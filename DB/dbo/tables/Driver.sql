CREATE TABLE [dbo].[Driver]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Contact] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL, 
    [CabNumber] NVARCHAR(50) NOT NULL, 
    [CNIC] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [CK_Driver_Unique_Name] UNIQUE(Name), 
    CONSTRAINT [CK_Driver_Contact] UNIQUE(Contact), 
    CONSTRAINT [CK_Driver_Email] UNIQUE(Email), 
    CONSTRAINT [CK_Driver_CabNumber] UNIQUE(CabNumber), 
    CONSTRAINT [CK_Driver_CNIC] UNIQUE(CNIC)
)
