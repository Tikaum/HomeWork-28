using OpenQA.Selenium;
using Wrappers.Page;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;

namespace HomeWork_28RnR.Page
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private By ShopPageLocator = By.XPath("//a[text()='Shop']");
        public ButtonElement ShopPageButton => new ButtonElement(ShopPageLocator);

        public ShopPage GoToShopPage()
        {
            driver.FindElement(ShopPageLocator).Click();
            return new ShopPage();
        }
    }
}
