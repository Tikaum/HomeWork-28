using OpenQA.Selenium;
using Reqnroll;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseStepDefinitions
    {                
        private readonly ScenarioContext _scenarioContext;

        LoginForm loginForm = new LoginForm();

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
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

        [Given("Login as an authorized user with login {string} and password {string}")]
        public void GivenLoginAsAnAuthorizedUserWithLoginAndPassword(string login, string password)
        {
            BrowserUtils.OpenPage("https://practice.automationtesting.in/my-account/");
            _scenarioContext.Set(login, "LoginOfUser");
            loginForm.LoginFieldUserInput.SetUpText(login);
            _scenarioContext.Set(password, "PasswordOfUser");
            loginForm.PasswordFieldUserInput.SetUpText(password);
            loginForm.LoginButtonInput.ClickElement();
        }

        [When("Click on the authorization confirmation button")]
        public void WhenClickOnTheAuthorizationConfirmationButton()
        {
            loginForm.LoginButtonInput.ClickElement();
        }
    }
}
