using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intership.Messenger.Client
{
    public partial class LoginForm : Form
    {
        ServerConnection _serverConnection;

        public LoginForm()
        {
            InitializeComponent();
            
        }

        public ServerConnection ServerConnection
        {
            get
            {
                return _serverConnection;
            }

           
        }

        async void ConnectAsync(object sender, EventArgs e)
        {
            await _serverConnection.Connect(txtServerIP.Text, Convert.ToInt32(txtServerPort.Text), txtNickname.Text);

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _serverConnection = new ServerConnection();
            //_serverConnection.Connect(txtServerIP.Text, Convert.ToInt32(txtServerPort.Text), txtNickname.Text);
            ConnectAsync(sender, e);
            //TODO: Connect to server
            this.Close();

         
        }


    }
}
