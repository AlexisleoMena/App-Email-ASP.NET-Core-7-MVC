CREATE DATABASE DBEmail;
GO

USE DBEmail;
GO

CREATE TABLE [User] (
    Id int primary key identity(1,1),
    Name varchar(50),
    Email varchar(50),
    Password varchar(100)
);
GO
