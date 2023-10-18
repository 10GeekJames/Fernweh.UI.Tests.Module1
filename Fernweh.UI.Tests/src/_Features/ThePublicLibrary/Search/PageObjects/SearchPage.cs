using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.Search;

public class SearchPage : BasePageObject
{
    public readonly static string TITLE = "Search";

    private ILocator _searchIsbnLocator => Page.Locator("#search-isbn-value");
    private ILocator _searchAuthorLocator => Page.Locator("#search-author-value");
    private ILocator _searchTitleLocator => Page.Locator("#search-title-value");
    private ILocator _submitSearchLocator => Page.Locator("#search-submit");
    private ILocator _errorMessageLocator => Page.Locator("#search-error-message");
    private ILocator _errorIsbnMessageLocator => Page.Locator("#isbn-search, .mud-input-helper-text.mud-input-error");

    private readonly static string _pagePath = "/thepubliclibrary/search";
    public SearchPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    
    public async Task<string> GetIsbnValueAsync() => (await _searchIsbnLocator.InputValueAsync()) ?? ""; 
    public async Task SetIsbnValueAsync(string isbnValue) => await _searchIsbnLocator.TypeAsync(isbnValue);
    
    public async Task<string> GetAuthorValueAsync() => (await _searchAuthorLocator.InputValueAsync()) ?? ""; 
    public async Task SetAuthorValueAsync(string authorValue) => await _searchAuthorLocator.TypeAsync(authorValue);
    
    public async Task<string> GetTitleValueAsync() { 
        await _searchTitleLocator.WaitForAsync();
        return await _searchTitleLocator.InputValueAsync() ?? ""; 
    }
    public async Task SetTitleValueAsync(string titleValue) => await _searchTitleLocator.TypeAsync(titleValue);
    
    public async Task SubmitSearchAsync() => await _submitSearchLocator.ClickAsync();
    
    public async Task SetValuesAsync(string isbnValue, string authorValue, string titleValue)
    {
        await SetIsbnValueAsync(isbnValue);
        await SetAuthorValueAsync(authorValue);
        await SetTitleValueAsync(titleValue);
    }

    public async Task<bool> IsOnPageAsync()
    {
        await _searchIsbnLocator.WaitForAsync();
        return await _searchIsbnLocator.IsVisibleAsync();
    }

    public async Task<string> GetErrorMessageAsync()
    {
        return await _errorMessageLocator.TextContentAsync();
    } 
}