CREATE TABLE [dbo].[Reservations] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [EntityId]  INT           NOT NULL,
    [UserId]    INT           NOT NULL,
    [StartTime] DATETIME      NULL,
    [EndTime]   DATETIME      NULL,
    [Contact]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Reservations_Entity] FOREIGN KEY ([EntityId]) REFERENCES [dbo].[Entity] ([Id]),
    CONSTRAINT [FK_Reservations_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

