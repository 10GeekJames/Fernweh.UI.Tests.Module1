namespace Fernweh.UITests.Features.FernwehRoot.Counter;

public class CounterPage : BasePageObject {

    private readonly string _counterValueSelector = "#current-count";
    private readonly string _incrementButtonSelector = "#increment-plus";

    private static readonly string _pagePath = "/counter";

    public CounterPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) { }

    
    public async Task IncrementValueAsync() => await IncrementButtonLocator.ClickAsync();
    public async Task<int> GetIncrementValueAsync() => int.Parse((await CounterValueLocator.TextContentAsync()) ?? "-1"); 
    
    public async Task<bool> IsOnPageAsync() {
        await CounterValueLocator.WaitForAsync();
        return await CounterValueLocator.IsVisibleAsync();
    }

    private ILocator CounterValueLocator => Page.Locator(_counterValueSelector);
    private ILocator IncrementButtonLocator => Page.Locator(_incrementButtonSelector);

}