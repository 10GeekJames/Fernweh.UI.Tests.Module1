using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.BookDetail;

public class BookDetailPage : BasePageObject
{
    public readonly static string _pagePath = "/thepubliclibrary/book-detail";

    private ILocator _title => Page.GetByTestId("book-title");
    private ILocator _author => Page.GetByTestId("book-authors");
    private ILocator _categories => Page.GetByTestId("book-categories");
    private ILocator _description => Page.GetByTestId("book-description");
    private ILocator _copiesTotal => Page.GetByTestId("book-total-copies");
    private ILocator _copiesAvailable => Page.GetByTestId("book-available-copies");
    private ILocator _publishDate => Page.GetByTestId("book-published-date");


    public BookDetailPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }

    public async Task<string> GetTitleAsync() => await _title.TextContentAsync();
    public async Task<string> GetAuthorAsync() => await _author.TextContentAsync();
    public async Task<string> GetCategoriesAsync() => await _categories.TextContentAsync();
    public async Task<string> GetDescriptionAsync() => await _description.TextContentAsync();
    public async Task<int> GetCopiesTotalAsync() => int.Parse(await _copiesTotal.TextContentAsync());
    public async Task<int> GetCopiesAvailableAsync() => int.Parse(await _copiesAvailable.TextContentAsync());
    public async Task<string> GetPublishDateAsync() => await _publishDate.TextContentAsync();

    public async Task<bool> IsOnPageAsync()
    {
        await Task.Yield();
        return Page.Url.Contains(_pagePath);
    }
}