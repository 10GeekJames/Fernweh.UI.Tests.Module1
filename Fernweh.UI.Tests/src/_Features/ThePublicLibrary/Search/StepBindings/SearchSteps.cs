namespace Fernweh.UITests.Features.ThePublicLibrary.Search;

[Binding]
public class SearchSteps : Steps
{
    private readonly SearchPage _searchPage;

    public SearchSteps(SearchPage searchPage)
    {
        _searchPage = searchPage;
    }

    [StepDefinition(@"I navigate to the search page")]
    public async Task INavigateToTheSearchPage()
    {
        await _searchPage.GotoAsync();
        (await _searchPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"I am on the search page")]
    public async Task IAmOnTheSearchPage()
    {
        (await _searchPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"I search for ""(.*)"", ""(.*)""")]
    public async Task WeSearchFor(string isbnValue, string titleValue)
    {
        await _searchPage.SetValuesAsync(isbnValue, titleValue);
    }
    
    [StepDefinition(@"I auto search for ""(.*)"", ""(.*)""")]
    public async Task WeAutoSearchFor(string isbnValue, string titleValue)
    {
        await _searchPage.SetValuesAsync(isbnValue, titleValue);
        await _searchPage.SubmitSearchAsync();
    }

    [StepDefinition(@"the search values are ""(.*)"", ""(.*)""")]
    public async Task TheSearchValuesAre(string isbnValue, string titleValue)
    {
        (await _searchPage.GetIsbnValueAsync()).Should().Be(isbnValue);
        (await _searchPage.GetTitleValueAsync()).Should().Be(titleValue);
    }
    
    [StepDefinition(@"I see a search error message")]
    public async Task WeSeeASearchErrorMessage()
    {
        (await _searchPage.GetErrorMessageAsync()).Should().NotBeNull();
    }

    [StepDefinition(@"I submit the search")]
    public async Task WhenWeSubmitTheSearch()
    {
        await _searchPage.SubmitSearchAsync();
    }
}