
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/19/2021 17:04:24
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
    [systemSize] int  NOT NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------