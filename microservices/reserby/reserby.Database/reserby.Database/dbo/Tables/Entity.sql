CREATE TABLE [dbo].[Entity] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId] INT            NOT NULL,
    [Name]      NVARCHAR (50)  NULL,
    [Location]  NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Entity_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
);

