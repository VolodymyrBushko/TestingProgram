using ClientServerDll;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Tables;
using Xml2CSharp;

namespace Server.OtherForm
{
    public partial class TeacherForm : Form
    {
        private Socket listenSocket;
        private GenericUnitOfWork work;

        public TeacherForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();

            this.work = work;
            Text += $" - {user.Login}";
            listViewConnectStudents.Columns.Add("Connect students", 106);
        }

        [Obsolete]
        private void TeacherForm_Load(object sender, EventArgs e)
        {
            bindingSourceTests.DataSource = work.Repository<Tables.Test>().GetAll();
            listBoxTests.DataSource = bindingSourceTests.DataSource;

            bindingSourceStudents.DataSource = work.Repository<User>().GetAll().Where(x => x.Group.Title.Equals("Student")).ToList();
            listBoxStudents.DataSource = bindingSourceStudents.DataSource;

            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listenSocket.Bind(new IPEndPoint(Dns.Resolve(SystemInformation.ComputerName).AddressList[1], 22000));
            listenSocket.Listen(3);

            Task.Run(() => ExpectConnect(listenSocket));
        }

        private void ExpectConnect(Socket listenSocket)
        {
            while (true)
            {
                try
                {
                    Socket clientSocket = listenSocket.Accept();
                    Task.Run(() => LogInStudent(clientSocket));
                }
                catch { }
            }
        }

        private void LogInStudent(Socket clientSocket)
        {
            while (true)
            {
                byte[] buffer = new byte[256];
                clientSocket.Receive(buffer);

                string[] message = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty).Split(' ');
                string login = message[0], password = message[1];

                User student = work.Repository<User>().GetAll().FirstOrDefault(
                    x => x.Login == login && x.Password == password && x.Group.Title == "Student");

                listViewConnectStudents.Invoke(new Action(() =>
                {
                    // Якщо студент != null, то відправити клієнту дозвіл
                    if (student != null)
                    {
                        listViewConnectStudents.Items.Add(student.ToString());
                        listViewConnectStudents.Items[listViewConnectStudents.Items.Count - 1].Tag = clientSocket;
                        clientSocket.Send(Encoding.UTF8.GetBytes("Enter"));
                    }
                }));
            }
        }

        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            //Тут маємо вибраному студенту відправити вибраний тест
            if (listViewConnectStudents.SelectedItems.Count > 0 && listBoxTests.SelectedItem != null)
            {
                Socket clientSocket = (listViewConnectStudents.SelectedItems[0].Tag as Socket);
                Tables.Test currentTest = listBoxTests.SelectedItem as Tables.Test;

                if (work.Repository<Tables.Test>().GetAll().FirstOrDefault(x => x.Id == currentTest.Id) != null)
                {
                    if (File.Exists(currentTest.Path))
                    {
                        Tests tests = null;

                        using (FileStream stream = new FileStream(currentTest.Path, FileMode.Open))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Tests));
                            tests = (Tests)serializer.Deserialize(stream);
                        }

                        byte[] buffer = Converter.ToByteArray<Tests>(tests);
                        clientSocket.Send(buffer);
                    }
                }
            }
        }
    }
}
