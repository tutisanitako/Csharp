create database Wordle
go
use Wordle

-- Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Words Table (All valid 5-letter words)
CREATE TABLE Words (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Word NVARCHAR(5) NOT NULL UNIQUE,
    IsSelectable BIT NOT NULL DEFAULT 1 -- True = can be selected as correct answer
);

-- Games Table
CREATE TABLE Games (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    WordId INT NOT NULL, -- FK to Words table
    AttemptsUsed INT NOT NULL,
    Score INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (WordId) REFERENCES Words(Id)
);

-- GameAttempts Table
CREATE TABLE GameAttempts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    GameId INT NOT NULL,
    AttemptNumber INT NOT NULL,
    GuessedWord NVARCHAR(5) NOT NULL,
    Result NVARCHAR(5) NOT NULL, -- e.g., "GYGYY" = feedback for the guessed word
    FOREIGN KEY (GameId) REFERENCES Games(Id)
);

-- UserStatistics Table
CREATE TABLE UserStatistics (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL UNIQUE,
    GamesPlayed INT NOT NULL DEFAULT 0,
    Wins INT NOT NULL DEFAULT 0,
    MaxStreak INT NOT NULL DEFAULT 0,
    CurrentStreak INT NOT NULL DEFAULT 0,
    WinningPercentage AS (CAST(Wins AS FLOAT) / NULLIF(GamesPlayed, 0) * 100),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);