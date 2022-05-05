using NUnit.Framework;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace FilePathTesterWhiteStackTest
{
    [Binding]
    public class MainWindowWorkingFeatureSteps
    {
        private static Application _app;
        private static Window _window;
        private static TextBox _inputField;
        private static Button _addButton;
        private static Button _removeFromValidListButton;
        private static Button _removeFromInvalidListButton;
        private static Button _moveButton;
        private static Button _backButton;
        private static ListBox _validPaths;
        private static ListBox _invalidPaths;

        [BeforeFeature]
        public static void Setup()
        {
            _app = Application.Launch(@"D:\SoftwareTesting\Lab3\WindowsFormTestingProject\FilePathTester\bin\Debug\FilePathTester.exe");
            _window = _app.GetWindow("FilePathTester");
            _inputField = _window.Get<TextBox>("inputPathField");
            _addButton = _window.Get<Button>("addPathButton");
            _removeFromValidListButton = _window.Get<Button>("removeFromLeftListButton");
            _removeFromInvalidListButton = _window.Get<Button>("removeFromRightListButton");
            _moveButton = _window.Get<Button>("moveButton");
            _backButton = _window.Get<Button>("backButton");
            _validPaths = _window.Get<ListBox>("validPaths");
            _invalidPaths = _window.Get<ListBox>("invalidPaths");
        }

        [AfterFeature]
        public static void Quit()
        {
            _app.Close();
        }

        [Given(@"I have entered ""([^""]*)"" to text field")]
        public void GivenIHaveEnteredToTextField(string input)
        {
            _inputField.Text = input;
        }

        [When(@"I press add button")]
        public void WhenIPressAddButton()
        {
            _addButton.Click();
        }

        [Then(@"the items count on valid paths list box should be (.*)")]
        public void ThenTheItemsCountOnValidPathsListBoxShouldBe(int count)
        {
            Assert.That(_validPaths.Items.Count, Is.EqualTo(count));
        }

        [Then(@"the items count on invalid paths list box should be (.*)")]
        public void ThenTheItemsCountOnInvalidPathsListBoxShouldBe(int count)
        {
            Assert.That(_invalidPaths.Items.Count, Is.EqualTo(count));
        }

        [When(@"I selecting item on valid paths list box with text ""([^""]*)""")]
        public void WhenISelectingItemOnValidPathsListBoxWithText(string input)
        {
            _validPaths.Items.Select(input);
        }

        [When(@"I press remove from valid paths list button")]
        public void WhenIPressRemoveFromValidPathsListButton()
        {
            _removeFromValidListButton.Click();
        }

        [When(@"I selecting item on invalid paths list box with text ""([^""]*)""")]
        public void WhenISelectingItemOnInvalidPathsListBoxWithText(string input)
        {
            _invalidPaths.Items.Select(input);
        }

        [When(@"I press remove from invalid paths list button")]
        public void WhenIPressRemoveFromInvalidPathsListButton()
        {
            _removeFromInvalidListButton.Click();
        }

        [Given(@"I press add button without entering of any path to textbox")]
        public void GivenIPressAddButtonWithoutEnteringOfAnyPathToTextbox()
        {
            _addButton.Click();
        }

        [Then(@"MessageBox with text ""([^""]*)"" should appear")]
        public void ThenMessageBoxWithTextShouldAppear(string text)
        {
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo(text));
            messageBox.Close();
        }

        [Given(@"I press remove from valid paths list button without choosing of any path on valid paths listbox")]
        public void GivenIPressRemoveFromValidPathsListButtonWithoutChoosingOfAnyPathOnValidPathsListbox()
        {
            _removeFromValidListButton.Click();
        }

        [Given(@"I press remove from invalid paths list button without choosing of any path on invalid paths listbox")]
        public void GivenIPressRemoveFromInvalidPathsListButtonWithoutChoosingOfAnyPathOnInvalidPathsListbox()
        {
            _removeFromInvalidListButton.Click();
        }

        [Given(@"I press back button without choosing of any path on invalid paths listbox")]
        public void GivenIPressBackButtonWithoutChoosingOfAnyPathOnInvalidPathsListbox()
        {
            _backButton.Click();
        }

        [Given(@"I press move button without choosing of any path on valid path listbox")]
        public void GivenIPressMoveButtonWithoutChoosingOfAnyPathOnValidPathListbox()
        {
            _moveButton.Click();
        }

        [When(@"I press back button")]
        public void WhenIPressBackButton()
        {
            _backButton.Click();
        }

        [Then(@"the text content on textbox should be ""([^""]*)""")]
        public void ThenTheTextContentOnTextboxShouldBe(string text)
        {
            Assert.That(_inputField.Text, Is.EqualTo(text));
        }

        [When(@"I press move button")]
        public void WhenIPressMoveButton()
        {
            _moveButton.Click();
        }
    }
}
