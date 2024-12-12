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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.창보이기ShowWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Location = new System.Drawing.Point(12, 10);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(131, 12);
            this.labelDeviceName.TabIndex = 0;
            this.labelDeviceName.Text = "장치명(Device Name):";
            // 
            // textBoxDeviceName
            // 
            this.textBoxDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeviceName.Location = new System.Drawing.Point(182, 7);
            this.textBoxDeviceName.Name = "textBoxDeviceName";
            this.textBoxDeviceName.Size = new System.Drawing.Size(310, 21);
            this.textBoxDeviceName.TabIndex = 1;
            // 
            // labelServerAddr
            // 
            this.labelServerAddr.AutoSize = true;
            this.labelServerAddr.Location = new System.Drawing.Point(12, 37);
            this.labelServerAddr.Name = "labelServerAddr";
            this.labelServerAddr.Size = new System.Drawing.Size(158, 12);
            this.labelServerAddr.TabIndex = 2;
            this.labelServerAddr.Text = "서버 주소(Server Address):";
            // 
            // textBoxServerAddr
            // 
            this.textBoxServerAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerAddr.Location = new System.Drawing.Point(182, 34);
            this.textBoxServerAddr.Name = "textBoxServerAddr";
            this.textBoxServerAddr.Size = new System.Drawing.Size(310, 21);
            this.textBoxServerAddr.TabIndex = 3;
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(12, 64);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(133, 12);
            this.labelServerPort.TabIndex = 4;
            this.labelServerPort.Text = "서버 포트(Server Port):";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerPort.Location = new System.Drawing.Point(182, 61);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(310, 21);
            this.textBoxServerPort.TabIndex = 5;
            // 
            // labelAuthToken
            // 
            this.labelAuthToken.AutoSize = true;
            this.labelAuthToken.Location = new System.Drawing.Point(12, 91);
            this.labelAuthToken.Name = "labelAuthToken";
            this.labelAuthToken.Size = new System.Drawing.Size(135, 12);
            this.labelAuthToken.TabIndex = 6;
            this.labelAuthToken.Text = "인증 토큰(Auth Token):";
            // 
            // textBoxAuthToken
            // 
            this.textBoxAuthToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAuthToken.Location = new System.Drawing.Point(182, 88);
            this.textBoxAuthToken.Name = "textBoxAuthToken";
            this.textBoxAuthToken.PasswordChar = '*';
            this.textBoxAuthToken.Size = new System.Drawing.Size(310, 21);
            this.textBoxAuthToken.TabIndex = 7;
            // 
            // labelLocalPort
            // 
            this.labelLocalPort.AutoSize = true;
            this.labelLocalPort.Location = new System.Drawing.Point(12, 118);
            this.labelLocalPort.Name = "labelLocalPort";
            this.labelLocalPort.Size = new System.Drawing.Size(128, 12);
            this.labelLocalPort.TabIndex = 8;
            this.labelLocalPort.Text = "로컬 포트(Local Port):";
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocalPort.Location = new System.Drawing.Point(182, 115);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(310, 21);
            this.textBoxLocalPort.TabIndex = 9;
            // 
            // labelRemotePort
            // 
            this.labelRemotePort.AutoSize = true;
            this.labelRemotePort.Location = new System.Drawing.Point(12, 145);
            this.labelRemotePort.Name = "labelRemotePort";
            this.labelRemotePort.Size = new System.Drawing.Size(140, 12);
            this.labelRemotePort.TabIndex = 10;
            this.labelRemotePort.Text = "원격 포트(Remote Port):";
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRemotePort.Location = new System.Drawing.Point(182, 142);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.Size = new System.Drawing.Size(310, 21);
            this.textBoxRemotePort.TabIndex = 11;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(310, 406);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(88, 25);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "시작(Start)";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(404, 406);
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
            this.richTextBoxOutput.Location = new System.Drawing.Point(5, 169);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(487, 231);
            this.richTextBoxOutput.TabIndex = 14;
            this.richTextBoxOutput.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.창보이기ShowWindowToolStripMenuItem,
            this.종료ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(213, 48);
            // 
            // 창보이기ShowWindowToolStripMenuItem
            // 
            this.창보이기ShowWindowToolStripMenuItem.Name = "창보이기ShowWindowToolStripMenuItem";
            this.창보이기ShowWindowToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.창보이기ShowWindowToolStripMenuItem.Text = "창 보이기(Show Window)";
            this.창보이기ShowWindowToolStripMenuItem.Click += new System.EventHandler(this.창보이기ShowWindowToolStripMenuItem_Click);
            // 
            // 종료ExitToolStripMenuItem
            // 
            this.종료ExitToolStripMenuItem.Name = "종료ExitToolStripMenuItem";
            this.종료ExitToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.종료ExitToolStripMenuItem.Text = "종료 (Exit)";
            this.종료ExitToolStripMenuItem.Click += new System.EventHandler(this.종료ExitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "frp GUI Client";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(5, 409);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(260, 16);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "프로그램 시작 시 자동으로 연결(Auto Start)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(497, 437);
            this.Controls.Add(this.checkBox1);
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
            this.Controls.Add(this.richTextBoxOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "frp GUI Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 창보이기ShowWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ExitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
