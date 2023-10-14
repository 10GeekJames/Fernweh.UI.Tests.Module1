namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.SearchResult;

[Binding]
public class SearchResultSteps : Steps
{
    private readonly SearchResultPage _searchResultPage;

    public SearchResultSteps(SearchResultPage searchResultPage)
    {
        _searchResultPage = searchResultPage;
    }

    [StepDefinition(@"I navigate to the search result page")]
    public async Task WeNavigateToTheSearchResultPage()
    {
        await _searchResultPage.GotoAsync();
    }

    [StepDefinition(@"I am on the search result page")]
    public async Task WeAreOnTheSearchResultPage()
    {   
        (await _searchResultPage.IsOnPageAsync()).Should().BeTrue();
        (await _searchResultPage.GetTitleAsync()).Should().Be(SearchResultPage.TITLE);
    }

    
    [StepDefinition(@"I should see search page results")]
    public async Task IShouldSeeSearchPageResults()
    {   
        var rowCount = await _searchResultPage.GetRowCountAsync();
        rowCount.Should().BeGreaterThan(0);
    }
}
