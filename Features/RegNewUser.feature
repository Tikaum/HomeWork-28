Feature: RnRStepDefinitions

@tag1
Scenario: Registration of new user
	Given I open start page	
	And Create  a user with a random login and password
	When I am entering the new user's details
	Then Registration button is available
	When Click Registration button
	Then User transit on next page
	