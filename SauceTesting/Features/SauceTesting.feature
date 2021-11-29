Feature: SauceTesting

@OpenSite
Scenario: Site test
	Given I navigate to site
	And I enter valid username
	And I enter valid password
	Then I click on login button
	Given I'm buying Labs Backpack
	And I'm buying Bike Light
	And I'm buying Bolt T-Shirt
	And I'm buying Fleece Jacket
	And I'm buying Onesie
	And I'm buying Red T-shirt
	Then I'm changing sort option
	And I'm going to basket
	And I click checkout
	Given I enter First Name <fname>
	And I enter Last Name <lname>
	And I enter Postal Code <code>
	Then I click Continue
	And I click Continue Overview
	And Close the test
	Examples:
	| fname | lname     | code   |
	| Tomek | Tomkowski | 69-420 |
