using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.SearchResult;

public class SearchResultPage : BasePageObject
{
    public readonly static string TITLE = "Search Results";
    private readonly static string _pagePath = "/thepubliclibrary/searchResults";

    private readonly string _searchResultTitleSelector = "#search-result-title";
    private readonly string _gridBodySelector = "#search-results-grid tbody";
    private readonly string _gridRowsSelector = "#search-results-grid tbody tr";
    
    public SearchResultPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    
    public async Task NavigateToAsync() => await base.GotoAsync();

    public async Task<bool> IsOnPageAsync()
    {
        await SearchResultTitleLocator.WaitForAsync();
        return GetURL().Contains(_pagePath);        
    }

    public async Task<int> GetRowCountAsync() {
        await Page.WaitForSelectorAsync(_gridBodySelector);
        var rows = await SearchResultGridRows.AllAsync();
        return rows.Count();
    }

    private ILocator SearchResultTitleLocator => Page.Locator(_searchResultTitleSelector);   
    private ILocator SearchResultGridRows => Page.Locator(_gridRowsSelector);   

}