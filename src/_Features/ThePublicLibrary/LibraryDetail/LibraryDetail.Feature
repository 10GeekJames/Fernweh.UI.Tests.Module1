@LibraryDetails
Feature: Library Details Experience
    As a guest user
    I want to be able to see the libraries detail
    So that I can find out more about the library

    Scenario Outline: I can see the advertisment on the library detail page
        Given we direct navigate to the library detail page using "<libraryId>"
        Then the library detail advertisment content is "<advertisment>"

        @qa
        Examples:
            | libraryId                            | advertisment                                           |
            | 89d3e762-d5c8-4b00-bec8-08dbcb693716 | Sponsor the Library, get some exposure! In this IFrame |

    #    @dev
    #    Examples:
    #        | libraryId                            | advertisment                                           |
    #        | 1075f340-cd29-4223-2135-08dbc74f410e | Sponsor the Library, get some exposure! In this IFrame |

    Scenario Outline: I can see the library detail
        Given we direct navigate to the library detail page using "<libraryId>"
        Then the library detail open hours is "<open hours>"
        And the library detail close hours is "<close hours>"
        And the library detail notes is "<notes>"
        And the library detail primary phone is "<primary phone>"
        And the library detail primary email is "<primary email>"

        @qa
        Examples:
            | libraryId                            | name                 | open hours | close hours | notes                            | primary phone | primary email |
            | 89d3e762-d5c8-4b00-bec8-08dbcb693716 | First Street Library | 7AM        | 9PM         | This is the first street library |               |               |

    #    @dev
    #    Examples:
    #        | libraryId                            | name                 | open hours | close hours | notes                            | primary phone | primary email |
    #        | 1075f340-cd29-4223-2135-08dbc74f410e | First Street Library | 7AM        | 9PM         | This is the first street library |               |               |

