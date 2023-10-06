@LibraryDetails

Feature: LibraryDetails Experience
    As a guest user
    I want to be able to see the libraries details
    So that I can find out more about the library

Background:
    Given we navigate to the library list page

Scenario: I can navigate to the library list page
    When we select the library by name "First Street Library"
    Then we are on the library details page
    And we can see the library details name is "First Street Library"
