using Client.OtherForm;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private Socket serverSocket;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(IPAddress.Parse("192.168.0.104"), 22000);
            }
            catch { MessageBox.Show("Could not find server..."); Close(); }
            //

            byte[] buffer = Encoding.UTF8.GetBytes($"{textBoxLogin.Text} {textBoxPassword.Text}");
            serverSocket.Send(buffer);

            Task.Run(() => ReceiveAnswer(serverSocket));
        }

        private void ReceiveAnswer(Socket serverSocket)
        {
            byte[] buffer = new byte[10];
            serverSocket.Receive(buffer);
            string message = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty);

            if (message.Equals("Enter"))
            {
                ClientForm form = new ClientForm(serverSocket);
                form.ShowDialog();
            }
        }
    }
}
