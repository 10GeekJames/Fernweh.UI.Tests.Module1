namespace Fernweh.StaticTestData;
public static class LibraryTestData
{
    public static string FirstStreetLibraryName = "First Street Library";
    public static LibraryViewModel FirstStreetLibrary;
    public static Guid FirstStreetLibraryId = new Guid("89d3e762-d5c8-4b00-bec8-08dbcb693716");
    public static PhysicalAddressVOViewModel FirstStreetLibraryAddress = new()
    {
        Street1 = "123 First Street",
        Street2 = "Suite 100",
        City = "First City",
        StateProvince = "First State",
        PostalCode = "12345",
        Country = "First Country"
    };
    public static DateTime FirstStreetLibraryOpenTime = new DateTime(2021, 1, 1, 8, 0, 0);
    public static DateTime FirstStreetLibraryCloseTime = new DateTime(2021, 1, 1, 17, 0, 0);
    public static string FirstStreetLibraryNotes = "This is the first street library";

    public static string SecondStreetLibraryName = "Second Street Library";
    public static Guid SecondStreetLibraryId = new Guid("e278f635-1700-4e1e-bec9-08dbcb693716");
    public static LibraryViewModel SecondStreetLibrary;
    public static PhysicalAddressVOViewModel SecondStreetLibraryAddress = new()
    {
        Street1 = "456 Second Street",
        Street2 = "Suite 200",
        City = "Second City",
        StateProvince = "Second State",
        PostalCode = "67890",
        Country = "Second Country"
    };
    public static DateTime SecondStreetLibraryOpenTime = new DateTime(2021, 1, 1, 9, 0, 0);
    public static DateTime SecondStreetLibraryCloseTime = new DateTime(2021, 1, 1, 18, 0, 0);
    public static string SecondStreetLibraryNotes = "This is the second street library";

    public static IEnumerable<LibraryViewModel> AllLibraries;

    static LibraryTestData()
    {
        FirstStreetLibrary = new LibraryViewModel()
        {
            Id = FirstStreetLibraryId,
            Name = FirstStreetLibraryName,
            MailingAddress = FirstStreetLibraryAddress,
            Notes = FirstStreetLibraryNotes,
            OpenTime = FirstStreetLibraryOpenTime,
            CloseTime = FirstStreetLibraryCloseTime
        };
        SecondStreetLibrary = new LibraryViewModel()
        {
            Id = SecondStreetLibraryId,
            Name = SecondStreetLibraryName,
            MailingAddress = SecondStreetLibraryAddress,
            Notes = SecondStreetLibraryNotes,
            OpenTime = SecondStreetLibraryOpenTime,
            CloseTime = SecondStreetLibraryCloseTime
        };

        AllLibraries = new List<LibraryViewModel> {
            FirstStreetLibrary,
            SecondStreetLibrary
        };
    }
}
