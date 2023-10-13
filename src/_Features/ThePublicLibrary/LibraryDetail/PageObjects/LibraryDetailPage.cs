using System.Globalization;
namespace Fernweh.BlazorClient.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryDetailPage : BasePageObject
{
    private readonly string _advertismentFrameSelector = "#advert";
    private readonly string _advertismentContentSelector = "#buy-now";
    private readonly string _libraryDetailHeaderSelector = "#library-detail-header";
    private readonly string _libraryNameSelector = "#library-name";

    private readonly string _openTimeSelector = "#open-time";
    private readonly string _closeTimeSelector = "#close-time";
    private readonly string _mailingAddressSelector = "#mailing-address";
    private readonly string _primaryPhoneSelector = "#primary-phone";
    private readonly string _primaryEmailSelector = "#primary-email";
    
    private readonly string _notesLabelSelector = ".notes-label";
    private readonly string _notesSelector = ".notes";
    

    private readonly static string _pagePath = "/thepubliclibrary/library";
    public LibraryDetailPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath) {         
        
    }
    public async Task NavigateToAsync() => await base.GotoAsync();
    public async Task<string> GetLibraryNameAsync() => await Page.Locator(_libraryNameSelector).TextContentAsync();

    public async Task GotoByIdAsync(string id) {
        await base.GotoAsync($"/{id}");
    }

    public async Task<string> GetAdvertismentContentAsync() {
        var frame = Page.FrameLocator(_advertismentFrameSelector);
        var locator = frame.Locator(_advertismentContentSelector);        
        return await locator.TextContentAsync();
    }

    public async Task<bool> IsOnPageAsync()
    {
        var foundSelector = await Page.WaitForSelectorAsync(_libraryDetailHeaderSelector);
        if(foundSelector == null) return false;
        
        return (await foundSelector.IsVisibleAsync());        
    }    

    public async Task<string> GetOpenTimeAsync() => await Page.Locator(_openTimeSelector).TextContentAsync();
    public async Task<string> GetCloseTimeAsync() => await Page.Locator(_closeTimeSelector).TextContentAsync();
    public async Task<string> GetMailingAddressAsync() => await Page.Locator(_mailingAddressSelector).TextContentAsync();
    public async Task<string> GetPrimaryPhoneAsync() => await Page.Locator(_primaryPhoneSelector).TextContentAsync();
    public async Task<string> GetPrimaryEmailAsync() => await Page.Locator(_primaryEmailSelector).TextContentAsync();    
    public async Task<string> GetNotesLabelAsync() => await Page.Locator(_notesLabelSelector).TextContentAsync();
    public async Task<string> GetNotesAsync() => await Page.Locator(_notesSelector).TextContentAsync();
    
    
}