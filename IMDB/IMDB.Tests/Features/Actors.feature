Feature: Actors

A short summary of the feature


Scenario Outline: Get all actors
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | status_code | response_data     |
		| /api/actors | 200         | Actor/GetAll.json |

Scenario Outline: Get actor by Id
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data             |
		| /api/actors/1  | 200         | Actor/ValidGetById.json   |
		| /api/actors/50 | 404         | Actor/InvalidGetById.json |

Scenario Outline: Add an actor
	Given I am a Client
	When I send a POST request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route       | request_data           | status_code | response_data          |
		| /api/actors | Actor/ValidNew.json    | 201         | Actor/ValidNew.json    |
		| /api/actors | Actor/InvalidNew1.json | 400         | Actor/InvalidNew1.json |
		| /api/actors | Actor/InvalidNew2.json | 400         | Actor/InvalidNew2.json |
		| /api/actors | Actor/InvalidNew3.json | 400         | Actor/InvalidNew3.json |
		| /api/actors | Actor/InvalidNew4.json | 400         | Actor/InvalidNew4.json |

Scenario Outline: Update actor details
	Given I am a Client
	When I send a PUT request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | request_data              | status_code | response_data             |
		| /api/actors/1  | Actor/ValidUpdate.json    | 200         | Actor/ValidUpdate.json    |
		| /api/actors/50 | Actor/InvalidUpdate1.json | 404         | Actor/InvalidUpdate1.json |
		| /api/actors/1  | Actor/InvalidUpdate2.json | 400         | Actor/InvalidUpdate2.json |
		| /api/actors/1  | Actor/InvalidUpdate3.json | 400         | Actor/InvalidUpdate3.json |
		| /api/actors/1  | Actor/InvalidUpdate4.json | 400         | Actor/InvalidUpdate4.json |
		| /api/actors/1  | Actor/InvalidUpdate5.json | 400         | Actor/InvalidUpdate5.json |

Scenario Outline: Delete an actor
	Given I am a Client
	When I send a DELETE request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data            |
		| /api/actors/1  | 200         | Actor/ValidDelete.json   |
		| /api/actors/50 | 404         | Actor/InvalidDelete.json |


