@Smoke

Feature: LibraryLists Experience
    As a guest user
    I want to be able to see a list of libraries
    So that I can find out more about them

Background:
    Given we navigate to the library list page

Scenario Outline: I can navigate to the library list page
    When we search for the library listed as "<library name>"
    
    Examples:
        | library name |
        | First Street Library |
        | Second Street Library |