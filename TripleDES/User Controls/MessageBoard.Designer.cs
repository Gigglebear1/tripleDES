namespace TripleDES.User_Controls
{
    partial class MessageBoard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttnLogOut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnSend = new System.Windows.Forms.Button();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bttnDelete = new System.Windows.Forms.Button();
            this.tbViewBody = new System.Windows.Forms.TextBox();
            this.bttnView = new System.Windows.Forms.Button();
            this.lbInbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSharedKeySend = new System.Windows.Forms.TextBox();
            this.tbSharedKeyReceive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbWarning = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnLogOut
            // 
            this.bttnLogOut.Location = new System.Drawing.Point(290, 10);
            this.bttnLogOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnLogOut.Name = "bttnLogOut";
            this.bttnLogOut.Size = new System.Drawing.Size(61, 29);
            this.bttnLogOut.TabIndex = 3;
            this.bttnLogOut.Text = "LogOut";
            this.bttnLogOut.UseVisualStyleBackColor = true;
            this.bttnLogOut.Click += new System.EventHandler(this.bttnLogOut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSharedKeySend);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bttnSend);
            this.groupBox1.Controls.Add(this.tbBody);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbSubject);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTo);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(331, 426);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send";
            // 
            // bttnSend
            // 
            this.bttnSend.Location = new System.Drawing.Point(12, 312);
            this.bttnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnSend.Name = "bttnSend";
            this.bttnSend.Size = new System.Drawing.Size(56, 21);
            this.bttnSend.TabIndex = 5;
            this.bttnSend.Text = "Send";
            this.bttnSend.UseVisualStyleBackColor = true;
            this.bttnSend.Click += new System.EventHandler(this.bttnSend_Click);
            // 
            // tbBody
            // 
            this.tbBody.Location = new System.Drawing.Point(12, 131);
            this.tbBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.Size = new System.Drawing.Size(255, 177);
            this.tbBody.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subject:";
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(89, 53);
            this.tbSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(135, 20);
            this.tbSubject.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To:";
            // 
            // cbTo
            // 
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(89, 23);
            this.cbTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(135, 21);
            this.cbTo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbWarning);
            this.groupBox2.Controls.Add(this.bttnLogOut);
            this.groupBox2.Controls.Add(this.tbSharedKeyReceive);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.bttnDelete);
            this.groupBox2.Controls.Add(this.tbViewBody);
            this.groupBox2.Controls.Add(this.bttnView);
            this.groupBox2.Controls.Add(this.lbInbox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(337, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(355, 426);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receive";
            // 
            // bttnDelete
            // 
            this.bttnDelete.Location = new System.Drawing.Point(45, 363);
            this.bttnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnDelete.Name = "bttnDelete";
            this.bttnDelete.Size = new System.Drawing.Size(92, 19);
            this.bttnDelete.TabIndex = 10;
            this.bttnDelete.Text = "Delete Message";
            this.bttnDelete.UseVisualStyleBackColor = true;
            this.bttnDelete.Click += new System.EventHandler(this.bttnDelete_Click);
            // 
            // tbViewBody
            // 
            this.tbViewBody.Location = new System.Drawing.Point(22, 192);
            this.tbViewBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbViewBody.Multiline = true;
            this.tbViewBody.Name = "tbViewBody";
            this.tbViewBody.ReadOnly = true;
            this.tbViewBody.Size = new System.Drawing.Size(294, 165);
            this.tbViewBody.TabIndex = 9;
            // 
            // bttnView
            // 
            this.bttnView.Location = new System.Drawing.Point(222, 131);
            this.bttnView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bttnView.Name = "bttnView";
            this.bttnView.Size = new System.Drawing.Size(64, 20);
            this.bttnView.TabIndex = 8;
            this.bttnView.Text = "View";
            this.bttnView.UseVisualStyleBackColor = true;
            this.bttnView.Click += new System.EventHandler(this.bttnView_Click);
            // 
            // lbInbox
            // 
            this.lbInbox.FormattingEnabled = true;
            this.lbInbox.Location = new System.Drawing.Point(22, 33);
            this.lbInbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbInbox.Name = "lbInbox";
            this.lbInbox.Size = new System.Drawing.Size(264, 69);
            this.lbInbox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inbox";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Shared Key";
            // 
            // tbSharedKeySend
            // 
            this.tbSharedKeySend.Location = new System.Drawing.Point(89, 82);
            this.tbSharedKeySend.Name = "tbSharedKeySend";
            this.tbSharedKeySend.Size = new System.Drawing.Size(135, 20);
            this.tbSharedKeySend.TabIndex = 7;
            // 
            // tbSharedKeyReceive
            // 
            this.tbSharedKeyReceive.Location = new System.Drawing.Point(36, 131);
            this.tbSharedKeyReceive.Name = "tbSharedKeyReceive";
            this.tbSharedKeyReceive.Size = new System.Drawing.Size(135, 20);
            this.tbSharedKeyReceive.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Shared Key";
            // 
            // lbWarning
            // 
            this.lbWarning.AutoSize = true;
            this.lbWarning.Location = new System.Drawing.Point(19, 177);
            this.lbWarning.Name = "lbWarning";
            this.lbWarning.Size = new System.Drawing.Size(69, 13);
            this.lbWarning.TabIndex = 11;
            this.lbWarning.Text = "label warning";
            // 
            // MessageBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MessageBoard";
            this.Size = new System.Drawing.Size(692, 430);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnLogOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttnSend;
        private System.Windows.Forms.TextBox tbBody;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Button bttnDelete;
        private System.Windows.Forms.TextBox tbViewBody;
        private System.Windows.Forms.Button bttnView;
        private System.Windows.Forms.ListBox lbInbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSharedKeySend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSharedKeyReceive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbWarning;
    }
}
