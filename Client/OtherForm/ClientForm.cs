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

namespace Client.OtherForm
{
    public partial class ClientForm : Form
    {
        private Socket socket;

        public ClientForm(Socket socket)
        {
            InitializeComponent();

            this.socket = socket;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            Task.Run(() => ReceiveTest(socket));
        }

        private void ReceiveTest(Socket socket)
        {
            while(true)
            {
                byte[] buffer = new byte[256];
                socket.Receive(buffer);
                string message = Encoding.UTF8.GetString(buffer);
                MessageBox.Show("Client socketr read");
            }
        }
    }
}
