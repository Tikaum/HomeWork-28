using NUnit.Framework;
using Reqnroll;

namespace HomeWork_28_RnR_.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

        [Given("the first number is {int}")]
        public void SetFirstNumber(int number1)
        {
            int num1 = number1;
        }

        [Given("the second number is {int}")]
        public void SetSecondNumber(int number2)
        {
            int num2 = number2;
        }

        [Given("the third number is {int}")]
        public void SetThierdNumber(int number3)
        {
            int num3 = number3;
        }

        [When("the two numbers are added")]
        public void TwoNumbersAreAdded()
        {
            int c = 50 + 70;
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {            
            NUnit.Framework.Assert.That(120, Is.EqualTo(result), "Numbers not correct sum");
        }

        [When("the two numbers are minused")]
        public void TwoNumbersAreMinus()
        {
            int c = 1000 - 345;
        }

        [Then("the result of minusing should be {int}")]
        public void ThenTheResultOfMinusedShouldBe(int result)
        {
            NUnit.Framework.Assert.That(655, Is.EqualTo(result), "Numbers not correct minused");
        }
    }
}
