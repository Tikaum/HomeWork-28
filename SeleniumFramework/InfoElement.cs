using OpenQA.Selenium;

namespace Wrappers.SeleniumFramework
{
    public class InfoElement : BaseElement
    {
        public InfoElement(By locator, int timeOutSeconds = 10) : base(locator, timeOutSeconds) { }

        public void ClickIfEnabled()
        {
            if (IsEnabled())
            {
                ClickElement();
            }
        }
    }
}
