Feature: PurchasingGoodTest

@tag1
Scenario: Check the name and price of the product added to cart
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "HTML5 WebApp Develpment" to cart	
	When Go to the cart page
	Then Check the name and price of the product added to cart

Scenario: Check the name and price of the added product in order
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "Selenium Ruby" to cart	
	And Go to the cart page with added product
	When Click on the button to checkout the added product
	Then Check the name and price of the product in order 

Scenario: FillingOut order and check userdata and productdata in order received info
	Given Login as an authorized user with login "test_user12345@gmail.com" and password "vszef#@$%#54456456"
	And Clear shopping cart
	And Go to the shop page
	And Add product "HTML5 Forms" to cart	
	And Proceeded to checkout
	When Filled in the payment details with text "Abrakadabra" in text fields and digits "123456" numeric fields
	And Click on the button to placed an order	
	Then Check the confirmation text, name and price of the product, e-mail and telephone of the user in order received info