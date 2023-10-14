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

    [StepDefinition(@"I find the row containing isbn ""(.*)""")]
    public async Task IShouldSeeSearchPageResults(string isbn)
    {   
        var isbnColumnIndex = await _searchResultPage.GetBookCountByIsbn(isbn);
    }

    [StepDefinition(@"I can see ""(\d+)"" results for book isbn ""(.*)""")]
    public async Task IShouldSeeSearchPageResults(int expectedCount, string bookIsbn)
    {   
        var count = await _searchResultPage.GetBookCountByIsbn(bookIsbn);
        count.Should().Be(expectedCount);
    }
    
}
