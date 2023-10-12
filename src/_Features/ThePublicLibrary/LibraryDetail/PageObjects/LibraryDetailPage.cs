using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryDetailsPage : BasePageObject
{

    private readonly string _libraryDetailHeaderSelector = "#library-detail-header";
    private readonly string _libraryNameSelector = "#library-name";
    private readonly static string _pagePath = "/thepubliclibrary/library";
    public LibraryDetailsPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();
    public async Task<string> GetLibraryNameAsync() => await Page.Locator(_libraryNameSelector).TextContentAsync();

    public async Task GotoByIdAsync(string id) {
        await base.GotoAsync($"/{id}");
    }

    public async Task<bool> IsOnPageAsync()
    {
        var foundSelector = await Page.WaitForSelectorAsync(_libraryDetailHeaderSelector);
        if(foundSelector == null) return false;
        
        return (await foundSelector.IsVisibleAsync());        
    }    
}