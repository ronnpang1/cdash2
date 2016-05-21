CREATE TABLE [dbo].[users] (
    [userID]   INT IDENTITY(1,1 ) NOT NULL,
    [FIRSTName]     VARCHAR (25) NOT NULL,
	[LASTName]     VARCHAR (35) NOT NULL,
    [email]    VARCHAR (50) NOT NULL,
    [password] VARCHAR (50) NOT NULL,
    [role]     VARCHAR (50) NOT NULL,
   CONSTRAINT [PK_dbo.users] PRIMARY KEY CLUSTERED ([userID] ASC)
);