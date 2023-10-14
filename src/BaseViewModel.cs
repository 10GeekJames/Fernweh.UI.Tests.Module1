namespace Fernweh.BlazorClient.UITests;
public abstract class BaseViewModel
{
    public Guid Id { get; set; }
    public BaseViewModel() { 
        Id = Guid.NewGuid();
    }
}
