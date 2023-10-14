namespace Fernweh.BlazorClient.UITests.ValueObjects;
public class DigitalAddressVOViewModel
{
    public DigitalAddressType Type { get; set; }
    public long PhoneNumber { get; set; }
    public string Description { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    private DigitalAddressVOViewModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
    public DigitalAddressVOViewModel(DigitalAddressType type, long phoneNumber, string description)
    {
        Type = type;
        PhoneNumber = phoneNumber;
        Description = description;
    }
}
