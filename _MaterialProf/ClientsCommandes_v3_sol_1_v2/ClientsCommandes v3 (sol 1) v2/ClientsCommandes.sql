

IF db_id('clientsCommandes') IS NULL CREATE DATABASE clientsCommandes;
GO

-- if object_id('object_name', 'U') is null -- for table

USE clientsCommandes ;

CREATE TABLE Clients( ClientId INT  NOT NULL, 
 Nom VARCHAR(30) NOT NULL UNIQUE,
 PRIMARY KEY (ClientId));


CREATE TABLE Commandes 
 (ComId INT NOT NULL, 
 Description VARCHAR(100) NOT NULL,
 Prix Decimal(10,2) NOT NULL,
 ClientId INT NOT NULL, 
 PRIMARY KEY (ComId),
 FOREIGN KEY (ClientId) REFERENCES
 Clients(ClientId)
 ON DELETE NO ACTION
 ON UPDATE CASCADE);
GO

INSERT INTO Clients (ClientId, Nom) 
VALUES ( 1, 'Pierre'),
( 2, 'Marie'),
( 3, 'Anne'),
( 4, 'Jacques') ;

INSERT INTO Commandes (ComId, Description, Prix ,ClientId)
VALUES (1, 'clavier', 30.00, 3),
(2, 'souris', 15.00, 3) ,
(3, 'imprimant',  250.00, 1);

GO









