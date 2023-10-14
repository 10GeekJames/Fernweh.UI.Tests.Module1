namespace Fernweh.Models.ViewModels;
public partial class BookCategoryViewModel : BaseViewModel
{ 
     public string Title { get; set; } = String.Empty;
     public List<BookCategoryViewModel> BookCategories { get; set; } = new();
}