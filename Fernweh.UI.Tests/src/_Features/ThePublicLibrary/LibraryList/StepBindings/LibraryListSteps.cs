namespace Fernweh.UITests.Features.ThePublicLibrary.LibraryDetail;

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

    [StepDefinition(@"I navigate to the library list page")]
    public async Task INavigateToTheLibraryListPage()
    {
        await _libraryListPage.GotoAsync();
    }

    [StepDefinition(@"I select the library by name ""(.*)""")]
    public async Task ISelectTheLibraryByName(string libraryName)
    {
        await _libraryListPage.SelectLibraryByNameAsync(libraryName);
    }

    [StepDefinition(@"I am on the library list page")]
    public async Task IAmOnTheLibraryListPage()
    {
        (await _libraryListPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"I see library ""(.*)"" is listed")]
    public async Task ISeeLibraryIsListed(string libraryName)
    {
        var libraryNameFromCard = await _libraryListPage.GetLibraryNameFromCardAsync(libraryName);
        libraryNameFromCard.Should().Be(libraryName);
    }    
}