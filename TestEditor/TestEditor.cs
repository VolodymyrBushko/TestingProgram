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
using System.Xml.Serialization;
using Xml2CSharp;

namespace TestEditor
{
    public partial class TestEditor : Form
    {
        public TestEditor()
        {
            InitializeComponent();
        }

        private void TestEditor_Load(object sender, EventArgs e)
        {
            openFileDialog.Filter = "XmlFiles | *.xml;";
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Tests));
                using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    Tests tests = (Tests)serializer.Deserialize(fileStream);
                    MessageBox.Show(tests.Test[0].Author);
                }
            }
        }
    }
}
