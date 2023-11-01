@smoke @thepubliclibrary @library @librarydetail
Feature: Library Detail Experience
    As a guest user
    I want to be able to see the libraries detail
    So that I can find out more about the library

    Scenario: I see the advertisment on the library detail page
        Given I direct navigate to "Library1" detail page
        Then the library detail advertisment content is "Sponsor the Library, get some exposure! In this IFrame"

    Scenario: I see all of the library details
        Given I direct navigate to "<library data key>" detail page
        Then I see the library has the correct details for "<library name>"
        Examples:
            | library data key | library name          |
            | Library1         | First Street Library  |
            | Library2         | Second Street Library |