using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.OtherForm
{
    public partial class AdminForm : Form
    {
        private string pathToXml;

        public AdminForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "XmlFiles | *.xml;";
            pathToXml = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\Xml";
        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(pathToXml))
                {
                    FileInfo file = new FileInfo(openFileDialog.FileName);
                    file.MoveTo($@"{pathToXml}\{file.Name}");
                }
            }
        }
    }
}
