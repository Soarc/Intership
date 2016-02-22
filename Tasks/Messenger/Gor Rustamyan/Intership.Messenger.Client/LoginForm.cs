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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            _serverConnection = new ServerConnection();
            _serverConnection.Connect(txtServerIP.Text, Convert.ToInt32(txtServerPort.Text), txtNickname.Text);
            //TODO: Connect to server
            this.Close();

         
        }
    }
}
