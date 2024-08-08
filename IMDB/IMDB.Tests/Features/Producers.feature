Feature: Producers

A short summary of the feature

Scenario Outline: Get all producers
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | status_code | response_data        |
		| /api/producers | 200         | Producer/GetAll.json |

Scenario Outline: Get producer by Id
	Given I am a Client
	When I send a GET request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route             | status_code | response_data                |
		| /api/producers/1  | 200         | Producer/ValidGetById.json   |
		| /api/producers/50 | 404         | Producer/InvalidGetById.json |

Scenario Outline: Add a producer
	Given I am a Client
	When I send a POST request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route          | request_data              | status_code | response_data             |
		| /api/producers | Producer/ValidNew.json    | 201         | Producer/ValidNew.json    |
		| /api/producers | Producer/InvalidNew1.json | 400         | Producer/InvalidNew1.json |
		| /api/producers | Producer/InvalidNew2.json | 400         | Producer/InvalidNew2.json |
		| /api/producers | Producer/InvalidNew3.json | 400         | Producer/InvalidNew3.json |
		| /api/producers | Producer/InvalidNew4.json | 400         | Producer/InvalidNew4.json |
		

Scenario Outline: Update producer details
	Given I am a Client
	When I send a PUT request to '<route>' with data '<request_data>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route             | request_data                 | status_code | response_data                |
		| /api/producers/1  | Producer/ValidUpdate.json    | 200         | Producer/ValidUpdate.json    |
		| /api/producers/50 | Producer/InvalidUpdate1.json | 404         | Producer/InvalidUpdate1.json |
		| /api/producers/1  | Producer/InvalidUpdate2.json | 400         | Producer/InvalidUpdate2.json |
		| /api/producers/1  | Producer/InvalidUpdate3.json | 400         | Producer/InvalidUpdate3.json |
		| /api/producers/1  | Producer/InvalidUpdate4.json | 400         | Producer/InvalidUpdate4.json |
		| /api/producers/1  | Producer/InvalidUpdate5.json | 400         | Producer/InvalidUpdate5.json |
		

Scenario Outline: Delete a producer
	Given I am a Client
	When I send a DELETE request to '<route>'
	Then I should get a response with status code '<status_code>'
	And response data should look like '<response_data>'
	Examples: 
		| route             | status_code | response_data               |
		| /api/producers/1  | 200         | Producer/ValidDelete.json   |
		| /api/producers/50 | 404         | Producer/InvalidDelete.json |
