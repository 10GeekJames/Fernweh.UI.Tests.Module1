namespace Fernweh.BlazorClient.UITests.ValueObjects;
public class NameVOViewModel
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string NameSuffix { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    private NameVOViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    public NameVOViewModel(string firstName, string lastName, string middleName = "", string nameSuffix = "")
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        NameSuffix = nameSuffix;
    }

}
