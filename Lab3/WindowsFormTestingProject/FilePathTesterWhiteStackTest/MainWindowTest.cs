using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace FilePathTesterWhiteStackTest
{
    public class MainWindowTest
    {
        private Application _app;
        private Window _window;
        private TextBox _inputField;
        private Button _addButton;
        private Button _removeFromValidListButton;
        private Button _removeFromInvalidListButton;
        private Button _moveButton;
        private Button _backButton;
        private ListBox _validPaths;
        private ListBox _invalidPaths;

        [OneTimeSetUp]
        public void Setup()
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

        [Test]
        public void TestIncorrectPathAdding()
        {
            _inputField.Text = "incorrect one1";
            _addButton.Click();
            Assert.That(_invalidPaths.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestCorrectPathAdding()
        {
            _inputField.Text = "d://labs/";
            _addButton.Click();
            Assert.That(_validPaths.Items.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestCorrectListItemRemoving()
        {
            string path = "d://removing/";
            _inputField.Text = path;
            _addButton.Click();
            _validPaths.Items.Select(path);
            _removeFromValidListButton.Click();
            Assert.That(_validPaths.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestIncorrectListItemRemoving()
        {
            string path = "removing/";
            _inputField.Text = path;
            _addButton.Click();
            _invalidPaths.Items.Select(path);
            _removeFromInvalidListButton.Click();
            Assert.That(_invalidPaths.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestEmptyItemAdding()
        {
            _addButton.Click();
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo("Пустая строка!"));
            messageBox.Close();
        }

        [Test]
        public void TestEmptyItemRemovingFromValidPathList()
        {
            _removeFromValidListButton.Click();
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo("Удаляемый элемент не выбран"));
            messageBox.Close();
        }

        [Test]
        public void TestEmptyItemRemovingFromInvalidPathList()
        {
            _removeFromInvalidListButton.Click();
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo("Удаляемый элемент не выбран"));
            messageBox.Close();
        }

        [Test]
        public void TestEmptyItemMovingBackFromInvalidPathList()
        {
            _backButton.Click();
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo("Вы не выбрали строку для повторной проверки!"));
            messageBox.Close();
        }

        [Test]
        public void TestEmptyItemMovingFromValidListToAnother()
        {
            _moveButton.Click();
            Window messageBox = _window.MessageBox("");
            var label = messageBox.Get<Label>(SearchCriteria.Indexed(0));
            Assert.That(label.Text, Is.EqualTo("Перемещаемая строка не выбрана"));
            messageBox.Close();
        }

        [Test]
        public void TestIncorrectListItemMovingBack()
        {
            string path = "incorrect_for_move";
            _inputField.Text = path;
            _addButton.Click();
            _invalidPaths.Items.Select(path);
            _backButton.Click();
            Assert.That(_invalidPaths.Items.Count, Is.EqualTo(0));
            Assert.That(_inputField.Text, Is.EqualTo(path));
        }

        [Test]
        public void TestItemMovingFromValidListToAnother()
        {
            string path = @"c:\\correct\move";
            _inputField.Text = path;
            _addButton.Click();
            _validPaths.Items.Select(path);
            _moveButton.Click();
            Assert.That(_validPaths.Items.Count, Is.EqualTo(1));
            Assert.That(_invalidPaths.Items.Count, Is.EqualTo(2));
        }

        [OneTimeTearDown]
        public void Quit()
        {
            _app.Close();
        }
    }
}