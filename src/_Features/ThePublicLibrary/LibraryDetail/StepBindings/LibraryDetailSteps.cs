namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

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

    [StepDefinition(@"we navigate to the library detail page")]
    public async Task WeNavigateToTheLibraryDetailPage()
    {
        await _libraryDetailPage.GotoAsync();
    }

    [StepDefinition(@"we direct navigate to the library detail page using ""(.*)""")]
    public async Task WeDirectNavigateToTheLibraryDetailPageUsing(string libraryId)
    {
        await _libraryDetailPage.GotoByIdAsync(libraryId);
    }

    [StepDefinition(@"we are on the library detail page")]
    public async Task WeAreOnTheLibraryDetailPage()
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

    [StepDefinition(@"the library detail open hours is ""(.*)""")]
    public async Task TheLibraryDetailOpenHoursAre(string openHours)
    {
        var openHoursUT = await _libraryDetailPage.GetOpenTimeAsync();
        openHoursUT.Should().Be(openHours);
    }
    
    [StepDefinition(@"the library detail close hours is ""(.*)""")]
    public async Task TheLibraryDetailCloseHoursAre(string closeHours)
    {
        var closeHoursUT = await _libraryDetailPage.GetCloseTimeAsync();
        closeHoursUT.Should().Be(closeHours);
    }
    
    [StepDefinition(@"the library detail notes is ""(.*)""")]
    public async void TheLibraryDetailNotesAre(string notes)
    {
        var notesUT = await _libraryDetailPage.GetNotesAsync();
        notesUT.Should().Be(notes);
    }

    [StepDefinition(@"the library detail primary phone is ""(.*)""")]
    public async void TheLibraryDetailPrimaryPhoneIs(string phone)
    {
        var phoneUT = await _libraryDetailPage.GetPrimaryPhoneAsync();
        phone.Should().Be(phone);
    }

    [StepDefinition(@"the library detail primary email is ""(.*)""")]
    public async void TheLibraryDetailPrimaryEmailIs(string email)
    {
        var emailUT = await _libraryDetailPage.GetPrimaryEmailAsync();
        email.Should().Be(email);
    }    

    [StepDefinition(@"we see a healthy library detail screen")]
    public void WeSeeAHealthyLibraryDetailScreen()
    {
        
    }    
    

}