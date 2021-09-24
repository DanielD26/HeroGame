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
CREATE PROCEDURE ADD_HERO @pHEROID INT, @pNAME NVARCHAR(100), @pMINDICE INT, @pMAXDICE INT, @pUSES INT AS
BEGIN
    BEGIN TRY
        INSERT INTO HERO(heroID, name, minDice, maxDice, Uses)
        VALUES (@pHEROID, @pNAME, @pMINDICE, @pMAXDICE, @pUSES);
    END TRY

    BEGIN CATCH

    END CATCH
END

GO

------------------------------------------- ADD_VILLAIN -------------------------------------------

CREATE PROCEDURE ADD_VILLAIN @pVILLAINID INT, @pNAME NVARCHAR(100) AS
BEGIN
    BEGIN TRY
        INSERT INTO VILLAIN(villainID, Name)
        VALUES(@pVILLAINID, @pNAME);
    END TRY

    BEGIN CATCH

    END CATCH
END

    