using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.BookDetail;

public class BookDetailsPage : BasePageObject
{

    private readonly string _bookDetailValueSelector = "#book-detail-value";
    private readonly string _submitBookDetailSelector = "#book-detail-submit";

    private readonly static string _pagePath = "/bookDetail";
    public BookDetailsPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
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