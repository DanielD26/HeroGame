USE HeroGame;

DROP TABLE IF EXISTS HERO

CREATE TABLE HERO (
    heroID  INT,
    Name    NVARCHAR(100),
    minDice INT,
    maxDice INT,
    Uses    INT
    PRIMARY KEY (heroID)
);

DROP TABLE IF EXISTS VILLAIN

CREATE TABLE VILLAIN (
    villainID INT,
    Name      NVARCHAR(100),
    PRIMARY KEY (villainID)
);

DROP TABLE IF EXISTS GAME

CREATE TABLE GAME (
    roundNum INT,
    PRIMARY KEY (roundNum)
);

DROP TABLE IF EXISTS [ACTION]

CREATE TABLE [ACTION](
    heroID    INT,
    villainID INT,
    roundNum  INT,
    turnNum   INT,
    Attack    INT,
    PRIMARY KEY (heroID, villainID, roundNum, turnNum, Attack),
    FOREIGN KEY (heroID) REFERENCES HERO,
    FOREIGN KEY (villainID) REFERENCES VILLAIN,
    FOREIGN KEY (roundNum) REFERENCES GAME
);


INSERT INTO HERO (heroID, Name, minDice, maxDice, Uses) VALUES
(1, 'Captain Swinburne', 0, 6, 2),
(2, 'Ms Hawthorn', 0, 8, 2),
(3, 'Rick', 0, 10, 2);

INSERT INTO VILLAIN (villainID, Name) VALUES
(1, 'Dr Evil'),
(2, 'Facebook'),
(3, 'Mr Bad')

SELECT * FROM VILLAIN
SELECT * FROM HERO

GO

------------------------------------------- PROCEDURES -------------------------------------------


------------------------------------------- ADD_HERO ---------------------------------------------
IF OBJECT_ID('ADD_HERO') IS NOT NULL
DROP PROCEDURE ADD_HERO
GO

CREATE PROCEDURE ADD_HERO @pHEROID INT, @pNAME NVARCHAR(100), @pMINDICE INT, @pMAXDICE INT, @pUSES INT AS
BEGIN
    BEGIN TRY
        INSERT INTO HERO(heroID, [Name], minDice, maxDice, Uses)
        VALUES (@pHEROID, @pNAME, @pMINDICE, @pMAXDICE, @pUSES);

    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 2627
            THROW 50010, 'Duplicate Hero ID', 1
    END CATCH
END

GO

------------------------------------------ ADD_VILLAIN -------------------------------------------
IF OBJECT_ID('ADD_VILLAIN') IS NOT NULL
DROP PROCEDURE ADD_VILLAIN
GO

CREATE PROCEDURE ADD_VILLAIN @pVILLAINID INT, @pNAME NVARCHAR(100) AS
BEGIN
    BEGIN TRY
        INSERT INTO VILLAIN(villainID, [Name])
        VALUES(@pVILLAINID, @pNAME);
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 2627
            THROW 50020, 'Duplicate Villain ID', 1
    END CATCH
END

GO

----------------------------------------- UPDATE_HERO -------------------------------------------
IF OBJECT_ID('UPDATE_HERO') IS NOT NULL
DROP PROCEDURE UPDATE_HERO
GO

CREATE PROCEDURE UPDATE_HERO @pHEROID INT, @pNAME NVARCHAR(100), @pMINDICE INT, @pMAXDICE INT, @pUSES INT AS
BEGIN
    BEGIN TRY
        UPDATE HERO
        SET [Name] = @pNAME, minDice = @pminDICE, maxDice = @pMAXDICE, Uses = @pUSES
        WHERE heroID = @pHEROID;

        IF @@ROWCOUNT = 0
            THROW 50030, 'Hero ID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50030
            THROW
    END CATCH
END

GO

----------------------------------------- UPDATE_VILLAIN -------------------------------------------
IF OBJECT_ID('UPDATE_VILLAIN') IS NOT NULL
DROP PROCEDURE UPDATE_VILLAIN
GO

CREATE PROCEDURE UPDATE_VILLAIN @pVILLAINID INT, @pNAME NVARCHAR(100) AS
BEGIN
    BEGIN TRY
        UPDATE VILLAIN
        SET [Name] = @pNAME
        WHERE villainID = @pVILLAINID;

        IF @@ROWCOUNT = 0
            THROW 50040, 'Villain ID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50040
            THROW
    END CATCH
END

GO

----------------------------------------- DELETE_HERO -------------------------------------------
IF OBJECT_ID('DELETE_HERO') IS NOT NULL
DROP PROCEDURE DELETE_HERO
GO

CREATE PROCEDURE DELETE_HERO @pHEROID INT AS
BEGIN
    BEGIN TRY
        DELETE FROM HERO
        WHERE heroID = @pHEROID;

        IF @@ROWCOUNT = 0
            THROW 50050, 'Hero ID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50050
            THROW
    END CATCH
END

GO

----------------------------------------- DELETE_VILLAIN -------------------------------------------
IF OBJECT_ID('DELETE_VILLAIN') IS NOT NULL
DROP PROCEDURE DELETE_VILLAIN
GO

CREATE PROCEDURE DELETE_VILLAIN @pVILLAINID INT AS
BEGIN
    BEGIN TRY
        DELETE FROM VILLAIN
        WHERE villainID = @pVILLAINID;

        IF @@ROWCOUNT = 0
            THROW 50060, 'Villain ID not found', 1
    END TRY

    BEGIN CATCH
        IF ERROR_NUMBER() = 50060
            THROW
    END CATCH
END

GO
