Feature: Search Grid ManyCopies Result has Seven
    @test
    Scenario: Can find many copies and see seven results
        Given I navigate to the search result page
        Then I can see "7" results for book isbn "978-5-00-000001-1"