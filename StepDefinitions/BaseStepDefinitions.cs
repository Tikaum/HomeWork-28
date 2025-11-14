using HomeWork_28RnR.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using Wrappers.Page;
using Wrappers.Page.Forms;
using Wrappers.Utils;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public abstract class BaseStepDefinitions
    {
        public IWebDriver driver = BrowserUtils.Driver;

        [AfterScenario]
        public static void AfterScenario()
        {
            BrowserUtils.Quit();
        }
    }
}
