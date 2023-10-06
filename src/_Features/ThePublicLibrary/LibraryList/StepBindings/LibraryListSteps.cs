namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

[Binding]
public class LibraryListSteps : Steps
{
    private readonly LibraryListPage _libraryListPage;
    private readonly ScenarioContext _scenarioContext;

    public LibraryListSteps(LibraryListPage libraryListPage, ScenarioContext scenarioContext)
    {
        _libraryListPage = libraryListPage;
        _scenarioContext = scenarioContext;
    }

    [StepDefinition(@"we navigate to the library list page")]
    public async Task WeNavigateToTheLibraryListPage()
    {
        await _libraryListPage.GotoAsync();
    }

    [StepDefinition(@"we select the library by name ""(.*)""")]
    public async Task WeSelectTheLibraryByName(string libraryName)
    {
        await _libraryListPage.SelectLibraryByName(libraryName);
    }

    [StepDefinition(@"we are on the library list page")]
    public async Task WeAreOnTheLibraryListPage()
    {
        (await _libraryListPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"we search for the library listed as ""(.*)""")]
    public async Task WeSearchForTheLibraryListedAs(string libraryName)
    {
        var libraryUnderTest = await _libraryListPage.GetLibraryNameByName(libraryName);
        _scenarioContext.Add("LibraryUnderTest", libraryUnderTest);        
    } 
    [StepDefinition(@"we can see the library listed as ""(.*)""")]
    public async Task WeCanSeeTheLibraryListedAs(string libraryName)
    {
        var libraryUnderTest = _scenarioContext.Get<string>("LibraryUnderTest");
        libraryUnderTest.Should().Be(libraryName);
    } 
}