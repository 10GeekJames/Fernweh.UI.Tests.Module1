using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.BookDetail;

public class BookDetailPage : BasePageObject
{
    public readonly static string _pagePath = "/thepubliclibrary/book-detail";

    private ILocator _pageHeader => Page.GetByTestId("book-title");
    private ILocator _author => Page.GetByTestId("book-authors");
    private ILocator _categories => Page.GetByTestId("book-categories");
    private ILocator _totalCopyCount => Page.GetByTestId("book-total-copies");
    private ILocator _availableCopyCount => Page.GetByTestId("book-available-copies");
    private ILocator _description => Page.GetByTestId("book-description");
    private ILocator _isbn => Page.GetByTestId("book-isbn");
    private ILocator _publishYear => Page.GetByTestId("book-published-date");

    public BookDetailPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }

    public async Task<string?> GetPageHeaderAsync() => await _pageHeader.TextContentAsync();

    public async Task<string?> GetAuthorsAsync() => await _author.TextContentAsync();
    public async Task<string?> GetIsbnAsync() => await _isbn.TextContentAsync();

    public async Task<string?> GetCategoriesAsync() => await _categories.TextContentAsync();
    public async Task<long?> GetTotalCopyCountAsync() => long.Parse(await _totalCopyCount.TextContentAsync() ?? "-1");
    public async Task<long> GetAvailableCopyCountAsync() => long.Parse(await _availableCopyCount.TextContentAsync() ?? "-1");
    public async Task<string?> GetDescriptionAsync() => await _description.TextContentAsync();
    public async Task<string?> GetPublishYearAsync() => await _publishYear.TextContentAsync();

    public async Task<BookViewModel> GetAsViewModelAsync() => new BookViewModel
    {
        Title = await GetPageHeaderAsync(),
        Authors = new List<AuthorViewModel>((await GetAuthorsAsync()).Split(",").Select(rs => new AuthorViewModel { Name = new NameVOViewModel { FirstName = rs.Split(" ")[0], LastName = rs.Split(" ")[1] } })),
        BookCategories = new List<BookCategoryViewModel>((await GetCategoriesAsync()).Split(",").Select(rs => new BookCategoryViewModel { Title = rs })),
        CopiesCount = await GetTotalCopyCountAsync() ?? -1,
        AvailableCopiesCount = await GetAvailableCopyCountAsync(),
        Description = await GetDescriptionAsync(),
        Isbn = new IsbnVOViewModel() { Isbn = await GetIsbnAsync() },
        PublishYear = await GetPublishYearAsync()
    };
    
    public async Task<bool> IsOnPageAsync()
    {
        await Task.Yield();
        return Page.Url.Contains(_pagePath);
    }
}