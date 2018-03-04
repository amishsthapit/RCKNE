
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/03/2018 14:23:37
-- Generated from EDMX file: E:\Projects\GIT-Personal\RCKNE\Rotaract_Admin\Rotaract_Admin\Rotaract.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [amish.sthapit_rotaract];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BOD]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BOD];
GO
IF OBJECT_ID(N'[dbo].[member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[member];
GO
IF OBJECT_ID(N'[dbo].[prez]', 'U') IS NOT NULL
    DROP TABLE [dbo].[prez];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[tbl_credential]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_credential];
GO
IF OBJECT_ID(N'[dbo].[tbl_module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_module];
GO
IF OBJECT_ID(N'[dbo].[tbl_role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_role];
GO
IF OBJECT_ID(N'[dbo].[tbl_role_module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_role_module];
GO
IF OBJECT_ID(N'[dbo].[tbl_user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tbl_user];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BODs'
CREATE TABLE [dbo].[BODs] (
    [BODID] uniqueidentifier  NOT NULL,
    [Year] varchar(10)  NOT NULL,
    [Designation] uniqueidentifier  NOT NULL,
    [MemID] uniqueidentifier  NOT NULL,
    [CreatedBy] uniqueidentifier  NOT NULL,
    [CreateTS] datetime  NOT NULL,
    [UpdatedBy] uniqueidentifier  NOT NULL,
    [UpdateTS] datetime  NOT NULL
);
GO

-- Creating table 'members'
CREATE TABLE [dbo].[members] (
    [MemID] uniqueidentifier  NOT NULL,
    [Name] varchar(50)  NULL,
    [DOJ] datetime  NULL,
    [Email] varchar(50)  NULL,
    [Phone] varchar(25)  NULL,
    [Address] varchar(100)  NULL,
    [Photo] varchar(max)  NULL,
    [CreatedBy] uniqueidentifier  NULL,
    [CreateTS] datetime  NOT NULL,
    [UpdatedBy] uniqueidentifier  NULL,
    [UpdateTS] datetime  NOT NULL
);
GO

-- Creating table 'prezs'
CREATE TABLE [dbo].[prezs] (
    [PrezID] uniqueidentifier  NOT NULL,
    [Year] varchar(10)  NOT NULL,
    [CreatedBy] uniqueidentifier  NOT NULL,
    [CreateTS] datetime  NOT NULL,
    [UpdatedBy] uniqueidentifier  NOT NULL,
    [UpdateTS] datetime  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectID] uniqueidentifier  NOT NULL,
    [Title] varchar(max)  NULL,
    [Description] varchar(max)  NULL,
    [Date] datetime  NOT NULL,
    [Venue] varchar(250)  NOT NULL,
    [CreatedBy] uniqueidentifier  NOT NULL,
    [CreateTS] datetime  NOT NULL,
    [UpdatedBy] uniqueidentifier  NOT NULL,
    [UpdateTS] datetime  NOT NULL,
    [RotaYear] varchar(max)  NULL
);
GO

-- Creating table 'tbl_module'
CREATE TABLE [dbo].[tbl_module] (
    [ID] uniqueidentifier  NOT NULL,
    [Module_Name] varchar(50)  NULL,
    [Createdby] varchar(100)  NULL,
    [CreateTS] datetime  NULL,
    [Updatedby] varchar(100)  NULL,
    [UpdateTS] datetime  NULL
);
GO

-- Creating table 'tbl_role'
CREATE TABLE [dbo].[tbl_role] (
    [ID] uniqueidentifier  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Createdby] varchar(100)  NULL,
    [CreateTS] datetime  NULL,
    [Updatedby] varchar(100)  NULL,
    [UpdateTS] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'tbl_role_module'
CREATE TABLE [dbo].[tbl_role_module] (
    [ID] uniqueidentifier  NOT NULL,
    [Role_ID] uniqueidentifier  NOT NULL,
    [Module_ID] uniqueidentifier  NOT NULL,
    [Createdby] varchar(100)  NULL,
    [CreateTS] datetime  NULL,
    [Updatedby] varchar(100)  NULL,
    [UpdateTS] datetime  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'tbl_credential'
CREATE TABLE [dbo].[tbl_credential] (
    [ID] uniqueidentifier  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [Password] varchar(50)  NOT NULL,
    [Status] bit  NOT NULL,
    [Createdby] varchar(100)  NULL,
    [CreateTS] datetime  NULL,
    [Updatedby] varchar(100)  NULL,
    [UpdateTS] datetime  NULL
);
GO

-- Creating table 'tbl_user'
CREATE TABLE [dbo].[tbl_user] (
    [Email] varchar(100)  NOT NULL,
    [Name] varchar(100)  NULL,
    [Phone] varchar(20)  NULL,
    [Address] varchar(max)  NULL,
    [Role] varchar(max)  NOT NULL,
    [Createdby] varchar(100)  NULL,
    [CreateTS] datetime  NULL,
    [Updatedby] varchar(100)  NULL,
    [UpdateTS] datetime  NULL,
    [Status] bit  NULL,
    [SN] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BODID] in table 'BODs'
ALTER TABLE [dbo].[BODs]
ADD CONSTRAINT [PK_BODs]
    PRIMARY KEY CLUSTERED ([BODID] ASC);
GO

-- Creating primary key on [MemID] in table 'members'
ALTER TABLE [dbo].[members]
ADD CONSTRAINT [PK_members]
    PRIMARY KEY CLUSTERED ([MemID] ASC);
GO

-- Creating primary key on [PrezID] in table 'prezs'
ALTER TABLE [dbo].[prezs]
ADD CONSTRAINT [PK_prezs]
    PRIMARY KEY CLUSTERED ([PrezID] ASC);
GO

-- Creating primary key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectID] ASC);
GO

-- Creating primary key on [ID] in table 'tbl_module'
ALTER TABLE [dbo].[tbl_module]
ADD CONSTRAINT [PK_tbl_module]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbl_role'
ALTER TABLE [dbo].[tbl_role]
ADD CONSTRAINT [PK_tbl_role]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbl_role_module'
ALTER TABLE [dbo].[tbl_role_module]
ADD CONSTRAINT [PK_tbl_role_module]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'tbl_credential'
ALTER TABLE [dbo].[tbl_credential]
ADD CONSTRAINT [PK_tbl_credential]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [SN] in table 'tbl_user'
ALTER TABLE [dbo].[tbl_user]
ADD CONSTRAINT [PK_tbl_user]
    PRIMARY KEY CLUSTERED ([SN] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------