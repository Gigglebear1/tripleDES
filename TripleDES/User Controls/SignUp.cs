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
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void bttnBack_Click(object sender, EventArgs e)
        {
            Globals.panel.Controls.Clear();
            Globals.panel.Controls.Add(new User_Controls.SignIn());
        }

        private async void bttnSignUp_Click(object sender, EventArgs e)
        {
          
             
            if (tbPassword.Text.ToString().Equals(tbPasswordRepeat.Text.ToString())){

                try { 
                var user = new ParseUser()
                {
                    Username = tbUserName.Text.ToString().Trim(),
                    Password = tbPassword.Text.ToString().Trim(),
                    Email = tbEmail.Text.ToString()
                };

                // other fields can be set just like with ParseObject
                await user.SignUpAsync();

                MessageBox.Show("Sucess: User Has Been Created");
                
                    Globals.panel.Controls.Clear();
                Globals.panel.Controls.Add(new User_Controls.SignIn());


                }
                catch(Exception exception){
                    MessageBox.Show(exception.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Your Passwords Do Not Match");
            }
        }
    }
}
