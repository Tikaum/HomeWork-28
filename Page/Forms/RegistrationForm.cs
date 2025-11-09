using HomeWork_28RnR.Page;
using HomeWork_28RnR.StepDefinitions;
using OpenQA.Selenium;
using Wrappers.Models;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page.Forms
{
    public class RegistrationForm : BasePage
    {
        private By RegFieldUserLocator = By.Id("reg_email");
        private By PasswordFieldUserLocator = By.Id("reg_password");
        private By RegButtonLocator = By.Name("register");

        public InputElement RegFieldUserInput => new InputElement(RegFieldUserLocator);
        public InputElement PasswordFieldUserInput => new InputElement(PasswordFieldUserLocator);
        public InputElement RegButtonInput => new InputElement(RegButtonLocator);

        public bool RegistrationUser(UserModel user)
        {
            RegFieldUserInput.SetUpText(user.UserName);
            PasswordFieldUserInput.SetUpText(user.Password);
            bool IsRegButtonEnable = RegButtonInput.IsEnabled();            
            return IsRegButtonEnable;
        }

        public bool RegistrationUserSuccess()
        {                        
            if (ShopPageButton.IsElementDisplayed())
            {
                return true;
            }
            else return false;
        }
    }
}
