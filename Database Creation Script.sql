IF db_id('abcautomotive') IS NULL 
    CREATE DATABASE abcautomotive

GO

CREATE TABLE [abcautomotive].[dbo].[Car] (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    carType varchar(255) NOT NULL,
    carColor varchar(255) NOT NULL,
	carCost float NOT NULL,
	convertible bit NOT NULL
);

Insert into [abcautomotive].[dbo].[Car] ([carType],[carColor],[carCost],[convertible]) VALUES 
('SUV','Blue',11000,0),('SUV','Red',11000,0),('SUV','Green',11000,0),('SUV','Yellow',11000,0),
('Sedan','Blue',10000,1),('Sedan','Red',10000,0),('Sedan','Green',10000,0),('Sedan','Yellow',10000,1),
('Sport','Blue',12000,0),('Sport','Red',12000,1),('Sport','Green',12000,1),('Sport','Yellow',12000,0)