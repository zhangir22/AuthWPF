CREATE DATABASE domofoneDb
GO
USE domofoneDb
GO 
CREATE TABLE users
(
id INT PRIMARY KEY IDENTITY NOT NULL,
name NVARCHAR(MAX) NOT NULL,
email NVARCHAR(MAX) NOT NULL,
password NVARCHAR(MAX) NOT NULL,
)
GO 
INSERT INTO users(name,email,password)VALUES('admin','admin@mail.ru','123');
