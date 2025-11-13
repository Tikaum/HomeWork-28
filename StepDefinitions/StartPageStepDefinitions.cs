using Reqnroll;
using Wrappers.Page;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class StartPageStepDefinitions : BaseStepDefinitions
    {     
        StartPage startPage = new StartPage();

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
    }
}
