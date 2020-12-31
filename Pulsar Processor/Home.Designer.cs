namespace Pulsar_Processor
{
    partial class Home
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
            this.richTxtBox_Console = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_Filepath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnStartPulsarProcessing = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pulsarDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPulsarDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTxtBox_Console
            // 
            this.richTxtBox_Console.BackColor = System.Drawing.SystemColors.WindowText;
            this.richTxtBox_Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBox_Console.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.richTxtBox_Console.ForeColor = System.Drawing.Color.LimeGreen;
            this.richTxtBox_Console.Location = new System.Drawing.Point(14, 130);
            this.richTxtBox_Console.Name = "richTxtBox_Console";
            this.richTxtBox_Console.ReadOnly = true;
            this.richTxtBox_Console.Size = new System.Drawing.Size(769, 300);
            this.richTxtBox_Console.TabIndex = 0;
            this.richTxtBox_Console.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Console:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select Pulsar Data: ";
            // 
            // txtBox_Filepath
            // 
            this.txtBox_Filepath.Location = new System.Drawing.Point(11, 41);
            this.txtBox_Filepath.Name = "txtBox_Filepath";
            this.txtBox_Filepath.ReadOnly = true;
            this.txtBox_Filepath.Size = new System.Drawing.Size(586, 20);
            this.txtBox_Filepath.TabIndex = 3;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(603, 40);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(177, 23);
            this.btnSelectFile.TabIndex = 4;
            this.btnSelectFile.Text = "Select file";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnStartPulsarProcessing
            // 
            this.btnStartPulsarProcessing.Location = new System.Drawing.Point(11, 67);
            this.btnStartPulsarProcessing.Name = "btnStartPulsarProcessing";
            this.btnStartPulsarProcessing.Size = new System.Drawing.Size(188, 30);
            this.btnStartPulsarProcessing.TabIndex = 5;
            this.btnStartPulsarProcessing.Text = "Start pulsar processing";
            this.btnStartPulsarProcessing.UseVisualStyleBackColor = true;
            this.btnStartPulsarProcessing.Click += new System.EventHandler(this.btnStartPulsarProcessing_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(610, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data must be only provided by CSV";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(205, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 56);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Information";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Test AI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Error: 0.50 Seconds +-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Pulsar Folded Data : ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(395, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(180, 51);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "Data File";
            this.fileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialog_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pulsarDatabaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pulsarDatabaseToolStripMenuItem
            // 
            this.pulsarDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPulsarDatabaseToolStripMenuItem});
            this.pulsarDatabaseToolStripMenuItem.Name = "pulsarDatabaseToolStripMenuItem";
            this.pulsarDatabaseToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.pulsarDatabaseToolStripMenuItem.Text = "Pulsar Database";
            // 
            // showPulsarDatabaseToolStripMenuItem
            // 
            this.showPulsarDatabaseToolStripMenuItem.Name = "showPulsarDatabaseToolStripMenuItem";
            this.showPulsarDatabaseToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showPulsarDatabaseToolStripMenuItem.Text = "Show pulsar database";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Filter Spikes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnStartPulsarProcessing);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtBox_Filepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTxtBox_Console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pulsar Processor";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtBox_Console;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_Filepath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnStartPulsarProcessing;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pulsarDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPulsarDatabaseToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

