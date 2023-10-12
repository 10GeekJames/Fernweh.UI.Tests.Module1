@LibraryDetails

Feature: LibraryDetails Experience
    As a guest user
    I want to be able to see the libraries details
    So that I can find out more about the library

    @test
    Scenario Outline: I can see the advertisment on the library details page
        Given we direct navigate to the library details page using "<libraryId>"
        When we consider the advertisment content
        Then we can see the advertisment content is "Sponsor the Library, get some exposure! In this IFrame"

        Examples:
            | libraryId                            | name                 |
            | 89d3e762-d5c8-4b00-bec8-08dbcb693716 | First Street Library |