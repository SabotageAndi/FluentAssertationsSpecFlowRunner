using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using TechTalk.SpecFlow;

namespace FluentAssertationsSpecFlowRunner
{
    [Binding]
    public class Bindings
    {
        private readonly List<int> _numbers = new List<int>();
        private int _sum;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _numbers.Add(p0);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _sum = _numbers.Sum();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            _sum.Should().Be(p0);
            Execute.Assertion.FailWith("Failing");
        }
    }
}