namespace Fernweh.StaticTestData;
public static class BookTestData
{
    public static BookViewModel BookTheWildSide;
    public static BookViewModel BookJumpingForJax;
    public static BookViewModel BookJuniperRising;
    public static BookViewModel BookAlfradoTheGreat;
    public static BookViewModel BookManyCopies;
    public static BookViewModel BookNoCopies;
    public static BookViewModel BookWithCategories;
    public static BookViewModel BookOfThreeAuthors;
    public static BookViewModel BookOfFantasy;

    public static BookCategoryViewModel BookCategoryFiction;
    public static BookCategoryViewModel BookCategoryNonFiction;
    public static BookCategoryViewModel BookCategoryScify;
    public static BookCategoryViewModel BookCategoryFantasy;

    public static IEnumerable<BookViewModel> AllBooks;

    static BookTestData()
    {
        BookCategoryFiction = new() { Title = "Fiction" };
        BookCategoryNonFiction = new() { Title = "Non-Fiction" };
        BookCategoryScify = new() { Title = "Scify" };
        BookCategoryFantasy = new() { Title = "Fantasy" };

        BookTheWildSide = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-6" },
            Title = "The Wild Side",
            PublishYear = "1982",
            PageCount = 100,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorJohnWriter }
        };

        BookTheWildSide.AddBookCopy(BookCondition.Poor);
        BookTheWildSide.AddBookCopy(BookCondition.Good);

        BookJumpingForJax = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-7" },
            Title = "Jumping for Jax",
            PublishYear = "1983",
            PageCount = 200,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper }
        };
        BookJumpingForJax.AddBookCopy(BookCondition.Good);

        BookJuniperRising = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-8" },
            Title = "Juniper Rising",
            PublishYear = "1984",
            PageCount = 300,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorBishopKnight }
        };
        BookJuniperRising.AddBookCopy(BookCondition.Good);

        BookAlfradoTheGreat = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-9" },
            Title = "Alfrado The Great",
            PublishYear = "1985",
            PageCount = 400,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorJohnWriter }
        };
        BookAlfradoTheGreat.AddBookCopy(BookCondition.Good);

        BookNoCopies = new()
        {
            Isbn = new() { Isbn = "978-4-00-000441-1" },
            Title = "Book No Copies",
            PublishYear = "1981",
            PageCount = 110,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper }
        };

        BookManyCopies = new()
        {
            Isbn = new() { Isbn = "978-5-00-000001-1" },
            Title = "Book Many Copies",
            PublishYear = "1981",
            PageCount = 110,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper }
        };
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Destroyed);

        BookOfThreeAuthors = new()
        {
            Isbn = new() { Isbn = "978-6-00-000331-2" },
            Title = "Book of Three AuthorViewModels",
            PublishYear = "1981",
            PageCount = 120,
            Authors = new List<AuthorViewModel> { AuthorTestData.AuthorBishopKnight, AuthorTestData.AuthorJohnWriter,
        AuthorTestData.AuthorSallyTyper }
        };
        BookOfThreeAuthors.AddBookCopy(BookCondition.Good);

        BookWithCategories = new()
        {
            Isbn = new() { Isbn = "978-7-00-000131-1" },
            Title = "Book With Categories",
            PublishYear = "1981",
            PageCount = 110,
            Authors = new List<AuthorViewModel> { AuthorTestData.AuthorSallyTyper },
            BookCategories = new List<BookCategoryViewModel> { BookCategoryFantasy, BookCategoryFiction }
        };
        BookWithCategories.AddBookCopy(BookCondition.Good);
        BookWithCategories.AddBookCopy(BookCondition.Fair);
        BookWithCategories.AddBookCopy(BookCondition.Poor);

        BookOfFantasy = new()
        {
            Isbn = new() { Isbn = "978-8-00-000214-6" },
            Title = "Book Of Fantasy",
            PublishYear = "1981",
            PageCount = 110,
            Authors = new List<AuthorViewModel> { AuthorTestData.AuthorSallyTyper },
            BookCategories = new List<BookCategoryViewModel> { BookCategoryFantasy }
        };

        AllBooks = new List<BookViewModel> {
            BookTheWildSide,
            BookJumpingForJax,
            BookJuniperRising,
            BookAlfradoTheGreat,
            BookManyCopies,
            BookNoCopies,
            BookWithCategories,
            BookOfThreeAuthors,
            BookOfFantasy
        };
    }
}
