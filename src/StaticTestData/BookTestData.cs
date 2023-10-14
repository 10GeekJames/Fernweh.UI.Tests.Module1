namespace Fernweh.BlazorClient.UITests.TestData;
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

        //BookTheWildSide = new(new("978-0-00-000000-6"), new List<AuthorViewModel>() { AuthorTestData.AuthorJohnWriter }, null, null, "The Wild Side", 1982, 100);
        BookTheWildSide = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-6" },
            Title = "The Wild Side",
            PublicationYear = 1982,
            PageCount = 100,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorJohnWriter },
            BookCategories = new List<BookCategoryViewModel>() { BookCategoryFiction }
        };

        BookTheWildSide.AddBookCopy(BookCondition.Poor);
        BookTheWildSide.AddBookCopy(BookCondition.Good);

        BookJumpingForJax = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-7" },
            Title = "Jumping for Jax",
            PublicationYear = 1983,
            PageCount = 200,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper },
            BookCategories = new List<BookCategoryViewModel>() { BookCategoryFiction }
        };
        BookJumpingForJax.AddBookCopy(BookCondition.Good);

        BookJuniperRising = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-8" },
            Title = "Juniper Rising",
            PublicationYear = 1984,
            PageCount = 300,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorBishopKnight },
            BookCategories = new List<BookCategoryViewModel>() { BookCategoryFiction }
        };
        BookJuniperRising.AddBookCopy(BookCondition.Good);

        BookAlfradoTheGreat = new()
        {
            Isbn = new() { Isbn = "978-0-00-000000-9" },
            Title = "Alfrado The Great",
            PublicationYear = 1985,
            PageCount = 400,
            Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorJohnWriter },
            BookCategories = new List<BookCategoryViewModel>() { BookCategoryFiction }
        };
        BookAlfradoTheGreat.AddBookCopy(BookCondition.Good);

        //BookNoCopies = new(new("978-4-00-000441-1"), new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper }, null, null, "Book No Copies", 1981, 110);
        BookNoCopies = new() { Isbn = new() { Isbn = "978-4-00-000441-1" }, Title = "Book No Copies", PublicationYear = 1981, PageCount = 110, Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper } };

        BookManyCopies = new() { Isbn = new() { Isbn = "978-5-00-000001-1" }, Title = "Book Many Copies", PublicationYear = 1981, PageCount = 110, Authors = new List<AuthorViewModel>() { AuthorTestData.AuthorSallyTyper } };
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);
        BookManyCopies.AddBookCopy(BookCondition.Good);

        BookOfThreeAuthors = new() { Isbn = new() { Isbn = "978-6-00-000331-2" }, Title = "Book of Three AuthorViewModels", PublicationYear = 1981, PageCount = 120, Authors = new List<AuthorViewModel> { AuthorTestData.AuthorBishopKnight, AuthorTestData.AuthorJohnWriter, AuthorTestData.AuthorSallyTyper } };
        BookOfThreeAuthors.AddBookCopy(BookCondition.Good);        

        BookWithCategories = new() { Isbn = new() { Isbn = "978-7-00-000131-1" }, Title = "Book With Categories", PublicationYear = 1981, PageCount = 110, Authors = new List<AuthorViewModel> { AuthorTestData.AuthorSallyTyper }, BookCategories = new List<BookCategoryViewModel> { BookCategoryFantasy, BookCategoryFiction } };
        BookWithCategories.AddBookCopy(BookCondition.Good);
        BookWithCategories.AddBookCopy(BookCondition.Fair);
        BookWithCategories.AddBookCopy(BookCondition.Poor);

        BookOfFantasy = new() { Isbn = new() { Isbn = "978-8-00-000214-6" }, Title = "Book Of Fantasy", PublicationYear = 1981, PageCount = 110, Authors = new List<AuthorViewModel> { AuthorTestData.AuthorSallyTyper }, BookCategories = new List<BookCategoryViewModel> { BookCategoryFantasy } };

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
