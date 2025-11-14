using NUnit.Framework;
using Reqnroll;
using Wrappers.Page;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class CartPageStepDefinitions : BaseStepDefinitions
    {        
        private readonly ScenarioContext _scenarioContext;

        CartPage cartPage = new CartPage();
        ShopPage shopPage = new ShopPage();

        public CartPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Proceeded to checkout")]
        public void GivenProceededToCheckout()
        {
            shopPage.GoToCart();
            cartPage.PurchaseItems();
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
    }
}
