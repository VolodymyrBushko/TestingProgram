using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tables;

namespace Server.OtherForm
{
    public partial class TeacherForm : Form
    {
        private GenericUnitOfWork work;

        public TeacherForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();

            this.work = work;
            Text += $" - {user.Login}";
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            bindingSourceTests.DataSource = work.Repository<Test>().GetAll();
            listBoxTests.DataSource = bindingSourceTests.DataSource;

            bindingSourceStudents.DataSource = work.Repository<User>().GetAll().Where(x => x.Group.Title.Equals("Student")).ToList();
            listBoxStudents.DataSource = bindingSourceStudents.DataSource;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

        }
    }
}
