using HomeWork_28RnR.Page;
using HomeWork_28RnR.StepDefinitions;
using OpenQA.Selenium;
using Wrappers.Builders;
using Wrappers.Page.Forms;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;

namespace Wrappers.Page
{
    public class StartPage : BasePage
    {
        CartPage cartPage = new CartPage();
        GeneratorUtils randomGenerator = new GeneratorUtils();
        RegistrationForm registrationForm = new RegistrationForm();

        public readonly By CartNotEmptyButtonLocator = By.CssSelector("a[title='View your shopping cart']");
        private By ShopPageLocator = By.XPath("//a[text()='Shop']");
        InfoElement CartNotEmptyButton => new InfoElement(CartNotEmptyButtonLocator);
        ButtonElement ShopPageButton => new ButtonElement(ShopPageLocator);

        public ShopPage GoToShopPage()
        {
            driver.FindElement(ShopPageLocator).Click();
            return new ShopPage();
        }

        public StartPage OpenPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
            return this;
        }

        public StartPage RegistrationNewUser()
        {
            string UserName = randomGenerator.RandomEmail();
            string Password = randomGenerator.RandomPass();
            var user = new UserBuilder()
            .WithName(UserName)
            .WithPassword(Password)
            .Build();
            registrationForm.RegistrationUser(user);
            return this;
        }

        public StartPage CleanCart()
        {            
            if (driver.FindElements(CartNotEmptyButtonLocator).Count() != 0)
            {
                CartNotEmptyButton.ClickElement();                
                cartPage.RemoveItemsFromCart();                
            }
            return this;
        }
    }
}
