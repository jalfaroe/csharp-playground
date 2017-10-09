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