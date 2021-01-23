
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/22/2021 05:11:15
-- Generated from EDMX file: C:\Users\LaurieSue\source\repos\AutoInsuranceConnectionApp\AutoInsuranceConnectionApp\Models\AutoInsuranceEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoInsurance];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Insurees__QuoteI__66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Insurees] DROP CONSTRAINT [FK__Insurees__QuoteI__66603565];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AutoQuotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AutoQuotes];
GO
IF OBJECT_ID(N'[dbo].[Insurees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Insurees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AutoQuotes'
CREATE TABLE [dbo].[AutoQuotes] (
    [QuoteID] int IDENTITY(1,1) NOT NULL,
    [BaseRate] decimal(19,4)  NOT NULL,
    [AgeUnder18] decimal(19,4)  NOT NULL,
    [Age19to25] decimal(19,4)  NOT NULL,
    [Age26AndUp] decimal(19,4)  NOT NULL,
    [AutoYearBefore2000] decimal(19,4)  NOT NULL,
    [AutoYearAfter2015] decimal(19,4)  NOT NULL,
    [IsPorsche] decimal(19,4)  NOT NULL,
    [IsCarerra911] decimal(19,4)  NOT NULL,
    [SpeedingTickets] decimal(19,4)  NOT NULL,
    [SubTotalBeforeDUICalc] decimal(19,4)  NOT NULL,
    [DUIRateUP25Percent] decimal(19,4)  NOT NULL,
    [SubTotalAfterDUICalc] decimal(19,4)  NOT NULL,
    [FullCovRateUP50Percent] decimal(19,4)  NOT NULL,
    [SubTotalAfterFullCovCalc] decimal(19,4)  NOT NULL,
    [QuoteMonthly] decimal(19,4)  NOT NULL,
    [QuoteYearly] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Insurees'
CREATE TABLE [dbo].[Insurees] (
    [InsureeID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [EmailAddress] nvarchar(100)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [CarYear] int  NOT NULL,
    [CarMake] nvarchar(50)  NOT NULL,
    [CarModel] nvarchar(50)  NOT NULL,
    [SpeedingTickets] int  NOT NULL,
    [DUI] bit  NOT NULL,
    [CoverageType] bit  NOT NULL,
    [QuoteID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [QuoteID] in table 'AutoQuotes'
ALTER TABLE [dbo].[AutoQuotes]
ADD CONSTRAINT [PK_AutoQuotes]
    PRIMARY KEY CLUSTERED ([QuoteID] ASC);
GO

-- Creating primary key on [InsureeID] in table 'Insurees'
ALTER TABLE [dbo].[Insurees]
ADD CONSTRAINT [PK_Insurees]
    PRIMARY KEY CLUSTERED ([InsureeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuoteID] in table 'Insurees'
ALTER TABLE [dbo].[Insurees]
ADD CONSTRAINT [FK__Insurees__QuoteI__66603565]
    FOREIGN KEY ([QuoteID])
    REFERENCES [dbo].[AutoQuotes]
        ([QuoteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Insurees__QuoteI__66603565'
CREATE INDEX [IX_FK__Insurees__QuoteI__66603565]
ON [dbo].[Insurees]
    ([QuoteID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------