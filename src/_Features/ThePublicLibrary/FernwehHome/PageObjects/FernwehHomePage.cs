using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.FernwehHome;

public class FernwehHomePage : BasePageObject
{

    private readonly string _fernwehHomeValueSelector = "#fernwehHome-value";
    private readonly string _submitFernwehHomeSelector = "#fernwehHome-submit";

    private readonly static string _pagePath = "/fernwehHome";
    public FernwehHomePage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }
    public async Task NavigateToAsync() => await base.GotoAsync();

    public async Task<string> GetFernwehHomeValueAsync() => await FernwehHomeValueLocator.TextContentAsync() ?? ""; 
    public async Task SetFernwehHomeValueAsync(string fernwehHomeValue) => await FernwehHomeValueLocator.TypeAsync(fernwehHomeValue);
    public async Task SubmitFernwehHomeAsync() => await SubmitFernwehHomeLocator.ClickAsync();
    public async Task FernwehHomeAsync(string fernwehHomeValue)
    {
        await SetFernwehHomeValueAsync(fernwehHomeValue);
        await SubmitFernwehHomeAsync();
    }

    public async Task<bool> IsOnPageAsync()
    {
        return await Page.IsVisibleAsync(_fernwehHomeValueSelector);
    }

    private ILocator FernwehHomeValueLocator => Page.Locator(_fernwehHomeValueSelector);
    private ILocator SubmitFernwehHomeLocator => Page.Locator(_submitFernwehHomeSelector);

}