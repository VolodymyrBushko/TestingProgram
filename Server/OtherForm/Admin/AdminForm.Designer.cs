﻿namespace Server.OtherForm
{
    partial class AdminForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonShowTests = new System.Windows.Forms.Button();
            this.buttonShowUsers = new System.Windows.Forms.Button();
            this.buttonShowGroups = new System.Windows.Forms.Button();
            this.buttonShowResults = new System.Windows.Forms.Button();
            this.buttonAddGroup = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonAddTest = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.labelNavigator = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRemove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Controls.Add(this.buttonShowTests);
            this.panel1.Controls.Add(this.buttonShowUsers);
            this.panel1.Controls.Add(this.buttonShowGroups);
            this.panel1.Controls.Add(this.buttonShowResults);
            this.panel1.Controls.Add(this.buttonAddGroup);
            this.panel1.Controls.Add(this.buttonAddUser);
            this.panel1.Controls.Add(this.buttonAddTest);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 361);
            this.panel1.TabIndex = 0;
            // 
            // buttonShowTests
            // 
            this.buttonShowTests.Location = new System.Drawing.Point(3, 239);
            this.buttonShowTests.Name = "buttonShowTests";
            this.buttonShowTests.Size = new System.Drawing.Size(101, 23);
            this.buttonShowTests.TabIndex = 6;
            this.buttonShowTests.Text = "Show tests";
            this.buttonShowTests.UseVisualStyleBackColor = true;
            this.buttonShowTests.Click += new System.EventHandler(this.buttonShow);
            // 
            // buttonShowUsers
            // 
            this.buttonShowUsers.Location = new System.Drawing.Point(3, 268);
            this.buttonShowUsers.Name = "buttonShowUsers";
            this.buttonShowUsers.Size = new System.Drawing.Size(101, 23);
            this.buttonShowUsers.TabIndex = 5;
            this.buttonShowUsers.Text = "Show users";
            this.buttonShowUsers.UseVisualStyleBackColor = true;
            this.buttonShowUsers.Click += new System.EventHandler(this.buttonShow);
            // 
            // buttonShowGroups
            // 
            this.buttonShowGroups.Location = new System.Drawing.Point(3, 297);
            this.buttonShowGroups.Name = "buttonShowGroups";
            this.buttonShowGroups.Size = new System.Drawing.Size(101, 23);
            this.buttonShowGroups.TabIndex = 4;
            this.buttonShowGroups.Text = "Show groups";
            this.buttonShowGroups.UseVisualStyleBackColor = true;
            this.buttonShowGroups.Click += new System.EventHandler(this.buttonShow);
            // 
            // buttonShowResults
            // 
            this.buttonShowResults.Location = new System.Drawing.Point(3, 326);
            this.buttonShowResults.Name = "buttonShowResults";
            this.buttonShowResults.Size = new System.Drawing.Size(101, 23);
            this.buttonShowResults.TabIndex = 3;
            this.buttonShowResults.Text = "Show results";
            this.buttonShowResults.UseVisualStyleBackColor = true;
            this.buttonShowResults.Click += new System.EventHandler(this.buttonShow);
            // 
            // buttonAddGroup
            // 
            this.buttonAddGroup.Location = new System.Drawing.Point(3, 70);
            this.buttonAddGroup.Name = "buttonAddGroup";
            this.buttonAddGroup.Size = new System.Drawing.Size(101, 23);
            this.buttonAddGroup.TabIndex = 2;
            this.buttonAddGroup.Text = "Add group";
            this.buttonAddGroup.UseVisualStyleBackColor = true;
            this.buttonAddGroup.Click += new System.EventHandler(this.buttonAddGroup_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(3, 41);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(101, 23);
            this.buttonAddUser.TabIndex = 1;
            this.buttonAddUser.Text = "Add user";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonAddTest
            // 
            this.buttonAddTest.Location = new System.Drawing.Point(3, 12);
            this.buttonAddTest.Name = "buttonAddTest";
            this.buttonAddTest.Size = new System.Drawing.Size(101, 23);
            this.buttonAddTest.TabIndex = 0;
            this.buttonAddTest.Text = "Add test";
            this.buttonAddTest.UseVisualStyleBackColor = true;
            this.buttonAddTest.Click += new System.EventHandler(this.buttonAddTest_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel.Controls.Add(this.labelNavigator);
            this.panel.Controls.Add(this.dataGridView);
            this.panel.Location = new System.Drawing.Point(162, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(310, 337);
            this.panel.TabIndex = 1;
            // 
            // labelNavigator
            // 
            this.labelNavigator.AutoSize = true;
            this.labelNavigator.Location = new System.Drawing.Point(15, 9);
            this.labelNavigator.Name = "labelNavigator";
            this.labelNavigator.Size = new System.Drawing.Size(0, 13);
            this.labelNavigator.TabIndex = 1;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 29);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(279, 279);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(3, 161);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(101, 23);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonShowTests;
        private System.Windows.Forms.Button buttonShowUsers;
        private System.Windows.Forms.Button buttonShowGroups;
        private System.Windows.Forms.Button buttonShowResults;
        private System.Windows.Forms.Button buttonAddGroup;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonAddTest;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label labelNavigator;
        private System.Windows.Forms.Button buttonRemove;
    }
}