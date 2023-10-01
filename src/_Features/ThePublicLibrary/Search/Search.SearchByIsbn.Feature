@Search @Isbn @Regression
Feature: Search by ISBN Experience

Background: 
    Given we navigate to the search page

Scenario: Search for a book by ISBN number
    When we search for "0-5213-0081-9", "", ""
    And we submit the search
    Then we are on the search result page

Scenario: Search for a book by invalid ISBN number
    When we auto search for "0-5213", "", ""
    Then we see a search error message
