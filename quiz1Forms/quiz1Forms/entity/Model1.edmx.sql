
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/20/2025 05:22:35
-- Generated from EDMX file: C:\Users\tutis\OneDrive\Desktop\GAU\s6\c#\quiz1Forms\quiz1Forms\entity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Delivery];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SuppliersSet'
CREATE TABLE [dbo].[SuppliersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [ContactName] nvarchar(max)  NOT NULL,
    [ContactTitle] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductsSet'
CREATE TABLE [dbo].[ProductsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [Package] nvarchar(max)  NOT NULL,
    [IsDiscontinued] bit  NOT NULL,
    [Suppliers_Id] int  NOT NULL
);
GO

-- Creating table 'OrderItemSet'
CREATE TABLE [dbo].[OrderItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UnitPrice] decimal(18,0)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Order_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderDate] datetime  NOT NULL,
    [OrderNumber] nvarchar(max)  NOT NULL,
    [TotalAmount] decimal(18,0)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SuppliersSet'
ALTER TABLE [dbo].[SuppliersSet]
ADD CONSTRAINT [PK_SuppliersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [PK_ProductsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItemSet'
ALTER TABLE [dbo].[OrderItemSet]
ADD CONSTRAINT [PK_OrderItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Suppliers_Id] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [FK_ProductsSuppliers]
    FOREIGN KEY ([Suppliers_Id])
    REFERENCES [dbo].[SuppliersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsSuppliers'
CREATE INDEX [IX_FK_ProductsSuppliers]
ON [dbo].[ProductsSet]
    ([Suppliers_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderItemSet'
ALTER TABLE [dbo].[OrderItemSet]
ADD CONSTRAINT [FK_OrderItemOrder]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderItemOrder'
CREATE INDEX [IX_FK_OrderItemOrder]
ON [dbo].[OrderItemSet]
    ([Order_Id]);
GO

-- Creating foreign key on [Products_Id] in table 'OrderItemSet'
ALTER TABLE [dbo].[OrderItemSet]
ADD CONSTRAINT [FK_ProductsOrderItem]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[ProductsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsOrderItem'
CREATE INDEX [IX_FK_ProductsOrderItem]
ON [dbo].[OrderItemSet]
    ([Products_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_OrderCustomer]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCustomer'
CREATE INDEX [IX_FK_OrderCustomer]
ON [dbo].[OrderSet]
    ([Customer_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------