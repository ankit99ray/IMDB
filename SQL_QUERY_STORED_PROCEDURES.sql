
--insert movie
CREATE PROCEDURE spInsertMovie
@Name VARCHAR(MAX),
@ReleaseYear INT,
@Plot VARCHAR(MAX),
@PosterLink VARCHAR(MAX),
@ActorIds VARCHAR(MAX),
@GenreIds VARCHAR(MAX),
@ProducerId INT
AS
BEGIN
	INSERT INTO Foundation.Movies (Name, YearOfRelease, Plot, PosterLink, ProducerId) 
	VALUES
		(@Name, @ReleaseYear, @Plot, @PosterLink, @ProducerId);

	DECLARE @MovieId INT
	SET @MovieId = SCOPE_IDENTITY()
	
	INSERT INTO Foundation.Actors_Movies (MovieId, ActorId)
		SELECT @MovieId, CAST(VALUE AS INT) FROM string_split(@ActorIds, ',');

	INSERT INTO Foundation.Genres_Movies (MovieId, GenreId)
		SELECT @MovieId, CAST(VALUE AS INT) FROM string_split(@GenreIds, ',');
END

--update movie
CREATE PROCEDURE spUpdateMovie
@Id INT,
@Name VARCHAR(MAX),
@ReleaseYear INT,
@Plot VARCHAR(MAX),
@PosterLink VARCHAR(MAX),
@ActorIds VARCHAR(MAX),
@GenreIds VARCHAR(MAX),
@ProducerId INT
AS
BEGIN
	UPDATE Foundation.Movies 
	SET
		Name = @Name, YearOfRelease = @ReleaseYear, Plot = @Plot, PosterLink = @PosterLink, ProducerId = @ProducerId
	WHERE Id = @Id;

	DELETE FROM Foundation.Actors_Movies WHERE MovieId = @Id;

	INSERT INTO Foundation.Actors_Movies (MovieId, ActorId)
		SELECT @Id, CAST(VALUE AS INT) FROM string_split(@ActorIds, ',');

	DELETE FROM Foundation.Genres_Movies WHERE MovieId = @Id;

	INSERT INTO Foundation.Genres_Movies (MovieId, GenreId)
		SELECT @Id, CAST(VALUE AS INT) FROM string_split(@GenreIds, ',');

END


--delete movie
CREATE PROCEDURE spDeleteMovieById
@MovieId INT
AS
BEGIN
	DELETE FROM Foundation.Actors_Movies WHERE MovieId = @MovieId
	DELETE FROM Foundation.Movies WHERE Id = @MovieId
END


--delete producer
CREATE PROCEDURE spDeleteProducerById
@ProducerId INT
AS
BEGIN
	DELETE FROM Foundation.Actors_Movies WHERE MovieId = (SELECT Id FROM Foundation.Movies WHERE ProducerId = @ProducerId)
	DELETE FROM Foundation.Movies WHERE ProducerId = @ProducerId
	DELETE FROM Foundation.Producers WHERE Id = @ProducerId
END

--delete actor
CREATE PROCEDURE spDeleteActorById
@ActorId INT
As
BEGIN
	DELETE FROM Foundation.Actors_Movies WHERE ActorId = @ActorId
	DELETE FROM Foundation.Actors WHERE Id = @ActorId
END


--delete genre 
CREATE PROCEDURE spDeleteGenreById
@GenreId INT
As
BEGIN
	DELETE FROM Foundation.Genres_Movies WHERE GenreId = @GenreId
	DELETE FROM Foundation.Genres WHERE Id = @GenreId
END


--EXECUTE spInsertMovie 'Rockstar' , 2008, 'alcoholic and heartbroken singer becomes rockstar', 'url1', '14,2', '2', 6;

--select * from Foundation.Actors