using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Xml2CSharp;

namespace TestEditor
{
    public partial class NewTestForm : Form
    {
        private Tests tests;

        public NewTestForm(Tests tests)
        {
            InitializeComponent();

            if (tests != null)
                this.tests = tests;
            else
            {
                Dispose();
                Close();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Count(x => string.IsNullOrWhiteSpace(x.Text)) == 0)
            {
                Test test = new Test();
                test.Description = textBoxDescription.Text;
                test.Difficulty = textBoxDifficulty.Text;

                test.Answers = new Answers();
                test.Answers.Count = textBoxAmountAnswer.Text;
                test.Answers.Answer = new List<Answer>();

                for (int i = 0; i < int.Parse(test.Answers.Count); i++)
                    test.Answers.Answer.Add(new Answer() { Text = "Null", IsRight = "false" });

                tests.Test.Add(test);
            }
            Dispose();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
    }
}
