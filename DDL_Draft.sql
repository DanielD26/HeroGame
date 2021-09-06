CREATE TABLE HERO (
    HeroID  INT,
    Name    NVARCHAR(100),
    DiceMin INT,
    DiceMax INT,
    Uses    INT
    PRIMARY KEY (HeroID)
);

CREATE TABLE VILLAIN (
    VillainID INT,
    Name      NVARCHAR(100),
    HitPoints INT,
    PRIMARY KEY (VillainID)
);