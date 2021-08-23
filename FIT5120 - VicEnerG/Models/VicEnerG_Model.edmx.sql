
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/23/2021 17:31:59
-- Generated from EDMX file: F:\2021\Monash\FIT5120 - Studio Project\FIT5120 - VicEnerG\FIT5120 - VicEnerG\Models\VicEnerG_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [VicEnerG_Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StationStationData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationDataSet] DROP CONSTRAINT [FK_StationStationData];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationSet];
GO
IF OBJECT_ID(N'[dbo].[StationDataSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationDataSet];
GO
IF OBJECT_ID(N'[dbo].[ApplianceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ApplianceSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StationSet'
CREATE TABLE [dbo].[StationSet] (
    [stationNumber] int  NOT NULL,
    [stationName] nvarchar(max)  NOT NULL,
    [stationLat] float  NOT NULL,
    [stationLon] float  NOT NULL
);
GO

-- Creating table 'StationDataSet'
CREATE TABLE [dbo].[StationDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [monthRadiation] float  NOT NULL,
    [month] smallint  NOT NULL,
    [Station_stationNumber] int  NOT NULL
);
GO

-- Creating table 'ApplianceSet'
CREATE TABLE [dbo].[ApplianceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [applianceName] nvarchar(max)  NOT NULL,
    [usage] float  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [stationNumber] in table 'StationSet'
ALTER TABLE [dbo].[StationSet]
ADD CONSTRAINT [PK_StationSet]
    PRIMARY KEY CLUSTERED ([stationNumber] ASC);
GO

-- Creating primary key on [Id] in table 'StationDataSet'
ALTER TABLE [dbo].[StationDataSet]
ADD CONSTRAINT [PK_StationDataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ApplianceSet'
ALTER TABLE [dbo].[ApplianceSet]
ADD CONSTRAINT [PK_ApplianceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Station_stationNumber] in table 'StationDataSet'
ALTER TABLE [dbo].[StationDataSet]
ADD CONSTRAINT [FK_StationStationData]
    FOREIGN KEY ([Station_stationNumber])
    REFERENCES [dbo].[StationSet]
        ([stationNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationStationData'
CREATE INDEX [IX_FK_StationStationData]
ON [dbo].[StationDataSet]
    ([Station_stationNumber]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------