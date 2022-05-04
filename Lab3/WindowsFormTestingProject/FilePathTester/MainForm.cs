using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilePathTester
{
    public partial class MainForm : Form
    {
        private string _currentText = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void inputPathField_TextChanged(object sender, EventArgs e)
        {
            _currentText = inputPathField.Text;
        }

        private void addPathButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(_currentText))
            {
                MessageBox.Show("Пустая строка!", "", MessageBoxButtons.OK);
                return;
            }
            if (isPathValid())
            {
                validPaths.Items.Add(_currentText);
                ClearCurrentText();
                return;
            }
            invalidPaths.Items.Add(_currentText);
            ClearCurrentText();
        }

        private bool isPathValid()
        {
            Uri pathUri;
            bool isValidUri = Uri.TryCreate(_currentText, UriKind.Absolute, out pathUri);
            return isValidUri && pathUri != null && pathUri.IsLoopback;
        }

        private void ClearCurrentText()
        {
            _currentText = string.Empty;
            inputPathField.Clear();
        }

        private void removeFromLeftListButton_Click(object sender, EventArgs e)
        {
            try
            {
                validPaths.Items.Remove(validPaths.SelectedItems[0]);
            }
            catch
            {
                MessageBox.Show("Удаляемый элемент не выбран");
            }
        }

        private void removeFromRightListButton_Click(object sender, EventArgs e)
        {
            try
            {
                invalidPaths.Items.Remove(invalidPaths.SelectedItems[0]);
            }
            catch
            {
                MessageBox.Show("Удаляемый элемент не выбран");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                _currentText = invalidPaths.SelectedItems[0].ToString();
                inputPathField.Text = _currentText;
                invalidPaths.Items.Remove(invalidPaths.SelectedItems[0]);
            }
            catch
            {
                MessageBox.Show("Вы не выбрали строку для повторной проверки!");
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var temp = validPaths.SelectedItems[0];
                validPaths.Items.Remove(temp);
                invalidPaths.Items.Add(temp);
            }
            catch
            {
                MessageBox.Show("Перемещаемая строка не выбрана");
            }
        }
    }
}
