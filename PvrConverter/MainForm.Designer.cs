namespace PvrConverter
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
            this.inputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.inputDirectoryLabel = new System.Windows.Forms.Label();
            this.inputDirectoryButton = new System.Windows.Forms.Button();
            this.outputDirectoryButton = new System.Windows.Forms.Button();
            this.outputDirectoryLabel = new System.Windows.Forms.Label();
            this.outputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.projectXInfoLabel = new System.Windows.Forms.Label();
            this.mkvMergeInfoLabel = new System.Windows.Forms.Label();
            this.fileListView = new System.Windows.Forms.ListView();
            this.searchButton = new System.Windows.Forms.Button();
            this.selectAllToggleButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputDirectoryTextBox
            // 
            this.inputDirectoryTextBox.Enabled = false;
            this.inputDirectoryTextBox.Location = new System.Drawing.Point(88, 31);
            this.inputDirectoryTextBox.Name = "inputDirectoryTextBox";
            this.inputDirectoryTextBox.Size = new System.Drawing.Size(389, 20);
            this.inputDirectoryTextBox.TabIndex = 0;
            // 
            // inputDirectoryLabel
            // 
            this.inputDirectoryLabel.AutoSize = true;
            this.inputDirectoryLabel.Location = new System.Drawing.Point(11, 34);
            this.inputDirectoryLabel.Name = "inputDirectoryLabel";
            this.inputDirectoryLabel.Size = new System.Drawing.Size(63, 13);
            this.inputDirectoryLabel.TabIndex = 1;
            this.inputDirectoryLabel.Text = "Input Folder";
            // 
            // inputDirectoryButton
            // 
            this.inputDirectoryButton.Location = new System.Drawing.Point(484, 30);
            this.inputDirectoryButton.Name = "inputDirectoryButton";
            this.inputDirectoryButton.Size = new System.Drawing.Size(75, 21);
            this.inputDirectoryButton.TabIndex = 2;
            this.inputDirectoryButton.Text = "Select";
            this.inputDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // outputDirectoryButton
            // 
            this.outputDirectoryButton.Location = new System.Drawing.Point(484, 56);
            this.outputDirectoryButton.Name = "outputDirectoryButton";
            this.outputDirectoryButton.Size = new System.Drawing.Size(75, 21);
            this.outputDirectoryButton.TabIndex = 5;
            this.outputDirectoryButton.Text = "Select";
            this.outputDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // outputDirectoryLabel
            // 
            this.outputDirectoryLabel.AutoSize = true;
            this.outputDirectoryLabel.Location = new System.Drawing.Point(11, 60);
            this.outputDirectoryLabel.Name = "outputDirectoryLabel";
            this.outputDirectoryLabel.Size = new System.Drawing.Size(71, 13);
            this.outputDirectoryLabel.TabIndex = 4;
            this.outputDirectoryLabel.Text = "Output Folder";
            // 
            // outputDirectoryTextBox
            // 
            this.outputDirectoryTextBox.Enabled = false;
            this.outputDirectoryTextBox.Location = new System.Drawing.Point(88, 57);
            this.outputDirectoryTextBox.Name = "outputDirectoryTextBox";
            this.outputDirectoryTextBox.Size = new System.Drawing.Size(389, 20);
            this.outputDirectoryTextBox.TabIndex = 3;
            // 
            // projectXInfoLabel
            // 
            this.projectXInfoLabel.AutoSize = true;
            this.projectXInfoLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.projectXInfoLabel.Location = new System.Drawing.Point(12, 9);
            this.projectXInfoLabel.MinimumSize = new System.Drawing.Size(265, 0);
            this.projectXInfoLabel.Name = "projectXInfoLabel";
            this.projectXInfoLabel.Size = new System.Drawing.Size(265, 13);
            this.projectXInfoLabel.TabIndex = 6;
            this.projectXInfoLabel.Text = "Project X Info Label";
            // 
            // mkvMergeInfoLabel
            // 
            this.mkvMergeInfoLabel.AutoSize = true;
            this.mkvMergeInfoLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mkvMergeInfoLabel.Location = new System.Drawing.Point(295, 9);
            this.mkvMergeInfoLabel.MinimumSize = new System.Drawing.Size(265, 0);
            this.mkvMergeInfoLabel.Name = "mkvMergeInfoLabel";
            this.mkvMergeInfoLabel.Size = new System.Drawing.Size(265, 13);
            this.mkvMergeInfoLabel.TabIndex = 7;
            this.mkvMergeInfoLabel.Text = "Mkv Merge Info Label";
            // 
            // fileListView
            // 
            this.fileListView.CheckBoxes = true;
            this.fileListView.FullRowSelect = true;
            this.fileListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fileListView.Location = new System.Drawing.Point(15, 83);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(544, 120);
            this.fileListView.TabIndex = 8;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Details;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(15, 209);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(90, 23);
            this.searchButton.TabIndex = 9;
            this.searchButton.Text = "Search for Files";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // selectAllToggleButton
            // 
            this.selectAllToggleButton.Location = new System.Drawing.Point(111, 209);
            this.selectAllToggleButton.Name = "selectAllToggleButton";
            this.selectAllToggleButton.Size = new System.Drawing.Size(106, 23);
            this.selectAllToggleButton.TabIndex = 10;
            this.selectAllToggleButton.Text = "Select/Deselect All";
            this.selectAllToggleButton.UseVisualStyleBackColor = true;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(484, 209);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 11;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 269);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.selectAllToggleButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.mkvMergeInfoLabel);
            this.Controls.Add(this.projectXInfoLabel);
            this.Controls.Add(this.outputDirectoryButton);
            this.Controls.Add(this.outputDirectoryLabel);
            this.Controls.Add(this.outputDirectoryTextBox);
            this.Controls.Add(this.inputDirectoryButton);
            this.Controls.Add(this.inputDirectoryLabel);
            this.Controls.Add(this.inputDirectoryTextBox);
            this.Name = "MainForm";
            this.Text = "PVR Converter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputDirectoryTextBox;
        private System.Windows.Forms.Label inputDirectoryLabel;
        private System.Windows.Forms.Button inputDirectoryButton;
        private System.Windows.Forms.Button outputDirectoryButton;
        private System.Windows.Forms.Label outputDirectoryLabel;
        private System.Windows.Forms.TextBox outputDirectoryTextBox;
        private System.Windows.Forms.Label projectXInfoLabel;
        private System.Windows.Forms.Label mkvMergeInfoLabel;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button selectAllToggleButton;
        private System.Windows.Forms.Button processButton;
    }
}

