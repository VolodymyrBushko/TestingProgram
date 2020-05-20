namespace Server.OtherForm
{
    partial class TeacherForm
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
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.listBoxStudents = new System.Windows.Forms.ListBox();
            this.buttonSendTest = new System.Windows.Forms.Button();
            this.bindingSourceTests = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceStudents = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemoveTest = new System.Windows.Forms.Button();
            this.buttonAddTest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewConnectStudents = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudents)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTests
            // 
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.Location = new System.Drawing.Point(77, 0);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.Size = new System.Drawing.Size(103, 225);
            this.listBoxTests.TabIndex = 0;
            // 
            // listBoxStudents
            // 
            this.listBoxStudents.FormattingEnabled = true;
            this.listBoxStudents.Location = new System.Drawing.Point(178, 95);
            this.listBoxStudents.Name = "listBoxStudents";
            this.listBoxStudents.Size = new System.Drawing.Size(106, 134);
            this.listBoxStudents.TabIndex = 1;
            // 
            // buttonSendTest
            // 
            this.buttonSendTest.Location = new System.Drawing.Point(3, 25);
            this.buttonSendTest.Name = "buttonSendTest";
            this.buttonSendTest.Size = new System.Drawing.Size(72, 23);
            this.buttonSendTest.TabIndex = 2;
            this.buttonSendTest.Text = "Send test";
            this.buttonSendTest.UseVisualStyleBackColor = true;
            this.buttonSendTest.Click += new System.EventHandler(this.buttonSendTest_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.buttonRemoveTest);
            this.panel1.Controls.Add(this.buttonAddTest);
            this.panel1.Controls.Add(this.buttonSendTest);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(78, 262);
            this.panel1.TabIndex = 5;
            // 
            // buttonRemoveTest
            // 
            this.buttonRemoveTest.Location = new System.Drawing.Point(3, 93);
            this.buttonRemoveTest.Name = "buttonRemoveTest";
            this.buttonRemoveTest.Size = new System.Drawing.Size(72, 23);
            this.buttonRemoveTest.TabIndex = 4;
            this.buttonRemoveTest.Text = "Remove test";
            this.buttonRemoveTest.UseVisualStyleBackColor = true;
            // 
            // buttonAddTest
            // 
            this.buttonAddTest.Location = new System.Drawing.Point(3, 64);
            this.buttonAddTest.Name = "buttonAddTest";
            this.buttonAddTest.Size = new System.Drawing.Size(72, 23);
            this.buttonAddTest.TabIndex = 3;
            this.buttonAddTest.Text = "Add test";
            this.buttonAddTest.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Location = new System.Drawing.Point(77, 223);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 39);
            this.panel2.TabIndex = 6;
            // 
            // listViewConnectStudents
            // 
            this.listViewConnectStudents.HideSelection = false;
            this.listViewConnectStudents.Location = new System.Drawing.Point(178, 0);
            this.listViewConnectStudents.MultiSelect = false;
            this.listViewConnectStudents.Name = "listViewConnectStudents";
            this.listViewConnectStudents.Size = new System.Drawing.Size(106, 95);
            this.listViewConnectStudents.TabIndex = 0;
            this.listViewConnectStudents.UseCompatibleStateImageBehavior = false;
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.listViewConnectStudents);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxStudents);
            this.Controls.Add(this.listBoxTests);
            this.Name = "TeacherForm";
            this.Text = "TeacherForm";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudents)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.ListBox listBoxStudents;
        private System.Windows.Forms.Button buttonSendTest;
        private System.Windows.Forms.BindingSource bindingSourceTests;
        private System.Windows.Forms.BindingSource bindingSourceStudents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRemoveTest;
        private System.Windows.Forms.Button buttonAddTest;
        private System.Windows.Forms.ListView listViewConnectStudents;
    }
}