@smoke @thepubliclibrary @library @librarylist @librarylistnavigate
Feature: Library List Can Navigate To Library Detail
    As a guest user
    I want to be able to see a list of libraries
    and select one of them to navigate to the library detail page

    Background:
        Given I navigate to the library list page

    Scenario Outline: I see a library in the list of libraries
        When I select the library by name "<library name>"
        Then I am on the library detail page

        Examples:
            | library name          |
            | First Street Library  |
            | Second Street Library |