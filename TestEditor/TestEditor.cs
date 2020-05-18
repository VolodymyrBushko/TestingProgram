﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Xml2CSharp;

namespace TestEditor
{
    public partial class TestEditor : Form
    {
        private Tests tests;

        public TestEditor()
        {
            InitializeComponent();
            openFileDialog.Filter = "XmlFiles | *.xml;";
        }

        private void UIFromObject()
        {
            panelMain.Controls.Clear();
            int stepHeight = 25;

            if (listBox.SelectedItem != null)
            {
                foreach (var answer in (listBox.SelectedItem as Test).Answers.Answer)
                {
                    #region Initialize UI elements
                    Panel panel = new Panel();
                    TextBox textBox = new TextBox();
                    CheckBox checkBox = new CheckBox();
                    Label label = new Label();

                    panel.Controls.Add(textBox);
                    panel.Controls.Add(checkBox);

                    panel.Size = new Size(203, 30);
                    panel.Location = new Point(5, stepHeight);
                    stepHeight += 25;

                    label.Text = "Answers :";
                    label.Location = new Point(10, 10);

                    textBox.Location = new Point(3, 5);
                    textBox.Text = answer.Text;

                    checkBox.Location = new Point(120, 3);
                    checkBox.Text = "IsRight";

                    if (answer.IsRight == "true")
                        checkBox.Checked = true;
                    #endregion

                    #region Include events to UI elements
                    textBox.TextChanged += (s, e) => answer.Text = textBox.Text;
                    checkBox.CheckedChanged += (s, e) => answer.IsRight = checkBox.Checked.ToString().ToLower();
                    #endregion

                    #region Add UI elements to panel
                    panelMain.Controls.Add(panel);
                    panelMain.Controls.Add(label);
                    #endregion
                }
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonCreate.Enabled = false;
                buttonBrowse.Enabled = false;

                buttonBrowse.BackColor = Color.LightYellow;

                using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Tests));
                    tests = (Tests)serializer.Deserialize(stream);

                    bindingSource.DataSource = tests.Test;
                    listBox.DataSource = bindingSource;

                    Text = openFileDialog.FileName;

                    UIFromObject();
                }
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Test test = listBox.SelectedItem as Test;

                textBoxAuthor.Text = test.Author;
                textBoxName.Text = test.Name;
                textBoxDate.Text = test.Date;
                textBoxDescription.Text = test.Description;

                UIFromObject();
            }
        }

        private void TestEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tests != null)
            {
                string fileName = string.Empty;

                if (buttonCreate.BackColor == Color.LightYellow)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        fileName = saveFileDialog.FileName;
                    else
                        return;
                }
                else
                    fileName = openFileDialog.FileName;

                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Tests));
                    serializer.Serialize(stream, tests);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Test test = listBox.SelectedItem as Test;

                test.Author = textBoxAuthor.Text;
                test.Name = textBoxName.Text;
                test.Date = textBoxDate.Text;
                test.Description = textBoxDescription.Text;

                buttonSave.BackColor = Color.PaleGreen;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (buttonBrowse.Enabled == false)
            {
                NewTestForm form = new NewTestForm(tests);
                form.ShowDialog();
                bindingSource.ResetBindings(false);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Test test = listBox.SelectedItem as Test;
                tests.Test.Remove(test);
                bindingSource.ResetBindings(false);
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (tests != null)
                buttonSave.BackColor = Color.Firebrick;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            buttonBrowse.Enabled = false;
            buttonCreate.Enabled = false;

            buttonCreate.BackColor = Color.LightYellow;

            tests = new Tests();
            tests.Test = new List<Test>();

            bindingSource.DataSource = tests.Test;
            listBox.DataSource = bindingSource;
        }
    }
}
