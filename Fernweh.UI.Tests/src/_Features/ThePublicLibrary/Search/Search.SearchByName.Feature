@smoke @thepubliclibrary @book @booksearch @name
Feature: Search by Name Experience

Background: 
    Given I navigate to the search page

Scenario: Search for a book by Name
    When I search for "", "book", ""
    Then I am on the search result page

Scenario: Search for a book by invalid Name
    When I auto search for "", "", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"
    Then I see a search error message
