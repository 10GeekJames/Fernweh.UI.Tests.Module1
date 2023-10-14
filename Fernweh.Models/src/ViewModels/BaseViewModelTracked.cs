namespace Fernweh.Models.ViewModels;
public abstract class BaseViewModelTracked
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}
