CREATE TABLE Persons (
    IdNum varchar(9) NOT NULL,
    FullName varchar(20) NOT NULL,
    BirthDate date,
    PRIMARY KEY (IdNum)
);
GO;

CREATE PROCEDURE GetAllPeople
AS
SELECT * FROM Persons
GO;

CREATE PROCEDURE GetSpecificPersonById
@IdNum nvarchar(9)
AS
SELECT * FROM Persons
WHERE @IdNum = IdNum 
GO;

CREATE PROCEDURE AddPerson
@IdNum varchar(9),
@FullName varchar(20),
@BirthDate date,
AS
IF NOT EXISTS
        (
        SELECT * FROM Persons
	WHERE @IdNum = IdNum 
        )
        BEGIN
           INSERT INTO Persons(IdNum, FullName , Country)
VALUES (@IdNum, @FullName, @BirthDate);
        END
    ELSE
        print 'person exists'
GO;