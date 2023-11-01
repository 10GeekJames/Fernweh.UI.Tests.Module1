@smoke @thepubliclibrary @book @bookdetail
Feature: Book Detail Experience
    As a guest user
    I want to be able to see the books detail
    So that I can find out more about the book

    Scenario Outline: I see the book details using inline table data with a little more focus on pageobjectmodel helping providing quality check logic
        Given I navigate to book by isbn "<isbn>"
        Then I see the book details for "<isbn>"
        Examples:
            | isbn              |
            | 978-0-00-000000-6 |
            | 978-0-00-000000-7 |
            | 978-0-00-000000-8 |
            | 978-0-00-000000-9 |   

    Scenario Outline: I see the book details using inline table data with assertions in step bindings providing quality check logic
        Given I navigate to book by isbn "<isbn>"
        Then I see the book details with feature file providing quality check logic "<isbn>"
        Examples:
            | isbn              |
            | 978-0-00-000000-6 |
            | 978-0-00-000000-7 |
            | 978-0-00-000000-8 |
            | 978-0-00-000000-9 |