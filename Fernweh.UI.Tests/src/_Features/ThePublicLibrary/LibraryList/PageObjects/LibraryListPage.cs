using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryListPage : BasePageObject
{
    public readonly static string _pagePath = "/thepubliclibrary/alllibrarys"; // https://fernwehs.com/thepubliclibrary/alllibrarys

    private ILocator _libraryListTitleLocator => Page.Locator("#all-librarys-static-table-header");
    private ILocator _libraryListLocator => Page.Locator("#all-librarys-static-table");    

    public LibraryListPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
        
    public async Task SelectLibraryByNameAsync(string libraryName) { 
        var libraryLocator = SelectLibraryLocator(libraryName);
        var libraryLinkFromCardLocator = libraryLocator.Locator("a");
        await libraryLinkFromCardLocator.ClickAsync();
    }
    public async Task<string> GetLibraryNameFromCardAsync(string libraryName)
    {
        var libraryLocator = SelectLibraryLocator(libraryName);
        var libraryNameFromCardLocator = libraryLocator.Locator("h4");
        return await libraryNameFromCardLocator.TextContentAsync() ?? string.Empty;        
    }
    public async Task<bool> IsOnPageAsync()
    {   
        await _libraryListTitleLocator.WaitForAsync();
        return await _libraryListTitleLocator.IsVisibleAsync();
    }

    private ILocator SelectLibraryLocator (string libraryName) => Page.Locator($"a:has-text('{libraryName}')");
}