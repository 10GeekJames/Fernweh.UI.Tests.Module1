@smoke @thepubliclibrary @book @booksearch @isbn
Feature: Search by ISBN Experience

Background: 
    Given I navigate to the search page

Scenario: Search for a book by ISBN number
    When I search for "0-5213-0081-9", "", ""
    And I submit the search
    Then I am on the search result page

Scenario: Search for a book by invalid ISBN number
    When I auto search for "0-5213", "", ""
    Then I see a search error message
