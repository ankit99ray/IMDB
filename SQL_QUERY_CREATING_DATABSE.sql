CREATE DATABASE IMDB_FINAL_RESTAPI;
USE IMDB_FINAL_RESTAPI;

CREATE SCHEMA Foundation;


CREATE TABLE Foundation.Producers(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Gender VARCHAR(100) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Bio VARCHAR(500),
);

CREATE TABLE Foundation.Actors(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(100) NOT NULL,
	Gender VARCHAR(100) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Bio VARCHAR(500),
);

CREATE TABLE Foundation.Movies(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(200) NOT NULL,
	YearOfRelease INT NOT NULL,
	Plot VARCHAR(MAX),
	PosterLink VARCHAR(MAX),
	ProducerId INT NOT NULL CONSTRAINT FK_Movies_ProducerId FOREIGN KEY (ProducerId) REFERENCES Foundation.Producers (Id),
);

CREATE TABLE Foundation.Genres(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name VARCHAR(MAX) NOT NULL
);

CREATE TABLE Foundation.Reviews(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	ReviewMessage VARCHAR(MAX),
	MovieId INT NOT NULL CONSTRAINT FK_Reviews_MovieId FOREIGN KEY (MovieId) REFERENCES Foundation.Movies (Id)
);

CREATE TABLE Foundation.Actors_Movies(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MovieId INT NOT NULL CONSTRAINT FK_Actors_Movies_MovieId FOREIGN KEY (MovieId) REFERENCES Foundation.Movies(Id),
	ActorId INT NOT NULL CONSTRAINT FK_Actors_Movies_ActorId FOREIGN KEY (ActorId) REFERENCES Foundation.Actors(Id),
);

CREATE TABLE Foundation.Genres_Movies(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	MovieId INT NOT NULL CONSTRAINT FK_Genres_Movies_MovieId FOREIGN KEY (MovieId) REFERENCES Foundation.Movies(Id),
	GenreId INT NOT NULL CONSTRAINT FK_Genres_Movies_GenreId FOREIGN KEY (GenreId) REFERENCES Foundation.Genres(Id),
);


--inserting values

INSERT INTO Foundation.Producers (Name, Gender, DateOfBirth, Bio)
VALUES
    ('Steven Spielberg', 'Male', '1946-12-18', 'One of the most popular directors and producers in film history.'),
    ('Karan Johar', 'Male', '1972-05-25', 'Renowned Indian filmmaker and producer.'),
    ('Kathleen Kennedy', 'Female', '1953-06-05', 'Co-founder of Amblin Entertainment and president of Lucasfilm.'),
    ('Ekta Kapoor', 'Female', '1975-06-07', 'Prolific producer of Indian television serials and films.'),
    ('Christopher Nolan', 'Male', '1970-07-30', 'Famous for directing and producing mind-bending movies.'),
    ('Farhan Akhtar', 'Male', '1974-01-09', 'Indian film director, producer, and actor.'),
    ('Ava DuVernay', 'Female', '1972-08-24', 'American filmmaker and producer known for her works on social issues.'),
    ('Rohit Shetty', 'Male', '1973-03-14', 'Known for directing and producing action-packed Bollywood films.'),
    ('Shonda Rhimes', 'Female', '1970-01-13', 'Creator and producer of several successful TV series.'),
    ('Aditya Chopra', 'Male', '1971-05-21', 'Indian filmmaker and producer, chairman of Yash Raj Films.'),
    ('Gauri Khan', 'Female', '1970-10-08', 'Indian film producer and interior designer.'),
    ('James Cameron', 'Male', '1954-08-16', 'Director and producer known for blockbuster films like Titanic and Avatar.');

INSERT INTO Foundation.Actors (Name, Gender, DateOfBirth, Bio)
VALUES
    ('Robert Downey Jr.', 'Male', '1965-04-04', 'American actor known for his role as Iron Man.'),
    ('Shah Rukh Khan', 'Male', '1965-11-02', 'Indian actor known as the King of Bollywood.'),
    ('Scarlett Johansson', 'Female', '1984-11-22', 'American actress and singer, known for her role as Black Widow.'),
    ('Priyanka Chopra', 'Female', '1982-07-18', 'Indian actress, singer, and film producer.'),
    ('Leonardo DiCaprio', 'Male', '1974-11-11', 'American actor and film producer.'),
    ('Amitabh Bachchan', 'Male', '1942-10-11', 'Legendary Indian actor known for his roles in Hindi cinema.'),
    ('Angelina Jolie', 'Female', '1975-06-04', 'American actress, filmmaker, and humanitarian.'),
    ('Deepika Padukone', 'Female', '1986-01-05', 'Indian actress and producer.'),
    ('Brad Pitt', 'Male', '1963-12-18', 'American actor and film producer.'),
    ('Hrithik Roshan', 'Male', '1974-01-10', 'Indian actor known for his dancing skills and versatile roles.'),
    ('Emma Watson', 'Female', '1990-04-15', 'British actress and activist, known for her role as Hermione Granger.'),
    ('Aishwarya Rai', 'Female', '1973-11-01', 'Indian actress and the winner of the Miss World 1994 pageant.'),
    ('Tom Hanks', 'Male', '1956-07-09', 'American actor and filmmaker, known for his diverse roles.'),
    ('Ranbir Kapoor', 'Male', '1982-09-28', 'Indian actor known for his roles in Bollywood.'),
    ('Meryl Streep', 'Female', '1949-06-22', 'American actress often described as the best actress of her generation.');

