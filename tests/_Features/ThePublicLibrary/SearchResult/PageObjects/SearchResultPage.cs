using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.SearchResult;

public class SearchResultPage : BasePageObject
{
    public readonly static string TITLE = "Search Results";
    private readonly string _searchResultTitle = "#search-result-title";
    private readonly static string _pagePath = "/searchResult";
    public SearchResultPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();

    public async Task<bool> IsOnPageAsync()
    {
        await SearchResultTitleLocator.WaitForAsync();
        return GetURL().Contains(_pagePath);
    }

    private ILocator SearchResultTitleLocator => Page.Locator(_searchResultTitle);

}