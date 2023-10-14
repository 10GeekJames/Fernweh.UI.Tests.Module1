// ag=yes
namespace Fernweh.BlazorClient.UITests.ViewModels; 

public class BookSearchViewModel
{ 
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";

    public override string ToString() {
        return $"{Isbn} {Title} {Author}";
    }
} 