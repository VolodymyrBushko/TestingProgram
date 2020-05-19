using Repository;
using System;
using System.Windows.Forms;
using Tables;

namespace Server.OtherForm.Admin
{
    public partial class AddGroupForm : Form
    {
        private GenericUnitOfWork work;

        public AddGroupForm(GenericUnitOfWork work)
        {
            InitializeComponent();

            this.work = work;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Group group = new Group();

            if (!string.IsNullOrWhiteSpace(textBoxGroupName.Text))
            {
                group.Title = textBoxGroupName.Text;
                work.Repository<Group>().Add(group);
            }
            textBoxGroupName.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
