namespace tcpclient
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.massegebox = new System.Windows.Forms.RichTextBox();
            this.sendmassage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.getmessage = new System.Windows.Forms.RichTextBox();
            this.serverip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverport = new System.Windows.Forms.TextBox();
            this.clientip = new System.Windows.Forms.TextBox();
            this.clientport = new System.Windows.Forms.TextBox();
            this.clientname = new System.Windows.Forms.TextBox();
            this.clientconnetn = new System.Windows.Forms.Button();
            this.serverconnent = new System.Windows.Forms.Button();
            this.Deneme_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // massegebox
            // 
            this.massegebox.Location = new System.Drawing.Point(15, 354);
            this.massegebox.Name = "massegebox";
            this.massegebox.Size = new System.Drawing.Size(292, 41);
            this.massegebox.TabIndex = 0;
            this.massegebox.Text = "";
            // 
            // sendmassage
            // 
            this.sendmassage.Location = new System.Drawing.Point(313, 354);
            this.sendmassage.Name = "sendmassage";
            this.sendmassage.Size = new System.Drawing.Size(119, 41);
            this.sendmassage.TabIndex = 1;
            this.sendmassage.Text = "gonder";
            this.sendmassage.UseVisualStyleBackColor = true;
            this.sendmassage.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "server ayrları";
            this.label1.Visible = false;
            // 
            // getmessage
            // 
            this.getmessage.Location = new System.Drawing.Point(15, 143);
            this.getmessage.Name = "getmessage";
            this.getmessage.ReadOnly = true;
            this.getmessage.Size = new System.Drawing.Size(417, 182);
            this.getmessage.TabIndex = 3;
            this.getmessage.Text = "";
            // 
            // serverip
            // 
            this.serverip.Location = new System.Drawing.Point(15, 29);
            this.serverip.Name = "serverip";
            this.serverip.Size = new System.Drawing.Size(100, 22);
            this.serverip.TabIndex = 4;
            this.serverip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "client ayarlari";
            this.label2.Visible = false;
            // 
            // serverport
            // 
            this.serverport.Location = new System.Drawing.Point(121, 29);
            this.serverport.Name = "serverport";
            this.serverport.Size = new System.Drawing.Size(100, 22);
            this.serverport.TabIndex = 7;
            this.serverport.Text = "9999";
            // 
            // clientip
            // 
            this.clientip.Location = new System.Drawing.Point(121, 100);
            this.clientip.Name = "clientip";
            this.clientip.Size = new System.Drawing.Size(100, 22);
            this.clientip.TabIndex = 8;
            this.clientip.Text = "127.0.0.1";
            // 
            // clientport
            // 
            this.clientport.Location = new System.Drawing.Point(227, 100);
            this.clientport.Name = "clientport";
            this.clientport.Size = new System.Drawing.Size(100, 22);
            this.clientport.TabIndex = 9;
            this.clientport.Tag = "";
            this.clientport.Text = "9999";
            // 
            // clientname
            // 
            this.clientname.Location = new System.Drawing.Point(15, 100);
            this.clientname.Name = "clientname";
            this.clientname.Size = new System.Drawing.Size(100, 22);
            this.clientname.TabIndex = 10;
            this.clientname.Text = "adiniz?";
            // 
            // clientconnetn
            // 
            this.clientconnetn.Location = new System.Drawing.Point(333, 92);
            this.clientconnetn.Name = "clientconnetn";
            this.clientconnetn.Size = new System.Drawing.Size(99, 39);
            this.clientconnetn.TabIndex = 11;
            this.clientconnetn.Text = "baglan";
            this.clientconnetn.UseVisualStyleBackColor = true;
            this.clientconnetn.Click += new System.EventHandler(this.clientconnent);
            // 
            // serverconnent
            // 
            this.serverconnent.Location = new System.Drawing.Point(227, 21);
            this.serverconnent.Name = "serverconnent";
            this.serverconnent.Size = new System.Drawing.Size(80, 39);
            this.serverconnent.TabIndex = 12;
            this.serverconnent.Text = "bağlan";
            this.serverconnent.UseVisualStyleBackColor = true;
            this.serverconnent.Click += new System.EventHandler(this.connentServer);
            // 
            // Deneme_file
            // 
            this.Deneme_file.Location = new System.Drawing.Point(318, 21);
            this.Deneme_file.Name = "Deneme_file";
            this.Deneme_file.Size = new System.Drawing.Size(109, 39);
            this.Deneme_file.TabIndex = 13;
            this.Deneme_file.Text = "denemefile";
            this.Deneme_file.UseVisualStyleBackColor = true;
            this.Deneme_file.Click += new System.EventHandler(this.denemfile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 420);
            this.Controls.Add(this.Deneme_file);
            this.Controls.Add(this.serverconnent);
            this.Controls.Add(this.clientconnetn);
            this.Controls.Add(this.clientname);
            this.Controls.Add(this.clientport);
            this.Controls.Add(this.clientip);
            this.Controls.Add(this.serverport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverip);
            this.Controls.Add(this.getmessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendmassage);
            this.Controls.Add(this.massegebox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox massegebox;
        private System.Windows.Forms.Button sendmassage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox getmessage;
        private System.Windows.Forms.TextBox serverip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverport;
        private System.Windows.Forms.TextBox clientip;
        private System.Windows.Forms.TextBox clientport;
        private System.Windows.Forms.TextBox clientname;
        private System.Windows.Forms.Button clientconnetn;
        private System.Windows.Forms.Button serverconnent;
        private System.Windows.Forms.Button Deneme_file;
    }
}

