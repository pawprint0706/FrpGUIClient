namespace FrpGUIClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.TextBox textBoxDeviceName;
        private System.Windows.Forms.Label labelServerAddr;
        private System.Windows.Forms.TextBox textBoxServerAddr;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Label labelAuthToken;
        private System.Windows.Forms.TextBox textBoxAuthToken;
        private System.Windows.Forms.Label labelLocalPort;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.Label labelRemotePort;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.textBoxDeviceName = new System.Windows.Forms.TextBox();
            this.labelServerAddr = new System.Windows.Forms.Label();
            this.textBoxServerAddr = new System.Windows.Forms.TextBox();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.labelAuthToken = new System.Windows.Forms.Label();
            this.textBoxAuthToken = new System.Windows.Forms.TextBox();
            this.labelLocalPort = new System.Windows.Forms.Label();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.labelRemotePort = new System.Windows.Forms.Label();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Location = new System.Drawing.Point(12, 15);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(131, 12);
            this.labelDeviceName.TabIndex = 0;
            this.labelDeviceName.Text = "장치명(Device Name):";
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Location = new System.Drawing.Point(184, 12);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(310, 21);
            this.textBoxDeviceName.TabIndex = 1;
            // 
            // labelServerAddr
            // 
            this.labelServerAddr.AutoSize = true;
            this.labelServerAddr.Location = new System.Drawing.Point(12, 42);
            this.labelServerAddr.Name = "labelServerAddr";
            this.labelServerAddr.Size = new System.Drawing.Size(158, 12);
            this.labelServerAddr.TabIndex = 2;
            this.labelServerAddr.Text = "서버 주소(Server Address):";
            // 
            // textBoxServerAddr
            // 
            this.textBoxServerAddr.Location = new System.Drawing.Point(184, 39);
            this.textBoxServerAddr.Name = "textBoxServerAddr";
            this.textBoxServerAddr.Size = new System.Drawing.Size(310, 21);
            this.textBoxServerAddr.TabIndex = 3;
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(12, 69);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(133, 12);
            this.labelServerPort.TabIndex = 4;
            this.labelServerPort.Text = "서버 포트(Server Port):";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(184, 66);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(310, 21);
            this.textBoxServerPort.TabIndex = 5;
            // 
            // labelAuthToken
            // 
            this.labelAuthToken.AutoSize = true;
            this.labelAuthToken.Location = new System.Drawing.Point(12, 96);
            this.labelAuthToken.Name = "labelAuthToken";
            this.labelAuthToken.Size = new System.Drawing.Size(135, 12);
            this.labelAuthToken.TabIndex = 6;
            this.labelAuthToken.Text = "인증 토큰(Auth Token):";
            // 
            // textBoxAuthToken
            // 
            this.textBoxAuthToken.Location = new System.Drawing.Point(184, 93);
            this.textBoxAuthToken.Name = "textBoxAuthToken";
            this.textBoxAuthToken.PasswordChar = '*';
            this.textBoxAuthToken.Size = new System.Drawing.Size(310, 21);
            this.textBoxAuthToken.TabIndex = 7;
            // 
            // labelLocalPort
            // 
            this.labelLocalPort.AutoSize = true;
            this.labelLocalPort.Location = new System.Drawing.Point(12, 123);
            this.labelLocalPort.Name = "labelLocalPort";
            this.labelLocalPort.Size = new System.Drawing.Size(128, 12);
            this.labelLocalPort.TabIndex = 8;
            this.labelLocalPort.Text = "로컬 포트(Local Port):";
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(184, 120);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(310, 21);
            this.textBoxLocalPort.TabIndex = 9;
            // 
            // labelRemotePort
            // 
            this.labelRemotePort.AutoSize = true;
            this.labelRemotePort.Location = new System.Drawing.Point(12, 150);
            this.labelRemotePort.Name = "labelRemotePort";
            this.labelRemotePort.Size = new System.Drawing.Size(140, 12);
            this.labelRemotePort.TabIndex = 10;
            this.labelRemotePort.Text = "원격 포트(Remote Port):";
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Location = new System.Drawing.Point(184, 147);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.Size = new System.Drawing.Size(310, 21);
            this.textBoxRemotePort.TabIndex = 11;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(150, 190);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(88, 25);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "시작(Start)";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(266, 190);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(88, 25);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "중지(Stop)";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(14, 230);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(480, 208);
            this.richTextBoxOutput.TabIndex = 14;
            this.richTextBoxOutput.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(508, 450);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxRemotePort);
            this.Controls.Add(this.labelRemotePort);
            this.Controls.Add(this.textBoxLocalPort);
            this.Controls.Add(this.labelLocalPort);
            this.Controls.Add(this.textBoxAuthToken);
            this.Controls.Add(this.labelAuthToken);
            this.Controls.Add(this.textBoxServerPort);
            this.Controls.Add(this.labelServerPort);
            this.Controls.Add(this.textBoxServerAddr);
            this.Controls.Add(this.labelServerAddr);
            this.Controls.Add(this.textBoxDeviceName);
            this.Controls.Add(this.labelDeviceName);
            this.Name = "Form1";
            this.Text = "frp GUI Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
