@Search @BasicSearch @Regression

Feature: Can search for books by ISBN, Author, Title
    As a guest user
    I want to be able to search for books by ISBN, Author, Title
    So that I can find the book I want

    Background:
        Given we navigate to the search page

    Scenario Outline: Search for books using various patterns
        Given we search for "<isbn value>", "<author value>", "<title value>"
        And the search values are "<isbn value>", "<author value>", "<title value>"
        When we submit the search
        Then we are on the search result page
        Examples:
            | isbn value    | author value | title value |
            | 0-5170-9394-4 |              |             |
            |               | Franky       |             |
            |               |              | Book of     |
            |               | Franky       | Book of     |
