Feature: PurchasingGoodTest

@tag1
Scenario: Adding a product to the cart
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "HTML5 WebApp Develpment" to cart
	And Find out the price of the product "HTML5 WebApp Develpment" on the shop page
	When Go to the cart page
	Then Check the name and price of the product added to cart
