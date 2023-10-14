@Smoke @Author
Feature: Search by Author Experience

Background: 
    Given we navigate to the search page

Scenario: Search for a book by Author
    When we search for "", "", "Sally"
    And we submit the search
    Then I am on the search result page

Scenario: Search for a book by too long of author
    When we auto search for "", "abcdefghijklmnopqrstuvwxyzzzz", ""
    Then we see a search error message
