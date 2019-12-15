using System;
using TechTalk.SpecFlow;

namespace XUnitTestProject1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Console.WriteLine("Given");
        } 

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("When");
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine("Then");
        }
    }
}
