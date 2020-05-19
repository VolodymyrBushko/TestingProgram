using Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using Tables;

namespace Server.OtherForm.Admin
{
    public partial class AddUserForm : Form
    {
        private GenericUnitOfWork work;

        public AddUserForm(GenericUnitOfWork work)
        {
            InitializeComponent();

            this.work = work;

            bindingSource.DataSource = work.Repository<Group>().GetAll().ToList();
            comboBoxGroups.DataSource = bindingSource.DataSource;
            comboBoxGroups.SelectedItem = comboBoxGroups.Items[0];
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Controls.OfType<TextBox>().Count(x => string.IsNullOrWhiteSpace(x.Text)) == 0)
            {
                User user = new User();
                user.Name = textBoxName.Text;
                user.Login = textBoxLogin.Text;
                user.Password = textBoxPassword.Text;
                user.Group = comboBoxGroups.SelectedItem as Group;
                work.Repository<User>().Add(user);
            }
            Controls.OfType<TextBox>().ToList().ForEach(x => { if (x.ReadOnly != true) x.Clear(); });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
