Feature: RnRStepDefinitions

@tag1
Scenario: Registration of new user
	Given Open start page	
	And Сreate a random login and password
	When Enter my login and password in the fields to register a new user
	Then Registration button is available
	When Click Registration button
	Then User transit on next page

Scenario: Authorization of a previously registered user
	Given Open start page
	And Enter login "test_user12345@gmail.com" in the fields to authorization a user
	And Enter password "vszef#@$%#54456456" in the fields to authorization a user
	When Click on the authorization confirmation button
	Then User transit on next page