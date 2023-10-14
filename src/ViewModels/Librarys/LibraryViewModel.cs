// ag=yes
namespace Fernweh.BlazorClient.UITests.ViewModels; 
public partial class LibraryViewModel : BaseViewModel
{ 

     public string Name { get; set; } = String.Empty;
     public PhysicalAddressVOViewModel? MailingAddress { get; set; } = null;
     public DigitalAddressVOViewModel? PrimaryPhone { get; set; } = null;
     public DigitalAddressVOViewModel? PrimaryEmail { get; set; } = null;
     public DateTime? OpenTime { get; set; } = null;
     public DateTime? CloseTime { get; set; } = null;
     public string Notes { get; set; } = "";
     public List<BookViewModel> Books { get; set; } = new();

     public string? OpenTimeShortFormat => OpenTime?.ToString("hh:mm tt") ?? null; 

     public string? CloseTimeShortFormat => CloseTime?.ToString("hh:mm tt") ?? null; 


} 
        