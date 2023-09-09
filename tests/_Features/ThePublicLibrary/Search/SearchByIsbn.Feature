@SearchTests
Feature: Search by ISBN Experience

Background: 
    Given we navigate to the search page
    Then we are on the search page

@SearchByIsbn
Scenario: Search for a book by ISBN number
    Given we search for "0-5213-0081-9", "", ""
    When we submit the search
    Then we are on the search result page

@SearchByIsbn @SearchByIsbnInvalid
Scenario: Search for a book by invalid ISBN number
    Given we search for "0-5213", "", ""
    When we submit the search
    Then we see a search error message
