using Repository;
using Server.OtherForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tables;

namespace Server
{
    public partial class Form1 : Form
    {
        private GenericUnitOfWork work;
        private List<User> users;

        public Form1()
        {
            InitializeComponent();

            work = new GenericUnitOfWork(new Context(ConfigurationManager.ConnectionStrings["ConnectToDb"].ConnectionString));
            users = work.Repository<User>().GetAll().ToList();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            User user = users.FirstOrDefault(x => x.Login == textBoxLogin.Text && x.Password == textBoxPassword.Text);
            Form form = null;

            if (user != null)
            {
                switch (user.Group.Title)
                {
                    case "Admin": form = new AdminForm(work, user); break;
                    case "Teacher": form = new TeacherForm(work); break;
                    default: MessageBox.Show("Refusal to access"); return;
                }
                form.ShowDialog();
            }
            else
                MessageBox.Show("Bad login or password");
        }
    }
}
