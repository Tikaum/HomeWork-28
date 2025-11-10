using HomeWork_28RnR.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Xml.Linq;
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

        public OperationsWithProductsStepDifinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Login as an authorized user with login {string} and password {string}")]
        public void GivenLoginAsAnAuthorizedUserWithLoginAndPassword(string login, string password)
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
            loginForm.LoginFieldUserInput.SetUpText(login);
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
        }

        [Given("Find out the price of the product {string} on the shop page")]
        public void GivenFindOutThePriceOfTheProductOnTheShopPage(string productName)
        {
            shopPage.GetPriceOfItemInShop(productName, out string productPrice);                    
            _scenarioContext.Set(productPrice, "ProductPriceOnShopPage");
        }        

        [Given("Go to the cart page with added product {string}")]
        public void GivenGoToTheCartPageWithAddedProduct(string productName)
        {
            //_scenarioContext.Set(productName, "ProductNameOnShopPage");
            //startPage.GoToShopPage();
            //shopPage.GetPriceOfItemInShop(productName, out string productPrice);
            //_scenarioContext.Set(productPrice, "ProductPriceOnShopPage");
            shopPage.GoToCart();
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
            orderForm.GetNameOfProductInOrder(out string productNameInOrderPage)
                .GetPriceOfProductInOrder(out string productPriceInOrderPage);
            Assert.Multiple(() =>
            {
                Assert.That(productNameInOrderPage, Does.Contain(_scenarioContext.Get<string>("ProductNameOnShopPage")), "The product name in order do not match");
                Assert.That((_scenarioContext.Get<string>("ProductPriceOnShopPage")), Is.EqualTo(productPriceInOrderPage), "The price in order of the product do not match");
            });
        }
//And Click on the button to checkout the added product
//And Fill in the payment details (text data "", numerical data "")

    }
}
