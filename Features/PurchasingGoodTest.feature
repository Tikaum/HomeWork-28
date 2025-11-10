Feature: PurchasingGoodTest

@tag1
Scenario: Check the name and price of the product added to cart
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "HTML5 WebApp Develpment" to cart
	And Find out the price of the product "HTML5 WebApp Develpment" on the shop page
	When Go to the cart page
	Then Check the name and price of the product added to cart

Scenario: Check the name and price of the added product in order
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "HTML5 WebApp Develpment" to cart
	And Find out the price of the product "HTML5 WebApp Develpment" on the shop page
	And Go to the cart page with added product "HTML5 WebApp Develpment"
	When Click on the button to checkout the added product
	Then Check the name and price of the product in order 

	