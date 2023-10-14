namespace Fernweh.StaticTestData;
public static class AuthorTestData
{
    public static NameVOViewModel AuthorJohnWriterName = new() { FirstName = "John", LastName = "Writer" };
    public static NameVOViewModel AuthorSallyTyperName = new() { FirstName = "Sally", LastName = "Typer" };
    public static NameVOViewModel AuthorBishopKnightName = new() { FirstName = "Bishop", LastName = "Knight" };
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
