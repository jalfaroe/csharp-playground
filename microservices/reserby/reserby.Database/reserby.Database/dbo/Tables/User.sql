CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Email]       NVARCHAR (50)  NULL,
    [Facebook]    NVARCHAR (150) NULL,
    [PhoneNumber] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

