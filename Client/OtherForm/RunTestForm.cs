using ClientServerDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xml2CSharp;

namespace Client.OtherForm
{
    public partial class RunTestForm : Form
    {
        private Socket socket;
        private Tests tests;

        private bool flag = true;
        private int navigator, tick = 0, min = 0;

        public RunTestForm(Socket socket, Tests tests)
        {
            InitializeComponent();

            this.socket = socket;
            this.tests = tests;
        }

        private void RunTestForm_Load(object sender, EventArgs e)
        {
            textBoxAuthor.Text = tests.Author;
            textBoxSubject.Text = tests.Subject;
            textBoxDate.Text = tests.Date;
            textBoxPassTime.Text = tests.PassTime;

            foreach (var test in tests.Test)
                foreach (var answer in test.Answers.Answer)
                    answer.IsRight = "false";
        }

        public void MoveTest(object sender, EventArgs e)
        {
            if (flag)
            {
                timer.Start();
                flag = false;
            }

            if (navigator < tests.Test.Count - 1 && (sender as Button).Name.Equals("buttonNext"))
                navigator++;
            else if (navigator > 0 && (sender as Button).Name.Equals("buttonPrev"))
                navigator--;

            int stepHeight = 5;
            panelMain.Controls.Clear();

            foreach (var answer in tests.Test[navigator].Answers.Answer)
            {
                Panel panel = new Panel();
                TextBox textBox = new TextBox();
                CheckBox checkBox = new CheckBox();
                panel.Controls.Add(textBox);
                panel.Controls.Add(checkBox);
                panel.Size = new Size(203, 30);
                panel.Location = new Point(5, stepHeight);
                stepHeight += 30;
                textBox.Location = new Point(3, 10);
                textBox.Text = answer.Text;
                checkBox.Location = new Point(120, 8);
                checkBox.Text = "IsRight";
                if (answer.IsRight == "true") checkBox.Checked = true;
                checkBox.CheckedChanged += (s, evnt) => answer.IsRight = checkBox.Checked.ToString().ToLower();
                textBoxDescription.Text = tests.Test[navigator].Description;
                panelMain.Controls.Add(panel);
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                timer.Stop();
                flag = true;

                byte[] buffer = Converter.ToByteArray(tests);
                socket.Send(buffer);
                buttonEnd.Invoke(new Action(() => { this.Close(); }));
            });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tick++;

            if (tick == 60)
            {
                min++;
                tick = 0;
            }

            if (min >= int.Parse(textBoxPassTime.Text))
                buttonEnd_Click(null, null);

            Text = $"{min} : {tick}";
        }
    }
}
