namespace Fernweh.Models.ViewModels;

public class BookSearchResultViewModel
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";
    public string Category { get; set; } = "";

    public IEnumerable<BookCopyViewModel> BookCopies { get; set; } = new List<BookCopyViewModel>();
    public int TotalCount => BookCopies.Count();

    public override string ToString()
    {
        return $"{Isbn} {Title} {Author} {Category}";
    }
}