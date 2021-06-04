using Server;
using SimpleTCP;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Client : Form
    {
        private SimpleTcpClient client;

        public Client()
        {
            InitializeComponent();
            InitNewClient();
        }

        private void InitNewClient()
        {
            textBox1.Text = "127.0.0.1";
            textBox12.Text = "2020";
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += DataReceived;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {

                client.Connect(textBox1.Text, Convert.ToInt32(textBox12.Text));
            
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
                byte[] signature = Signature.Signature1(messageTxt.Text);

                string clientSignature = Encoding.UTF8.GetString(signature);
                string clientMsg = messageTxt.Text;
                //ServerSignature
                HelperMethods.CallExtraMethod(clientMsg, signature);

                client.Write(clientMsg);

        }

        private void DataReceived(Object sender, SimpleTCP.Message msg)
        {
           /* statusTxt.Invoke((MethodInvoker)delegate
            {
                statusTxt.Text = msg.MessageString;
            });*/
        }
    }
}