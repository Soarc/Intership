using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessangerClient
{
    public partial class LoginForm : Form
    {
        ServerConnection _serverconnection;
        public LoginForm()
        {
            InitializeComponent();
        }

        public ServerConnection ServerConnection
        {
            get
            {
                return _serverconnection;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void LoginBt_Click(object sender, EventArgs e)
        {
           _serverconnection  = new ServerConnection();
            _serverconnection.Connect(IptxtTxtbox.Text,Convert.ToInt32(PortTxtbox.Text),NickTxt.Text);
            this.Close();
        }
    }
}
