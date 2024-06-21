Feature: Actor

In my IMDB console , I want to add new actors.

@addingActor
Scenario Outline: Adding valid actor in the IMDB
	Given I have an actor named "<Name>"
	And birth date of the actor is "<DateOfBirth>"
	When I add the actor to IMDB
	Then My actors in the IMDB should look like this "<OutputFileName>"
	And Output message should look like "<OutputMessage>"
	Examples: 
		| Name     | DateOfBirth | OutputFileName       | OutputMessage |
		| John Doe | 01/01/2000  | ValidActorInput.json |               |



Scenario Outline: Adding invalid Actor in the IMDB
	Given I have an actor named "<Name>"
	And birth date of the actor is "<DateOfBirth>"
	When I add the actor to IMDB
	Then My actors in the IMDB should look like this "<OutputFileName>"
	And Output message should look like "<OutputMessage>"
	Examples: 
		| Name     | DateOfBirth | OutputFileName         | OutputMessage                             |
		| John Doe | 01/01/2045  | InvalidActorInput.json | Birth date of actor cannot be in future   |
		| John Doe | 01/01/1700  | InvalidActorInput.json | Actor birth year cannot be less than 1800 |
		|          | 01/01/2000  | InvalidActorInput.json | Actor name cannot be null or empty        |