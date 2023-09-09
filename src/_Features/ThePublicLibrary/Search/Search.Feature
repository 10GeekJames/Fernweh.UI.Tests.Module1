@SearchTests
Feature: Search Experience

Background: 
    Given we navigate to the search page
    Then we are on the search page

@SearchSingleTest
Scenario: Search for single value
    Given we search for "", "Frank", ""
    When we submit the search
    Then we are on the search result page

@SearchManyTest
Scenario: Search for many values
    Given we search for "<isbn_value>", "<author_value>", "<title_value>"
    Then the search values are "<isbn_value>", "<author_value>", "<title_value>"
    When we submit the search
    Then we are on the search result page
    Examples:
    | isbn_value         | author_value | title_value |
    | 0-5170-9394-4      |              |             |
    |                    | Franky       |             |
    |                    |              | Book of     |
