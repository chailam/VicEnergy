
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2021 23:02:53
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CalculatorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalculatorSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CalculatorSet'
CREATE TABLE [dbo].[CalculatorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [area] float  NOT NULL,
    [efficiency] float  NOT NULL,
    [energy] float  NOT NULL,
    [performanceRatio] float  NOT NULL,
    [radiation] float  NOT NULL,
    [systemSize] smallint  NOT NULL
);
GO

-- Creating table 'StationSet'
CREATE TABLE [dbo].[StationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [stationNumber] smallint  NOT NULL,
    [stationName] nvarchar(max)  NOT NULL,
    [stationLat] float  NOT NULL,
    [stationLon] float  NOT NULL
);
GO

-- Creating table 'StationDataSet'
CREATE TABLE [dbo].[StationDataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [stationNumber] smallint  NOT NULL,
    [monthRadiation] float  NOT NULL,
    [month] nvarchar(max)  NOT NULL,
    [Station_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'CalculatorSet'
ALTER TABLE [dbo].[CalculatorSet]
ADD CONSTRAINT [PK_CalculatorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StationSet'
ALTER TABLE [dbo].[StationSet]
ADD CONSTRAINT [PK_StationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating foreign key on [Station_Id] in table 'StationDataSet'
ALTER TABLE [dbo].[StationDataSet]
ADD CONSTRAINT [FK_StationStationData]
    FOREIGN KEY ([Station_Id])
    REFERENCES [dbo].[StationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationStationData'
CREATE INDEX [IX_FK_StationStationData]
ON [dbo].[StationDataSet]
    ([Station_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------