using System.Globalization;
namespace Fernweh.UITests.Features.ThePublicLibrary.LibraryDetail;

public class LibraryDetailPage : BasePageObject
{
    private IFrameLocator _advertismentFrameLocator => Page.FrameLocator("#advert");
    private ILocator _advertismentContentLocator => _advertismentFrameLocator.Locator("#buy-now");
    private ILocator _libraryDetailHeaderLocator => Page.Locator("#library-detail-header");
    private ILocator _libraryNameLocator => Page.Locator("#library-name");
    private ILocator _openTimeLocator => Page.Locator("#open-time");
    private ILocator _closeTimeLocator => Page.Locator("#close-time");
    private ILocator _mailingAddressLocator => Page.Locator("#mailing-address");
    private ILocator _primaryPhoneLocator => Page.Locator("#primary-phone");
    private ILocator _primaryEmailLocator => Page.Locator("#primary-email");
    private ILocator _notesLabelLocator => Page.Locator(".notes-label");
    private ILocator _notesLocator => Page.Locator(".notes");

    private readonly static string _pagePath = "/thepubliclibrary/library";
    public LibraryDetailPage(IPage page, AppConfig appConfig) : base(page, appConfig, _pagePath)
    {

    }
    public async Task<string?> GetLibraryNameAsync() => await _libraryNameLocator.TextContentAsync();

    public async Task GotoByIdAsync(string id)
    {
        await base.GotoAsync($"/{id}");
    }

    public async Task<string?> GetAdvertismentContentAsync()
    {
        return await _advertismentContentLocator.TextContentAsync();
    }

    public async Task<bool> IsOnPageAsync()
    {
        await _libraryDetailHeaderLocator.WaitForAsync();
        return await _libraryDetailHeaderLocator.IsVisibleAsync();
    }

    public async Task<string?> GetOpenTimeAsync() => await _openTimeLocator.TextContentAsync();
    public async Task<string?> GetCloseTimeAsync() => await _closeTimeLocator.TextContentAsync();
    public async Task<string?> GetMailingAddressAsync() => await _mailingAddressLocator.TextContentAsync();
    public async Task<string?> GetPrimaryPhoneAsync() => await _primaryPhoneLocator.TextContentAsync();
    public async Task<string?> GetPrimaryEmailAsync() => await _primaryEmailLocator.TextContentAsync();
    public async Task<string?> GetNotesLabelAsync() => await _notesLabelLocator.TextContentAsync();
    public async Task<string?> GetNotesAsync() => await _notesLocator.TextContentAsync();

}