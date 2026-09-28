@Factorial
Feature: UsingCalculatorFactorial
In order to quickly calculate combinations and permutations
As a math enthusiast
I want to be told the factorial of a number

Scenario: Calculate a normal factorial
Given I have a calculator
When I enter 5 and press factorial
Then the factorial result should be 120

Scenario: Calculate the factorial of zero
Given I have a calculator
When I enter 0 and press factorial
Then the factorial result should be 1

Scenario Outline: Reject unsupported factorial values
Given I have a calculator
When I enter <value> and press factorial
Then the factorial operation should be rejected

Examples:
  | value |
  | -1    |
  | 21    |