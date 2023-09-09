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
    }

    public async Task<string> GetTitleAsync()
    {
        await Task.Yield();
        return await Page.TitleAsync();
    }

    public async Task GotoAsync()
    {
        await Page.GotoAsync($"{BasePath}{PagePath}");
    }

    public string GetURL()
    {
        return Page.Url;
    }
}