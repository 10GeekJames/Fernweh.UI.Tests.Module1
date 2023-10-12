namespace Fernweh.BlazorClient.UITests;
public abstract class BasePageObject
{
    public virtual string PagePath { get; set; } = "";
    public readonly string BasePath = "";

    protected IPage Page { get; set; }
    protected AppConfig AppConfig { get; set; }    

    public BasePageObject(IPage page, AppConfig appConfig, string pagePath)
    {
        AppConfig = appConfig;
        Page = page;        
        PagePath = pagePath;
        BasePath = $"{appConfig.TestUrl}{BasePath}";

        Page.WaitForLoadStateAsync(LoadState.NetworkIdle).GetAwaiter().GetResult();
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