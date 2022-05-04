Feature: WebSearchFeature
	In order to check russian article about NUnti on Wikipedia
	As a Google Chrome user
	I want to check corresponding article link exists

A short summary of the feature

Scenario: Search the russian article link
	Given I have opened Google Chrome search page
	And I have entered unit testing
	When I pressed search button
	Then The search relusts contains english Wikipedia link
	Then I follow the english Wikipedia link
	And I have entered NUnit to Wikipedia search field
	When I confirmed the NUnit searching
	Then Must be a link to a russian article about NUnit on Wikipedia
