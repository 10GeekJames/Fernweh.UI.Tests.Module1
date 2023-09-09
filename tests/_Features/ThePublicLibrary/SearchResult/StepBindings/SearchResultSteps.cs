namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.SearchResult;

[Binding]
public class SearchResultSteps : Steps
{
    private readonly SearchResultPage _searchResultPage;

    public SearchResultSteps(SearchResultPage searchResultPage)
    {
        _searchResultPage = searchResultPage;
    }

    [StepDefinition(@"we navigate to the searchResult page")]
    public async Task WeNavigateToTheSearchResultPage()
    {
        await _searchResultPage.GotoAsync();
    }

    [StepDefinition(@"we are on the search result page")]
    public async Task WeAreOnTheSearchResultPage()
    {   
        (await _searchResultPage.IsOnPageAsync()).Should().BeTrue();
        (await _searchResultPage.GetTitleAsync()).Should().Be(SearchResultPage.TITLE);
    }
}
