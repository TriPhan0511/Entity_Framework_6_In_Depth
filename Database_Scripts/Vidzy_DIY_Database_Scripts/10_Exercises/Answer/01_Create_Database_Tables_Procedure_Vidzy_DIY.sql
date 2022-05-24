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

---- 5. Create a stored procedure
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
---- NEW

---- Create a stored procedure to get all videos
CREATE OR ALTER PROCEDURE spGetVideos
AS
	SELECT vi.Id, vi.Name, vi.RealeaseDate, ge.Name Genre
	FROM Videos vi INNER JOIN  VideoGenres vg ON vg.VideoId = vi.Id
		INNER JOIN Genres ge ON ge.Id = vg.GenreId
GO

---- Create a stored procedure to delete all videos
CREATE OR ALTER PROCEDURE spDeleteAllVideos
AS
	DELETE FROM Videos
	DBCC CHECKIDENT ('Videos', RESEED, 0) -- Reset the "Id" column of the "Videos" table
GO

---- Create a stored procedure to delete a video based on its id.
CREATE OR ALTER PROCEDURE spDeleteAVideo
(
	@Id INT
)
AS
	DELETE FROM Videos 
	WHERE Id = @Id
GO

---- Create a stored procedure to update a video based on its id.
CREATE OR ALTER PROCEDURE spUpdateAVideoNameBasedOnId
(
	@Id INT,
	@Name VARCHAR(255)
)
AS
	UPDATE Videos
	SET Name = @Name
	WHERE Id = @Id
GO

---- Create a stored procedure to update a video based on its id.
CREATE OR ALTER PROCEDURE spUpdateAVideoBasedOnId
(
	@Id INT,
	@Name VARCHAR(255),
	@ReleaseDate DATETIME,
	@Genre VARCHAR(255)
)
AS
	DECLARE @GenreId TINYINT
	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

	IF @GenreId IS NOT NULL
	BEGIN
		UPDATE Videos
		SET Name = @Name,
			RealeaseDate = @ReleaseDate
		WHERE Id = @Id

		UPDATE VideoGenres
		SET @GenreId = @GenreId
		WHERE VideoId = @Id
	END
GO

