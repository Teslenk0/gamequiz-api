
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/08/2020 21:08:26
-- Generated from EDMX file: C:\Users\Gabriel\Desktop\Programacion\RIA y .NET\gamequiz-api\Persistencia\Database\ModelosDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [gamequiz];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioJuego]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JuegoSet] DROP CONSTRAINT [FK_UsuarioJuego];
GO
IF OBJECT_ID(N'[dbo].[FK_JuegoPuntaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PuntajeSet] DROP CONSTRAINT [FK_JuegoPuntaje];
GO
IF OBJECT_ID(N'[dbo].[FK_PreguntaRespuesta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RespuestaSet] DROP CONSTRAINT [FK_PreguntaRespuesta];
GO
IF OBJECT_ID(N'[dbo].[FK_JuegoPregunta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PreguntaSet] DROP CONSTRAINT [FK_JuegoPregunta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[JuegoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JuegoSet];
GO
IF OBJECT_ID(N'[dbo].[PuntajeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PuntajeSet];
GO
IF OBJECT_ID(N'[dbo].[PreguntaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PreguntaSet];
GO
IF OBJECT_ID(N'[dbo].[RespuestaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RespuestaSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [FechaNac] datetime  NOT NULL
);
GO

-- Creating table 'JuegoSet'
CREATE TABLE [dbo].[JuegoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Jugados] bigint  NOT NULL,
    [Activo] bit  NOT NULL,
    [Privado] bit  NOT NULL,
    [Caratula] nvarchar(max)  NOT NULL,
    [Musica] int  NOT NULL,
    [Uuid] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [UsuarioId] int  NOT NULL,
    [Creado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PuntajeSet'
CREATE TABLE [dbo].[PuntajeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Puntos] bigint  NOT NULL,
    [JuegoId] int  NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PreguntaSet'
CREATE TABLE [dbo].[PreguntaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mensaje] nvarchar(max)  NOT NULL,
    [Tiempo] bigint  NOT NULL,
    [Puntos] bigint  NOT NULL,
    [Video] nvarchar(max)  NULL,
    [Imagen] nvarchar(max)  NULL,
    [Quiz] bit  NOT NULL,
    [JuegoId] int  NOT NULL,
    [InicioVideo] bigint  NULL,
    [FinVideo] bigint  NULL
);
GO

-- Creating table 'RespuestaSet'
CREATE TABLE [dbo].[RespuestaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mensaje] nvarchar(max)  NOT NULL,
    [Correcta] bit  NOT NULL,
    [VecesSeleccionada] bigint  NOT NULL,
    [PreguntaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JuegoSet'
ALTER TABLE [dbo].[JuegoSet]
ADD CONSTRAINT [PK_JuegoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PuntajeSet'
ALTER TABLE [dbo].[PuntajeSet]
ADD CONSTRAINT [PK_PuntajeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PreguntaSet'
ALTER TABLE [dbo].[PreguntaSet]
ADD CONSTRAINT [PK_PreguntaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RespuestaSet'
ALTER TABLE [dbo].[RespuestaSet]
ADD CONSTRAINT [PK_RespuestaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioId] in table 'JuegoSet'
ALTER TABLE [dbo].[JuegoSet]
ADD CONSTRAINT [FK_UsuarioJuego]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioJuego'
CREATE INDEX [IX_FK_UsuarioJuego]
ON [dbo].[JuegoSet]
    ([UsuarioId]);
GO

-- Creating foreign key on [JuegoId] in table 'PuntajeSet'
ALTER TABLE [dbo].[PuntajeSet]
ADD CONSTRAINT [FK_JuegoPuntaje]
    FOREIGN KEY ([JuegoId])
    REFERENCES [dbo].[JuegoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JuegoPuntaje'
CREATE INDEX [IX_FK_JuegoPuntaje]
ON [dbo].[PuntajeSet]
    ([JuegoId]);
GO

-- Creating foreign key on [PreguntaId] in table 'RespuestaSet'
ALTER TABLE [dbo].[RespuestaSet]
ADD CONSTRAINT [FK_PreguntaRespuesta]
    FOREIGN KEY ([PreguntaId])
    REFERENCES [dbo].[PreguntaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PreguntaRespuesta'
CREATE INDEX [IX_FK_PreguntaRespuesta]
ON [dbo].[RespuestaSet]
    ([PreguntaId]);
GO

-- Creating foreign key on [JuegoId] in table 'PreguntaSet'
ALTER TABLE [dbo].[PreguntaSet]
ADD CONSTRAINT [FK_JuegoPregunta]
    FOREIGN KEY ([JuegoId])
    REFERENCES [dbo].[JuegoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JuegoPregunta'
CREATE INDEX [IX_FK_JuegoPregunta]
ON [dbo].[PreguntaSet]
    ([JuegoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------