@smoke @thepubliclibrary @library @librarydetail
Feature: LibraryDetailDirectNavigate Experience
    As a guest user
    I want to be able to see the library detail
    So that I can find out more about the library

    Scenario Outline: I can navigate to the library list page
        Given I direct navigate to "<library data key>" detail page
        And the library detail name is "<name>"

        Examples:
            | library data key | name                  |
            | Library1         | First Street Library  |
            | Library2         | Second Street Library |