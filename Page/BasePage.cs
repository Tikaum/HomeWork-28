using OpenQA.Selenium;
using Wrappers.Page;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;

namespace HomeWork_28RnR.Page
{
    public abstract class BasePage
    {
        public IWebDriver driver = BrowserUtils.Driver;        
    }
}
