using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryListPage : BasePageObject
{
    public readonly static string _pagePath = "/thepubliclibrary/alllibrarys";

    private ILocator _libraryListTitleLocator => Page.Locator("#all-librarys-static-table-header");
    private ILocator _libraryListLocator => Page.Locator("#all-librarys-static-table");    
    
    public LibraryListPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    
    
    public async Task SelectLibraryByName(string libraryName) { 
        var libraryLocator = SelectLibraryLocator(libraryName);
        await libraryLocator.ClickAsync();
    }
    public async Task<string> GetLibraryNameByName(string libraryName)
    {
        var libraryLocator = SelectLibraryLocator(libraryName);
        return await libraryLocator.TextContentAsync() ?? string.Empty;        
    }
    
    public async Task<bool> IsOnPageAsync()
    {   
        _libraryListTitleLocator.WaitForAsync();
        return (await _libraryListTitleLocator.IsVisibleAsync());
    }

    //private ILocator SelectLibraryLocator (string libraryName) => Page.Locator($"a:has-text('{libraryName}')");
    private ILocator SelectLibraryLocator (string libraryName) => Page.GetByTestId(libraryName);

}