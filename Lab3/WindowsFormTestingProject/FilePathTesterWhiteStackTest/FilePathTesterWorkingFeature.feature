Feature: MainWindowWorkingFeature
	In order to perform FilePathTester working
	As a OS Windows user
	I want to run all cases of FilePathTester program

A short summary of the feature

Scenario: Add valid path to valid paths list box
	Given I have entered "d://labs/" to text field
	When I press add button
	Then the items count on valid paths list box should be 1

Scenario: Add invalid path to invalid paths list box
	Given I have entered "incorrect one1" to text field
	When I press add button
	Then the items count on invalid paths list box should be 1

Scenario: Remove item from valid paths list box
	Given I have entered "d://removing/" to text field
	When I press add button
	And I selecting item on valid paths list box with text "input"
	And I press remove from valid paths list button
	Then the items count on valid paths list box should be 0

Scenario: Remove item from invalid paths list box
	Given I have entered "removing/" to text field
	When I press add button
	And I selecting item on invalid paths list box with text "input"
	And I press remove from invalid paths list button
	Then the items count on invalid paths list box should be 0

Scenario: Try to add empty item to paths listbox
	Given I press add button without entering of any path to textbox
	Then MessageBox with text "Пустая строка!" should appear

Scenario: Try to remove not selected item from valid paths listbox
	Given I press remove from valid paths list button without choosing of any path on valid paths listbox
	Then MessageBox with text "Удаляемый элемент не выбран" should appear

Scenario: Try to remove not selected item from invalid paths listbox
	Given I press remove from invalid paths list button without choosing of any path on invalid paths listbox
	Then MessageBox with text "Удаляемый элемент не выбран" should appear

Scenario: Try to move not selected item from invalid path listbox to textbox for another check
	Given I press back button without choosing of any path on invalid paths listbox
	Then MessageBox with text "Вы не выбрали строку для повторной проверки!" should appear

Scenario: Try to move not selected item from valid path listbox to invalid paths listbox
	Given I press move button without choosing of any path on valid path listbox
	Then MessageBox with text "Перемещаемая строка не выбрана" should appear

Scenario: Try to move path from invalid paths listbox to textbox for another check
	Given I have entered "incorrect_for_move" to text field
	When I press add button
	And I selecting item on invalid paths list box with text "input"
	And I press back button
	Then the items count on invalid paths list box should be 0
	And the text content on textbox should be "incorrect_for_move"

Scenario: Try to move path from valid paths listbox to invalid paths listbox
	Given I have entered "c:\\correct\move" to text field
	When I press add button
	And I selecting item on valid paths list box with text "input"
	And I press move button
	Then the items count on invalid paths list box should be 2
	And the items count on valid paths list box should be 1
