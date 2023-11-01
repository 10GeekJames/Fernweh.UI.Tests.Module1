namespace Fernweh.Models.ViewModels;
public class DigitalAddressVOViewModel
{
    public DigitalAddressVOViewModel() { }
    public DigitalAddressVOViewModel(string initFromString)
    {
        if (string.IsNullOrEmpty(initFromString)) return;
        if (initFromString.Replace(" ", "") == ",,") return;
        var addressParts = initFromString.Split(',');
        if (addressParts.Length > 2)
        {
            Type = (DigitalAddressType)Enum.Parse(typeof(DigitalAddressType), addressParts[0].Trim());
            PhoneNumber = long.TryParse(addressParts[1].Trim(), out var _) ? long.Parse(addressParts[1].Trim()) : null;
            Description = addressParts[2].Trim();
        }
        else if (addressParts.Length > 0)
        {
            throw new ArgumentException($"DigitalAddressVOViewModel initFromString must have at least 3 parts, found {addressParts.Length} parts, '{initFromString}'");
        }        
    }
    public DigitalAddressType Type { get; set; }
    public long? PhoneNumber { get; set; } = null;
    public string Description { get; set; } = "";

    public override string ToString()
    {
        if(PhoneNumber == null && string.IsNullOrEmpty(Description)) {
            return "";
        }
        return $"{Type}, {PhoneNumber}, {Description}";
    }
}
