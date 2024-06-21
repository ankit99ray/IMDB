Feature: Producer

In my IMDB console , I want to add new Producers.

@addingProducer
Scenario Outline: Adding valid producer in the IMDB
	Given I have a producer with name "<Name>"
	And birth date of the producer is "<DateOfBirth>"
	When I add the producer to IMDB
	Then My producers in the IMDB should look like this "<OutputFileName>"
	And Output message should look something like "<OutputMessage>"
	Examples: 
		| Name     | DateOfBirth | OutputFileName          | OutputMessage |
		| John Doe | 01/01/2000  | ValidProducerInput.json |               |



Scenario Outline: Adding invalid producer in the IMDB
	Given I have a producer with name "<Name>"
	And birth date of the producer is "<DateOfBirth>"
	When I add the producer to IMDB
	Then My producers in the IMDB should look like this "<OutputFileName>"
	And Output message should look something like "<OutputMessage>"
	Examples: 
		| Name     | DateOfBirth | OutputFileName            | OutputMessage                                |
		| John Doe | 01/01/2045  | InvalidProducerInput.json | Birth date of producer cannot be in future   |
		| John Doe | 01/01/1700  | InvalidProducerInput.json | Producer birth year cannot be less than 1800 |
		|          | 01/01/2045  | InvalidProducerInput.json | Producer name cannot be null or empty        |
		
