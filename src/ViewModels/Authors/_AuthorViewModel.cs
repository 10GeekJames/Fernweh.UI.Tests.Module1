// ag=yes
namespace Fernweh.BlazorClient.UITests.ViewModels;
public partial class AuthorViewModel : BaseViewModel
{
     public NameVOViewModel Name { get; set; }
     public List<BookViewModel> Books { get; set; } = new();
}
