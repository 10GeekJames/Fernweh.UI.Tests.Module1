using FluentAssertions.Equivalency;

namespace Fernweh.UITests.Features.ThePublicLibrary.LibraryDetail;

[Binding]
public class LibraryDetailSteps : Steps
{
    private readonly LibraryDetailPage _libraryDetailPage;
    private readonly ScenarioContext _scenarioContext;

    public LibraryDetailSteps(LibraryDetailPage libraryDetailPage, ScenarioContext scenarioContext)
    {
        _libraryDetailPage = libraryDetailPage;
        _scenarioContext = scenarioContext;
    }

    [StepDefinition(@"I navigate to the library detail page")]
    public async Task INavigateToTheLibraryDetailPage()
    {
        await _libraryDetailPage.GotoAsync();
    }


    [StepDefinition(@"I direct navigate to ""(.*)"" detail page")]
    public async Task WeDirectNavigateToTheNamedLibraryDetailPageUsing(string namedLibraryInDataset)
    {
        var libraryId = _scenarioContext.Get<Guid>(namedLibraryInDataset);
        await _libraryDetailPage.GotoAsync($"/{namedLibraryInDataset}");
    }

    [StepDefinition(@"I am on the library detail page")]
    public async Task IAmOnTheLibraryDetailPage()
    {
        (await _libraryDetailPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"the library detail name is ""(.*)""")]
    public async Task TheLibraryDetailNameIs(string libraryName)
    {
        var pageLibraryName = await _libraryDetailPage.GetLibraryNameAsync();
        pageLibraryName.Should().Be(libraryName);
    }

    [StepDefinition(@"the library detail advertisment content is ""(.*)""")]
    public async Task TheLibraryDetailAdvertismentContentIs(string advertismentContent)
    {
        var advertismentContentUT = await _libraryDetailPage.GetAdvertismentContentAsync();
        advertismentContentUT.Should().Be(advertismentContent);
    }

    // Using these patterns to reduce noise and make the tests more declarative for the feature file, 
    // just be careful you don't overburden the step definition with logic, just focus on assertions and error handling
    [StepDefinition(@"I see the library has the correct details for ""(.*)""")]
    public async Task ISeeTheLibraryHasTheCorrectDetailsFor(string libraryName)
    {
        // here we pull from the testing data out we put into the scenario context and use that to drive the assertions
        var libraryDetail = _scenarioContext.Get<LibraryViewModel>(libraryName);
        
        (await _libraryDetailPage.GetMailingAddressAsync()).Should().Be(libraryDetail.MailingAddress?.ToString());
        (await _libraryDetailPage.GetPrimaryPhoneAsync()).Should().Be(libraryDetail.PrimaryPhone?.ToString());
        (await _libraryDetailPage.GetPrimaryEmailAsync()).Should().Be(libraryDetail.PrimaryEmail?.ToString());
        (await _libraryDetailPage.GetNotesAsync()).Should().Be(libraryDetail.Notes);
        
        (await _libraryDetailPage.GetOpenTimeAsync())?.ToString("hh:mm tt").Should().Be(libraryDetail.OpenTimeShortFormat);
        (await _libraryDetailPage.GetCloseTimeAsync())?.ToString("hh:mm tt").Should().Be(libraryDetail.CloseTimeShortFormat);
        
        (await _libraryDetailPage.GetLibraryNameAsync()).Should().Be(libraryDetail.Name);
                
        var pageValues = await _libraryDetailPage.GetAsViewModelAsync();
        
        pageValues
           .Should()
           .BeEquivalentTo(libraryDetail,
               options => options.Excluding((IMemberInfo x) =>
                   x.Path.EndsWith("Id") ||
                   x.Path.EndsWith("OpenTime") ||
                   x.Path.EndsWith("CloseTime")
                   ));
    }

}