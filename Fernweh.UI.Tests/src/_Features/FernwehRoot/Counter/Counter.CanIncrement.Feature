@Counter @Regression
Feature: Counter Can Increment

Background: 
    Given I navigate to the counter page
    Then I am on the counter page

Scenario: I can increment the value
    Given the counter value is 0
    When I click the increment button
    And I wait 0.5 seconds
    Then the counter value is 1    
    
    When I click the increment button
    And I wait 0.5 seconds
    Then the counter value is 2    
    
    When I click the increment button
    And I wait 0.5 seconds
    Then the counter value is 3
    