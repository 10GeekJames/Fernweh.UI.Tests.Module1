namespace Fernweh.Models.ViewModels;
public class PhysicalAddressVOViewModel
{
    public PhysicalAddressVOViewModel() {}
    public PhysicalAddressVOViewModel(string initFromString) {
        if(string.IsNullOrEmpty(initFromString)) return;
        if (initFromString.Replace(" ", "") == ",,,,,") return;

        var addressParts = initFromString.Split(',');
        if(addressParts.Length > 4) {
            Street1         = addressParts[0].Trim();
            Street2         = addressParts[1].Trim();
            City            = addressParts[2].Trim();
            StateProvince   = addressParts[3].Trim();
            PostalCode      = addressParts[4].Trim();
            Country         = addressParts[5].Trim();
        } else if (addressParts.Length > 0)  {
            throw new ArgumentException($"PhysicalAddressVOViewModel initFromString must have 5 parts, found {addressParts.Length} parts, '{initFromString}'");
        }
    }
    public string Street1 { get; set; } = "";
    public string Street2 { get; set; } = "";
    public string City { get; set; } = "";
    public string StateProvince { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string Country { get; set; } = "";

    public override string ToString()
    {
        if(string.IsNullOrEmpty(Street1)) return "";
        return $"{Street1}, {Street2}, {City}, {StateProvince}, {PostalCode}, {Country}";
    }
}
