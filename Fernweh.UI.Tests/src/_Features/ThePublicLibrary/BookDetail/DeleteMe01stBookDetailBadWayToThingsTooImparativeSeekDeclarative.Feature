@smoke @thepubliclibrary @book @bookdetail
Feature: DeleteMe01stBookDetailBadWayToThingsTooImparativeSeekDeclarative
    As a guest user
    I want to be able to see the books detail
    So that I can find out more about the book

    @longwinded
    Scenario Outline: I see the book details using inline table data with feature file providing quality check logic
        Given I navigate to book by isbn "<isbn>"
        Then I see the book details isbn is "<isbn>"
        And I see the book details title is "<title>"
        And I see the book details author is "<author>"
        And I see the book details categories is "<categories>"
        And I see the book details description is "<description>"
        And I see the book details copies total is "<copies total>"
        And I see the book details copies available is "<copies available>"
        And I see the book details publish year is "<publish year>"

        Examples:
            | isbn              | title            | author      | categories | description | copies total | copies available | publish year |
            | 978-0-00-000000-6 | The Wild Side    | John Writer |            |             | 2            | 2                | 1982         |
            | 978-5-00-000001-1 | Book Many Copies | Sally Typer |            |             | 7            | 7                | 1981         |