using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.SearchResult;

public class SearchResultPage : BasePageObject
{
    public readonly static string TITLE = "Search Results";
    public readonly static string _pagePath = "/thepubliclibrary/searchResults";

    private ILocator _searchResultTitleLocator => Page.Locator("#search-result-title");
    private ILocator _gridTableLocator => Page.Locator("#search-results-grid");
    private ILocator _gridBodyLocator => Page.Locator("#search-results-grid tbody");
    private ILocator _gridRowsLocator => Page.Locator("#search-results-grid tbody tr");

    public SearchResultPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }

    
    public async Task<bool> IsOnPageAsync()
    {
        await _searchResultTitleLocator.WaitForAsync();
        
        return GetURL().Contains(_pagePath);
    }

    public async Task<int> GetRowCountAsync()
    {
        await _gridBodyLocator.WaitForAsync();

        var rows = await _gridRowsLocator.AllAsync();
        return rows.Count();
    }

    public async Task<int> GetBookCountByIsbn(string isbn)
    {
        await _gridRowsLocator.First.WaitForAsync();

        var isbnColumnIndex = await GetColumnIndexAsync(_gridTableLocator, "isbn");
        var bookCountColumnIndex = await GetColumnIndexAsync(_gridTableLocator, "copies");

        var rowIndex = await GetRowIndexAsync(_gridTableLocator, isbnColumnIndex, isbn);
        var bookCount = await GetTableRowColumnValueAsync(_gridTableLocator, rowIndex, bookCountColumnIndex);

        var returnValue = -1;
        int.TryParse(bookCount, out returnValue);

        return returnValue;
    }

}