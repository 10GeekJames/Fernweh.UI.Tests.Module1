namespace Fernweh.UITests.Features.ThePublicLibrary.FernwehHome;

[Binding]
public class FernwehHomeSteps : Steps
{
    private readonly FernwehHomePage _fernwehHomePage;

    public FernwehHomeSteps(FernwehHomePage fernwehHomePage)
    {
        _fernwehHomePage = fernwehHomePage;
    }

    [StepDefinition(@"we navigate to the fernwehHome page")]
    public async Task WeNavigateToTheFernwehHomePage()
    {
        await _fernwehHomePage.GotoAsync();
    }

    [StepDefinition(@"we are on the fernwehHome page")]
    public async Task WeAreOnTheFernwehHomePage()
    {
        (await _fernwehHomePage.IsOnPageAsync()).Should().BeTrue();
    }
    
    [StepDefinition(@"we fernwehHome for (.*)")]
    public async Task WeFernwehHomeFor(string fernwehHomeValue)
    {
        await _fernwehHomePage.FernwehHomeAsync(fernwehHomeValue);
    }

    [StepDefinition(@"the fernwehHome value is (.*)")]
    public async Task TheFernwehHomeValueIs(string fernwehHomeValue)
    {
        (await _fernwehHomePage.GetFernwehHomeValueAsync()).Should().Be(fernwehHomeValue);
    }
    
    
}