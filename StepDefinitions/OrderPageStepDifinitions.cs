using NUnit.Framework;
using Reqnroll;
using Wrappers.Builders;
using Wrappers.Page.Forms;

namespace HomeWork_28RnR.StepDefinitions
{
    [Binding]
    public class OrderPageStepDifinitions : BaseStepDefinitions
    {
        OrderForm orderForm = new OrderForm();

        private readonly ScenarioContext _scenarioContext;                         

        public OrderPageStepDifinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }                

        [When("Filled in the payment details with text {string} in text fields and digits {string} numeric fields")]
        public void WhenFilledInThePaymentDetailsWithTextInTextFieldsAndDigitsNumericFields(string text, string digits)
        {
            _scenarioContext.Set(digits, "PhoneOfUser");
            var user = new UserBuilder()
                .WithFirstName(text)
                .WithLasttName(text)
                .WithPhone(digits)
                .WithAdress1(text)
                .WithCity(text)
                .WithPostcod(digits).BuildForOrder();
            orderForm.FillingOutOrder(user);            
        }
        
        [When("Click on the button to placed an order")]
        public void WhenClickOnTheButtonToPlacedAnOrder()
        {
            orderForm.PlaceOrder();
        }

        [Then("Check the name and price of the product in order")]
        public void ThenCheckTheNameAndPriceOfTheProductInOrder()
        {
            orderForm.GetNameOfProductInOrder(out string productNameInOrderPage);            
            orderForm.GetPriceOfProductInOrder(out string productPriceInOrderPage);           
            Assert.Multiple(() =>
            {
                Assert.That(productNameInOrderPage, Does.Contain(_scenarioContext.Get<string>("ProductNameOnShopPage")), "The product name in order do not match");
                Assert.That((_scenarioContext.Get<string>("ProductPriceOnShopPage")), Is.EqualTo(productPriceInOrderPage), "The price in order of the product do not match");
            });
        }
    }
}
