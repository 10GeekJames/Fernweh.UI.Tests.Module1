using FluentAssertions.Equivalency;
namespace Fernweh.UITests.Features.ThePublicLibrary.BookDetail;
[Binding]
public class DeleteMe01stBookDetailBadWayToThingsTooImparativeSeekDeclarativeSteps : Steps
{
    private readonly BookDetailPage _bookDetailPage;
    private readonly ScenarioContext _scenarioContext;
    public DeleteMe01stBookDetailBadWayToThingsTooImparativeSeekDeclarativeSteps(BookDetailPage bookDetailPage, ScenarioContext scenarioContext)
    {
        _bookDetailPage = bookDetailPage;
        _scenarioContext = scenarioContext;
    }

    [Then(@"I see the book details isbn is ""(.*)""")]
    public void ThenISeeTheBookDetailsIsbnIs(string isbn)
    {
        _bookDetailPage.GetIsbnAsync().Result.Should().Be(isbn);
    }

    [Then(@"I see the book details title is ""(.*)""")]
    public void ThenISeeTheBookDetailsTitleIs(string bookTitle)
    {
        _bookDetailPage.GetPageHeaderAsync().Result.Should().Be(bookTitle);
    }

    [Then(@"I see the book details author is ""(.*)""")]
    public void ThenISeeTheBookDetailsAuthorIs(string authors)
    {
        _bookDetailPage.GetAuthorsAsync().Result.Should().Be(authors);
    }

    [Then(@"I see the book details categories is ""(.*)""")]
    public void ThenISeeTheBookDetailsCategoriesIs(string categories)
    {
        _bookDetailPage.GetCategoriesAsync().Result.Should().Be(categories);
    }

    [Then(@"I see the book details description is ""(.*)""")]
    public void ThenISeeTheBookDetailsDescriptionIs(string description)
    {
        _bookDetailPage.GetDescriptionAsync().Result.Should().Be(description);
    }

    [Then(@"I see the book details copies total is ""(.*)""")]
    public void ThenISeeTheBookDetailsCopiesTotalIs(string copiesTotal)
    {
        _bookDetailPage.GetTotalCopyCountAsync().Result.Should().Be(long.Parse(copiesTotal));
    }

    [Then(@"I see the book details copies available is ""(.*)""")]
    public void ThenISeeTheBookDetailsCopiesAvailableIs(string copiesAvailable)
    {
        _bookDetailPage.GetAvailableCopyCountAsync().Result.Should().Be(long.Parse(copiesAvailable));
    }
    [Then(@"I see the book details publish year is ""(.*)""")]
    public void ThenISeeTheBookDetailsPublishYearIs(string publishYear)
    {
        _bookDetailPage.GetPublishYearAsync().Result.Should().Be(publishYear);
    }
}