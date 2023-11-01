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
    public async Task INavigateToTheFernwehHomePage()
    {
        await _fernwehHomePage.GotoAsync();
    }

    [StepDefinition(@"I am on the fernweh home page")]
    public async Task IAmOnTheFernwehHomePage()
    {
        (await _fernwehHomePage.IsOnPageAsync()).Should().BeTrue();
    }   
    
}