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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPublicXML = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtPrivateXML = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnNew = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPublicPEM = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtPrivatePEM = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(841, 22);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(670, 530);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage1.Controls.Add(this.txtPublicXML);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(662, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "公钥(XML)";
            // 
            // txtPublicXML
            // 
            this.txtPublicXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicXML.BackColor = System.Drawing.Color.Black;
            this.txtPublicXML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublicXML.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPublicXML.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPublicXML.Location = new System.Drawing.Point(6, 6);
            this.txtPublicXML.Multiline = true;
            this.txtPublicXML.Name = "txtPublicXML";
            this.txtPublicXML.Size = new System.Drawing.Size(650, 485);
            this.txtPublicXML.TabIndex = 0;
            this.txtPublicXML.Text = "[NONE]";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPage2.Controls.Add(this.txtPrivateXML);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(662, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "私钥(XML)";
            // 
            // txtPrivateXML
            // 
            this.txtPrivateXML.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivateXML.BackColor = System.Drawing.Color.Black;
            this.txtPrivateXML.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivateXML.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPrivateXML.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPrivateXML.Location = new System.Drawing.Point(6, 6);
            this.txtPrivateXML.Multiline = true;
            this.txtPrivateXML.Name = "txtPrivateXML";
            this.txtPrivateXML.Size = new System.Drawing.Size(650, 485);
            this.txtPrivateXML.TabIndex = 1;
            this.txtPrivateXML.Text = "[NONE]";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(688, 498);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(141, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(141, 40);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "建立新密钥对(&N)";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabPage3.Controls.Add(this.txtPublicPEM);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(662, 497);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "公钥(PEM)";
            // 
            // txtPublicPEM
            // 
            this.txtPublicPEM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPublicPEM.BackColor = System.Drawing.Color.Black;
            this.txtPublicPEM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublicPEM.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPublicPEM.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPublicPEM.Location = new System.Drawing.Point(6, 6);
            this.txtPublicPEM.Multiline = true;
            this.txtPublicPEM.Name = "txtPublicPEM";
            this.txtPublicPEM.Size = new System.Drawing.Size(650, 485);
            this.txtPublicPEM.TabIndex = 2;
            this.txtPublicPEM.Text = "[NONE]";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tabPage4.Controls.Add(this.txtPrivatePEM);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(662, 497);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "私钥(PEM)";
            // 
            // txtPrivatePEM
            // 
            this.txtPrivatePEM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrivatePEM.BackColor = System.Drawing.Color.Black;
            this.txtPrivatePEM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrivatePEM.Font = new System.Drawing.Font("Verdana", 10F);
            this.txtPrivatePEM.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPrivatePEM.Location = new System.Drawing.Point(6, 6);
            this.txtPrivatePEM.Multiline = true;
            this.txtPrivatePEM.Name = "txtPrivatePEM";
            this.txtPrivatePEM.Size = new System.Drawing.Size(650, 485);
            this.txtPrivatePEM.TabIndex = 3;
            this.txtPrivatePEM.Text = "[NONE]";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Location = new System.Drawing.Point(688, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 451);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 567);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPublicXML;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtPrivateXML;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtPublicPEM;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtPrivatePEM;
        private System.Windows.Forms.Panel panel1;
    }
}

