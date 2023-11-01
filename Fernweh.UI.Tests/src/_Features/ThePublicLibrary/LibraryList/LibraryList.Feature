@smoke @thepubliclibrary @library @librarylist
Feature: LibraryList Experience
    As a guest user
    I want to be able to see a list of libraries
    So that I can find out more about them

    Background:
        Given I navigate to the library list page

    Scenario Outline: I see a library in the list of libraries
        Then I see library "<library name>" is listed

        Examples:
            | library name          |
            | First Street Library  |
            | Second Street Library |