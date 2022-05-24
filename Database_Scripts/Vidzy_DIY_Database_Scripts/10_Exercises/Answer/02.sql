USE Vidzy_DIY
GO

SELECT Id, Name FROM Genres

SELECT Id, Name, RealeaseDate FROM Videos

SELECT VideoId, GenreId FROM VideoGenres

--EXEC spGetVideos

--EXEC spAddVideo 'Testing testing 3', '11-05-1984', 'Comedy'

--EXEC spDeleteAVideo 1

--EXEC spUpdateAVideoBasedOnId 1, 'A NEW romance lover 2'

---- After editing the "spAddVideo" stored procedure
EXEC spAddVideo  'This is a new action film 2', '05-24-2022', 'action'
EXEC spAddVideo  'This is a new romantic film', '05-24-2022', 'romance'

SELECT * FROM Videos


