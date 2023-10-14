namespace Fernweh.BlazorClient.UITests.Configurations;
public class AppConfig
{
    public string TestUrl { get; set; } = "";
        
    public BrowserTypeLaunchOptions BrowserTypeLaunchOptions { get; set; } = new BrowserTypeLaunchOptions();
    
}
