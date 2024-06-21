
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2024 09:56:20
-- Generated from EDMX file: C:\uni\dotnet\Final\RealEstate\EF\RealEstateModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RealEstate];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Properties_Categories1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_Properties_Categories1];
GO
IF OBJECT_ID(N'[dbo].[FK_Properties_Locations1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_Properties_Locations1];
GO
IF OBJECT_ID(N'[dbo].[FK_Properties_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Properties] DROP CONSTRAINT [FK_Properties_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_RolesToPermissions_Permissions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolesToPermissions] DROP CONSTRAINT [FK_RolesToPermissions_Permissions];
GO
IF OBJECT_ID(N'[dbo].[FK_RolesToPermissions_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RolesToPermissions] DROP CONSTRAINT [FK_RolesToPermissions_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Locations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Locations];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Locations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Locations];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[Properties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Properties];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[RolesToPermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RolesToPermissions];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(50)  NULL
);
GO

-- Creating table 'Locations'
CREATE TABLE [dbo].[Locations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Country] nvarchar(50)  NULL,
    [City] nvarchar(50)  NULL
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PermissionName] varchar(50)  NULL
);
GO

-- Creating table 'Properties'
CREATE TABLE [dbo].[Properties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PropertyName] nvarchar(50)  NULL,
    [Description] nvarchar(500)  NULL,
    [Rooms] int  NULL,
    [Size] float  NULL,
    [Floors] int  NULL,
    [LocationId] int  NULL,
    [CategoryId] int  NULL,
    [AgentId] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [RoleId] int  NULL,
    [LocationId] int  NULL
);
GO

-- Creating table 'RolesToPermissions'
CREATE TABLE [dbo].[RolesToPermissions] (
    [Permissions_Id] int  NOT NULL,
    [Roles_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Locations'
ALTER TABLE [dbo].[Locations]
ADD CONSTRAINT [PK_Locations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [PK_Properties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Permissions_Id], [Roles_Id] in table 'RolesToPermissions'
ALTER TABLE [dbo].[RolesToPermissions]
ADD CONSTRAINT [PK_RolesToPermissions]
    PRIMARY KEY CLUSTERED ([Permissions_Id], [Roles_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_Properties_Categories1]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Properties_Categories1'
CREATE INDEX [IX_FK_Properties_Categories1]
ON [dbo].[Properties]
    ([CategoryId]);
GO

-- Creating foreign key on [LocationId] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_Properties_Locations1]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Properties_Locations1'
CREATE INDEX [IX_FK_Properties_Locations1]
ON [dbo].[Properties]
    ([LocationId]);
GO

-- Creating foreign key on [LocationId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Locations]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[Locations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Locations'
CREATE INDEX [IX_FK_Users_Locations]
ON [dbo].[Users]
    ([LocationId]);
GO

-- Creating foreign key on [AgentId] in table 'Properties'
ALTER TABLE [dbo].[Properties]
ADD CONSTRAINT [FK_Properties_Users]
    FOREIGN KEY ([AgentId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Properties_Users'
CREATE INDEX [IX_FK_Properties_Users]
ON [dbo].[Properties]
    ([AgentId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Roles]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Roles'
CREATE INDEX [IX_FK_Users_Roles]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [Permissions_Id] in table 'RolesToPermissions'
ALTER TABLE [dbo].[RolesToPermissions]
ADD CONSTRAINT [FK_RolesToPermissions_Permissions]
    FOREIGN KEY ([Permissions_Id])
    REFERENCES [dbo].[Permissions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_Id] in table 'RolesToPermissions'
ALTER TABLE [dbo].[RolesToPermissions]
ADD CONSTRAINT [FK_RolesToPermissions_Roles]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolesToPermissions_Roles'
CREATE INDEX [IX_FK_RolesToPermissions_Roles]
ON [dbo].[RolesToPermissions]
    ([Roles_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------