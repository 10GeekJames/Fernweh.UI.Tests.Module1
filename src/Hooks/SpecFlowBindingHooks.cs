using System.Threading.Tasks;
using System.Diagnostics;
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

    [AfterTestRun]
    static public async Task RunLivingDocReports()
    {
        /*
        RunLivingDocReport1();
        RunLivingDocReport2();
        */
    }

    static void RunLivingDocReport1()
    {
        var process = new Process();
        process.StartInfo.FileName = "livingdoc";
        process.StartInfo.Arguments = "feature-folder ./ -t ./bin/Debug/net7.0/TestExecution.json --output TestFeatureReport.html";
        process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
        process.Start();
        process.WaitForExit();
    }
    static void RunLivingDocReport2()
    {
        var process = new Process();
        process.StartInfo.FileName = "livingdoc";
        process.StartInfo.Arguments = "test-assembly ./bin/Debug/net7.0/Fernweh.BlazorClient.UITests.dll  --output TestAssemblyReport.html";
        process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
        process.Start();
        process.WaitForExit();

    }

}
