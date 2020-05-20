using ClientServerDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xml2CSharp;

namespace Client.OtherForm
{
    public partial class ClientForm : Form
    {
        private Socket socket;
        private Tests tests;

        public ClientForm(Socket socket)
        {
            InitializeComponent();

            this.socket = socket;
            listViewTests.Columns.Add("Tests", 190);
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Task.Run(() => ReceiveTest(socket));
        }

        private void ReceiveTest(Socket socket)
        {
            while(true)
            {
                byte[] buffer = new byte[8000];
                int nCount = socket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer);

                tests = Converter.FromByteArray<Tests>(buffer);

                listViewTests.Invoke(new Action(() => { listViewTests.Items.Add(tests.ToString()); }));
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if(listViewTests.SelectedItems.Count > 0)
            {
                RunTestForm form = new RunTestForm(socket, tests);
                form.ShowDialog();
            }
        }
    }
}
