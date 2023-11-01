using System.Globalization;
using System.Net.NetworkInformation;
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

    public async Task<bool> IsOnPageAsync()
    {
        await _libraryDetailHeaderLocator.WaitForAsync();
        return await _libraryDetailHeaderLocator.IsVisibleAsync();
    }

    public async Task<string?> GetLibraryNameAsync() => await _libraryNameLocator.TextContentAsync();
    public async Task<string?> GetAdvertismentContentAsync() => await _advertismentContentLocator.TextContentAsync();
    public async Task<DateTime?> GetOpenTimeAsync() => DateTime.TryParse(await _openTimeLocator.TextContentAsync(), out var _) ? DateTime.Parse(await _openTimeLocator.TextContentAsync()) : null;
    public async Task<DateTime?> GetCloseTimeAsync() => DateTime.TryParse(await _closeTimeLocator.TextContentAsync(), out var _) ? DateTime.Parse(await _closeTimeLocator.TextContentAsync()) : null;
    public async Task<string> GetMailingAddressAsync()
    {
        var mailingAddressValue = await _mailingAddressLocator.InputValueAsync();

        if (string.IsNullOrEmpty(mailingAddressValue)) return "";
        if (mailingAddressValue.Replace(" ", "") == ",,,,,") return "";

        return mailingAddressValue;
    }
    public async Task<string> GetPrimaryPhoneAsync()
    {
        var primaryPhoneValue = await _primaryPhoneLocator.InputValueAsync();
        if (string.IsNullOrEmpty(primaryPhoneValue)) return "";
        return primaryPhoneValue;
    }
    public async Task<string> GetPrimaryEmailAsync()
    {
        var primaryEmailValue = await _primaryEmailLocator.InputValueAsync();

        if (string.IsNullOrEmpty(primaryEmailValue)) return "";
        if (primaryEmailValue.Trim() == "") return "";

        return primaryEmailValue;
    }
    public async Task<string?> GetNotesLabelAsync() => await _notesLabelLocator.TextContentAsync();
    public async Task<string?> GetNotesAsync() => await _notesLocator.TextContentAsync();
    public async Task<LibraryViewModel> GetAsViewModelAsync()
    {
        var name = await GetLibraryNameAsync();
        var openTime = await GetOpenTimeAsync();
        var closeTime = await GetCloseTimeAsync();
        var mailingAddress = await GetMailingAddressAsync();
        var primaryPhone = await GetPrimaryPhoneAsync();
        var primaryEmail = await GetPrimaryEmailAsync();
        var notes = await GetNotesAsync();
        return new LibraryViewModel
        {
            Name = name,
            OpenTime = openTime,
            CloseTime = closeTime,
            MailingAddress = new PhysicalAddressVOViewModel(mailingAddress),
            PrimaryPhone = new DigitalAddressVOViewModel(primaryPhone),
            PrimaryEmail = new DigitalAddressVOViewModel(primaryEmail),
            Notes = notes
        };
    }
}