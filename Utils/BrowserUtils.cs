using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wrappers.Utils
{
    public class BrowserUtils
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = Init();
                }
                return driver;
            }
        }

        private static IWebDriver Init()
        {
            var options = new ChromeOptions();            
            options.AddArguments(
                "--no-sandbox",
                "--disable-dev-shm-usage",
                "--disable-gpu",
                "--window-size=1280,1024",
                "--disable-popup-blocking");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }

        public static void OpenPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
