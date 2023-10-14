namespace Fernweh.Models.ViewModels;
public partial class BookViewModel : BaseViewModel
{

     public IsbnVOViewModel Isbn { get; set; }
     public string Title { get; set; } = String.Empty;
     public string Description { get; set; } = "No Description";
     public int PublicationYear { get; set; }
     public int PageCount { get; set; }
     public List<AuthorViewModel> Authors { get; set; } = new();
     public List<BookCategoryViewModel> BookCategories { get; set; } = new();
     public List<BookCopyViewModel> BookCopies { get; set; } = new();

     public string AuthorsList => Authors.Count == 0 ? "" : String.Join(", ", Authors.Select(rs => rs.Name.ToShortName()));
     public string CategoriesList => BookCategories.Count == 0 ? "No Category" : String.Join(", ", BookCategories.Select(rs => rs.Title));
     public int CopiesCount => BookCopies.Count();
     public int AvailableCopiesCount => BookCopies.Count(bc => bc.Condition != BookCondition.Destroyed);

     
     public void AddBookCopy(BookCondition condition)
     {
          BookCopies.Add(new() { Book = this, Condition = condition });
     }
}
