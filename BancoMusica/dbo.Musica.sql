﻿CREATE TABLE [dbo].[Musica] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX)  NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Genre]       NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Musica] PRIMARY KEY CLUSTERED ([Id] ASC)
);

