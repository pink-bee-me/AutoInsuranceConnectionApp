
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/19/2021 12:18:57
-- Generated from EDMX file: C:\Users\LaurieSue\source\repos\AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\Models\InsuranceEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Insurance];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Insuree]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Insuree];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Insurees'
CREATE TABLE [dbo].[Insurees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(100)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [CarYear] int  NOT NULL,
    [CarMake] nvarchar(50)  NOT NULL,
    [CarModel] nvarchar(50)  NOT NULL,
    [DUI] bit  NOT NULL,
    [SpeedingTickets] int  NOT NULL,
    [CoverageType] bit  NOT NULL,
    [Quote] decimal(19,4)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Insurees'
ALTER TABLE [dbo].[Insurees]
ADD CONSTRAINT [PK_Insurees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------