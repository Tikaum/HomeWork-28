using HomeWork_28RnR.Page;
using NUnit.Framework;
using Reqnroll;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions : BaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        
        GeneratorUtils randomGenerator = new GeneratorUtils();
        RegistrationForm registrationForm = new RegistrationForm();
        MyAccountPage myAccountPage = new MyAccountPage();        

        public RegistrationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("Open start page")]
        public void GivenIOpenStartPage()
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
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
    }
}
