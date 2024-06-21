Feature: Movie
	In my IMDB console, I want to add, list and delete movies.

@addingMovie
Scenario Outline: Add a movie to my IMDB
	Given I have a movie named "<Name>"
	And The release year of the movie is "<Year>"
	And The plot of the movie is "<Plot>"
	And the actors in the movie are "<ActorIds>"
	And The Producer of the movie is "<ProducerId>"
	When I add the movie to IMDb
	Then My movies in the IMDB console should look like this "<OutputFileName>"
	And Output message should be "<OutputMessage>"
	Examples: 
		| Name   | Year | Plot               | ActorIds | ProducerId | OutputFileName       | OutputMessage |
		| Avatar | 2008 | Aliens in a planet | 3,4      | 2          | ValidMovieInput.json |               |



Scenario Outline: Add an invalid movie to IMDB
	Given I have a movie named "<Name>"
	And The release year of the movie is "<Year>"
	And The plot of the movie is "<Plot>"
	And the actors in the movie are "<ActorIds>"
	And The Producer of the movie is "<ProducerId>"
	When I add the movie to IMDb
	Then My movies in the IMDB console should look like this "<OutputFileName>"
	And Output message should be "<OutputMessage>"
	Examples: 
		| Name   | Year | Plot               | ActorIds | ProducerId | OutputFileName         | OutputMessage                        |
		| Avatar | 2045 | Aliens in a Planet | 3,4      | 2          | InvalidMovieInput.json | Invalid year of release of the movie |
		| Avatar | 2008 | Aliens in a Planet | 3,4,21   | 2          | InvalidMovieInput.json | Actor does not exist                 |
		| Avatar | 2008 | Aliens in a Planet | 3,4      | 21         | InvalidMovieInput.json | Producer does not exist              |
		| Avatar | 2008 |                    | 3,4      | 2          | InvalidMovieInput.json | Plot cannot be null or empty         |
		|        | 2008 | Aliens in a Planet | 3,4      | 2          | InvalidMovieInput.json | Movie name cannot be null or empty   |



@listMovies
Scenario Outline: List all movies from IMDB console
	When I try to list all movies from the IMDB
	Then My movies list should look like this "<OutputFileName>"
	Examples: 
		| OutputFileName    |
		| AllMovieList.json |


@deletingMovie
Scenario Outline: Delete a valid movie from IMDB
	Given I have an Id of a movie "<MovieId>"
	When I delete this movie from IMDB
	Then My movies in the IMDB console should look like this "<OutputFileName>"
	And Output message should be "<OutputMessage>"
	Examples: 
		| MovieId | OutputFileName              | OutputMessage |
		| 1       | ValidMoviesDeletedList.json |               |




Scenario Outline: Delete an invalid movie from IMDB
	Given I have an Id of a movie "<MovieId>"
	When I delete this movie from IMDB
	Then My movies in the IMDB console should look like this "<OutputFileName>"
	And Output message should be "<OutputMessage>"
	Examples: 
		| MovieId | OutputFileName                | OutputMessage        |
		| 15      | InvalidMoviesDeletedList.json | Movie does not exist |