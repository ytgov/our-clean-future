---
name: Feature template
about: This template provides a basic structure for Gherkin feature issues.
title: 'Feature: '
labels: feature
assignees: JonHodgins

---

<!--
Write the Gherkin feature in the title: "Feature: Account Holder withdraws cash"
-->

<!--
Acceptance criteria should be defined in a Gherkin syntax (Given, When, Then). Keep this simple.
-->

# Scenario(s) (acceptance criteria)

```gherkin
Feature: Account Holder withdraws cash
 
  Scenario: Account has sufficient funds
    Given the account balance is $100
      And the card is valid
      And the machine contains enough money
    When the Account Holder requests $20
    Then the ATM should dispense $20
      And the account balance should be $80
      And the card should be returned
```

# Sprint Ready Checklist 
1. - [ ] Scenarios defined 
2. - [ ] Team understands scenarios
3. - [ ] Team has defined solution / steps to satisfy scenarios
4. - [ ] scenarios are verifiable / testable 
5. - [ ] External / 3rd Party dependencies identified
