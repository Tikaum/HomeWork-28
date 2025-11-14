using Reqnroll;
using Wrappers.Page;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class ShopPageStepDefinitions : BaseStepDefinitions
    {        
        private readonly ScenarioContext _scenarioContext;

        ShopPage shopPage = new ShopPage();

        public ShopPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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

        [When("Go to the cart page")]
        public void WhenGoToTheCartPage()
        {
            shopPage.GoToCart();
        }
    }
}
