using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parse;
using TripleDES.User_Controls;

namespace TripleDES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Globals.panel = MainPanel;
            Globals.panel.Controls.Add(new SignIn());
            ParseClient.Initialize("8G4nIOIZxeHWrFoioNNz0fOuKGOS5SBWyta9bFjJ", "w694Al2aaHgm51qkbCAeQdlnFwJLt6UxGJcaLnya");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
