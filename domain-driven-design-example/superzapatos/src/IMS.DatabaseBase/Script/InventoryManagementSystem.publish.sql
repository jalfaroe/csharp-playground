USE [master]
GO

-- DROP DATABASE [InventoryManagementSystem]

CREATE DATABASE [InventoryManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystem_Primary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystem_Primary.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

ALTER DATABASE [InventoryManagementSystem] SET COMPATIBILITY_LEVEL = 130
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [InventoryManagementSystem] SET ANSI_NULL_DEFAULT ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET ANSI_NULLS ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET ANSI_PADDING ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET ANSI_WARNINGS ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET ARITHABORT ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET CURSOR_DEFAULT  LOCAL 
GO

ALTER DATABASE [InventoryManagementSystem] SET CONCAT_NULL_YIELDS_NULL ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET QUOTED_IDENTIFIER ON 
GO

ALTER DATABASE [InventoryManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET  DISABLE_BROKER 
GO

ALTER DATABASE [InventoryManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [InventoryManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET RECOVERY FULL 
GO

ALTER DATABASE [InventoryManagementSystem] SET  MULTI_USER 
GO

ALTER DATABASE [InventoryManagementSystem] SET PAGE_VERIFY NONE  
GO

ALTER DATABASE [InventoryManagementSystem] SET DB_CHAINING OFF 
GO

ALTER DATABASE [InventoryManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [InventoryManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [InventoryManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [InventoryManagementSystem] SET QUERY_STORE = OFF
GO

USE [InventoryManagementSystem]
GO

ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO

ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO

ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO

ALTER DATABASE [InventoryManagementSystem] SET  READ_WRITE 
GO



GO
PRINT N'Creating [dbo].[Articles]...';


GO
CREATE TABLE [dbo].[Articles] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)   NOT NULL,
    [Description]  NVARCHAR (150)  NULL,
    [Price]        DECIMAL (16, 4) NOT NULL,
    [TotalInShelf] DECIMAL (16, 4) NOT NULL,
    [TotalInVault] DECIMAL (16, 4) NOT NULL,
    [StoreId]      INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Stores]...';


GO
CREATE TABLE [dbo].[Stores] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (50)  NOT NULL,
    [Address] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Articles_Stores]...';


GO
ALTER TABLE [dbo].[Articles]
    ADD CONSTRAINT [FK_Articles_Stores] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Stores] ([Id]);


GO
/* 
Post-Deployment Script Template               
-------------------------------------------------------------------------------------- 
 This file contains SQL statements that will be appended to the build script.     
 Use SQLCMD syntax to include a file in the post-deployment script.       
 Example:      :r .\myfile.sql                 
 Use SQLCMD syntax to reference a variable in the post-deployment script.     
 Example:      :setvar TableName MyTable               
               SELECT * FROM [$(TableName)]           
-------------------------------------------------------------------------------------- 
*/ 
DECLARE @NewStoreId AS INT 

-- Super Zapatos - Quesada 
INSERT [dbo].[stores] 
       ([name], 
        [address]) 
VALUES (N'Super Zapatos - Quesada', 
        N'Av. 1, Provincia de Alajuela, Cd Quesada'); 

SET @NewStoreId = @@IDENTITY 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato01', 
        N'Descriccion01', 
        10, 
        100, 
        50, 
        @NewStoreId); 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato02', 
        N'Descriccion02', 
        20, 
        200, 
        100, 
        @NewStoreId); 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato03', 
        N'Descriccion03', 
        30, 
        300, 
        150, 
        @NewStoreId); 

-- Super Zapatos - Palmares 
INSERT [dbo].[stores] 
       ([name], 
        [address]) 
VALUES (N'Super Zapatos - Palmares', 
        N'Mercado Municipal, Provincia de Alajuela, Palmares'); 

SET @NewStoreId = @@IDENTITY 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato01', 
        N'Descriccion01', 
        10, 
        100, 
        50, 
        @NewStoreId); 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato02', 
        N'Descriccion02', 
        20, 
        200, 
        100, 
        @NewStoreId); 

INSERT [dbo].[articles] 
       ([name], 
        [description], 
        [price], 
        [totalinshelf], 
        [totalinvault], 
        [storeid]) 
VALUES (N'Zapato03', 
        N'Descriccion03', 
        30, 
        300, 
        150, 
        @NewStoreId); 
GO


GO
PRINT N'Deploy complete.';


GO
