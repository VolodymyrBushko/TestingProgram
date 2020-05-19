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

                    try
                    {
                        Tables.Test testTable = new Tables.Test();
                        testTable.Title = tests.Subject;
                        testTable.Path = $@"{pathToXml}\{file.Name}";
                        testTable.Dt = DateTime.Parse(tests.Date);
                        testTable.PassTime = int.Parse(tests.PassTime);
                        testTable.User = user;
                        work.Repository<Tables.Test>().Add(testTable);
                    }
                    catch { MessageBox.Show("Bad format of XML"); }
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

        private async void buttonShow(object sender, EventArgs e)
        {
            await work.SaveAsync();

            switch ((sender as Button).Text)
            {
                case "Show tests":
                    bindingSource.DataSource = work.Repository<Tables.Test>().GetAll().Select(x => new
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Date = x.Dt,
                        PassTime = x.PassTime
                    }).ToList();
                    break;
                case "Show users":
                    bindingSource.DataSource = work.Repository<User>().GetAll().Select(x => new
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Login = x.Login,
                        Password = x.Password,
                        Group = x.Group.Title
                    }).ToList();
                    break;
                case "Show groups":
                    bindingSource.DataSource = work.Repository<Group>().GetAll().Select(x => new
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToList();
                    break;
                case "Show results":
                    bindingSource.DataSource = work.Repository<Result>().GetAll().Select(x => new
                    {
                        Id = x.Id,
                        Date = x.Dt,
                        Rating = x.Rating,
                        Test = x.Test.Title,
                        Student = x.User.Login
                    }).ToList();
                    break;
            }
            dataGridView.DataSource = bindingSource;
            labelNavigator.Text = (sender as Button).Text;
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            work.SaveChanges();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows[0] != null)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                switch (labelNavigator.Text)
                {
                    case "Show users":
                        work.Repository<User>().Remove(work.Repository<User>().GetAll().FirstOrDefault(x => x.Id == id));
                        break;
                    case "Show groups":
                        work.Repository<Group>().Remove(work.Repository<Group>().GetAll().FirstOrDefault(x => x.Id == id));
                        break;
                    case "Show results":
                        work.Repository<Result>().Remove(work.Repository<Result>().GetAll().FirstOrDefault(x => x.Id == id));
                        break;
                    case "Show tests":
                        Tables.Test test = work.Repository<Tables.Test>().GetAll().FirstOrDefault(x => x.Id == id);
                        if (File.Exists(test.Path)) File.Delete(test.Path);
                        work.Repository<Tables.Test>().Remove(test);
                        break;
                }
                work.SaveChanges();
                bindingSource.ResetBindings(false);
            }
        }
    }
}
