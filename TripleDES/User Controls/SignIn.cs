using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parse;

namespace TripleDES.User_Controls
{
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Globals.panel.Controls.Clear();
            Globals.panel.Controls.Add(new User_Controls.SignUp());
        }

        private async void bttnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                await ParseUser.LogInAsync(tbUserName.Text.ToString().Trim(), tbPassword.Text.ToString().Trim());
                // Login was successful.
                Globals.currentUser = ParseUser.CurrentUser;

                Globals.panel.Controls.Clear();
                Globals.panel.Controls.Add(new User_Controls.MessageBoard());

            }
            catch (Exception eception)
            {
                // The login failed. Check the error to see why.
                MessageBox.Show(eception.Message.ToString());
            }
        }
    }
}
