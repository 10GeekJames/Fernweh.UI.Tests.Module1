@smoke @thepubliclibrary @library @librarydetail
Feature: Library Detail Experience
    As a guest user
    I want to be able to see the libraries detail
    So that I can find out more about the library

    Scenario: I can see the advertisment on the library detail page
        Given we direct navigate to "Library1" detail page
        Then the library detail advertisment content is "Sponsor the Library, get some exposure! In this IFrame"

    Scenario Outline: I can see the library detail
        Given we direct navigate to "<library data key>" detail page
        Then the library detail open hours is "<open hours>"
        And the library detail close hours is "<close hours>"
        And the library detail notes is "<notes>"
        And the library detail primary phone is "<primary phone>"
        And the library detail primary email is "<primary email>"

        Examples:
            | library data key | name                  | open hours | close hours | notes                             | primary phone | primary email |
            | Library1         | First Street Library  | 7AM        | 9PM         | This is the first street library  |               |               |
            | Library2         | Second Street Library | 7AM        | 9PM         | This is the second street library |               |               |