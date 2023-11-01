@smoke @thepubliclibrary @book @booksearch @author
Feature: Search by Author Experience

Background: 
    Given I navigate to the search page

Scenario: Search for a book by Author
    When I search for "", "", "Sally"
    And I submit the search
    Then I am on the search result page

Scenario: Search for a book by too long of author
    When I auto search for "", "abcdefghijklmnopqrstuvwxyzzzz", ""
    Then I see a search error message
