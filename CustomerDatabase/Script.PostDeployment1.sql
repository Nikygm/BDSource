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
INSERT INTO Customer VALUES (1,'Albert')
INSERT INTO Customer VALUES (2,'Benedict')
INSERT INTO Customer VALUES (3,'Chris')

INSERT INTO Product VALUES (1,'Abricot')
INSERT INTO Product VALUES (2,'Banane')
INSERT INTO Product VALUES (3,'Cerise')

INSERT INTO Orders VALUES (1,1)
INSERT INTO Orders VALUES (2,2)
INSERT INTO Orders VALUES (3,3)

INSERT INTO ProductQuantity VALUES (1,1,1,2)
INSERT INTO ProductQuantity VALUES (2,1,2,1)
INSERT INTO ProductQuantity VALUES (3,2,2,5)
INSERT INTO ProductQuantity VALUES (4,2,3,3)
INSERT INTO ProductQuantity VALUES (5,3,1,5)
INSERT INTO ProductQuantity VALUES (6,3,3,8)


