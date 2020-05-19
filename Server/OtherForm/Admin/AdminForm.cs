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
using Repository;
using Server.OtherForm.Admin;
using Tables;
using Xml2CSharp;

namespace Server.OtherForm
{
    public partial class AdminForm : Form
    {
        private string pathToXml;
        private GenericUnitOfWork work;
        private User user;

        public AdminForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();

            this.work = work;
            this.user = user;

            openFileDialog.Filter = "XmlFiles | *.xml;";
            pathToXml = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\Xml";
        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(pathToXml))
                {
                    FileInfo file = new FileInfo(openFileDialog.FileName);
                    file.MoveTo($@"{pathToXml}\{file.Name}");

                    Tests tests = null;

                    using (FileStream stream = new FileStream($@"{pathToXml}\{file.Name}", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Tests));
                        tests = (Tests)serializer.Deserialize(stream);
                    }

                    Tables.Test testTable = new Tables.Test();
                    testTable.Title = tests.Subject;
                    testTable.Path = $@"{pathToXml}\{file.Name}";
                    testTable.Dt = DateTime.Parse(tests.Date);
                    testTable.PassTime = int.Parse(tests.PassTime);
                    testTable.User = user;
                    work.Repository<Tables.Test>().Add(testTable);
                }
            }
        }

        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            AddGroupForm form = new AddGroupForm(work);
            form.ShowDialog();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm(work);
            form.ShowDialog();
        }
    }
}
