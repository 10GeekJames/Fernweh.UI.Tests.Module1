namespace Fernweh.UITests.Features.FernwehRoot.Counter;

public class CounterPage : BasePageObject
{
    private ILocator _counterValueLocator => Page.Locator("#current-count");
    private ILocator _incrementButtonLocator => Page.Locator("#increment-plus");

    private static readonly string _pagePath = "/counter";

    public CounterPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }


    public async Task IncrementValueAsync() => await _incrementButtonLocator.ClickAsync();
    public async Task<int> GetIncrementValueAsync() => int.Parse((await _counterValueLocator.TextContentAsync()) ?? "-1");

    public async Task<bool> IsOnPageAsync()
    {
        await _counterValueLocator.WaitForAsync();
        return await _counterValueLocator.IsVisibleAsync();
    }
}