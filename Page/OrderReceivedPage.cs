using HomeWork_28RnR.Page;
using HomeWork_28RnR.StepDefinitions;
using OpenQA.Selenium;
using Wrappers.SeleniumFramework;

namespace Wrappers.Page
{
    public class OrderReceivedPage : BasePage
    {
        private By OrderReceivedTextLocator = By.XPath("//p[@class='woocommerce-thankyou-order-received']");
        private By ProductNameLocator = By.XPath("//td[@class='product-name']/a");
        private By ProductPriceLocator = By.XPath("//td[@class='product-total']/span");
        private By EmailLocator = By.XPath("//th[contains(text(),'Email:')]/following::td");
        private By TelephoneLocator = By.XPath("//th[contains(text(),'Telephone:')]/following::td");

        InfoElement OrderReceivedText => new InfoElement(OrderReceivedTextLocator);
        InfoElement ProductNameInOrderReceived => new InfoElement(ProductNameLocator);
        InfoElement ProductPriceInOrderReceived => new InfoElement(ProductPriceLocator);
        InfoElement EmailInOrderReceived => new InfoElement(EmailLocator);
        InfoElement TelephoneInOrderReceived => new InfoElement(TelephoneLocator);        

        public OrderReceivedPage GetOrderReceivedInfo(out IList<(string Text, string Name,
            string Price, string Email, string Telephone)> OrderReceivedInfoInfo)
        {
            OrderReceivedInfoInfo = new List<(string, string, string, string, string)>();
            OrderReceivedInfoInfo.Add((
                OrderReceivedText.GetText(),
                ProductNameInOrderReceived.GetText(),
                ProductPriceInOrderReceived.GetText(),
                EmailInOrderReceived.GetText(),
                TelephoneInOrderReceived.GetText()
            ));
            return this;
        }
    }
}
