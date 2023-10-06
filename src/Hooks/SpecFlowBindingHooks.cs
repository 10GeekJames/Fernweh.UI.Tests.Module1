using System.Reflection;
namespace AddToMeeting.UITests.Hooks;
[Binding]
public class SpecFlowBindingHooks
{
    private readonly IObjectContainer _objectContainer;

    public SpecFlowBindingHooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public async Task SetupWebDriver()
    {
        var builder = new ConfigurationBuilder();
        var env = Environment.GetEnvironmentVariable("env") ?? "qa";
        var appConfigFile = $"./Configurations/appsettings.{env}.json";

        builder
            .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? "");

        builder
            .AddJsonFile(appConfigFile, optional: false, reloadOnChange: true);

        var defaultConfig = builder.Build();
        var appConfig = defaultConfig.Get<AppConfig>();

        this._objectContainer.RegisterInstanceAs<AppConfig>(appConfig!);

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(appConfig.BrowserTypeLaunchOptions);
        var page = await browser.NewPageAsync();

        this._objectContainer.RegisterInstanceAs<IPlaywright>(playwright);
        this._objectContainer.RegisterInstanceAs<IBrowser>(browser);
        this._objectContainer.RegisterInstanceAs<IPage>(page);

    }

    [AfterScenario]
    public async Task CleanupWebDriver()
    {
        var browser = this._objectContainer.Resolve<IBrowser>();
        await browser.CloseAsync();
        var playwright = this._objectContainer.Resolve<IPlaywright>();
        playwright.Dispose();
    }    
}
