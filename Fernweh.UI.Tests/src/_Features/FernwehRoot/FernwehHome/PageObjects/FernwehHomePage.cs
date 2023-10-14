using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.FernwehHome;

public class FernwehHomePage : BasePageObject
{
    public readonly static string TITLE = "Fernweh";    
    public readonly static string _pagePath = "";    
    private ILocator _fernwehTitleValueLocator => Page.GetByTestId("title");    
    
    public FernwehHomePage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    
    public async Task<string> GetFernwehTitleValueAsync() => await _fernwehTitleValueLocator.TextContentAsync() ?? ""; 
    
    public async Task<bool> IsOnPageAsync()
    {
        await _fernwehTitleValueLocator.WaitForAsync();
        var titleValue = await _fernwehTitleValueLocator.TextContentAsync();
        return titleValue == TITLE;
    } 
}