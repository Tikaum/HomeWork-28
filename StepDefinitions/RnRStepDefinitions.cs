using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumExtras.WaitHelpers;
using Wrappers.Builders;
using Wrappers.Page;
using Wrappers.Page.Forms;
using Wrappers.SeleniumFramework;
using Wrappers.Utils;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class RnRStepDefinitions
    {
        public IWebDriver driver = BrowserUtils.Driver;

        private readonly ScenarioContext _scenarioContext;

        CartPage cartPage = new CartPage();
        GeneratorUtils randomGenerator = new GeneratorUtils();
        RegistrationForm registrationForm = new RegistrationForm();


        private By ShopPageLocator = By.XPath("//a[text()='Shop']");
        private readonly By CartNotEmptyButtonLocator = By.CssSelector("a[title='View your shopping cart']");
        private By RegFieldUserLocator = By.Id("reg_email");
        private By PasswordFieldUserLocator = By.Id("reg_password");
        private By RegButtonLocator = By.Name("register");

        public ButtonElement ShopPageButton => new ButtonElement(ShopPageLocator);        
        public InfoElement CartNotEmptyButton => new InfoElement(CartNotEmptyButtonLocator);
        public InputElement RegFieldUserInput => new InputElement(RegFieldUserLocator);
        public InputElement PasswordFieldUserInput => new InputElement(PasswordFieldUserLocator);
        public ButtonElement RegButton => new ButtonElement(RegButtonLocator);

        

        public RnRStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I open shop page")]
        public void GivenIOpenShopPage()
        {
            driver.FindElement(ShopPageLocator).Click();
        }

        [Given("I open start page")]
        public void GivenIOpenStartPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
        }

        [Given("Create  a user with a random login and password")]
        public void GivenCreateAUserWithARandomLoginAndPassword()
        {
            string userName = randomGenerator.RandomEmail();
            _scenarioContext.Set(userName, "randomUserName");
            string password = randomGenerator.RandomPass();
            _scenarioContext.Set(password, "randomUserPassword");
        }

        [When("I am entering the new user's details")]
        public void WhenIAmEnteringTheNewUsersDetails()
        {            
            int attempts = 0; 
            var userName = _scenarioContext.Get<string>("randomUserName");
            var userPassword = _scenarioContext.Get<string>("randomUserPassword");
            RegFieldUserInput.SetUpText(userName);            
            PasswordFieldUserInput.SetUpText(userPassword);
            bool StateRegButton = RegButton.IsEnabled();                 
            while (!StateRegButton && attempts < 5)
            {
                RegFieldUserInput.Blur();
                PasswordFieldUserInput.Blur();
                StateRegButton = RegButton.IsEnabled();
                attempts++;
            }                         
        }

        [When("Click Registration button")]
        public void WhenClickRegistrationButton()
        {
            RegButton.ClickIfEnabled();
        }

        [Then("User transit on next page")]
        public void ThenUserTransitOnNextPage()
        {
            bool IsTransitNextPage = ShopPageButton.IsElementDisplayed();
            Assert.That(IsTransitNextPage, Is.True, "Registration failed, transition to the next page did not occur");
        }


        [Then("Registration button is available")]
        public void ThenRegistrationButtonIsUnavailable()
        {
            bool IsRegButtonEnable = RegButton.IsEnabled();
            Assert.That(IsRegButtonEnable, Is.True, "Registration failed, the Registration button is unavailable");
        }






    }

}
