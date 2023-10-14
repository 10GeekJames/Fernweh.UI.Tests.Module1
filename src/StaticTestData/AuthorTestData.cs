namespace Fernweh.BlazorClient.UITests.TestData;
public static class AuthorTestData
{
    public static NameVOViewModel AuthorJohnWriterName = new("John", "Writer");
    public static NameVOViewModel AuthorSallyTyperName = new("Sally", "Typer");
    public static NameVOViewModel AuthorBishopKnightName = new("Bishop", "Knight");
    public static AuthorViewModel AuthorJohnWriter;
    public static AuthorViewModel AuthorSallyTyper;
    public static AuthorViewModel AuthorBishopKnight;
    public static IEnumerable<AuthorViewModel> AllAuthors;
    static AuthorTestData()
    {
        AuthorJohnWriter = new() { Name = AuthorJohnWriterName };
        AuthorSallyTyper = new() { Name = AuthorSallyTyperName };
        AuthorBishopKnight = new() { Name = AuthorBishopKnightName };
        AllAuthors = new List<AuthorViewModel> {
            AuthorJohnWriter,
            AuthorSallyTyper,
            AuthorBishopKnight
        }
        .AsReadOnly();
    }
}
