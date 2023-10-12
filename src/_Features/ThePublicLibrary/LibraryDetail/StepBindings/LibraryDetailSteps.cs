namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

[Binding]
public class LibraryDetailSteps : Steps
{
    private readonly LibraryDetailsPage _libraryDetailsPage;

    public LibraryDetailSteps(LibraryDetailsPage libraryDetailsPage)
    {
        _libraryDetailsPage = libraryDetailsPage;
    }

    [StepDefinition(@"we navigate to the library details page")]
    public async Task WeNavigateToTheLibraryDetailsPage()
    {
        await _libraryDetailsPage.GotoAsync();
    }

    [StepDefinition(@"we direct navigate to the library details page using ""(.*)""")]
    public async Task WeDirectNavigateToTheLibraryDetailsPageUsing(string libraryId)
    {
        await _libraryDetailsPage.GotoByIdAsync(libraryId);
    }

    [StepDefinition(@"we are on the library details page")]
    public async Task WeAreOnTheLibraryDetailsPage()
    {
        (await _libraryDetailsPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"we can see the library details name is ""(.*)""")]
    public async Task ThenWeCanSeeTheLibraryName(string libraryName)
    {
        var pageLibraryName = await _libraryDetailsPage.GetLibraryNameAsync();
        pageLibraryName.Should().Be(libraryName);
    }

}