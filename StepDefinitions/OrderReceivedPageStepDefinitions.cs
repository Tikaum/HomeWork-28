using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using System;
using Wrappers.Page;
using Wrappers.Utils;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class OrderReceivedPageStepDefinitions : BaseStepDefinitions
    {
        OrderReceivedPage orderReceivedPage = new OrderReceivedPage();

        private readonly ScenarioContext _scenarioContext;        

        public OrderReceivedPageStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then("Check the confirmation text, name and price of the product, e-mail and telephone of the user in order received info")]
        public void ThenCheckTheConfirmationTextNameAndPriceOfTheProductE_MailAndTelephoneOfTheUserInOrderReceivedInfo()
        {
            orderReceivedPage.GetOrderReceivedInfo(out var infoOfReceived);
            string textOfOrderReceived = "Thank you. Your order has been received.";
            Assert.Multiple(() =>
            {
                Assert.That(infoOfReceived[0].Text, Is.EqualTo(textOfOrderReceived),
                    "The text on the order confirmation page does not match");
                Assert.That(infoOfReceived[0].Name, Is.EqualTo(_scenarioContext.Get<string>("ProductNameOnShopPage")),
                    "The product name in order received info do not match");
                Assert.That(infoOfReceived[0].Price, Is.EqualTo(_scenarioContext.Get<string>("ProductPriceOnShopPage")),
                    "The price of the product in order received info do not match");
                Assert.That(infoOfReceived[0].Email, Is.EqualTo(_scenarioContext.Get<string>("LoginOfUser")),
                    "The e-mail of the user in order received info do not match");
                Assert.That(infoOfReceived[0].Telephone, Is.EqualTo(_scenarioContext.Get<string>("PhoneOfUser")),
                    "The telephone of the user in order received info do not match");
            });
        }
    }
}
