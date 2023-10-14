// ag=yes
namespace Fernweh.BlazorClient.UITests.ViewModels; 
public partial class BookCopyViewModel : BaseViewModel
{ 

     public Guid BookId { get; set; }
     public BookViewModel Book { get; set; } //RemoveMap
     public int CopySequence { get; set; }
     public BookCondition Condition { get; set; } = BookCondition.New;


} 
        