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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtPrivatePEM = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPublicPEM = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInpPri = new System.Windows.Forms.Button();
            this.btnInpPub = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExpPri = new System.Windows.Forms.Button();
            this.btnExpPub = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDecTxt = new System.Windows.Forms.Button();
            this.btnEncTxt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeyLength = new System.Windows.Forms.ComboBox();
            this.btnNewPriKey = new System.Windows.Forms.Button();
            this.btnNewPubKey = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 586);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(689, 542);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.txtPrivatePEM);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(681, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "私钥";
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
            this.txtPrivatePEM.Size = new System.Drawing.Size(675, 503);
            this.txtPrivatePEM.TabIndex = 1;
            this.txtPrivatePEM.TextChanged += new System.EventHandler(this.txtPrivatePEM_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.txtPublicPEM);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(681, 509);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "公钥";
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
            this.txtPublicPEM.Size = new System.Drawing.Size(675, 503);
            this.txtPublicPEM.TabIndex = 2;
            this.txtPublicPEM.TextChanged += new System.EventHandler(this.txtPublicPEM_TextChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.txtText);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(681, 509);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "测试文本";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txtText
            // 
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtText.Location = new System.Drawing.Point(3, 3);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(675, 503);
            this.txtText.TabIndex = 4;
            this.txtText.Text = "在此输入测试用文本";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(855, 539);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
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
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(707, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 492);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInpPri);
            this.groupBox1.Controls.Add(this.btnInpPub);
            this.groupBox1.Location = new System.Drawing.Point(0, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 121);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入";
            // 
            // btnInpPri
            // 
            this.btnInpPri.Location = new System.Drawing.Point(6, 25);
            this.btnInpPri.Name = "btnInpPri";
            this.btnInpPri.Size = new System.Drawing.Size(129, 40);
            this.btnInpPri.TabIndex = 3;
            this.btnInpPri.Text = "导入私钥";
            this.btnInpPri.UseVisualStyleBackColor = true;
            this.btnInpPri.Click += new System.EventHandler(this.btnInpPri_Click);
            // 
            // btnInpPub
            // 
            this.btnInpPub.Location = new System.Drawing.Point(6, 71);
            this.btnInpPub.Name = "btnInpPub";
            this.btnInpPub.Size = new System.Drawing.Size(129, 40);
            this.btnInpPub.TabIndex = 3;
            this.btnInpPub.Text = "导入公钥";
            this.btnInpPub.UseVisualStyleBackColor = true;
            this.btnInpPub.Click += new System.EventHandler(this.btnInpPub_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExpPri);
            this.groupBox2.Controls.Add(this.btnExpPub);
            this.groupBox2.Location = new System.Drawing.Point(145, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 121);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出";
            // 
            // btnExpPri
            // 
            this.btnExpPri.Location = new System.Drawing.Point(6, 71);
            this.btnExpPri.Name = "btnExpPri";
            this.btnExpPri.Size = new System.Drawing.Size(129, 40);
            this.btnExpPri.TabIndex = 4;
            this.btnExpPri.Text = "导出私钥";
            this.btnExpPri.UseVisualStyleBackColor = true;
            this.btnExpPri.Click += new System.EventHandler(this.btnExpPri_Click);
            // 
            // btnExpPub
            // 
            this.btnExpPub.Location = new System.Drawing.Point(6, 25);
            this.btnExpPub.Name = "btnExpPub";
            this.btnExpPub.Size = new System.Drawing.Size(129, 40);
            this.btnExpPub.TabIndex = 4;
            this.btnExpPub.Text = "导出公钥";
            this.btnExpPub.UseVisualStyleBackColor = true;
            this.btnExpPub.Click += new System.EventHandler(this.btnExpPub_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDecTxt);
            this.groupBox3.Controls.Add(this.btnEncTxt);
            this.groupBox3.Location = new System.Drawing.Point(0, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(141, 120);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试文本";
            // 
            // btnDecTxt
            // 
            this.btnDecTxt.Location = new System.Drawing.Point(6, 71);
            this.btnDecTxt.Name = "btnDecTxt";
            this.btnDecTxt.Size = new System.Drawing.Size(129, 40);
            this.btnDecTxt.TabIndex = 4;
            this.btnDecTxt.Text = "解密";
            this.btnDecTxt.UseVisualStyleBackColor = true;
            this.btnDecTxt.Click += new System.EventHandler(this.btnDecTxt_Click);
            // 
            // btnEncTxt
            // 
            this.btnEncTxt.Location = new System.Drawing.Point(6, 25);
            this.btnEncTxt.Name = "btnEncTxt";
            this.btnEncTxt.Size = new System.Drawing.Size(129, 40);
            this.btnEncTxt.TabIndex = 4;
            this.btnEncTxt.Text = "加密";
            this.btnEncTxt.UseVisualStyleBackColor = true;
            this.btnEncTxt.Click += new System.EventHandler(this.btnEncTxt_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 9);
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
            this.comboBox1.Location = new System.Drawing.Point(175, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(821, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.groupBox4.Text = "建立";
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
            this.btnNewPubKey.Location = new System.Drawing.Point(151, 25);
            this.btnNewPubKey.Name = "btnNewPubKey";
            this.btnNewPubKey.Size = new System.Drawing.Size(129, 40);
            this.btnNewPubKey.TabIndex = 3;
            this.btnNewPubKey.Text = "从私钥提取公钥";
            this.btnNewPubKey.UseVisualStyleBackColor = true;
            this.btnNewPubKey.Click += new System.EventHandler(this.btnNewPubKey_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 608);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "密钥工具";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tabPage3;
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
        private System.Windows.Forms.TabPage tabPage5;
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
    }
}

