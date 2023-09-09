namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.Search;

[Binding]
public class SearchSteps : Steps
{
    private readonly SearchPage _searchPage;

    public SearchSteps(SearchPage searchPage)
    {
        _searchPage = searchPage;
    }

    [StepDefinition(@"we navigate to the search page")]
    public async Task WeNavigateToTheSearchPage()
    {
        await _searchPage.GotoAsync();
    }

    [StepDefinition(@"we are on the search page")]
    public async Task WeAreOnTheSearchPage()
    {
        (await _searchPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"we search for ""(.*)"", ""(.*)"", ""(.*)""")]
    public async Task WeSearchFor(string isbnValue, string authorValue, string titleValue)
    {
        await _searchPage.SetValuesAsync(isbnValue, authorValue, titleValue);
    }

    [StepDefinition(@"the search values are ""(.*)"", ""(.*)"", ""(.*)""")]
    public async Task TheSearchValuesAre(string isbnValue, string authorValue, string titleValue)
    {
        (await _searchPage.GetIsbnValueAsync()).Should().Be(isbnValue);
        (await _searchPage.GetAuthorValueAsync()).Should().Be(authorValue);
        (await _searchPage.GetTitleValueAsync()).Should().Be(titleValue);
    }
    
    [StepDefinition(@"we see a search error message")]
    public async Task WeSeeASearchErrorMessage()
    {
        (await _searchPage.GetErrorMessageAsync()).Should().NotBeNull();
    }

    [StepDefinition(@"we submit the search")]
    public async Task WhenWeSubmitTheSearch()
    {
        await _searchPage.SubmitSearchAsync();
    }
}