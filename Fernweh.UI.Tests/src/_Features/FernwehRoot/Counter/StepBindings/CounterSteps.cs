namespace Fernweh.UITests.Features.FernwehRoot.Counter;

[Binding]
public class CounterSteps : Steps
{
    private readonly CounterPage _counterPage;

    public CounterSteps(CounterPage counterPage)
    {
        _counterPage = counterPage;
    }

    [StepDefinition(@"I navigate to the counter page")]
    public async Task GivenINavigateToTheCounterPage()
    {
        await _counterPage.GotoAsync();
    }

    [StepDefinition(@"I click the increment button")]
    public async Task WeClickTheIncrementButton()
    {
        await _counterPage.IncrementValueAsync();
    }

    [StepDefinition(@"I am on the counter page")]
    public async Task IAmOnTheCounterPage()
    {
        (await _counterPage.IsOnPageAsync()).Should().BeTrue();
    }
    
    [StepDefinition(@"the counter value is (.*)")]
    public async Task TheCounterValueIs(int counterValue)
    {
        (await _counterPage.GetIncrementValueAsync()).Should().Be(counterValue);
    }    
}