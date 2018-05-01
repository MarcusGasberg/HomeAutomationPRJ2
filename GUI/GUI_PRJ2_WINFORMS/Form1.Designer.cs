using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI_PRJ2_WINFORMS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddApparatButton = new System.Windows.Forms.Button();
            this.MainView = new System.Windows.Forms.TabControl();
            this.ApparatMenu = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddMenu = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.functionalityCheckBox = new System.Windows.Forms.CheckedListBox();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.apparatNameTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addMenuHeader = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MainView.SuspendLayout();
            this.ApparatMenu.SuspendLayout();
            this.AddMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddApparatButton
            // 
            this.AddApparatButton.Location = new System.Drawing.Point(686, 370);
            this.AddApparatButton.Name = "AddApparatButton";
            this.AddApparatButton.Size = new System.Drawing.Size(75, 23);
            this.AddApparatButton.TabIndex = 4;
            this.AddApparatButton.Text = "Add new";
            this.AddApparatButton.UseVisualStyleBackColor = true;
            this.AddApparatButton.Click += new System.EventHandler(this.AddApparat_Click);
            // 
            // MainView
            // 
            this.MainView.Controls.Add(this.ApparatMenu);
            this.MainView.Controls.Add(this.AddMenu);
            this.MainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainView.Location = new System.Drawing.Point(0, 0);
            this.MainView.Name = "MainView";
            this.MainView.SelectedIndex = 0;
            this.MainView.Size = new System.Drawing.Size(800, 450);
            this.MainView.TabIndex = 5;
            this.MainView.TabStop = false;
            // 
            // ApparatMenu
            // 
            this.ApparatMenu.Controls.Add(this.listView1);
            this.ApparatMenu.Controls.Add(this.AddApparatButton);
            this.ApparatMenu.Location = new System.Drawing.Point(4, 22);
            this.ApparatMenu.Name = "ApparatMenu";
            this.ApparatMenu.Padding = new System.Windows.Forms.Padding(3);
            this.ApparatMenu.Size = new System.Drawing.Size(792, 424);
            this.ApparatMenu.TabIndex = 0;
            this.ApparatMenu.Text = "MainView";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(8, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(231, 168);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // AddMenu
            // 
            this.AddMenu.Controls.Add(this.label1);
            this.AddMenu.Controls.Add(this.functionalityCheckBox);
            this.AddMenu.Controls.Add(this.portComboBox);
            this.AddMenu.Controls.Add(this.portLabel);
            this.AddMenu.Controls.Add(this.apparatNameTextbox);
            this.AddMenu.Controls.Add(this.nameLabel);
            this.AddMenu.Controls.Add(this.addMenuHeader);
            this.AddMenu.Controls.Add(this.AddButton);
            this.AddMenu.Controls.Add(this.BackButton);
            this.AddMenu.Enabled = false;
            this.AddMenu.Location = new System.Drawing.Point(4, 22);
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Padding = new System.Windows.Forms.Padding(3);
            this.AddMenu.Size = new System.Drawing.Size(792, 424);
            this.AddMenu.TabIndex = 1;
            this.AddMenu.Text = "AddMenu";
            this.AddMenu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Functionality:";
            // 
            // functionalityCheckBox
            // 
            this.functionalityCheckBox.FormattingEnabled = true;
            this.functionalityCheckBox.Items.AddRange(new object[] {
            "Turn on/off",
            "Dimm Light"});
            this.functionalityCheckBox.Location = new System.Drawing.Point(22, 166);
            this.functionalityCheckBox.Name = "functionalityCheckBox";
            this.functionalityCheckBox.Size = new System.Drawing.Size(120, 94);
            this.functionalityCheckBox.TabIndex = 7;
            // 
            // portComboBox
            // 
            this.portComboBox.DisplayMember = "None";
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Items.AddRange(new object[] {
            "Port 1",
            "Port 2",
            "Port 3"});
            this.portComboBox.Location = new System.Drawing.Point(22, 110);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 6;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(19, 93);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Port:";
            // 
            // apparatNameTextbox
            // 
            this.apparatNameTextbox.Location = new System.Drawing.Point(22, 55);
            this.apparatNameTextbox.Name = "apparatNameTextbox";
            this.apparatNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.apparatNameTextbox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(19, 39);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // addMenuHeader
            // 
            this.addMenuHeader.AutoSize = true;
            this.addMenuHeader.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMenuHeader.Location = new System.Drawing.Point(17, 7);
            this.addMenuHeader.Name = "addMenuHeader";
            this.addMenuHeader.Size = new System.Drawing.Size(246, 27);
            this.addMenuHeader.TabIndex = 2;
            this.addMenuHeader.Text = "Add New Apparat Here:";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(709, 393);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(709, 7);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HomeAutomation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainView.ResumeLayout(false);
            this.ApparatMenu.ResumeLayout(false);
            this.AddMenu.ResumeLayout(false);
            this.AddMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddApparatButton;
        private System.Windows.Forms.TabPage ApparatMenu;
        private System.Windows.Forms.TabPage AddMenu;
        private System.Windows.Forms.TabControl MainView;
        private Button BackButton;
        private TextBox apparatNameTextbox;
        private Label nameLabel;
        private Label addMenuHeader;
        private Button AddButton;
        private ComboBox portComboBox;
        private Label portLabel;
        private Label label1;
        private CheckedListBox functionalityCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListView listView1;
    }
}

