namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.BookDetail;

[Binding]
public class BookDetailSteps : Steps
{
    private readonly BookDetailsPage _bookDetailsPage;

    public BookDetailSteps(BookDetailsPage bookDetailsPage)
    {
        _bookDetailsPage = bookDetailsPage;
    }

    [StepDefinition(@"we navigate to the book details page")]
    public async Task WeNavigateToTheBookDetailsPage()
    {
        await _bookDetailsPage.GotoAsync();
    }

    [StepDefinition(@"we are on the book details page")]
    public async Task WeAreOnTheBookDetailsPage()
    {
        (await _bookDetailsPage.IsOnPageAsync()).Should().BeTrue();
    }
    
    [StepDefinition(@"we book details for (.*)")]
    public async Task WeBookDetailFor(string bookDetailValue)
    {
        await _bookDetailsPage.BookDetailAsync(bookDetailValue);
    }

    [StepDefinition(@"the book details value is (.*)")]
    public async Task TheBookDetailValueIs(string bookDetailValue)
    {
        (await _bookDetailsPage.GetBookDetailValueAsync()).Should().Be(bookDetailValue);
    }  
    
}