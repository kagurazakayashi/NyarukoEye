namespace NyarukoEye_Windows
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrivatePEM = new System.Windows.Forms.TabPage();
            this.txtPrivatePEM = new System.Windows.Forms.TextBox();
            this.tabPublicPEM = new System.Windows.Forms.TabPage();
            this.txtPublicPEM = new System.Windows.Forms.TextBox();
            this.tabAES = new System.Windows.Forms.TabPage();
            this.txtAES = new System.Windows.Forms.TextBox();
            this.tabText = new System.Windows.Forms.TabPage();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSecMode = new System.Windows.Forms.ComboBox();
            this.radioKeyMode2 = new System.Windows.Forms.RadioButton();
            this.radioKeyMode1 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAESKeyLength = new System.Windows.Forms.ComboBox();
            this.btnNewAES = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDecFile = new System.Windows.Forms.Button();
            this.btnEncFile = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnTo = new System.Windows.Forms.Button();
            this.btnFrom = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBase64 = new System.Windows.Forms.CheckBox();
            this.btnDecTxt = new System.Windows.Forms.Button();
            this.btnEncTxt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInpAes = new System.Windows.Forms.Button();
            this.btnInpPri = new System.Windows.Forms.Button();
            this.btnInpPub = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyLength = new System.Windows.Forms.ComboBox();
            this.btnNewPriKey = new System.Windows.Forms.Button();
            this.btnNewPubKey = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExpAes = new System.Windows.Forms.Button();
            this.btnExpPri = new System.Windows.Forms.Button();
            this.btnExpPub = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrivatePEM.SuspendLayout();
            this.tabPublicPEM.SuspendLayout();
            this.tabAES.SuspendLayout();
            this.tabText.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1243, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "准备就绪。";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrivatePEM);
            this.tabControl1.Controls.Add(this.tabPublicPEM);
            this.tabControl1.Controls.Add(this.tabAES);
            this.tabControl1.Controls.Add(this.tabText);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 508);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPrivatePEM
            // 
            this.tabPrivatePEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPrivatePEM.Controls.Add(this.txtPrivatePEM);
            this.tabPrivatePEM.Location = new System.Drawing.Point(4, 29);
            this.tabPrivatePEM.Name = "tabPrivatePEM";
            this.tabPrivatePEM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivatePEM.Size = new System.Drawing.Size(623, 475);
            this.tabPrivatePEM.TabIndex = 1;
            this.tabPrivatePEM.Text = "[!] 非对称私钥";
            // 
            // txtPrivatePEM
            // 
            this.txtPrivatePEM.BackColor = System.Drawing.Color.Black;
            this.txtPrivatePEM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivatePEM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrivatePEM.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPrivatePEM.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPrivatePEM.Location = new System.Drawing.Point(3, 3);
            this.txtPrivatePEM.Multiline = true;
            this.txtPrivatePEM.Name = "txtPrivatePEM";
            this.txtPrivatePEM.Size = new System.Drawing.Size(617, 469);
            this.txtPrivatePEM.TabIndex = 1;
            this.txtPrivatePEM.TextChanged += new System.EventHandler(this.txtPrivatePEM_TextChanged);
            // 
            // tabPublicPEM
            // 
            this.tabPublicPEM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPublicPEM.Controls.Add(this.txtPublicPEM);
            this.tabPublicPEM.Location = new System.Drawing.Point(4, 29);
            this.tabPublicPEM.Name = "tabPublicPEM";
            this.tabPublicPEM.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublicPEM.Size = new System.Drawing.Size(623, 475);
            this.tabPublicPEM.TabIndex = 2;
            this.tabPublicPEM.Text = "[!] 非对称公钥";
            // 
            // txtPublicPEM
            // 
            this.txtPublicPEM.BackColor = System.Drawing.Color.Black;
            this.txtPublicPEM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublicPEM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPublicPEM.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPublicPEM.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPublicPEM.Location = new System.Drawing.Point(3, 3);
            this.txtPublicPEM.Multiline = true;
            this.txtPublicPEM.Name = "txtPublicPEM";
            this.txtPublicPEM.Size = new System.Drawing.Size(617, 469);
            this.txtPublicPEM.TabIndex = 2;
            this.txtPublicPEM.TextChanged += new System.EventHandler(this.txtPublicPEM_TextChanged);
            // 
            // tabAES
            // 
            this.tabAES.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabAES.Controls.Add(this.txtAES);
            this.tabAES.Location = new System.Drawing.Point(4, 29);
            this.tabAES.Name = "tabAES";
            this.tabAES.Padding = new System.Windows.Forms.Padding(3);
            this.tabAES.Size = new System.Drawing.Size(623, 475);
            this.tabAES.TabIndex = 5;
            this.tabAES.Text = "[!] 对称密钥";
            // 
            // txtAES
            // 
            this.txtAES.BackColor = System.Drawing.Color.Black;
            this.txtAES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAES.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtAES.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtAES.Location = new System.Drawing.Point(3, 3);
            this.txtAES.Multiline = true;
            this.txtAES.Name = "txtAES";
            this.txtAES.Size = new System.Drawing.Size(617, 469);
            this.txtAES.TabIndex = 3;
            this.txtAES.TextChanged += new System.EventHandler(this.txtAES_TextChanged);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.txtText);
            this.tabText.Location = new System.Drawing.Point(4, 29);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(623, 475);
            this.tabText.TabIndex = 4;
            this.tabText.Text = "测试文本";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // txtText
            // 
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(3, 3);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(617, 469);
            this.txtText.TabIndex = 4;
            this.txtText.Text = "在此输入测试用文本";
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(1090, 505);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Location = new System.Drawing.Point(6, 71);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(129, 40);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "一键完成两步(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(649, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 422);
            this.panel1.TabIndex = 4;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.txtSecMode);
            this.groupBox7.Controls.Add(this.radioKeyMode2);
            this.groupBox7.Controls.Add(this.radioKeyMode1);
            this.groupBox7.Location = new System.Drawing.Point(292, 130);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(286, 89);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "加密解密测试模式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "对称密钥格式：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "使用密钥：";
            // 
            // txtSecMode
            // 
            this.txtSecMode.FormattingEnabled = true;
            this.txtSecMode.Items.AddRange(new object[] {
            "aes-128-cbc",
            "aes-128-cbc-hmac-sha1",
            "aes-128-cfb",
            "aes-128-cfb1",
            "aes-128-cfb8",
            "aes-128-ctr",
            "aes-128-ecb",
            "aes-128-gcm",
            "aes-128-ofb",
            "aes-128-xts",
            "aes-192-cbc",
            "aes-192-cfb",
            "aes-192-cfb1",
            "aes-192-cfb8",
            "aes-192-ctr",
            "aes-192-ecb",
            "aes-192-gcm",
            "aes-192-ofb",
            "aes-256-cbc",
            "aes-256-cbc-hmac-sha1",
            "aes-256-cfb",
            "aes-256-cfb1",
            "aes-256-cfb8",
            "aes-256-ctr",
            "aes-256-ecb",
            "aes-256-gcm",
            "aes-256-ofb",
            "aes-256-xts",
            "aes128",
            "aes192",
            "aes256",
            "bf",
            "bf-cbc",
            "bf-cfb",
            "bf-ecb",
            "bf-ofb",
            "blowfish",
            "camellia-128-cbc",
            "camellia-128-cfb",
            "camellia-128-cfb1",
            "camellia-128-cfb8",
            "camellia-128-ecb",
            "camellia-128-ofb",
            "camellia-192-cbc",
            "camellia-192-cfb",
            "camellia-192-cfb1",
            "camellia-192-cfb8",
            "camellia-192-ecb",
            "camellia-192-ofb",
            "camellia-256-cbc",
            "camellia-256-cfb",
            "camellia-256-cfb1",
            "camellia-256-cfb8",
            "camellia-256-ecb",
            "camellia-256-ofb",
            "camellia128",
            "camellia192",
            "camellia256",
            "cast",
            "cast-cbc",
            "cast5-cbc",
            "cast5-cfb",
            "cast5-ecb",
            "cast5-ofb",
            "des",
            "des-cbc",
            "des-cfb",
            "des-cfb1",
            "des-cfb8",
            "des-ecb",
            "des-ede",
            "des-ede-cbc",
            "des-ede-cfb",
            "des-ede-ofb",
            "des-ede3",
            "des-ede3-cbc",
            "des-ede3-cfb",
            "des-ede3-cfb1",
            "des-ede3-cfb8",
            "des-ede3-ofb",
            "des-ofb",
            "des3",
            "desx",
            "desx-cbc",
            "id-aes128-GCM",
            "id-aes192-GCM",
            "id-aes256-GCM",
            "rc2",
            "rc2-40-cbc",
            "rc2-64-cbc",
            "rc2-cbc",
            "rc2-cfb",
            "rc2-ecb",
            "rc2-ofb",
            "rc4",
            "rc4-40",
            "rc4-hmac-md5",
            "seed",
            "seed-cbc",
            "seed-cfb",
            "seed-ecb",
            "seed-ofb"});
            this.txtSecMode.Location = new System.Drawing.Point(126, 53);
            this.txtSecMode.Name = "txtSecMode";
            this.txtSecMode.Size = new System.Drawing.Size(154, 28);
            this.txtSecMode.TabIndex = 11;
            this.txtSecMode.Text = "aes-256-cbc";
            // 
            // radioKeyMode2
            // 
            this.radioKeyMode2.AutoSize = true;
            this.radioKeyMode2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioKeyMode2.Location = new System.Drawing.Point(206, 23);
            this.radioKeyMode2.Name = "radioKeyMode2";
            this.radioKeyMode2.Size = new System.Drawing.Size(69, 24);
            this.radioKeyMode2.TabIndex = 12;
            this.radioKeyMode2.Text = "非对称";
            this.radioKeyMode2.UseVisualStyleBackColor = true;
            // 
            // radioKeyMode1
            // 
            this.radioKeyMode1.AutoSize = true;
            this.radioKeyMode1.Checked = true;
            this.radioKeyMode1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioKeyMode1.Location = new System.Drawing.Point(126, 23);
            this.radioKeyMode1.Name = "radioKeyMode1";
            this.radioKeyMode1.Size = new System.Drawing.Size(55, 24);
            this.radioKeyMode1.TabIndex = 11;
            this.radioKeyMode1.TabStop = true;
            this.radioKeyMode1.Text = "对称";
            this.radioKeyMode1.UseVisualStyleBackColor = true;
            this.radioKeyMode1.CheckedChanged += new System.EventHandler(this.radioKeyMode1_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtAESKeyLength);
            this.groupBox6.Controls.Add(this.btnNewAES);
            this.groupBox6.Location = new System.Drawing.Point(292, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(287, 81);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "建立对称密钥";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "位数：";
            // 
            // txtAESKeyLength
            // 
            this.txtAESKeyLength.FormattingEnabled = true;
            this.txtAESKeyLength.Items.AddRange(new object[] {
            "16",
            "32",
            "64"});
            this.txtAESKeyLength.Location = new System.Drawing.Point(211, 37);
            this.txtAESKeyLength.Name = "txtAESKeyLength";
            this.txtAESKeyLength.Size = new System.Drawing.Size(69, 28);
            this.txtAESKeyLength.TabIndex = 9;
            this.txtAESKeyLength.Text = "64";
            // 
            // btnNewAES
            // 
            this.btnNewAES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewAES.Location = new System.Drawing.Point(12, 30);
            this.btnNewAES.Name = "btnNewAES";
            this.btnNewAES.Size = new System.Drawing.Size(129, 40);
            this.btnNewAES.TabIndex = 7;
            this.btnNewAES.Text = "生成新对称密钥";
            this.btnNewAES.UseVisualStyleBackColor = true;
            this.btnNewAES.Click += new System.EventHandler(this.btnNewAES_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDecFile);
            this.groupBox5.Controls.Add(this.btnEncFile);
            this.groupBox5.Controls.Add(this.txtTo);
            this.groupBox5.Controls.Add(this.txtFrom);
            this.groupBox5.Controls.Add(this.btnTo);
            this.groupBox5.Controls.Add(this.btnFrom);
            this.groupBox5.Location = new System.Drawing.Point(0, 302);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(579, 120);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "测试文件";
            // 
            // btnDecFile
            // 
            this.btnDecFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecFile.Enabled = false;
            this.btnDecFile.Location = new System.Drawing.Point(481, 71);
            this.btnDecFile.Name = "btnDecFile";
            this.btnDecFile.Size = new System.Drawing.Size(92, 40);
            this.btnDecFile.TabIndex = 9;
            this.btnDecFile.Text = "解密";
            this.btnDecFile.UseVisualStyleBackColor = true;
            this.btnDecFile.Click += new System.EventHandler(this.btnDecFile_Click);
            // 
            // btnEncFile
            // 
            this.btnEncFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncFile.Enabled = false;
            this.btnEncFile.Location = new System.Drawing.Point(481, 25);
            this.btnEncFile.Name = "btnEncFile";
            this.btnEncFile.Size = new System.Drawing.Size(92, 40);
            this.btnEncFile.TabIndex = 10;
            this.btnEncFile.Text = "加密";
            this.btnEncFile.UseVisualStyleBackColor = true;
            this.btnEncFile.Click += new System.EventHandler(this.btnEncFile_Click);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(104, 78);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(371, 26);
            this.txtTo.TabIndex = 8;
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(104, 32);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(371, 26);
            this.txtFrom.TabIndex = 7;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            // 
            // btnTo
            // 
            this.btnTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTo.Location = new System.Drawing.Point(6, 71);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(92, 40);
            this.btnTo.TabIndex = 6;
            this.btnTo.Text = "目标文件";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnFrom
            // 
            this.btnFrom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrom.Location = new System.Drawing.Point(6, 25);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(92, 40);
            this.btnFrom.TabIndex = 5;
            this.btnFrom.Text = "源文件";
            this.btnFrom.UseVisualStyleBackColor = true;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBase64);
            this.groupBox3.Controls.Add(this.btnDecTxt);
            this.groupBox3.Controls.Add(this.btnEncTxt);
            this.groupBox3.Location = new System.Drawing.Point(292, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 71);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试文本";
            // 
            // checkBase64
            // 
            this.checkBase64.Checked = true;
            this.checkBase64.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBase64.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBase64.Location = new System.Drawing.Point(202, 32);
            this.checkBase64.Name = "checkBase64";
            this.checkBase64.Size = new System.Drawing.Size(78, 29);
            this.checkBase64.TabIndex = 5;
            this.checkBase64.Text = "Base64";
            this.checkBase64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBase64.UseVisualStyleBackColor = true;
            // 
            // btnDecTxt
            // 
            this.btnDecTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecTxt.Location = new System.Drawing.Point(104, 25);
            this.btnDecTxt.Name = "btnDecTxt";
            this.btnDecTxt.Size = new System.Drawing.Size(92, 40);
            this.btnDecTxt.TabIndex = 4;
            this.btnDecTxt.Text = "解密";
            this.btnDecTxt.UseVisualStyleBackColor = true;
            this.btnDecTxt.Click += new System.EventHandler(this.btnDecTxt_Click);
            // 
            // btnEncTxt
            // 
            this.btnEncTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncTxt.Location = new System.Drawing.Point(6, 25);
            this.btnEncTxt.Name = "btnEncTxt";
            this.btnEncTxt.Size = new System.Drawing.Size(92, 40);
            this.btnEncTxt.TabIndex = 4;
            this.btnEncTxt.Text = "加密";
            this.btnEncTxt.UseVisualStyleBackColor = true;
            this.btnEncTxt.Click += new System.EventHandler(this.btnEncTxt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInpAes);
            this.groupBox1.Controls.Add(this.btnInpPri);
            this.groupBox1.Controls.Add(this.btnInpPub);
            this.groupBox1.Location = new System.Drawing.Point(0, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 166);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入";
            // 
            // btnInpAes
            // 
            this.btnInpAes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInpAes.Location = new System.Drawing.Point(6, 117);
            this.btnInpAes.Name = "btnInpAes";
            this.btnInpAes.Size = new System.Drawing.Size(129, 40);
            this.btnInpAes.TabIndex = 4;
            this.btnInpAes.Text = "导入对称密钥";
            this.btnInpAes.UseVisualStyleBackColor = true;
            this.btnInpAes.Click += new System.EventHandler(this.btnInpAes_Click);
            // 
            // btnInpPri
            // 
            this.btnInpPri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInpPri.Location = new System.Drawing.Point(6, 25);
            this.btnInpPri.Name = "btnInpPri";
            this.btnInpPri.Size = new System.Drawing.Size(129, 40);
            this.btnInpPri.TabIndex = 3;
            this.btnInpPri.Text = "导入非对称私钥";
            this.btnInpPri.UseVisualStyleBackColor = true;
            this.btnInpPri.Click += new System.EventHandler(this.btnInpPri_Click);
            // 
            // btnInpPub
            // 
            this.btnInpPub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInpPub.Location = new System.Drawing.Point(6, 71);
            this.btnInpPub.Name = "btnInpPub";
            this.btnInpPub.Size = new System.Drawing.Size(129, 40);
            this.btnInpPub.TabIndex = 3;
            this.btnInpPub.Text = "导入非对称公钥";
            this.btnInpPub.UseVisualStyleBackColor = true;
            this.btnInpPub.Click += new System.EventHandler(this.btnInpPub_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtKeyLength);
            this.groupBox4.Controls.Add(this.btnNewPriKey);
            this.groupBox4.Controls.Add(this.btnNewPubKey);
            this.groupBox4.Controls.Add(this.btnNew);
            this.groupBox4.Location = new System.Drawing.Point(0, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 121);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "建立非对称密钥";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "位数：";
            // 
            // txtKeyLength
            // 
            this.txtKeyLength.FormattingEnabled = true;
            this.txtKeyLength.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "4096"});
            this.txtKeyLength.Location = new System.Drawing.Point(211, 78);
            this.txtKeyLength.Name = "txtKeyLength";
            this.txtKeyLength.Size = new System.Drawing.Size(69, 28);
            this.txtKeyLength.TabIndex = 5;
            this.txtKeyLength.Text = "1024";
            // 
            // btnNewPriKey
            // 
            this.btnNewPriKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPriKey.Location = new System.Drawing.Point(6, 25);
            this.btnNewPriKey.Name = "btnNewPriKey";
            this.btnNewPriKey.Size = new System.Drawing.Size(129, 40);
            this.btnNewPriKey.TabIndex = 4;
            this.btnNewPriKey.Text = "生成新私钥";
            this.btnNewPriKey.UseVisualStyleBackColor = true;
            this.btnNewPriKey.Click += new System.EventHandler(this.btnNewPriKey_Click);
            // 
            // btnNewPubKey
            // 
            this.btnNewPubKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPubKey.Enabled = false;
            this.btnNewPubKey.Location = new System.Drawing.Point(151, 25);
            this.btnNewPubKey.Name = "btnNewPubKey";
            this.btnNewPubKey.Size = new System.Drawing.Size(129, 40);
            this.btnNewPubKey.TabIndex = 3;
            this.btnNewPubKey.Text = "从私钥提取公钥";
            this.btnNewPubKey.UseVisualStyleBackColor = true;
            this.btnNewPubKey.Click += new System.EventHandler(this.btnNewPubKey_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExpAes);
            this.groupBox2.Controls.Add(this.btnExpPri);
            this.groupBox2.Controls.Add(this.btnExpPub);
            this.groupBox2.Location = new System.Drawing.Point(145, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 166);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出";
            // 
            // btnExpAes
            // 
            this.btnExpAes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpAes.Enabled = false;
            this.btnExpAes.Location = new System.Drawing.Point(6, 117);
            this.btnExpAes.Name = "btnExpAes";
            this.btnExpAes.Size = new System.Drawing.Size(129, 40);
            this.btnExpAes.TabIndex = 5;
            this.btnExpAes.Text = "导出对称密钥";
            this.btnExpAes.UseVisualStyleBackColor = true;
            this.btnExpAes.Click += new System.EventHandler(this.btnExpAes_Click);
            // 
            // btnExpPri
            // 
            this.btnExpPri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpPri.Enabled = false;
            this.btnExpPri.Location = new System.Drawing.Point(6, 71);
            this.btnExpPri.Name = "btnExpPri";
            this.btnExpPri.Size = new System.Drawing.Size(129, 40);
            this.btnExpPri.TabIndex = 4;
            this.btnExpPri.Text = "导出非对称私钥";
            this.btnExpPri.UseVisualStyleBackColor = true;
            this.btnExpPri.Click += new System.EventHandler(this.btnExpPri_Click);
            // 
            // btnExpPub
            // 
            this.btnExpPub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpPub.Enabled = false;
            this.btnExpPub.Location = new System.Drawing.Point(6, 25);
            this.btnExpPub.Name = "btnExpPub";
            this.btnExpPub.Size = new System.Drawing.Size(129, 40);
            this.btnExpPub.TabIndex = 4;
            this.btnExpPub.Text = "导出非对称公钥";
            this.btnExpPub.UseVisualStyleBackColor = true;
            this.btnExpPub.Click += new System.EventHandler(this.btnExpPub_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "OpenSSL 执行文件：";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(1018, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NyarukoEye_Windows.Properties.Resources.f_f_object_34_s32_f_object_34_0nbg;
            this.pictureBox1.Location = new System.Drawing.Point(19, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 574);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "密钥工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPrivatePEM.ResumeLayout(false);
            this.tabPrivatePEM.PerformLayout();
            this.tabPublicPEM.ResumeLayout(false);
            this.tabPublicPEM.PerformLayout();
            this.tabAES.ResumeLayout(false);
            this.tabAES.PerformLayout();
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrivatePEM;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tabPublicPEM;
        private System.Windows.Forms.TextBox txtPublicPEM;
        private System.Windows.Forms.TextBox txtPrivatePEM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnExpPri;
        private System.Windows.Forms.Button btnInpPri;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExpPub;
        private System.Windows.Forms.Button btnInpPub;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDecTxt;
        private System.Windows.Forms.Button btnEncTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtKeyLength;
        private System.Windows.Forms.Button btnNewPriKey;
        private System.Windows.Forms.Button btnNewPubKey;
        private System.Windows.Forms.CheckBox checkBase64;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnDecFile;
        private System.Windows.Forms.Button btnEncFile;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.Button btnFrom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox txtAESKeyLength;
        private System.Windows.Forms.Button btnNewAES;
        private System.Windows.Forms.TabPage tabAES;
        private System.Windows.Forms.TextBox txtAES;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtSecMode;
        private System.Windows.Forms.RadioButton radioKeyMode2;
        private System.Windows.Forms.RadioButton radioKeyMode1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnInpAes;
        private System.Windows.Forms.Button btnExpAes;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

