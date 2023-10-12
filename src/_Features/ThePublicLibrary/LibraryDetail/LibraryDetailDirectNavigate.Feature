@LibraryDetails @LibraryDetailsDirectNavigate

Feature: LibraryDetailDirectNavigate Experience
    As a guest user
    I want to be able to see the libraries details
    So that I can find out more about the library

    Scenario Outline: I can navigate to the library list page
        When we direct navigate to the library details page using "<libraryId>"
        And we can see the library details name is "<name>"

        Examples:
            | libraryId                            | name                 |
            | 89d3e762-d5c8-4b00-bec8-08dbcb693716 | First Street Library |