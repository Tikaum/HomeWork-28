using HomeWork_28RnR.Page;
using HomeWork_28RnR.StepDefinitions;
using OpenQA.Selenium;
using Wrappers.Models;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page.Forms
{
    public class LoginForm : BasePage
    {
        private By LoginFieldUserLocator = By.Id("username");
        private By PasswordFieldUserLocator = By.Id("password");
        private By LoginButtonLocator = By.Name("login");

        public InputElement LoginFieldUserInput => new InputElement(LoginFieldUserLocator);
        public InputElement PasswordFieldUserInput => new InputElement(PasswordFieldUserLocator);
        public InputElement LoginButtonInput => new InputElement(LoginButtonLocator);

        public void LoginUser(UserModel user)
        {
            LoginFieldUserInput.SetUpText(user.UserName);
            PasswordFieldUserInput.SetUpText(user.Password);
            LoginButtonInput.ClickElement();
        }
    }
}
