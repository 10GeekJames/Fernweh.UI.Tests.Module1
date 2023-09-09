using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.BookDetail;

public class BookDetailPage : BasePageObject
{

    private readonly string _bookDetailValueSelector = "#bookDetail-value";
    private readonly string _submitBookDetailSelector = "#bookDetail-submit";

    private readonly static string _pagePath = "/bookDetail";
    public BookDetailPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();

    public async Task<string> GetBookDetailValueAsync() => await BookDetailValueLocator.TextContentAsync() ?? ""; 
    public async Task SetBookDetailValueAsync(string bookDetailValue) => await BookDetailValueLocator.TypeAsync(bookDetailValue);
    public async Task SubmitBookDetailAsync() => await SubmitBookDetailLocator.ClickAsync();
    public async Task BookDetailAsync(string bookDetailValue)
    {
        await SetBookDetailValueAsync(bookDetailValue);
        await SubmitBookDetailAsync();
    }

    public async Task<bool> IsOnPageAsync()
    {
        return await Page.IsVisibleAsync(_bookDetailValueSelector);
    }

    private ILocator BookDetailValueLocator => Page.Locator(_bookDetailValueSelector);
    private ILocator SubmitBookDetailLocator => Page.Locator(_submitBookDetailSelector);

}