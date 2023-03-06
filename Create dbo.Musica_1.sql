USE [BancoMusica.Data]
GO

/****** Objeto: Table [dbo].[Musica] Data do Script: 03/03/2023 13:40:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Musica] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [ReleaseDate] DATETIME2 (7)  NOT NULL,
    [Genre]       NVARCHAR (MAX) NULL,
    [Video]       NVARCHAR (MAX) NOT NULL
);

select * from [dbo].Musica


