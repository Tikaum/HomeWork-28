using OpenQA.Selenium;
using System;

namespace HomeWork_28RnR.Page
{
    public class MyAccountPage : BasePage
    {        
        private By MyAccountPageLocator = By.XPath("//p[contains(text(), 'Hello')]");

        public bool IsLoggedIn()
        {
            bool successLogged = driver.FindElements(MyAccountPageLocator).Count() > 0;
            return successLogged;
        }
    }
}
