-- CREATE TABLE Users
-- (
--     Id INT IDENTITY(1,1) PRIMARY KEY,
--     Name VARCHAR(20) NOT NULL,
--     Surname VARCHAR(25) NOT NULL,
--     Username VARCHAR(15) NOT NULL,
--     [Password] VARCHAR(12) NOT NULL,
--     IsDeleted bit DEFAULT 0,
--     ADD RoleId INT REFERENCES Roles(Id)
-- )

-- CREATE TABLE Products
-- (
--     Id INT IDENTITY PRIMARY KEY,
--     Name VARCHAR(35) NOT NULL,
--     Price DECIMAL (10,2) DEFAULT 0,
--     IsDeleted bit DEFAULT 0
-- )


-- CREATE TABLE Baskets
-- (
--     Id INT IDENTITY PRIMARY KEY,
--     UserId INT REFERENCES Users(Id),
--     ProductId INT REFERENCES Products(Id)
-- )

-- CREATE TABLE Historys
-- (
--     Id INT IDENTITY PRIMARY KEY,
--     Username VARCHAR(15) NOT NULL,
--     Productname VARCHAR(35) NOT NULL,
--     Price DECIMAL (10,2) DEFAULT 0
-- )


-- CREATE TABLE Roles
-- (
--     Id INT IDENTITY PRIMARY KEY,
--     [Description] VARCHAR(12) NOT NULL
-- )


-- CREATE TRIGGER SoftDelete
-- ON Products
-- INSTEAD OF DELETE
-- AS
-- BEGIN
-- UPDATE Products
-- SET IsDeleted = 1
-- WHERE Id IN (SELECT Id FROM deleted)
-- END


-- CREATE TRIGGER SoftDeleteUser
-- ON Users
-- INSTEAD OF DELETE
-- AS
-- BEGIN
-- UPDATE Users
-- SET IsDeleted = 1
-- WHERE Id IN (SELECT Id FROM deleted)
-- END

