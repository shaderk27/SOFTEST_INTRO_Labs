@BasicMusa
Feature: UsingCalculatorBasicReliability
In order to calculate the Basic Musa model's failures and intensities
As a Software Quality Metric enthusiast
I want to use my calculator to do this

Scenario: Calculate Current Failure Intensity
Given I have a calculator
When I enter initial intensity 10, total failures 100, and execution time 10 to calculate current intensity
Then the result should be 3.6787944117

Scenario: Calculate Expected Cumulative Failures
Given I have a calculator
When I enter initial intensity 10, total failures 100, and execution time 10 to calculate expected failures
Then the result should be 63.2120558829