INSERT INTO Foundation.Movies (Name, YearOfRelease, Plot, PosterLink, ProducerId)
VALUES
    ('Kabhi Khushi Kabhie Gham', 2001, 'A story of a wealthy family facing challenges.', 'https://example.com/k3g.jpg', 2),
    ('My Name is Khan', 2010, 'A man with Aspergers syndrome embarks on a journey to meet the President of the United States.', 'https://example.com/mnik.jpg', 2),
    ('Ae Dil Hai Mushkil', 2016, 'A story about unrequited love and friendship.', 'https://example.com/adhm.jpg', 2),
    ('Inception', 2010, 'A thief who steals corporate secrets through dream-sharing technology.', 'https://example.com/inception.jpg', 5),
    ('The Dark Knight', 2008, 'Batman sets out to dismantle the remaining criminal organizations that plague Gotham.', 'https://example.com/darkknight.jpg', 5),
    ('Interstellar', 2014, 'A team of explorers travel through a wormhole in space in an attempt to ensure humanitys survival.', 'https://example.com/interstellar.jpg', 5),
    ('Titanic', 1997, 'A love story that unfolds on the ill-fated R.M.S. Titanic.', 'https://example.com/titanic.jpg', 12),
    ('Avatar', 2009, 'A paraplegic Marine dispatched to the moon Pandora on a unique mission.', 'https://example.com/avatar.jpg', 12),
    ('Terminator 2: Judgment Day', 1991, 'A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her teenage son.', 'https://example.com/t2.jpg', 12),
    ('The Abyss', 1989, 'A civilian diving team is enlisted to search for a lost nuclear submarine and faces danger from an unknown life form.', 'https://example.com/abyss.jpg', 12),
    ('Once Upon a Time in Mumbaai', 2010, 'A smuggler rises to power in 1970s Mumbai, a younger gangster seeks to overthrow him.', 'https://example.com/ouatim.jpg', 4),
    ('Golmaal: Fun Unlimited', 2006, 'Four runaway crooks take shelter in a bungalow which is owned by a blind couple.', 'https://example.com/golmaal.jpg', 8),
    ('Chennai Express', 2013, 'A mans journey from Mumbai to Rameshwaram, and what happens along the way.', 'https://example.com/chennai_express.jpg', 8);


--select * from Foundation.Actors

INSERT INTO Foundation.Genres (Name)
VALUES
	('Horror'),('Romantic'),('Comedy'),('Thriller'),('Psychological'),('Dark'),('Sci-fi'),('Biography'),('Suspense');

INSERT INTO Foundation.Reviews (ReviewMessage, MovieId)
VALUES
	('Good', 1),
	('Excellent', 2),
	('Average', 3),
	('Bad', 4),
	('Above average', 5),
	('Excellent', 6),
	('Good', 7),
	('Good', 8),
	('Bad', 9),
	('Excellent', 10),
	('Bad', 11),
	('Average', 12),
	('Above average', 13);


INSERT INTO Foundation.Actors_Movies (MovieId, ActorId)
VALUES
	(1,2), (1,6), (1,10), (2,2), (2,4), (3, 14), (3, 2), (4, 5), (4, 15), (5, 5), (5, 15), (6,1), (6,3),
	(7, 5), (7, 8), (8, 1), (9,13), (9, 7), (10, 9), (10, 12), (11, 4), (11, 12), (12, 14), (12, 2), (13, 10), (13, 11), (13, 1);


--select * from Foundation.Genres;
--select * from Foundation.Movies;

INSERT INTO Foundation.Genres_Movies (MovieId, GenreId) 
VALUES
	(1,2),(1,3),(2,2),(3,2),(3,3),(4,7),(5,6),(6,7),(7,2),(8,7),(9,7),(10,7),(11,4),(12,3),(13,3),(13,2),(11,9);

	--select * from Foundation.Genres_Movies