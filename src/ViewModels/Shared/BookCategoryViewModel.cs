// ag=yes
namespace Fernweh.BlazorClient.UITests.ViewModels; 
public partial class BookCategoryViewModel : BaseViewModel
{ 

     public string Title { get; set; } = String.Empty;
     public List<BookCategoryViewModel> BookCategories { get; set; } = new();


} 
        