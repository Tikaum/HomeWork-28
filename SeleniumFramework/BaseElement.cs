using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using Wrappers.Utils;

namespace Wrappers.SeleniumFramework
{
    public class BaseElement
    {
        protected IWebDriver Driver = BrowserUtils.Driver;
        protected By Locator;
        protected WebDriverWait Wait;

        public BaseElement(By locator, int timeOutSeconds = 10)
        {
            Locator = locator;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOutSeconds));
        }

        public IWebElement Element => Wait.Until(driver => driver.FindElement(Locator));
        public IList<IWebElement> Elements => Wait.Until(driver => driver.FindElements(Locator));
        public bool IsEnabled()
        {
            return Element.Enabled;
        }

        public bool IsElementDisplayed()
        {
            return Element.Displayed;
        }

        public bool IsElementNotDisplayed()
        {
            int EC = Elements.Count();
            if (EC == 0) { return true; }
            else return false;          
        }

        public void ClickElement()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Locator)).Click();
        }

        public void SetUpText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }

        public void Blur()
        {
            Element.SendKeys(Keys.Tab);
        }

        public void SetUpTextWithOutClear(string text)
        {            
            Element.SendKeys(text);
        }

        public string GetText()
        {
            return Element.Text;
        }

        public string? GetAttributeValue(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }
    }
}
