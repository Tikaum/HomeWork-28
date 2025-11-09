using HomeWork_28RnR.Page;
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
        
        GeneratorUtils randomGenerator = new GeneratorUtils();
        RegistrationForm registrationForm = new RegistrationForm();
        MyAccountPage myAccountPage = new MyAccountPage();
        LoginForm loginForm = new LoginForm();        

        public RnRStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Open start page")]
        public void GivenIOpenStartPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
        }

        [Given("Enter login {string} in the fields to authorization a user")]
        public void GivenEnterLoginInTheFieldsToAuthorizationAUser(string login)
        {
            loginForm.LoginFieldUserInput.SetUpText(login);
        }

        [Given("Enter password {string} in the fields to authorization a user")]
        public void GivenEnterPasswordInTheFieldsToAuthorizationAUser(string password)
        {
            loginForm.PasswordFieldUserInput.SetUpText(password);
        }

        [When("Click on the authorization confirmation button")]
        public void WhenClickOnTheAuthorizationConfirmationButton()
        {
            loginForm.LoginButtonInput.ClickElement();
        }

        [Given("Сreate a random login and password")]
        public void GivenСreateARandomLoginAndPassword()
        {
            string userName = randomGenerator.RandomEmail();
            _scenarioContext.Set(userName, "randomUserName");
            string password = randomGenerator.RandomPass();
            _scenarioContext.Set(password, "randomUserPassword");
        }

        [When("Enter my login and password in the fields to register a new user")]
        public void WhenEnterMyLoginAndPasswordInTheFieldsToRegisterANewUser()
        {
            var userName = _scenarioContext.Get<string>("randomUserName");
            var userPassword = _scenarioContext.Get<string>("randomUserPassword");
            registrationForm.RegFieldUserInput.SetUpText(userName);
            registrationForm.PasswordFieldUserInput.SetUpText(userPassword);
            bool StateRegButton = registrationForm.RegButtonInput.IsEnabled();
            int attempts = 0;
            while (!StateRegButton && attempts < 5)
            {
                registrationForm.RegFieldUserInput.Blur();
                Thread.Sleep(500);
                registrationForm.PasswordFieldUserInput.Blur();
                Thread.Sleep(500);
                StateRegButton = registrationForm.RegButtonInput.IsEnabled();
                attempts++;
            }
        }        

        [When("Click Registration button")]
        public void WhenClickRegistrationButton()
        {
            registrationForm.RegButtonInput.ClickIfEnabled();
        }

        [Then("User transit on next page")]
        public void ThenUserTransitOnNextPage()
        {
            bool IsTransitNextPage = myAccountPage.IsLoggedIn();
            Assert.That(IsTransitNextPage, Is.True, "Registration failed, transition to the next page did not occur");
        }

        [Then("Registration button is available")]
        public void ThenRegistrationButtonIsUnavailable()
        {
            bool IsRegButtonEnable = registrationForm.RegButtonInput.IsEnabled();
            Assert.That(IsRegButtonEnable, Is.True, "Registration failed, the Registration button is unavailable");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BrowserUtils.Quit();
        }
    }
}
