---
name: Feature template
about: This template provides a basic structure for Gherkin feature issues.
title: 'Feature: '
labels: feature
assignees: 

---

<!--
Read this reference page if you are not yet familiar with Gherkin: https://github.com/cucumber/docs/blob/main/content/docs/gherkin/reference.md
-->

<!--
Write the Gherkin feature in the title: "Feature: Account Holder withdraws cash"
-->

<!--
Acceptance criteria should be defined by providing examples in Gherkin syntax (Given, When, Then). Keep this simple.
-->

# Scenario(s)

```gherkin
Scenario: Account has sufficient funds
  Given the account balance is $100
    And the card is valid
    And the machine contains enough money
  When the Account Holder requests $20
  Then the ATM should dispense $20
    And the account balance should be $80
    And the card should be returned
```

```gherkin
Scenario: Account has insufficient funds
  Given the account balance is $100
    And the card is valid
    And the machine contains enough money
  When the Account Holder requests $200
  Then the ATM should inform the Account Holder that they have insufficient funds
    And display the current account balance
    And prompt the Account Holder to request a different amount
```

# Feature checklist
1. - [ ] The scenarios are defined
2. - [ ] The team understands the scenarios
3. - [ ] All external dependencies are identified
4. - [ ] The team has defined a solution that satisfies the scenarios
