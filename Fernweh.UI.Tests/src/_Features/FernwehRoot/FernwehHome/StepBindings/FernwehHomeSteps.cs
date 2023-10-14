namespace Fernweh.UITests.Features.ThePublicLibrary.FernwehHome;

[Binding]
public class FernwehHomeSteps : Steps
{
    private readonly FernwehHomePage _fernwehHomePage;

    public FernwehHomeSteps(FernwehHomePage fernwehHomePage)
    {
        _fernwehHomePage = fernwehHomePage;
    }

    [StepDefinition(@"I navigate to the fernweh home website")]
    public async Task WeNavigateToTheFernwehHomePage()
    {
        await _fernwehHomePage.GotoAsync();
    }

    [StepDefinition(@"I am on the fernweh home page")]
    public async Task WeAreOnTheFernwehHomePage()
    {
        (await _fernwehHomePage.IsOnPageAsync()).Should().BeTrue();
    }   
    
}