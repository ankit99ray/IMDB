Feature: Movies

A short summary of the feature

Scenario Outline: Get all movies
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | status_code | response_data     |
		| /api/movies | 200         | Movie/GetAll.json |

Scenario Outline: Get movie by Id
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data             |
		| /api/movies/1  | 200         | Movie/ValidGetById.json   |
		| /api/movies/100 | 404         | Movie/InvalidGetById.json |

Scenario Outline: Add a movie
	Given I am a Client
	When I send a POST request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | request_data           | status_code | response_data          |
		| /api/movies | Movie/ValidNew.json    | 201         | Movie/ValidNew.json    |
		| /api/movies | Movie/InvalidNew1.json | 400         | Movie/InvalidNew1.json |
		| /api/movies | Movie/InvalidNew2.json | 400         | Movie/InvalidNew2.json |
		| /api/movies | Movie/InvalidNew3.json | 404         | Movie/InvalidNew3.json |
		| /api/movies | Movie/InvalidNew4.json | 404         | Movie/InvalidNew4.json |
		| /api/movies | Movie/InvalidNew5.json | 404         | Movie/InvalidNew5.json |

Scenario Outline: Update movie details
	Given I am a Client
	When I send a PUT request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route           | request_data              | status_code | response_data             |
		| /api/movies/1   | Movie/ValidUpdate.json    | 200         | Movie/ValidUpdate.json    |
		| /api/movies/100 | Movie/InvalidUpdate1.json | 404         | Movie/InvalidUpdate1.json |
		| /api/movies/1   | Movie/InvalidUpdate2.json | 400         | Movie/InvalidUpdate2.json |
		| /api/movies/1   | Movie/InvalidUpdate3.json | 400         | Movie/InvalidUpdate3.json |
		| /api/movies/1   | Movie/InvalidUpdate4.json | 404         | Movie/InvalidUpdate4.json |
		| /api/movies/1   | Movie/InvalidUpdate5.json | 404         | Movie/InvalidUpdate5.json |
		| /api/movies/1   | Movie/InvalidUpdate6.json | 404         | Movie/InvalidUpdate6.json |

Scenario Outline: Delete a movie
	Given I am a Client
	When I send a DELETE request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data            |
		| /api/movies/1  | 200         | Movie/ValidDelete.json   |
		| /api/movies/50 | 404         | Movie/InvalidDelete.json |



