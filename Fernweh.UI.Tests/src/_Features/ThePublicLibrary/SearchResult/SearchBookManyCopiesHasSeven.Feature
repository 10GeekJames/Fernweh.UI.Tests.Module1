@smoke @thepubliclibrary @book @booksearchresult
Feature: Search Grid ManyCopies Result has Seven
    
    Scenario: Can find 7 copies of the book many copies by isbn
        Given I navigate to the search result page
        Then I can see "7" results for book isbn "978-5-00-000001-1"