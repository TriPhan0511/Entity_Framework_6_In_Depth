---- 1st iteration
USE master
GO

DROP DATABASE IF EXISTS Vidzy_DIY
GO

CREATE DATABASE Vidzy_DIY
GO

USE Vidzy_DIY
GO

---- 1. Create Genres table
CREATE TABLE dbo.Genres
(
	Id TINYINT NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	CONSTRAINT PK_Genres PRIMARY KEY(Id)
)
GO

---- 2. Create VideoGenres table
CREATE TABLE dbo.VideoGenres
(
	VideoId INT NOT NULL,
	GenreId TINYINT NOT NULL,
	CONSTRAINT PK_VideoGenres PRIMARY KEY (VideoId, GenreId)
)
GO

---- 3. Create Videos table
CREATE TABLE dbo.Videos
(
	Id INT IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(255) NOT NULL,
	RealeaseDate DATETIME NOT NULL,
	CONSTRAINT PK_Videos PRIMARY KEY (Id)
)
GO

---- 4. Alter VideoGenres table to add two foreign keys
ALTER TABLE dbo.VideoGenres 
	ADD CONSTRAINT FK_VideoGenres_Genres FOREIGN KEY (GenreId)
	REFERENCES dbo.Genres
	ON DELETE CASCADE
GO

ALTER TABLE dbo.VideoGenres
	ADD CONSTRAINT FK_VideoGenres_Videos FOREIGN KEY (VideoId)
	REFERENCES dbo.Videos
	ON DELETE CASCADE
GO

---- 5.1 Create a stored procedure 
CREATE OR ALTER PROCEDURE [dbo].[spAddVideo]
(
	@Name VARCHAR(255),
	@ReleaseDate DATETIME,
	@Genre VARCHAR(255)
)
AS
	DECLARE @GenreId TINYINT
	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

	IF @GenreId IS NOT NULL
	BEGIN
		INSERT INTO Videos(Name, RealeaseDate)
		VALUES (@Name, @ReleaseDate)

		DECLARE @VideoId INT
		SET @VideoId = SCOPE_IDENTITY()

		INSERT INTO VideoGenres(VideoId, GenreId)
		VALUES (@VideoId, @GenreId)
	END
GO

---- 6. Insert some data into the Genres table
INSERT INTO Genres (Id, Name)
VALUES 
	(1, 'Comedy'),
	(2, 'Action'),
	(3, 'Horror'),
	(4, 'Thriller'),
	(5, 'Family'),
	(6, 'Romance')
GO

-------------------------------------------------------------------------------------------------
------ 2nd iteration

---- Add a new NULLABLE TINYINT column to the "Videos" table called GenreId.
ALTER TABLE dbo.Videos
	ADD GenreId TINYINT NULL

---- Edit the records in the table and assign them a genre
UPDATE dbo.Videos SET GenreId = 1 WHERE Id = 1
UPDATE dbo.Videos SET GenreId = 2 WHERE Id = 2
UPDATE dbo.Videos SET GenreId = 3 WHERE Id = 3
UPDATE dbo.Videos SET GenreId = 4 WHERE Id = 4
UPDATE dbo.Videos SET GenreId = 5 WHERE Id = 5
UPDATE dbo.Videos SET GenreId = 6 WHERE Id = 6

---- Remove the NULLABLE attribute from the "GenreId" column in the "Videos" table
ALTER TABLE Videos
	ALTER COLUMN GenreId TINYINT NOT NULL

---- Create a relationship between "Genres" and "Videos" tables
ALTER TABLE Videos
	ADD CONSTRAINT FK_Videos_Genres FOREIGN KEY (GenreId)
		REFERENCES Genres (Id)

---- Drop the "VideosGenres" table
DROP TABLE VideoGenres
GO

---- Modify the procedure after deleting the "VideoGenres" table
CREATE OR ALTER PROCEDURE [dbo].[spAddVideo]
(
	@Name VARCHAR(255),
	@ReleaseDate DATETIME,
	@Genre VARCHAR(255)
)
AS
	DECLARE @GenreId TINYINT
	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

	IF @GenreId IS NOT NULL
	BEGIN
		INSERT INTO Videos(Name, RealeaseDate, GenreId)
		VALUES (@Name, @ReleaseDate, @GenreId)
	END
GO
---------------------------------------------------------------------------------------------------
------ 3rd iteration

---- Add a new column (named Classification) with a default value (1) to the "Videos" table
ALTER TABLE dbo.Videos
	ADD [Classification] TINYINT NOT NULL
	CONSTRAINT Default_Classification DEFAULT 1
GO

---- Modify the procedure after adding the "Classification" column to the "Videos" table
CREATE OR ALTER PROCEDURE [dbo].[spAddVideo]
(
	@Name VARCHAR(255),
	@ReleaseDate DATETIME,
	@Genre VARCHAR(255),
	@Classification TINYINT
)
AS
	DECLARE @GenreId TINYINT
	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

	IF @GenreId IS NOT NULL
	BEGIN
		INSERT INTO Videos(Name, RealeaseDate, GenreId, [Classification])
		VALUES (@Name, @ReleaseDate, @GenreId, @Classification)
	END
GO



