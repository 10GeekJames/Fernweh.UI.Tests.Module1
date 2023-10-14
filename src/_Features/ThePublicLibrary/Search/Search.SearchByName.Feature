@Smoke
Feature: Search by Name Experience

Background: 
    Given we navigate to the search page

Scenario: Search for a book by Name
    When we search for "", "book", ""
    And we submit the search
    Then I am on the search result page

Scenario: Search for a book by invalid Name
    When we auto search for "", "", "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz"
    Then we see a search error message
