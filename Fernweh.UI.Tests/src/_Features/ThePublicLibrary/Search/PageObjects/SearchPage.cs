using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.Search;

public class SearchPage : BasePageObject
{
    public readonly static string TITLE = "Search";
    private readonly static string _pagePath = "/thepubliclibrary/search";
    
    private ILocator _searchIsbnLocator => Page.Locator("#search-isbn-value");
    private ILocator _errorIsbnMessageLocator => Page.Locator("#isbn-search, .mud-input-helper-text.mud-input-error");
    private ILocator _searchTitleLocator => Page.Locator("#search-title-value");
    private ILocator _submitSearchLocator => Page.Locator("#search-submit");
    private ILocator _errorMessageLocator => Page.Locator("#search-error-message");
    
    public SearchPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    
    public async Task<bool> IsOnPageAsync()
    {
        await _searchIsbnLocator.WaitForAsync();
        return await _searchIsbnLocator.IsVisibleAsync();
    }

    public async Task<string> GetErrorMessageAsync()
    {
        return await _errorMessageLocator.TextContentAsync() ?? "";
    } 

    public async Task SubmitSearchAsync() => await _submitSearchLocator.ClickAsync();
        
    public async Task<string> GetIsbnValueAsync() => (await _searchIsbnLocator.InputValueAsync()) ?? ""; 
    public async Task<string> GetTitleValueAsync() { 
        await _searchTitleLocator.WaitForAsync();
        return await _searchTitleLocator.InputValueAsync() ?? ""; 
    }    
    
    public async Task SetIsbnValueAsync(string isbnValue) => await _searchIsbnLocator.TypeAsync(isbnValue);    
    public async Task SetTitleValueAsync(string titleValue) => await _searchTitleLocator.TypeAsync(titleValue);
    public async Task SetValuesAsync(string isbnValue, string titleValue)
    {
        await SetIsbnValueAsync(isbnValue);
        await SetTitleValueAsync(titleValue);
    }    
}