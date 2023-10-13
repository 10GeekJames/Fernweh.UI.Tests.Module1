using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryListPage : BasePageObject
{
    private readonly string _libraryListTitleSelector = "all-librarys-static-table-header";
    private readonly string _libraryListSelector = "#all-librarys-static-table";
    private readonly static string _pagePath = "/thepubliclibrary/alllibrarys";
    public LibraryListPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();

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
        var foundSelector = await Page.WaitForSelectorAsync(_libraryListTitleSelector);
        if(foundSelector == null) return false;

        return (await foundSelector.IsVisibleAsync());
    }

    //private ILocator SelectLibraryLocator (string libraryName) => Page.Locator($"a:has-text('{libraryName}')");
    private ILocator SelectLibraryLocator (string libraryName) => Page.GetByTestId(libraryName);

}