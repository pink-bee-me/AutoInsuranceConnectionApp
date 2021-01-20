
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2021 16:10:04
-- Generated from EDMX file: C:\Users\LaurieSue\source\repos\AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\Models\Quote.edmx
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

IF OBJECT_ID(N'[dbo].[FK__Quote__InsureeId__36B12243]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quotes] DROP CONSTRAINT [FK__Quote__InsureeId__36B12243];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Insurees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Insurees];
GO
IF OBJECT_ID(N'[dbo].[Quotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quotes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Insurees'
CREATE TABLE [dbo].[Insurees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
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

-- Creating table 'Quotes'
CREATE TABLE [dbo].[Quotes] (
    [QuoteId] int IDENTITY(1,1) NOT NULL,
    [InsureeId] int  NOT NULL,
    [BaseRate] decimal(19,4)  NOT NULL,
    [AgeUnder18] decimal(19,4)  NOT NULL,
    [Age19to25] decimal(19,4)  NOT NULL,
    [Age26AndUp] decimal(19,4)  NOT NULL,
    [AutoYearPrior2000] decimal(19,4)  NOT NULL,
    [AutoYearAfter2015] decimal(19,4)  NOT NULL,
    [IsPorsche] decimal(19,4)  NOT NULL,
    [IsCarerra911] decimal(19,4)  NOT NULL,
    [SpeedingTicket] decimal(19,4)  NOT NULL,
    [SubTotalBeforeDUICalc] decimal(19,4)  NOT NULL,
    [DUIRateUP25Percent] decimal(19,4)  NOT NULL,
    [SubTotalAfterDUICalc] decimal(19,4)  NOT NULL,
    [FullCovRateUP50Percent] decimal(19,4)  NOT NULL,
    [SubTotalAfterFullCovCalc] decimal(19,4)  NOT NULL,
    [QuoteInsCostPerMonth] decimal(19,4)  NOT NULL,
    [QuoteInsCostPerYear] decimal(19,4)  NOT NULL
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

-- Creating primary key on [QuoteId] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [PK_Quotes]
    PRIMARY KEY CLUSTERED ([QuoteId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InsureeId] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [FK__Quote__InsureeId__36B12243]
    FOREIGN KEY ([InsureeId])
    REFERENCES [dbo].[Insurees]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Quote__InsureeId__36B12243'
CREATE INDEX [IX_FK__Quote__InsureeId__36B12243]
ON [dbo].[Quotes]
    ([InsureeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------