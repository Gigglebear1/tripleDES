using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Parse;


namespace TripleDES.User_Controls
{
    public partial class MessageBoard : UserControl
    {
        IEnumerable<ParseObject> userInbox;
        Timer t;
        public MessageBoard()
        {
            InitializeComponent();
            fillToBox();
            fillInbox();
            lbWarning.Text = "";

            //makes a call to fillInbox every x seconds
            t = new Timer { Enabled = true, Interval = 15 * 1000 }; // numSec *1000
            t.Tick += delegate
            {
                fillInbox();
            };

        }

        private void bttnLogOut_Click(object sender, EventArgs e)
        {
            ParseUser.LogOut();
            Globals.currentUser = ParseUser.CurrentUser;

            //disable the time that calls fillInbox
            t.Enabled = false;


            //set the panel back to log in
            Globals.panel.Controls.Clear();
            Globals.panel.Controls.Add(new User_Controls.SignIn());
        }

        /// <summary>
        /// qureies all users and fills the TO combo box
        /// </summary>
        public async void fillToBox()
        {
            //query all users
            var allUsers = await (from User in ParseUser.Query
                                  orderby User.Get<string>("username") descending
                                  select User).FindAsync();

            //clear the cb and fill it with users minus the current user
            cbTo.Items.Clear();
            cbTo.Items.Add("Select User Name");
            foreach (ParseUser user in allUsers)
            {
                if (user.Username != Globals.currentUser.Username)
                {
                    cbTo.Items.Add(user.Username);
                }
            }

            //make it select the "Select User Name"
            cbTo.SelectedIndex = 0;
        }

        /// <summary>
        /// empty and then fill the inbox
        /// </summary>
        public async void fillInbox()
        {
            try
            {
                var usermessages = await (from message in ParseObject.GetQuery("Messages")
                                          where message.Get<string>("ToID").Equals(Globals.currentUser.Username.ToString().Trim())
                                          select message).FindAsync();

                userInbox = usermessages;

                //get the curently selected index to reset later 
                int currentIndex = lbInbox.SelectedIndex;

                //clear the lb and fill it with user messages
                lbInbox.Items.Clear();

                foreach (ParseObject message in usermessages)
                {
                    // TODO: when encrypted need to decryipt here 
                    lbInbox.Items.Add("From:" + message.Get<string>("FromID") + "  Subject: " + message.Get<string>("Subject"));
                }

                //reset the current index
                lbInbox.SelectedIndex = currentIndex;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString().Trim());
            }


        }

        /// <summary>
        /// send the message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void bttnSend_Click(object sender, EventArgs e)
        {
            try
            {
                //gather all the information to compose the message
                string subject = tbSubject.Text.ToString().Trim();
                string body = tbBody.Text.ToString().Trim();
                string to = cbTo.SelectedItem.ToString().Trim();
                string from = Globals.currentUser.Username.ToString().Trim();
                string key = tbSharedKeySend.Text.ToString().Trim();

                if (subject == "" || body == "" || to == "Select User Name")
                {
                    MessageBox.Show("Please enter all data");
                }
                else
                {
                    //send message to pasre
                    ParseObject message = new ParseObject("Messages");
                    message["FromID"] = from;
                    message["ToID"] = to;
                    message["Message"] = Support.TripleDesAlgo.tdesEncrypt(body, Globals.k1, Globals.k2);
                    message["Subject"] = subject;
                    message["SHA1"] = SHA1.SHA1.hashString(subject + body + tbSharedKeySend.Text);
                    
                    // If a file is included
                    if (tbFilePath.Text != "")
                    {
                        string filepath = tbFilePath.Text.ToString().Trim();
                        string filename = filepath.Substring(filepath.LastIndexOf("\\"));
                        FileStream file = File.Open(filepath, FileMode.Open);
                        FileStream encfile = File.Open(".encfile." + filepath.Substring(filepath.LastIndexOf(".")), FileMode.Create);
                        StreamWriter writer = new StreamWriter(encfile);

                        // 3DES encrypt the file, and also calculate a checksum at the same time. Do it with the subject and key for integrity
                        BigInteger sum = 0;
                        byte[] array = new byte[4096];
                        while (file.Read(array, 0, array.Length) != 0)
                        {
                            string result = System.Text.Encoding.Default.GetString(array);
                            string sha = SHA1.SHA1.hashString(subject + result + tbSharedKeySend.Text);
                            string tdes = Support.TripleDesAlgo.tdesEncrypt(result, Globals.k1, Globals.k2);
                            sum += BigInteger.Parse(sha, System.Globalization.NumberStyles.AllowHexSpecifier);
                            writer.Write(tdes);
                        }

                        // Reset the stream back to the start of the encrypted file
                        encfile.Seek(0, SeekOrigin.Begin);

                        // Send the encrypted file with the filename
                        message["File"] = new ParseFile(filename, encfile);

                        // Get the last 40 hex characters of the checksum
                        // Whole checksum will be modified by any file changes so we still have collision resistance
                        message["Checksum"] = sum.ToString("40X");

                        // Close both the files
                        file.Close();
                        encfile.Close();
                    }
                    await message.SaveAsync();

                    MessageBox.Show("Message sent sucessful");

                    //clear the message box and all other thing
                    cbTo.SelectedIndex = 0;
                    tbBody.Clear();
                    tbSubject.Clear();
                    tbSharedKeySend.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString().Trim());
            }
        }

        /// <summary>
        /// view the selected item in lbInbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnView_Click(object sender, EventArgs e)
        {

            try
            {
                //clear warning label
                lbWarning.Text = "";

                //index from the lb
                int seletedMessage = lbInbox.SelectedIndex;

                //for waring at top of message if needed
                string warning = "!!!!!WARNING! message might have been tampered with!!!!!";

                //convert the userInbox to list then grab the index of the lb 
                ParseObject message = userInbox.ToList()[seletedMessage];

                string body = Support.TripleDesAlgo.tdesDecrypt(message.Get<string>("Message"), Globals.k1, Globals.k2); 

                //recompute the SHA
                string computedSHA = SHA1.SHA1.hashString(message.Get<string>("Subject") + body + tbSharedKeyReceive.Text);

                if (computedSHA != message.Get<string>("SHA1"))
                {
                    MessageBox.Show("WARNING!!!!\nThis message has been tampered with or you entered an incorrect Shared Key");
                    lbWarning.Text = warning;
                }

                tbViewBody.Text = body;
            }
            catch (Exception excpetion)
            {
                //there was an exception 
            }
        }

        private async void bttnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbInbox.SelectedIndex != -1)
                {
                    //get the object to delete
                    int messageIndex = lbInbox.SelectedIndex;
                    ParseObject messageToDelete = userInbox.ToList()[messageIndex];

                    //delete object
                    await messageToDelete.DeleteAsync();

                    //TODO: error wen delete but it deletes something to do with viewing it and trying to delete it   

                    //update fill box
                    fillInbox();
                }
                else
                {
                    MessageBox.Show("Please Select A Message To Delete");
                }
            }
            catch (Exception exception)
            {

            }


        }

        private void bttnAttachFile_Click(object sender, EventArgs e)
        {
            try
            {
                var FD = new System.Windows.Forms.OpenFileDialog();
                FD.Filter = "Text Files (.txt)|*.txt";
                if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tbFilePath.Text = FD.FileName;
                }
            }
            catch(Exception exception){

            }

        }
    }
}
