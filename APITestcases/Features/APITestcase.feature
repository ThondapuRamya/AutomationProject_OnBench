Feature: Users

To create and update and get all available users in system

@ListUsers
Scenario Outline: List all users available
	Given Create a GET request to get all users with page value as <PageNumber>
	Then Validate users list displayed in given range <startingRange> and <endingRange>
	Examples:
	| PageNumber | startingRange | endingRange |
	| 1          | 1             | 6           |
	| 2          | 7             | 12          |
	| 3          | 13            | 18          |


@CreateResource
Scenario: Create resource
	Given Create resource 
	Then Validate Resource is created or not
