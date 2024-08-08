Feature: Reviews

A short summary of the feature

Scenario Outline: Get all reviews
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route                   | status_code | response_data             |
		| /api/movies/1/reviews   | 200         | Review/ValidGetAll.json   |
		| /api/movies/500/reviews | 404         | Review/InvalidGetAll.json |

Scenario Outline: Get review by Id
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route                     | status_code | response_data               |
		| /api/movies/1/reviews/1   | 200         | Review/ValidGetById.json    |
		| /api/movies/1/reviews/100 | 404         | Review/InvalidGetById1.json |
		| /api/movies/100/reviews/1 | 404         | Review/InvalidGetById2.json |

Scenario Outline: Add a review
	Given I am a Client
	When I send a POST request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route                   | request_data            | status_code | response_data           |
		| /api/movies/1/reviews   | Review/ValidNew.json    | 201         | Review/ValidNew.json    |
		| /api/movies/100/reviews | Review/InvalidNew1.json | 404         | Review/InvalidNew1.json |
		| /api/movies/1/reviews   | Review/InvalidNew2.json | 400         | Review/InvalidNew2.json |
		

Scenario Outline: Update review details
	Given I am a Client
	When I send a PUT request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route                     | request_data               | status_code | response_data              |
		| /api/movies/1/reviews/1   | Review/ValidUpdate.json    | 200         | Review/ValidUpdate.json    |
		| /api/movies/1/reviews/100 | Review/InvalidUpdate1.json | 404         | Review/InvalidUpdate1.json |
		| /api/movies/100/reviews/1 | Review/InvalidUpdate2.json | 404         | Review/InvalidUpdate2.json |
		| /api/movies/1/reviews/1   | Review/InvalidUpdate3.json | 400         | Review/InvalidUpdate3.json |
		

Scenario Outline: Delete a review
	Given I am a Client
	When I send a DELETE request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route                    | status_code | response_data              |
		| /api/movies/1/reviews/1  | 200         | Review/ValidDelete.json    |
		| /api/movies/1/reviews/50 | 404         | Review/InvalidDelete1.json  |
		| api/movies/100/reviews/1 | 404         | Review/InvalidDelete2.json |
