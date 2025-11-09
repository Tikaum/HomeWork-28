using Reqnroll;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class SiteStepDefinitions
    {
        IWebDriver driver = new ChromeDriver();
        [Given("I open URL {string}")]
        public void OpenURL(string url)
        {
            driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            driver.Navigate().GoToUrl(url);
        }

    }
}
