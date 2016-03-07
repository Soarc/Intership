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
    public partial class MessangerForm : Form
    {
        ServerConnection _serverconnection;
        public MessangerForm()
        {
            InitializeComponent();
        }

        private void MessangerFormLoad(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            _serverconnection = login.ServerConnection;

            _serverconnection.newUserConnected += OnNewUserConnect;
            _serverconnection.MessageReceived += OnNewMessage;
        }
        private void OnNewMessage(Message message)
        {              this.Invoke((Action)(() =>
            {
                var clientNick = _serverconnection.Users.FirstOrDefault(x => x.Id == message.ClientId).Nickname;

                if (clientNick != null)
                {
                    MessangerView.Items.Add($"{clientNick}: {message.MessageText}");
                }
            }));  
        }  
   
         private void OnNewUserConnect(User user)
        {  
             this.Invoke((Action)(() =>  
             {
                   UsersList.Items.Add(user.Nickname);
             }));  
         }  
  
       

        private void SendBt_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextMessage.Text))
                return;
            _serverconnection.SendMessage(TextMessage.Text);

            TextMessage.Clear();

        }
    }
}
