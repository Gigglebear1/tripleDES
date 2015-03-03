using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
