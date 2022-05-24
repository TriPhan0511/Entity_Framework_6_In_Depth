---- NEW

---- Create a stored procedure to get all videos
--CREATE OR ALTER PROCEDURE spGetVideos
--AS
--	SELECT vi.Id, vi.Name, vi.RealeaseDate, ge.Name Genre
--	FROM Videos vi INNER JOIN  VideoGenres vg ON vg.VideoId = vi.Id
--		INNER JOIN Genres ge ON ge.Id = vg.GenreId
--GO

---- Create a stored procedure to delete all videos
--CREATE OR ALTER PROCEDURE spDeleteAllVideos
--AS
--	DELETE FROM Videos
--	DBCC CHECKIDENT ('Videos', RESEED, 0) -- Reset the "Id" column of the "Videos" table
--GO

---- Create a stored procedure to delete a video based on its id.
--CREATE OR ALTER PROCEDURE spDeleteAVideo
--(
--	@Id INT
--)
--AS
--	DELETE FROM Videos 
--	WHERE Id = @Id
--GO

---- Create a stored procedure to update a video based on its id.
--CREATE OR ALTER PROCEDURE spUpdateAVideoNameBasedOnId
--(
--	@Id INT,
--	@Name VARCHAR(255)
--)
--AS
--	UPDATE Videos
--	SET Name = @Name
--	WHERE Id = @Id
--GO

---- Create a stored procedure to update a video based on its id.
--CREATE OR ALTER PROCEDURE spUpdateAVideoBasedOnId
--(
--	@Id INT,
--	@Name VARCHAR(255),
--	@ReleaseDate DATETIME,
--	@Genre VARCHAR(255)
--)
--AS
--	DECLARE @GenreId TINYINT
--	SET @GenreId = (SELECT Id FROM Genres WHERE Name = @Genre)

--	IF @GenreId IS NOT NULL
--	BEGIN
--		UPDATE Videos
--		SET Name = @Name,
--			RealeaseDate = @ReleaseDate
--		WHERE Id = @Id

--		UPDATE VideoGenres
--		SET @GenreId = @GenreId
--		WHERE VideoId = @Id
--	END
--GO