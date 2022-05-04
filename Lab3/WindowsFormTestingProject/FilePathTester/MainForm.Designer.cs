namespace FilePathTester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputPathField = new System.Windows.Forms.TextBox();
            this.addPathButton = new System.Windows.Forms.Button();
            this.removeFromLeftListButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.removeFromRightListButton = new System.Windows.Forms.Button();
            this.validPaths = new System.Windows.Forms.ListBox();
            this.invalidPaths = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // inputPathField
            // 
            this.inputPathField.Location = new System.Drawing.Point(12, 12);
            this.inputPathField.Name = "inputPathField";
            this.inputPathField.Size = new System.Drawing.Size(451, 20);
            this.inputPathField.TabIndex = 0;
            this.inputPathField.TextChanged += new System.EventHandler(this.inputPathField_TextChanged);
            // 
            // addPathButton
            // 
            this.addPathButton.Location = new System.Drawing.Point(492, 7);
            this.addPathButton.Name = "addPathButton";
            this.addPathButton.Size = new System.Drawing.Size(184, 29);
            this.addPathButton.TabIndex = 1;
            this.addPathButton.Text = "Добавить";
            this.addPathButton.UseVisualStyleBackColor = true;
            this.addPathButton.Click += new System.EventHandler(this.addPathButton_Click);
            // 
            // removeFromLeftListButton
            // 
            this.removeFromLeftListButton.Location = new System.Drawing.Point(12, 318);
            this.removeFromLeftListButton.Name = "removeFromLeftListButton";
            this.removeFromLeftListButton.Size = new System.Drawing.Size(184, 29);
            this.removeFromLeftListButton.TabIndex = 4;
            this.removeFromLeftListButton.Text = "Удалить";
            this.removeFromLeftListButton.UseVisualStyleBackColor = true;
            this.removeFromLeftListButton.Click += new System.EventHandler(this.removeFromLeftListButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(604, 318);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(184, 29);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Вернуть";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(205, 318);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(184, 29);
            this.moveButton.TabIndex = 6;
            this.moveButton.Text = "Переместить";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // removeFromRightListButton
            // 
            this.removeFromRightListButton.Location = new System.Drawing.Point(411, 318);
            this.removeFromRightListButton.Name = "removeFromRightListButton";
            this.removeFromRightListButton.Size = new System.Drawing.Size(184, 29);
            this.removeFromRightListButton.TabIndex = 7;
            this.removeFromRightListButton.Text = "Удалить";
            this.removeFromRightListButton.UseVisualStyleBackColor = true;
            this.removeFromRightListButton.Click += new System.EventHandler(this.removeFromRightListButton_Click);
            // 
            // validPaths
            // 
            this.validPaths.FormattingEnabled = true;
            this.validPaths.Location = new System.Drawing.Point(12, 84);
            this.validPaths.Name = "validPaths";
            this.validPaths.Size = new System.Drawing.Size(377, 212);
            this.validPaths.TabIndex = 8;
            // 
            // invalidPaths
            // 
            this.invalidPaths.FormattingEnabled = true;
            this.invalidPaths.Location = new System.Drawing.Point(411, 84);
            this.invalidPaths.Name = "invalidPaths";
            this.invalidPaths.Size = new System.Drawing.Size(377, 212);
            this.invalidPaths.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 356);
            this.Controls.Add(this.invalidPaths);
            this.Controls.Add(this.validPaths);
            this.Controls.Add(this.removeFromRightListButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.removeFromLeftListButton);
            this.Controls.Add(this.addPathButton);
            this.Controls.Add(this.inputPathField);
            this.MaximumSize = new System.Drawing.Size(816, 395);
            this.MinimumSize = new System.Drawing.Size(816, 395);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilePathTester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputPathField;
        private System.Windows.Forms.Button addPathButton;
        private System.Windows.Forms.Button removeFromLeftListButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button removeFromRightListButton;
        private System.Windows.Forms.ListBox validPaths;
        private System.Windows.Forms.ListBox invalidPaths;
    }
}

