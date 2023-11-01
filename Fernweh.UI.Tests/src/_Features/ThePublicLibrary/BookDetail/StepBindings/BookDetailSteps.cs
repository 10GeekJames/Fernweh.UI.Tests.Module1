using FluentAssertions.Equivalency;
namespace Fernweh.UITests.Features.ThePublicLibrary.BookDetail;
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
    [StepDefinition(@"I navigate to book by isbn ""(.*)""")]
    public async Task INavigateToBookByIsbn(string isbn)
    {
        await _bookDetailPage.GotoAsync($"/{isbn}");
    }
    [StepDefinition(@"I am on the book detail page")]
    public async Task IAmOnTheBookDetailPage()
    {
        (await _bookDetailPage.IsOnPageAsync()).Should().BeTrue();
    }

    // Using these patterns to reduce noise and make the tests more declarative for the feature file, 
    // just be careful you don't overburden the step definition with logic, just focus on assertions and error handling
    [StepDefinition(@"I see the book details with feature file providing quality check logic ""(.*)""")]
    public async Task ISeeTheBookDetailsFor(string isbn)
    {
        // here we pull from the testing data out we put into the scenario context and use that to drive the assertions
        var bookDetails = _scenarioContext.Get<BookViewModel>(isbn);
        await _bookDetailPage.GotoAsync($"/{isbn}");
        (await _bookDetailPage.GetIsbnAsync()).Should().Be(isbn);
        (await _bookDetailPage.GetPageHeaderAsync()).Should().Be(bookDetails.Title);
        (await _bookDetailPage.GetAuthorsAsync()).Should().Be(bookDetails.AuthorsList);
        (await _bookDetailPage.GetCategoriesAsync()).Should().Be(bookDetails.CategoriesList);
        (await _bookDetailPage.GetDescriptionAsync()).Should().Be(bookDetails.Description);
        (await _bookDetailPage.GetTotalCopyCountAsync()).Should().Be(bookDetails.CopiesCount);
        (await _bookDetailPage.GetAvailableCopyCountAsync()).Should().Be(bookDetails.AvailableCopiesCount);
        (await _bookDetailPage.GetPublishYearAsync()).Should().Be(bookDetails.PublishYear);
    }

    // Using these patterns to reduce noise and make the tests more declarative for the feature file, 
    // just be careful you don't overburden the step definition with logic, just focus on assertions and error handling
    [StepDefinition(@"I see the book details for ""(.*)""")]
    public async Task ISeeTheBookDetailsForUsingPOM(string isbn)
    {
        // here we pull from the testing data out we put into the scenario context and use that to drive the assertions
        var bookDetails = _scenarioContext.Get<BookViewModel>(isbn);
        //await _bookDetailPage.GotoAsync($"/{isbn}");
        (await _bookDetailPage.GetAsViewModelAsync())
            .Should()
            .BeEquivalentTo(bookDetails,
                options => options.Excluding((IMemberInfo x) =>
                    x.Path.EndsWith("Id") ||
                    x.Path.EndsWith("BookCopies") ||
                    x.Path.EndsWith("BookCategories") ||                    
                    x.Path.EndsWith("Authors") ||
                    x.Path.EndsWith("PageCount")
                    ));
    }
}