namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.BookDetail;

[Binding]
public class BookDetailSteps : Steps
{
    private readonly BookDetailPage _bookDetailPage;
    private readonly ScenarioContext _scenarioContext;

    public BookDetailSteps(BookDetailPage bookDetailPage, ScenarioContext scenarioContext)
    {
        _bookDetailPage = bookDetailPage;
        _scenarioContext = scenarioContext;
    }

    [StepDefinition(@"I navigate to book by id ""(.*)""")]
    public async Task INavigateToBookById(Guid bookId)
    {
        await _bookDetailPage.GotoAsync(bookId.ToString());
    }

    [StepDefinition(@"we are on the book detail page")]
    public async Task WeAreOnTheBookDetailPage()
    {
        (await _bookDetailPage.IsOnPageAsync()).Should().BeTrue();
    }

    [StepDefinition(@"I can see the book details for ""(.*)""")]
    public async Task ICanSeeTheBookDetailsFor(string isbn)
    {
        var bookDetails = _scenarioContext.Get<BookViewModel>(isbn);
        await _bookDetailPage.GotoAsync(isbn);
        (await _bookDetailPage.GetTitleAsync()).Should().Be(bookDetails.Title);
        (await _bookDetailPage.GetAuthorAsync()).Should().Be(bookDetails.AuthorsList);
        (await _bookDetailPage.GetCategoriesAsync()).Should().Be(bookDetails.CategoriesList);
        (await _bookDetailPage.GetDescriptionAsync()).Should().Be(bookDetails.Description);
        (await _bookDetailPage.GetCopiesTotalAsync()).Should().Be(bookDetails.CopiesCount);
        (await _bookDetailPage.GetCopiesAvailableAsync()).Should().Be(bookDetails.AvailableCopiesCount);
        (await _bookDetailPage.GetPublishDateAsync()).Should().Be(bookDetails.PublicationYear.ToString("d"));
    }
}