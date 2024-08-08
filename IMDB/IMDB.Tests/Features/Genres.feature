Feature: Genres

A short summary of the feature

Scenario Outline: Get all genres
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | status_code | response_data     |
		| /api/genres | 200         | Genre/GetAll.json |

Scenario Outline: Get genre by Id
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data             |
		| /api/genres/1  | 200         | Genre/ValidGetById.json   |
		| /api/genres/50 | 404         | Genre/InvalidGetById.json |


Scenario Outline: Add a genre
	Given I am a Client
	When I send a POST request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | request_data           | status_code | response_data          |
		| /api/genres | Genre/ValidNew.json    | 201         | Genre/ValidNew.json    |
		| /api/genres | Genre/InvalidNew1.json | 400         | Genre/InvalidNew1.json |


Scenario Outline: Update genre details
	Given I am a Client
	When I send a PUT request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route           | request_data              | status_code | response_data             |
		| /api/genres/1   | Genre/ValidUpdate.json    | 200         | Genre/ValidUpdate.json    |
		| /api/genres/100 | Genre/InvalidUpdate1.json | 404         | Genre/InvalidUpdate1.json |
		| /api/genres/1   | Genre/InvalidUpdate2.json | 400         | Genre/InvalidUpdate2.json |
		

Scenario Outline: Delete a genre
	Given I am a Client
	When I send a DELETE request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data            |
		| /api/genres/1  | 200         | Genre/ValidDelete.json   |
		| /api/genres/50 | 404         | Genre/InvalidDelete.json |


