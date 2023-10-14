namespace Fernweh.Models.ViewModels;
public abstract class BaseViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
}

