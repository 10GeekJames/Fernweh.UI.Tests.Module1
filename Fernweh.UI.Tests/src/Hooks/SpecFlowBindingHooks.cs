using System.Reflection.Metadata.Ecma335;
using System.Reflection;
namespace AddToMeeting.UITests.Hooks;
[Binding]
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
[assembly: CollectionBehavior(MaxParallelThreads = 3)]
public class SpecFlowBindingHooks
{
    private readonly IObjectContainer _objectContainer;

    public SpecFlowBindingHooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }
    
    [BeforeScenario]
    public async Task SetupWebDriver(ScenarioContext scenarioContext)
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
        
        scenarioContext.Add("Library1", new Guid("89d3e762-d5c8-4b00-bec8-08dbcb693716"));
        scenarioContext.Add("Library2", new Guid("e278f635-1700-4e1e-bec9-08dbcb693716"));

        //scenarioContext.Add("Book1", new BookViewModel());
        foreach(var book in BookTestData.AllBooks) {
            scenarioContext.Add(book.Isbn.Isbn, book);
        }

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
