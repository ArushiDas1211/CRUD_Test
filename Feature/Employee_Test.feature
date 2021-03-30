@User
Feature: Employee_Test
Description: The feature file describe the positive and negative scenarioes for CRUD

Background: 
Given the user is a valid user

@PositiveScenario @GetUser
Scenario: Verify that valid user can access the URL
	When the user request for 'GET' the user details
	Then the user details should be returned with status code '200'

@PositiveScenario @GetSingleUser
Scenario:Verify that user with valid ID details are returned
	When the request for 'GET' the user details with Id '2'
	Then the user details should be verified with status code '200' 
	| id | employee_name   |
	| 2  | Garrett Winters |

@PositiveScenario @PostUser
Scenario:Verify that user details are created with success
	When the request for 'POST' the user details with details
	| Data                                      |
	| {"name":"test","salary":"123","age":"23"} |
	Then the user details should be returned with success message
	| Message                              |
	| Successfully! Record has been added. |

@PositiveScenario @GetSingleUser
Scenario:Verify that user records are deleted
	When the request for 'DELETE' the user details with Id '2'
	Then the user details should be returned with success message
	| Message                       |
	| Successfully! Record has been deleted |
	
	

