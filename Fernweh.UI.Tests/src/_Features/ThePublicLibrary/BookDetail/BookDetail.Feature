@Smoke
Feature: Book Detail Experience
    As a guest user
    I want to be able to see the books detail
    So that I can find out more about the book

    Scenario Outline: I can see the book details
        Given I navigate to book by isbn "<isbn>"
        Then I can see the book details for "<isbn>"
        Examples:
            | isbn              |
            | 978-0-00-000000-6 |
            | 978-0-00-000000-7 |
            | 978-0-00-000000-8 |
            | 978-0-00-000000-9 |




