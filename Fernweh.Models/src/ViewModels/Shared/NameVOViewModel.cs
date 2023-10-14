namespace Fernweh.Models.ViewModels;
public class NameVOViewModel
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string NameSuffix { get; set; }

    public string ToShortName()
    {
        return $"{FirstName} {LastName}".Trim();
    }
}
