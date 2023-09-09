namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.BookDetail;

[Binding]
public class BookDetailSteps : Steps
{
    private readonly BookDetailPage _bookDetailPage;

    public BookDetailSteps(BookDetailPage bookDetailPage)
    {
        _bookDetailPage = bookDetailPage;
    }

    [StepDefinition(@"we navigate to the bookDetail page")]
    public async Task WeNavigateToTheBookDetailPage()
    {
        await _bookDetailPage.GotoAsync();
    }

    [StepDefinition(@"we are on the bookDetail page")]
    public async Task WeAreOnTheBookDetailPage()
    {
        (await _bookDetailPage.IsOnPageAsync()).Should().BeTrue();
    }
    
    [StepDefinition(@"we bookDetail for (.*)")]
    public async Task WeBookDetailFor(string bookDetailValue)
    {
        await _bookDetailPage.BookDetailAsync(bookDetailValue);
    }

    [StepDefinition(@"the bookDetail value is (.*)")]
    public async Task TheBookDetailValueIs(string bookDetailValue)
    {
        (await _bookDetailPage.GetBookDetailValueAsync()).Should().Be(bookDetailValue);
    }
    
    
}