using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.Search;

public class SearchPage : BasePageObject
{
    public readonly static string TITLE = "Search";

    private readonly string _searchIsbnSelector = "#search-isbn-value";
    private readonly string _searchAuthorSelector = "#search-author-value";
    private readonly string _searchTitleSelector = "#search-title-value";    
    private readonly string _submitSearchSelector = "#search-submit";

    private readonly string _errorMessageSelector = "#search-error-message";
    private readonly string _errorIsbnMessageSelector = "#IsbnSearch, .mud-input-helper-text.mud-input-error";    

    private readonly static string _pagePath = "/thepubliclibrary/search";
    public SearchPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();

    public async Task<string> GetIsbnValueAsync() => (await IsbnValueLocator.InputValueAsync()) ?? ""; 
    public async Task SetIsbnValueAsync(string isbnValue) => await IsbnValueLocator.TypeAsync(isbnValue);
    
    public async Task<string> GetAuthorValueAsync() => (await AuthorValueLocator.InputValueAsync()) ?? ""; 
    public async Task SetAuthorValueAsync(string authorValue) => await AuthorValueLocator.TypeAsync(authorValue);
    
    public async Task<string> GetTitleValueAsync() => (await TitleValueLocator.InputValueAsync()) ?? ""; 
    public async Task SetTitleValueAsync(string titleValue) => await TitleValueLocator.TypeAsync(titleValue);
    
    public async Task SubmitSearchAsync() => await SubmitSearchLocator.ClickAsync();
    
    public async Task SetValuesAsync(string isbnValue, string authorValue, string titleValue)
    {
        await SetIsbnValueAsync(isbnValue);
        await SetAuthorValueAsync(authorValue);
        await SetTitleValueAsync(titleValue);
    }

    public async Task<bool> IsOnPageAsync()
    {
        await IsbnValueLocator.WaitForAsync();
        return await Page.TitleAsync() == TITLE;
    }

    public async Task<string> GetErrorMessageAsync()
    {
        return await Page.TextContentAsync(_errorMessageSelector);
    }

    private ILocator IsbnValueLocator => Page.Locator(_searchIsbnSelector);
    private ILocator AuthorValueLocator => Page.Locator(_searchAuthorSelector);
    private ILocator TitleValueLocator => Page.Locator(_searchTitleSelector);
    private ILocator SubmitSearchLocator => Page.Locator(_submitSearchSelector);

}