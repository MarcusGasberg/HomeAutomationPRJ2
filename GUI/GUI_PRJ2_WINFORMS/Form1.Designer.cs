﻿using System.Collections.Generic;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddApparatButton = new System.Windows.Forms.Button();
            this.mainView = new System.Windows.Forms.TabControl();
            this.ApparatMenu = new System.Windows.Forms.TabPage();
            this.serialCommunicationGroup = new System.Windows.Forms.GroupBox();
            this.comboBox_baudRate = new System.Windows.Forms.ComboBox();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.availableCOM = new System.Windows.Forms.Label();
            this.comboBox_available_serialPorts = new System.Windows.Forms.ComboBox();
            this.apparatsGroup = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddMenu = new System.Windows.Forms.TabPage();
            this.addButton = new System.Windows.Forms.Button();
            this.backButton1 = new System.Windows.Forms.Button();
            this.apparatAttributes = new System.Windows.Forms.GroupBox();
            this.functionalityCheckBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.apparatNameTextbox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.Settings = new System.Windows.Forms.TabPage();
            this.backButton2 = new System.Windows.Forms.Button();
            this.settingsGroup = new System.Windows.Forms.GroupBox();
            this.dimmerText = new System.Windows.Forms.Label();
            this.onOffButton = new System.Windows.Forms.Button();
            this.dimmerScroll = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.mainView.SuspendLayout();
            this.ApparatMenu.SuspendLayout();
            this.serialCommunicationGroup.SuspendLayout();
            this.apparatsGroup.SuspendLayout();
            this.AddMenu.SuspendLayout();
            this.apparatAttributes.SuspendLayout();
            this.Settings.SuspendLayout();
            this.settingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimmerScroll)).BeginInit();
            this.SuspendLayout();
            // 
            // AddApparatButton
            // 
            this.AddApparatButton.Location = new System.Drawing.Point(495, 304);
            this.AddApparatButton.Name = "AddApparatButton";
            this.AddApparatButton.Size = new System.Drawing.Size(75, 23);
            this.AddApparatButton.TabIndex = 4;
            this.AddApparatButton.Text = "Add new";
            this.AddApparatButton.UseVisualStyleBackColor = true;
            this.AddApparatButton.Click += new System.EventHandler(this.AddApparat_Click);
            // 
            // mainView
            // 
            this.mainView.Controls.Add(this.ApparatMenu);
            this.mainView.Controls.Add(this.AddMenu);
            this.mainView.Controls.Add(this.Settings);
            this.mainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainView.Location = new System.Drawing.Point(0, 0);
            this.mainView.Name = "mainView";
            this.mainView.SelectedIndex = 0;
            this.mainView.Size = new System.Drawing.Size(584, 361);
            this.mainView.TabIndex = 5;
            this.mainView.TabStop = false;
            // 
            // ApparatMenu
            // 
            this.ApparatMenu.Controls.Add(this.serialCommunicationGroup);
            this.ApparatMenu.Controls.Add(this.AddApparatButton);
            this.ApparatMenu.Controls.Add(this.apparatsGroup);
            this.ApparatMenu.Location = new System.Drawing.Point(4, 22);
            this.ApparatMenu.Name = "ApparatMenu";
            this.ApparatMenu.Padding = new System.Windows.Forms.Padding(3);
            this.ApparatMenu.Size = new System.Drawing.Size(576, 335);
            this.ApparatMenu.TabIndex = 0;
            this.ApparatMenu.Text = "MainView";
            // 
            // serialCommunicationGroup
            // 
            this.serialCommunicationGroup.Controls.Add(this.comboBox_baudRate);
            this.serialCommunicationGroup.Controls.Add(this.baudRateLabel);
            this.serialCommunicationGroup.Controls.Add(this.availableCOM);
            this.serialCommunicationGroup.Controls.Add(this.comboBox_available_serialPorts);
            this.serialCommunicationGroup.Location = new System.Drawing.Point(261, 7);
            this.serialCommunicationGroup.Name = "serialCommunicationGroup";
            this.serialCommunicationGroup.Size = new System.Drawing.Size(309, 80);
            this.serialCommunicationGroup.TabIndex = 8;
            this.serialCommunicationGroup.TabStop = false;
            this.serialCommunicationGroup.Text = "Serial Settings";
            // 
            // comboBox_baudRate
            // 
            this.comboBox_baudRate.FormattingEnabled = true;
            this.comboBox_baudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.comboBox_baudRate.Location = new System.Drawing.Point(137, 37);
            this.comboBox_baudRate.Name = "comboBox_baudRate";
            this.comboBox_baudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBox_baudRate.TabIndex = 3;
            this.comboBox_baudRate.SelectionChangeCommitted += new System.EventHandler(this.comboBox_baudRate_SelectionChangeCommitted);
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(134, 20);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(55, 13);
            this.baudRateLabel.TabIndex = 2;
            this.baudRateLabel.Text = "BaudRate";
            // 
            // availableCOM
            // 
            this.availableCOM.AutoSize = true;
            this.availableCOM.Location = new System.Drawing.Point(6, 18);
            this.availableCOM.Name = "availableCOM";
            this.availableCOM.Size = new System.Drawing.Size(84, 13);
            this.availableCOM.TabIndex = 1;
            this.availableCOM.Text = "Available COM\'s";
            // 
            // comboBox_available_serialPorts
            // 
            this.comboBox_available_serialPorts.FormattingEnabled = true;
            this.comboBox_available_serialPorts.Location = new System.Drawing.Point(6, 38);
            this.comboBox_available_serialPorts.Name = "comboBox_available_serialPorts";
            this.comboBox_available_serialPorts.Size = new System.Drawing.Size(121, 21);
            this.comboBox_available_serialPorts.TabIndex = 0;
            this.comboBox_available_serialPorts.SelectionChangeCommitted += new System.EventHandler(this.comboBox_available_serialPorts_SelectionChangeCommitted);
            // 
            // apparatsGroup
            // 
            this.apparatsGroup.Controls.Add(this.deleteButton);
            this.apparatsGroup.Controls.Add(this.listView1);
            this.apparatsGroup.Location = new System.Drawing.Point(6, 6);
            this.apparatsGroup.Name = "apparatsGroup";
            this.apparatsGroup.Size = new System.Drawing.Size(248, 225);
            this.apparatsGroup.TabIndex = 7;
            this.apparatsGroup.TabStop = false;
            this.apparatsGroup.Text = "Available Apparats";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(6, 193);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(231, 168);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // AddMenu
            // 
            this.AddMenu.Controls.Add(this.addButton);
            this.AddMenu.Controls.Add(this.backButton1);
            this.AddMenu.Controls.Add(this.apparatAttributes);
            this.AddMenu.Enabled = false;
            this.AddMenu.Location = new System.Drawing.Point(4, 22);
            this.AddMenu.Name = "AddMenu";
            this.AddMenu.Padding = new System.Windows.Forms.Padding(3);
            this.AddMenu.Size = new System.Drawing.Size(576, 335);
            this.AddMenu.TabIndex = 1;
            this.AddMenu.Text = "AddMenu";
            this.AddMenu.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(498, 309);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // backButton1
            // 
            this.backButton1.Location = new System.Drawing.Point(498, 3);
            this.backButton1.Name = "backButton1";
            this.backButton1.Size = new System.Drawing.Size(75, 23);
            this.backButton1.TabIndex = 0;
            this.backButton1.Text = "Back";
            this.backButton1.UseVisualStyleBackColor = true;
            this.backButton1.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // apparatAttributes
            // 
            this.apparatAttributes.Controls.Add(this.functionalityCheckBox);
            this.apparatAttributes.Controls.Add(this.label1);
            this.apparatAttributes.Controls.Add(this.apparatNameTextbox);
            this.apparatAttributes.Controls.Add(this.nameLabel);
            this.apparatAttributes.Controls.Add(this.portComboBox);
            this.apparatAttributes.Controls.Add(this.portLabel);
            this.apparatAttributes.Location = new System.Drawing.Point(8, 7);
            this.apparatAttributes.Name = "apparatAttributes";
            this.apparatAttributes.Size = new System.Drawing.Size(189, 220);
            this.apparatAttributes.TabIndex = 9;
            this.apparatAttributes.TabStop = false;
            this.apparatAttributes.Text = "Apparat Attributes";
            // 
            // functionalityCheckBox
            // 
            this.functionalityCheckBox.FormattingEnabled = true;
            this.functionalityCheckBox.Items.AddRange(new object[] {
            "Turn on/off",
            "Dimm Light"});
            this.functionalityCheckBox.Location = new System.Drawing.Point(14, 112);
            this.functionalityCheckBox.Name = "functionalityCheckBox";
            this.functionalityCheckBox.Size = new System.Drawing.Size(120, 94);
            this.functionalityCheckBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Functionality:";
            // 
            // apparatNameTextbox
            // 
            this.apparatNameTextbox.Location = new System.Drawing.Point(14, 33);
            this.apparatNameTextbox.Name = "apparatNameTextbox";
            this.apparatNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.apparatNameTextbox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(11, 17);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Name:";
            // 
            // portComboBox
            // 
            this.portComboBox.DisplayMember = "None";
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Items.AddRange(new object[] {
            "Port 0",
            "Port 1",
            "Port 2"});
            this.portComboBox.Location = new System.Drawing.Point(14, 72);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(121, 21);
            this.portComboBox.TabIndex = 6;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(11, 56);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 5;
            this.portLabel.Text = "Port:";
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.backButton2);
            this.Settings.Controls.Add(this.settingsGroup);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(576, 335);
            this.Settings.TabIndex = 2;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // backButton2
            // 
            this.backButton2.Location = new System.Drawing.Point(498, 3);
            this.backButton2.Name = "backButton2";
            this.backButton2.Size = new System.Drawing.Size(75, 23);
            this.backButton2.TabIndex = 4;
            this.backButton2.Text = "Back";
            this.backButton2.UseVisualStyleBackColor = true;
            this.backButton2.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // settingsGroup
            // 
            this.settingsGroup.Controls.Add(this.dimmerText);
            this.settingsGroup.Controls.Add(this.onOffButton);
            this.settingsGroup.Controls.Add(this.dimmerScroll);
            this.settingsGroup.Location = new System.Drawing.Point(8, 12);
            this.settingsGroup.Name = "settingsGroup";
            this.settingsGroup.Size = new System.Drawing.Size(200, 135);
            this.settingsGroup.TabIndex = 3;
            this.settingsGroup.TabStop = false;
            this.settingsGroup.Text = "Settings";
            // 
            // dimmerText
            // 
            this.dimmerText.AutoSize = true;
            this.dimmerText.Location = new System.Drawing.Point(6, 55);
            this.dimmerText.Name = "dimmerText";
            this.dimmerText.Size = new System.Drawing.Size(42, 13);
            this.dimmerText.TabIndex = 2;
            this.dimmerText.Text = "Dimmer";
            // 
            // onOffButton
            // 
            this.onOffButton.Location = new System.Drawing.Point(6, 19);
            this.onOffButton.Name = "onOffButton";
            this.onOffButton.Size = new System.Drawing.Size(75, 23);
            this.onOffButton.TabIndex = 0;
            this.onOffButton.Text = "Turn On";
            this.onOffButton.UseVisualStyleBackColor = true;
            this.onOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // dimmerScroll
            // 
            this.dimmerScroll.Location = new System.Drawing.Point(6, 71);
            this.dimmerScroll.Maximum = 4;
            this.dimmerScroll.Name = "dimmerScroll";
            this.dimmerScroll.Size = new System.Drawing.Size(104, 45);
            this.dimmerScroll.TabIndex = 1;
            this.dimmerScroll.Scroll += new System.EventHandler(this.dimmer_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.mainView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "HomeAutomation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainView.ResumeLayout(false);
            this.ApparatMenu.ResumeLayout(false);
            this.serialCommunicationGroup.ResumeLayout(false);
            this.serialCommunicationGroup.PerformLayout();
            this.apparatsGroup.ResumeLayout(false);
            this.AddMenu.ResumeLayout(false);
            this.apparatAttributes.ResumeLayout(false);
            this.apparatAttributes.PerformLayout();
            this.Settings.ResumeLayout(false);
            this.settingsGroup.ResumeLayout(false);
            this.settingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dimmerScroll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button AddApparatButton;
        private System.Windows.Forms.TabPage ApparatMenu;
        private System.Windows.Forms.TabPage AddMenu;
        private System.Windows.Forms.TabControl mainView;
        private Button backButton1;
        private TextBox apparatNameTextbox;
        private Label nameLabel;
        private Button addButton;
        private ComboBox portComboBox;
        private Label portLabel;
        private Label label1;
        private CheckedListBox functionalityCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ListView listView1;
        private TabPage Settings;
        private Button onOffButton;
        private TrackBar dimmerScroll;
        private Label dimmerText;
        private System.IO.Ports.SerialPort serialPort1;
        private Button deleteButton;
        private GroupBox apparatsGroup;
        private GroupBox apparatAttributes;
        private GroupBox serialCommunicationGroup;
        private Label availableCOM;
        private ComboBox comboBox_available_serialPorts;
        private ComboBox comboBox_baudRate;
        private Label baudRateLabel;
        private GroupBox settingsGroup;
        private Button backButton2;
    }
}
