namespace Fernweh.BlazorClient.UITests;
public abstract class BasePageObject
{
    public virtual string PagePath { get; set; } = "";
    public readonly string BasePath = "";

    protected IPage Page { get; set; }
    protected AppConfig AppConfig { get; set; }    

    private readonly string _loadingDataSelector = ".loading-data";

    public BasePageObject(IPage page, AppConfig appConfig, string pagePath)
    {
        AppConfig = appConfig;
        Page = page;        
        PagePath = pagePath;
        BasePath = $"{appConfig.TestUrl}{BasePath}";

        Page.WaitForLoadStateAsync(LoadState.NetworkIdle).GetAwaiter().GetResult();
        var loadingIndicatorCheckCount = 0;
        var loadingIndicatorIsVisible = Page.IsVisibleAsync(_loadingDataSelector).GetAwaiter().GetResult();
        while(loadingIndicatorIsVisible || loadingIndicatorCheckCount > 20)
        {            
            Thread.Sleep(300);
            loadingIndicatorIsVisible = Page.IsVisibleAsync(_loadingDataSelector).GetAwaiter().GetResult();
            loadingIndicatorCheckCount++;
        }
    }

    public async Task<string> GetTitleAsync()
    {
        await Task.Yield();
        return await Page.TitleAsync();
    }

    public async Task GotoAsync(string append = "")
    {
        await Page.GotoAsync($"{BasePath}{PagePath}{append}");
    }

    public string GetURL()
    {
        return Page.Url;
    }
}