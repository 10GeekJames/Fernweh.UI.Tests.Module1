namespace Fernweh.UITests.Features.FernwehRoot.Counter;

[Binding]
public class CounterSteps : Steps
{
    private readonly CounterPage _counterPage;

    public CounterSteps(CounterPage counterPage)
    {
        _counterPage = counterPage;
    }

    [StepDefinition(@"we navigate to the counter page")]
    public async Task GivenWeNavigateToTheCounterPage()
    {
        await _counterPage.GotoAsync();
    }

    [StepDefinition(@"we click the increment button")]
    public async Task WeClickTheIncrementButton()
    {
        await _counterPage.IncrementValueAsync();
    }

    [StepDefinition(@"we are on the counter page")]
    public async Task WeAreOnTheCounterPage()
    {
        (await _counterPage.IsOnPageAsync()).Should().BeTrue();
    }
    
    [StepDefinition(@"the counter value is (.*)")]
    public async Task TheCounterValueIs(int counterValue)
    {
        (await _counterPage.GetIncrementValueAsync()).Should().Be(counterValue);
    }    
}