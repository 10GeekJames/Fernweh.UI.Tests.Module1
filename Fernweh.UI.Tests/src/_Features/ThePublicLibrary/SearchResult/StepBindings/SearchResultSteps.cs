namespace Fernweh.UITests.Features.ThePublicLibrary.SearchResult;

[Binding]
public class SearchResultSteps : Steps
{
    private readonly SearchResultPage _searchResultPage;

    public SearchResultSteps(SearchResultPage searchResultPage)
    {
        _searchResultPage = searchResultPage;
    }

    [StepDefinition(@"I navigate to the search result page")]
    public async Task INavigateToTheSearchResultPage()
    {
        await _searchResultPage.GotoAsync();
    }

    [StepDefinition(@"I am on the search result page")]
    public async Task IAmOnTheSearchResultPage()
    {   
        (await _searchResultPage.IsOnPageAsync()).Should().BeTrue();
        (await _searchResultPage.GetPageTitleAsync()).Should().Be(SearchResultPage.TITLE);
    }
    
    [StepDefinition(@"I see search page results")]
    public async Task ISeeSearchPageResults()
    {   
        var rowCount = await _searchResultPage.GetRowCountAsync();
        rowCount.Should().BeGreaterThan(0);
    }

    [StepDefinition(@"I find the row containing isbn ""(.*)""")]
    public async Task ISeeSearchPageResults(string isbn)
    {   
        var isbnColumnIndex = await _searchResultPage.GetBookCountByIsbn(isbn);
    }

    [StepDefinition(@"I see ""(\d+)"" results for book isbn ""(.*)""")]
    public async Task ISeeSearchPageResults(int expectedCount, string bookIsbn)
    {   
        var count = await _searchResultPage.GetBookCountByIsbn(bookIsbn);
        count.Should().Be(expectedCount);
    }
    
}
