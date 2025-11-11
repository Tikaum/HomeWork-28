using HomeWork_28RnR.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class OperationsWithProductsStepDifinitions
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private readonly ScenarioContext _scenarioContext;

        GeneratorUtils randomGenerator = new GeneratorUtils();
        RegistrationForm registrationForm = new RegistrationForm();
        MyAccountPage myAccountPage = new MyAccountPage();
        LoginForm loginForm = new LoginForm();
        CartPage cartPage = new CartPage();
        StartPage startPage = new StartPage();
        ShopPage shopPage = new ShopPage();
        OrderForm orderForm = new OrderForm();
        OrderReceivedPage orderReceivedPage = new OrderReceivedPage();

        public OperationsWithProductsStepDifinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Login as an authorized user with login {string} and password {string}")]
        public void GivenLoginAsAnAuthorizedUserWithLoginAndPassword(string login, string password)
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
            _scenarioContext.Set(login, "LoginOfUser");
            loginForm.LoginFieldUserInput.SetUpText(login);
            _scenarioContext.Set(password, "PasswordOfUser");
            loginForm.PasswordFieldUserInput.SetUpText(password);
            loginForm.LoginButtonInput.ClickElement();
        }

        [Given("Clear shopping cart")]
        public void GivenClearShoppingCart()
        {
            startPage.CleanCart();
        }

        [Given("Go to the shop page")]
        public void GivenGoToTheShopPage()
        {
            startPage.GoToShopPage();
        }

        [Given("Add product {string} to cart")]
        public void GivenAddProductToCart(string productName)
        {
            _scenarioContext.Set(productName, "ProductNameOnShopPage");
            shopPage.AddItemFromNameToCart(productName);
            shopPage.GetPriceOfItemInShop(productName, out string productPrice);
            _scenarioContext.Set(productPrice, "ProductPriceOnShopPage");
        }                     

        [Given("Go to the cart page with added product")]
        public void GivenGoToTheCartPageWithAddedProduct()
        {
            shopPage.GoToCart();
        }

        [Given("Proceeded to checkout")]
        public void GivenProceededToCheckout()
        {
            shopPage.GoToCart();
            cartPage.PurchaseItems();
        }

        [When("Go to the cart page")]
        public void WhenGoToTheCartPage()
        {
            shopPage.GoToCart();
        }

        [When("Click on the button to checkout the added product")]
        public void WhenClickOnTheButtonToCheckoutTheAddedProduct()
        {
            cartPage.PurchaseItems();
        }

        [When("Filled in the payment details with text {string} in text fields and digits {string} numeric fields")]
        public void WhenFilledInThePaymentDetailsWithTextInTextFieldsAndDigitsNumericFields(string text, string digits)
        {
            _scenarioContext.Set(digits, "PhoneOfUser");
            var user = new UserBuilder()
                .WithFirstName(text)
                .WithLasttName(text)
                .WithPhone(digits)
                .WithAdress1(text)
                .WithCity(text)
                .WithPostcod(digits).BuildForOrder();
            orderForm.FillingOutOrder(user);            
        }
        
        [When("Click on the button to placed an order")]
        public void WhenClickOnTheButtonToPlacedAnOrder()
        {
            orderForm.PlaceOrder();
        }

        [Then("Check the confirmation text, name and price of the product, e-mail and telephone of the user in order received info")]
        public void ThenCheckTheConfirmationTextNameAndPriceOfTheProductE_MailAndTelephoneOfTheUserInOrderReceivedInfo()
        {
            orderReceivedPage.GetOrderReceivedInfo(out var infoOfReceived);
            string textOfOrderReceived = "Thank you. Your order has been received.";
            Assert.Multiple(() =>
            {
                Assert.That(infoOfReceived[0].Text, Is.EqualTo(textOfOrderReceived),
                    "The text on the order confirmation page does not match");
                Assert.That(infoOfReceived[0].Name, Is.EqualTo(_scenarioContext.Get<string>("ProductNameOnShopPage")),
                    "The product name in order received info do not match");
                Assert.That(infoOfReceived[0].Price, Is.EqualTo(_scenarioContext.Get<string>("ProductPriceOnShopPage")),
                    "The price of the product in order received info do not match");
                Assert.That(infoOfReceived[0].Email, Is.EqualTo(_scenarioContext.Get<string>("LoginOfUser")),
                    "The e-mail of the user in order received info do not match");
                Assert.That(infoOfReceived[0].Telephone, Is.EqualTo(_scenarioContext.Get<string>("PhoneOfUser")),
                    "The telephone of the user in order received info do not match");
            });
        }

        [Then("Check the name and price of the product added to cart")]
        public void ThenCheckTheNameAndPriceOfTheProductAddedToCart()
        {
            cartPage.GetPriceOfProductInCart(out string productPriceOnCartPage)
                .GetNameOfProductInCart(out string productNameOnCartPage);            
            Assert.Multiple(() =>
            {
                Assert.That(_scenarioContext.Get<string>("ProductNameOnShopPage"),
                    Is.EqualTo(productNameOnCartPage), "The product names do not match");
                Assert.That(_scenarioContext.Get<string>("ProductPriceOnShopPage"),
                    Is.EqualTo(productPriceOnCartPage), "The prices of the goods do not match");
            });
        }

        [Then("Check the name and price of the product in order")]
        public void ThenCheckTheNameAndPriceOfTheProductInOrder()
        {
            orderForm.GetNameOfProductInOrder(out string productNameInOrderPage);            
            orderForm.GetPriceOfProductInOrder(out string productPriceInOrderPage);           
            Assert.Multiple(() =>
            {
                Assert.That(productNameInOrderPage, Does.Contain(_scenarioContext.Get<string>("ProductNameOnShopPage")), "The product name in order do not match");
                Assert.That((_scenarioContext.Get<string>("ProductPriceOnShopPage")), Is.EqualTo(productPriceInOrderPage), "The price in order of the product do not match");
            });
        }
    }
}
