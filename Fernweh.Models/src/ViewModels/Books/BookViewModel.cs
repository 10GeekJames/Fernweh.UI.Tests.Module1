namespace Fernweh.Models.ViewModels;
public partial class BookViewModel : BaseViewModel
{

     public IsbnVOViewModel Isbn { get; set; }
     public string Title { get; set; } = String.Empty;
     public string Description { get; set; } = String.Empty;
     public string PublishYear { get; set; }
     public long PageCount { get; set; }
     public List<AuthorViewModel> Authors { get; set; } = new();
     public List<BookCategoryViewModel> BookCategories { get; set; } = new();
     public List<BookCopyViewModel> BookCopies { get; set; } = new();

     public string AuthorsList => Authors.Count == 0 ? "" : String.Join(", ", Authors.Select(rs => rs.Name.ToShortName()));
     public string CategoriesList => BookCategories.Count == 0 ? "" : String.Join(", ", BookCategories.Select(rs => rs.Title));
     public long CopiesCount { get; set; }
     public long AvailableCopiesCount {get;set;}

     public BookViewModel(){          
     }
     public void AddBookCopy(BookCondition condition)
     {
          var bookCopy = new BookCopyViewModel { Book = this, Condition = condition };
          BookCopies.Add(bookCopy);
          CopiesCount++;
          if(bookCopy.Condition != BookCondition.Destroyed) {
               AvailableCopiesCount++;
          }
     }
}
