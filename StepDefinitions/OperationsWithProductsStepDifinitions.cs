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

        [When("Go to the cart page")]
        public void WhenGoToTheCartPage()
        {
            shopPage.GoToCart();
        }

        [Then("Check the name and price of the product added to cart")]
        public void ThenCheckTheNameAndPriceOfTheProductAddedToCart()
        {
            cartPage.GetPriceOfProductInCart(out string productPriceOnCartPage)
                .GetNameOfProductInCart(out string productNameOnCartPage);
            //_scenarioContext.Set(productPriceOnCartPage, "ProductPriceOnCartPage");
            //_scenarioContext.Set(productNameOnCartPage, "ProductNameOnCartPage");
            Assert.Multiple(() =>
            {
                Assert.That(_scenarioContext.Get<string>("ProductNameOnShopPage"),
                    Is.EqualTo(productNameOnCartPage), "The product names do not match");
                Assert.That(_scenarioContext.Get<string>("ProductPriceOnShopPage"),
                    Is.EqualTo(productPriceOnCartPage), "The prices of the goods do not match");
            });
        }


    }
}
